using SharpDX;

namespace Elysium_Diamond.EngineWindow {
    public interface IEngineWindow {
        /// <summary>
        /// Índice da janela.
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// Mostra ou esconde a janela.
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// Posição do controle na tela.
        /// </summary>
        Point Position { get; set; }
    }
}
