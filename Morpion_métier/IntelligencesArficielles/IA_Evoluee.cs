using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /// <summary>
    /// Cette IA joue semi-intelligement, en bloquant la troisième case d'une ligne gagnante de l'adversaire.
    /// </summary>
    public class IA_Evoluee : IA
    {

        public IA_Evoluee(PlateauRestreint p) : base(p)
        {

        }

        public override Position Jouer()
        {
            return null;
        }

        public Case MeilleureCase()
        {
            //List<Case> casePossibles;

            return null;
        }

        /// <summary>
        /// 
        /// 1 si la position est gagnante,
        /// 0 si on ne sait pas,
        /// -1 si la position est perdante.
        /// Implémentation de l'algorithme Minimax pour évaluer les positions.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int Evaluation(PlateauRestreint p)
        {
            

            return 0;
        }

    }
}
