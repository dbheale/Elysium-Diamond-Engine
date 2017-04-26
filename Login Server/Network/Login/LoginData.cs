using LoginServer.MySQL;
using LoginServer.Common;
using LoginServer.Server;
using Lidgren.Network;

namespace LoginServer.Network {
    public static class LoginData {
        /// <summary>
        /// Analisa o cabeçalho e processa a mensagem.
        /// </summary>
        /// <param name="hexID"></param>
        /// <param name="msg"></param>
        public static void HandleData(string hexID, NetIncomingMessage msg) {
            //se algum pacote estiver com menos que 4 bytes, retorna
            if (msg.LengthBytes < 4) { return; }

            var header = msg.ReadInt32();

            switch (header) {
                case (int)PacketList.CL_LS_Login: Authentication.Login(hexID, msg); break;
                case (int)PacketList.CL_LS_BackToLogin: Authentication.BackToLoginScreen(hexID); break;
                case (int)PacketList.CL_LS_WorldServerConnect: WorldPacket.PlayerLogin(hexID, msg.ReadInt32()); break;
            }
        }
    }
}
