using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using GameServer.Common;
using GameServer.MySQL;
using GameServer.Server;
using GameServer.Network;
using GameServer.ClasseData;
using GameServer.GameGuild;
using GameServer.LuaScript;
using Elysium;

namespace GameServer {
    public partial class frmMain : Form {
        public bool GameRunning = true;

        #region Peek Message
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

        /// <summary>Windows Message</summary>
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
            while (AppStillIdle) {
                Server.World.Loop();

                if (Configuration.Sleep > 0) { Thread.Sleep(Configuration.Sleep); }
            }

            if (!GameRunning) { Application.Exit(); }
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

            Logs.LogsEvent += WriteLog;
        }

        private void MainForm_Load(object sender, EventArgs e) {

        }

        private void exitItem_Click(object sender, EventArgs e) {
            Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            Logs.CloseFile();
        }

        private void clearScreenItem_Click(object sender, EventArgs e) {
            general_textbox.Text = string.Empty;
        }

        public void InitializeServer() {
            Settings.ParseConfigFile("ServerConfig.txt");

            Logs.Enabled = Settings.GetBoolean("Logs");

            var result = string.Empty;
            if (Logs.Enabled)
                if (!Logs.OpenFile(out result)) MessageBox.Show(result);

            Configuration.ID = Settings.GetInt32("ID");
            Logs.Write($"ID: {Configuration.ID}", Color.Red);

            Configuration.GameServerName = Settings.GetString("Name");
            Logs.Write($"Game Server Name: {Configuration.GameServerName}", Color.CornflowerBlue);
            Text = $"Game Server @ {Configuration.GameServerName}";

            Configuration.Discovery = Settings.GetString("Discovery");
            Logs.Write($"Discovery: {Configuration.Discovery}", Color.Black);

            Configuration.GameServerPort = Settings.GetInt32("Port");
            Logs.Write($"Port: {Configuration.GameServerPort}", Color.Black);

            Configuration.MaximumConnections = Settings.GetInt32("MaximumConnections");
            Logs.Write($"MaximumConnections: {Configuration.MaximumConnections}", Color.Black);

            Configuration.Sleep = Settings.GetInt32("Sleep");
            Logs.Write($"Sleep: {Configuration.Sleep}", Color.Black);

            result = (Logs.Enabled == true) ? "Logs: Ativado" : "Logs: Desativado";
            Logs.Write(result, Color.Black);

            Configuration.WorldServerID = new string[Constant.MAX_SERVER];

            Logs.Write("Carregando config mysql", Color.Black);

            Common_DB.Server = Settings.GetString("MySQL_IP");
            Common_DB.Port = Settings.GetInt32("MySQL_Port");
            Common_DB.Username = Settings.GetString("MySQL_User");
            Common_DB.Password = Settings.GetString("MySQL_Pass");
            Common_DB.Database = Settings.GetString("MySQL_DB");

            Logs.Write("Connectado ao banco de dados", Color.Green);

            // Tenta se conectar ao banco de dados
            if (!Common_DB.Open(out result))
                Logs.Write(result, Color.Red);

            for (int n = 0; n < Constant.MAX_SERVER; n++) {
                Configuration.WorldServerID[n] = Settings.GetString($"{n + 1}_WorldID");
                Logs.Write($"WorldServer {n + 1}  ID: {Configuration.WorldServerID[n]}", Color.Coral);
            }

            Logs.Write("Carregando experiência", Color.Black);
            ServerData_DB.LoadExperience();

            Logs.Write($"Level Max: {Experience.Level.LevelMax}", Color.BlueViolet);
            Logs.Write($"Exp Max: {Experience.Level.GetMaxExp()}", Color.BlueViolet);

            Guild.Guilds = null;
            // Prepara as classes para receber dados
            Guild.Guilds = new HashSet<Guild>();

            // Carrega todos os dados de guild
            Logs.Write("Carregando guilds", Color.Black);
            Guild_DB.GuildInfo();

            Guild_DB.MemberInfo();
            Logs.Write("Carregando membros", Color.Black);

            // Classes
            InitializeClasse();

            ///npc
            Logs.Write("Carregando NPC", Color.Black);
            Npc_DB.LoadNpcData();

            //Inicia mapas de teste        
            var map = new Maps.Map(1);
            Maps.MapManager.Add(map);
            Maps.MapManager.LoadMaps();

            Logs.Write("Carregando scripts", Color.BlueViolet);
            LuaConfig.InitializeConfig();

            GameNetwork.InitializeServer();
            Logs.Write("Game Server Start", Color.Green);
        }

        public void InitializeClasse() {
            Classe.Classes = new List<Classe>();

            Logs.Write("Carregando classe(s) base", Color.MediumVioletRed);
            Classes_DB.GetClasseStatsBase();

            Logs.Write("Carregando classe(s) incremento", Color.MediumVioletRed);

            for (var index = 0; index < Classe.Classes.Count; index++) {
                Classes_DB.GetClasseStatsIncrement(index, Classe.Classes[index].IncrementID);
            }
        }

        public void Exit() {
            Logs.CloseFile();
            Application.Exit();
        }

        public void WriteLog(object sender, LogsEventArgs e) {
            general_textbox.SelectionStart = general_textbox.TextLength;
            general_textbox.SelectionLength = 0;

            general_textbox.SelectionColor = e.Color;
            general_textbox.AppendText($"{DateTime.Now}: {e.Text}\n");
            general_textbox.SelectionColor = e.Color;

            general_textbox.ScrollToCaret();
        }


        private void button1_Click(object sender, EventArgs e) {


        }
    }
}
