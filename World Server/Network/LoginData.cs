using WorldServer.Server;
using WorldServer.Common;
using Lidgren.Network;
using Elysium;

namespace WorldServer.Network {
    public static class LoginData {
        /// <summary>
        /// Recebe o ID do servidor de login.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void ReceiveConnectionID(NetConnection connection, int msg) {
            var pData = Authentication.FindByConnection(connection);
            pData.AccountID = msg;
            Configuration.LoginID = msg;
            Logs.Write($"Login Server ID: {msg}", System.Drawing.Color.DarkMagenta);
        }

        /// <summary>
        /// Verifica se o usuário já está conectado no world.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static void IsUserConnected(NetConnection connection, string username) {
            LoginPacket.ConnectedResult(connection, Authentication.IsConnected(username), username);
        }

        /// <summary>
        /// Desconecta o usuário antigo para o novo entrar.
        /// </summary>
        /// <param name="username"></param>
        public static void UserDisconnect(string username) {
            if (!Authentication.IsConnected(username)) { return; }

            var pData = Authentication.FindByAccount(username);

            WorldPacket.Message(pData?.HexID, (short)PacketList.Disconnect);

            pData?.Connection.Disconnect("");

            Logs.Write($"Disconnected by login server: {username}", System.Drawing.Color.Black);
        }
    }
}
