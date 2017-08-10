namespace Elysium_Diamond.DirectX {
    public class EngineEventArgs {
        /// <summary>
        /// Botão esquerdo.
        /// </summary>
        public bool Left { get; set; }

        /// <summary>
        /// Botão direito.
        /// </summary>
        public bool Right { get; set; }

        /// <summary>
        /// Construtor vazio.
        /// </summary>
        public EngineEventArgs() {

        }

        /// <summary>
        /// Left, botão esquerdo e right, botão direito.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public EngineEventArgs(bool left, bool right) {
            Left = left;
            Right = right;
        }

        /// <summary>
        /// Retorna um evento vazio.
        /// </summary>
        public static EngineEventArgs Empty { get {
                return new EngineEventArgs();
            }
        }
    }
}
