using System;
using System.Windows.Forms;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace Elysium_Diamond.DirectX {
    public class EngineObject : IDisposable {
        protected Vector3 _position;
        protected Color _color;
        private byte _transparency;

        /// <summary>
        /// Obtem ou altera o índice do controle.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Obtem ou altera o nome do controle.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtem ou altera as coordenadas do controle.
        /// </summary>
        public Point Position {
            get { return new Point((int)_position.X, (int)_position.Y); }
            set { _position = new Vector3(value.X, value.Y, 0); }
        }

        /// <summary>
        /// Obtem ou altera o tamanho do controle.
        /// </summary>
        public Size2 Size { get; set; }

        /// <summary>
        /// Obtem ou altera a area de cópia da textura.
        /// </summary>
        public Rectangle SourceRect { get; set; }

        /// <summary>
        /// Obtem ou altera a area de borda da intersecção com o mouse.
        /// </summary>
        public Rectangle BorderRect { get; set; }

        /// <summary>
        /// Obtem ou altera o valor indicando a resposta de interação.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Obtem ou altera a visibilidade do controle.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Habilita ou desabilita o click com o botão direito.
        /// </summary>
        public bool MouseRight { get; set; }

        /// <summary>
        /// Obtem ou altera a cor.
        /// </summary>
        public Color Color {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// Obtem ou altera o valor de transparencia.
        /// </summary>
        public byte Transparency {
            get { return _transparency; }

            set {
                Color = new Color(Color.R, Color.G, Color.B, value);
                _transparency = value;
            }
        }

        /// <summary>
        /// Obtem ou altera a textura do controle.
        /// </summary>
        public Texture Texture { get; set; }

        /// <summary>
        /// Spriteflags
        /// </summary>
        public SpriteFlags SpriteFlags { get; set; }

        public delegate void MouseEventHandler(object sender, EngineEventArgs args);

        /// <summary>
        /// Eventos de click dos botões.
        /// </summary>
        public event MouseEventHandler MouseUp, MouseDown, MouseMove, MouseLeave;

        //used for mouse events
        protected bool move, click, left, right;

        /// <summary>
        /// Instancia a classe.
        /// </summary>
        public EngineObject() {
            Name = string.Empty;
            Transparency = byte.MaxValue;
            Visible = true;
            Enabled = true;
            SourceRect = new Rectangle(0, 0, 0, 0);
            BorderRect = new Rectangle(0, 0, 0, 0);
            Position = new Point(0, 0);
            Color = Color.White;
            SpriteFlags = SpriteFlags.AlphaBlend;
        }

        /// <summary>
        /// Carrega um novo arquivo e obtém automaticamente o tamanho.
        /// </summary>
        /// <param name="file">Arquivo</param>
        public EngineObject(string file) {
            Name = string.Empty;
            Transparency = byte.MaxValue;
            Visible = true;
            Enabled = true;
            BorderRect = new Rectangle(0, 0, 0, 0);
            Position = new Point();
            Color = Color.White;
            SpriteFlags = SpriteFlags.AlphaBlend;

            Size2 size;
            Texture = EngineTexture.TextureFromFile(file, out size);

            Size = size;
            SourceRect = new Rectangle(0, 0, Size.Width, Size.Height);
        }

        /// <summary>
        /// Carrega um novo arquivo com tamanho definido.
        /// </summary>
        /// <param name="file">Arquivo</param>
        public EngineObject(string file, int width, int height) {
            Name = string.Empty;
            Transparency = byte.MaxValue ;
            Visible = true;
            Enabled = true;
            Position = new Point();
            Color = Color.White;
            SpriteFlags = SpriteFlags.AlphaBlend;
            Size = new Size2(width, height);
            SourceRect = new Rectangle(0, 0, width, height);
            BorderRect = new Rectangle(0, 0, 0, 0);

            Texture = EngineTexture.TextureFromFile(file, width, height);
        }

        /// <summary>
        /// Destrutor.
        /// </summary>
        ~EngineObject() {
            Dispose(false);
        }

        public virtual void Execute() {
            MouseButtons();
            Draw();
        }

        /// <summary>
        /// Desenha o controle de acordo com as coordenadas.
        /// </summary>
        public virtual void Draw() {
            if (!Visible) { return; }
            if (Transparency == byte.MinValue) { return; }

            EngineCore.SpriteDevice.Begin(SpriteFlags);
            EngineCore.SpriteDevice.Draw(Texture, _color, SourceRect, null, _position);
            EngineCore.SpriteDevice.End();
        }

        /// <summary>
        /// Desenha o controle de acordo com as coordenadas usando outra textura.
        /// </summary>
        /// <param name="texture">Textura</param>
        public virtual void Draw(Texture texture) {
            if (!Visible) return;
            if (Transparency == byte.MinValue) return;

            MouseButtons();

            EngineCore.SpriteDevice.Begin(SpriteFlags.AlphaBlend);
            EngineCore.SpriteDevice.Draw(texture, _color, SourceRect, null, _position);
            EngineCore.SpriteDevice.End();
        }

        /// <summary>
        /// Executa os eventos do mouse.
        /// </summary>
        public virtual void MouseButtons() {
            if (!Enabled) { return; }

            if (InsideButton()) { //se o cursor estiver em cima do botão ... 
                if (!move) { // se o evento mousemove não foi executado ainda (MOUSE MOVE)
                    move = true;  // permite que ele seja executado (apenas uma vez)  (MOUSE MOVE) 
                    OnMouseMove(new EngineEventArgs(EngineCore.MouseLeft, EngineCore.MouseRight)); //invoca o evento mouse move (MOUSE MOVE)
                }

                if (EngineCore.MouseLeft || EngineCore.MouseRight) { //se o click estiver pressionado... (MOUSE DOWN)
                    left = EngineCore.MouseLeft;
                    right = EngineCore.MouseRight;

                    //se o botão direito não estiver ativo
                    if (!MouseRight) {
                        if (right) 
                        return;
                    }

                    if (!click) {      //se o evento mousedown não foi executado ainda ... (MOUSEDOWN)
                        OnMouseDown(new EngineEventArgs(left, right));  //invoca o evento mouse down (MOUSEDOWN)
                        click = true;    //muda para true indicando que o click ja foi pressionado
                    }
                }
                else {
                    if (click) { //se o click ja foi pressionado (MOUSEUP)
                        OnMouseUp(new EngineEventArgs(left, right)); //invoca o evento mouse up (MOUSEUP)
                        left = false;
                        right = false;
                        click = false; //muda o click para falso
                    }
                }
            }
            else { //se o cursor nao estiver em cima do botao
                if (move) {
                    move = false;
                    OnMouseLeave(EngineEventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Invoca o evento mouse up.
        /// </summary>
        /// <param name="_event"></param>
        protected virtual void OnMouseUp(EngineEventArgs args) {            
            MouseUp?.Invoke(this, args);
        }

        /// <summary>
        /// Invoca o evento mouse move.
        /// </summary>
        /// <param name="_event"></param>
        protected virtual void OnMouseMove(EngineEventArgs args) {
            MouseMove?.Invoke(this, args);
        }

        /// <summary>
        /// Invoca o evento mouse down.
        /// </summary>
        /// <param name="_event"></param>
        protected virtual void OnMouseDown(EngineEventArgs args) {
            MouseDown?.Invoke(this, args);
        }

        /// <summary>
        /// Invoca o evento mouse move.
        /// </summary>
        /// <param name="_event"></param>
        protected virtual void OnMouseLeave(EngineEventArgs args) {                                             
            MouseLeave?.Invoke(this, args);
        }

        /// <summary>
        /// Verifica se o mouse faz uma intersecção com o controle.
        /// </summary>
        public virtual bool InsideButton() {
            if (!Enabled) { return false; }
            if (!Visible) { return false; }
            if (!Program.GraphicsDisplay.Focused) { return false; }
            if (Program.GraphicsDisplay.WindowState == FormWindowState.Minimized) { return false; }

            if ((EngineCore.MousePosition.X >= (Position.X + BorderRect.X) && (EngineCore.MousePosition.X <= ((Position.X + BorderRect.X) + BorderRect.Width)))) {
                if ((EngineCore.MousePosition.Y >= (Position.Y + BorderRect.Y) && (EngineCore.MousePosition.Y <= ((Position.Y + BorderRect.Y) + BorderRect.Height)))) { return true; }
            }

            return false;
        }

        #region "IDisposable"
        bool disposed = false;
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing) {
            if (!this.disposed) {
                if (disposing) {
                    Texture = null;
                    Name = null;
                }

                disposed = true;
            }
        }
        #endregion
    }
}