using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace RedJ_Code
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            Environment.CurrentDirectory = Application.StartupPath;
            CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.Run(new MainForm(args));
        }

        static void Application_ThreadException(object? sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, StringTable.ThreadExceptionMessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

