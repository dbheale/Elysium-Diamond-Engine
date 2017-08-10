using System;
using System.Windows.Forms;

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
            Application.SetCompatibleTextRenderingDefault(true);

            MainForm = new frmMain();
            MainForm.Show();

            MainForm.InitializeServer();

            Application.Idle += new EventHandler(MainForm.OnApplicationIdle);
            Application.Run(MainForm);
        }
    }
}