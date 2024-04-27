
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
            var client = Client.Instance;
            await client.Connect("20.215.40.53",8080);
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}