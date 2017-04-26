using System;
using LoginServer.Network;
using LoginServer.Common;
using LoginServer.MySQL;

namespace LoginServer.Server {
    public static class Login {
        /// <summary>
        /// Loops por segundos.
        /// </summary>
        public static int CPS { get; set; }
        
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
            WorldNetwork.WorldServerConnect();

            // Recebe os dados do world server
            WorldNetwork.WorldServerReceiveData();

            // Verifica cada ip bloqueado, se o tempo expirou remove da lista
            GeoIp.CheckIpBlockedTime();

            if (Environment.TickCount >= tick + 1000) {
                CPS = count;
                tick = Environment.TickCount;
                count = 0;
            }

            count++;
        }

        /// <summary>
        /// Fecha todas as conexões.
        /// </summary>
        public static void Close() {
            //Não permite nenhuma conexão (evitar possíveis erros)
            Configuration.DisableLogin = true;
            Configuration.Server = null;

            //Limpa as configurações
            Elysium.Settings.Clear();
            Authentication.Clear();
            CheckSum.Clear();

            //Fecha o arquivo de logs
            Elysium.Logs.CloseFile();
            Common_DB.Close();

            //LoginNetwork.Shutdown();
            //WorldNetwork.Shutdown();

            Environment.Exit(0);
        }
    }
}
