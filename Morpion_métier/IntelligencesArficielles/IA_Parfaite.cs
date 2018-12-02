using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /// <summary>
    /// Cette intelligence artificielle a pour objectif de jouer parfaitement;
    /// soit, de ne jamais perdre, et de gagner lorsque l'adversaire fait une erreur
    /// (que ce soit une autre IA ou non).
    /// 
    /// Pour concevoir l'intelligence artificielle, nous utilisons un arbre évaluant toutes les positions
    /// légales atteignables à partir de la position actuelle.
    /// Il ne peut y avoir au maximum que 9! = 362 880 positions au morpion; ainsi l'approche brute force
    /// reste raisonnable pour l'ordinateur.
    /// </summary>
    public class IA_Parfaite : IA
    {

        public IA_Parfaite(PlateauRestreint p) : base(p)
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
        public int EvaluationPosition(PlateauRestreint p)
        {

            

            return 0;
        }

    }
}
