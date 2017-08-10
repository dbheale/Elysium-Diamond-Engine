using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using Lidgren.Network;
using WorldServer.Network;
using Elysium.Logs;

/* O servidor de login gera um código hexadecimal a partir da conexão; abreviado para hexID.
   Esse hexa é enviado para o cliente no momento da conexão com o servidor de login.
   Quando o usuário clica para conectar em algum servidor (world), o login server envia o hexID para o world server.

   O World recebendo o hexa pelo servidor de login, é adicionado na lista "HexID".

   Então, o cliente conecta ao servidor (world) e envia o hexadecimal que foi enviado pelo servidor de login.

   O método "ReceivedHexID" recebe o hex do cliente e altera o atual hexID pelo do cliente.

   O método "VerifyPlayerHexID" verifica se o hexID do jogador é igual com algum recebido pelo servidor de login.
   Se correto, chama o método "AcceptHexID" e copia todos os dados da lista "HexID" para o jogador.
   Então, carrega todos os dados do usuário.

   O hexID enviado pelo servidor de login é deletado depois de 10 segundos. Esse é o tempo necessário para a conexão com o cliente.
*/

namespace WorldServer.Server {
    public static partial class Authentication {
        private static List<PlayerData> playersremove = new List<PlayerData>();
        private static List<HexaID> hexsremove = new List<HexaID>();

        /// <summary>
        /// Lista de hexa ID recebido pelo login server.
        /// </summary>
        private static HashSet<HexaID> hexids = new HashSet<HexaID>();

        /// <summary>
        /// Lista de jogadores.
        /// </summary>
        private static HashSet<PlayerData> players = new HashSet<PlayerData>();

        /// <summary>
        /// Adiciona os dados recebido do login server.
        /// </summary>
        /// <param name="data"></param>
        public static void AddHexID(NetIncomingMessage data) {
            var hexID = new HexaID();

            hexID.HexID = data.ReadString();
            hexID.Account = data.ReadString();
            hexID.AccountID = data.ReadInt32();
            hexID.LanguageID = data.ReadByte();
            hexID.AccessLevel = data.ReadByte();
            hexID.Cash = data.ReadInt32();
            hexID.Pin = data.ReadString();
            hexID.PinAttempt = data.ReadByte();
            hexID.Time = Environment.TickCount;
            var service = data.ReadInt32();

            for (var n = 0; n < service; n++) hexID.Service.Add(data.ReadString());

            hexids.Add(hexID);

            Log.Write($"Received from login server ID: {hexID.AccountID} Account: {hexID.Account} {hexID.HexID}", Color.Black);
        }

        /// <summary>
        /// Recebe do cliente e altera o hexID.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="hexID"></param>
        public static void ReceivedHexID(NetConnection connection, string hexID)  {
            var pData = FindByConnection(connection);
            pData.HexID = hexID;

            Log.Write($"Received from client: {hexID}", Color.Black);
        }

        /// <summary>
        /// Copia a estrutura para a Player e remove da lista de HexID.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="hexIndex"></param>
        public static void AcceptHexID(NetConnection connection, HexaID hexID) {
            var pData = FindByConnection(connection);

            if (pData == null) { return; }

            pData.HexID = hexID.HexID;
            pData.AccountID = hexID.AccountID;
            pData.Account = hexID.Account;
            pData.LanguageID = hexID.LanguageID;
            pData.AccessLevel = hexID.AccessLevel;
            pData.Cash = hexID.Cash;
            pData.Pin = hexID.Pin;
            pData.PinAttempt = hexID.PinAttempt;
            pData.Service = hexID.Service;

            //adiciona o hexid na lista de exclusão
            hexsremove.Add(hexID);
        }

        /// <summary>
        /// Percorre todos os hexa IDS e verifica e aceita a conexão.
        /// </summary>
        public static void VerifyHexID() {
            //  HexaID hexID;
            PlayerData pData;

            foreach (var _hexID in hexids) {
                pData = FindByHexID(_hexID.HexID);

                if (pData == null) { continue; }

                AcceptHexID(pData.Connection, _hexID);

                Log.Write($"Player found ID: {pData.AccountID} Account: {pData.Account} {pData.HexID}", Color.Black);

                //inicia o processo de login
                PlayerLogin.Login(pData);
            }
        }

        /// <summary>
        /// Remove os jogadores.
        /// </summary>
        public static void RemoveInvalidUsersAndHexID() {
            //se algum dado estiver mais que 10 segundos no sistema, é removido da lista.
            foreach (var pData in players) {
                if (pData.AccountID == 0) {
                    if (Environment.TickCount >= (pData.Time + 10000)) {
                        pData.Connection?.Disconnect(string.Empty);
                        playersremove.Add(pData);
                    }
                }
            }

            //se algum dado estiver mais que 10 segundos no sistema, é removido da lista.
            //então, o jogador deve fazer um login
            foreach (var hexID in hexids) {
                if (Environment.TickCount > hexID.Time + 10000) {
                    Log.Write($"Removed HexID: {hexID.HexID} {hexID.Account}", Color.Coral);
                    hexsremove.Add(hexID);
                }
            }

            var count = playersremove.Count;
            for (var i = 0; i < count; i++) {
                players.Remove(playersremove[i]);
            }

            if (count > 0) playersremove.Clear();

            count = hexsremove.Count;
            for (var i = 0; i < count; i++) {
                hexids.Remove(hexsremove[i]);
            }

            if (count > 0) hexsremove.Clear();
        }

        /// <summary>
        /// Procura o HexID, retorna nulo caso falso.
        /// </summary>
        /// <param name="hexid"></param>
        /// <returns></returns>
        public static HexaID FindHexID(string hexID) {
            if (string.IsNullOrEmpty(hexID)) { return null; }

            var find_hexid = from hData in hexids
                             where hData.HexID.CompareTo(hexID) == 0
                             select hData;

            return find_hexid.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID de usuário.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PlayerData FindByAccountID(int accountID) {
            var find_id = from pData in players
                          where pData.AccountID.CompareTo(accountID) == 0
                          select pData;

            return find_id.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID do personagem.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PlayerData FindByCharacterID(int characterID) {
            var find_id = from pData in players
                          where pData.CharacterID.CompareTo(characterID) == 0
                          select pData;

            return find_id.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID do personagem.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static PlayerData FindByCharacterName(string characterName) {
            var find_id = from pData in players
                          where string.Compare(pData.CharacterName, characterName, true) == 0
                          select pData;

            return find_id.FirstOrDefault();
        }

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
        public static void Connect(NetIncomingMessage msg) {
            Log.Write($"Status changed to connected: {msg.SenderEndPoint.Address}", Color.Coral);
            players.Add(new PlayerData(msg.SenderConnection, string.Empty, msg.SenderEndPoint.Address.ToString()));
            WorldPacket.NeedHexID(msg.SenderConnection);
        }

        /// <summary>
        /// Remove o jogador da lista quando é desconectado.
        /// </summary>
        /// <param name="pData"></param>
        public static void Disconnect(PlayerData pData) {
            if (pData != null) {
                Log.Write($"Status changed to disconnected: {pData.AccountID} {pData.Account} {pData.IP} {pData.HexID}", Color.Coral);

                //atualiza as informações na DB pelo login server. 
                LoginPacket.UpdateUserDisconnect(pData.AccountID, pData.Account, pData.IP);
            }

            playersremove.Add(pData);
        }

        /// <summary>
        /// Limpa todos os dados.
        /// </summary>
        public static void Clear() {
            hexids.Clear();
            players.Clear();
        }
    }
}