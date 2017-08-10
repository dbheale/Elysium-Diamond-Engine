using System;
using LoginServer.Network;
using LoginServer.Common;
using LoginServer.Database;
using Elysium.Logs;
using Elysium.IO;

namespace LoginServer.Server {
    public static class Login {
        /// <summary>
        /// Loops por segundos.
        /// </summary>
        public static int UPS { get; private set; }
        
        /// <summary>
        /// Contador privado.
        /// </summary>
        private static int count, tick;

        /// <summary>
        /// Loop do servidor.
        /// </summary>
        public static void Loop() {
            // Recebe os dados do login server
            LoginNetwork.ReceivedData();

            // Verifica e tenta uma nova conexão com o world server
            NetworkClient.DiscoverServer();

            // Recebe os dados do world server
            NetworkClient.ReceiveData();

            // Verifica cada ip bloqueado, se o tempo expirou remove da lista
            GeoIp.CheckIpBlockedTime();

            if (Environment.TickCount >= tick + 1000) {
                UPS = count;
                tick = Environment.TickCount;
                count = 0;
            }

            count++;
        }

        /// <summary>
        /// Fecha todas as conexões e encerra.
        /// </summary>
        public static void Close() {
            //Não permite nenhuma conexão (evitar possíveis erros)
            Configuration.IsLoginDisabled = true;
            Configuration.Server = null;

            //Limpa as configurações
            Settings.Clear();
            Authentication.Clear();
            CheckSum.Clear();

            //Fecha o arquivo de logs
            Log.CloseFile();

            Environment.Exit(0);
        }
    }
}