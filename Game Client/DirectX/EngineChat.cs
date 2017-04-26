using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpDX;
using Elysium_Diamond.DirectX;

namespace Elysium_Diamond.DirectX {
    public class EngineChat : EngineObject {
        /// <summary>
        /// imagen de scroll
        /// </summary>
        private EngineObject scroll_background;

        /// <summary>
        /// Texto de chat.
        /// </summary>
        public EngineTextBox Textbox { get; set; }

        /// <summary>
        /// Botões do scroll.
        /// </summary>
        private EngineButton[] button = new EngineButton[2];

        public List<EngineChatText> Message { get; set; }

        /// <summary>
        /// Construtor.
        /// </summary>
        public EngineChat() {
            Message = new List<EngineChatText>();

            Position = new Point(5, 435);
            Texture = EngineTexture.TextureFromFile($"./Data/Graphics/window_chat.png");
            Size = new Size2(277, 203);
            SourceRect = new Rectangle(0, 0, 277, 203);
            BorderRect = new Rectangle(0, 0, 277, 203);
            Transparency = 255;

            scroll_background = new EngineObject();
            scroll_background.Position = new Point(Position.X + 255, Position.Y + 10);
            scroll_background.Size = new Size2(10, 172);
            scroll_background.Texture = EngineTexture.TextureFromFile($"./Data/Graphics/scroll_background.png");
            scroll_background.SourceRect = new Rectangle(0, 0, 10, 172);
            scroll_background.Transparency = 255;

            button[0] = new EngineButton("arrow_up", 10, 10);
            button[0].Name = "up";
            button[0].Position = new Point(Position.X + 255, Position.Y + 10);
            button[0].BorderRect = new Rectangle(0, 0, 10, 10);
            button[0].SourceRect = new Rectangle(0, 0, 10, 10);
            button[0].Size = new Size2(10, 10);
            button[0].MouseUp += Up_Click;

            button[1] = new EngineButton("arrow_down", 10, 10);
            button[1].Name = "down";
            button[1].Position = new Point(Position.X + 255, Position.Y + 145);
            button[1].BorderRect = new Rectangle(0, 0, 10, 10);
            button[1].SourceRect = new Rectangle(0, 0, 10, 10);
            button[1].Size = new Size2(10, 10);
            button[1].MouseUp += Down_Click;
        }

        public override void Draw() {
            base.Draw();

        }

        public void Up_Click(object sender, EventArgs e) {
            EngineMultimedia.Play(EngineSoundEnum.Close);

            if (Index > 0) Index--;
        }

        public void Down_Click(object sender, EventArgs e) {
            EngineMultimedia.Play(EngineSoundEnum.Close);

            if (Index < Message.Count - 1) Index++;
        }

        public void AddText(string text, Color color) {

        }
    }
}
