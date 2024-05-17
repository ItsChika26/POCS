using System.Drawing.Text;
using System.Runtime.InteropServices;
using LauncherApp.Properties;
using Newtonsoft.Json;

namespace LauncherApp
{
    public partial class LoginForm : Form
    {
        private const string LoginDetailsFilePath = "loginDetails.txt";
        public LoginForm()
        {
            InitializeComponent();
            LoadLoginDetails();
            InitEvents();
            InitCustomLabelFont();

        }

        private void InitCustomLabelFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            int fontLength = Resources.osaka_re.Length;
            byte[] fontData = Resources.osaka_re;
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
            Login_Title.Font = new Font(pfc.Families[0], 32, FontStyle.Regular);
            pfc.Dispose();
            Marshal.FreeCoTaskMem(data);
        }

        private void LoadLoginDetails()
        {
            if (File.Exists(LoginDetailsFilePath))
            {
                string[] lines = File.ReadAllLines(LoginDetailsFilePath);
                if (lines.Length >= 2)
                {
                    textBox_user.Text = lines[0];
                    textBox_pass.Text = lines[1];
                    rememberDetailsCheckbox.Checked = true;
                }
            }
        }

        private void SaveLoginDetails()
        {
            if (rememberDetailsCheckbox.Checked)
            {
                string username = textBox_user.Text;
                string password = textBox_pass.Text;
                File.WriteAllText(LoginDetailsFilePath, $"{username}\n{password}");
            }
            else
            {
                File.Delete(LoginDetailsFilePath);
            }
        }
        private async void button_login_Click(object sender, EventArgs e)
        {
            if (!await Client.ServerAvailable())
            {
                MessageBox.Show("Server is not available");
                return;
            }
            string username = textBox_user.Text;
            string password = textBox_pass.Text;
            errorProvider_user.Clear();

            Request loginRequest = new() { Username = username, Password = password, Action = "Login" };
            string message = JsonConvert.SerializeObject(loginRequest);
            await Client.Instance.SendMessageAsync(message);

            var response = JsonConvert.DeserializeObject<Request>((await Client.Instance.ReceiveMessageAsync())!);
            if (response!.Success)
            {
                SaveLoginDetails();
                User.Instance.LoadUser(username, response.Level,Utils.BitmapFromBytes(response.Image));
                await LoadFriends();
                this.Hide();
                var form = new GameHub();
                form.ShowDialog();
                this.Show();

            }
            else
            {
                errorProvider_user.SetError(textBox_user, response.FailureMessage);
            }
        }

        private async void button_register_Click(object sender, EventArgs e)
        {
            if (!await Client.ServerAvailable())
            {
                MessageBox.Show(@"Server is not available");
                return;
            }
            string username = textBox_user.Text;
            string password = textBox_pass.Text;

            errorProvider_user.Clear();

            if (username.Length > 25 || username.Length < 4)
            {
                errorProvider_user.SetError(textBox_user, "Username must be between 4 and 25 characters long");
                return;
            }
            //if (password.Length < 8 || password.Length > 25)
            //{
            //    errorProvider_user.SetError(textBox_pass, "Password must be at least 8 characters long");
            //    return;
            //}
            //if (!password.Any(char.IsDigit))
            //{
            //    errorProvider_user.SetError(textBox_pass, "Password must contain at least one digit");
            //    return;
            //}
            if (!password.Any(char.IsUpper))
            {
                errorProvider_user.SetError(textBox_pass, "Password must contain at least one uppercase letter");
                return;
            }

            Request registerRequest = new() { Username = username, Password = password, Action = "Register" };
            var message = JsonConvert.SerializeObject(registerRequest);
            await Client.Instance.SendMessageAsync(message);
            var response = JsonConvert.DeserializeObject<Request>((await Client.Instance.ReceiveMessageAsync())!);

            if (response!.Success)
            {
                MessageBox.Show(@"User registered successfully");
            }
            else
            {
                errorProvider_user.SetError(textBox_user, response.FailureMessage);
            }

        }

        private async Task LoadFriends()
        {
            var request = new Request { Username = User.Instance.Username, Action = "LoadFriends" };
            var message = JsonConvert.SerializeObject(request);
            _ = Client.Instance.SendMessageAsync(message);
            var response = JsonConvert.DeserializeObject<Request>((await Client.Instance.ReceiveMessageAsync())!);
            User.Instance.UpdateFriends(response!.friends);
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            Client.Instance.Disconnect();
            this.Close();
        }

        private void Login_Title_Click(object sender, EventArgs e)
        {

        }

        private void Login_Title_Click_1(object sender, EventArgs e)
        {

        }

        private void menuButton_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = Color.Orange;
        }

        private void menuButton_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).ForeColor = Color.White;
        }

        private void InitEvents()
        {
            MinimizeButton.MouseEnter += menuButton_MouseEnter!;
            MinimizeButton.MouseLeave += menuButton_MouseLeave!;
            Exit_button.MouseEnter += menuButton_MouseEnter!;
            Exit_button.MouseLeave += menuButton_MouseLeave!;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
