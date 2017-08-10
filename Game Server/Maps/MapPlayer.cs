using System.Collections.Generic;
using GameServer.Server;
using GameServer.Player;

namespace GameServer.Maps {
    public partial class Map {
        /// <summary>
        /// Lista de jogadores no mapa.
        /// </summary>
        public HashSet<int> CharacterID { get; set; } = new HashSet<int>();

        /// <summary>
        /// Envia jogador para todos do mapa.
        /// </summary>
        /// <param name="pData"></param>
        public void SendPlayerToMap(PlayerData pData) {
            foreach (int characterID in CharacterID) {
                //procura o jogador pelo ID
                var playerData = Authentication.FindByCharacterID(characterID);

                //se for o mesmo jogador, ignora
                if (playerData.CharacterID == pData.CharacterID) { continue; }

                Map.SendMapPlayer(playerData.Connection, pData.CharacterID, pData.CharacterName, pData.Sprite, pData.Direction, pData.X, pData.Y);
            }
        }

        /// <summary>
        /// Envia cada jogador do mapa para determinado jogador.
        /// </summary>
        /// <param name="pData"></param>
        public void GetPlayerOnMap(PlayerData pData) {
            foreach (int characterID in CharacterID) {
                //procura o jogador pelo ID
                var playerData = Authentication.FindByCharacterID(characterID);

                //se for o mesmo jogador, ignora
                if (playerData.CharacterID == pData.CharacterID) { continue; }

                Map.SendMapPlayer(pData.Connection, playerData.CharacterID, playerData.CharacterName, playerData.Sprite, playerData.Direction, playerData.X, playerData.Y);
            }
        }

        /// <summary>
        /// Envia o movimento do jogador para o mapa.
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="dir"></param>
        public void SendPlayerMove(PlayerData pData, byte dir) {
            foreach (int characterID in CharacterID) {
                //procura o jogador pelo ID
                var playerData = Authentication.FindByCharacterID(characterID);

                //se for o mesmo jogador, ignora
                if (playerData.CharacterID == pData.CharacterID) { continue; }

                Map.SendPlayerMapMove(playerData.Connection, pData.CharacterID, dir);
            }
        }

        /// <summary>
        /// Remove um jogador do mapa.
        /// </summary>
        /// <param name="id"></param>
        public void RemovePlayer(int characterID) {
            CharacterID.Remove(characterID);

            foreach (int id in CharacterID) {
                var pData = Authentication.FindByCharacterID(id);

                if (pData.CharacterID == characterID) { continue; }

                Map.RemovePlayerOnMap(pData.Connection, characterID);
            }
        }
    }
}
