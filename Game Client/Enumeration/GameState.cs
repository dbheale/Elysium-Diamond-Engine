using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elysium_Diamond.Enumeration {
    public enum GameState : byte {
        None,
        Login,
        Server,
        Character,
        NewCharacter,
        Game
    }
}
