using System;
using System.Drawing;
using ConnectServer.Network;
using ConnectServer.Server;
using Elysium.IO;
using Elysium.Logs;
using ConnectServer.LuaScript;

namespace ConnectServer {
    public static class Connect {
        private static int _count;
        private static int _tick;       

        /// <summary>
        /// Loops (updates) por segundos.
        /// </summary>
        public static int UPS { get; set; }      

        /// <summary>
        /// Inicializa as configurações do servidor.
        /// </summary>
        public static void Initialize() {
            Settings.ParseConfigFile("Config.txt");

            Log.Enabled = Settings.GetBoolean("Log");

            var error = string.Empty;
            var result = true;

            if (Log.Enabled) {
                result = Log.OpenFile(out error);

                if (!result) {
                    Log.Write($"Ocorreu um erro ao abrir o arquivo de logs", Color.Red);
                    Log.Write(error, Color.Red);
                }
            }

            Configuration.Discovery = Settings.GetString("Discovery");
            Configuration.Port = Settings.GetInt32("Port");
            Configuration.Sleep = Settings.GetInt32("Sleep");
            Configuration.MaxConnections = Settings.GetInt32("MaximumConnections");

            Log.Write($"Discovery: {Configuration.Discovery}", Color.Black);
            Log.Write($"Port: {Configuration.Port}", Color.Black);
            Log.Write($"Sleep: {Configuration.Sleep}", Color.Black);
            Log.Write($"Max Connections: {Configuration.MaxConnections}", Color.Black);
            Log.Write($"Loading scripts", Color.Black);
            LuaConfig.InitializeConfig();

            Log.Write("Connect Server Start", Color.Green);
            NetworServer.Initialize();
        }

        /// <summary>
        /// Processa os dados.
        /// </summary>
        public static void Loop() {
            // recebe os dados
            NetworServer.ReceivedData();

            // remove os clients desconectados
            Authentication.RemoveClients();
           
            if (Environment.TickCount >= _tick + 1000) {
                UPS = _count;
                _tick = Environment.TickCount;
                _count = 0;
            }

            _count++;
        }
    }
}