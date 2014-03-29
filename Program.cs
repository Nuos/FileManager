using System;
using System.Windows.Forms;

namespace FileManager
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //Operation.Subscribe();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            var app = new Controller();
        }
    }
}