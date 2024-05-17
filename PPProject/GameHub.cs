using LauncherApp.CustomControls;
using Newtonsoft.Json;
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

        public GameHub()
        {
            InitializeComponent();
            UsernameLabel.Text = usr.Username;
            LevelNumberLabel.Text = usr.Level.ToString();
            InitControls();
            SelectedFriendDisplay = AllLabel;
            Connected = true;
            AddingFriends = false;
            addFriendControl = new AddFriendControl(this);
            UpdateTimer = new Timer(_ => Client.Instance.Update(), null, 0, 5000);

        }

        private void LoadFriends(object sender, EventArgs e)
        {
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
                FriendListPanel.SuspendLayout();
                FriendListPanel.Controls.Clear();

                SelectedFriendDisplay = AllLabel;

                if (AddingFriends)
                {
                    FriendListPanel.Controls.Add(addFriendControl);
                }

                foreach (var friend in User.Instance.friends)
                {
                    if (friend.IsPending)
                        continue;
                    var friendControl = new FriendListItem(friend);
                    FriendListPanel.Controls.Add(friendControl);
                }

                for(int i = 0; i < 30; i++)
                {
                    FriendListPanel.Controls.Add(new FriendListItem(User.Instance.friends[0]));
                }

                FriendListPanel.ResumeLayout();
            });
        }

        private void LoadPendingFriends(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                SelectedFriendDisplay = PendingLabel;
                FriendListPanel.Controls.Clear();
                if (AddingFriends)
                {
                    FriendListPanel.Controls.Add(addFriendControl);
                }

                foreach (var friend in User.Instance.friends)
                {
                    if (!friend.IsPending || !friend.IsRequestOwner)
                        continue;
                    var friendControl = new PendingFriendListItem(friend);
                    FriendListPanel.Controls.Add(friendControl);
                }
            });
        }

        private void LoadOnlineFriends(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                SelectedFriendDisplay = OnlineLabel;
                List<Control> controls = new();
                if (AddingFriends)
                {
                    FriendListPanel.Controls.Add(addFriendControl);
                }
                foreach (var friend in User.Instance.friends)
                {
                    if (!friend.IsOnline)
                        continue;
                    var friendControl = new FriendListItem(friend);
                    controls.Add(friendControl);
                }
                FriendListPanel.Controls.Clear();
                FriendListPanel.Controls.AddRange(controls.ToArray());
            });
        }

        private void InitControls()
        {
            for (int i = 0; i < 10; i++)
            {
                var gameControl = new GameControl();

                GameListPanel.Controls.Add(gameControl);

            }

            Client.Instance.OnDataUpdateEvent += LoadFriends;

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
                this.Close();
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
    }
}