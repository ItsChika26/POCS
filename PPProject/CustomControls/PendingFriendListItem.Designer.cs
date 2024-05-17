namespace LauncherApp.CustomControls
{
    partial class PendingFriendListItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ProfilePicture = new RoundedPicture();
            UsernameLabel = new Label();
            LevelLabel = new Label();
            LevelNumberLabel = new Label();
            fileSystemWatcher1 = new FileSystemWatcher();
            AcceptButton = new Button();
            IgnoreButton = new Button();
            TimeLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ProfilePicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // ProfilePicture
            // 
            ProfilePicture.Image = Properties.Resources.c0589be1b84c602dae8e97419541708d;
            ProfilePicture.Location = new Point(5, 5);
            ProfilePicture.Name = "ProfilePicture";
            ProfilePicture.Size = new Size(42, 42);
            ProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            ProfilePicture.TabIndex = 2;
            ProfilePicture.TabStop = false;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.BackColor = Color.FromArgb(60, 44, 98);
            UsernameLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameLabel.ForeColor = SystemColors.ButtonHighlight;
            UsernameLabel.Location = new Point(51, 2);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(104, 28);
            UsernameLabel.TabIndex = 3;
            UsernameLabel.Text = "Username";
            // 
            // LevelLabel
            // 
            LevelLabel.AutoSize = true;
            LevelLabel.BackColor = Color.FromArgb(60, 44, 98);
            LevelLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            LevelLabel.ForeColor = SystemColors.ActiveBorder;
            LevelLabel.Location = new Point(51, 25);
            LevelLabel.Name = "LevelLabel";
            LevelLabel.Size = new Size(44, 20);
            LevelLabel.TabIndex = 4;
            LevelLabel.Text = "Level";
            // 
            // LevelNumberLabel
            // 
            LevelNumberLabel.AutoSize = true;
            LevelNumberLabel.BackColor = Color.FromArgb(60, 44, 98);
            LevelNumberLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            LevelNumberLabel.ForeColor = Color.FromArgb(255, 128, 0);
            LevelNumberLabel.Location = new Point(90, 25);
            LevelNumberLabel.Name = "LevelNumberLabel";
            LevelNumberLabel.Size = new Size(17, 20);
            LevelNumberLabel.TabIndex = 5;
            LevelNumberLabel.Text = "0";
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // AcceptButton
            // 
            AcceptButton.BackColor = Color.FromArgb(4, 198, 202);
            AcceptButton.FlatAppearance.BorderSize = 0;
            AcceptButton.FlatStyle = FlatStyle.Flat;
            AcceptButton.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            AcceptButton.ForeColor = SystemColors.ButtonHighlight;
            AcceptButton.Location = new Point(157, 5);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(77, 25);
            AcceptButton.TabIndex = 9;
            AcceptButton.Text = "Accept";
            AcceptButton.UseVisualStyleBackColor = false;
            AcceptButton.Click += AcceptButton_Click;
            // 
            // IgnoreButton
            // 
            IgnoreButton.BackColor = Color.DarkGray;
            IgnoreButton.FlatAppearance.BorderSize = 0;
            IgnoreButton.FlatStyle = FlatStyle.Flat;
            IgnoreButton.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            IgnoreButton.ForeColor = SystemColors.ButtonHighlight;
            IgnoreButton.Location = new Point(157, 36);
            IgnoreButton.Name = "IgnoreButton";
            IgnoreButton.Size = new Size(77, 25);
            IgnoreButton.TabIndex = 10;
            IgnoreButton.Text = "Ignore";
            IgnoreButton.UseVisualStyleBackColor = false;
            IgnoreButton.Click += IgnoreButton_Click;
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.BackColor = Color.FromArgb(60, 44, 98);
            TimeLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            TimeLabel.ForeColor = SystemColors.ButtonFace;
            TimeLabel.Location = new Point(5, 46);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(56, 20);
            TimeLabel.TabIndex = 11;
            TimeLabel.Text = "9d ago";
            TimeLabel.Click += TimeLabel_Click;
            // 
            // PendingFriendListItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 44, 98);
            Controls.Add(ProfilePicture);
            Controls.Add(TimeLabel);
            Controls.Add(IgnoreButton);
            Controls.Add(AcceptButton);
            Controls.Add(LevelNumberLabel);
            Controls.Add(LevelLabel);
            Controls.Add(UsernameLabel);
            Name = "PendingFriendListItem";
            Padding = new Padding(2);
            Size = new Size(239, 68);
            MouseEnter += FriendListItem_MouseEnter;
            MouseLeave += FriendListItem_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)ProfilePicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RoundedPicture ProfilePicture;
        private Label UsernameLabel;
        private Label LevelLabel;
        private Label LevelNumberLabel;
        private FileSystemWatcher fileSystemWatcher1;
        private Button AcceptButton;
        private Button IgnoreButton;
        private Label TimeLabel;
    }
}
