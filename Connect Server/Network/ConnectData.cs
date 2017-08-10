using System.Drawing;
using Lidgren.Network;
using ConnectServer.Server;
using Elysium.Logs;

namespace ConnectServer.Network {
    public static class ConnectData {
        /// <summary>
        /// Analisa o cabeçalho e processa a mensagem.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="msg"></param>
        public static void Handle(NetIncomingMessage msg) {
            if (msg.LengthBytes < 2) { return; }

            var header = msg.ReadInt16();
            
            switch (header) {
                // login packet
                case (short)PacketList.CS_ServerID: ReceiveServerID(msg); break;
                case (short)PacketList.LS_WS_PlayerLogin: LoginData.ReceivePlayerData(msg); break;
                case (short)PacketList.LS_WS_IsPlayerConnected: LoginData.IsUserConnected(msg); break;
                case (short)PacketList.CS_DisconnectPlayer: LoginData.DisconnectPlayer(msg); break;
                case (short)PacketList.CS_SelectServer: SelectPlayerRegion(msg); break;

                // world packet
                case (short)PacketList.WS_LS_UpdatePin: LoginData.UpdateUserPin(msg); break;
                case (short)PacketList.WS_LS_UpdatePinAttempt: LoginData.UpdateUserPinAttempt(msg); break;
                case (short)PacketList.WS_LS_UpdateBan: LoginData.UpdateUserBan(msg); break;
                case (short)PacketList.WS_LS_UpdateCash: LoginData.UpdateUserCash(msg); break;
                case (short)PacketList.WS_LS_UpdateDisconnect: LoginData.UpdateUserDisconnect(msg); break;
                case (short)PacketList.WS_LS_UpdateUserStatus: LoginData.UpdateUserStatus(msg); break;
                case (short)PacketList.WS_LS_InsertService: LoginData.InsertUserService(msg); break;
                case (short)PacketList.WS_GS_UserLogin: WorldData.ReceivePlayerData(msg); break;

                // game server
                case (short)PacketList.GS_WS_UpdateUserStatus: WorldData.UpdatePlayerStatus(msg); break;
            }
        }

        /// <summary>
        /// Recebe o ID do servidor.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void ReceiveServerID(NetIncomingMessage msg) {
            int id = msg.ReadInt32();
            string name = msg.ReadString();

            var sData = Authentication.FindByConnection(msg.SenderConnection);

            if (sData == null) {
                Log.Write($"Ocorreu um erro ao adicionar o servidor ID {id} {name}", Color.Red);
                return;
            }

            sData.ID = id;
            sData.Name = name;
            Log.Write($"{sData.Name} ID: {sData.ID} {sData.HexID}", Color.Green);
            
            //altera para conectado
            AutoBalance.ChangeChannelStatus(id, true);
        }

        /// <summary>
        /// Recebe o id de região e seleciona o canal.
        /// </summary>
        /// <param name="msg"></param>
        public static void SelectPlayerRegion(NetIncomingMessage msg) {
            var accountID = msg.ReadInt32();
            var regionID = msg.ReadInt32();
            var channel = AutoBalance.FindChannelByRegionID(regionID);

            WorldPacket.SelectedPlayerRegion(msg.SenderConnection, accountID, channel.IP, channel.Port);
        }
    }
}