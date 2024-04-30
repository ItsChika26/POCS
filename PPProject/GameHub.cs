using LauncherApp.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherApp
{
    public partial class GameHub : Form
    {
        private User user;
        public GameHub(User usr)
        {
            InitializeComponent();
            UsernameLabel.Text = usr.Username;
            LevelNumberLabel.Text = usr.Level.ToString();
            user = usr;
            for (int i = 0; i < 12; i++)
                FriendListPanel.Controls.Add(new FriendListItem());
            InitControls();
            InitEvents();
        }

        private void InitEvents()
        {
            OnlineLabel.MouseEnter += FilterLabel_MouseEnter;
            OnlineLabel.MouseLeave += FilterLabel_MouseLeave;
            AllLabel.MouseEnter += FilterLabel_MouseEnter;
            AllLabel.MouseLeave += FilterLabel_MouseLeave;
            PendingLabel.MouseEnter += FilterLabel_MouseEnter;
            PendingLabel.MouseLeave += FilterLabel_MouseLeave;

        }

        private void InitControls()
        {
            //var scrollBar = new CustomvScrollBar();
            //scrollBar.Dock = DockStyle.Right;
            //FriendListContainerPanel.Controls.Add(scrollBar);

            //FriendListContainerPanel.Controls.SetChildIndex(scrollBar, 0);

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void roundedPicture1_Click(object sender, EventArgs e)
        {

        }

        private void FriendsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new LoginForm();
            form.ShowDialog();
            Client.Instance.Disconnect();
            this.Close();
        }

        private void LevelNumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void FilterLabel_MouseEnter(object sender, EventArgs e)
        {
            var label = (Label)sender;
            label.ForeColor = Color.FromArgb(255, 4, 198, 202);
        }

        private void FilterLabel_MouseLeave(object sender, EventArgs e)
        {
            var label = (Label)sender;
            label.ForeColor = Color.White;
        }
    }
}
