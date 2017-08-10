using WorldServer.Server;

namespace WorldServer.Network {
    public static class GamePacket {
        /// <summary>
        /// Envia todos os dados para o gameserver.
        /// </summary>
        /// <param name="pIndex"></param>
        /// <param name="worldID"></param>
        public static void Login(PlayerData pData, int regionID) {
            var buffer = NetworkClient.CreateMessage();
            buffer.Write((short)PacketList.WS_GS_UserLogin);
            buffer.Write(pData.HexID);
            buffer.Write(pData.Account);
            buffer.Write(pData.AccountID);
            buffer.Write(pData.LanguageID);
            buffer.Write(pData.AccessLevel);
            buffer.Write(pData.CharacterID);
            buffer.Write(pData.CharSlot);
            buffer.Write(regionID);

            //pega a quantidade de serviços
            var servicesID = pData.Service.GetServicesID();
            buffer.Write(servicesID.Length);

            //escreve cada um no buffer
            foreach(var id in servicesID) buffer.Write(pData.Service.GetService(id));

            NetworkClient.SendData(buffer);
        }
    }
}