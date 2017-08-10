using System;
using System.Windows.Forms;

namespace ConnectServer {
    static class Program {
        public static frmMain MainForm { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm = new frmMain();

            Application.Idle += new EventHandler(MainForm.OnApplicationIdle);
            Application.Run(MainForm);
        }
    }
}