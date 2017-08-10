using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security;
using System.Threading;
using System.Runtime.InteropServices;
using Elysium.Logs;

namespace ConnectServer {
    public partial class frmMain : Form {

        #region Peek Message
        [SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

        [StructLayout(LayoutKind.Sequential)]
        public struct Message {
            public IntPtr hWnd;
            public IntPtr msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public Point p;
        }

        public void OnApplicationIdle(object sender, EventArgs e) {
            while (this.AppStillIdle) {
                Connect.Loop();

                if (Configuration.Sleep > 0) {
                    Thread.Sleep(Configuration.Sleep);
                }
            }
        }

        private bool AppStillIdle {
            get {
                Message msg;
                return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
            }
        }
        #endregion

        public frmMain() {
            InitializeComponent();

            Log.LogEvent += WriteLog;
        }

        public void WriteLog(object sender, LogEventArgs e) {
            general_textbox.SelectionStart = general_textbox.TextLength;
            general_textbox.SelectionLength = 0;

            general_textbox.SelectionColor = e.Color;
            general_textbox.AppendText($"{DateTime.Now}: {e.Text}{Environment.NewLine}");
            general_textbox.SelectionColor = e.Color;

            general_textbox.ScrollToCaret();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            //carrega as configurações
            Connect.Initialize();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            Text = "Connect Server @ " + Connect.UPS;
        }
    }
}