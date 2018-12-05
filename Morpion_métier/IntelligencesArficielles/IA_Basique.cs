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

        public IA_Basique(PlateauRestreint p) : base(p)
        {

        }

        public override Position Jouer()
        {
            bool plateauRempli = false;
            bool caseTrouvee = false;
            int x = 0;
            int y = 0;

            // -1 car la position doit être invalide par défaut. A modifier ?
            int xFinal = -1;
            int yFinal = -1;

            do
            {
                if (this.Plateau.GetCase(x,y).Joueur == null)
                {
                    caseTrouvee = true;
                    xFinal = x;
                    yFinal = y;
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

            } while (!caseTrouvee && !plateauRempli);

            Position pos = new Position(xFinal, yFinal);

            return pos;
        }

    }

}
