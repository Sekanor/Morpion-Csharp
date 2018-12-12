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
        /// 1 si la position est gagnante,
        /// 0 si on ne sait pas,
        /// -1 si la position est perdante.
        /// Implémentation de l'algorithme Minimax pour évaluer les positions.
        /// 
        /// Principe :
        /// - si la position est déterminée, on retourne 1 ou -1 (respectivement
        /// joueur1 gagne et joueur2 gagne)
        /// - on retourne 0 si la position est déterminée match nul.
        /// - Sinon, on parcourt l'arbre:
        ///     - on fait une liste de tous les mouvements possibles.
        ///     - on crée des copies du morpion avec ces mouvements joués,
        ///       qu'on évalue avec la fonction évaluation.
        ///     - on obtient une suite de positions avec leur évaluation respective;
        ///     - on applique Minimax pour connaître quel mouvements on sélectionne;
        ///     - on sélectionne aléatoirement parmi les mouvements ayant la meilleure
        ///       évaluation,
        ///     - on retourne le résultat (la position, et éventuellement son eval).
        /// </summary>
        /// <param name="p">Plateau à évaluer passé en paramètre.</param>
        /// <returns></returns>
        public int EvaluationPosition(PlateauRestreint p)
        {
            int res;

            if (p.VerifierVictoire() == this.Plateau.JoueurCourant)
            {
                // Victoire de l'IA : retourne 1.
                res = 1;
            }
            else if (p.VerifierVictoire() != null && p.VerifierVictoire() != this.Plateau.JoueurCourant)
            {
                // Défaite de l'IA : retourne -1.
                res = -1;
            }
            else if (p.VerifierPlateauRempli())
            {
                // Match nul : retourne 0.
                res = 0;
            }
            else
            {
                // Indécision.

                // On évalue tous les mouvements possibles, qu'on place dans une liste.
                List<Position> positionsLibres = this.GetPositionsLibres(p);
                int[] evaluations = new int[9];

                foreach (Position pos in positionsLibres)
                {
                    // Création d'une copie de plateau

                    
                }

            }

            

            return 0;
        }

        private List<Position> GetPositionsLibres(PlateauRestreint p)
        {
            List<Position> positionsLibres = new List<Position>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (p.GetCase(i, j).Joueur == null)
                    {
                        positionsLibres.Add(new Position(i, j));
                    }
                }
            }

            return positionsLibres;
        }

    }

}
