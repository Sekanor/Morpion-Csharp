using System;

namespace Morpion_métier
{
    public class Case
    {

        /* Correspond au joueur qui a marqué la case.
         * null correspond à une case non marquée.
         */
        private Joueur joueur;
        public Joueur Joueur
        {
            get
            {
                return this.joueur;
            }
        }

        // Constructeur de la classe Case.
        public Case()
        {
            this.joueur = null;
        }

        /* Permet à un joueur de marquer la case.
         * Renvoie true si le marquage a été correctement effectué.
         * Si un joueur a déjà marqué la case auparavant, la méthode renvoie false.
         */
        public Boolean Marquer(Joueur j)
        {
            Boolean peutMarquer = (this.EstMarquee() == null || j == null);

            if (peutMarquer)
            {
                this.joueur = j;
            }

            return peutMarquer;
        }

        // Permet de vérifier si un joueur a marqué cette case.
        public Joueur EstMarquee()
        {
            return this.joueur;
        }

        
    }
}
