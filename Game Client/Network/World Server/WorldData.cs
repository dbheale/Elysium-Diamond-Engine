using System;
using System.Collections.Generic;
using System.Linq;
using Lidgren.Network;
using Elysium_Diamond.Common;
using Elysium_Diamond.EngineWindow;
using Elysium_Diamond.DirectX;

namespace Elysium_Diamond.Network {
    public class WorldData {
        /// <summary>
        /// Carrega os personagens para exibição.
        /// </summary>
        /// <param name="data"></param>
        public static void PreLoad(NetIncomingMessage msg) {
            var classeIndex = 0;

            //limpa os dados dos personagens
            WindowCharacter.Clear();

            for (var index = 0; index < Configuration.MAX_CHARACTER; index++) {
                WindowCharacter.Player[index].Name = msg.ReadString();

                classeIndex = Classes.ClasseManager.GetIndexByID(msg.ReadInt32());

                WindowCharacter.Player[index].Class = Classes.ClasseManager.Classes[classeIndex].Name;
                WindowCharacter.Player[index].Sprite = msg.ReadInt16();
                WindowCharacter.Player[index].Level = msg.ReadInt32();
            }
        }

        /// <summary>
        /// Recebe os dados do game server.
        /// </summary>
        /// <param name="data"></param>
        public static void GameServerData(NetIncomingMessage msg) {
            Configuration.HexID = msg.ReadString();
            Configuration.IPAddress[(int)SocketEnum.GameServer] = new IPAddress(msg.ReadString(), msg.ReadInt32());      
            NetworkSocket.Disconnect(SocketEnum.GameServer);
        }

        public static void AddTextChat(NetIncomingMessage msg) {
            var type = msg.ReadByte();
            var channel = msg.ReadByte();
            var from = msg.ReadString();
            var text = msg.ReadString();

            WindowChat.AddText(from, text, (MessageType)type);
        }
    }
}
