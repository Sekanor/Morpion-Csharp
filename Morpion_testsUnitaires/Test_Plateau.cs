﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morpion_métier;

namespace Morpion_testsUnitaires
{
    [TestClass]
    public class Test_Plateau
    {
        [TestMethod]
        public void TestGetCase()
        {
            Morpion m = new Morpion();
            m.Initialisation("test1", "test2");

            // On vérifie si la case que l'on a obtenue par p.GetCase() a bien été marquée.
            Joueur jCourant = m.JoueurCourant;
            m.Tour(1, 2);
            Assert.AreEqual(jCourant, m.PlateauJeu.GetCase(1, 2).Joueur);

            // On vérifie si getCase() renvoie bien null si on lui demande une case de plateau qui n'existe pas.
            Assert.AreEqual(null, m.PlateauJeu.GetCase(3, 5));
        }

        [TestMethod]
        public void TestReinitialiser()
        {
            Morpion m = new Morpion();
            m.Initialisation("test1", "test2");

            m.Tour(0, 1);
            m.Tour(0, 2);

            m.PlateauJeu.Reinitialiser();

            // On vérifie si le plateau est vide.
            Boolean estVide = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; i < 3; i++)
                {
                    estVide = estVide && (m.PlateauJeu.GetCase(i, j).Joueur == null);
                }
            }
            Assert.AreEqual(true, estVide);
        }

        [TestMethod]
        public void TestClone()
        {
            Morpion morpion = new Morpion();
            morpion.Initialisation("Joueur1", "Joueur2");
            morpion.Tour(1, 2);

            Plateau plateau2 = morpion.PlateauJeu.Clone(new Morpion());

            // Test de chaque case, impropre
            Assert.AreEqual(null, plateau2.GetCase(0, 0).Joueur);
            Assert.AreEqual(null, plateau2.GetCase(0, 1).Joueur);
            Assert.AreEqual(null, plateau2.GetCase(0, 2).Joueur);
            Assert.AreEqual(null, plateau2.GetCase(1, 0).Joueur);
            Assert.AreEqual(null, plateau2.GetCase(1, 1).Joueur);
            Assert.AreEqual(morpion.Joueur1, plateau2.GetCase(1, 2).Joueur);
            Assert.AreEqual(null, plateau2.GetCase(2, 0).Joueur);
            Assert.AreEqual(null, plateau2.GetCase(2, 1).Joueur);
            Assert.AreEqual(null, plateau2.GetCase(2, 2).Joueur);


            Assert.AreEqual(morpion.PlateauJeu, plateau2);
        }
    }
}
