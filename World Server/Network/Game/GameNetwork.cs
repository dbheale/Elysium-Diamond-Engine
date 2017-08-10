using System;
using System.Collections.Generic;
using WorldServer.Server;

namespace WorldServer.Network {
    public static class GameNetwork {
        /// <summary>
        /// Tick do tempo de descoberta de rede. 
        /// </summary>
        private static int tick;

        private static int max_server;

        /// <summary>
        /// Cliente de conexão com o game server.
        /// </summary>
        public static List<NetworkClient> GameServer { get; set; } = new List<NetworkClient>();

        /// <summary>
        /// Inicializa e configura as 5 conexões com GameServer.
        /// </summary>
        public static void InitializeGameServer() {
            max_server = AutoBalance.Channel.Count;

            for (var index = 0; index < max_server; index++) {
                GameServer.Add(new NetworkClient());

                //se possível, manter a conexão do game server em rede local para maior desempenho.
                if (!string.IsNullOrEmpty(AutoBalance.Channel[index].Name)) {
                    GameServer[index].InitializeClient(
                        AutoBalance.Channel[index].LocalIP,
                        AutoBalance.Channel[index].IP,
                        AutoBalance.Channel[index].Port,
                        AutoBalance.Channel[index].ID
                        );
                }
            }
        }

        public static void Shutdown() {
            for (var index = 0; index < max_server; index++) {
                GameServer[index].Shutdown();
            }
        }

        /// <summary>
        /// Faz a conexão com GameServer.
        /// </summary>
        public static void GameServerConnect() {
            // Faz a descoberta de rede a cada 10 segundos, se inativo, tenta uma nova conexão.
            if (Environment.TickCount >= (tick + 10000)) {
                tick = Environment.TickCount;

                for (var index = 0; index < max_server; index++) {
                    GameServer[index].DiscoverServer();

                    AutoBalance.Channel[index].Online = GameServer[index].Connected();
                }
            }
        }

        /// <summary>
        /// Recebe os dados de cada GameServer.
        /// </summary>
        public static void GameServerReceiveData() {
            for (var index = 0; index < max_server; index++) {
                GameServer[index].ReceiveData(index);
            }
        }
    }
}