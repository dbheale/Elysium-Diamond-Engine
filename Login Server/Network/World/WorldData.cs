using Lidgren.Network;
using LoginServer.Common;
using LoginServer.Server;

namespace LoginServer.Network {
    public static class WorldData {
        /// <summary>
        /// Analisa o cabeçalho e processa a mensagem.
        /// </summary>
        /// <param name="index">Número do Servidor</param>
        /// <param name="msg"></param>
        public static void HandleData(int index, NetIncomingMessage msg) {
            //se algum pacote estiver com menos que 4 bytes, retorna
            if (msg.LengthBytes < 4) return;
            // cabeçalho da msg
            var header = msg.ReadInt32();

            // chama o método
            switch (header) {
                case (int)PacketList.LS_WS_IsPlayerConnected: Authentication.Login(index, msg.ReadBoolean(), msg.ReadString()); break;
            }
        }
    }
}
