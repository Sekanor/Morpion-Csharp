using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Morpion_métier;

namespace Morpion_Csharp
{
    class PlateauIHM
    {
        private Plateau plateauMorpion;
        private List<CaseIHM> casesIHM;

        public PlateauIHM(Plateau p)
        {
            this.plateauMorpion = p;
            foreach (Case c in this.plateauMorpion.Cases)
            {
                casesIHM.Add(new CaseIHM(c));
            }
        }

    }
}
