using System.Collections.Generic;
using System.Linq;
using Elysium_Diamond.DirectX;

namespace Elysium_Diamond.Maps {
    public class MapManager {
        public static HashSet<EngineNpc> Npc { get; set; } = new HashSet<EngineNpc>();
        public static HashSet<EngineCharacter> Player = new HashSet<EngineCharacter>();

        /// <summary>
        /// Realiza uma busca pelo ID do jogador.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EngineCharacter FindPlayerByID(int id) {
            if (id == 0) { return null; }

            var find = from pData in Player
                       where pData.ID == id
                       select pData;

            return find.FirstOrDefault();
        }

        /// <summary>
        /// Realiza uma busca pelo ID unico do npc.
        /// </summary>
        /// <param name="uniqueid"></param>
        /// <returns></returns>
        public static EngineNpc FindPlayerByUniqueID(int uniqueid) {
            if (uniqueid == 0) { return null; }

            var find = from npc in Npc
                       where npc.UniqueID == uniqueid
                       select npc;

            return find.FirstOrDefault();
        }
    }
}
