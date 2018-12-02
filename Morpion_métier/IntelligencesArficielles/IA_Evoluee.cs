using System;
using System.Collections.Generic;
using System.Text;

namespace Morpion_métier
{
    /// <summary>
    /// Cette IA joue semi-intelligement, en bloquant la troisième case d'une ligne gagnante de l'adversaire.
    /// 
    /// L'IA évoluée suit quatre règles, dans l'ordre :
    /// 1. Si l'IA joue en premier, elle joue au centre.
    /// 2. Si l'adversaire joue au centre en premier, 
    ///    l'IA joue dans une diagonale.
    /// 3. Si l'IA détecte une case pouvant faire gagner l'adversaire,
    ///    elle joue dans cette case.
    /// 4. Si l'IA ne sait pas quoi jouer, elle joue aléatoirement.
    /// </summary>
    public class IA_Evoluee : IA
    {

        public IA_Evoluee(PlateauRestreint p) : base(p)
        {

        }

        public override Position Jouer()
        {
            // Code TRES factorisable

            Position pos = null;

            // 1. Si l'IA joue en premier, elle joue au centre.
            Boolean estVide = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    estVide = estVide && (this.Plateau.GetCase(i, j).EstMarquee() == null);
                }
            }

            if (estVide)
            {
                pos = new Position(1, 1);
            }

            // 2. Si l'adversaire joue au centre en premier, l'IA joue dans une diagonale.
            if (pos == null)
            {

                if (this.Plateau.GetCase(1, 1).EstMarquee() != this.Plateau.JoueurCourant
                    && this.Plateau.GetCase(1, 1).EstMarquee() != null)
                {
                    // Cela signifie que l'autre joueur a joué dans cette case.

                    // On vérifie si le plateau est vide hormis cette case.
                    Boolean estPresqueVide = true;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; i < 3; i++)
                        {
                            if (!(i == 1 && j == 1))
                            {
                                estPresqueVide = estPresqueVide && (this.Plateau.GetCase(i, j).EstMarquee() == null);
                            }
                        }
                    }

                    if (estPresqueVide)
                    {
                        // On pourrait faire un aléatoire pour décider de la diagonale jouée.
                        pos = new Position(0, 0);
                    }
                }

            }

            // 3. Si l'IA détecte une case pouvant faire gagner l'adversaire, elle joue dans cette case.
            if (pos == null)
            {
                
                // Lignes
                for(int i = 0; i < 3; i++)
                {
                    // On veut que adversaire = 2 et nonJouee = 1.
                    int adversaire = 0;
                    int nonJouee = 0;
                    Position posNonJouee = null;

                    for (int j = 0; j < 3; j++)
                    {
                        if (CaseAdversaire(i,j))
                        {
                            adversaire++;
                        }
                        if (CaseNonJouee(i,j))
                        {
                            nonJouee++;
                            posNonJouee = new Position(i, j);
                        }

                        if (adversaire == 2 && nonJouee == 1)
                        {
                            pos = posNonJouee;
                        }
                    }
                }

                // Colonnes
                for (int i = 0; i < 3; i++)
                {
                    // On veut que adversaire = 2 et nonJouee = 1.
                    int adversaire = 0;
                    int nonJouee = 0;
                    Position posNonJouee = null;

                    for (int j = 0; j < 3; j++)
                    {
                        if (CaseAdversaire(j, i))
                        {
                            adversaire++;
                        }
                        if (CaseNonJouee(j, i))
                        {
                            nonJouee++;
                            posNonJouee = new Position(j, i);
                        }

                        if (adversaire == 2 && nonJouee == 1)
                        {
                            pos = posNonJouee;
                        }
                    }
                }

                // TL-BR
                for (int i = 0; i < 3; i++)
                {
                    // On veut que adversaire = 2 et nonJouee = 1.
                    int adversaire = 0;
                    int nonJouee = 0;
                    Position posNonJouee = null;

                    if (CaseAdversaire(i, i))
                    {
                        adversaire++;
                    }
                    if (CaseNonJouee(i, i))
                    {
                        nonJouee++;
                        posNonJouee = new Position(i, i);
                    }
                    if (adversaire == 2 && nonJouee == 1)
                    {
                        pos = posNonJouee;
                    }
                }

                // BL-TR
                for (int i = 0; i < 3; i++)
                {
                    // On veut que adversaire = 2 et nonJouee = 1.
                    int adversaire = 0;
                    int nonJouee = 0;
                    Position posNonJouee = null;

                    if (CaseAdversaire(2-i, i))
                    {
                        adversaire++;
                    }
                    if (CaseNonJouee(2-i, i))
                    {
                        nonJouee++;
                        posNonJouee = new Position(2-i, i);
                    }
                    if (adversaire == 2 && nonJouee == 1)
                    {
                        pos = posNonJouee;
                    }
                }

            }

            // 4. Si l'IA ne sait pas quoi jouer, elle joue aléatoirement.
            if (pos == null)
            {
                IA_Aleatoire rand = new IA_Aleatoire(this.Plateau);
                pos = rand.Jouer();
            }

            return pos;
        }

    }
}
