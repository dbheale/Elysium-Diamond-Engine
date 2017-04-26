using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LoginServer.Common;

namespace LoginServer {
    static class Program {
        /// <summary>
        /// Formulário principal.
        /// </summary>
        public static frmMain MainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();

            MainForm = new frmMain();

            MainForm.InitializeServer();

            Application.Idle += new EventHandler(MainForm.OnApplicationIdle);
            Application.Run(MainForm);
        }
    }
}
