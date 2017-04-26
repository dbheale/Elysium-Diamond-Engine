using System;
using System.Security;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using LoginServer.Network;
using LoginServer.Common;
using LoginServer.Server;
using LoginServer.MySQL;
using Elysium;

namespace LoginServer {        
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

                Login.Loop();

                if (Configuration.Sleep > 0) { Thread.Sleep(Configuration.Sleep); }
            }
        }

        private bool AppStillIdle {
            get {
                Message msg;
                return !PeekMessage(out msg, IntPtr.Zero, 0, 0, 0);
            }
        }

        #endregion

        NotifyIcon trayIcon;
        ContextMenu trayMenu;
        
        public frmMain() {
            InitializeComponent();

            Logs.LogsEvent += WriteLog;
        }

        private void ShowForm(object sender, EventArgs e) {
            trayIcon.Visible = false;
            Visible = true;
            ShowInTaskbar = true;  
        }

        /// <summary>
        /// Limpa todo o registro de log na tela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trm_cleartext_Tick(object sender, EventArgs e) {
            general_textbox.Clear();
        }

        /// <summary>
        /// Atualiza o cps na barra de título.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trm_showfps_Tick(object sender, EventArgs e) {
            Text = $"Login Server @ {Login.CPS}";
        }

        /// <summary>
        /// Adiciona as informações de logs na tela.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public void WriteLog(object sender, LogsEventArgs e) {
            general_textbox.SelectionStart = general_textbox.TextLength;
            general_textbox.SelectionLength = 0;

            general_textbox.SelectionColor = e.Color;
            general_textbox.AppendText($"{DateTime.Now}: {e.Text}{Environment.NewLine}");
            general_textbox.SelectionColor = e.Color;

            general_textbox.ScrollToCaret();
        }

        #region Menu Item
        //File -> Minimize
        private void min_MenuItem_Click(object sender, EventArgs e) {
            trayIcon.Visible = true;
            Visible = false;
            ShowInTaskbar = false;
        }

        //File -> Quit
        private void quit_MenuItem_Click(object sender, EventArgs e) {
            trayIcon.Visible = false;
            trayIcon.Dispose();
 
            Login.Close();
        }

        //Config -> Clear
        private void clear_MenuItem_Click(object sender, EventArgs e) {
            general_textbox.Clear();
        }
        
        //Config -> Reload Server List
        private void reload_MenuItem_Click(object sender, EventArgs e) {
            InitializeServerConfig();
        }

        /// <summary>
        /// Ativa o timer para limpar o registro na tela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearsec_MenuItem_Click(object sender, EventArgs e) {
            if (clearsec_MenuItem.Checked) {
                clearsec_MenuItem.Checked = false;
                trm_cleartext.Stop();
            }
            else {
                clearsec_MenuItem.Checked = true;
                trm_cleartext.Start();
            }
        }

        private void reloadVersion_MenuItem_Click(object sender, EventArgs e) {
            Settings.ParseConfigFile("LogConfig.txt");
            Configuration.Version = Settings.GetString("CheckVersion");
            WriteLog(null, new LogsEventArgs($"Version: {Configuration.Version}", Color.Black));
        }

        private void disableLogin_MenuItem_Click(object sender, EventArgs e) {
            if (disableLogin_MenuItem.Checked)
                Configuration.DisableLogin = true;
            else
                Configuration.DisableLogin = false;                    
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;

            Login.Close();

            trayIcon.Visible = false;
            trayIcon.Dispose();

            e.Cancel = false;
        }
        #endregion

        /// <summary>
        /// Carrega todas as informações de configuração.
        /// </summary>
        public void InitializeServer() {
            trayIcon = new NotifyIcon();
            trayMenu = new ContextMenu();

            LuaScript.LuaScript.InitializeConfig();

            Settings.ParseConfigFile("LoginConfig.txt");

            Logs.Enabled = Settings.GetBoolean("Logs");

            var result = string.Empty;
            if (Logs.Enabled) {
                if (!Logs.OpenFile(out result)) MessageBox.Show(result);
            }

            Configuration.ID = Settings.GetInt32("ID");
            Logs.Write($"ID: {Configuration.ID}", Color.Red);

            Configuration.Discovery = Settings.GetString("Discovery");
            Logs.Write($"Discovery: {Configuration.Discovery}", Color.Black);

            Configuration.LoginServerPort = Settings.GetInt32("Port");
            Logs.Write($"Port: {Configuration.LoginServerPort}", Color.Black);

            Configuration.MaximumConnections = Settings.GetInt32("MaximumConnections");
            Logs.Write($"Maximum Connection: {Configuration.MaximumConnections}", Color.Black);

            Configuration.Sleep = Settings.GetInt32("Sleep");
            Logs.Write($"Sleep: {Configuration.Sleep}", Color.Black);

            Configuration.Version = Settings.GetString("CheckVersion");
            Logs.Write($"Version: {Configuration.Version}", Color.BlueViolet);

            result = (Logs.Enabled == true) ? "Logs: Ativado" : "Logs: Desativado";
            WriteLog(null, new LogsEventArgs(result, Color.Black));

            GeoIp.Enabled = Settings.GetBoolean("GeoIp");
            result = (GeoIp.Enabled == true) ? "Ativado" : "Desativado";
            Logs.Write($"GeoIp: {result}", Color.BlueViolet);

            CheckSum.Enabled = Settings.GetBoolean("CheckSum");
            result = (CheckSum.Enabled == true) ? "Ativado" : "Desativado";
            Logs.Write($"CheckSum: {result}", Color.BlueViolet);

            if (GeoIp.Enabled) {
                Logs.Write("Carregando dados ip de países.", Color.Green);
                GeoIp.ReadFile();
            }

            InitializeServerConfig();
            InitializeDatabaseConfig();

            Logs.Write("Connectado ao banco de dados", Color.Green);

            if (!Common_DB.Open(out result))
                WriteLog(null, new LogsEventArgs(result, Color.Black));

            Logs.Write("Conectando World Server.", Color.Green);

            WorldNetwork.InitializeWorldServer();

            Logs.Write("Login Server Start.", Color.Green);

            LoginNetwork.InitializeServer();

            #region Tray System
            trayMenu.MenuItems.Add("Mostrar", ShowForm);
            trayMenu.MenuItems.Add("Sair", quit_MenuItem_Click);

            trayIcon.Text = "Connect Server @";
            trayIcon.Icon = this.Icon;

            trayIcon.ContextMenu = trayMenu;
            #endregion
        }

        /// <summary>
        /// Carrega as configurações de servidores
        /// </summary>
        public void InitializeServerConfig() {
            var enabled = 0;

            for (var i = 0; i < Constant.MAX_SERVER; i++) {
                enabled = Settings.GetInt32((i + 1) + "_Enabled");
                Configuration.Server[i] = new ServerData();

                if (enabled == 0) {
                    Configuration.Server[i].Name = string.Empty;
                    Configuration.Server[i].WorldServerIP = string.Empty;
                    Configuration.Server[i].WorldServerLocalIP = string.Empty;
                    Configuration.Server[i].Region = string.Empty;
                    Configuration.Server[i].Status = string.Empty;
                }
                else {
                    Configuration.Server[i].Name = Settings.GetString((i + 1) + "_Name");
                    Configuration.Server[i].Region = Settings.GetString((i + 1) + "_Region");
                    Configuration.Server[i].WorldServerIP = Settings.GetString((i + 1) + "_WorldServerIP");
                    Configuration.Server[i].WorldServerLocalIP = Settings.GetString((i + 1) + "_WorldServerLocalIP");
                    Configuration.Server[i].WorldServerPort = Settings.GetInt32((i + 1) + "_WorldServerPort");
                    Configuration.Server[i].Status = Settings.GetString((i + 1) + "_Status");

                    Logs.Write($"Servidor adicionado: {Configuration.Server[i].Name} {Configuration.Server[i].Region} {Configuration.Server[i].Status}", Color.Coral);
                }
            }
        }

        /// <summary>
        /// Obtém todas as configurações de arquivo.
        /// </summary>
        public void InitializeDatabaseConfig() {
            Common_DB.Server = Settings.GetString("MySQL_IP");
            Common_DB.Port = Settings.GetInt32("MySQL_Port");
            Common_DB.Username = Settings.GetString("MySQL_User");
            Common_DB.Password = Settings.GetString("MySQL_Pass");
            Common_DB.Database = Settings.GetString("MySQL_DB");
        }
    }
}
