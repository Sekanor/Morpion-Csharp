using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /// <summary>
    /// Le seul objectif de cette IA est de jouer dans la première case libre.
    /// </summary>
    public class IA_Basique : IA
    {

        public void Jouer(PlateauRestreint plateau)
        {
            bool plateauRempli = false;
            Case caseTrouvee = null;
            int x = 0;
            int y = 0;

            do
            {
                if (plateau.GetCase(x,y).EstMarquee() == null)
                {
                    caseTrouvee = plateau.GetCase(x, y);
                }
                else
                {
                    // On évalue la case suivante du plateau.
                    x++;
                    if (x == 3)
                    {
                        x = 0;
                        y++;
                        if (y == 3)
                        {
                            plateauRempli = true;
                        }
                    }
                }

            } while ((caseTrouvee == null) && !plateauRempli);
        }

    }

}
