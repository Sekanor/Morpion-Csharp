using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morpion_métier;

namespace Morpion_testsUnitaires
{
    [TestClass]
    public class Test_IA_Aleatoire
    {
        [TestMethod]
        public void TestIA()
        {

            // Test unitaire d'une méthode aléatoire : pose soucis, car il ne pourra jamais être valable à 100%.
            // Nous pouvons seulement nous approcher de ce nombre.

            Morpion morpion = new Morpion();
            morpion.Initialisation("IA_1", "IA_2");

            IA_Aleatoire ia = new IA_Aleatoire(morpion.PlateauRestreint);
            Position pos;

            morpion.PlateauJeu.Afficher();


            for (int i = 0; i < 9; i++)
            {
                pos = ia.Jouer();
                morpion.Tour(pos.X, pos.Y);
                morpion.PlateauJeu.Afficher();
            }
        }
    }
}
