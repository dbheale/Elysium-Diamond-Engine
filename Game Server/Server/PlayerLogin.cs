using System.Drawing;
using GameServer.Network;
using GameServer.MySQL;
using GameServer.GameLogic;
using GameServer.Maps;
using Elysium;

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
                Character_DB.Save(playerData);

                Logs.Write($"Player disconnected: {playerData.CharacterName}", Color.Peru);

                MapManager.FindMapByID(playerData.WorldID).RemovePlayer(pData.CharacterID);

                Authentication.Disconnect(playerData);
            }

            //carrega dados do personagem
            Character_DB.Load(pData.HexID, pData.CharacterSlot);

            Logs.Write($"Player Found ID: {pData.CharacterID} Name: {pData.CharacterName}", Color.Black);

            //realiza o calculo dos stats
            CharacterLogic.UpdateCharacterStats(pData.AccountID);

            //aceita a conexão
            GamePacket.Message(pData.Connection, (int)PacketList.AcceptedConnection);

            //envia os dados do jogador
            pData.SendPlayerBasicData();
            pData.SendPlayerElementalStats();
            pData.SendPlayerLocation();
            pData.SendPlayerMagicStats();
            pData.SendPlayerPhysicalStats();
            pData.SendPlayerResistStats();
            pData.SendPlayerStats();
            pData.SendPlayerUniqueStats();
            pData.SendPlayerVital();
            pData.SendPlayerVitalRegen();
            pData.SendPlayerExp();

            //adiciona o jogador ao mapa
            MapManager.FindMapByID(pData.WorldID).CharacterID.Add(pData.CharacterID);

            Logs.Write($"{pData.CharacterName} joined map id {pData.WorldID}", Color.Black);

            //envia outros jogadores do mapa
            MapManager.FindMapByID(pData.WorldID).GetPlayerOnMap(pData);

            //envia jogador para outros jogadores do mapa
            MapManager.FindMapByID(pData.WorldID).SendPlayerToMap(pData);

            // MapManager.FindMapByID(pData.WorldID)
            Map.SendNpc(pData);
        }
    }
}
