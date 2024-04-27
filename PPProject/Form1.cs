using System.Windows.Forms;

namespace LauncherApp
{
    public partial class Form1 : Form
    {
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

        private void button_login_Click(object sender, EventArgs e)
        {
            string username = textBox_user.Text;
            string password = textBox_pass.Text;

            errorProvider_user.Clear();
            var user = Database.LoginUser(username, password);
            if (user != null) 
            {
                MessageBox.Show($"User {user.Username} with level {user.Level} logged in successfully");
            }
            else
            {
                errorProvider_user.SetError(textBox_user, "Invalid username or password");
            }
        }

        private void button_register_Click(object sender, EventArgs e)
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

            if(Database.RegisterUser(username, password))
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
