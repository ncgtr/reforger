namespace Reforger
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetColorMode(SystemColorMode.Dark);
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}