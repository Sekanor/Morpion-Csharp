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

        /// <summary>
        /// Méthode permettant à l'IA de jouer un tour.
        /// </summary>
        public abstract Position Jouer(); 

    }
}
