using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /// <summary>
    /// Cette classe a pour objectif de restreindre les droits d'utilisation
    /// des intelligences artificielles vis-à-vis du plateau,
    /// afin de par exemple empêcher aux IAs de réinitialiser le plateau.
    /// </summary>
    public class PlateauRestreint
    {

        private Plateau plateau;

        /// <summary>
        /// Constructeur de la classe PlateauRestreint.
        /// </summary>
        /// <param name="p">Plateau passé en paramètre.</param>
        public PlateauRestreint(Plateau p)
        {
            this.plateau = p;
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
            return plateau.GetCase(x, y);
        }


        public Joueur EstMarquee(int x, int y)
        {
            return plateau.GetCase(x, y).Joueur;
        }


        /// <summary>
        /// Retourne le joueur 1 de la partie.
        /// </summary>
        public Joueur Joueur1
        {
            get
            {
                return plateau.MorpionJeu.Joueur1;
            }
        }

        /// <summary>
        /// Retourne le joueur 2 de la partie.
        /// </summary>
        public Joueur Joueur2
        {
            get
            {
                return plateau.MorpionJeu.Joueur2;
            }
        }

        /// <summary>
        /// Retourne le joueur courant du tour.
        /// </summary>
        public Joueur JoueurCourant
        {
            get
            {
                return plateau.MorpionJeu.JoueurCourant;
            }
        }

        /// <summary>
        /// Cette méthode vérifie s'il y a une victoire.
        /// Dans le cas ou un joueur à gagné, la méthode renvoie ce joueur.
        /// Si aucun joueur n'a gagné, la méthode renvoie null.
        /// </summary>
        /// <param name="list">Liste des joueurs, utilisée pour simplifier la vérification de victoire.</param>
        /// <returns>Retourne le joueur ayant gagné la partie, et null s'il n'y en a pas.</returns>
        public Joueur VerifierVictoire()
        {
            // Cette méthode recrée une liste de joueurs, à optimiser.

            List<Joueur> liste = new List<Joueur>();
            liste.Add(this.Joueur1);
            liste.Add(this.Joueur2);

            return this.plateau.VerifierVictoire(liste);
        }

        /// <summary>
        /// Cette méthode vérifie si le plateau est rempli.
        /// </summary>
        /// <returns>Retourne true si le plateau est rempli.</returns>
        public Boolean VerifierPlateauRempli()
        {
            return this.plateau.VerifierPlateauRempli();
        }

        /// <summary>
        /// Clone le plateau : renvoie une nouvelle version du plateau, codée de manière identique.
        /// </summary>
        /// <returns>Retourne une nouvelle version du plateau, clonée.</returns>
        public Plateau Clone(Morpion morpion)
        {
            return this.plateau.Clone(morpion);
        }

    }
}
