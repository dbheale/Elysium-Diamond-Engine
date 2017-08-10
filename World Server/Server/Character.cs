using System;
using WorldServer.Common;

namespace WorldServer.Server {
    public struct Character {
        public int ID { get; set; }
        /// <summary>
        /// Nome de personagem.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ID de classe.
        /// </summary>
        public int Class { get; set; }

        /// <summary>
        /// ID de sprite.
        /// </summary>
        public short Sprite { get; set; }

        /// <summary>
        /// Level de personagem.
        /// </summary>
        public int Level { get; set; }   

        /// <summary>
        /// Data de exclusão.
        /// </summary>
        public DateTime DeletionTime { get; set; }

        /// <summary>
        /// Ativa ou desativa a exclusão.
        /// </summary>
        public bool PendingDeletion { get; set; } 

        public int RegionID { get; set; }

        /// <summary>
        /// Limpa todos os dados
        /// </summary>
        public void Clear() {
            ID = 0;
            Name = string.Empty;
            Class = 0;
            Sprite = 0;
            Level = 0;
            PendingDeletion = false;
            RegionID = 0;
        }

        /// <summary>
        /// Verifica se o tempo de exclusão foi expirado.
        /// </summary>
        /// <returns></returns>
        public bool IsPendingDateExpired() {
            return (DateTime.Now.CompareTo(DeletionTime) == Constants.Expired) ? true : false;
        }
    }
}