using System;
using WorldServer.Network;
using WorldServer.MySQL;
using Elysium;

namespace WorldServer.Server {
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
            //Recebe os dados do world server
            WorldNetwork.ReceivedData();

            // Verifica e tenta uma nova conexão com o game server
            GameNetwork.GameServerConnect();

            // Recebe os dados do game server
            GameNetwork.GameServerReceiveData();

            //Se houver alguma conexão com ID 0, realiza a desconexão.
            Authentication.VerifyPlayers();

            // Percorre todos os hexid e verifica se o tempo limite já foi ultrapassado ...
            // Se verdadeiro, é retirado da lista
            Authentication.VerifyHexID();

            // Percorre todos os hexid de jogadores, se ambos hexid estiverem corretos, aceita a conexão
            Authentication.VerifyPlayerHexID();

            if (Environment.TickCount >= tick + 1000) {
                CPS = count;
                tick = Environment.TickCount;
                count = 0;
            }

            count++;
        }

        /// <summary>
        /// Limpa os dados e encerra.
        /// </summary>
        public static void Close() {
            Common_DB.Close();
            Classe.Clear();
            Settings.Clear();
            Authentication.Clear();
            ProhibitedNames.Clear();
            Logs.CloseFile();
            WorldNetwork.Shutdown();
            GameNetwork.Shutdown();
        }
    }
}
