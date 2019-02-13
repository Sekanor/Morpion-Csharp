using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /// <summary>
    /// Gère le morpion, fait le lien entre tous les éléments du jeu.
    /// </summary>
    public class Morpion
    {
        /// <summary>
        /// Booléen représentant si la partie est en cours ou non.
        /// </summary>
        private Boolean enJeu;
        public Boolean EnJeu
        {
            get
            {
                return this.enJeu;
            }
        }

        /// <summary>
        /// Plateau de jeu
        /// </summary>
        private Plateau plateauJeu;
        public Plateau PlateauJeu
        {
            get
            {
                return this.plateauJeu;
            }
            set
            {
                this.plateauJeu = value;
                this.plateauRestreint.PlateauJeu = value;
            }
        }

        /// <summary>
        /// Plateau de jeu en lecture seule, transféré aux IAs.
        /// </summary>
        private PlateauRestreint plateauRestreint;
        public PlateauRestreint PlateauRestreint
        {
            get
            {
                return this.plateauRestreint;
            }
        }

        /// <summary>
        /// Liste des joueurs, accesseurs pour Joueur1 et Joueur2
        /// </summary>
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

        /// <summary>
        /// Joueur dont c'est le tour
        /// </summary>
        private Joueur joueurCourant; 
        public Joueur JoueurCourant
        {
            get
            {
                return this.joueurCourant;
            }
            set
            {
                this.joueurCourant = value;
            }
        }

        /// <summary>
        /// Constructeur de la classe Morpion.
        /// </summary>
        public Morpion()
        {
            this.plateauJeu = new Plateau(this);
            this.plateauRestreint = new PlateauRestreint(this.plateauJeu);
            this.listeJoueurs = new List<Joueur>();

            // Initialisation des joueurs
            this.listeJoueurs.Add(new Joueur(1));
            this.listeJoueurs.Add(new Joueur(2));
        }

        /// <summary>
        /// Initialise le déroulement d'une partie.
        /// </summary>
        /// <param name="nomJoueur1">Nom du premier joueur.</param>
        /// <param name="nomJoueur2">Nom du deuxième joueur.</param>
        public void Initialisation(string nomJoueur1, string nomJoueur2)
        {
            this.enJeu = true;
            this.Joueur1.Nom = nomJoueur1;
            this.Joueur2.Nom = nomJoueur2;
            this.joueurCourant = this.Joueur1;
            this.PlateauJeu.Reinitialiser();
        }

        /// <summary>
        /// Initialise le déroulement d'une partie.
        /// </summary>
        /// <param name="nomJoueur1">Nom du premier joueur.</param>
        /// <param name="nomJoueur2">Nom du deuxième joueur.</param>
        public void Initialisation(Joueur j1, Joueur j2)
        {
            this.enJeu = true;
            this.listeJoueurs[0] = j1;
            this.listeJoueurs[1] = j2;
            this.joueurCourant = this.Joueur1;
            this.PlateauJeu.Reinitialiser();
        }

        /// <summary>
        /// Tour de jeu
        /// </summary>
        /// <param name="x">Coordonnée x de la case.</param>
        /// <param name="y">Coordonnée y de la case.</param>
        public void Tour(int x, int y)
        {
            if (this.enJeu)
            {
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
