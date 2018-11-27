using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    public interface IA
    {

        /// <summary>
        /// Méthode permettant à l'IA de jouer un tour.
        /// </summary>
        void Jouer(Plateau p); 

    }
}
