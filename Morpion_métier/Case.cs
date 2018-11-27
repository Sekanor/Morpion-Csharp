using System;

namespace Morpion_métier
{
    public class Case
    {

        /// <summary>
        /// Correspond au joueur qui a marqué la case.
        /// null correspond à une case non marquée.
        /// </summary>
        private Joueur joueur;
        public Joueur Joueur
        {
            get
            {
                return this.joueur;
            }
        }

        /// <summary>
        /// Constructeur de la classe Case.
        /// </summary>
        public Case()
        {
            this.joueur = null;
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
            Boolean peutMarquer = (this.EstMarquee() == null || j == null);

            if (peutMarquer)
            {
                this.joueur = j;
            }

            return peutMarquer;
        }

        /// <summary>
        /// Permet de vérifier si un joueur a marqué cette case.
        /// Si la case n'a pas été marquée, la méthode retourne null.
        /// </summary>
        /// <returns>Retourne le joueur ayant marqué la case, et null si aucun.</returns>
        public Joueur EstMarquee()
        {
            return this.joueur;
        }
    }
}
