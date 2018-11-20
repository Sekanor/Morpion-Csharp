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

        public override bool Equals(object obj)
        {
            var joueur = obj as Joueur;
            return joueur != null &&
                   nom == joueur.nom &&
                   Nom == joueur.Nom;
        }
    }
}
