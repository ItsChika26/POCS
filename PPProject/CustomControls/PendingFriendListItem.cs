using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LauncherApp.CustomControls
{
    public partial class PendingFriendListItem : UserControl
    {

        private Color borderColor;

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public void SetDate(DateTime friendTime)
        {
            var time = DateTime.Now - friendTime;

            if (time.Days > 0)
            {
                TimeLabel.Text = time.Days + " d";
            }
            else if (time.Hours > 0)
            {
                TimeLabel.Text = time.Hours + " h";
            }
            else if (time.Minutes > 0)
            {
                TimeLabel.Text = time.Minutes + " m";
            }
            else
            {
                TimeLabel.Text = time.Seconds + " s";
            }

            TimeLabel.Text += " ago";
        }


        public PendingFriendListItem(Friend friend)
        {
            InitializeComponent();
            UsernameLabel.Text = friend.Username;
            LevelNumberLabel.Text = friend.Level.ToString();
            SetDate(friend.Date);
            InitEvents();
        }

        public void InitEvents()
        {
            MouseEnter += FriendListItem_MouseEnter;
            MouseLeave += FriendListItem_MouseLeave;
            foreach (Control control in Controls)
            {
                control.MouseEnter += FriendListItem_MouseEnter;
                control.MouseLeave += FriendListItem_MouseLeave;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen borderPen = new Pen(borderColor))
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle
                {
                    Location = ClientRectangle.Location
                ,
                    Size = new Size(ClientRectangle.Width - 1, ClientRectangle.Height - 1)
                });
            }
        }
        private void FriendListItem_MouseEnter(object sender, EventArgs e)
        {

            BorderColor = Color.Orange;
        }

        private void FriendListItem_MouseLeave(object sender, EventArgs e)
        {
            BorderColor = Color.FromArgb(60, 44, 98);
        }

        private void TimeLabel_Click(object sender, EventArgs e)
        {
        }

        private async void AcceptButton_Click(object sender, EventArgs e)
        {
            var request = new Request { Username = User.Instance.Username, FriendUsername = UsernameLabel.Text, Action = "AddFriend" };
            var message = JsonConvert.SerializeObject(request);
            _ = Client.Instance.SendMessageAsync(message);
            var response = JsonConvert.DeserializeObject<Request>((await Client.Instance.ReceiveMessageAsync())!);
            var form = (GameHub)ParentForm!;
        }

        private void IgnoreButton_Click(object sender, EventArgs e)
        {

        }
    }
}
