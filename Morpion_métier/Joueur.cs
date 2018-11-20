using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    public class Joueur
    {
        // Nom du joueur.
        private String nom;
        public String Nom
        {
            get
            {
                return this.nom;
            }
            set
            {
                this.nom = value;
            }
        }

        // Constructeur de la classe Joueur.
        public Joueur(String nom)
        {
            this.nom = nom;
        }

        // Méthode permettant de vérifier si deux joueurs sont égaux.
        public override bool Equals(object obj)
        {
            var joueur = obj as Joueur;
            return joueur != null &&
                   nom == joueur.nom &&
                   Nom == joueur.Nom;
        }

        public override int GetHashCode()
        {
            var hashCode = 142165330;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(nom);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nom);
            return hashCode;
        }
    }
}
