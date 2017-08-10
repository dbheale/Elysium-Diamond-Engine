using System.Drawing;
using System.Collections.Generic;
using Elysium;

namespace WorldServer.Server {
    /// <summary>
    /// Distribui os usuários de acordo com a capacidade do servidor.
    /// </summary>
    public static class AutoBalance {
        // Após o limite de todos os canais terem sido atingido, aumenta em 5% a capacidade dos canais.
        /// <summary>
        /// Aumenta a porcentagem populacional do canal.
        /// </summary>
        //const byte MAX_PERCENT = 5;

        /// <summary>
        /// Ativa ou desativa o auto balanceamento de usuários.
        /// </summary>
        public static bool Enabled { get; set; }

        public static List<Channel> Channel { get; set; } = new List<Channel>();

        /// <summary>
        /// Adiciona um novo canal.
        /// </summary>
        /// <param name="regionID"></param>
        /// <param name="gameID"></param>
        /// <param name="name"></param>
        /// <param name="ip"></param>
        /// <param name="localIp"></param>
        /// <param name="port"></param>
        public static void Add(int regionID, int gameID, string name, string ip, string localIp, int port, int capacity, byte percentage) {
            var channel = new Channel();
            channel.RegionID = regionID;
            channel.ID = gameID;
            channel.Name = name;
            channel.IP = ip;
            channel.LocalIP = localIp;
            channel.Port = port;
            channel.Percentage = percentage;

            Channel.Add(channel);

            //Logs.Write($"{name} GameID: {gameID} {ip}:{port} Capacity: {capacity} {percentage}%", Color.Black);
        }

        /// <summary>
        /// Encontra um canal pelo ID de região.
        /// </summary>
        /// <param name="regionID"></param>
        /// <returns></returns>
        public static Channel FindChannelByRegionID(int regionID) {
            var list = new List<Channel>();

            //encontra os canais disponíveis
            for (int i = 0; i < Channel.Count; i++) {
                if (Channel[i].RegionID.CompareTo(regionID) == 0)
                    list.Add(Channel[i]);
            }

            //se não achar, retorna um valor vazio
            if (list.Count == 0)  return new Channel();

            //procura por servidores online
            for (int i = 0; i < list.Count; i++) {
                if (list[i].Online)
                    return list[i];
            }

            //se não achar, retorna um valor vazio
            return new Channel();
        }

        /// <summary>
        /// Encontra o índice um canal na lista pelo ID do gameserver.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int FindIndexByID(int id) {
            for (int i = 0; i < Channel.Count; i++) {
                if (Channel[i].ID.CompareTo(id) == 0)
                    return i;                
            }

            //retorna -1 caso não encontrar
            return -1;
        }
    }
}