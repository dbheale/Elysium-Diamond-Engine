using Lidgren.Network;
using WorldServer.Common;
using WorldServer.Server;
using Elysium;

namespace WorldServer.Network {
    public sealed class NetworkClient {
        private string ip = string.Empty;
        private string local_ip = string.Empty;
        private int port;

        public int GameServerID { get; set; }

        public NetClient Socket;
        private NetIncomingMessage incMsg;

        /// <summary>
        /// Inicializa o cliente.
        /// </summary>
        /// <param name="localAddress"></param>
        /// <param name="address"></param>
        /// <param name="port"></param>
        public void InitializeClient(string localAddress, string address, int port, int gameID) {
            if (Socket == null) {
                local_ip = localAddress;
                ip = address;
                this.port = port;
                GameServerID = gameID;

                // Networking //
                var config = new NetPeerConfiguration(Configuration.Discovery);
                config.ConnectionTimeout = 25;
                config.UseMessageRecycling = true;
                config.AutoFlushSendQueue = true;
                config.EnableMessageType(NetIncomingMessageType.DiscoveryResponse | NetIncomingMessageType.StatusChanged | NetIncomingMessageType.Data);
                config.DisableMessageType(NetIncomingMessageType.ConnectionApproval |
                    NetIncomingMessageType.ConnectionLatencyUpdated |
                    NetIncomingMessageType.DebugMessage |
                    NetIncomingMessageType.Error |
                    NetIncomingMessageType.NatIntroductionSuccess |
                    NetIncomingMessageType.Receipt |
                    NetIncomingMessageType.UnconnectedData |
                    NetIncomingMessageType.VerboseDebugMessage |
                    NetIncomingMessageType.WarningMessage);

                Socket = new NetClient(config);
                Socket.Start();
                Socket.Socket.Blocking = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Shutdown() {
            Socket.Shutdown("");
            Socket = null;
        }

        /// <summary>
        /// Descoberta de servidor.
        /// </summary>
        /// <returns></returns>
        public bool DiscoverServer() {
            if (Equals(null, Socket)) { return false; }

            if (Connected()) { return true; }

            if (string.IsNullOrEmpty(local_ip)) {
                if (Socket.DiscoverKnownPeer(ip, port)) { return true; }
            }
            else {
                if (Socket.DiscoverKnownPeer(local_ip, port)) { return true; }
            }

            return false;
        }

        /// <summary>
        /// Verifica se o cliente está conectado.
        /// </summary>
        /// <returns></returns>
        public bool Connected() {
            if (Socket == null) { return false; }
            return Socket.ConnectionStatus == NetConnectionStatus.Connected ? true : false;
        }

        /// <summary>
        /// Envia os dados.
        /// </summary>
        /// <param name="Data"></param>
        public void SendData(NetOutgoingMessage msg) {
            if (Socket == null) { return; }
            Socket.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Lê e processa as informações recebidas.
        /// </summary>
        /// <param name="index"></param>
        public void ReceiveData(int index) {
            if (Socket == null) { return; }

            //lê os dados recebidos
            while ((incMsg = Socket.ReadMessage()) != null) {
                switch (incMsg.MessageType) {
                    case NetIncomingMessageType.DiscoveryResponse:
                        Socket.Connect(incMsg.SenderEndPoint);
                        Logs.Write($"Conectado ao Game Server #{AutoBalance.Channel[index].Name}", System.Drawing.Color.Green);
                        break;
                    case NetIncomingMessageType.StatusChanged:
                        NetConnectionStatus status = (NetConnectionStatus)incMsg.ReadByte();

                        //envia confirmação
                        if (status == NetConnectionStatus.Connected) {
                            GamePacket.ConnectionID(index);
                        }

                        if (status == NetConnectionStatus.Disconnected) {
                            Logs.Write($"Game Server #{AutoBalance.Channel[index].Name} desconectado", System.Drawing.Color.Green);
                        }
                        break;
                    case NetIncomingMessageType.Data:
                        GameData.HandleData(index, incMsg);
                        break;
                }

                Socket.Recycle(incMsg);
            }
        }
    }
}

