using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morpion_métier;

namespace Morpion_testsUnitaires
{
    [TestClass]
    public class Test_Morpion
    {
        [TestMethod]
        public void TestConstructeur()
        {
            Morpion morpion = new Morpion();
        }

        [TestMethod]
        public void TestPartie()
        {
            Morpion morpion = new Morpion();
            morpion.Initialisation("Joueur1", "Joueur2");

            // Vérification si le joueur courant est correctement défini.
            Assert.AreEqual(morpion.Joueur1, morpion.JoueurCourant);

            morpion.Tour(0, 0);
            morpion.Tour(0, 1);

            // Vérification si les cartes ont été marquées correctement.
            Assert.AreEqual(morpion.Joueur1, morpion.PlateauJeu.GetCase(0, 0).Joueur);
            Assert.AreEqual(morpion.Joueur2, morpion.PlateauJeu.GetCase(0, 1).Joueur);

            // Vérification si le joueur courant est correctement défini.
            Assert.AreEqual(morpion.Joueur1, morpion.JoueurCourant);

            morpion.Tour(1, 0);
            morpion.Tour(1, 1);

            // Vérification s'il n'y a bien pas de vainqueur encore assigné.
            Assert.AreEqual(null, morpion.Vainqueur);

            // Marquage de la dernière case manquante permettant au joueur 1 de gagner la partie.
            morpion.Tour(2, 0);

            // Vérification si le joueur 1 a bien été assigné comme vainqueur.
            Assert.AreEqual(morpion.Joueur1, morpion.Vainqueur);

            morpion.Initialisation("NouveauJoueur1", "NouveauJoueur2");

            // Vérification si toutes les cases sont vides.
            Boolean casesVides = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; i < 3; i++)
                {
                    casesVides = casesVides && (morpion.PlateauJeu.GetCase(i, j).Joueur == null);
                }
            }
            Assert.AreEqual(true, casesVides);

            // Vérification si le joueur courant est bien le joueur 1.
            Assert.AreEqual(morpion.Joueur1, morpion.JoueurCourant);

            // Vérification si les joueurs ont bien les noms demandés.
            Assert.AreEqual("NouveauJoueur1", morpion.Joueur1.Nom);
            Assert.AreEqual("NouveauJoueur2", morpion.Joueur2.Nom);

            // Vérification s'il n'y a bien pas de vainqueur encore assigné.
            Assert.AreEqual(null, morpion.Vainqueur);

            morpion.Tour(1, 1);
            morpion.Tour(2, 2);
            morpion.Tour(1, 2);
            morpion.Tour(1, 0);
            morpion.Tour(2, 1);
            morpion.Tour(0, 1);
            morpion.Tour(0, 2);
            morpion.Tour(2, 0);
            morpion.Tour(0, 0);

            // Vérification si la partie est bien notée comme match nul.
            Assert.AreEqual(null, morpion.Vainqueur);


        }
    }
}
