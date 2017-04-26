using System.Linq;
using System.Collections.Generic;

namespace GameServer.Maps {
    public static partial class MapManager {
        /// <summary>
        /// Lista de mapas
        /// </summary>
        private static HashSet<Map> maps = new HashSet<Map>();

        /// <summary>
        /// Adiciona um novo mapa.
        /// </summary>
        /// <param name="map"></param>
        public static void Add(Map map) {
            maps.Add(map);
        }

        /// <summary>
        /// Procura um mapa pelo ID.
        /// </summary>
        /// <param name="mapID"></param>
        /// <returns></returns>
        public static Map FindMapByID(int mapID) {
            var find_value = from mData in maps
                             where mData.ID.CompareTo(mapID) == 0
                             select mData;

            return find_value.FirstOrDefault();
        }

        public static void Compute() {
            foreach(var map in maps) {
                map.Compute();
            }
        }
    }
}
