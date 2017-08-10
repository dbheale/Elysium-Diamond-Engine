using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using WorldServer.WorldChat;
using WorldServer.Common;
using WorldServer.Network;
using WorldServer.Database;
using WorldServer.Server;
using WorldServer.GameGuild;
using WorldServer.LuaScript;
using WorldServer.BlackMarket;
using Elysium.IO;
using Elysium.Logs;

namespace WorldServer {        
    public partial class frmMain : Form {
        #region Peek Message
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

        /// <summary>Windows Message</summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Message
        {
            public IntPtr hWnd;
            public IntPtr msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }
        public void OnApplicationIdle(object sender, EventArgs e)
        {
            while (this.AppStillIdle)
            {
                World.Loop();

                if (Configuration.Sleep > 0) { Thread.Sleep(Configuration.Sleep); }
            }
        }
        private bool AppStillIdle
        {
            get
            {
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

        private void quit_MenuItem_Click(object sender, EventArgs e) {
            Log.CloseFile();
            Application.Exit();
        }

        private void ShowForm(object sender, EventArgs e) {
            trayIcon.Visible = false;
            Visible = true;
            ShowInTaskbar = true;  
        }
  
        /// <summary>
        /// Carrega todas as informações de configuração.
        /// </summary>
        public void InitializeServer() {
            trayIcon = new NotifyIcon();
            trayMenu = new ContextMenu();

            Settings.ParseConfigFile("WorldConfig.txt");

            Log.Enabled = Settings.GetBoolean("Logs");

            var result = string.Empty;
            if (Log.Enabled) {
                if (!Log.OpenFile(out result)) MessageBox.Show(result);
            }

            Configuration.ID = Settings.GetInt32("WorldID");
            Log.Write($"WorldID: {Configuration.ID}", Color.Red);

            Configuration.WorldServerName = Settings.GetString("WorldServerName");
            Log.Write($"Server Name: {Configuration.WorldServerName}", Color.Black);

            Configuration.Discovery = Settings.GetString("Discovery");
            Log.Write($"Discovery: {Configuration.Discovery}", Color.Black);

            Text = $"World Server @ {Configuration.WorldServerName}";

            Configuration.WorldServerPort = Settings.GetInt32("Port");
            Log.Write($"Port: {Configuration.WorldServerPort}", Color.Black);

            Configuration.MaxConnections = Settings.GetInt32("MaximumConnections");
            Log.Write($"Maximum Connections: {Configuration.MaxConnections}", Color.Black);

            result = (Log.Enabled == true) ? "Logs: Enabled" : "Logs: Disabled";
            Log.Write(result, Color.Black);

            Configuration.Sleep = Settings.GetInt32("Sleep");
            Log.Write($"Sleep: {Configuration.Sleep}", Color.Black);

            Configuration.Pin = Settings.GetBoolean("Pin");
            Log.Write($"Pin: {Configuration.Pin}", Color.BlueViolet);

            Configuration.PinMaxAttempt = Settings.GetByte("PinMaxAttempt");
            Log.Write($"PinMaxAttempt: {Configuration.PinMaxAttempt}", Color.BlueViolet);

            Configuration.PinBannedTime = Settings.GetInt16("PinBannedTime");
            Log.Write($"PinBannedTime: {Configuration.PinBannedTime}", Color.BlueViolet);

            Configuration.ConnectIp = Settings.GetString("ConnectIp");
            Log.Write($"Connect Ip: {Configuration.ConnectIp}", Color.Black);

            Configuration.ConnectPort = Settings.GetInt32("ConnectPort");
            Log.Write($"Connect Port: {Configuration.ConnectPort}", Color.Black);

            InitializeDatabaseConfig();

            InitializeGuild();
            InitializeClasse();

            Log.Write("Loading server messages", Color.Black);
            InitializeServerMessage();

            Log.Write("Loading black market items", Color.Black);
            CashShop.Initialize();

            Log.Write("Loading scripts", Color.Black);
            LuaConfig.InitializeConfig();

            var text = (Configuration.CharacterCreation) ? "Enabled" : "Disabled";
            Log.Write($"Create Character: {text}", Color.MediumVioletRed);
            text = (Configuration.CharacterCreation) ? "Enabled" : "Disabled";
            Log.Write($"Delete Character: {text}", Color.MediumVioletRed);

            WorldNetwork.InitializeServer();
            NetworkClient.Initialize();

            Log.Write("World Server Start", Color.Green);

            #region System Tray
            trayMenu.MenuItems.Add("Show", ShowForm);
            trayMenu.MenuItems.Add("Exit", quit_MenuItem_Click);

            trayIcon.Text = "World Server @";
            trayIcon.Icon = this.Icon;

            trayIcon.ContextMenu = trayMenu;
            #endregion
        }

        public void WriteLog(object sender, LogEventArgs e) {
            general_textbox.SelectionStart = general_textbox.TextLength;
            general_textbox.SelectionLength = 0;

            general_textbox.SelectionColor = e.Color;
            general_textbox.AppendText($"{DateTime.Now}: {e.Text}\n");
            general_textbox.SelectionColor = e.Color;

            general_textbox.ScrollToCaret();
        }

        private void InitializeGuild() {
            Guild.Guilds = null;

            // Prepara as classes para receber dados
            Guild.Guilds = new HashSet<Guild>();

            // Carrega todos os dados de guild
            WriteLog(null, new LogEventArgs("Loading guilds", Color.Black));
            GuildDB.LoadGuild();

            WriteLog(null, new LogEventArgs("Loading guild members", Color.Black));
            GuildDB.LoadGuildMember();

        }

        private void InitializeClasse() {
            Classe.Classes = new List<Classe>();
            
            WriteLog(null, new LogEventArgs("Loading classes", Color.Black));
            ClasseDB.GetClasseStatsBase();            
        }

        private void InitializeDatabaseConfig() {
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

        private void InitializeServerMessage() {
            const string fileName = "WorldMessage.txt";

            if (!File.Exists(fileName)) {
                Log.Write("The message file was not found", Color.Black);
            }

            Chat.WorldMessage = new List<string>();

            using (StreamReader sr = new StreamReader(fileName)) {
                while (sr.Peek() >= 0) {
                    Chat.WorldMessage.Add(sr.ReadLine());
                }
            }
        }

        #region Menu
        private void min_MenuItem_Click(object sender, EventArgs e) {
            trayIcon.Visible = true;
            Visible = false;
            ShowInTaskbar = false;  
        }
        private void clear_MenuItem_Click(object sender, EventArgs e) {
            general_textbox.Clear();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;

            Log.CloseFile();

            e.Cancel = false;
        }

        /// <summary>
        /// Recarrega guilds e config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reloadGuild_MenuItem_Click(object sender, EventArgs e) {
            InitializeGuild();
        }


        /// <summary>
        /// Recarrega config de personagens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reloadChar_MenuItem_Click(object sender, EventArgs e) {
            //InitializeCharacter();
        }

        /// <summary>
        /// Recarrega classes e config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reloadClasse_MenuItem_Click(object sender, EventArgs e) {
            InitializeClasse();
        }
        #endregion

        /// <summary>
        /// Limpa todo o registro de log na tela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerClear_Tick(object sender, EventArgs e) {
            general_textbox.Clear();
        }

        /// <summary>
        /// Ativa o timer para limpar o registro na tela.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearScreenSeconds_Click(object sender, EventArgs e) {
            if (ClearScreenSeconds.Checked) {
                ClearScreenSeconds.Checked = false;
                timerClear.Stop();
            }
            else {
                ClearScreenSeconds.Checked = true;
                timerClear.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            Text = $"World Server @ {Configuration.WorldServerName} {World.CPS}";
        }

        private void shop_reload_Click(object sender, EventArgs e) {
            LuaConfig.ReloadCashShop();
        }

        private void reload_server_menuitem_Click(object sender, EventArgs e) {

        }
    }
}