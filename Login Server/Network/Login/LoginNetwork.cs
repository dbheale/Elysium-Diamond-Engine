using System.Drawing;
using Lidgren.Network;
using LoginServer.Common;
using LoginServer.Server;
using LoginServer.Database;
using Elysium.Logs;

namespace LoginServer.Network {
    public static class LoginNetwork {
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
                NetIncomingMessageType.WarningMessage) ;
    
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
        }

        /// <summary>
        /// Processa os dados recebidos.
        /// </summary>
        public static void ReceivedData() {
            while ((msg = socket.ReadMessage()) != null) {

                switch (msg.MessageType) {
                    case NetIncomingMessageType.DiscoveryRequest:

                        #region Find Banned Country
                        var ip = msg.SenderEndPoint.Address.ToString();

                        if (GeoIp.Enabled) {

                            //Verifica se o ip já está bloqueado temporariamente (evitar processamento desnecessario)
                            if (!GeoIp.IsIpBlocked(ip)) {

                                //verifica se o ip do país está na lista de bloqueados.
                                if (GeoIp.IsCountryIpBlocked(ip)) {
                                    var country = GeoIp.FindCountryByIp(ip);

                                    //adiciona na lista de bloqueados temporariamente
                                    GeoIp.AddIpAddress(ip);
                                    Log.Write($"Banned country trying to connect: {ip} {country.Country}-{country.Code}", Color.Coral);
                                    return;
                               }    
                            }
                            else {
                                return;
                            }
                        }

                        #endregion

                        #region Find Banned IP
                        if (AccountDB.IsBannedIp(msg.SenderEndPoint.Address.ToString()) == true) {
                            Log.Write("Warning: Attempted IP Banned " + msg.SenderEndPoint.Address, Color.Coral);
                            return;
                        }
                        #endregion

                        LoginNetwork.socket.SendDiscoveryResponse(null, msg.SenderEndPoint);
                        Log.Write($"Discovery Response IPEndPoint: {msg.SenderEndPoint.Address}", Color.Coral); 

                        break;

                    case NetIncomingMessageType.ErrorMessage:
                        Log.Write($"Error: {msg.ReadString()}", Color.Coral);
                        break;
  
                    case NetIncomingMessageType.StatusChanged:
                        var status = (NetConnectionStatus)msg.ReadByte();

                        #region Connect
                        if (status == NetConnectionStatus.Connected) {
                            Authentication.ConnectPlayer(msg);                     
                        }
                        #endregion

                        #region Disconnect
                        if (status == NetConnectionStatus.Disconnected) {
                            Authentication.DisconnectPlayer(msg);
                        }
                        #endregion
                        break;

                    case NetIncomingMessageType.Data:
                        LoginData.HandleData(msg);
                        break;

                    default:
                        //Registra qualquer mensagem invalida
                        Log.Write($"Unhandled type: {msg.MessageType}", Color.DarkRed);
                        break;
                }

                socket.Recycle(msg);
            }
        }
        
        /// <summary>
        /// Verifica se o estado da conexão pelo HexaID.
        /// </summary>
        /// <param name="hexID"></param>
        /// <returns></returns>
        public static bool Connected(NetConnection connection) {
            return (connection.Status == NetConnectionStatus.Connected) ? true : false;
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
    }
}