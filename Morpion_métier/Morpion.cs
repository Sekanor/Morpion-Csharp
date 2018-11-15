using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /* Représente un plateau de jeu */
    public class Morpion
    {
        private List<Joueur> listeJoueurs; // Liste des joueurs 
        private List<Case> cases; // Liste des cases
        private Joueur joueurCourant; // Joueur dont c'est le tour

        public Morpion()
        {
            this.listeJoueurs = new List<Joueur>();
            this.cases = new List<Case>();
            this.joueurCourant = listeJoueurs[0];
        }

        public void ajouterJoueur(Joueur j)
        {
            this.listeJoueurs.Add(j);
        }
    }
}
