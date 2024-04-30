
namespace LauncherApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }
    }
}