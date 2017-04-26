using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;

namespace Elysium_Diamond.DirectX {
    public class EngineColor {
        public static Color GetColor(byte a, byte r, byte g, byte b) {
            return new Color(r, g, b, a);
        }
    }
}
