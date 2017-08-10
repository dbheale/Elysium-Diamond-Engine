using Lidgren.Network;

namespace ConnectServer.Server {
    public sealed class Client {
        /// <summary>
        /// Referência de conexão.
        /// </summary>
        public NetConnection Connection { get; set; }

        /// <summary>
        /// ID do servidor conectado.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Nome para identificação.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID de conexão.
        /// </summary>
        public string HexID { get; set; }

        /// <summary>
        /// Verifica se o estado da conexão.
        /// </summary>
        /// <param name="hexID"></param>
        /// <returns></returns>
        public bool Connected() {
            return (Connection.Status == NetConnectionStatus.Connected) ? true : false;
        }

        public Client(NetConnection connection) {
            Connection = connection;
            Name = string.Empty;
            HexID = NetUtility.ToHexString(connection.RemoteUniqueIdentifier);
        }
    }
}