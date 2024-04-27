using System.Diagnostics;

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
            Database.Connect();
            //Debug.WriteLine(Database.RegisterUser("test", "test"));
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}