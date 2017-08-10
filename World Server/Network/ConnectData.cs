using Lidgren.Network;
using WorldServer.Server;

namespace WorldServer.Network {
    public static class ConnectData {
        /// <summary>
        /// Analisa o cabeçalho e processa a mensagem.
        /// </summary>
        /// <param name="msg"></param>
        public static void HandleData(NetIncomingMessage msg) {
            //se algum pacote estiver com menos que 2 bytes, sai do método
            if (msg.LengthBytes < 2) return;
            // cabeçalho da msg
            var header = msg.ReadInt16();

            // chama o método
            switch (header) {
                case (short)PacketList.LS_WS_PlayerLogin: Authentication.AddHexID(msg); break;
                case (short)PacketList.CS_DisconnectPlayer: LoginData.UserDisconnect(msg.ReadInt32()); break;
                case (short)PacketList.CS_SelectServer: PlayerLogin.StartGame(msg); break;
                case (short)PacketList.GS_WS_UpdateUserStatus: GameData.UpdateUserStatus(msg.ReadInt32()); break;
            }
        }
    }
}