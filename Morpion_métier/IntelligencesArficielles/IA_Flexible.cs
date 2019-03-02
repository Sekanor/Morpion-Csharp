using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier.IntelligencesArficielles
{
    /// <summary>
    /// Cette intelligence artificielle à pour objectif d'instaurer
    /// un nouveau de difficulté pour le joueur.
    /// </summary>
    public class IA_Flexible : IA
    {

        /// <summary>
        /// Correspond au niveau de difficulté de l'IA,
        /// varie entre 1 et 100.
        /// </summary>
        private int niveau;
        public int Niveau
        {
            get
            {
                return this.niveau;
            }
            set
            {
                this.niveau = value;
                if (this.niveau > 100) this.niveau = 100;
                if (this.niveau < 0) this.niveau = 0;
            }
        }

        public IA_Flexible(PlateauRestreint p, int niv) : base(p)
        {
            this.Niveau = niv;
        }

        public IA_Flexible(PlateauRestreint p) : base(p)
        {
            this.Niveau = 80;
        }

        /// <summary>
        /// Le principe du niveau de difficulté est le suivant: si l'IA a un niveau
        /// de 90, alors il y a 90% de chances qu'elle joue le coup correct.
        /// Dans le cas contraire, elle jouera un coup aléatoire
        /// (qui, est à noter, peut être le coup correct).
        /// </summary>
        /// <returns>Coup joué par l'IA.</returns>
        public override Position Jouer()
        {
            Position pos;

            Random rand = new Random();

            if (this.niveau >= rand.Next(1, 100))
            {
                pos = new IA_Parfaite(this.Plateau).Jouer();
            }
            else
            {
                pos = new IA_Aleatoire(this.Plateau).Jouer();
            }

            return pos;
        }

    }
}
