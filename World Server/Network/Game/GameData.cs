using WorldServer.Server;
using Lidgren.Network;

namespace WorldServer.Network {
    public static class GameData {
        public static void HandleData(int index, NetIncomingMessage msg) {
            if (msg.LengthBytes < 2) { return; }

            var header = msg.ReadInt16();

            if (header < 0) { return; }

            switch (header) {
                case (short)PacketList.None: break;
                case (short)PacketList.GS_WS_UpdateUserStatus: UpdateUserStatus(msg.ReadInt32()); break;
            }
        }
        /// <summary>
        /// Indica que o usuario conectou ao game server e carrega os dados.
        /// </summary>
        /// <param name="msg"></param>
        public static void UpdateUserStatus(int accountID) {
            var pData = Authentication.FindByAccountID(accountID);
            pData.IsGameConnected = true;

            PlayerLogin.EnterGame(pData);
        }
    }
}