using System;
using System.Collections.Generic;

namespace Morpion_métier
{
    public class Case
    {

        /// <summary>
        /// Correspond au joueur qui a marqué la case.
        /// null correspond à une case non marquée.
        /// </summary>
        private Joueur joueur;
        /// <summary>
        /// Permet de vérifier si un joueur a marqué cette case.
        /// Si la case n'a pas été marquée, la méthode retourne null.
        /// </summary>
        /// <returns>Retourne le joueur ayant marqué la case, et null si aucun.</returns>
        public Joueur Joueur
        {
            get
            {
                return this.joueur;
            }
        }

        private Plateau plateau;
        public Plateau PlateauJeu
        {
            get
            {
                return this.plateau;
            }
        }

        private int x;
        public int X
        {
            get
            {
                return x;
            }
        }

        private int y;
        public int Y
        {
            get
            {
                return y;
            }
        }


        /// <summary>
        /// Constructeur de la classe Case.
        /// </summary>
        public Case(Plateau plateau, int x, int y)
        {
            this.plateau = plateau;
            this.joueur = null;
            this.x = x;
            this.y = y;

        }

        /// <summary>
        /// Permet à un joueur de marquer la case.
        /// Renvoie true si le marquage a été correctement effectué.
        /// Si un joueur a déjà marqué la case auparavant, la méthode renvoie false.
        /// </summary>
        /// <param name="j">Joueur marquant la case.</param>
        /// <returns>Retourne true si le joueur a correctement marqué la case.</returns>
        public Boolean Marquer(Joueur j)
        {
            Boolean peutMarquer = (this.Joueur == null || j == null);

            if (peutMarquer)
            {
                this.joueur = j;
            }

            return peutMarquer;
        }

        public override bool Equals(object obj)
        {
            var @case = obj as Case;
            return @case != null &&
                   EqualityComparer<Joueur>.Default.Equals(joueur, @case.joueur) &&
                   EqualityComparer<Joueur>.Default.Equals(Joueur, @case.Joueur);
        }
    }
}
