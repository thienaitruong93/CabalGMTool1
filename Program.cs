namespace CabalGM1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
            AppDomain.CurrentDomain.UnhandledException += delegate (object s, UnhandledExceptionEventArgs e)
            {
                if (e.ExceptionObject is Exception ex)
                {
                    string text = string.Concat("Exception:\n", ex, "\n\n");
                    string text2 = "Inner Exception:\n" + ex.InnerException;
                    MessageBox.Show(text + text2, "Error");
                }
            };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(defaultValue: false);
            Application.Run(new FormMain());
        }
    }
}