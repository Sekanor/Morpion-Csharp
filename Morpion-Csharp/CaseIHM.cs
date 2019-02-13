using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Morpion_métier;

namespace Morpion_Csharp
{
    class CaseIHM
    {
        private Case caseMorpion;
        private Image image;

        public CaseIHM(Case c, Image img)
        {
            this.caseMorpion = c;
            this.image = img;
            this.image.Source = new BitmapImage(new Uri("Images/j0.png", UriKind.Relative));
        }

        public Case GetCaseMorpion()
        {
            return caseMorpion;
        }

        public Image GetImage()
        {
            return image;
        }

        public void Marquer(Joueur j)
        {
            caseMorpion.PlateauJeu.MorpionJeu.Tour(caseMorpion.X, caseMorpion.Y);

            if (this.caseMorpion.Joueur == this.caseMorpion.PlateauJeu.MorpionJeu.Joueur1)
            {
                this.image.Source = new BitmapImage(new Uri("Images/j1.png", UriKind.Relative));
            }

            if (this.caseMorpion.Joueur == this.caseMorpion.PlateauJeu.MorpionJeu.Joueur2)
            {
                this.image.Source = new BitmapImage(new Uri("Images/j2.png", UriKind.Relative));
            }

        }

        /// <summary>
        /// Réinitialise l'image de la case
        /// </summary>
        public void Nettoyer()
        {
            this.image.Source = new BitmapImage(new Uri("Images/j0.png", UriKind.Relative));
        }

    }
}
