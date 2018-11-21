using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    public class Joueur
    {

        /// <summary>
        /// Identifiant du joueur
        /// </summary>
        private int id;

        /// <summary>
        /// Nom du joueur.
        /// </summary>
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

        /// <summary>
        /// Constructeur de la classe Joueur.
        /// </summary>
        /// <param name="id">Identifiant unique du joueur.</param>
        public Joueur(int id)
        {
            this.id = id;
            this.nom = "";
        }

        /// <summary>
        /// Méthode permettant de vérifier si deux joueurs sont égaux.
        /// </summary>
        /// <param name="obj">Objet comparé au joueur.</param>
        /// <returns>Retourne true si les deux joueurs sont égaux.</returns>
        public override bool Equals(object obj)
        {
            var joueur = obj as Joueur;
            return joueur != null &&
                   id == joueur.id &&
                   id == joueur.id;
        }
    }
}
