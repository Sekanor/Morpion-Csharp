using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morpion_métier;

namespace Morpion_testsUnitaires
{
    [TestClass]
    public class Test_IA_Evoluee
    {
        [TestMethod]
        public void TestIA()
        {

            Morpion morpion = new Morpion();
            morpion.Initialisation("IA_Evoluee", "Joueur");
            Position pos;

            IA_Evoluee ia = new IA_Evoluee(morpion.PlateauRestreint);

            // Tour 1 -- test règle 1; on vérifie si l'IA joue au centre.
            pos = ia.Jouer();
            morpion.Tour(pos.X, pos.Y);
            morpion.PlateauJeu.Afficher();
            Assert.AreEqual(morpion.Joueur1, morpion.PlateauJeu.GetCase(1, 1).EstMarquee());

            Console.Write("===========\n\n");

            // On recommence une partie. Tour 2 -- test règle 2; on vérifie si l'IA joue dans une diagonale si le premier joueur joue au centre.
            morpion.Initialisation("Joueur", "IA_Evoluee");
            morpion.Tour(1, 1);

            pos = ia.Jouer();
            morpion.Tour(pos.X, pos.Y);
            morpion.PlateauJeu.Afficher();
            Assert.AreEqual(morpion.Joueur2, morpion.PlateauJeu.GetCase(0, 0).EstMarquee());

            // Tour 3 -- test règle 3: si l'IA détecte une case pouvant faire gagner l'adversaire, elle joue dans cette case.
            morpion.Tour(1, 0);

            pos = ia.Jouer();
            morpion.Tour(pos.X, pos.Y);
            morpion.PlateauJeu.Afficher();
            Assert.AreEqual(morpion.Joueur2, morpion.PlateauJeu.GetCase(1, 2).EstMarquee());

        }
    }
}
