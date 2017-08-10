using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using Lidgren.Network;
using LoginServer.Database;
using Elysium.Logs;

namespace LoginServer.Server {
    public static partial class Authentication {
        /// <summary>
        /// Lista de usuários.
        /// </summary>
        private static HashSet<PlayerData> players = new HashSet<PlayerData>();

        /// <summary>
        /// Realiza uma busca pelo ID de conexão.
        /// </summary>
        /// <param name="hexID"></param>
        /// <returns></returns>
        public static PlayerData FindByHexID(string hexID) {
            var find_hexID = from pData in players
                             where pData.HexID.CompareTo(hexID) == 0
                             select pData;

            return find_hexID.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID de usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PlayerData FindByAccountID(int accountID) {
            var find_id = from pData in players
                          where pData.ID.CompareTo(accountID) == 0
                          select pData;

            return find_id.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo nome de usuário.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static PlayerData FindByAccount(string account) {
             var find_account = from pData in players
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
            var find_account = from pData in players
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

            var find_connection = from pData in players
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
            var find_account = from pData in players
                               where string.Compare(pData.Account, account, true) == 0
                               select pData;

            return (find_account.FirstOrDefault() == null) ? false : true;
        }

        /// <summary>
        /// Adiciona um novo jogador quando a conexão é iniciada.
        /// </summary>
        /// <param name="msg"></param>
        public static void ConnectPlayer(NetIncomingMessage msg) {
            players.Add(new PlayerData(msg.SenderConnection, NetUtility.ToHexString(msg.SenderConnection.RemoteUniqueIdentifier), msg.SenderEndPoint.Address.ToString()));
            Log.Write($"Status changed to connected: {msg.SenderEndPoint.Address}", Color.Coral);
        }

        /// <summary>
        /// Remove o jogador da lista quando é desconectado.
        /// </summary>
        /// <param name="pData"></param>
        public static void DisconnectPlayer(NetIncomingMessage msg) {
            var pData = FindByConnection(msg.SenderConnection);

            Log.Write($"Status changed to disconnected: {pData.ID} {pData.Account} {pData.IP} {pData.HexID}", Color.Coral);

            //se não conectado ao world server, salva as informações
            if (!pData.IsWorldConnected) {
                AccountDB.UpdateLoggedIn(pData.ID, 0); //0 disconnected
                AccountDB.UpdateLastIP(pData.ID, pData.IP);
                AccountDB.UpdateCurrentIP(pData.ID, string.Empty); //limpa o ip atual
            }

            players.Remove(pData);
        } 

        /// <summary>
        /// Limpa os dados e libera a memoria.
        /// </summary>
        public static void Clear() {
            players.Clear();
            players = null;
        }
    }
}