using System;
using System.Security;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using MySql.Data.MySqlClient;
using LoginServer.Network;
using LoginServer.Common;
using LoginServer.Server;
using LoginServer.Database;
using Elysium.Logs;
using Elysium.IO;

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

            Log.LogEvent += WriteLog;
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
            Text = $"Login Server @ {Login.UPS}";
        }

        /// <summary>
        /// Adiciona as informações de logs na tela.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public void WriteLog(object sender, LogEventArgs e) {
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
            Settings.ParseConfigFile("LoginConfig.txt");
            Configuration.Version = Settings.GetString("CheckVersion");
            WriteLog(null, new LogEventArgs($"Version: {Configuration.Version}", Color.Black));
        }

        private void disableLogin_MenuItem_Click(object sender, EventArgs e) {
            if (disableLogin_MenuItem.Checked)
                Configuration.IsLoginDisabled = true;
            else
                Configuration.IsLoginDisabled = false;                    
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

            LuaScript.LuaScript.InitializeScript();

            Settings.ParseConfigFile("LoginConfig.txt");

            Log.Enabled = Settings.GetBoolean("Log");

            var result = string.Empty;

            if (Log.Enabled) {
                if (!Log.OpenFile(out result)) MessageBox.Show(result);
            }

            Configuration.ID = Settings.GetInt32("ID");
            Log.Write($"ID: {Configuration.ID}", Color.Red);

            Configuration.Discovery = Settings.GetString("Discovery");
            Log.Write($"Discovery: {Configuration.Discovery}", Color.Black);

            Configuration.Port = Settings.GetInt32("Port");
            Log.Write($"Port: {Configuration.Port}", Color.Black);

            Configuration.MaxConnections = Settings.GetInt32("MaximumConnections");
            Log.Write($"Maximum Connection: {Configuration.MaxConnections}", Color.Black);

            Configuration.Sleep = Settings.GetInt32("Sleep");
            Log.Write($"Sleep: {Configuration.Sleep}", Color.Black);

            Configuration.Version = Settings.GetString("CheckVersion");
            Log.Write($"Version: {Configuration.Version}", Color.BlueViolet);

            result = (Log.Enabled == true) ? "Log: Enabled" : "Log: Disabled";
            WriteLog(null, new LogEventArgs(result, Color.Black));

            GeoIp.Enabled = Settings.GetBoolean("GeoIp");
            result = (GeoIp.Enabled == true) ? "Enabled" : "Disabled";
            Log.Write($"GeoIp: {result}", Color.BlueViolet);

            CheckSum.Enabled = Settings.GetBoolean("CheckSum");
            result = (CheckSum.Enabled == true) ? "Enabled" : "Disabled";
            Log.Write($"CheckSum: {result}", Color.BlueViolet);

            Configuration.PinCheckTime = Settings.GetInt32("PinCheckTime");
            Log.Write($"PinCheckTime: {Configuration.PinCheckTime}", Color.BlueViolet);

            Configuration.ConnectIp = Settings.GetString("ConnectIp");
            Log.Write($"Connect Ip: {Configuration.ConnectIp}", Color.Black);

            Configuration.ConnectPort = Settings.GetInt32("ConnectPort");
            Log.Write($"Connect Port: {Configuration.ConnectPort}", Color.Black);

            if (GeoIp.Enabled) {
                Log.Write("Loading country data", Color.Green);
                GeoIp.ReadFile();
            }

            InitializeServerConfig();
            InitializeDatabaseConfig();

            NetworkClient.Initialize();

            Log.Write("Login Server Start", Color.Green);

            LoginNetwork.Initialize();

            #region Tray System
            trayMenu.MenuItems.Add("Show", ShowForm);
            trayMenu.MenuItems.Add("Quit", quit_MenuItem_Click);

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

            for (var i = 0; i < Constants.MaxServer; i++) {
                enabled = Settings.GetInt32((i + 1) + "_Enabled");
                Configuration.Server[i] = new ServerData();
                Configuration.Server[i].Enabled = Convert.ToBoolean(enabled);

                if (!Configuration.Server[i].Enabled) {
                    Configuration.Server[i].Name = string.Empty;
                    Configuration.Server[i].WorldServerIP = string.Empty;
                    Configuration.Server[i].WorldServerLocalIP = string.Empty;
                    Configuration.Server[i].WorldServerPort = 0;
                    Configuration.Server[i].Region = string.Empty;
                    Configuration.Server[i].Status = string.Empty;
                }
                else {
                    Configuration.Server[i].ID = Settings.GetInt32((i + 1) + "_ID");
                    Configuration.Server[i].Name = Settings.GetString((i + 1) + "_Name");
                    Configuration.Server[i].Region = Settings.GetString((i + 1) + "_Region");
                    Configuration.Server[i].WorldServerIP = Settings.GetString((i + 1) + "_WorldServerIP");
                    Configuration.Server[i].WorldServerLocalIP = Settings.GetString((i + 1) + "_WorldServerLocalIP");
                    Configuration.Server[i].WorldServerPort = Settings.GetInt32((i + 1) + "_WorldServerPort");
                    Configuration.Server[i].Status = Settings.GetString((i + 1) + "_Status");

                    Log.Write($"Added server: {Configuration.Server[i].Name} {Configuration.Server[i].Region} {Configuration.Server[i].Status}", Color.Coral);
                }
            }
        }

        /// <summary>
        /// Obtém todas as configurações de arquivo.
        /// </summary>
        public void InitializeDatabaseConfig() {
            MySQL.Server = Settings.GetString("MySQL_IP");
            MySQL.Port = Settings.GetInt32("MySQL_Port");
            MySQL.Username = Settings.GetString("MySQL_User");
            MySQL.Password = Settings.GetString("MySQL_Pass");
            MySQL.Database = Settings.GetString("MySQL_DB");

            Log.Write("Trying to connect database", Color.Green);

            MySqlConnection connection = null;

            try {
                connection = new MySQL().CreateConnection();
            }
            catch (MySqlException ex) {
                Log.Write(ex.Message, Color.Red);
            }

            if (connection.State == System.Data.ConnectionState.Open) {
                Log.Write("Database is connected successfully", Color.Green);
            }

            connection?.Close();
        }
    }
}