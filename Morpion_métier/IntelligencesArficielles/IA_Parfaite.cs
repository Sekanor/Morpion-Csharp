using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{

    public class Move
    {
        private Position position;
        public Position Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }
        private int evaluation;
        public int Evaluation
        {
            get
            {
                return this.evaluation;
            }
            set
            {
                this.evaluation = value;
            }
        }

        public Move(Position pos, int eval)
        {
            this.position = pos;
            this.evaluation = eval;
        }

        public Move()
        {
            this.position = null;
            this.evaluation = -2;
        }

        public override string ToString()
        {
            return this.position.ToString() + " evaluated " + this.evaluation;
        }
    }

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

            Position bestPosition = null;
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
                    if (bestPosition == null)
                    {
                        bestPosition = pos;
                        bestEval = eval;
                    }
                    else if (eval > bestEval)
                    {
                        bestPosition = pos;
                        bestEval = eval;
                    }
                }
                else
                {
                    morpionClone.Tour(pos.X, pos.Y);
                    int eval = this.Minimax(morpionClone.PlateauRestreint, true);
                    if (bestPosition == null)
                    {
                        bestPosition = pos;
                        bestEval = eval;
                    }
                    else if (eval < bestEval)
                    {
                        bestPosition = pos;
                        bestEval = eval;
                    }
                }
            }

            return bestPosition;

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
        public Move EvaluationPosition(PlateauRestreint p, bool firstMove)
        {

            // On évalue tous les mouvements possibles, qu'on place dans une liste.
            List<Position> positionsLibres = this.GetPositionsLibres(p);
            List<Move> moves = new List<Move>();

            foreach (Position pos in positionsLibres)
            {

                Move move = new Move(pos, -2);

                // Création d'une copie de plateau
                Morpion morpionClone = new Morpion();
                morpionClone.Initialisation(p.Joueur1, p.Joueur2);
                morpionClone.PlateauJeu = p.Clone(morpionClone);
                morpionClone.Tour(pos.X, pos.Y);
                //morpionClone.PlateauJeu.Afficher();

                if (morpionClone.PlateauRestreint.VerifierVictoire() == this.Plateau.JoueurCourant)
                {
                    // Victoire de l'IA : retourne 1.
                    move.Evaluation = 1;
                }
                else if (morpionClone.PlateauRestreint.VerifierVictoire() != null && morpionClone.PlateauRestreint.VerifierVictoire() != this.Plateau.JoueurCourant)
                {
                    // Défaite de l'IA : retourne -1.
                    move.Evaluation = -1;
                    
                }
                else if (morpionClone.PlateauRestreint.VerifierPlateauRempli())
                {
                    // Match nul : retourne 0.
                    move.Evaluation = 0;
                }
                else
                {
                    Move res = this.EvaluationPosition(morpionClone.PlateauRestreint, false);
                    move.Evaluation = res.Evaluation;
                }

                // La position a été évaluée
                moves.Add(move);
            }

            // Evaluation finale

            if (firstMove)
            {
                // point d'arrêt
                Console.Write("HiDingDingPipe\n");
            }

            Move bestMove = new Move();
            IA_Aleatoire rand = new IA_Aleatoire(this.Plateau);
            bestMove.Position = rand.Jouer();

            foreach (Move move in moves)
            {
                if (move.Evaluation >= bestMove.Evaluation)
                {
                    bestMove = move;
                }
            }

            //Console.Write(bestMove.Position+"\n");
            return bestMove;
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
