using System.Drawing;
using Lidgren.Network;
using WorldServer.Common;
using WorldServer.Server;
using Elysium.Logs;

namespace WorldServer.Network {
    public static class WorldNetwork {
        /// <summary>
        /// Total de conexões.
        /// </summary>
        public static int ConnectionsCount {
            get { return socket.ConnectionsCount; }
        }

        private static NetServer socket;

        private static NetIncomingMessage msg;

        private static PlayerData pData;

        /// <summary>
        /// Inicia as configurações.
        /// </summary>
        public static void InitializeServer() {
            var config = new NetPeerConfiguration(Configuration.Discovery);
            config.Port = Configuration.WorldServerPort;
            config.AutoFlushSendQueue = true;
            config.AcceptIncomingConnections = true;
            config.MaximumConnections = Configuration.MaxConnections;
            config.ConnectionTimeout = 25f;
            config.PingInterval = 2.0f;
            config.UseMessageRecycling = true;
            config.DisableMessageType(NetIncomingMessageType.ConnectionApproval |                  
                NetIncomingMessageType.ConnectionLatencyUpdated |
                NetIncomingMessageType.DebugMessage |
                NetIncomingMessageType.DiscoveryResponse |
                NetIncomingMessageType.Error |
                NetIncomingMessageType.NatIntroductionSuccess |
                NetIncomingMessageType.Receipt |
                NetIncomingMessageType.UnconnectedData |
                NetIncomingMessageType.VerboseDebugMessage |
                NetIncomingMessageType.WarningMessage);

            socket = new NetServer(config);
            socket.Start();
            socket.Socket.Blocking = false;
        }

        /// <summary>
        /// Cria a mensagem de envio.
        /// </summary>
        /// <returns></returns>
        public static NetOutgoingMessage CreateMessage() {
            return socket.CreateMessage();
        }

        /// <summary>
        /// Cria a mensagem de envio com a capacidade inicial.
        /// </summary>
        /// <param name="initialCapacity"></param>
        /// <returns></returns>
        public static NetOutgoingMessage CreateMessage(int initialCapacity) {
            return socket.CreateMessage(initialCapacity);
        }

        /// <summary>
        /// Fecha a conexão.
        /// </summary>
        public static void Shutdown() {
            socket.Shutdown("");
            socket = null;
        }

        /// <summary>
        /// Recebe os dados.
        /// </summary>
        public static void ReceivedData() {
            while ((msg = socket.ReadMessage()) != null) {

                pData = Authentication.FindByConnection(msg.SenderConnection);

                switch (msg.MessageType) {
                    case NetIncomingMessageType.DiscoveryRequest:
                        socket.SendDiscoveryResponse(null, msg.SenderEndPoint);
                        Log.Write($"Discovery Response IPEndPoint: {msg.SenderEndPoint.Address}", Color.Coral);

                        break;
                    case NetIncomingMessageType.ErrorMessage:
                        #region ErrorMessage
                        var error = msg.ReadString();

                        Log.Write($"Error: {error}", Color.Coral);

                        #endregion

                        break;
                    case NetIncomingMessageType.StatusChanged:

                        #region StatusChanged : Connected
                        NetConnectionStatus status = (NetConnectionStatus)msg.ReadByte();
                        if (status == NetConnectionStatus.Connected) {
                            Authentication.Connect(msg);   
                        }
                        #endregion

                        #region StatusChanged : Disconnected
                        if (status == NetConnectionStatus.Disconnected) {
                            Authentication.Disconnect(pData);           
                        }
                        #endregion

                        break;

                    case NetIncomingMessageType.Data:
                        WorldData.HandleData(pData.Connection, msg); 
                        break;
            
                    default:
                        Log.Write($"Unhandled type: {msg.MessageType}", Color.Red); 
                        break;
                }

                socket.Recycle(msg);
            }
        }

        /// <summary>
        /// Verifica se o cliente está conectado.
        /// </summary>
        /// <param name="hexID"></param>
        /// <returns></returns>
        public static bool IsConnected(string hexID) {
            if (Equals(null, Authentication.FindByHexID(hexID).Connection)) { return false; }
            return Authentication.FindByHexID(hexID).Connection.Status == NetConnectionStatus.Connected ? true : false;
        }

        /// <summary>
        /// Verifica se o cliente está conectado.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static bool IsConnected(NetConnection connection) {
            if (Equals(null, connection)) { return false; }
            return connection.Status == NetConnectionStatus.Connected ? true : false; 
        }

        /// <summary>
        /// Envia dados para o cliente.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataTo(string hexID, NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod) {
            socket.SendMessage(msg, Authentication.FindByHexID(hexID).Connection, deliveryMethod);
        }

        /// <summary>
        /// Envia dados para o cliente.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataTo(NetConnection connection, NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod) {
            socket.SendMessage(msg, connection, deliveryMethod);
        }

        /// <summary>
        /// Envia dados para todos os clientes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataToAll(NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod) {
            socket.SendToAll(msg, deliveryMethod);
        }
    }
}