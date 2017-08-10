using System.Drawing;
using Lidgren.Network;
using ConnectServer.Server;
using Elysium.Logs;

namespace ConnectServer.Network {
    /// <summary>
    /// Dados que são enviados para o world server.
    /// </summary>
    public static class WorldPacket {
        /// <summary>
        /// Envia todos os dados do usuário para o world server que foi selecionado pelo cliente.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="worldID"></param>
        public static void PlayerLogin(PlayerData pData, int worldID) {
            var buffer = NetworServer.CreateMessage();
            buffer.Write((short)PacketList.LS_WS_PlayerLogin);
            buffer.Write(pData.HexID);
            buffer.Write(pData.Account);
            buffer.Write(pData.AccountID);
            buffer.Write(pData.LanguageID);
            buffer.Write(pData.AccessLevel);
            buffer.Write(pData.Cash);
            buffer.Write(pData.Pin);
            buffer.Write(pData.PinAttempt);

            //escreve a quantidade de serviços
            int[] servicesID = pData.Service.GetServicesID();
            buffer.Write(pData.Service.Count());

            //escreve cada serviço no buffer
            foreach (var id in servicesID) {
                buffer.Write(pData.Service.GetService(id));
            }

            var sData = Authentication.FindByID(worldID);

            if (sData == null) {
                return;
            }

            NetworServer.SendDataTo(sData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);

            Log.Write($"{sData.Name} {sData.ID} login lttempt: {pData.Account}", Color.Black);
        }

        /// <summary>
        /// Envia os dados do game server para o usuário.
        /// </summary>
        /// <param name="accountID"></param>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        public static void SelectedPlayerRegion(NetConnection connection, int accountID, string ip, int port) {
            var buffer = NetworServer.CreateMessage();
            buffer.Write((short)PacketList.CS_SelectServer);
            buffer.Write(accountID);
            buffer.Write(ip);
            buffer.Write(port);

            NetworServer.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Indica que o usuário se conectou ao game server.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="accountID"></param>
        public static void UpdatePlayerStatus(NetConnection connection, int accountID) {
            var buffer = NetworServer.CreateMessage(6);
            buffer.Write((short)PacketList.GS_WS_UpdateUserStatus);
            buffer.Write(accountID);

            NetworServer.SendDataTo(connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}