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
        private Image img;
        private BitmapImage imgFile;

        public CaseIHM(Case c, Image img)
        {
            this.caseMorpion = c;
            this.img = img;
            this.imgFile = new BitmapImage(new Uri("Images/j0.png", UriKind.Relative));
        }

        public void marquer(Joueur j)
        {
            this.caseMorpion.Marquer(j);

            if (this.caseMorpion.Joueur == this.caseMorpion.PlateauJeu.MorpionJeu.Joueur1)
            {
                this.imgFile = new BitmapImage(new Uri("Images/j1.png", UriKind.Relative));
            }

            else if (this.caseMorpion.Joueur == this.caseMorpion.PlateauJeu.MorpionJeu.Joueur2)
            {
                this.imgFile = new BitmapImage(new Uri("Images/j2.png", UriKind.Relative));
            }
        }

    }
}
