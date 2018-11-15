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

        // Constructeur de la classe Morpion.
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

        // Ajoute un joueur au morpion.
        private void AjouterJoueur(Joueur j)
        {
            this.listeJoueurs.Add(j);
        }

        // Déroule une partie.
        public void Partie()
        {
            Boolean partieEnCours = true;
            Joueur vainqueur = null;

            // Tour de jeu
            do
            {
                // Sélection du joueur courant.
                if (this.joueurCourant == null)
                {
                    this.joueurCourant = this.listeJoueurs[0];
                }
                else
                {
                    if (this.joueurCourant.Equals(this.listeJoueurs[0]))
                    {
                        this.joueurCourant = this.listeJoueurs[1];
                    }
                    else
                    {
                        this.joueurCourant = this.listeJoueurs[0];
                    }
                }

                // On sélectionne une case, et on la marque.
                this.cases[0, 1].Marquer(this.joueurCourant);

                // On vérifie s'il y a un vainqueur de la partie.
                vainqueur = this.VerifierVictoire();
                
                if (vainqueur != null)
                {
                    // Vainqueur trouvé : on arrête la partie.
                    partieEnCours = false;
                }
                else
                {
                    // Aucun vainqueur : on vérifie si le plateau est rempli,
                    // auquel cas on arrête la partie.
                    partieEnCours = !this.VerifierPlateauRempli();
                }

            } while (partieEnCours);

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

        /*
         * Cette méthode vérifie si le plateau est rempli.
         */
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
                    if (this.cases[i, j].EstMarquee() == null) {
                        plateauRempli = false;
                    }
                }
            }

            return plateauRempli;
        }
    }
}
