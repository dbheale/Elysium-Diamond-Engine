using System;
using Elysium_Diamond.Common;
using Elysium_Diamond.DirectX;


namespace Elysium_Diamond.Network {
    public static class CommonData {
        public static void ChangeGameState(byte value) {
            EngineCore.GameState = value;
        }

    }
}
