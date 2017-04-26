using System;
using System.Drawing;

namespace Elysium {
    public class LogsEventArgs : EventArgs {
        public string Text { get; private set; }
        public Color Color { get; private set; }

        public LogsEventArgs(string text, Color color) {
            Text = text;
            Color = color;
        }
    }
}

