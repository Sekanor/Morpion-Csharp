using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morpion_métier;

namespace Morpion_testsUnitaires
{
    [TestClass]
    public class Test_IA_Parfaite
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
            Assert.AreEqual(morpion.Joueur1, morpion.PlateauJeu.GetCase(1, 1).Joueur);

        }
    }
}