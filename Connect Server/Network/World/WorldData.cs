using System.Drawing;
using ConnectServer.Server;
using Lidgren.Network;
using Elysium.Logs;

namespace ConnectServer.Network {
    /// <summary>
    /// Dados que são recebidos pelo world server enviados de outros servidores.
    /// </summary>
    public static class WorldData {
        /// <summary>
        /// Recebe os dados do usuário e direciona para o servidor escolhido.
        /// </summary>
        /// <param name="msg"></param>
        public static void ReceivePlayerData(NetIncomingMessage msg) {
            var pData = new PlayerData();

            pData.HexID = msg.ReadString();
            pData.Account = msg.ReadString();
            pData.AccountID = msg.ReadInt32();
            pData.LanguageID = msg.ReadByte();
            pData.AccessLevel = msg.ReadByte();
            pData.CharacterID = msg.ReadInt32();
            pData.CharSlot = msg.ReadInt32();
            pData.RegionID = msg.ReadInt32();

            //pega a quantidade de serviços
            var lenght = msg.ReadInt32();

            for (var n = 0; n < lenght; n++) {
                pData.Service.Add(msg.ReadString());
            }

            Log.Write($"Data from world server account: {pData.Account} {pData.HexID}", Color.Black);

            GamePacket.Login(pData);
        }

        /// <summary>
        /// Indica que o usuário se conectou ao game server.
        /// </summary>
        /// <param name="msg"></param>
        public static void UpdatePlayerStatus(NetIncomingMessage msg) {
            var accountID = msg.ReadInt32();
            var gameID = msg.ReadInt32();

            var pData = Authentication.FindUserByID(accountID);
            if (pData == null) {
                Log.Write($"Failed to find user id {accountID}", Color.Red);
                return;
            }

            //atualiza a informação do usuário
            pData.GameID = gameID;

            var sData = Authentication.FindByID(pData.WorldID);
            if (sData == null) {
                Log.Write($"Failed to find world id {pData.WorldID}", Color.Red);
                return;
            }

            WorldPacket.UpdatePlayerStatus(sData.Connection, accountID);         
        }
    }
}