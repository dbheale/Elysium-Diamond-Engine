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
            // Percorre todos os hexid e verifica se o tempo limite já foi ultrapassado ...
            // Se verdadeiro, é retirado da lista
            Authentication.VerifyHexID();

            // Percorre todos os hexid de jogadores, se ambos hexid estiverem corretos, aceita a conexão
            Authentication.VerifyPlayerHexID();

            // Recebe os dados do game server
            GameNetwork.ReceiveData();

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
