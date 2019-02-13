using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morpion_métier;

namespace Morpion_testsUnitaires
{
    [TestClass]
    public class Test_IA_Basique
    {
        [TestMethod]
        public void TestIA()
        {

            Morpion morpion = new Morpion();
            morpion.Initialisation("Joueur1", "IABasique");
            Position pos;

            IA_Basique ia = new IA_Basique(morpion.PlateauRestreint);

            // Tour 1

            morpion.Tour(0, 0);

            Assert.AreEqual(null, morpion.PlateauJeu.GetCase(1, 0).Joueur);
            
            pos = ia.Jouer();
            morpion.Tour(pos.X, pos.Y);

            Assert.AreEqual(morpion.Joueur2, morpion.PlateauJeu.GetCase(1, 0).Joueur);

            // Tour 2

            morpion.Tour(2, 1);

            pos = ia.Jouer();
            morpion.Tour(pos.X, pos.Y);

            Assert.AreEqual(morpion.Joueur2, morpion.PlateauJeu.GetCase(2, 0).Joueur);

            // Tour 3
            
            morpion.Tour(1, 2);

            pos = ia.Jouer();
            morpion.Tour(pos.X, pos.Y);

            Assert.AreEqual(morpion.Joueur2, morpion.PlateauJeu.GetCase(0, 1).Joueur);

            // Tour 4

            morpion.Tour(1, 1);

            pos = ia.Jouer();
            morpion.Tour(pos.X, pos.Y);

            Assert.AreEqual(morpion.Joueur2, morpion.PlateauJeu.GetCase(2, 0).Joueur);

            // Tour 5

            morpion.Tour(2, 2);

            Assert.AreEqual(false, morpion.EnJeu);

            pos = ia.Jouer();
            morpion.Tour(pos.X, pos.Y);

            Assert.AreEqual(new Position(-1, -1), pos);


        }
    }
}
