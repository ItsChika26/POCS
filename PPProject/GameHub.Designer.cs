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
            button1 = new Button();
            FriendsPanel = new Panel();
            GamesPanel = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            roundedPicture1 = new RoundedPicture();
            AccountPanel.SuspendLayout();
            GamesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)roundedPicture1).BeginInit();
            SuspendLayout();
            // 
            // AccountPanel
            // 
            AccountPanel.Controls.Add(roundedPicture1);
            AccountPanel.Controls.Add(button1);
            AccountPanel.Dock = DockStyle.Left;
            AccountPanel.Location = new Point(0, 0);
            AccountPanel.Name = "AccountPanel";
            AccountPanel.Size = new Size(300, 628);
            AccountPanel.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(4, 198, 202);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(78, 547);
            button1.Name = "button1";
            button1.Size = new Size(135, 52);
            button1.TabIndex = 0;
            button1.Text = "Log Out";
            button1.UseVisualStyleBackColor = false;
            // 
            // FriendsPanel
            // 
            FriendsPanel.Dock = DockStyle.Right;
            FriendsPanel.Location = new Point(882, 0);
            FriendsPanel.Name = "FriendsPanel";
            FriendsPanel.Size = new Size(300, 628);
            FriendsPanel.TabIndex = 1;
            // 
            // GamesPanel
            // 
            GamesPanel.BackColor = Color.FromArgb(4, 198, 202);
            GamesPanel.Controls.Add(panel5);
            GamesPanel.Controls.Add(panel4);
            GamesPanel.Dock = DockStyle.Fill;
            GamesPanel.Location = new Point(300, 0);
            GamesPanel.Name = "GamesPanel";
            GamesPanel.Size = new Size(582, 628);
            GamesPanel.TabIndex = 2;
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
            // roundedPicture1
            // 
            roundedPicture1.Location = new Point(78, 94);
            roundedPicture1.Name = "roundedPicture1";
            roundedPicture1.Size = new Size(125, 62);
            roundedPicture1.TabIndex = 1;
            roundedPicture1.TabStop = false;
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
            GamesPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)roundedPicture1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel AccountPanel;
        private Panel FriendsPanel;
        private Panel GamesPanel;
        private Panel panel5;
        private Panel panel4;
        private Button button1;
        private RoundedPicture roundedPicture1;
    }
}