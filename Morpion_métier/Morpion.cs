using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /* Représente un plateau de jeu */
    public class Morpion
    {
        // Plateau de jeu
        private Plateau plateauJeu;
        public Plateau PlateauJeu
        {
            get
            {
                return this.plateauJeu;
            }
        }

        // Liste des joueurs
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
            this.listeJoueurs = new List<Joueur>();

            // Initialisation des joueurs
            this.AjouterJoueur(new Joueur("Ange"));
            this.AjouterJoueur(new Joueur("Kévin"));

            this.plateauJeu = new Plateau(this);
            
        }

        // Ajoute un joueur au morpion.
        private void AjouterJoueur(Joueur j)
        {
            this.listeJoueurs.Add(j);
        }

        // Déroule une partie.
        private void Partie()
        {
            Boolean partieEnCours = true;
            Joueur vainqueur = null;

            // Tour de jeu
            do
            {
                // Sélection du joueur courant.
                if (this.joueurCourant == null)
                {
                    this.joueurCourant = this.Joueur1();
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
                this.PlateauJeu.GetCase(1, 1).Marquer(this.JoueurCourant);

                // On vérifie s'il y a un vainqueur de la partie.
                vainqueur = this.PlateauJeu.VerifierVictoire(this.listeJoueurs);
                
                if (vainqueur != null)
                {
                    // Vainqueur trouvé : on arrête la partie.
                    partieEnCours = false;
                }
                else
                {
                    // Aucun vainqueur : on vérifie si le plateau est rempli,
                    // auquel cas on arrête la partie.
                    partieEnCours = !this.PlateauJeu.VerifierPlateauRempli();
                }

            } while (partieEnCours);

        }
 

    }
}
