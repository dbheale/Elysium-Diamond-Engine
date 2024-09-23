using System;
using System.Windows.Forms;
using Elysium_Diamond.DirectX;
using Elysium_Diamond.Common;

namespace Elysium_Diamond {
    static class Program {
        public static CreateDevice GraphicsDisplay;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {
            if (!Configuration.Open()) {
                MessageBox.Show("Configuration file not found. The program will be closed.");
                return;
            }

            Application.EnableVisualStyles();

            GraphicsDisplay = new CreateDevice();

            if (!EngineCore.InitializeDirectX()) {
                MessageBox.Show("Could not initialize Direct3D. The program will be closed.");
                return;
            }

            if (!EngineCore.InitializeEngine()) {
                MessageBox.Show("Could not initialize the resources. The program will be closed.");
                return;
            }

            GraphicsDisplay.Show();

            Application.Idle += new EventHandler(GraphicsDisplay.OnApplicationIdle);
            Application.Run(GraphicsDisplay);
        }
    }
}
