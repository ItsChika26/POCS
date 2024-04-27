using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace LauncherApp
{
    public partial class Form1 : Form
    {
        Client client = Client.Instance;
        public Form1()
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
            string username = textBox_user.Text;
            string password = textBox_pass.Text;

            Request loginRequest = new() { Username = username, Password = password, Action = "Login"};
            string message = JsonConvert.SerializeObject(loginRequest);

            var response = await client.SendMessage(message);
            if (!response.IsNullOrEmpty()) 
            {
                var user = JsonConvert.DeserializeObject<User>(response);
                MessageBox.Show($"User {user.Username} with level {user.Level} logged in successfully");
            }
            else
            {
                errorProvider_user.SetError(textBox_user, "Invalid username or password");
            }
        }

        private async void button_register_Click(object sender, EventArgs e)
        {
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

            var response = await client.SendMessage(message);

            if(response!=null)
            {
                MessageBox.Show("User registered successfully");
            }
            else
            {
                errorProvider_user.SetError(textBox_user, "Username already exists");
            }
            
        }
    }
}
