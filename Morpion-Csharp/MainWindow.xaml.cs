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
            String J2 = textBoxJoueur2.Text;

            // Si les champs Joueur1 et Joueur2 ne sont pas vides, on lance la partie
            if (J1 != "" && J2 != "")
            {
                morpion.Initialisation(J1, J2);
                NettoyerPlateau();
                MessageBox.Show("C'est parti ! " + morpion.Joueur1.Nom + " commence.", "Partie lancée");
            }

            // Si l'un des deux champs est vide, on affiche un message d'erreur
            else
            {
                MessageBox.Show("Veuillez indiquer le nom des deux joueurs avant de lancer une partie.", "Erreur de saisie");
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
                    MessageBox.Show("Cette case est déjà marquée.", "Impossible de cliquer ici");
                }
            }

            // Si aucune partie n'est lancée, on affiche un message d'erreur
            else
            {
                MessageBox.Show("Aucune partie lancée", "Veillez à lancer une partie en appuyant sur le bouton Jouer.");
            }

        }


        /// <summary>
        /// Marque la case logique associée à l'image dont le nom est passé en paramètre.
        /// </summary>
        /// <param name="imgName">Nom de l'image dont on doit marquer la case logique correspondante.</param>
        private void marquerCase(String imgName)
        {
            switch (imgName)
            {
                case "imgTL":
                    morpion.Tour(0, 0);
                    break;
                case "imgTC":
                    morpion.Tour(1, 0);
                    break;
                case "imgTR":
                    morpion.Tour(2, 0);
                    break;

                case "imgML":
                    morpion.Tour(0, 1);
                    break;
                case "imgMC":
                    morpion.Tour(1, 1);
                    break;
                case "imgMR":
                    morpion.Tour(2, 1);
                    break;

                case "imgBL":
                    morpion.Tour(0, 2);
                    break;
                case "imgBC":
                    morpion.Tour(1, 2);
                    break;
                case "imgBR":
                    morpion.Tour(2, 2);
                    break;
            }

            // On regarde si, suite à ce tour, la partie a un vainqueur
            VerifierVictoire();
        }


        /// <summary>
        /// Vérifie si un des deux joueurs est victorieux
        /// </summary>
        private void VerifierVictoire()
        {
            if (morpion.Vainqueur == morpion.Joueur1)
            {
                MessageBox.Show(morpion.Joueur1.Nom + " remporte la partie !", "Nous avons un vainqueur");
                NettoyerPlateau();
            }
            else if (morpion.Vainqueur == morpion.Joueur2)
            {
                MessageBox.Show(morpion.Joueur2.Nom + " remporte la partie !", "Nous avons un vainqueur");
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
