using LauncherApp.CustomControls;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace LauncherApp
{
    public partial class GameHub : Form
    {
        public User usr = User.Instance;
        public Label SelectedFriendDisplay { get; set; }
        public Timer UpdateTimer { get; set; }
        private bool Connected { get; set; }
        public bool AddingFriends { get; set; }
        public AddFriendControl addFriendControl { get; set; }
        public Dictionary<string,FriendListItem> FriendListItems { get; set; }
        public Dictionary<string,PendingFriendListItem> PendingFriendListItems { get; set; }


        public GameHub()
        {
            InitializeComponent();
            UsernameLabel.Text = usr.Username;
            LevelNumberLabel.Text = usr.Level.ToString();
            roundedPicture1.Image = Utils.BitmapFromBytes(usr.Image);
            InitControls();
            SelectedFriendDisplay = AllLabel;
            Connected = true;
            AddingFriends = false;
            addFriendControl = new AddFriendControl(this);
            UpdateTimer = new Timer(_ => Client.Instance.Update(), null, 0, 5000);
            Client.Instance.OnDataUpdateEvent += LoadFriends;
        }

        private void LoadFriends(object sender, EventArgs e)
        {
            AddNewFriends();
            if (SelectedFriendDisplay == AllLabel)
            {
                LoadAllFriends(sender, e);
            }
            else if (SelectedFriendDisplay == PendingLabel)
            {
                LoadPendingFriends(sender, e);
            }
            else if (SelectedFriendDisplay == OnlineLabel)
            {
                LoadOnlineFriends(sender, e);
            }
        }

        private void LoadAllFriends(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                SelectedFriendDisplay = AllLabel;
                List<Control> controls = new();
                if (AddingFriends)
                    controls.Add(addFriendControl);
                foreach (var friend in FriendListItems.Values)
                {
                    if (!friend.FriendDetails.IsPending)
                    {
                        controls.Add(friend);
                    }
                }
                FriendListPanel.SuspendLayout();
                FriendListPanel.Controls.Clear();
                FriendListPanel.Controls.AddRange(controls.ToArray());
                FriendListPanel.ResumeLayout();

            });
        }

        private void LoadPendingFriends(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {

                SelectedFriendDisplay = PendingLabel;
                FriendListPanel.SuspendLayout();
                FriendListPanel.Controls.Clear();
                if (AddingFriends)
                    FriendListPanel.Controls.Add(addFriendControl);
                FriendListPanel.Controls.AddRange(PendingFriendListItems.Values.ToArray());
                FriendListPanel.ResumeLayout();
            });
        }

        private void LoadOnlineFriends(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {

                SelectedFriendDisplay = OnlineLabel;
                List<Control> controls = new();
                if (AddingFriends)
                    controls.Add(addFriendControl);
                foreach (var friend in FriendListItems.Values)
                {
                    if (!friend.FriendDetails.IsOnline || friend.FriendDetails.IsPending)
                        continue;
                    controls.Add(friend);
                }
                FriendListPanel.SuspendLayout();
                FriendListPanel.Controls.Clear();
                FriendListPanel.Controls.AddRange(controls.ToArray());
                FriendListPanel.ResumeLayout();
            });
        }

        private void InitControls()
        {
            for (int i = 0; i < 10; i++)
            {
                var gameControl = new GameControl();

                GameListPanel.Controls.Add(gameControl);

            }
            SetStyle(ControlStyles.AllPaintingInWmPaint,true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer,true);
            UpdateStyles();
            FriendListItems = new();
            PendingFriendListItems = new();
            foreach (var friend in User.Instance.friends.Values)
            {
                if (friend.IsPending)
                {
                    var friendControl1 = new PendingFriendListItem(friend);
                    PendingFriendListItems.Add(friend.Username, friendControl1);
                    continue;
                }
                var friendControl = new FriendListItem(friend);
                FriendListItems.Add(friend.Username,friendControl);
            }

        }

        public void AddNewFriends()
        {
            foreach (var friend in User.Instance.friends.Values)
            {
                if (!FriendListItems.ContainsKey(friend.Username))
                {
                    var friendControl = new FriendListItem(friend);
                    FriendListItems.Add(friend.Username, friendControl);
                }
            }
        }

        private async void LogoutButton_Click(object sender, EventArgs e)
        {
            if (Connected)
            {
                UpdateTimer.Dispose();
                var request = new Request() { Action = "Logout", Username = User.Instance.Username };
                var message = JsonConvert.SerializeObject(request);
                await Client.Instance.SendMessageAsync(message);
                Client.Instance.Disconnect();
                User.Instance.Dispose();
                Connected = false;
                Close();
            }
        }


        private void FilterLabel_MouseEnter(object sender, EventArgs e)
        {
            var label = (Label)sender;
            label.ForeColor = Color.FromArgb(255, 4, 198, 202);
        }

        private void FilterLabel_MouseLeave(object sender, EventArgs e)
        {
            var label = (Label)sender;
            label.ForeColor = Color.White;
        }

        private void AddFriendButton_Click(object sender, EventArgs e)
        {
            AddingFriends = true;
            FriendListPanel.Controls.Add(addFriendControl);
            FriendListPanel.Controls.SetChildIndex(addFriendControl, 0);
        }

        // ...

        private async void roundedPicture1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpeg;*.jpg;*.png)|*.jpeg;*.jpg;*.png";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    if (new FileInfo(filePath).Length <= 4 * 1024 * 1024) // Check if file size is less than 2MB
                    {
                        ImageFormat imageFormat;
                        if (Path.GetExtension(filePath).Equals(".png", StringComparison.OrdinalIgnoreCase))
                        {
                            imageFormat = ImageFormat.Png;
                        }
                        else
                        {
                            imageFormat = ImageFormat.Jpeg;
                        }

                        var image = Utils.BytesFromBitmap((Bitmap)Image.FromFile(filePath), imageFormat);
                        var request = new Request() { Action = "UpdateIcon", Username = User.Instance.Username, Image = image };
                        var message = JsonConvert.SerializeObject(request);
                        _ = Client.Instance.SendMessageAsync(message);
                        var response = JsonConvert.DeserializeObject<Request>((await Client.Instance.ReceiveMessageAsync())!);
                        MessageBox.Show(response!.Success ? "Icon updated successfully" : response.FailureMessage);
                        roundedPicture1.Image = Image.FromFile(filePath);
                    }
                    else
                    {
                        MessageBox.Show(@"The selected image exceeds the maximum file size limit of 2MB.");
                    }
                }
            }
        }
    }
}