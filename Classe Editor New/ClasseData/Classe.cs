using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classe_Editor.ClasseData {
    public class Classe : StatsBase {
        /// <summary>
        /// ID de classe.
        /// </summary>
        public int ID { get; set; }

        public int OldID { get; set; }

        /// <summary>
        /// ID de icnremento
        /// </summary>
        public int IncrementID { get; set; }

        public string Name { get; set; }

        public short Sprite { get; set; }

        /// <summary>
        /// Lista de classes.
        /// </summary>
        public static List<Classe> Classes { get; set; }

        /// <summary>
        /// Atributos de incremento
        /// </summary>
        public StatIncrement Increment { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public Classe() {
            Increment = new StatIncrement();
        }

        /// Procura pelo indice da classe na lista.
        /// </summary>
        /// <param name="classeID"></param>
        /// <returns></returns>
        public static int FindClasseIndexByID(int classeID) {
            for (var index = 0; index < Classes.Count; index++) {
                if (Classes[index].ID == classeID) return index;
            }

            return -1;
        }
    }
}
