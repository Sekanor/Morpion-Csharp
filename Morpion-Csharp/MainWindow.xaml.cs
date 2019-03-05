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
        private IA iaJ1;
        private IA iaJ2;
        private Boolean partieIA;

        public MainWindow()
        {
            InitializeComponent();
            morpion = new Morpion();
            partieIA = false;

            plateauIHM = new PlateauIHM(morpion.PlateauJeu);

            // Création des cases de l'IHM
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
            j2 = textBoxJoueur2.Text;

            if (EstIA(1)) j1 = "IA_1";
            if (EstIA(2)) j2 = "IA_2";

            // Gestion des erreurs
            if (j1 == "")
            {
                MessageBox.Show("Veuillez indiquer un nom pour le Joueur 1.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (j2 == "")
            {
                MessageBox.Show("Veuillez indiquer un nom pour le Joueur 2.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (j1 == j2)
            {
                MessageBox.Show("Les deux joueurs ne peuvent pas avoir un nom identique.", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            partieIA = (EstIA(1) || EstIA(2));

            if (checkBoxIAJ1.IsChecked == true)
            {
                iaJ1 = new IA_Flexible(morpion.PlateauRestreint, Convert.ToInt32(sliderLevelJ1.Value));
            }
            if (checkBoxIAJ2.IsChecked == true)
            {
                iaJ2 = new IA_Flexible(morpion.PlateauRestreint, Convert.ToInt32(sliderLevelJ2.Value));
            }
            
            InitialiserMorpion(j1, j2);

            // On fait jouer la (les) IAs.
            CoupIA();
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
                    Jouer(img);

                    // L'IA joue
                    CoupIA();
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

                GererScore();
            }

            // Match nul
            else if (morpion.PlateauJeu.VerifierPlateauRempli())
            {
                listeActions.Items.Add("Match nul !");
                MessageBox.Show("Match nul", "Aucun joueur ne remporte la partie.", MessageBoxButton.OK, MessageBoxImage.Information);
                plateauIHM.Nettoyer();
                GererScore();
            }
        }

        /// <summary>
        /// Effectue un coup sur une case précise du plateau.
        /// </summary>
        /// <param name="img">Image représentant la case du plateau sur laquelle on va jouer.</param>
        private void Jouer(Image img)
        {
            listeActions.Items.Add(morpion.JoueurCourant.Nom + ": " + img.Name);
            plateauIHM.GetCase(img.Name).Marquer(morpion.JoueurCourant);
            VerifierVictoire();
        }

        /// <summary>
        /// Retourne true si le joueur en question est une IA.
        /// </summary>
        /// <param name="joueur">ID du joueur en question.</param>
        /// <returns>True s'il s'agit d'une IA.</returns>
        private Boolean EstIA(int joueur)
        {
            Boolean estIA;

            switch(joueur)
            {
                case 1:
                    estIA = Convert.ToBoolean(checkBoxIAJ1.IsChecked);
                    break;
                case 2:
                    estIA = Convert.ToBoolean(checkBoxIAJ2.IsChecked);
                    break;
                default:
                    estIA = false;
                    break;
            }

            return estIA;
        }

        /// <summary>
        /// Exécute un, ou plusieurs coups de l'IA, s'il y a lieu.
        /// </summary>
        private void CoupIA()
        {
            Boolean coupIA = true;
            do
            {
                if (morpion.JoueurCourant.Equals(morpion.Joueur1))
                {
                    if (EstIA(1))
                    {
                        Position pos = iaJ1.Jouer();
                        Jouer(plateauIHM.GetCase(pos.X, pos.Y).GetImage());
                    }
                    else
                    {
                        coupIA = false;
                    }
                }
                else
                {
                    if (EstIA(2))
                    {
                        Position pos = iaJ2.Jouer();
                        Jouer(plateauIHM.GetCase(pos.X, pos.Y).GetImage());
                    }
                    else
                    {
                        coupIA = false;
                    }
                }
            } while (coupIA && morpion.EnJeu);
        }

        /// <summary>
        /// Méthode gérant l'évolution du score des deux joueurs.
        /// </summary>
        private void GererScore()
        {
            if (morpion.Joueur1.Equals(morpion.Vainqueur))
            {
                scoreJ1.Content = Convert.ToString(Convert.ToDouble(scoreJ1.Content) + 1);
            }
            else if (morpion.Joueur2.Equals(morpion.Vainqueur))
            {
                scoreJ2.Content = Convert.ToString(Convert.ToDouble(scoreJ2.Content) + 1);
            }
            else
            {
                scoreJ1.Content = Convert.ToString(Convert.ToDouble(scoreJ1.Content) + 0.5);
                scoreJ2.Content = Convert.ToString(Convert.ToDouble(scoreJ2.Content) + 0.5);
            }
        }


        /// <summary>
        /// Se déclenche lorsqu'on clique sur la checkbox IA du joueur 1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxIAJ1_Click(object sender, RoutedEventArgs e)
        {
            sliderLevelJ1.IsEnabled = !sliderLevelJ1.IsEnabled;
        }

        /// <summary>
        /// Se déclenche lorsqu'on clique sur la checkbox IA du joueur 2.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxIAJ2_Click(object sender, RoutedEventArgs e)
        {
            sliderLevelJ2.IsEnabled = !sliderLevelJ2.IsEnabled;
        }

        /// <summary>
        /// Se déclenche lorsque le slider représentant le niveau de difficulté de l'IA_1 change de valeur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SliderLevelJ1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            checkBoxIAJ1.Content = "IA niveau " + Convert.ToInt32(sliderLevelJ1.Value);
        }

        /// <summary>
        /// Se déclenche lorsque le slider représentant le niveau de difficulté de l'IA_2 change de valeur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SliderLevelJ2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            checkBoxIAJ2.Content = "IA niveau " + Convert.ToInt32(sliderLevelJ2.Value);
        }
    }
}
