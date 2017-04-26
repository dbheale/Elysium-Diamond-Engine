using NLua;

namespace GameServer.Maps {
    public static partial class MapManager {
        /// <summary>
        /// Carrega todos os mapas.
        /// </summary>
        public static void LoadMaps() {
            using(Lua lua = new Lua()) {
                lua.RegisterFunction("AddNpc", typeof(MapManager).GetMethod("AddNpc"));

                foreach (var map in maps) {
                    lua.DoFile($"./Maps/Map {map.ID}/npc.lua");
                }
            }
        }     

        /// <summary>
        /// Adiciona um novo npc.
        /// </summary>
        /// <param name="mapID"></param>
        /// <param name="npcID"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void AddNpc(int mapID, int npcID, int uniqueID, short x, short y, byte range, int movetime) {
            FindMapByID(mapID).Npcs.Add(new MapNpcData(npcID, uniqueID, x, y, range, movetime));
        }
    }
}
