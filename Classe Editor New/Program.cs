using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Classe_Editor {
    static class Program {
        public static MainForm MainForm { get; set; }
        public static FormClasses FormClasses { get; set; }
        public static FormIncrement FormIncrement { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm = new MainForm();
            FormClasses = new FormClasses();
            FormIncrement = new FormIncrement();

            Application.Run(MainForm);
        }
    }
}
