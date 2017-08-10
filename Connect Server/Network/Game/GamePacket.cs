using System.Drawing;
using ConnectServer.Server;
using Lidgren.Network;
using Elysium.Logs;

namespace ConnectServer.Network {
    /// <summary>
    /// Dados que são enviados ao game server.
    /// </summary>
    public static class GamePacket {
        public static void Login(PlayerData pData) {
            var buffer = NetworServer.CreateMessage();
            buffer.Write((short)PacketList.WS_GS_UserLogin);
            buffer.Write(pData.HexID);
            buffer.Write(pData.Account);
            buffer.Write(pData.AccountID);
            buffer.Write(pData.LanguageID);
            buffer.Write(pData.AccessLevel);
            buffer.Write(pData.CharacterID);
            buffer.Write(pData.CharSlot);

            //pega a quantidade de serviços
            var servicesID = pData.Service.GetServicesID();
            buffer.Write(servicesID.Length);

            //escreve cada um no buffer
            foreach (var id in servicesID) buffer.Write(pData.Service.GetService(id));

            var channel = AutoBalance.FindChannelByRegionID(pData.RegionID);
            if (channel == null) {
                Log.Write($"Failed to find channel region {pData.RegionID}", Color.Red);
                return;
            }

            var sData = Authentication.FindByID(channel.ServerID);
            if (sData == null) {
                Log.Write($"Failed to find server id {channel.ServerID}", Color.Red);
                return;
            }

            NetworServer.SendDataTo(sData.Connection, buffer, NetDeliveryMethod.ReliableOrdered);

            Log.Write($"{sData.Name} {sData.ID} login attempt: {pData.Account}", Color.Black);
        }
    }
}