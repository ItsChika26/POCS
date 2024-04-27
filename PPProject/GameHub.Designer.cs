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
            panel7 = new Panel();
            LevelNumberLabel = new Label();
            LevelProgressBar = new ProgressBar();
            LevelLabel = new Label();
            panel6 = new Panel();
            UsernameLabel = new Label();
            roundedPicture1 = new RoundedPicture();
            LogoutButton = new Button();
            FriendsPanel = new Panel();
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
            panel9 = new Panel();
            panel10 = new Panel();
            DeleteGameButton = new Button();
            AddGameButton = new Button();
            label2 = new Label();
            panel5 = new Panel();
            panel4 = new Panel();
            AccountPanel.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)roundedPicture1).BeginInit();
            FriendsPanel.SuspendLayout();
            panel3.SuspendLayout();
            GamesPanel.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // AccountPanel
            // 
            AccountPanel.Controls.Add(panel7);
            AccountPanel.Controls.Add(panel6);
            AccountPanel.Controls.Add(UsernameLabel);
            AccountPanel.Controls.Add(roundedPicture1);
            AccountPanel.Controls.Add(LogoutButton);
            AccountPanel.Dock = DockStyle.Left;
            AccountPanel.Location = new Point(0, 0);
            AccountPanel.Name = "AccountPanel";
            AccountPanel.Padding = new Padding(10, 0, 10, 10);
            AccountPanel.Size = new Size(300, 628);
            AccountPanel.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Controls.Add(LevelNumberLabel);
            panel7.Controls.Add(LevelProgressBar);
            panel7.Controls.Add(LevelLabel);
            panel7.Location = new Point(37, 200);
            panel7.Name = "panel7";
            panel7.Padding = new Padding(10, 0, 10, 10);
            panel7.Size = new Size(226, 72);
            panel7.TabIndex = 7;
            // 
            // LevelNumberLabel
            // 
            LevelNumberLabel.AutoSize = true;
            LevelNumberLabel.BackColor = Color.FromArgb(60, 44, 98);
            LevelNumberLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            LevelNumberLabel.ForeColor = Color.FromArgb(255, 128, 0);
            LevelNumberLabel.Location = new Point(89, 2);
            LevelNumberLabel.Name = "LevelNumberLabel";
            LevelNumberLabel.Size = new Size(32, 37);
            LevelNumberLabel.TabIndex = 5;
            LevelNumberLabel.Text = "0";
            // 
            // LevelProgressBar
            // 
            LevelProgressBar.BackColor = Color.FromArgb(60, 44, 98);
            LevelProgressBar.Dock = DockStyle.Bottom;
            LevelProgressBar.ForeColor = SystemColors.ActiveCaptionText;
            LevelProgressBar.Location = new Point(10, 42);
            LevelProgressBar.Name = "LevelProgressBar";
            LevelProgressBar.Size = new Size(206, 20);
            LevelProgressBar.Style = ProgressBarStyle.Marquee;
            LevelProgressBar.TabIndex = 4;
            LevelProgressBar.Value = 50;
            // 
            // LevelLabel
            // 
            LevelLabel.AutoSize = true;
            LevelLabel.Font = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            LevelLabel.ForeColor = SystemColors.ButtonHighlight;
            LevelLabel.Location = new Point(0, 2);
            LevelLabel.Name = "LevelLabel";
            LevelLabel.Padding = new Padding(4, 0, 0, 0);
            LevelLabel.Size = new Size(83, 37);
            LevelLabel.TabIndex = 3;
            LevelLabel.Text = "Level";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(4, 198, 202);
            panel6.Location = new Point(12, 278);
            panel6.Name = "panel6";
            panel6.Size = new Size(281, 2);
            panel6.TabIndex = 6;
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            UsernameLabel.ForeColor = SystemColors.ButtonHighlight;
            UsernameLabel.Location = new Point(78, 161);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(156, 41);
            UsernameLabel.TabIndex = 2;
            UsernameLabel.Text = "Username";
            // 
            // roundedPicture1
            // 
            roundedPicture1.Image = Properties.Resources.c0589be1b84c602dae8e97419541708d;
            roundedPicture1.Location = new Point(78, 19);
            roundedPicture1.Name = "roundedPicture1";
            roundedPicture1.Size = new Size(135, 131);
            roundedPicture1.TabIndex = 1;
            roundedPicture1.TabStop = false;
            roundedPicture1.Click += roundedPicture1_Click;
            // 
            // LogoutButton
            // 
            LogoutButton.BackColor = Color.FromArgb(4, 198, 202);
            LogoutButton.Dock = DockStyle.Bottom;
            LogoutButton.FlatAppearance.BorderSize = 0;
            LogoutButton.FlatStyle = FlatStyle.Flat;
            LogoutButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LogoutButton.ForeColor = SystemColors.ButtonHighlight;
            LogoutButton.Location = new Point(10, 566);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(280, 52);
            LogoutButton.TabIndex = 0;
            LogoutButton.Text = "Log Out";
            LogoutButton.UseVisualStyleBackColor = false;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // FriendsPanel
            // 
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
            panel2.Size = new Size(284, 2);
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
            panel8.Controls.Add(panel9);
            panel8.Controls.Add(panel10);
            panel8.Controls.Add(DeleteGameButton);
            panel8.Controls.Add(AddGameButton);
            panel8.Controls.Add(label2);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(10, 0);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(5);
            panel8.Size = new Size(562, 628);
            panel8.TabIndex = 3;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(194, 13);
            label2.Name = "label2";
            label2.Size = new Size(157, 57);
            label2.TabIndex = 2;
            label2.Text = "Games";
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
            Text = "GameHub";
            AccountPanel.ResumeLayout(false);
            AccountPanel.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)roundedPicture1).EndInit();
            FriendsPanel.ResumeLayout(false);
            FriendsPanel.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            GamesPanel.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
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
        private Label label2;
        private Button DeleteGameButton;
        private Button AddGameButton;
        private Panel panel10;
        private Panel panel9;
    }
}