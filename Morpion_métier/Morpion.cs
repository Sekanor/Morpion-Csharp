using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /* Représente un plateau de jeu */
    public class Morpion
    {
        // Liste des joueurs
        private List<Joueur> listeJoueurs;

        // Liste des cases
        private Case[,] cases;

        // Joueur dont c'est le tour
        private Joueur joueurCourant; 

        public Morpion()
        {
            this.listeJoueurs = new List<Joueur>();
            this.joueurCourant = listeJoueurs[0];

            // Initialisation du plateau
            this.cases = new Case[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.cases[i, j] = new Case();
                }
            }
            
            
        }

        public void ajouterJoueur(Joueur j)
        {
            this.listeJoueurs.Add(j);
        }
    }
}
