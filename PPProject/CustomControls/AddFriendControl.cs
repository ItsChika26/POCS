using Newtonsoft.Json;

namespace LauncherApp.CustomControls
{
    public partial class AddFriendControl : UserControl
    {
        private readonly GameHub _parent;
        public AddFriendControl(GameHub gameHub)
        {
            _parent = gameHub;
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var request = new Request { Username = User.Instance.Username,FriendUsername = textBox1.Text, Action = "AddFriend" };
            var message = JsonConvert.SerializeObject(request);
            _ = Client.Instance.SendMessageAsync(message);
            var response = JsonConvert.DeserializeObject<Request>((await Client.Instance.ReceiveMessageAsync())! );
            _parent.AddingFriends = false;
            if (response!.Success)
            {
                var load = JsonConvert.SerializeObject(new Request { Username = User.Instance.Username, Action = "LoadFriends" } );
                _ = Client.Instance.SendMessageAsync(load);
                response = JsonConvert.DeserializeObject<Request>((await Client.Instance.ReceiveMessageAsync())!);

                User.Instance.UpdateFriends(response!.friends);
                _parent.FriendListPanel.Controls.Clear();
                foreach (var friend in User.Instance.friends)
                {
                    var friendControl = new FriendListItem(friend);
                    _parent.FriendListPanel.Controls.Add(friendControl);
                }

                textBox1.Text = "";
                MessageBox.Show(@"Friend added successfully");
            }
            else
            {
                MessageBox.Show(response.FailureMessage);
            }
        }
    }
}
