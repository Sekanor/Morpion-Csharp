using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /// <summary>
    /// Cette IA joue aléatoirement dans les cases libres.
    /// </summary>
    public class IA_Aleatoire : IA
    {

        public IA_Aleatoire(PlateauRestreint p) : base(p)
        {

        }

        public override Position Jouer()
        {

            List<Position> positionsLibres = new List<Position>();
            
            // On stocke toutes les cases libres dans un array.
            for (int caseX = 0; caseX < 3; caseX++)
            {
                for (int caseY = 0; caseY < 3; caseY++)
                {
                    if (this.Plateau.GetCase(caseX, caseY).EstMarquee() == null)
                    {
                        positionsLibres.Add(new Position(caseX, caseY));
                    }
                }
            }

            // On mélange cette liste.
            this.Shuffle(positionsLibres);

            // On prend le premier index de cette liste, qui sera la case jouée.
            Position positionJouee = positionsLibres[0];

            return positionJouee;

        }

        /// <summary>
        /// Mélange une liste.
        /// https://stackoverflow.com/questions/273313/randomize-a-listt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        private void Shuffle<T>(IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}
