using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace LauncherApp
{
    public partial class LoginForm : Form
    {
        Client client = Client.Instance;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label_password_Click(object sender, EventArgs e)
        {

        }

        private void label_username_Click(object sender, EventArgs e)
        {

        }

        private async void button_login_Click(object sender, EventArgs e)
        {
            if (!client.IsConnected)
            { 
                client.Connect("20.215.40.53",8080);
                if (!client.IsConnected)
                {
                    MessageBox.Show("Server is not available");
                    return;
                }
            }
            
            string username = textBox_user.Text;
            string password = textBox_pass.Text;
            errorProvider_user.Clear();

            Request loginRequest = new() { Username = username, Password = password, Action = "Login"};
            string message = JsonConvert.SerializeObject(loginRequest);

            var response = JsonConvert.DeserializeObject<Request>(await client.SendMessage(message)) ;
            if (response.Success) 
            {
                User.Instance.LoadUser(username, response.Level);
                this.Hide();
                var form = new GameHub(User.Instance);
                form.ShowDialog();
                this.Close();
                //MessageBox.Show($"User {user.Username} with level {user.Level} logged in successfully");
            }
            else
            {
                errorProvider_user.SetError(textBox_user, response.FailureMessage);
            }
        }

        private async void button_register_Click(object sender, EventArgs e)
        {
            if (!client.IsConnected)
            { 
                client.Connect("20.215.40.53",8080);
                if (!client.IsConnected)
                {
                    MessageBox.Show("Server is not available");
                    return;
                }
            }
            string username = textBox_user.Text;
            string password = textBox_pass.Text;

            errorProvider_user.Clear();
          
            if (username.Length > 25 || username.Length < 4)
            {
                errorProvider_user.SetError(textBox_user, "Username must be between 4 and 25 characters long");
                return;
            }
            if (password.Length < 8 || password.Length > 25)
            {
                errorProvider_user.SetError(textBox_pass, "Password must be at least 8 characters long");
                return;
            }
            if (!password.Any(char.IsDigit))
            {
                errorProvider_user.SetError(textBox_pass, "Password must contain at least one digit");
                return;
            }
            if (!password.Any(char.IsUpper))
            {
                errorProvider_user.SetError(textBox_pass, "Password must contain at least one uppercase letter");
                return;
            }

            Request registerRequest = new() { Username = username, Password = password,Action = "Register"};
            var message = JsonConvert.SerializeObject(registerRequest);

            var response = JsonConvert.DeserializeObject<Request>(await client.SendMessage(message));

            if(response.Success)
            {
                MessageBox.Show("User registered successfully");
            }
            else
            {
                errorProvider_user.SetError(textBox_user, response.FailureMessage);
            }
            
        }
    }
}
