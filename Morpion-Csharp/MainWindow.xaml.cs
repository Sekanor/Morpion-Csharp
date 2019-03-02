using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Morpion_métier;
using Morpion_métier.IntelligencesArficielles;

namespace Morpion_Csharp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Morpion morpion;
        private PlateauIHM plateauIHM;

        private String j1;
        private String j2;
        private IA ia;
        private Boolean partieIA;

        public MainWindow()
        {
            InitializeComponent();
            morpion = new Morpion();
            partieIA = false;


            plateauIHM = new PlateauIHM(morpion.PlateauJeu);

            this.plateauIHM.AjouterCaseIHM(new CaseIHM(morpion.PlateauJeu.GetCase(0, 0), A1));
            this.plateauIHM.AjouterCaseIHM(new CaseIHM(morpion.PlateauJeu.GetCase(1, 0), B1));
            this.plateauIHM.AjouterCaseIHM(new CaseIHM(morpion.PlateauJeu.GetCase(2, 0), C1));

            this.plateauIHM.AjouterCaseIHM(new CaseIHM(morpion.PlateauJeu.GetCase(0, 1), A2));
            this.plateauIHM.AjouterCaseIHM(new CaseIHM(morpion.PlateauJeu.GetCase(1, 1), B2));
            this.plateauIHM.AjouterCaseIHM(new CaseIHM(morpion.PlateauJeu.GetCase(2, 1), C2));

            this.plateauIHM.AjouterCaseIHM(new CaseIHM(morpion.PlateauJeu.GetCase(0, 2), A3));
            this.plateauIHM.AjouterCaseIHM(new CaseIHM(morpion.PlateauJeu.GetCase(1, 2), B3));
            this.plateauIHM.AjouterCaseIHM(new CaseIHM(morpion.PlateauJeu.GetCase(2, 2), C3));

        }


        /// <summary>
        /// Action effectuée lorsque l'utilisateur clique sur le bouton Jouer.
        /// </summary>
        private void BoutonJouer_Click(object sender, RoutedEventArgs e)
        {
            j1 = textBoxJoueur1.Text;
            j2 = "";

            // Si le champ Joueur 1 n'est pas vide
            if (j1 != "")
            {
                // Partie Joueur VS Joueur
                if (Convert.ToBoolean(radioJoueur.IsChecked))
                {
                    j2 = textBoxJoueur2.Text;

                    // Si le champ Joueur 2 n'est pas vide
                    if (j2 != "")
                    {
                        // Si les deux joueurs n'ont pas le même nom
                        if (j1 != j2)
                        {
                            partieIA = false;
                            InitialiserMorpion(j1, j2);
                        }
                        // Si les deux joueurs ont le même nom, on affiche un message d'erreur
                        else
                        {
                            MessageBox.Show("Les deux joueurs ne peuvent pas avoir un nom identique.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    // Si le champ Joueur 2 est vide, on affiche un message d'erreur
                    else
                    {
                        MessageBox.Show("Veuillez indiquer un nom pour le Joueur 2.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

                // Partie Joueur VS I.A. simple
                else if (Convert.ToBoolean(radioSimple.IsChecked))
                {
                    j2 = "I.A. Simple";
                    ia = new IA_Flexible(morpion.PlateauRestreint);
                    ((IA_Flexible)ia).Niveau = 90;
                    
                    InitialiserMorpion(j1, j2);
                    partieIA = true;
                }

                // Partie Joueur VS I.A. complexe
                else if (Convert.ToBoolean(radioComplexe.IsChecked))
                {
                    j2 = "I.A. Complexe";
                    ia = new IA_Parfaite(morpion.PlateauRestreint);
                    InitialiserMorpion(j1, j2);
                    partieIA = true;
                }

                // Aucun type de partie sélectionné
                else
                {
                    MessageBox.Show("Veuillez indiquer le type de partie que vous souhaitez jouer.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            // Si le champ Joueur 1 est vide, on affiche un message d'erreur
            else
            {
                MessageBox.Show("Veuillez indiquer un nom pour le Joueur 1.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Initialise la partie de Morpion avec les joueurs donnés
        /// </summary>
        /// <param name="J1">Nom du Joueur 1</param>
        /// <param name="J2">Nom du Joueur 2</param>
        public void InitialiserMorpion(String J1, String J2)
        {
            morpion.Initialisation(J1, J2);
            plateauIHM.Nettoyer(); // Nettoyage du plateau
            listeActions.Items.Clear(); // Nettoyage de l'historique des actions
            listeActions.Items.Add("Début de la partie: " + morpion.Joueur1.Nom + " contre " + morpion.Joueur2.Nom);
            MessageBox.Show("C'est parti ! " + morpion.Joueur1.Nom + " commence.", "Partie lancée", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        /// <summary>
        /// Action effectuée quand une case détecte le clic d'un joueur.
        /// </summary>
        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;

            // Si une partie de Morpion est en cours
            if (morpion.EnJeu)
            {
                // On vérifie que la case ne soit pas déjà marquée
                if (plateauIHM.GetCase(img.Name).GetCaseMorpion().Joueur == null)
                {
                    listeActions.Items.Add(morpion.JoueurCourant.Nom + ": " + img.Name);
                    plateauIHM.GetCase(img.Name).Marquer(morpion.JoueurCourant);
                    VerifierVictoire();

                    // L'IA joue
                    if (partieIA && morpion.EnJeu)
                    {
                        Position pos = ia.Jouer();
                        listeActions.Items.Add(morpion.JoueurCourant.Nom + ": " + plateauIHM.GetCase(pos.X, pos.Y).GetImage().Name);
                        plateauIHM.GetCase(pos.X, pos.Y).Marquer(morpion.JoueurCourant);
                        VerifierVictoire();
                    }
                }

                // Si la case est déjà marquée, on affiche un message d'erreur
                else
                {
                    MessageBox.Show("Cette case est déjà marquée.", "Impossible de cliquer ici", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            // Si aucune partie n'est lancée, on affiche un message d'erreur
            else
            {
                MessageBox.Show("Veuillez lancer une partie en appuyant sur le bouton Jouer.", "Aucune partie lancée", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }


        /// <summary>
        /// Vérifie si un des deux joueurs est victorieux, ou s'il y a match nul
        /// </summary>
        private void VerifierVictoire()
        {
            if (morpion.Vainqueur != null)
            {
                listeActions.Items.Add(morpion.Vainqueur.Nom + " remporte la partie !");
                MessageBox.Show(morpion.Vainqueur.Nom + " remporte la partie !", "Nous avons un vainqueur", MessageBoxButton.OK, MessageBoxImage.Information);
                plateauIHM.Nettoyer();
            }

            // Match nul
            else if (morpion.PlateauJeu.VerifierPlateauRempli())
            {
                listeActions.Items.Add("Match nul !");
                MessageBox.Show("Match nul", "Aucun joueur ne remporte la partie.", MessageBoxButton.OK, MessageBoxImage.Information);
                plateauIHM.Nettoyer();
            }
        }

    }
}
