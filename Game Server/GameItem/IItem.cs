using System;

namespace GameServer.GameItem {
    public interface IItem {
        /// <summary>
        /// ID de item.
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Quantidade.
        /// </summary>
        short Quantity { get; set; }

        /// <summary>
        /// Nivel de encantamento.
        /// </summary>
        short Enchant { get; set; }

        /// <summary>
        /// Durabilidade.
        /// </summary>
        short Durability { get; set; }

        /// <summary>
        /// ID de socket.
        /// </summary>
        short[] Socket { get; set; }

        /// <summary>
        /// Indica se o item pode expirar.
        /// </summary>
        byte Expire { get; set; }

        /// <summary>
        /// Tempo limite
        /// </summary>
        DateTime ExpireDate { get; set; }

        /// <summary>
        /// Ligado ao personagem.
        /// </summary>
        byte SoulBound { get; set; }

        /// <summary>
        /// Item negociável.
        /// </summary>
        byte Tradeable { get; set; }
    }
}