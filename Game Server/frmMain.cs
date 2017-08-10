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
using GameServer.Classes;
using GameServer.GameGuild;
using GameServer.LuaScript;
using Elysium.IO;
using Elysium.Logs;

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

            Log.LogEvent += WriteLog;
        }

        private void exitItem_Click(object sender, EventArgs e) {
            Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            Log.CloseFile();
        }

        private void clearScreenItem_Click(object sender, EventArgs e) {
            general_textbox.Text = string.Empty;
        }

        public void InitializeServer() {
            Settings.ParseConfigFile("ServerConfig.txt");

            Log.Enabled = Settings.GetBoolean("Log");

            var result = string.Empty;
            if (Log.Enabled)
                if (!Log.OpenFile(out result)) MessageBox.Show(result);

            Configuration.ID = Settings.GetInt32("ID");
            Log.Write($"ID: {Configuration.ID}", Color.Red);

            Configuration.GameServerName = Settings.GetString("Name");
            Log.Write($"Game Server Name: {Configuration.GameServerName}", Color.CornflowerBlue);
            Text = $"Game Server @ {Configuration.GameServerName}";

            Configuration.Discovery = Settings.GetString("Discovery");
            Log.Write($"Discovery: {Configuration.Discovery}", Color.Black);

            Configuration.GameServerPort = Settings.GetInt32("Port");
            Log.Write($"Port: {Configuration.GameServerPort}", Color.Black);

            Configuration.MaximumConnections = Settings.GetInt32("MaximumConnections");
            Log.Write($"MaximumConnections: {Configuration.MaximumConnections}", Color.Black);

            Configuration.Sleep = Settings.GetInt32("Sleep");
            Log.Write($"Sleep: {Configuration.Sleep}", Color.Black);

            Configuration.ConnectIp = Settings.GetString("ConnectIp");
            Log.Write($"Connect Ip: {Configuration.ConnectIp}", Color.Black);

            Configuration.ConnectPort = Settings.GetInt32("ConnectPort");
            Log.Write($"Connect Port: {Configuration.ConnectPort}", Color.Black);

            result = (Log.Enabled == true) ? "Log: Enabled" : "Log: Disabled";
            Log.Write(result, Color.Black);

            Common_DB.Server = Settings.GetString("MySQL_IP");
            Common_DB.Port = Settings.GetInt32("MySQL_Port");
            Common_DB.Username = Settings.GetString("MySQL_User");
            Common_DB.Password = Settings.GetString("MySQL_Pass");
            Common_DB.Database = Settings.GetString("MySQL_DB");

            Log.Write("Trying to connect database", Color.Green);

            // Tenta se conectar ao banco de dados
            if (!Common_DB.Open(out result))
                Log.Write(result, Color.Red);

            Log.Write("Loading items", Color.Black);
            GameData_DB.LoadItems();
            Log.Write($"{GameItem.ItemManager.Count()} items loaded", Color.Black);

            Log.Write("Loading talents", Color.Black);
            GameData_DB.LoadTalent();
            Log.Write($"{GameTalent.TalentManager.Talent.Count} talents loaded", Color.Black);

            Log.Write("Loading experience table", Color.Black);
            GameData_DB.LoadExperience();
            Log.Write($"Max Level: {Experience.Level.LevelMax} EXP: {Experience.Level.GetMaxExp()}", Color.BlueViolet);

            // Prepara as classes para receber dados
            Guild.Guilds = new HashSet<Guild>();

            // Carrega todos os dados de guild
            Log.Write("Loading guilds", Color.Black);
            Guild_DB.GuildInfo();

            Guild_DB.MemberInfo();
            Log.Write("Loading members", Color.Black);

            // Classes
            InitializeClasse();

            ///npc
            Log.Write("Loading NPC", Color.Black);
            Npc_DB.LoadNpcData();

            //Inicia mapas de teste        
            var map = new Maps.Map(1);
            Maps.MapManager.Add(map);
            Maps.MapManager.LoadMaps();

            Log.Write("Loading scripts", Color.BlueViolet);
            LuaConfig.InitializeConfig();

            GameNetwork.InitializeServer();
            NetworkClient.Initialize();
            Log.Write("Game Server Start", Color.Green);
        }

        public void InitializeClasse() {
            Classe.Classes = new List<Classe>();

            Log.Write("Loading classe base", Color.MediumVioletRed);
            Classes_DB.GetClasseStatsBase();

            Log.Write("Loading classe increment", Color.MediumVioletRed);

            for (var index = 0; index < Classe.Classes.Count; index++) {
                Classes_DB.GetClasseStatsIncrement(index, Classe.Classes[index].IncrementID);
                Classes_DB.GetClasseTalent(index, Classe.Classes[index].TalentID);
            }
        }

        public void Exit() {
            Log.CloseFile();
            Application.Exit();
        }

        public void WriteLog(object sender, LogEventArgs e) {
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