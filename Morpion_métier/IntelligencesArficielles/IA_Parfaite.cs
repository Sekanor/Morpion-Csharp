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
            //Move move = this.EvaluationPosition(this.Plateau, true);
            //return move.Position;

            List<Position> positionsLibres = this.GetPositionsLibres(this.Plateau);
            List<Position> bestPositionsList = new List<Position>();

            int bestEval = -67736;

            foreach (Position pos in positionsLibres)
            {

                Morpion morpionClone = new Morpion();
                morpionClone.Initialisation(this.Plateau.Joueur1, this.Plateau.Joueur2);
                morpionClone.PlateauJeu = this.Plateau.Clone(morpionClone);
                

                if (morpionClone.JoueurCourant == morpionClone.Joueur1)
                {
                    morpionClone.Tour(pos.X, pos.Y);
                    int eval = this.Minimax(morpionClone.PlateauRestreint, false);
                    if (bestPositionsList.Count == 0 || eval == bestEval)
                    {
                        bestPositionsList.Add(pos);
                        bestEval = eval;
                    }
                    else if (eval > bestEval)
                    {
                        bestPositionsList.Clear();
                        bestPositionsList.Add(pos);
                        bestEval = eval;
                    }
                }
                else
                {
                    morpionClone.Tour(pos.X, pos.Y);
                    int eval = this.Minimax(morpionClone.PlateauRestreint, true);
                    if (bestPositionsList.Count == 0 || eval == bestEval)
                    {
                        bestPositionsList.Add(pos);
                        bestEval = eval;
                    }
                    else if (eval < bestEval)
                    {
                        bestPositionsList.Clear();
                        bestPositionsList.Add(pos);
                        bestEval = eval;
                    }
                }
            }
            Random rand = new Random();
            int index = rand.Next(bestPositionsList.Count);
            Position bestPosition = bestPositionsList[index];

            return bestPosition;

        }

        public int Minimax(PlateauRestreint p, bool maximizingPlayer)
        {
            int res;

            if (p.VerifierVictoire() == p.Joueur1)
            {
                // Victoire du joueur 1 : retourne 1.
                res = 1;
            }
            else if (p.VerifierVictoire() == p.Joueur2)
            {
                // Victoire du joueur 2 : retourne -1.
                res = -1;
            }
            else if (p.VerifierPlateauRempli())
            {
                // Match nul : retourne 0.
                res = 0;
            }
            else
            {
                // Not terminal node

                List<Position> positionsLibres = this.GetPositionsLibres(p);

                if (maximizingPlayer)
                {
                    // foreach child of node
                    res = -5000;
                    foreach (Position pos in positionsLibres)
                    {
                        // Création d'une copie de plateau
                        Morpion morpionClone = new Morpion();
                        morpionClone.Initialisation(p.Joueur1, p.Joueur2);
                        morpionClone.PlateauJeu = p.Clone(morpionClone);

                        morpionClone.Tour(pos.X, pos.Y);
                        res = Math.Max(res, this.Minimax(morpionClone.PlateauRestreint, false));
                    }
                }
                else
                {
                    // foreach child of node
                    res = +5000;
                    foreach (Position pos in positionsLibres)
                    {
                        // Création d'une copie de plateau
                        Morpion morpionClone = new Morpion();
                        morpionClone.Initialisation(p.Joueur1, p.Joueur2);
                        morpionClone.PlateauJeu = p.Clone(morpionClone);

                        morpionClone.Tour(pos.X, pos.Y);
                        res = Math.Min(res, this.Minimax(morpionClone.PlateauRestreint, true));
                    }
                }

            }

            return res;
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
