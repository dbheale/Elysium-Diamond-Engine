using System;
using GameServer.Network;

namespace GameServer.Server {
    public class World {
        /// <summary>
        /// Loops por segundos.
        /// </summary>
        public static int CPS { get; set; }

        /// <summary>
        /// Contador privado.
        /// </summary>
        private static int count;

        /// <summary>
        /// tick windows em ms.
        /// </summary>
        private static int tick;

        /// <summary>
        /// Loop do servidor.
        /// </summary>
        public static void Loop() {
            // recebe os dados do game server
            GameNetwork.ReceiveData();

            NetworkClient.DiscoverServer();

            // recebe os dados do connect server
            NetworkClient.ReceiveData();

            // se houver alguma conexão com ID 0, realiza a desconexão e remove usuários
            Authentication.RemoveInvalidUsersAndHexID();

            // percorre todos os hexid de jogadores, se ambos hexid estiverem corretos, aceita a conexão
            Authentication.VerifyPlayerHexID();

            Maps.MapManager.Compute();

            if (Environment.TickCount >= tick + 1000) {
                CPS = count;
                tick = Environment.TickCount;
                count = 0;
            }

            count++;
        }
    }
}