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
            this.casesIHM = new List<CaseIHM>();
        }

        public void ajouterCaseIHM(CaseIHM c)
        {
            casesIHM.Add(c);
        }

    }
}
