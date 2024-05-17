namespace LauncherApp
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label_username = new Label();
            label_password = new Label();
            panel1 = new Panel();
            Login_Title = new Label();
            MinimizeButton = new Button();
            Exit_button = new Button();
            rememberDetailsCheckbox = new CheckBox();
            textBox_user = new TextBox();
            button_register = new Button();
            button_login = new Button();
            textBox_pass = new TextBox();
            errorProvider_user = new ErrorProvider(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider_user).BeginInit();
            SuspendLayout();
            // 
            // label_username
            // 
            label_username.AutoSize = true;
            label_username.Font = new Font("Arial", 12F, FontStyle.Bold);
            label_username.ForeColor = SystemColors.ControlLightLight;
            label_username.Location = new Point(20, 171);
            label_username.Name = "label_username";
            label_username.Size = new Size(112, 24);
            label_username.TabIndex = 0;
            label_username.Text = "Username:";
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Arial", 12F, FontStyle.Bold);
            label_password.ForeColor = SystemColors.ControlLightLight;
            label_password.Location = new Point(23, 219);
            label_password.Name = "label_password";
            label_password.Size = new Size(110, 24);
            label_password.TabIndex = 1;
            label_password.Text = "Password:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(61, 44, 98);
            panel1.Controls.Add(Login_Title);
            panel1.Controls.Add(MinimizeButton);
            panel1.Controls.Add(Exit_button);
            panel1.Controls.Add(rememberDetailsCheckbox);
            panel1.Controls.Add(textBox_user);
            panel1.Controls.Add(label_username);
            panel1.Controls.Add(button_register);
            panel1.Controls.Add(button_login);
            panel1.Controls.Add(textBox_pass);
            panel1.Controls.Add(label_password);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(382, 383);
            panel1.TabIndex = 2;
            // 
            // Login_Title
            // 
            Login_Title.AutoSize = true;
            Login_Title.Font = new Font("Osaka-Sans Serif", 32F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Login_Title.ForeColor = Color.FromArgb(255, 128, 0);
            Login_Title.Location = new Point(57, 28);
            Login_Title.Name = "Login_Title";
            Login_Title.Size = new Size(312, 133);
            Login_Title.TabIndex = 6;
            Login_Title.Text = "POCS\r\nLauncher\r\n";
            Login_Title.TextAlign = ContentAlignment.MiddleCenter;
            Login_Title.UseCompatibleTextRendering = true;
            // 
            // MinimizeButton
            // 
            MinimizeButton.BackColor = Color.FromArgb(61, 44, 98);
            MinimizeButton.FlatAppearance.BorderSize = 0;
            MinimizeButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(61, 44, 98);
            MinimizeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(61, 44, 98);
            MinimizeButton.FlatStyle = FlatStyle.Flat;
            MinimizeButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            MinimizeButton.ForeColor = Color.White;
            errorProvider_user.SetIconAlignment(MinimizeButton, ErrorIconAlignment.MiddleLeft);
            MinimizeButton.Location = new Point(313, -5);
            MinimizeButton.Margin = new Padding(0);
            MinimizeButton.Name = "MinimizeButton";
            MinimizeButton.Size = new Size(30, 41);
            MinimizeButton.TabIndex = 9;
            MinimizeButton.Text = "_";
            MinimizeButton.UseCompatibleTextRendering = true;
            MinimizeButton.UseVisualStyleBackColor = false;
            MinimizeButton.Click += MinimizeButton_Click;
            // 
            // Exit_button
            // 
            Exit_button.BackColor = Color.FromArgb(61, 44, 98);
            Exit_button.FlatAppearance.BorderSize = 0;
            Exit_button.FlatAppearance.MouseDownBackColor = Color.FromArgb(61, 44, 98);
            Exit_button.FlatAppearance.MouseOverBackColor = Color.FromArgb(61, 44, 98);
            Exit_button.FlatStyle = FlatStyle.Flat;
            Exit_button.Font = new Font("Segoe UI", 15F);
            Exit_button.ForeColor = Color.White;
            errorProvider_user.SetIconAlignment(Exit_button, ErrorIconAlignment.MiddleLeft);
            Exit_button.Location = new Point(343, 5);
            Exit_button.Margin = new Padding(0);
            Exit_button.Name = "Exit_button";
            Exit_button.Size = new Size(30, 31);
            Exit_button.TabIndex = 3;
            Exit_button.Text = "x";
            Exit_button.UseCompatibleTextRendering = true;
            Exit_button.UseVisualStyleBackColor = false;
            Exit_button.Click += Exit_button_Click;
            // 
            // rememberDetailsCheckbox
            // 
            rememberDetailsCheckbox.AutoSize = true;
            rememberDetailsCheckbox.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rememberDetailsCheckbox.ForeColor = Color.FromArgb(255, 128, 0);
            rememberDetailsCheckbox.Location = new Point(102, 335);
            rememberDetailsCheckbox.Name = "rememberDetailsCheckbox";
            rememberDetailsCheckbox.Size = new Size(161, 22);
            rememberDetailsCheckbox.TabIndex = 7;
            rememberDetailsCheckbox.Text = "Remember Details?";
            rememberDetailsCheckbox.UseVisualStyleBackColor = true;
            // 
            // textBox_user
            // 
            textBox_user.BackColor = SystemColors.Window;
            textBox_user.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox_user.ForeColor = SystemColors.WindowText;
            textBox_user.Location = new Point(136, 164);
            textBox_user.Name = "textBox_user";
            textBox_user.Size = new Size(210, 34);
            textBox_user.TabIndex = 2;
            // 
            // button_register
            // 
            button_register.BackColor = Color.FromArgb(4, 189, 202);
            button_register.Cursor = Cursors.Hand;
            button_register.FlatAppearance.BorderSize = 0;
            button_register.FlatStyle = FlatStyle.Flat;
            button_register.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button_register.ForeColor = SystemColors.ControlLightLight;
            button_register.Location = new Point(190, 259);
            button_register.Name = "button_register";
            button_register.Padding = new Padding(0, 0, 0, 3);
            button_register.Size = new Size(156, 54);
            button_register.TabIndex = 5;
            button_register.Text = "Register";
            button_register.UseVisualStyleBackColor = false;
            button_register.Click += button_register_Click;
            // 
            // button_login
            // 
            button_login.BackColor = Color.FromArgb(4, 189, 202);
            button_login.Cursor = Cursors.Hand;
            button_login.FlatAppearance.BorderSize = 0;
            button_login.FlatStyle = FlatStyle.Flat;
            button_login.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button_login.ForeColor = SystemColors.ControlLightLight;
            button_login.Location = new Point(23, 259);
            button_login.Name = "button_login";
            button_login.Padding = new Padding(0, 0, 0, 3);
            button_login.Size = new Size(152, 54);
            button_login.TabIndex = 4;
            button_login.Text = "Login";
            button_login.UseVisualStyleBackColor = false;
            button_login.Click += button_login_Click;
            // 
            // textBox_pass
            // 
            textBox_pass.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBox_pass.Location = new Point(136, 212);
            textBox_pass.Name = "textBox_pass";
            textBox_pass.Size = new Size(210, 34);
            textBox_pass.TabIndex = 3;
            textBox_pass.UseSystemPasswordChar = true;
            // 
            // errorProvider_user
            // 
            errorProvider_user.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider_user.ContainerControl = this;
            errorProvider_user.Icon = (Icon)resources.GetObject("errorProvider_user.Icon");
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(382, 383);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign In";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider_user).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label_username;
        private Label label_password;
        private Panel panel1;
        private Button button_register;
        private Button button_login;
        private TextBox textBox_pass;
        private TextBox textBox_user;
        private ErrorProvider errorProvider_user;
        private CheckBox rememberDetailsCheckbox;
        private Button Exit_button;
        private Label Login_Title;
        private Button MinimizeButton;
    }
}
