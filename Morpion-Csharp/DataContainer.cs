using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion_Csharp
{

    public class DataContainer
    {

        public string J1_Nom { get; set; }
        public string J2_Nom { get; set; }
        public string Titre { get; set; }
        public string Bouton_Jouer { get; set; }
        public string HistoriqueActions { get; set; }
        public string TexteIA { get; set; }

        public string TitreMessageErreur { get; set; }
        public string ErreurJ1Nom { get; set; }
        public string ErreurJ2Nom { get; set; }
        public string ErreurNomIdentique { get; set; }

        public string DebutPartie { get; set; }
        public string Contre { get; set; }
        public string Depart { get; set; }
        public string Commence { get; set; }
        public string TitrePartieLancee { get; set; }

        public string RemportePartie { get; set; }
        public string PartieGagneeTitre { get; set; }
        public string MatchNulItem { get; set; }
        public string MatchNulTexte { get; set; }
        public string MatchNulTitre { get; set; }

        public string CaseMarqueeTexte { get; set; }
        public string CaseMarqueeTitre { get; set; }
        public string VeuillezLancerPartie { get; set; }
        public string VeuillezLancerPartieTitre { get; set; }

        public string IA_1 { get; set; }
        public string IA_2 { get; set; }

        public string Menu_Langage { get; set; }
        public string Menu_Anglais { get; set; }
        public string Menu_Francais { get; set; }


        public DataContainer()
        {
            this.Anglais();
        }

        public void Francais()
        {
            this.Titre = "Morpion";
            this.J1_Nom = "Joueur 1 : ";
            this.J2_Nom = "Joueur 2 : ";
            this.TexteIA = "IA niveau ";
            this.Bouton_Jouer = "Jouer !";
            this.HistoriqueActions = "Historique des actions";

            this.TitreMessageErreur = "Erreur de saisie";
            this.ErreurJ1Nom = "Veuillez indiquer un nom pour le Joueur 1.";
            this.ErreurJ2Nom = "Veuillez indiquer un nom pour le Joueur 2.";
            this.ErreurNomIdentique = "Les deux joueurs ne peuvent pas avoir un nom identique.";

            this.DebutPartie = "Début de la partie : ";
            this.Contre = " contre ";
            this.Depart = "C'est parti ! ";
            this.Commence = " commence.";
            this.TitrePartieLancee = "Partie lancée";

            this.RemportePartie = " remporte la partie !";
            this.PartieGagneeTitre = "Nous avons un vainqueur";
            this.MatchNulItem = "Match nul !";
            this.MatchNulTitre = "Match nul";
            this.MatchNulTexte = "Aucun joueur ne remporte la partie.";

            this.CaseMarqueeTexte = "Cette case est déjà marquée.";
            this.CaseMarqueeTitre = "Impossible de cliquer ici";
            this.VeuillezLancerPartie = "Veuillez lancer une partie en appuyant sur le bouton Jouer.";
            this.VeuillezLancerPartieTitre = "Aucune partie lancée";

            this.IA_1 = "IA_1";
            this.IA_2 = "IA_2";

            this.Menu_Langage = "Langage";
            this.Menu_Anglais = "Anglais";
            this.Menu_Francais = "Français";
        }

        public void Anglais()
        {
            this.Titre = "Tic-Tac-Toe";
            this.J1_Nom = "Player 1 : ";
            this.J2_Nom = "Player 2 : ";
            this.TexteIA = "AI level ";
            this.Bouton_Jouer = "Play !";
            this.HistoriqueActions = "Move history";

            this.TitreMessageErreur = "Error";
            this.ErreurJ1Nom = "A name is required for Player 1.";
            this.ErreurJ2Nom = "A name is required for Player 2.";
            this.ErreurNomIdentique = "Both players cannot have the same name.";

            this.DebutPartie = "The game begins : ";
            this.Contre = " against ";
            this.Depart = "Let's go ! ";
            this.Commence = " starts.";
            this.TitrePartieLancee = "Game started";

            this.RemportePartie = " wins the game !";
            this.PartieGagneeTitre = "We have a winner";
            this.MatchNulItem = "Tied game !";
            this.MatchNulTitre = "Tied game";
            this.MatchNulTexte = "No player wins the game.";

            this.CaseMarqueeTexte = "This square has already been marked.";
            this.CaseMarqueeTitre = "Cannot click here";
            this.VeuillezLancerPartie = "Please start a game by pressing the Play button.";
            this.VeuillezLancerPartieTitre = "No game started";

            this.IA_1 = "AI_1";
            this.IA_2 = "AI_2";

            this.Menu_Langage = "Language";
            this.Menu_Anglais = "English";
            this.Menu_Francais = "French";
        }

    }
}
