using System;
using System.Drawing;

namespace Elysium.Logs {
    public class LogEventArgs : EventArgs {
        public string Text { get; private set; }
        public Color Color { get; private set; }

        public LogEventArgs(string text, Color color) {
            Text = text;
            Color = color;
        }
    }
}