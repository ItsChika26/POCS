namespace LauncherApp
{
    partial class GameHub
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AccountPanel = new Panel();
            roundedPicture1 = new RoundedPicture();
            panel7 = new Panel();
            panel12 = new Panel();
            panel13 = new Panel();
            label5 = new Label();
            label3 = new Label();
            UsernameLabel = new Label();
            panel11 = new Panel();
            ExpLabel = new Label();
            label2 = new Label();
            LevelNumberLabel = new Label();
            LevelProgressBar = new ProgressBar();
            LevelLabel = new Label();
            LogoutButton = new Button();
            panel6 = new Panel();
            FriendsPanel = new Panel();
            FriendListContainerPanel = new Panel();
            FriendListPanel = new FlowLayoutPanel();
            AddFriendButton = new Button();
            panel3 = new Panel();
            PendingLabel = new Label();
            AllLabel = new Label();
            OnlineLabel = new Label();
            panel2 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            GamesPanel = new Panel();
            panel8 = new Panel();
            label4 = new Label();
            panel9 = new Panel();
            panel10 = new Panel();
            DeleteGameButton = new Button();
            AddGameButton = new Button();
            panel5 = new Panel();
            panel4 = new Panel();
            fileSystemWatcher1 = new FileSystemWatcher();
            AccountPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)roundedPicture1).BeginInit();
            panel7.SuspendLayout();
            panel12.SuspendLayout();
            panel11.SuspendLayout();
            FriendsPanel.SuspendLayout();
            FriendListContainerPanel.SuspendLayout();
            panel3.SuspendLayout();
            GamesPanel.SuspendLayout();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // AccountPanel
            // 
            AccountPanel.Controls.Add(roundedPicture1);
            AccountPanel.Controls.Add(panel7);
            AccountPanel.Controls.Add(panel6);
            AccountPanel.Dock = DockStyle.Left;
            AccountPanel.Location = new Point(0, 0);
            AccountPanel.Name = "AccountPanel";
            AccountPanel.Padding = new Padding(5);
            AccountPanel.Size = new Size(300, 628);
            AccountPanel.TabIndex = 0;
            // 
            // roundedPicture1
            // 
            roundedPicture1.Image = Properties.Resources.c0589be1b84c602dae8e97419541708d;
            roundedPicture1.Location = new Point(81, 21);
            roundedPicture1.Name = "roundedPicture1";
            roundedPicture1.Size = new Size(135, 135);
            roundedPicture1.SizeMode = PictureBoxSizeMode.StretchImage;
            roundedPicture1.TabIndex = 1;
            roundedPicture1.TabStop = false;
            roundedPicture1.Click += roundedPicture1_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(42, 31, 61);
            panel7.Controls.Add(panel12);
            panel7.Controls.Add(label3);
            panel7.Controls.Add(UsernameLabel);
            panel7.Controls.Add(panel11);
            panel7.Controls.Add(LogoutButton);
            panel7.Location = new Point(8, 98);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10, 0, 10, 10);
            panel7.Size = new Size(286, 522);
            panel7.TabIndex = 7;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(60, 44, 98);
            panel12.Controls.Add(panel13);
            panel12.Controls.Add(label5);
            panel12.Location = new Point(13, 175);
            panel12.Name = "panel12";
            panel12.Padding = new Padding(2);
            panel12.Size = new Size(259, 272);
            panel12.TabIndex = 15;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(4, 198, 202);
            panel13.Location = new Point(5, 30);
            panel13.Name = "panel13";
            panel13.Size = new Size(250, 2);
            panel13.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(0, 2);
            label5.Name = "label5";
            label5.Padding = new Padding(4, 0, 0, 0);
            label5.Size = new Size(137, 25);
            label5.TabIndex = 4;
            label5.Text = "Achievements";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            label3.ForeColor = SystemColors.ButtonShadow;
            label3.Location = new Point(13, 50);
            label3.Name = "label3";
            label3.Padding = new Padding(4, 0, 0, 0);
            label3.Size = new Size(80, 20);
            label3.TabIndex = 14;
            label3.Text = "Welcome,";
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            UsernameLabel.ForeColor = SystemColors.ButtonHighlight;
            UsernameLabel.Location = new Point(13, 61);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(156, 41);
            UsernameLabel.TabIndex = 2;
            UsernameLabel.Text = "Username";
            UsernameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(60, 44, 98);
            panel11.Controls.Add(ExpLabel);
            panel11.Controls.Add(label2);
            panel11.Controls.Add(LevelNumberLabel);
            panel11.Controls.Add(LevelProgressBar);
            panel11.Controls.Add(LevelLabel);
            panel11.Location = new Point(13, 105);
            panel11.Name = "panel11";
            panel11.Padding = new Padding(2);
            panel11.Size = new Size(260, 64);
            panel11.TabIndex = 13;
            // 
            // ExpLabel
            // 
            ExpLabel.AutoSize = true;
            ExpLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            ExpLabel.ForeColor = SystemColors.ButtonHighlight;
            ExpLabel.Location = new Point(192, 9);
            ExpLabel.Name = "ExpLabel";
            ExpLabel.Padding = new Padding(4, 0, 0, 0);
            ExpLabel.Size = new Size(27, 25);
            ExpLabel.TabIndex = 5;
            ExpLabel.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label2.ForeColor = SystemColors.ButtonShadow;
            label2.Location = new Point(215, 9);
            label2.Name = "label2";
            label2.Size = new Size(44, 25);
            label2.TabIndex = 6;
            label2.Text = "/ 10";
            // 
            // LevelNumberLabel
            // 
            LevelNumberLabel.AutoSize = true;
            LevelNumberLabel.BackColor = Color.FromArgb(60, 44, 98);
            LevelNumberLabel.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            LevelNumberLabel.ForeColor = Color.FromArgb(255, 128, 0);
            LevelNumberLabel.Location = new Point(60, 4);
            LevelNumberLabel.Name = "LevelNumberLabel";
            LevelNumberLabel.Size = new Size(24, 32);
            LevelNumberLabel.TabIndex = 5;
            LevelNumberLabel.Text = "1";
            LevelNumberLabel.Click += LevelNumberLabel_Click;
            // 
            // LevelProgressBar
            // 
            LevelProgressBar.BackColor = Color.FromArgb(60, 44, 98);
            LevelProgressBar.ForeColor = SystemColors.ActiveCaptionText;
            LevelProgressBar.Location = new Point(5, 37);
            LevelProgressBar.Name = "LevelProgressBar";
            LevelProgressBar.Size = new Size(250, 20);
            LevelProgressBar.TabIndex = 4;
            LevelProgressBar.Value = 20;
            // 
            // LevelLabel
            // 
            LevelLabel.AutoSize = true;
            LevelLabel.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            LevelLabel.ForeColor = SystemColors.ButtonHighlight;
            LevelLabel.Location = new Point(5, 9);
            LevelLabel.Name = "LevelLabel";
            LevelLabel.Size = new Size(56, 25);
            LevelLabel.TabIndex = 3;
            LevelLabel.Text = "Level";
            // 
            // LogoutButton
            // 
            LogoutButton.BackColor = Color.FromArgb(4, 198, 202);
            LogoutButton.FlatAppearance.BorderSize = 0;
            LogoutButton.FlatStyle = FlatStyle.Flat;
            LogoutButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LogoutButton.ForeColor = SystemColors.ButtonHighlight;
            LogoutButton.Location = new Point(12, 462);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(260, 47);
            LogoutButton.TabIndex = 0;
            LogoutButton.Text = "Log Out";
            LogoutButton.UseVisualStyleBackColor = false;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(4, 198, 202);
            panel6.Location = new Point(8, 95);
            panel6.Name = "panel6";
            panel6.Size = new Size(284, 2);
            panel6.TabIndex = 6;
            // 
            // FriendsPanel
            // 
            FriendsPanel.Controls.Add(FriendListContainerPanel);
            FriendsPanel.Controls.Add(AddFriendButton);
            FriendsPanel.Controls.Add(panel3);
            FriendsPanel.Controls.Add(panel2);
            FriendsPanel.Controls.Add(panel1);
            FriendsPanel.Controls.Add(label1);
            FriendsPanel.Dock = DockStyle.Right;
            FriendsPanel.Location = new Point(882, 0);
            FriendsPanel.Name = "FriendsPanel";
            FriendsPanel.Padding = new Padding(5);
            FriendsPanel.Size = new Size(300, 628);
            FriendsPanel.TabIndex = 1;
            FriendsPanel.Paint += FriendsPanel_Paint;
            // 
            // FriendListContainerPanel
            // 
            FriendListContainerPanel.AutoScroll = true;
            FriendListContainerPanel.BackColor = Color.FromArgb(42, 31, 61);
            FriendListContainerPanel.Controls.Add(FriendListPanel);
            FriendListContainerPanel.Location = new Point(11, 207);
            FriendListContainerPanel.Name = "FriendListContainerPanel";
            FriendListContainerPanel.Padding = new Padding(5);
            FriendListContainerPanel.Size = new Size(281, 413);
            FriendListContainerPanel.TabIndex = 8;
            // 
            // FriendListPanel
            // 
            FriendListPanel.AutoSize = true;
            FriendListPanel.FlowDirection = FlowDirection.TopDown;
            FriendListPanel.Location = new Point(8, 9);
            FriendListPanel.Name = "FriendListPanel";
            FriendListPanel.Size = new Size(245, 396);
            FriendListPanel.TabIndex = 8;
            // 
            // AddFriendButton
            // 
            AddFriendButton.BackColor = Color.FromArgb(4, 198, 202);
            AddFriendButton.FlatAppearance.BorderSize = 0;
            AddFriendButton.FlatStyle = FlatStyle.Flat;
            AddFriendButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddFriendButton.ForeColor = SystemColors.ButtonHighlight;
            AddFriendButton.Location = new Point(11, 95);
            AddFriendButton.Name = "AddFriendButton";
            AddFriendButton.Size = new Size(281, 47);
            AddFriendButton.TabIndex = 7;
            AddFriendButton.Text = "Add Friend";
            AddFriendButton.UseVisualStyleBackColor = false;
            AddFriendButton.Click += AddFriendButton_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(PendingLabel);
            panel3.Controls.Add(AllLabel);
            panel3.Controls.Add(OnlineLabel);
            panel3.Location = new Point(11, 156);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(20, 5, 0, 0);
            panel3.Size = new Size(281, 42);
            panel3.TabIndex = 6;
            // 
            // PendingLabel
            // 
            PendingLabel.AutoSize = true;
            PendingLabel.BackColor = Color.FromArgb(60, 44, 98);
            PendingLabel.Dock = DockStyle.Left;
            PendingLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PendingLabel.ForeColor = SystemColors.ButtonHighlight;
            PendingLabel.Location = new Point(179, 5);
            PendingLabel.Name = "PendingLabel";
            PendingLabel.Size = new Size(87, 28);
            PendingLabel.TabIndex = 2;
            PendingLabel.Text = "Pending";
            // 
            // AllLabel
            // 
            AllLabel.AutoSize = true;
            AllLabel.BackColor = Color.FromArgb(60, 44, 98);
            AllLabel.Dock = DockStyle.Left;
            AllLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AllLabel.ForeColor = SystemColors.ButtonHighlight;
            AllLabel.Location = new Point(118, 5);
            AllLabel.Name = "AllLabel";
            AllLabel.Size = new Size(61, 28);
            AllLabel.TabIndex = 1;
            AllLabel.Text = "All   /";
            // 
            // OnlineLabel
            // 
            OnlineLabel.AutoSize = true;
            OnlineLabel.BackColor = Color.FromArgb(60, 44, 98);
            OnlineLabel.Dock = DockStyle.Left;
            OnlineLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            OnlineLabel.ForeColor = SystemColors.ButtonHighlight;
            OnlineLabel.Location = new Point(20, 5);
            OnlineLabel.Name = "OnlineLabel";
            OnlineLabel.Size = new Size(98, 28);
            OnlineLabel.TabIndex = 0;
            OnlineLabel.Text = "Online   /";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(4, 198, 202);
            panel2.Location = new Point(11, 204);
            panel2.Name = "panel2";
            panel2.Size = new Size(281, 2);
            panel2.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(4, 198, 202);
            panel1.Location = new Point(11, 148);
            panel1.Name = "panel1";
            panel1.Size = new Size(281, 2);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(73, 19);
            label1.Name = "label1";
            label1.Size = new Size(148, 50);
            label1.TabIndex = 3;
            label1.Text = "Friends";
            // 
            // GamesPanel
            // 
            GamesPanel.BackColor = Color.FromArgb(4, 198, 202);
            GamesPanel.Controls.Add(panel8);
            GamesPanel.Controls.Add(panel5);
            GamesPanel.Controls.Add(panel4);
            GamesPanel.Dock = DockStyle.Fill;
            GamesPanel.Location = new Point(300, 0);
            GamesPanel.Name = "GamesPanel";
            GamesPanel.Size = new Size(582, 628);
            GamesPanel.TabIndex = 2;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(60, 44, 98);
            panel8.Controls.Add(label4);
            panel8.Controls.Add(panel9);
            panel8.Controls.Add(panel10);
            panel8.Controls.Add(DeleteGameButton);
            panel8.Controls.Add(AddGameButton);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(10, 0);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(5);
            panel8.Size = new Size(562, 628);
            panel8.TabIndex = 3;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(206, 19);
            label4.Name = "label4";
            label4.Size = new Size(138, 50);
            label4.TabIndex = 12;
            label4.Text = "Games";
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(42, 31, 61);
            panel9.Location = new Point(8, 151);
            panel9.Name = "panel9";
            panel9.Size = new Size(546, 469);
            panel9.TabIndex = 11;
            panel9.Paint += panel9_Paint;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(4, 198, 202);
            panel10.Location = new Point(8, 148);
            panel10.Name = "panel10";
            panel10.Size = new Size(544, 2);
            panel10.TabIndex = 10;
            // 
            // DeleteGameButton
            // 
            DeleteGameButton.BackColor = Color.FromArgb(4, 198, 202);
            DeleteGameButton.FlatAppearance.BorderSize = 0;
            DeleteGameButton.FlatStyle = FlatStyle.Flat;
            DeleteGameButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteGameButton.ForeColor = SystemColors.ButtonHighlight;
            DeleteGameButton.Location = new Point(286, 95);
            DeleteGameButton.Name = "DeleteGameButton";
            DeleteGameButton.Size = new Size(266, 47);
            DeleteGameButton.TabIndex = 9;
            DeleteGameButton.Text = "Delete Game";
            DeleteGameButton.UseVisualStyleBackColor = false;
            // 
            // AddGameButton
            // 
            AddGameButton.BackColor = Color.FromArgb(4, 198, 202);
            AddGameButton.FlatAppearance.BorderSize = 0;
            AddGameButton.FlatStyle = FlatStyle.Flat;
            AddGameButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddGameButton.ForeColor = SystemColors.ButtonHighlight;
            AddGameButton.Location = new Point(8, 95);
            AddGameButton.Name = "AddGameButton";
            AddGameButton.Size = new Size(270, 47);
            AddGameButton.TabIndex = 8;
            AddGameButton.Text = "Add Game";
            AddGameButton.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(255, 128, 0);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(572, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(10, 628);
            panel5.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(255, 128, 0);
            panel4.Dock = DockStyle.Left;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(10, 628);
            panel4.TabIndex = 0;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // GameHub
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 44, 98);
            ClientSize = new Size(1182, 628);
            Controls.Add(GamesPanel);
            Controls.Add(FriendsPanel);
            Controls.Add(AccountPanel);
            Name = "GameHub";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GameHub";
            AccountPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)roundedPicture1).EndInit();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            FriendsPanel.ResumeLayout(false);
            FriendsPanel.PerformLayout();
            FriendListContainerPanel.ResumeLayout(false);
            FriendListContainerPanel.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            GamesPanel.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel AccountPanel;
        private Panel FriendsPanel;
        private Panel GamesPanel;
        private Panel panel5;
        private Panel panel4;
        private Button LogoutButton;
        private RoundedPicture roundedPicture1;
        private Label LevelLabel;
        private Label UsernameLabel;
        private Label label1;
        private Panel panel3;
        private Label OnlineLabel;
        private Panel panel2;
        private Panel panel1;
        private Label PendingLabel;
        private Label AllLabel;
        private Panel panel7;
        private ProgressBar LevelProgressBar;
        private Panel panel6;
        private Label LevelNumberLabel;
        private Button AddFriendButton;
        private Panel panel8;
        private Button DeleteGameButton;
        private Button AddGameButton;
        private Panel panel10;
        private Panel panel9;
        private FlowLayoutPanel FriendListPanel;
        private FileSystemWatcher fileSystemWatcher1;
        private Label label4;
        private Panel panel11;
        private Label ExpLabel;
        private Label label2;
        private Label label3;
        private Panel panel12;
        private Label label5;
        private Panel panel13;
        private Panel FriendListContainerPanel;
    }
}