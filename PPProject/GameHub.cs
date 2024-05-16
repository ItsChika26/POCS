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
using Newtonsoft.Json;

namespace LauncherApp
{
    public partial class GameHub : Form
    {
        public User usr = User.Instance;
        public GameHub()
        {
            InitializeComponent();
            UsernameLabel.Text = usr.Username;
            LevelNumberLabel.Text = usr.Level.ToString();
            InitControls();
            LoadFriends();
        }

        private void LoadFriends()
        {
            FriendListPanel.Controls.Clear();
            foreach (var friend in User.Instance.friends)
            {
                var friendControl = new FriendListItem(friend);
                FriendListPanel.Controls.Add(friendControl);
            }
        }

        private void InitControls()
        {
            for (int i = 0; i < 10; i++)
            {
                var gameControl = new GameControl();

                GameListPanel.Controls.Add(gameControl);
            }


            //var scrollBar = new CustomvScrollBar();
            //scrollBar.Dock = DockStyle.Right;
            //FriendListContainerPanel.Controls.Add(scrollBar);

            //FriendListContainerPanel.Controls.SetChildIndex(scrollBar, 0);

        }

        private async void LogoutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var request = new Request() { Action = "Logout", Username = User.Instance.Username };
            var message = JsonConvert.SerializeObject(request);
            await Client.Instance.SendMessageAsync(message);
            Client.Instance.Disconnect();
            this.Close();
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

        private void AddFriendButton_Click(object sender, EventArgs e)
        {
            var addFriendControl = new AddFriendControl(this);
            FriendListPanel.Controls.Add(addFriendControl);
        }
    }
}
