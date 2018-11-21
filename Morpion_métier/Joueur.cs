using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    public class Joueur
    {

        // Identifiant du joueur
        private int id;

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
        public Joueur(int id)
        {
            this.id = id;
            this.nom = "";
        }

        // Méthode permettant de vérifier si deux joueurs sont égaux.
        public override bool Equals(object obj)
        {
            var joueur = obj as Joueur;
            return joueur != null &&
                   id == joueur.id &&
                   id == joueur.id;
        }
    }
}
