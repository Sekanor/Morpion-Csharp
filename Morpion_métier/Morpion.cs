using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    public class Morpion
    {
        // Booléen représentant si la partie est en cours ou non.
        private Boolean enJeu;
        public Boolean EnJeu
        {
            get
            {
                return this.enJeu;
            }
        }

        // Plateau de jeu
        private Plateau plateauJeu;
        public Plateau PlateauJeu
        {
            get
            {
                return this.plateauJeu;
            }
        }

        // Liste des joueurs, accesseurs pour Joueur1 et Joueur2
        private List<Joueur> listeJoueurs;
        public Joueur Joueur1
        {
            get
            {
                return this.listeJoueurs[0];
            }
            
        }
        public Joueur Joueur2
        {
            get
            {
                return this.listeJoueurs[1];
            }

        }
        public Joueur Vainqueur
        {
            get
            {
                return this.PlateauJeu.VerifierVictoire(this.listeJoueurs);
            }
        }

        // Joueur dont c'est le tour
        private Joueur joueurCourant; 
        public Joueur JoueurCourant
        {
            get
            {
                return this.joueurCourant;
            }
        }


        // Constructeur de la classe Morpion.
        public Morpion()
        {
            this.plateauJeu = new Plateau(this);
            this.listeJoueurs = new List<Joueur>();

            // Initialisation des joueurs
            this.listeJoueurs.Add(new Joueur(""));
            this.listeJoueurs.Add(new Joueur(""));
            
            this.Initialisation("Joueur1", "Joueur2");
        }

        // Initialise le déroulement d'une partie.
        public void Initialisation(string nomJoueur1, string nomJoueur2)
        {
            this.enJeu = true;
            this.Joueur1.Nom = nomJoueur1;
            this.Joueur2.Nom = nomJoueur2;
            this.joueurCourant = this.Joueur1;
            this.PlateauJeu.Reinitialiser();
        }

        // Tour de jeu
        public void Tour(int x, int y)
        {
            if (this.enJeu)
            {
                Console.Write(this.PlateauJeu.GetCase(x, y));

                // On marque le plateau.
                if (this.PlateauJeu.GetCase(x, y).Marquer(this.JoueurCourant))
                {
                    // On vérifie s'il y a un vainqueur de la partie.
                    Joueur vainqueur = this.PlateauJeu.VerifierVictoire(this.listeJoueurs);

                    if (vainqueur != null)
                    {
                        // Vainqueur trouvé : on arrête la partie.
                        this.enJeu = false;
                    }
                    else
                    {
                        // Aucun vainqueur : on vérifie si le plateau est rempli,
                        // auquel cas on arrête la partie.
                        this.enJeu = !this.PlateauJeu.VerifierPlateauRempli();
                    }

                    if (this.enJeu)
                    {
                        // Changement du joueur courant.
                        if (this.joueurCourant.Equals(this.Joueur1))
                        {
                            this.joueurCourant = Joueur2;
                        }
                        else
                        {
                            this.joueurCourant = Joueur1;
                        }
                    }
                }
            }
        }

    }
}
