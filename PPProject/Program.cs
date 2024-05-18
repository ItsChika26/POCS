
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
            var LoginForm = new LoginForm();
            Application.Run(LoginForm);
            if (LoginForm.DialogResult == DialogResult.Cancel)
            {
                return;
            }
            Application.Run(new GameHub());
        }
    }
}