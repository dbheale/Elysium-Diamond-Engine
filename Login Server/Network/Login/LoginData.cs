using LoginServer.Server;
using Lidgren.Network;

namespace LoginServer.Network {
    public static class LoginData {
        /// <summary>
        /// Analisa o cabeçalho e processa a mensagem.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="msg"></param>
        public static void HandleData(NetIncomingMessage msg) {
            if (msg.LengthBytes < 2) { return; }

            var header = msg.ReadInt16();

            var pData = Authentication.FindByConnection(msg.SenderConnection);

            switch (header) {
                case (short)PacketList.CL_LS_Login: Authentication.Login(pData, msg); break;
                case (short)PacketList.CL_LS_BackToLogin: Authentication.BackToLoginScreen(pData); break;
                case (short)PacketList.CL_LS_WorldServerConnect: ConnectPacket.PlayerLogin(pData, msg.ReadInt32()); break;
            }
        }
    }
}