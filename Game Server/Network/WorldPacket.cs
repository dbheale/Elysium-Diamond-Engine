using GameServer.Server;
using GameServer.Common;
using Lidgren.Network;

namespace GameServer.Network {
    public static class WorldPacket {
        /// <summary>
        /// Envia a mensagem, confirmar a conexão do usuário.
        /// </summary>
        /// <param name="accountID"></param>
        public static void UpdateUserConnected(int accountID) {
            var pData = Authentication.FindByAccountID(Configuration.WorldID);

            if (pData == null) return;

            var buffer = GameNetwork.CreateMessage(6);
            buffer.Write((short)PacketList.GS_WS_UpdateUserStatus);
            buffer.Write(accountID);
            GameNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }

        /// <summary>
        /// Envia a quantidade de conexões.
        /// </summary>
        public static void UpdateUserCount() {
            var pData = Authentication.FindByAccountID(Configuration.WorldID);

            if (pData == null) return;
            
            var buffer = GameNetwork.CreateMessage(6);
            buffer.Write((short)PacketList.GS_WS_UpdateUserCount);
            buffer.Write(GameNetwork.ConnectionsCount);
            GameNetwork.SendDataTo(pData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);
        }
    }
}