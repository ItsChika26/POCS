using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LauncherApp
{
    public partial class RoundedPicture : PictureBox
    {
        public RoundedPicture()
        {
            InitializeComponent();
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            GraphicsPath grpath = new GraphicsPath();
            grpath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(grpath);
            base.OnPaint(pe);
        }
    }
}
