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

    }
}
