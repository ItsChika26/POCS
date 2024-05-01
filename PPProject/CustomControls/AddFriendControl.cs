using Newtonsoft.Json;

namespace LauncherApp.CustomControls
{
    public partial class AddFriendControl : UserControl
    {
        GameHub parent;
        public AddFriendControl()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var request = new Request { Username = User.Instance.Username,FriendUsername = textBox1.Text, Action = "AddFriend" };
            var message = JsonConvert.SerializeObject(request);
            Client.Instance.SendMessageAsync(message);
            var response = JsonConvert.DeserializeObject<Request>(Client.Instance.ReceiveMessageAsync().Result);
            if (response.Success)
            {
                var load = JsonConvert.SerializeObject(new Request { Username = User.Instance.Username, Action = "LoadFriends" } );
                Client.Instance.SendMessageAsync(load);
                response = JsonConvert.DeserializeObject<Request>(Client.Instance.ReceiveMessageAsync().Result);

                User.Instance.UpdateFriends(response.friends);
                parent.FriendListPanel.Controls.Clear();
                foreach (var friend in User.Instance.friends)
                {
                    var friendControl = new FriendListItem(friend);
                    parent.FriendListPanel.Controls.Add(friendControl);
                }

                textBox1.Text = "";
                MessageBox.Show("Friend added successfully");
            }
            else
            {
                MessageBox.Show(response.FailureMessage);
            }
        }
    }
}
