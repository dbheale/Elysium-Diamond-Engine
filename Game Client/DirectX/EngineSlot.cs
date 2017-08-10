using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.DirectX {
    public class EngineSlot : EngineObject {
        private Color _iconColor;
        private byte _iconTransparency;
        /// <summary>
        /// ID do objeto inserido no slot.
        /// </summary>
        /// public int ObjectID { get; set; }

        /// <summary>
        /// Tipo do objeto inserido no slot.
        /// </summary>
        /// public int ObjectType { get; set; }

        /// <summary>
        /// Ícone do objeto.
        /// </summary>
        public int IconID { get; set; }

        /// <summary>
        /// Obtem ou altera a cor do ícone.
        /// </summary>
        public Color IconColor {
            get {
                return _iconColor;
            }
            set {
                _iconColor = new Color(value.R, value.G, value.B, _iconTransparency);
            }
        }

        /// <summary>
        /// Obtem ou altera a transparencia do ícone.
        /// </summary>
        public byte IconTransparency {
            get {
                return _iconTransparency;
            }
            set {
                _iconTransparency = value;
                _iconColor = new Color(Color.R, Color.G, Color.B, value);
            }
        }

        public EngineSlot() : base() {
            _iconColor = Color.White;
            _iconTransparency = byte.MaxValue;
        }

        /// <summary>
        /// Desenha o slot.
        /// </summary>
        /// <param name="texture"></param>
        public override void Draw(Texture texture) {
            EngineCore.SpriteDevice.Begin(SpriteFlags.AlphaBlend);
            EngineCore.SpriteDevice.Draw(texture, Color, SourceRect, null, _position);
            if (IconID > 0) EngineCore.SpriteDevice.Draw(EngineTexture.FindTextureByID(IconID, EngineTextureType.Icons), _iconColor, null, null, new Vector3(_position.X + 4, _position.Y + 4, 0));
            EngineCore.SpriteDevice.End();
        }
        //        new Color(Color.R, Color.G, Color.B, Transparency)
    }
}