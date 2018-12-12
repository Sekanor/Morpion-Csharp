using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Morpion_métier;

namespace Morpion_Csharp
{
    class CaseIHM
    {
        private Case caseMorpion;
        private BitmapImage img;

        public CaseIHM(Case c)
        {
            this.caseMorpion = c;
            this.img = new BitmapImage(new Uri("Images/j0.png", UriKind.Relative));
        }

    }
}
