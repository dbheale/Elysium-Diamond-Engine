using System.Drawing;
using Lidgren.Network;
using ConnectServer.Server;
using Elysium.Logs;

namespace ConnectServer.Network {
    public static class NetworServer {
        // socket de conexão
        private static NetServer socket;
        // dados recebidos
        private static NetIncomingMessage msg;

        /// <summary>
        /// Inicia e prepara a conexão.
        /// </summary>
        public static void Initialize() {      
            var config = new NetPeerConfiguration(Configuration.Discovery);
            config.Port = Configuration.Port;
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
        /// Processa os dados recebidos.
        /// </summary>
        public static void ReceivedData() {
            while ((msg = socket.ReadMessage()) != null) {

                switch (msg.MessageType) {
                    case NetIncomingMessageType.DiscoveryRequest:
                        socket.SendDiscoveryResponse(null, msg.SenderEndPoint);
                        Log.Write($"Discovery response IPEndPoint: {msg.SenderEndPoint.Address}", Color.Coral);
                        break;

                    case NetIncomingMessageType.ErrorMessage:
                        Log.Write($"Error: {msg.ReadString()}", Color.Coral);
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        var status = (NetConnectionStatus)msg.ReadByte();

                        if (status == NetConnectionStatus.Connected) {
                            Authentication.ConnectClient(msg);
                        }
  
                        if (status == NetConnectionStatus.Disconnected) {
                            Authentication.DisconnectClient(msg);
                        }

                        break;

                    case NetIncomingMessageType.Data:
                        ConnectData.Handle(msg);
                        break;

                    default:
                        Log.Write($"Unhandled type: {msg.MessageType}", Color.DarkRed);
                        break;
                }

                socket.Recycle(msg);
            }
        }

        /// <summary>
        /// Envia dados para determinada conexão.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="msg"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataTo(NetConnection connection, NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod) {
            socket.SendMessage(msg, connection, deliveryMethod);
        }

        /// <summary>
        /// Envia dados para todas as conexões.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataToAll(NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod) {
            socket.SendToAll(msg, deliveryMethod);
        }
    }
}