using SharpDX;

namespace Elysium_Diamond.DirectX {
    public struct EngineChatText {
        public int ID { get; set; }
        public string Text { get; set; }
        public Color Color { get; set; }
        public int ItemID { get; set; }
        public int LineNumber { get; set; }

        public EngineChatText(int id, string text, Color color, int itemID, int lineNumber) {
            ID = id;
            Text = text;
            Color = color;
            ItemID = itemID;
            LineNumber = lineNumber;
         }
    }
}
