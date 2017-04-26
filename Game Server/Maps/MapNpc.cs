using System.Collections.Generic;
using System.Linq;

namespace GameServer.Maps {
    public partial class Map {
        /// <summary>
        /// Lista de Npc
        /// </summary>
        public HashSet<MapNpcData> Npcs { get; set; } = new HashSet<MapNpcData>();

        /// <summary>
        /// Encontra um npc pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MapNpcData FindNpcByID(int npcID) {
            var find_npc = from nData in Npcs
                           where nData.ID == npcID
                           select nData;

            return find_npc.FirstOrDefault();
        }
    }
}
