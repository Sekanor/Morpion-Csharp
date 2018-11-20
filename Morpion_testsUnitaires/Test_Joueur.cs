using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morpion_métier;

namespace Morpion_testsUnitaires
{
    [TestClass]
    public class Test_Joueur
    {
        [TestMethod]
        public void TestConstructeur()
        {
            Joueur joueur = new Joueur("Michel");
            Assert.AreEqual("Michel", joueur.Nom);
        }
    }
}
