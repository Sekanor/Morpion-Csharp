using System;

namespace Morpion_métier
{
    public class Case
    {

        // Correspond au joueur qui a marqué la case.
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

    }
}
