using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morpion_métier;

namespace Morpion_testsUnitaires
{
    [TestClass]
    public class Test_Case
    {
        [TestMethod]
        public void Test_Marquer()
        {
            Plateau plateau = new Plateau(new Morpion());
            Case c = new Case(plateau);
            Joueur j1 = new Joueur(1);
            Joueur j2 = new Joueur(2);

            // On vérifie si la case n'est pas marquée quand elle est initialisée.
            Assert.AreEqual(null, c.Joueur);

            // On vérifie si la case se marque bien.
            Boolean aBienMarque =  c.Marquer(j1);
            Assert.AreEqual(j1, c.Joueur);
            Assert.AreEqual(true, aBienMarque);

            // On vérifie si la case ne peut être marquée, lorsqu'elle est marquée plusieurs fois.
            aBienMarque = c.Marquer(j2);
            Assert.AreEqual(j1, c.Joueur);
            Assert.AreEqual(false, aBienMarque);
        }
    }
}
