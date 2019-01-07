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

        public CaseIHM(Case c, Image img)
        {
            this.caseMorpion = c;
            this.img = img;
            this.img.Source = new BitmapImage(new Uri("Images/j0.png", UriKind.Relative));
        }

        public Case getCaseMorpion()
        {
            return caseMorpion;
        }

        public Image getImg()
        {
            return img;
        }

        public void marquer(Joueur j)
        {
            caseMorpion.PlateauJeu.MorpionJeu.Tour(caseMorpion.X, caseMorpion.Y);

            if (this.caseMorpion.Joueur == this.caseMorpion.PlateauJeu.MorpionJeu.Joueur1)
            {
                this.img.Source = new BitmapImage(new Uri("Images/j1.png", UriKind.Relative));
                Console.WriteLine("J1 a joué");
            }

            if (this.caseMorpion.Joueur == this.caseMorpion.PlateauJeu.MorpionJeu.Joueur2)
            {
                this.img.Source = new BitmapImage(new Uri("Images/j2.png", UriKind.Relative));
                Console.WriteLine("J2 a joué");
            }

        }

    }
}
