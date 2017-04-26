using System.Collections.Generic;
using System.Linq;

namespace GameServer.Npcs {
    public class NpcManager {
        private static HashSet<Npc> npcs { get; set; } = new HashSet<Npc>();

        /// <summary>
        /// Adiciona um novo npc na lista.
        /// </summary>
        /// <param name="npc"></param>
        public static void Add(Npc npc) {
            npcs.Add(npc);
        }

        /// <summary>
        /// Encontra um npc pelo ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Npc FindByID(int id) {
            var find_npc = from nData in npcs
                           where nData.ID == id
                           select nData;

            return find_npc.FirstOrDefault();
        }
    }
}
