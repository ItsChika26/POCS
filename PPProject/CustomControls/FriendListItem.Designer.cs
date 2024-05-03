namespace LauncherApp.CustomControls
{
    partial class FriendListItem
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
            ((System.ComponentModel.ISupportInitialize)ProfilePicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // ProfilePicture
            // 
            ProfilePicture.Image = Properties.Resources.c0589be1b84c602dae8e97419541708d;
            ProfilePicture.Location = new Point(3, 3);
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
            // FriendListItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 44, 98);
            Controls.Add(LevelNumberLabel);
            Controls.Add(LevelLabel);
            Controls.Add(UsernameLabel);
            Controls.Add(ProfilePicture);
            Name = "FriendListItem";
            Padding = new Padding(2);
            Size = new Size(239, 50);
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
    }
}
