using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    public class Joueur
    {
        private String nom;
        public String Nom
        {
            get
            {
                return this.nom;
            }
        }

        public Joueur(String nom)
        {
            this.nom = nom;
        }
    }
}
