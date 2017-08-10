using Lidgren.Network;

namespace GameServer.Administrator {
    public static class Command {
        /// <summary>
        /// Analisa o comando e executa.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="msg"></param>
        public static void ParseCommand(NetConnection connection, NetIncomingMessage msg) {
            var command = (CommandType)msg.ReadInt16();
            var target = msg.ReadString();
            var lenght = msg.ReadInt32();
            var values = new string[lenght];

            if (lenght == 0) return;

            for (var n = 0; n < lenght; n++) values[n] = msg.ReadString();

            switch (command) {
                case CommandType.SetPlayerStat: AdminTool.SetStat(target, values); break;
                case CommandType.SetPlayerLevel: AdminTool.SetLevel(target, values); break;
                case CommandType.SetPlayerExperience: AdminTool.SetExperience(target, values); break;
                case CommandType.SetPlayerPoints: AdminTool.SetPoints(target, values); break;
                case CommandType.SetPlayerSprite: AdminTool.SetSprite(target, values); break;
                case CommandType.SetPlayerLocation: AdminTool.SetLocation(target, values); break;
                case CommandType.SetPlayerCurrency: AdminTool.SetCurrency(target, values); break;
            }
        }
    }
}