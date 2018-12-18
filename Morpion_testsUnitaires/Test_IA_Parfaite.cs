using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morpion_métier;

namespace Morpion_testsUnitaires
{
    [TestClass]
    public class Test_IA_Parfaite
    {
        /// <summary>
        /// Teste l'IA dans une situation évidente de jeu; on vérifie alors
        /// qu'elle joue le coup lui permettant de remporter la partie.
        /// </summary>
        [TestMethod]
        public void TestIABasique()
        {

            Morpion morpion = new Morpion();
            morpion.Initialisation("IA_Evoluee", "Joueur");
            Position pos;

            IA_Parfaite ia = new IA_Parfaite(morpion.PlateauRestreint);

            morpion.Tour(1, 1);
            morpion.Tour(0, 1);
            morpion.Tour(0, 0);
            morpion.Tour(2, 2);
            morpion.Tour(2, 0);
            morpion.Tour(0, 2);

            pos = ia.Jouer();
            morpion.Tour(pos.X, pos.Y);
            morpion.PlateauJeu.Afficher();

            Assert.AreEqual(morpion.Joueur1, morpion.PlateauJeu.GetCase(1, 0).Joueur);

        }

        /// <summary>
        /// Exécute un match entre deux IA parfaites.
        /// Le match doit toujours être un match nul : si ce n'est pas le cas,
        /// l'une des deux IAs a mal joué; et donc, le code de
        /// l'IA parfaite devra être revu.
        /// </summary>
        [TestMethod]
        public void ParfaiteContreParfaite()
        {

            Morpion morpion = new Morpion();
            morpion.Initialisation("IA_Evoluee", "Joueur");
            Position pos;

            IA_Parfaite perf = new IA_Parfaite(morpion.PlateauRestreint);
            IA_Aleatoire alea = new IA_Aleatoire(morpion.PlateauRestreint);
            IA_Evoluee evol = new IA_Evoluee(morpion.PlateauRestreint);

            for (int i = 0; i < 9; i++)
            {
                if (i % 2 == 0)
                {
                    pos = perf.Jouer();
                }
                else
                {
                    pos = perf.Jouer();
                }
                morpion.Tour(pos.X, pos.Y);
                morpion.PlateauJeu.Afficher();
            }

            // Entre deux IA parfaites, il doit toujours y avoir match nul.
            Assert.AreEqual(morpion.Vainqueur, null);

        }

        /// <summary>
        /// Exécute un match entre l'IA parfaite et l'IA évoluée.
        /// L'IA parfaite remporte le match la plupart du temps, en exploitant
        /// les erreurs de l'IA évoluée.
        /// </summary>
        [TestMethod]
        public void ParfaiteContreEvoluee()
        {

            Morpion morpion = new Morpion();
            morpion.Initialisation("IA_Evoluee", "Joueur");
            Position pos;

            IA_Parfaite perf = new IA_Parfaite(morpion.PlateauRestreint);
            IA_Aleatoire alea = new IA_Aleatoire(morpion.PlateauRestreint);
            IA_Evoluee evol = new IA_Evoluee(morpion.PlateauRestreint);

            for (int i = 0; i < 9; i++)
            {
                if (i % 2 == 0)
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

        }
    }
}