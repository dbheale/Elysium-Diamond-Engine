using System;
using System.Drawing;
using Lidgren.Network;
using GameServer.Common;
using Elysium.Logs;

namespace GameServer.Network {
    public static class NetworkClient {
        private static NetClient socket;
        private static NetIncomingMessage msg;
        private static int tick;

        /// <summary>
        /// Inicializa as configurações do socket.
        /// </summary>
        public static void Initialize() {
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

            socket = new NetClient(config);
            socket.Start();
            socket.Socket.Blocking = false;
        }

        /// <summary>
        /// Descoberta de servidor.
        /// </summary>
        /// <returns></returns>
        public static void DiscoverServer() {
            // Faz a descoberta de rede a cada 10 segundos, se inativo, tenta uma nova conexão.
            if (Environment.TickCount >= (tick + 10000)) {
                tick = Environment.TickCount;

                if (Connected()) { return; }

                if (!string.IsNullOrEmpty(Configuration.ConnectIp)) {
                    socket.DiscoverKnownPeer(Configuration.ConnectIp, Configuration.ConnectPort);
                }
            }
        }

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
        /// Verifica se o cliente está conectado.
        /// </summary>
        /// <returns></returns>
        public static bool Connected() {
            return socket.ConnectionStatus == NetConnectionStatus.Connected ? true : false;
        }

        /// <summary>
        /// Fecha a conexão.
        /// </summary>
        public static void Disconnect() {
            socket.Disconnect(string.Empty);
        }

        /// <summary>
        /// Envia os dados.
        /// </summary>
        /// <param name="Data"></param>
        public static void SendData(NetOutgoingMessage msg) {
            socket.SendMessage(msg, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Lê e processa as informações recebidas.
        /// </summary>
        /// <param name="index"></param>
        public static void ReceiveData() {
            while ((msg = socket.ReadMessage()) != null) {
                switch (msg.MessageType) {

                    case NetIncomingMessageType.DiscoveryResponse:
                        socket.Connect(msg.SenderEndPoint);
                        Log.Write($"Connect Server connected", Color.Green);
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        NetConnectionStatus status = (NetConnectionStatus)msg.ReadByte();

                        if (status == NetConnectionStatus.Connected) {
                            ConnectPacket.ConnectionID();
                        }

                        if (status == NetConnectionStatus.Disconnected) {
                            Log.Write($"Connect Server disconnected", Color.Green);
                        }
                        break;

                    case NetIncomingMessageType.Data:
                        ConnectData.HandleData(msg);
                        break;

                    default:
                        Log.Write($"Unhandled Message", Color.Crimson);
                        break;
                }

                socket.Recycle(msg);
            }
        }
    }
}