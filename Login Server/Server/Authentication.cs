using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using Lidgren.Network;
using LoginServer.MySQL;
using Elysium;

namespace LoginServer.Server {
    public static partial class Authentication {
        /// <summary>
        /// Lista de usuários.
        /// </summary>
        private static HashSet<PlayerData> player = new HashSet<PlayerData>();

        /// <summary>
        /// Realiza uma busca pelo ID de conexão.
        /// </summary>
        /// <param name="hexID"></param>
        /// <returns></returns>
        public static PlayerData FindByHexID(string hexID) {
            var find_hexID = from pData in player
                             where pData.HexID.CompareTo(hexID) == 0
                             select pData;

            return find_hexID.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo nome de usuário.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static PlayerData FindByAccount(string account) {
             var find_account = from pData in player
                               where string.Compare(pData.Account, account, true) == 0
                               select pData;

            return find_account.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo usuário no campo 'temporário'.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static PlayerData FindByUsername(string username) {
            var find_account = from pData in player
                               where string.Compare(pData.Username, username, true) == 0
                               select pData;

            return find_account.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pela conexão.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static PlayerData FindByConnection(NetConnection connection) {
            if (Equals(null, connection)) { return null; }

            var find_connection = from pData in player
                                  where pData.Connection.Equals(connection)
                                  select pData;

            return find_connection.FirstOrDefault();
        }

        /// <summary>
        /// Verifica se o usuário já está conectado.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static bool IsConnected(string account) {
            var find_account = from pData in player
                               where string.Compare(pData.Account, account, true) == 0
                               select pData;

            return (find_account.FirstOrDefault() == null) ? false : true;
        }

        /// <summary>
        /// Adiciona um novo jogador quando a conexão é iniciada.
        /// </summary>
        /// <param name="msg"></param>
        public static void Connect(NetIncomingMessage msg) {
            player.Add(new PlayerData(msg.SenderConnection, NetUtility.ToHexString(msg.SenderConnection.RemoteUniqueIdentifier), msg.SenderEndPoint.Address.ToString()));
            Logs.Write($"Status changed to connected: {msg.SenderEndPoint.Address}", Color.Coral);
        }

        /// <summary>
        /// Remove o jogador da lista quando é desconectado.
        /// </summary>
        /// <param name="pData"></param>
        public static void Disconnect(PlayerData pData) {
            Logs.Write($"Status changed to disconnected: {pData.ID} {pData.Account} {pData.IP} {pData.HexID}", Color.Coral);

            Accounts_DB.UpdateLastIP(pData.Account, pData.IP);
            Accounts_DB.UpdateLoggedIn(pData.Account, 0); //0 disconnected
            Accounts_DB.UpdateCurrentIP(pData.Account, string.Empty); //limpa o ip atual

            player.Remove(pData);
        }

        /// <summary>
        /// Limpa os dados e libera a memoria.
        /// </summary>
        public static void Clear() {
            player.Clear();
            player = null;
        }

    }
}
