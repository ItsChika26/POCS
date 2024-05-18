
namespace LauncherApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            ApplicationConfiguration.Initialize();
            while(true)
            {
                if(new LoginForm().ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new GameHub());
                }
                else
                {
                    break;
                }
            }
        }
    }
}