using System.Drawing;
using GameServer.Network;
using GameServer.MySQL;
using GameServer.GameLogic;
using GameServer.Player;
using GameServer.Maps;
using Elysium.Logs;

namespace GameServer.Server {
    public static class PlayerLogin {
        /// <summary>
        /// Carrega as informações do jogador.
        /// </summary>
        /// <param name="pData"></param>
        public static void Login(PlayerData pData) {
            //pega o nome do personagem e verifica se há algum personagem conectado.
            var name = Character_DB.CharacterName(pData.AccountID, pData.CharacterSlot);
            var playerData = Authentication.FindByCharacterName(name);

            //se está conectado, salva e limpa os dados para uma nova conexão.
            if (playerData != null) {

                Character_DB.SaveData(playerData);

                Log.Write($"Player disconnected: {playerData.CharacterName} {pData.HexID}", Color.Peru);

                MapManager.FindMapByID(playerData.WorldID).RemovePlayer(pData.CharacterID);

                Authentication.Disconnect(playerData);
            }

            //carrega dados do personagem
            Character_DB.LoadData(pData.HexID, pData.CharacterSlot);
            Character_DB.LoadEquippedItem(pData);
            Character_DB.LoadInventory(pData);

            //Envia a mensagem, confirmar a conexão do usuário
            WorldPacket.UpdatePlayerStatus(pData.AccountID);

            Log.Write($"Player Found ID: {pData.CharacterID} Name: {pData.CharacterName}", Color.Black);

            //aceita a conexão
            GamePacket.Message(pData.Connection, (short)PacketList.AcceptedConnection);

            pData.SendPlayerBasicData();
            pData.SendPlayerWorldLocation();

            CharacterLogic.UpdateCharacterStats(pData);
            CharacterLogic.SendCharacterStats(pData);

            pData.SendPlayerTalentData();

            pData.SendPlayerExp();
            pData.SendPlayerCurrency();

            //envia os items
            for (int n = 0; n < 14; n++) {
                GamePacket.SendEquippedItem(pData, (GameItem.EquipSlotType)n);
            }

            InventoryPacket.SendInventoryItems(pData);

            //adiciona o jogador ao mapa
            MapManager.FindMapByID(pData.WorldID).CharacterID.Add(pData.CharacterID);

            Log.Write($"{pData.CharacterName} joined map id {pData.WorldID}", Color.Black);

            //envia outros jogadores do mapa
            MapManager.FindMapByID(pData.WorldID).GetPlayerOnMap(pData);

            //envia jogador para outros jogadores do mapa
            MapManager.FindMapByID(pData.WorldID).SendPlayerToMap(pData);

            // MapManager.FindMapByID(pData.WorldID)
            Map.SendNpc(pData);
        }
    }
}
