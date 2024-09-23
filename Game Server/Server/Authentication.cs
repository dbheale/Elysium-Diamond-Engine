using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using GameServer.Network;
using GameServer.Maps;
using GameServer.MySQL;
using GameServer.Player;
using Lidgren.Network;
using Elysium.Logs;
using Org.BouncyCastle.Utilities;

namespace GameServer.Server {
    public static class Authentication {
        private static List<PlayerData> playersremove = new List<PlayerData>();
        private static List<HexaID> hexsremove = new List<HexaID>();

        /// <summary>
        /// HexID recebido pelo login server.
        /// </summary>
        private static HashSet<HexaID> hexid = new HashSet<HexaID>();

        /// <summary>
        /// Conexões e jogadores.
        /// </summary>
        private static HashSet<PlayerData> player = new HashSet<PlayerData>();

        /// <summary>
        /// Adiciona os dados recebido do login server.
        /// </summary>
        /// <param name="data"></param>
        public static void AddHexID(NetIncomingMessage data) {
            HexaID hexID = new HexaID();

            hexID.HexID = data.ReadString();
            hexID.Account = data.ReadString();
            hexID.AccountID = data.ReadInt32();
            hexID.LanguageID = data.ReadByte();
            hexID.AccessLevel = data.ReadByte();
            hexID.CharacterID = data.ReadInt32();
            hexID.CharSlot = data.ReadInt32();
            var service = data.ReadInt32();

            for (var n = 0; n < service; n++) hexID.Service.Add(data.ReadString());

            hexID.Time = Environment.TickCount;

            hexid.Add(hexID);

            Log.Write($"Data From World Server ID: {hexID.AccountID} Account: {hexID.Account} Char ID: {hexID.CharacterID} Slot: {hexID.CharSlot} {hexID.HexID}", Color.Black);
        }

        /// <summary>
        /// Recebe do cliente e altera o hexID.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="hexID"></param>
        public static void ReceiveHexID(NetConnection connection, string hexID) {
            PlayerData pData = FindByConnection(connection);
            pData.HexID = hexID;

            Log.Write($"Received From Client: {hexID}", Color.Black);
        }

        /// <summary>
        /// Copia a estrutura para a Player e remove da lista de HexID.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="hexIndex"></param>
        private static void AcceptHexID(NetConnection connection, HexaID hexID) {
            PlayerData pData = FindByConnection(connection);

            pData.HexID = hexID.HexID;
            pData.AccountID = hexID.AccountID;
            pData.Account = hexID.Account;
            pData.LanguageID = hexID.LanguageID;
            pData.AccessLevel = hexID.AccessLevel;
            pData.CharacterID = hexID.CharacterID;
            pData.CharacterSlot = hexID.CharSlot;
            pData.Service = hexID.Service;

            hexid.Remove(hexID);
        }

        /// <summary>
        /// Percorre todos os jogadores e verifica o estado atual do HexID.
        /// </summary>
        public static void VerifyPlayerHexID() {
            HexaID hexID;

            foreach (PlayerData pData in player) {
                if (pData.AccountID != 0) { continue; }
                if (pData.HexID.Length == 0) { continue; }

                hexID = FindHexID(pData.HexID);
                
                //Se não encontrar o hexid, desconecta o usuário pelo cliente
                if (hexID == null) {
                    GamePacket.Message(pData.Connection, (short)PacketList.Disconnect);
                    continue;
                }
              
                //aceita a conexão
                AcceptHexID(pData.Connection, hexID);

                //Carrega os dados do personagem.
                PlayerLogin.Login(pData);

                //Muda de janela
                GamePacket.GameState(pData.HexID, 6);
            }
        }

        /// <summary>
        /// Remove os jogadores.
        /// </summary>
        public static void RemoveInvalidUsersAndHexID() {
            //se algum dado estiver mais que 10 segundos no sistema, é removido da lista.
            foreach (var pData in player) {
                if (pData?.AccountID == 0) {
                    if (Environment.TickCount >= (pData.Time + 10000)) {
                        pData.Connection?.Disconnect("");
                        playersremove.Add(pData);
                    }
                }
            }

            //se algum dado estiver mais que 10 segundos no sistema, é removido da lista.
            //então, o jogador deve fazer um login
            foreach (var hexID in hexid) {
                if (Equals(null, hexID)) { continue; }

                if (Environment.TickCount > hexID.Time + 10000) {
                    Log.Write($"Removed HexID: {hexID.HexID} {hexID.Account}", Color.Coral);
                    hexsremove.Add(hexID);
                }
            }

            var count = playersremove.Count;
            for (var i = 0; i < count; i++) {
                player.Remove(playersremove[i]);
            }

            if (count > 0) playersremove.Clear();

            count = hexsremove.Count;
            for (var i = 0; i < count; i++) {
                hexid.Remove(hexsremove[i]);
            }

            if (count > 0) hexsremove.Clear();
        }

        /// <summary>
        /// Procura o HexID, se não encontrar, retorna -1.
        /// </summary>
        /// <param name="hexid"></param>
        /// <returns></returns>
        private static HexaID FindHexID(string hexID) {
            if (string.IsNullOrEmpty(hexID)) { return null; }

            var find_hexid = from hData in hexid
                             where hData.HexID.CompareTo(hexID) == 0
                             select hData;

            return find_hexid.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID de usuário.
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public static PlayerData FindByAccountID(int pID) {
            var find_id = from pData in player
                          where pData.AccountID.CompareTo(pID) == 0
                          select pData;

            return find_id.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID de usuário.
        /// </summary>
        /// <param name="cID"></param>
        /// <returns></returns>
        public static PlayerData FindByCharacterID(int cID) {
            var find_id = from pData in player
                          where pData.CharacterID.CompareTo(cID) == 0
                          select pData;

            return find_id.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo nome do personagem.
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public static PlayerData FindByCharacterName(string charName) {
            if (string.IsNullOrEmpty(charName)) { return null; }

            var find_id = from pData in player
                          where string.Compare(pData.CharacterName, charName, true) == 0 
                          select pData;

            return find_id.FirstOrDefault();
        }

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
                               where pData.Account.CompareTo(account) == 0
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
        /// Adiciona um novo jogador quando a conexão é iniciada.
        /// </summary>
        /// <param name="msg"></param>
        public static void Connect(NetIncomingMessage msg) {
            Log.Write($"Status changed to connected: {msg.SenderEndPoint}", Color.Coral);
            player.Add(new PlayerData(msg.SenderConnection, string.Empty, msg.SenderEndPoint.Address.ToString()));
            GamePacket.NeedHexID(msg.SenderConnection);
            WorldPacket.UpdateUserCount();
        }

        /// <summary>
        /// Remove o jogador da lista quando é desconectado.
        /// </summary>
        /// <param name="pData"></param>
        public static void Disconnect(PlayerData pData) {           
            if (pData.CharacterID > 0) {
                MapManager.FindMapByID(pData.WorldID).RemovePlayer(pData.CharacterID);

                Log.Write($"ID: {pData?.CharacterID} {pData?.CharacterName} status changed to disconnected: " + pData.IP, Color.Coral);

                Character_DB.SaveData(pData);
                Character_DB.SaveEquippedItems(pData);
                Character_DB.SaveInventory(pData);
            }
            else if (pData.AccountID < 0) {
                Log.Write($"World ID: {pData.AccountID} {pData.HexID} status changed to disconnected: {pData.IP}", Color.Coral);
            }

            playersremove.Add(pData);
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

            return find_account.FirstOrDefault() == null ? false : true;
        }
    }
}