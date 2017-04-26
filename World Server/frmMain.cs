using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using WorldServer.Chat;
using WorldServer.Common;
using WorldServer.Network;
using WorldServer.MySQL;
using WorldServer.Server;
using WorldServer.GameGuild;
using WorldServer.LuaScript;
using Elysium;


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

            Logs.LogsEvent += WriteLog;
        }

        private void quit_MenuItem_Click(object sender, EventArgs e) {
            Logs.CloseFile();
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

            Logs.Enabled = Settings.GetBoolean("Logs");

            var result = string.Empty;
            if (Logs.Enabled) {
                if (!Logs.OpenFile(out result)) MessageBox.Show(result);
            }

            WorldChat.ReadMessageFile();

            Configuration.ID = Settings.GetInt32("ID");
            Logs.Write($"ID: {Configuration.ID}", Color.Red);

            Configuration.WorldServerName = Settings.GetString("WorldServerName");
            Logs.Write($"Server Name: {Configuration.WorldServerName}", Color.Black);

            Configuration.Discovery = Settings.GetString("Discovery");
            Logs.Write($"Discovery: {Configuration.Discovery}", Color.Black);

            Text = $"World Server @ {Configuration.WorldServerName}";

            Configuration.WorldServerPort = Settings.GetInt32("Port");
            Logs.Write($"Port: {Configuration.WorldServerPort}", Color.Black);

            Configuration.MaximumConnections = Settings.GetInt32("MaximumConnections");
            Logs.Write($"Maximum Connections: {Configuration.MaximumConnections}", Color.Black);

            result = (Logs.Enabled == true) ? "Logs: Ativado" : "Logs: Desativado";
            Logs.Write(result, Color.Black);

            Configuration.Sleep = Settings.GetInt32("Sleep");
            Logs.Write($"Sleep: {Configuration.Sleep}", Color.Black);

            Logs.Write($"Create Character: {Configuration.CharacterCreation}", Color.MediumVioletRed);
            Logs.Write($"Delete Character: {Configuration.CharacterDelete}", Color.MediumVioletRed);

            InitializeServerConfig();

            Logs.Write("Carregando config do mysql", Color.Black);
            InitializeDatabaseConfig();

            Logs.Write("Connectado ao banco de dados", Color.Green);

            if (!Common_DB.Open(out result))
                Logs.Write(result, Color.Red);      

            InitializeGuild();
            InitializeClasse();
        
            WorldNetwork.InitializeServer();
            GameNetwork.InitializeGameServer();

            Logs.Write("Carregando scripts", Color.BlueViolet);
            LuaConfig.InitializeConfig();     

            Logs.Write("World Server Start.", Color.Green);

            #region System Tray
            trayMenu.MenuItems.Add("Mostrar", ShowForm);
            trayMenu.MenuItems.Add("Sair", quit_MenuItem_Click);

            trayIcon.Text = "World Server @";
            trayIcon.Icon = this.Icon;

            trayIcon.ContextMenu = trayMenu;
            #endregion
        }

        public void WriteLog(object sender, LogsEventArgs e) {
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
            WriteLog(null, new LogsEventArgs("Carregando guilds.", Color.Black));
            Guild_DB.LoadGuild();

            WriteLog(null, new LogsEventArgs("Carregando membros.", Color.Black));
            Guild_DB.LoadGuildMember();

        }

        private void InitializeClasse() {
            Classe.Classes = new List<Classe>();
            
            WriteLog(null, new LogsEventArgs("Carregando classe(s) base.", Color.BlueViolet));
            Classes_DB.GetClasseStatsBase();            
        }

        private void InitializeDatabaseConfig() {
            Common_DB.Server = Settings.GetString("MySQL_IP");
            Common_DB.Port = Settings.GetInt32("MySQL_Port");
            Common_DB.Username = Settings.GetString("MySQL_User");
            Common_DB.Password = Settings.GetString("MySQL_Pass");
            Common_DB.Database = Settings.GetString("MySQL_DB");
        }

        private void InitializeServerConfig() {
            var enabled = 0;

            for (var i = 0; i < Constant.MAX_SERVER; i++) {
                Configuration.GameServer[i] = new ServerData();         

                enabled = Settings.GetInt32((i + 1) + "_Enabled");

                if (enabled == 0) {
                    Configuration.GameServer[i].Clear();
                }
                else {
                    Configuration.GameServer[i].Name = Settings.GetString((i + 1) + "_Name");
                    Configuration.GameServer[i].Region = Settings.GetString((i + 1) + "_Region");
                    Configuration.GameServer[i].GameServerIP = Settings.GetString((i + 1) + "_GameServerIP");
                    Configuration.GameServer[i].GameServerLocalIP = Settings.GetString((i + 1) + "_GameServerLocalIP");
                    Configuration.GameServer[i].GameServerPort = Settings.GetInt32((i + 1) + "_GameServerPort");
                    Configuration.GameServer[i].Status = Settings.GetString((i + 1) + "_Status");

                    WriteLog(null, new LogsEventArgs($"Game Server: {Configuration.GameServer[i].Name} {Configuration.GameServer[i].Region} {Configuration.GameServer[i].Status}", Color.Coral));
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

            Logs.CloseFile();

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

        private void reloadServerData_MenuItem_Click(object sender, EventArgs e) {
            InitializeServerConfig();
        }

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
    }
}
