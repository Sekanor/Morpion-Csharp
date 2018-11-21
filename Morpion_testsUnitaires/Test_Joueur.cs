using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morpion_métier;

namespace Morpion_testsUnitaires
{
    [TestClass]
    public class Test_Joueur
    {
        [TestMethod]
        public void TestEquals()
        {
            Joueur j  = new Joueur(3);
            Joueur j2 = new Joueur(3);
            Joueur j3 = new Joueur(4);
            Assert.AreEqual(j, j2);
            Assert.AreNotEqual(j, j3);
            
        }
    }
}
