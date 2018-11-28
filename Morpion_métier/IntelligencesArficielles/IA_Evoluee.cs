using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /// <summary>
    /// Cette IA joue semi-intelligement, en bloquant la troisième case d'une ligne gagnante de l'adversaire.
    /// 
    /// L'IA évoluée suit quatre règles, dans l'ordre :
    /// 1. Si l'IA joue en premier, elle joue au centre.
    /// 2. Si l'adversaire joue au centre en premier, 
    ///    l'IA joue dans une diagonale.
    /// 3. Si l'IA détecte une case pouvant faire gagner l'adversaire,
    ///    elle joue dans cette case.
    /// 4. Si l'IA ne sait pas quoi jouer, elle joue aléatoirement.
    /// </summary>
    public class IA_Evoluee : IA
    {

        public IA_Evoluee(PlateauRestreint p) : base(p)
        {

        }

        public override Position Jouer()
        {
            bool aJoue = false;
            Position pos = null;

            // 1. Si l'IA joue en premier, elle joue au centre.
            Boolean estVide = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; i < 3; i++)
                {
                    estVide = estVide && (this.Plateau.GetCase(i, j).EstMarquee() == null);
                }
            }

            if (estVide)
            {
                pos = new Position(1, 1);
            }

            // 2. Si l'adversaire joue au centre en premier, l'IA joue dans une diagonale.
            if (pos == null)
            {

                if (this.Plateau.GetCase(1, 1).EstMarquee() != this.Plateau.JoueurCourant
                    && this.Plateau.GetCase(1, 1).EstMarquee() != null)
                {
                    // Cela signifie que l'autre joueur a joué dans cette case.

                    // On vérifie si le plateau est vide hormis cette case.
                    Boolean estPresqueVide = true;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; i < 3; i++)
                        {
                            if (!(i == 1 && j == 1))
                            {
                                estPresqueVide = estPresqueVide && (this.Plateau.GetCase(i, j).EstMarquee() == null);
                            }
                        }
                    }

                    if (estPresqueVide)
                    {
                        // On pourrait faire un aléatoire pour décider de la diagonale jouée.
                        pos = new Position(0, 0);
                    }
                }

            }

            // 3. Si l'IA détecte une case pouvant faire gagner l'adversaire, elle joue dans cette case.
            if (pos == null)
            {
                
                // Lignes
                for(int i = 0; i < 3; i++)
                {
                    for (int j = 0; i < 2; i++)
                    {
                        
                    }
                }

                // Colonnes

                // Quatre diagonales


            }

            // 4. Si l'IA ne sait pas quoi jouer, elle joue aléatoirement.
            if (pos == null)
            {

            }

            return pos;
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
