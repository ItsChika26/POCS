namespace LauncherApp.CustomControls
{
    partial class CustomFLP: FlowLayoutPanel
    {
        public CustomFLP(): base()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint,true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer,true);
            this.UpdateStyles();
        }
        
    }
}
