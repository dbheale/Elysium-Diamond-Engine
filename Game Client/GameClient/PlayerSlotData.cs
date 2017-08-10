using System;

namespace Elysium_Diamond.GameClient {
    /// <summary>
    /// Estrutura usada para a seleção de personagem.
    /// </summary>
    public struct PlayerSlotData {
        public string Name { get; set; }
        public string Class { get; set; }
        public int Sprite { get; set; }
        public int Level { get; set; }
        public byte Transparency { get; set; }
        public TimeSpan Time { get; set; }
        public int TickTime { get; set; }
        public bool Pending { get; set; }
        public string TimeString { get; set; }

        public void Clear() {
            Name = string.Empty;
            Class = string.Empty;
            Sprite = 0;
            Level = 0;
            Transparency = 255;
            TickTime = 0;
            Pending = false;
        }
    }
}
