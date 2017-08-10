using System.Drawing;
using Lidgren.Network;
using GameServer.Common;
using GameServer.Server;
using GameServer.Player;
using Elysium.Logs;

namespace GameServer.Network {
    public static class GameNetwork {
        /// <summary>
        /// Total de conexões.
        /// </summary>
        public static int ConnectionsCount {
            get { return socket.ConnectionsCount; }
        }

        /// <summary>
        /// Socket de conexão
        /// </summary>
        private static NetServer socket;

        /// <summary>
        /// 
        /// </summary>
        private static NetIncomingMessage msg;

        /// <summary>
        /// 
        /// </summary>
        private static PlayerData pData;

        /// <summary>
        /// Inicializa as configurações do servidor.
        /// </summary>
        public static void InitializeServer() { 
            var config = new NetPeerConfiguration(Configuration.Discovery);
            config.Port = Configuration.GameServerPort;
            config.AutoFlushSendQueue = true;
            config.AcceptIncomingConnections = true;
            config.MaximumConnections = Configuration.MaximumConnections;
            config.ConnectionTimeout = 25.0f;
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
        /// Recebe os dados.
        /// </summary>
        public static void ReceiveData() {
            if (socket == null) { return; }

            while ((msg = socket.ReadMessage()) != null) {
                pData = Authentication.FindByConnection(msg.SenderConnection);

                switch (msg.MessageType) {
                    case NetIncomingMessageType.DiscoveryRequest:
                        var ip = msg.SenderEndPoint.Address.ToString();

                        socket.SendDiscoveryResponse(null, msg.SenderEndPoint);
                        Log.Write($"Discovery Response IPEndPoint: {msg.SenderEndPoint.Address}", Color.Coral);

                        break;
                    case NetIncomingMessageType.ErrorMessage:
                        #region ErrorMessage
                        var error = msg.ReadString();
                        Log.Write($"Error: {error}", Color.Red);
                        #endregion
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        #region StatusChanged : Connected
                        var status = (NetConnectionStatus)msg.ReadByte();

                        if (status == NetConnectionStatus.Connected) {
                            Authentication.Connect(msg);
                        }
                        #endregion

                        #region StatusChanged : Disconnected
                        if (status == NetConnectionStatus.Disconnected) {
                            if (pData != null) Authentication.Disconnect(pData);
                        }
                        #endregion
                        break;

                    case NetIncomingMessageType.Data:
                        GameData.HandleData(pData.Connection, msg);
                        break;
                    default:
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
            if (Authentication.FindByHexID(hexID).Connection == null) { return false; }
            if (Authentication.FindByHexID(hexID).Connection.Status == NetConnectionStatus.Connected) { return true; }

            return false;
        }

        /// <summary>
        /// Verifica se o cliente está conectado.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static bool IsConnected(NetConnection connection) {
            if (connection == null) { return false; }
            if (connection.Status == NetConnectionStatus.Connected) { return true; }

            return false;
        }

        /// <summary>
        /// Envia dados para o cliente.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="msg"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataTo(string hexID, NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod) {
            socket.SendMessage(msg, Authentication.FindByHexID(hexID).Connection, deliveryMethod);
        }

        /// <summary>
        /// Envia dados para o cliente.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataTo(NetConnection connection, NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod) {
            socket.SendMessage(msg, connection, deliveryMethod);
        }

        /// <summary>
        /// Envia dados para o cliente.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        /// <param name="deliveryMethod"></param>
        /// <param name="channel"></param>
        public static void SendDataTo(NetConnection connection, NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod, int channel) {
            socket.SendMessage(msg, connection, deliveryMethod, channel);
        }

        /// <summary>
        /// Envia dados para todos os clientes.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataToAll(NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod) {
            socket.SendToAll(msg, deliveryMethod);
        }
    }
}