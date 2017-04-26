using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Linq;
using LoginServer.Server;

namespace LoginServer.Common {
    public static class Configuration {
        /// <summary>
        /// ID de login server.
        /// </summary>
        public static int ID { get; set; }

        /// <summary>
        /// Descoberta de conexão.
        /// </summary>
        public static string Discovery { get; set; }

        /// <summary>
        /// Porta do servidor.
        /// </summary>
        public static int LoginServerPort { get; set; }

        /// <summary>
        /// Quantidade máxima de conexões.
        /// </summary>
        public static int MaximumConnections { get; set; }

        /// <summary>
        /// Sleep do loop principal.
        /// </summary>
        public static int Sleep { get; set; }

        /// <summary>
        /// Desativa o login temporariamente.
        /// </summary>
        public static bool DisableLogin { get; set; }

        /// <summary>
        /// Versão do cliente e servidor
        /// </summary>
        public static string Version { get; set; }

        /// <summary>
        /// Ativa ou desativa o envio do estado do world server no cliente.
        /// </summary>
        public static bool WorldStatusData { get; set; }

        /// <summary>
        /// Lista de canal ou servidor.
        /// </summary>
        public static ServerData[] Server { get; set; } = new ServerData[Constant.MAX_SERVER];
    }
}