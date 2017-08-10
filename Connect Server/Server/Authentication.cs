using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Lidgren.Network;
using Elysium.Logs;

namespace ConnectServer.Server {
    public static class Authentication {
        // lista de clientes para removação
        private static List<Client> remove_clients = new List<Client>();
        // lista de clientes
        private static HashSet<Client> clients = new HashSet<Client>();
        // lista de usuários conectados
        private static HashSet<UserData> accounts = new HashSet<UserData>();

        /// <summary>
        /// Remove todos os clientes desconectados.
        /// </summary>
        public static void RemoveClients() {
            var count = remove_clients.Count;

            for (var n = 0; n < count; n++) {
                clients.Remove(remove_clients[n]);
            }

            if (count > 0) {
                remove_clients.Clear();
            }
        }

        /// <summary>
        /// Adiciona um novo usuário à lista de conectados.
        /// </summary>
        /// <param name="account"></param>
        public static void AddAccount(int accountID, string account, int worldID) {
            var find_user = FindUserByID(accountID);

            if (find_user == null) {
                var user = new UserData(accountID, account, worldID, 0);
                accounts.Add(user);

                Log.Write($"added {user.Account}", Color.Black);
            }    
        }

        /// <summary>
        /// Remove um usuário da lista de conectados.
        /// </summary>
        /// <param name="account"></param>
        public static void RemoveAccount(int accountID) {
            var user = FindUserByID(accountID);
               
            if (user?.AccountID > 0) {
                accounts.Remove(user);

                Log.Write($"removed {user.Account}", Color.Black);
            }            
        }

        /// <summary>
        /// Realiza a busca do servidor pelo ID.
        /// </summary>
        /// <param name="serverID"></param>
        /// <returns></returns>
        public static Client FindByID(int serverID) {
            var find_client = from client in clients
                          where client.ID == serverID
                          select client;

            return find_client.FirstOrDefault();
        }

        /// <summary>
        /// Realiza a busca do servidor pela conexão.
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public static Client FindByConnection(NetConnection connection) {
            var find_client = from client in clients
                              where client.Connection.Equals(connection)
                              select client;

            return find_client.FirstOrDefault();
        }

        /// <summary>
        /// Realiza a busca do servidor pelo nome.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Client FindByName(string name) {
            var find_client = from client in clients
                              where string.Compare(client.Name, name, false) == 0
                              select client;

            return find_client.FirstOrDefault();
        }

        /// <summary>
        /// Realiza a busca do usuário pelo ID.
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns></returns>
        public static UserData FindUserByID(int accountID) {
            var find_user = from user in accounts
                              where user.AccountID.CompareTo(accountID) == 0
                              select user;

            return find_user.FirstOrDefault();
        }

        /// <summary>
        /// Realiza a busca pelo nome de usuário.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static UserData FindUserByAccount(string account) {
            var find_user = from user in accounts
                            where string.Compare(user.Account, account, true) == 0
                            select user;

            return find_user.FirstOrDefault();
        }

        /// <summary>
        /// Adiciona um novo cliente quando a conexão é iniciada.
        /// </summary>
        /// <param name="msg"></param>
        public static void ConnectClient(NetIncomingMessage msg) {
            clients.Add(new Client(msg.SenderConnection));
      
            Log.Write($"Connected {msg.SenderEndPoint.Address}", Color.Coral);
        }

        /// <summary>
        /// Remove o cliente da lista quando é desconectado.
        /// </summary>
        /// <param name="pData"></param>
        public static void DisconnectClient(NetIncomingMessage msg) {
            var client = FindByConnection(msg.SenderConnection);

            if (client != null) {
                Log.Write($"Disconnected {client.ID} {client.Name} {client.HexID}", Color.Coral);

                //altera para desconectado
                AutoBalance.ChangeChannelStatus(client.ID, false);
            }       

            remove_clients.Add(client);
        }
    }
}