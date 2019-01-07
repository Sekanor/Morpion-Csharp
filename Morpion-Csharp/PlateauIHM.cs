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

        public void AjouterCaseIHM(CaseIHM c)
        {
            casesIHM.Add(c);
        }

        public CaseIHM GetCase(int x, int y)
        {
            CaseIHM res = null;

            foreach (CaseIHM c in casesIHM) {
                if (c.GetCaseMorpion().X == x && c.GetCaseMorpion().Y == y)
                {
                    res = c;
                }
            }

            return res;
        }

        public CaseIHM GetCase(string imgId)
        {
            CaseIHM res = null;

            foreach (CaseIHM c in casesIHM)
            {
                if (c.GetImage().Name == imgId)
                {
                    res = c;
                }
            }

            return res;
        }

        /// <summary>
        /// Réinitialise les images du plateau
        /// </summary>
        public void Nettoyer()
        {
            foreach (CaseIHM c in casesIHM)
            {
                c.Nettoyer();
            }
        }

    }
}
