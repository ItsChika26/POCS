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
    public partial class GameControl : UserControl
    {
        public GameControl()
        {
            InitializeComponent();
            InitEvents();
        
        }

        public void InitEvents()
        {
            MouseEnter += GameControl_MouseEnter;
            MouseLeave += GameControl_MouseLeave;
            foreach (Control control in Controls)
            {
                control.MouseEnter += GameControl_MouseEnter;
                control.MouseLeave += GameControl_MouseLeave;
            }
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen borderPen = new Pen(borderColor))
            {
                e.Graphics.DrawRectangle(borderPen, new Rectangle
                { Location=ClientRectangle.Location
                , Size = new Size(ClientRectangle.Width - 1, ClientRectangle.Height - 1)
                });
            }
        }

        private void GameControl_MouseLeave(object sender, EventArgs e)
        {
            BorderColor = Color.FromArgb(60, 44, 98);
        }

        private void GameControl_MouseEnter(object sender, EventArgs e)
        {
            BorderColor = Color.Orange;
        }
    }
}
