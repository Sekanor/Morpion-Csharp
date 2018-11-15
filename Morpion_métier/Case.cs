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

        // Permet à un joueur de marquer la case.
        public void Marquer(Joueur j)
        {
            this.joueur = j;
        }

        // Permet de vérifier si le joueur est marqué.
        public Joueur EstMarquee()
        {
            return this.joueur;
        }

        
    }
}
