using System;
using System.Windows.Forms;

namespace WorldServer {
    static class Program {
        public static frmMain MainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();

            MainForm = new frmMain();
            MainForm.Show();

            MainForm.InitializeServer();

            Application.Idle += new EventHandler(MainForm.OnApplicationIdle);
            Application.Run(MainForm);
        }
    }
}
