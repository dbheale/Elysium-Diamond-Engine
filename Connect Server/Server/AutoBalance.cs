using System.Drawing;
using System.Collections.Generic;
using Elysium.Logs;

namespace ConnectServer.Server {
    /// <summary>
    /// Distribui os usuários de acordo com a capacidade do servidor.
    /// </summary>
    public static class AutoBalance {
        // Após o limite de todos os canais terem sido atingido, aumenta em 5% a capacidade dos canais.
        /// <summary>
        /// Aumenta a porcentagem populacional do canal.
        /// </summary>
        const byte MAX_PERCENT = 5;

        /// <summary>
        /// Ativa ou desativa o auto balanceamento de usuários.
        /// </summary>
        public static bool Enabled { get; set; } = true;

        private static List<Channel> channel { get; set; } = new List<Channel>();

        /// <summary>
        /// Adiciona um novo canal.
        /// </summary>
        /// <param name="gameID"></param>
        /// <param name="regionID"></param>
        /// <param name="ip"></param>
        /// <param name="localIp"></param>
        /// <param name="port"></param>
        public static void AddChannel(int gameID, int regionID, string ip, int port) {
            var channel = new Channel();
            channel.ServerID = gameID;
            channel.RegionID = regionID;
            channel.IP = ip;
            channel.Port = port;

            AutoBalance.channel.Add(channel);

            Log.Write($"Added game server {channel.ServerID} region {channel.RegionID}", Color.Black);       
        }

        /// <summary>
        /// Encontra um canal pelo ID de região.
        /// </summary>
        /// <param name="regionID"></param>
        /// <returns></returns>
        public static Channel FindChannelByRegionID(int regionID) {
            var list = new List<Channel>();
            var count = channel.Count;

            //encontra os canais disponíveis
            for (int i = 0; i < count; i++) {
                if (channel[i].RegionID.CompareTo(regionID) == 0) {
                    list.Add(channel[i]);
                }
            }

            //se não achar, retorna um valor vazio
            if (list.Count == 0) return new Channel();

            //procura por servidores online
            for (int i = 0; i < list.Count; i++) {
                if (list[i].Online)
                    return list[i];
            }

            //se não achar, retorna um valor vazio
            return new Channel();
        }

        /// <summary>
        /// Altera o status do servidor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public static void ChangeChannelStatus(int id, bool status) {
            var index = FindIndexByID(id);

            if (index == -1) {
                return;
            }
   
            channel[index].Online = status;
        }

        /// <summary>
        /// Encontra o índice um canal na lista pelo ID do gameserver.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private static int FindIndexByID(int id) {
            for (int i = 0; i < channel.Count; i++) {
                if (channel[i].ServerID.CompareTo(id) == 0)
                    return i;
            }

            //retorna -1 caso não encontrar
            return -1;
        }
    }
}