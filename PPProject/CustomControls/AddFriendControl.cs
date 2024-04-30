using Newtonsoft.Json;

namespace LauncherApp.CustomControls
{
    public partial class AddFriendControl : UserControl
    {
        public AddFriendControl()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var request = new Request { Username = textBox1.Text, Action = "AddFriend" };
            var message = JsonConvert.SerializeObject(request);
            Client.Instance.SendMessageAsync(message);
            var response = JsonConvert.DeserializeObject<Request>(Client.Instance.ReceiveMessageAsync().Result);
            if (response.Success)
            {
                User.Instance.UpdateFriends(response.friends);
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
