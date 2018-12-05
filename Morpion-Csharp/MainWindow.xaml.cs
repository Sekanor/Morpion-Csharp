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

namespace Morpion_Csharp
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Morpion morpion;

        public MainWindow()
        {
            InitializeComponent();
            morpion = new Morpion();
        }


        /// <summary>
        /// Action effectuée lorsque l'utilisateur clique sur le bouton Jouer.
        /// </summary>
        private void BoutonJouer_Click(object sender, RoutedEventArgs e)
        {
            String J1 = textBoxJoueur1.Text;
            
            // Si le champ Joueur 1 n'est pas vide
            if (J1 != "")
            {
                // Partie Joueur VS Joueur
                if (Convert.ToBoolean(radioJoueur.IsChecked))
                {
                    String J2 = textBoxJoueur2.Text;

                    // Si le champ Joueur 2 n'est pas vide
                    if (J2 != "")
                    {
                        // Si les deux joueurs n'ont pas le même nom
                        if (J1 != J2)
                        {
                            morpion.Initialisation(J1, J2);
                            NettoyerPlateau(); // Nettoyage du plateau
                            listeActions.Items.Clear(); // Nettoyage de l'historique des actions
                            listeActions.Items.Add("Début de la partie: " + morpion.Joueur1.Nom + " contre " + morpion.Joueur2.Nom);
                            MessageBox.Show("C'est parti ! " + morpion.Joueur1.Nom + " commence.", "Partie lancée", MessageBoxButton.OK, MessageBoxImage.Information);
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
                    // TODO : Lancer une partie avec une I.A. simple
                }

                // Partie Joueur VS I.A. complexe
                else if (Convert.ToBoolean(radioSimple.IsChecked))
                {
                    // TODO : Lancer une partie avec une I.A. complexe
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
        /// Action effectuée quand une case détecte le clic d'un joueur.
        /// </summary>
        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;
            BitmapImage marque = new BitmapImage(new Uri("Images/j0.png", UriKind.Relative));

            // Si une partie de Morpion est en cours
            if (morpion.EnJeu)
            {
                // On vérifie que la case ne soit pas déjà marquée
                if (img.Source.ToString() == "pack://application:,,,/Morpion-Csharp;component/Images/j0.png")
                {
                    if (morpion.JoueurCourant.Equals(morpion.Joueur1))
                    {
                        marque = new BitmapImage(new Uri("Images/j1.png", UriKind.Relative));
                    }
                    else if (morpion.JoueurCourant.Equals(morpion.Joueur2))
                    {
                        marque = new BitmapImage(new Uri("Images/j2.png", UriKind.Relative));
                    }

                    img.Source = marque; // Marquage visuel de la case (on remplace l'image)
                    marquerCase(img.Name); // Marquage logique de l'image
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
        /// Marque la case logique associée à l'image dont le nom est passé en paramètre.
        /// </summary>
        /// <param name="imgName">Nom de l'image dont on doit marquer la case logique correspondante.</param>
        private void marquerCase(String imgName)
        {
            String nomCase = "";

            switch (imgName)
            {
                case "imgTL":
                    morpion.Tour(0, 0);
                    nomCase = "A1";
                    break;
                case "imgTC":
                    morpion.Tour(1, 0);
                    nomCase = "B1";
                    break;
                case "imgTR":
                    morpion.Tour(2, 0);
                    nomCase = "C1";
                    break;

                case "imgML":
                    morpion.Tour(0, 1);
                    nomCase = "A2";
                    break;
                case "imgMC":
                    morpion.Tour(1, 1);
                    nomCase = "B2";
                    break;
                case "imgMR":
                    morpion.Tour(2, 1);
                    nomCase = "C2";
                    break;

                case "imgBL":
                    morpion.Tour(0, 2);
                    nomCase = "A3";
                    break;
                case "imgBC":
                    morpion.Tour(1, 2);
                    nomCase = "B3";
                    break;
                case "imgBR":
                    morpion.Tour(2, 2);
                    nomCase = "C3";
                    break;
            }

            listeActions.Items.Add(morpion.JoueurCourant.Nom + ": " + nomCase);

            // On regarde si, suite à ce tour, la partie a un vainqueur
            VerifierVictoire();
        }


        /// <summary>
        /// Vérifie si un des deux joueurs est victorieux, ou s'il y a match nul
        /// </summary>
        private void VerifierVictoire()
        {
            // Le joueur 1 remporte la partie
            if (morpion.Vainqueur == morpion.Joueur1)
            {
                listeActions.Items.Add(morpion.Joueur1.Nom + " remporte la partie !");
                MessageBox.Show(morpion.Joueur1.Nom + " remporte la partie !", "Nous avons un vainqueur", MessageBoxButton.OK, MessageBoxImage.Information);
                NettoyerPlateau();
            }

            // Le joueur 2 remporte la partie
            else if (morpion.Vainqueur == morpion.Joueur2)
            {
                listeActions.Items.Add(morpion.Joueur2.Nom + " remporte la partie !");
                MessageBox.Show(morpion.Joueur2.Nom + " remporte la partie !", "Nous avons un vainqueur", MessageBoxButton.OK, MessageBoxImage.Information);
                NettoyerPlateau();
            }

            // Match nul
            else if (morpion.PlateauJeu.VerifierPlateauRempli())
            {
                listeActions.Items.Add("Match nul !");
                MessageBox.Show("Match nul", "Aucun joueur ne remporte la partie.", MessageBoxButton.OK, MessageBoxImage.Information);
                NettoyerPlateau();
            }
        }


        /// <summary>
        /// Réinitialise les images du plateau
        /// </summary>
        private void NettoyerPlateau()
        {
            foreach (Image img in grillePlateau.Children)
            {
                img.Source = new BitmapImage(new Uri("Images/j0.png", UriKind.Relative));
            }
        }
    }
}
