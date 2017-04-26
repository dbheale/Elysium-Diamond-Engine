using System;
using System.Windows.Forms;

namespace GameServer {
    static class Program {
        public static frmMain MainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {        
            Application.EnableVisualStyles();

            MainForm = new frmMain();

            Application.Idle += new EventHandler(MainForm.OnApplicationIdle);

            MainForm.InitializeServer();

            Application.Run(MainForm);
        }
    }
}
