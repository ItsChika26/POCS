namespace LauncherApp.CustomControls
{
    partial class GameControl
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
            GameIcon = new PictureBox();
            HoursPlayedLabel = new Label();
            LevelLabel = new Label();
            GameNameLabel = new Label();
            richTextBox1 = new RichTextBox();
            panel13 = new Panel();
            ((System.ComponentModel.ISupportInitialize)GameIcon).BeginInit();
            SuspendLayout();
            // 
            // GameIcon
            // 
            GameIcon.Image = Properties.Resources.c0589be1b84c602dae8e97419541708d;
            GameIcon.Location = new Point(8, 8);
            GameIcon.Name = "GameIcon";
            GameIcon.Size = new Size(99, 99);
            GameIcon.SizeMode = PictureBoxSizeMode.Zoom;
            GameIcon.TabIndex = 0;
            GameIcon.TabStop = false;
            // 
            // HoursPlayedLabel
            // 
            HoursPlayedLabel.AutoSize = true;
            HoursPlayedLabel.BackColor = Color.FromArgb(60, 44, 98);
            HoursPlayedLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            HoursPlayedLabel.ForeColor = Color.FromArgb(255, 128, 0);
            HoursPlayedLabel.Location = new Point(416, 126);
            HoursPlayedLabel.Name = "HoursPlayedLabel";
            HoursPlayedLabel.Size = new Size(26, 20);
            HoursPlayedLabel.TabIndex = 8;
            HoursPlayedLabel.Text = "0h";
            // 
            // LevelLabel
            // 
            LevelLabel.AutoSize = true;
            LevelLabel.BackColor = Color.FromArgb(60, 44, 98);
            LevelLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            LevelLabel.ForeColor = SystemColors.ActiveBorder;
            LevelLabel.Location = new Point(327, 126);
            LevelLabel.Name = "LevelLabel";
            LevelLabel.Size = new Size(92, 20);
            LevelLabel.TabIndex = 7;
            LevelLabel.Text = "Time played";
            // 
            // GameNameLabel
            // 
            GameNameLabel.BackColor = Color.FromArgb(60, 44, 98);
            GameNameLabel.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            GameNameLabel.ForeColor = SystemColors.ButtonHighlight;
            GameNameLabel.Location = new Point(8, 103);
            GameNameLabel.Name = "GameNameLabel";
            GameNameLabel.Size = new Size(313, 41);
            GameNameLabel.TabIndex = 6;
            GameNameLabel.Text = "Game_Name";
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(42, 31, 61);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.ForeColor = SystemColors.ActiveBorder;
            richTextBox1.Location = new Point(113, 8);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.ScrollBars = RichTextBoxScrollBars.None;
            richTextBox1.Size = new Size(334, 99);
            richTextBox1.TabIndex = 9;
            richTextBox1.Text = "Description\n";
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(4, 198, 202);
            panel13.Location = new Point(8, 147);
            panel13.Name = "panel13";
            panel13.Size = new Size(438, 2);
            panel13.TabIndex = 10;
            // 
            // GameControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 44, 98);
            Controls.Add(GameIcon);
            Controls.Add(panel13);
            Controls.Add(richTextBox1);
            Controls.Add(HoursPlayedLabel);
            Controls.Add(LevelLabel);
            Controls.Add(GameNameLabel);
            DoubleBuffered = true;
            ForeColor = Color.White;
            Margin = new Padding(5);
            Name = "GameControl";
            Padding = new Padding(5);
            Size = new Size(455, 157);
            MouseDoubleClick += GameControl_MouseDoubleClick;
            MouseEnter += GameControl_MouseEnter;
            MouseLeave += GameControl_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)GameIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox GameIcon;
        private Label HoursPlayedLabel;
        private Label LevelLabel;
        private Label GameNameLabel;
        private RichTextBox richTextBox1;
        private Panel panel13;
    }
}
