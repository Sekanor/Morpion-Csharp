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

            IA_Parfaite ia = new IA_Parfaite(morpion.PlateauRestreint);

            // Tour 1 -- test règle 1; on vérifie si l'IA joue au centre.

            morpion.Tour(1, 1);
            morpion.Tour(0, 1);
            morpion.Tour(0, 0);
            morpion.Tour(2, 2);
            morpion.Tour(2, 0);
            morpion.Tour(0, 2);

            pos = ia.Jouer();
            morpion.Tour(pos.X, pos.Y);
            morpion.PlateauJeu.Afficher();

            


            //Assert.AreEqual(morpion.Joueur1, morpion.PlateauJeu.GetCase(1, 1).Joueur);

        }

        [TestMethod]
        public void MatchTestIAs()
        {

            Morpion morpion = new Morpion();
            morpion.Initialisation("IA_Evoluee", "Joueur");
            Position pos;

            IA_Parfaite perf = new IA_Parfaite(morpion.PlateauRestreint);
            IA_Aleatoire alea = new IA_Aleatoire(morpion.PlateauRestreint);
            IA_Evoluee evol = new IA_Evoluee(morpion.PlateauRestreint);

            for (int i = 0; i < 9; i++)
            {
                if (i%2 == 0)
                {
                    pos = perf.Jouer();
                }
                else
                {
                    pos = evol.Jouer();
                }
                morpion.Tour(pos.X, pos.Y);
                morpion.PlateauJeu.Afficher();
            }
            




            //Assert.AreEqual(morpion.Joueur1, morpion.PlateauJeu.GetCase(1, 1).Joueur);

        }
    }
}