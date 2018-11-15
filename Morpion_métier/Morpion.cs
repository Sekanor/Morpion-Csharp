using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /* Représente un plateau de jeu */
    public class Morpion
    {
        // Liste des joueurs
        private List<Joueur> listeJoueurs;

        // Liste des cases
        private Case[,] cases;

        // Joueur dont c'est le tour
        private Joueur joueurCourant; 

        public Morpion()
        {
            this.listeJoueurs = new List<Joueur>();

            // Initialisation des joueurs
            this.listeJoueurs[0] = new Joueur("Ange");
            this.listeJoueurs[1] = new Joueur("Kévin");
            this.joueurCourant = listeJoueurs[0];

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

        public void ajouterJoueur(Joueur j)
        {
            this.listeJoueurs.Add(j);
        }


        /* 
         * Cette méthode vérifie s'il y a une victoire.
         * Dans le cas ou un joueur à gagné, la méthode renvoie ce joueur.
         * Si aucun joueur n'a gagné, la méthode renvoie null.
         */
        public Joueur VerifierVictoire()
        {
            // Le code de cette méthode peut être optimisé, revenir dessus si le projet est terminé.
            Joueur joueurGagnant = null;

            foreach(Joueur joueur in this.listeJoueurs)
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
                    &&  this.cases[1, i].EstMarquee() == joueur
                    &&  this.cases[2, i].EstMarquee() == joueur)
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

        // Cette méthode vérifie si la partie est nulle; donc, si le plateau est rempli.
        public Boolean VerifierNulle()
        {
            // Méthode a optimiser également.

            // On part du principe que le plateau est rempli,
            // sauf si on arrive à prouver qu'il ne l'est pas.
            Boolean plateauRempli = true;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (this.cases[i, j].EstMarquee() == null) {
                        plateauRempli = false;
                    }
                }
            }

            return plateauRempli;
        }
    }
}
