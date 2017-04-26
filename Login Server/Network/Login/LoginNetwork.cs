using System.Drawing;
using Lidgren.Network;
using LoginServer.Common;
using LoginServer.Server;
using LoginServer.MySQL;
using Elysium;

namespace LoginServer.Network {
    public static class LoginNetwork {
        /// <summary>
        /// Socket de conexão.
        /// </summary>
        private static NetServer socket;

        /// <summary>
        /// Recebe as mensagens.
        /// </summary>
        private static NetIncomingMessage msg;

        /// <summary>
        /// 
        /// </summary>
        private static PlayerData pData;

        /// <summary>
        /// Inicia e prepara a conexão.
        /// </summary>
        public static void InitializeServer() {
            var config = new NetPeerConfiguration(Configuration.Discovery);
            config.Port = Configuration.LoginServerPort;
            config.AutoFlushSendQueue = true;
            config.AcceptIncomingConnections = true;
            config.MaximumConnections = Configuration.MaximumConnections;
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
        /// Recebe os dados dos clientes.
        /// </summary>
        public static void ReceivedData() {
            while ((msg = socket.ReadMessage()) != null) {

                pData = Authentication.FindByConnection(msg.SenderConnection);

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
                                    Logs.Write($"Banned country trying to connect: {ip} {country.Country}-{country.Code}", Color.Coral);
                                    return;
                               }    
                            }
                            else {
                                return;
                            }
                        }

                        #endregion

                        #region Find Banned IP
                        if (Accounts_DB.IsBannedIp(msg.SenderEndPoint.Address.ToString()) == true) {
                            Logs.Write("Warning: Attempted IP Banned " + msg.SenderEndPoint.Address, Color.Coral);
                            return;
                        }
                        #endregion

                        LoginNetwork.socket.SendDiscoveryResponse(null, msg.SenderEndPoint);
                        Logs.Write($"Discovery Response IPEndPoint: {msg.SenderEndPoint.Address}", Color.Coral); 
                        break;

                    case NetIncomingMessageType.ErrorMessage:
                        Logs.Write($"Error: {msg.ReadString()}", Color.Coral);
                        break;
  
                    case NetIncomingMessageType.StatusChanged:
                        #region Status Changed Connected
                        var status = (NetConnectionStatus)msg.ReadByte();
                        if (status == NetConnectionStatus.Connected) {
                            Authentication.Connect(msg);                     
                        }
                        #endregion

                        #region Status Changed Disconnected
                        if (status == NetConnectionStatus.Disconnected) {
                            if (pData != null) Authentication.Disconnect(pData);
                        }
                        #endregion
                        break;

                    case NetIncomingMessageType.Data:
                        LoginData.HandleData(pData.HexID, msg);
                        break;

                    default:
                        //Registra qualquer mensagem invalida
                        Logs.Write($"Unhandled type: {msg.MessageType}", Color.DarkRed);
                        break;
                }

                LoginNetwork.socket.Recycle(msg);
            }
        }
        
        /// <summary>
        /// Verifica o estado da conexão pela conexão de usuário.
        /// </summary>
        /// <param name="pData"></param>
        /// <returns></returns>
        public static bool Connected(ref PlayerData pData) {
            return (pData.Connection.Status == NetConnectionStatus.Connected) ? true : false;
        }

        /// <summary>
        /// Verifica se o estado da conexão pelo HexaID.
        /// </summary>
        /// <param name="hexID"></param>
        /// <returns></returns>
        public static bool Connected(string hexID) {
            return (Authentication.FindByHexID(hexID).Connection.Status == NetConnectionStatus.Connected) ? true : false;
        }

        /// <summary>
        /// Envia dados para determinada conexão.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="msg"></param>
        /// <param name="deliveryMethod"></param>
        public static void SendDataTo(string hexID, NetOutgoingMessage msg, NetDeliveryMethod deliveryMethod) {
            socket.SendMessage(msg, Authentication.FindByHexID(hexID).Connection, deliveryMethod);
        }
    }
}