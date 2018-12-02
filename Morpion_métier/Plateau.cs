using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    public class Plateau
    {
        /// <summary>
        /// Liste des cases
        /// </summary>
        private Case[,] cases;

        /// <summary>
        /// Instance du morpion auquel appartient le plateau.
        /// </summary>
        private Morpion morpion;
        public Morpion MorpionJeu
        {
            get
            {
                return this.morpion;
            }
        }

        /// <summary>
        /// Constructeur de la classe Plateau.
        /// </summary>
        /// <param name="m"></param>
        public Plateau(Morpion m)
        {
            this.morpion = m;

            // Initialisation du plateau
            this.cases = new Case[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.cases[i, j] = new Case();
                }
            }
        }

        /// <summary>
        /// Ré-initialisation du plateau à un état vide. Annule tous les marquages.
        /// </summary>
        public void Reinitialiser()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.cases[i, j].Marquer(null);
                }
            }
        }

        /// <summary>
        ///  Retourne une case du plateau.
        ///  Si la case n'existe pas, la méthode retourne null.
        /// </summary>
        /// <param name="x">Coordonnée x de la case.</param>
        /// <param name="y">Coordonnée y de la case.</param>
        /// <returns>Retourne la case correspondant aux coordonnées.</returns>
        public Case GetCase(int x, int y)
        {
            Case res = null;
            if (x >= 0 && x <= 2 && y >= 0 && y <= 2)
            {
                // A améliorer
                res = this.cases[x, y];
            }

            return res;
        }

        /// <summary>
        /// Cette méthode vérifie s'il y a une victoire.
        /// Dans le cas ou un joueur à gagné, la méthode renvoie ce joueur.
        /// Si aucun joueur n'a gagné, la méthode renvoie null.
        /// </summary>
        /// <param name="list">Liste des joueurs, utilisée pour simplifier la vérification de victoire.</param>
        /// <returns>Retourne le joueur ayant gagné la partie, et null s'il n'y en a pas.</returns>
        public Joueur VerifierVictoire(List<Joueur> list)
        {
            // Le code de cette méthode peut être optimisé, revenir dessus si le projet est terminé.
            Joueur joueurGagnant = null;

            foreach (Joueur joueur in list)
            {

                // Lignes
                for (int i = 0; i < 3; i++)
                {
                    if (this.cases[i, 0].EstMarquee() == joueur
                    && this.cases[i, 1].EstMarquee() == joueur
                    && this.cases[i, 2].EstMarquee() == joueur)
                    {
                        joueurGagnant = joueur;
                    }
                }

                // Colonnes
                for (int i = 0; i < 3; i++)
                {
                    if (this.cases[0, i].EstMarquee() == joueur
                    && this.cases[1, i].EstMarquee() == joueur
                    && this.cases[2, i].EstMarquee() == joueur)
                    {
                        joueurGagnant = joueur;
                    }
                }

                // Diagonale TL-DR
                if (this.cases[0, 0].EstMarquee() == joueur
                && this.cases[1, 1].EstMarquee() == joueur
                && this.cases[2, 2].EstMarquee() == joueur)
                {
                    joueurGagnant = joueur;
                }

                // Diagonale DL-TR
                if (this.cases[0, 2].EstMarquee() == joueur
                && this.cases[1, 1].EstMarquee() == joueur
                && this.cases[2, 0].EstMarquee() == joueur)
                {
                    joueurGagnant = joueur;
                }
            }

            return joueurGagnant;
        }

        /// <summary>
        /// Cette méthode vérifie si le plateau est rempli.
        /// </summary>
        /// <returns>Retourne true si le plateau est rempli.</returns>
        public Boolean VerifierPlateauRempli()
        {
            // Méthode a optimiser également.

            // On part du principe que le plateau est rempli,
            // sauf si on arrive à prouver qu'il ne l'est pas.
            Boolean plateauRempli = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (this.cases[i, j].EstMarquee() == null)
                    {
                        plateauRempli = false;
                    }
                }
            }

            return plateauRempli;
        }

        /// <summary>
        /// Permet d'afficher le plateau avec la console.
        /// Fonction utile pour débuguer des erreurs dans les tests unitaires.
        /// </summary>
        public void Afficher()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Ecriture
                    String c = "- ";

                    if (this.cases[j, i].EstMarquee() == this.MorpionJeu.Joueur1) c = "X";
                    else if (this.cases[j, i].EstMarquee() == this.MorpionJeu.Joueur2) c = "O";

                    Console.Write(c + " ");

                    if (j == 2)
                    {
                        Console.Write("\n");
                    }
                }
            }
            Console.Write("\n");
        }
    }
}
