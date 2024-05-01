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
        public FriendListItem(Friend friend)
        {
            InitializeComponent();
            UsernameLabel.Text = friend.Username;
            LevelNumberLabel.Text = friend.Level.ToString();
        }
    }
}
