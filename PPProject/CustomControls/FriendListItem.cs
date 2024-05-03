using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherApp.CustomControls
{
    public partial class FriendListItem : UserControl
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
        public FriendListItem(Friend friend)
        {
            InitializeComponent();
            UsernameLabel.Text = friend.Username;
            LevelNumberLabel.Text = friend.Level.ToString();
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
    }
}
