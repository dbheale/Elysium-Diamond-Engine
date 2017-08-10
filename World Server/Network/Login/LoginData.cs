using System.Drawing;
using WorldServer.Server;
using Elysium.Logs;

namespace WorldServer.Network {
    public static class LoginData {
        /// <summary>
        /// Desconecta o usuário antigo para o novo entrar.
        /// </summary>
        /// <param name="username"></param>
        public static void UserDisconnect(int accountID) {
            var pData = Authentication.FindByAccountID(accountID);

            if (pData != null) {
                WorldPacket.Message(pData.Connection, (short)PacketList.Disconnect);
                pData.Connection.Disconnect(string.Empty);
                Log.Write($"Disconnected by login server: {pData.AccountID}", Color.Black);
            }
        }
    }
}