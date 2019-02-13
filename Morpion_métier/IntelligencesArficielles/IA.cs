using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    public abstract class IA
    {

        private PlateauRestreint plateau;
        public PlateauRestreint Plateau
        {
            get
            {
                return this.plateau;
            }
        }

        public IA(PlateauRestreint p)
        {
            this.plateau = p;
        }
        
        public bool CaseAdversaire(int x, int y)
        {
            return this.Plateau.GetCase(x, y).Joueur != null && this.Plateau.GetCase(x, y).Joueur != this.Plateau.JoueurCourant;
        }

        public bool CaseAlliee(int x, int y)
        {
            return this.Plateau.GetCase(x, y).Joueur == this.Plateau.JoueurCourant;
        }

        public bool CaseNonJouee(int x, int y)
        {
            return this.Plateau.GetCase(x, y).Joueur == null;
        }

        /// <summary>
        /// Méthode permettant à l'IA de jouer un tour.
        /// </summary>
        public abstract Position Jouer(); 

    }
}
