namespace LauncherApp
{
    partial class Form1
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
            label_username = new Label();
            label_password = new Label();
            panel1 = new Panel();
            label_title = new Label();
            button_register = new Button();
            button_login = new Button();
            textBox_pass = new TextBox();
            textBox_user = new TextBox();
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
            label_username.Location = new Point(27, 106);
            label_username.Name = "label_username";
            label_username.Size = new Size(112, 24);
            label_username.TabIndex = 0;
            label_username.Text = "Username:";
            label_username.Click += label_username_Click;
            // 
            // label_password
            // 
            label_password.AutoSize = true;
            label_password.Font = new Font("Arial", 12F, FontStyle.Bold);
            label_password.ForeColor = SystemColors.ControlLightLight;
            label_password.Location = new Point(29, 168);
            label_password.Name = "label_password";
            label_password.Size = new Size(110, 24);
            label_password.TabIndex = 1;
            label_password.Text = "Password:";
            label_password.Click += label_password_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(label_title);
            panel1.Controls.Add(button_register);
            panel1.Controls.Add(button_login);
            panel1.Controls.Add(textBox_pass);
            panel1.Controls.Add(textBox_user);
            panel1.Controls.Add(label_username);
            panel1.Controls.Add(label_password);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(382, 353);
            panel1.TabIndex = 2;
            // 
            // label_title
            // 
            label_title.AutoSize = true;
            label_title.Font = new Font("Arial", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label_title.ForeColor = SystemColors.ControlLightLight;
            label_title.Location = new Point(64, 21);
            label_title.Name = "label_title";
            label_title.Size = new Size(245, 55);
            label_title.TabIndex = 6;
            label_title.Text = "PPProject";
            // 
            // button_register
            // 
            button_register.Font = new Font("Segoe UI", 12F);
            button_register.Location = new Point(225, 249);
            button_register.Name = "button_register";
            button_register.Size = new Size(117, 54);
            button_register.TabIndex = 5;
            button_register.Text = "Register";
            button_register.UseVisualStyleBackColor = true;
            button_register.Click += button_register_Click;
            // 
            // button_login
            // 
            button_login.Font = new Font("Segoe UI", 12F);
            button_login.Location = new Point(36, 249);
            button_login.Name = "button_login";
            button_login.Size = new Size(119, 54);
            button_login.TabIndex = 4;
            button_login.Text = "Login";
            button_login.UseVisualStyleBackColor = true;
            button_login.Click += button_login_Click;
            // 
            // textBox_pass
            // 
            textBox_pass.Location = new Point(159, 168);
            textBox_pass.Name = "textBox_pass";
            textBox_pass.PasswordChar = '*';
            textBox_pass.Size = new Size(174, 27);
            textBox_pass.TabIndex = 3;
            textBox_pass.UseSystemPasswordChar = true;
            // 
            // textBox_user
            // 
            textBox_user.Location = new Point(159, 106);
            textBox_user.Name = "textBox_user";
            textBox_user.Size = new Size(174, 27);
            textBox_user.TabIndex = 2;
            // 
            // errorProvider_user
            // 
            errorProvider_user.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider_user.ContainerControl = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(382, 353);
            Controls.Add(panel1);
            Name = "Form1";
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
        private Label label_title;
        private ErrorProvider errorProvider_user;
    }
}
