using System.Drawing;
using System.Collections.Generic;
using System.IO;

namespace TextEditor {
    public static class EngineIcon {
        public static List<Bitmap> Icon = new List<Bitmap>();

        public static void LoadBitmap() {
            Icon.Add(new Bitmap(32, 32));

            var max_icons = Directory.GetFiles("./Icon/").Length;
            for (int n = 1; n <= max_icons; n++) {
                Icon.Add(new Bitmap($"./Icon/{n}.png"));
            }
        }
    }
}
