using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /// <summary>
    /// Cette intelligence artificielle a pour objectif de jouer parfaitement;
    /// soit, de ne jamais perdre, et de gagner lorsque l'adversaire fait une erreur
    /// (que ce soit une autre IA ou non).
    /// </summary>
    public class IA_Parfaite : IA
    {

        public IA_Parfaite(PlateauRestreint p) : base(p)
        {

        }

        public override Position Jouer()
        {
            return null;
        }

    }
}
