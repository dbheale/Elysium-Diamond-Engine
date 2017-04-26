using System;

namespace GameServer.Maps {
    public partial class Map {
        /// <summary>
        /// ID do mapa.
        /// </summary>
        public int ID { get; set; }
                
        /// <summary>
        /// Instancia um novo mapa.
        /// </summary>
        /// <param name="mapID"></param>
        public Map(int mapID) {
            ID = mapID;
        }

        /// <summary>
        /// tick de envio.
        /// </summary>
        private int sendTick;

        /// <summary>
        /// Computa os dados do mapa.
        /// </summary>
        public void Compute() {
            foreach (var npc in Npcs) {
                npc.Compute();

                if (npc.DirectionQueue.Count > 0) {

                    if (Environment.TickCount >= sendTick + 170) {
                        npc.Direction = npc.DirectionQueue.Dequeue();
                        npc.Move();
                        SendNpcMove(npc);

                        sendTick = Environment.TickCount;
                    }
                }
            }

        }
    }
}