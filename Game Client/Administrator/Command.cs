namespace Elysium_Diamond.Administrator {
    public static class Command {
        private const int COMMAND = 0;
        private const int TARGET = 1;

        /// <summary>
        /// Analisa o texto.
        /// </summary>
        /// <param name="text"></param>
        public static void ParseCommand(string text) {
            var parse = text.Split(' ');

            //command e target
            //se não houver os 2 primeiros comandos, retorna
            if (parse.Length < 2) { return; }

            var command = GetCommandType(parse[COMMAND].Trim());     
            var target = parse[TARGET].Trim(); 

            //retira os dois pacotes já usados
            var lenght = parse.Length - 2;
            var values = new string[lenght];

            for(var n = 0; n < lenght; n++) {
                values[n] = parse[n + 2];
            }

            CommandPacket.SendCommand(command, target, values);
        }

        /// <summary>
        /// Obtem o tipo de comando.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static CommandType GetCommandType(string data) {
            CommandType command = CommandType.None;

            switch (data) {
                case "/player.stat": command = CommandType.SetPlayerStat; break;
                case "/player.level": command = CommandType.SetPlayerLevel; break;
                case "/player.experience": command = CommandType.SetPlayerExperience; break;
                case "/player.points": command = CommandType.SetPlayerPoints; break;
                case "/player.sprite": command = CommandType.SetPlayerSprite; break;
                case "/player.location": command = CommandType.SetPlayerLocation; break;
                case "/player.currency": command = CommandType.SetPlayerCurrency; break;    
            }

            return command;
        }
    }
}