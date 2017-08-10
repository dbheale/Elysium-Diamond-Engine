using System;
using WorldServer.Network;
using Elysium.Logs;
using Elysium.IO;

namespace WorldServer.Server {
    public static class World {
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
            //recebe os dados do world server
            WorldNetwork.ReceivedData();

            //verifica e tenta uma nova conexão com o game server
            NetworkClient.DiscoverServer();

            NetworkClient.ReceiveData();

            //se houver alguma conexão com ID 0, realiza a desconexão e remove usuários
            Authentication.RemoveInvalidUsersAndHexID();

            //percorre todos os hexid de jogadores, se ambos hexid estiverem corretos, aceita a conexão
            Authentication.VerifyHexID();

            //verifica se há personagens para excluir.
            DeleteTime.VerifyCharacters();

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
            Classe.Clear();
            Settings.Clear();
            Authentication.Clear();
            ProhibitedNames.Clear();
            Log.CloseFile();
            WorldNetwork.Shutdown();
            NetworkClient.Disconnect();
        }
    }
}