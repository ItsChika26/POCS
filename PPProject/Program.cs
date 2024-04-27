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
<<<<<<< HEAD
            
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
=======
            Database.Connect();
            Debug.WriteLine(Database.RegisterUser("test", "test"));
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
>>>>>>> c7e20ee5d8e6e2060373a47f0fe46f8bb3aa05e5
        }
    }
}