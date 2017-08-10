using GameServer.Server;
using GameServer.GameLogic;

namespace GameServer.Administrator {
    public static partial class AdminTool {
         /// <summary>
        /// Altera os atributos de determinado personagem.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="command"></param>
        /// <param name="value"></param>
        public static void SetStat(string character, string[] values) {
            //se o pacote não estiver completo, retorna
            if (values.Length < 2) { return; }

            byte stat;
            int value;
            var result = byte.TryParse(values[0], out stat);
            result = int.TryParse(values[1], out value);

            //se a conversão não for possível, retorna
            if (!result) { return; }

            //se não encontrar o usuário, retorna
            var pData = Authentication.FindByCharacterName(character);
            if (pData == null) { return; }

            switch (stat) {
                case 0:
                    pData.Strenght = value;
                    break;
                case 1:
                    pData.Dexterity = value;
                    break;
                case 2:
                    pData.Agility = value;
                    break;
                case 3:
                    pData.Constitution = value;
                    break;
                case 4:
                    pData.Intelligence = value;
                    break;
                case 5:
                    pData.Wisdom = value;
                    break;
                case 6:
                    pData.Will = value;
                    break;
                case 7:
                    pData.Mind = value;
                    break;
            }

            CharacterLogic.UpdateCharacterStats(pData);
            CharacterLogic.SendCharacterStats(pData);
        }

        /// <summary>
        /// Altera o level do personagem.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="values"></param>
        public static void SetLevel(string character, string[] values) {
            int value;
            var result = int.TryParse(values[0], out value);

            //se a conversão não for possível, retorna
            if (!result) { return; }

            //se não encontrar o usuário, retorna
            var pData = Authentication.FindByCharacterName(character);
            if (pData == null) { return; }

            pData.Level = value;

            CharacterLogic.UpdateCharacterStats(pData);
            CharacterLogic.SendCharacterStats(pData);

            pData.SendLevel();
        }

        /// <summary>
        /// Altera a experiência do personagem.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="values"></param>
        public static void SetExperience(string character, string[] values) {
            long value;
            var result = long.TryParse(values[0], out value);

            //se a conversão não for possível, retorna
            if (!result) { return; }

            //se não encontrar o usuário, retorna
            var pData = Authentication.FindByCharacterName(character);
            if (pData == null) { return; }

            pData.Experience = value;
            pData.SendPlayerExp();
        }

        /// <summary>
        /// Altera os pontos de stats.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="values"></param>
        public static void SetPoints(string character, string[] values) {
            int value;
            var result = int.TryParse(values[0], out value);

            //se a conversão não for possível, retorna
            if (!result) { return; }

            //se não encontrar o usuário, retorna
            var pData = Authentication.FindByCharacterName(character);
            if (pData == null) { return; }

            pData.StatPoints = value;
            pData.SendStatPoints();
        }

        /// <summary>
        /// Altera a sprite.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="values"></param>
        public static void SetSprite(string character, string[] values) {
            short value;
            var result = short.TryParse(values[0], out value);

            //se a conversão não for possível, retorna
            if (!result) { return; }

            //se não encontrar o usuário, retorna
            var pData = Authentication.FindByCharacterName(character);
            if (pData == null) { return; }

            pData.Sprite = value;
            pData.SendSprite();
        }

        /// <summary>
        /// Altera a localização no mapa.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="values"></param>
        public static void SetLocation(string character, string[] values) {
            //se o pacote não estiver completo, retorna
            if (values.Length < 2) { return; }

            short x, y;
            var result = short.TryParse(values[0], out x);
            result = short.TryParse(values[1], out y);

            //se a conversão não for possível, retorna
            if (!result) { return; }

            //se não encontrar o usuário, retorna
            var pData = Authentication.FindByCharacterName(character);
            if (pData == null) { return; }

            pData.X = x;
            pData.Y = y;
            pData.SendLocation();
        }

        /// <summary>
        /// Altera a quantidade de dinheiro.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="values"></param>
        public static void SetCurrency(string character, string[] values) {
            long value;
            var result = long.TryParse(values[0], out value);

            //se a conversão não for possível, retorna
            if (!result) { return; }

            //se não encontrar o usuário, retorna
            var pData = Authentication.FindByCharacterName(character);
            if (pData == null) { return; }

            pData.Currency = value;
            pData.SendPlayerCurrency();
        }
    }
}