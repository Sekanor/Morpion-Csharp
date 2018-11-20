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
            morpion.Tour(0, 0);
            morpion.Tour(0, 1);

            Assert.AreEqual(morpion.Joueur1, morpion.PlateauJeu.GetCase(0, 0).EstMarquee());
            Assert.AreEqual(morpion.Joueur2, morpion.PlateauJeu.GetCase(0, 1).EstMarquee());

            Assert.AreEqual(morpion.Joueur1, morpion.JoueurCourant);

            morpion.Tour(1, 0);
            morpion.Tour(1, 1);

            Assert.AreEqual(null, morpion.Vainqueur);

            morpion.Tour(2, 0);

            Assert.AreEqual(morpion.Joueur1, morpion.Vainqueur);

            
        }
    }
}
