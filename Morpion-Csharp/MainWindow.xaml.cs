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
        /// Action effectuée quand une case détecte le clic d'un joueur.
        /// </summary>
        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;
            BitmapImage marque;

            // On vérifie que la case ne soit pas déjà marquée
            if (img.Source.ToString() == "pack://application:,,,/Morpion-Csharp;component/Images/j0.png")
            {
                marque = new BitmapImage(new Uri("Images/j1.png", UriKind.Relative));
                img.Source = marque;
                marquerCase(img.Name);
            }

            // Si la case est déjà marquée, on affiche un message d'erreur
            else
            {
                MessageBox.Show("Cette case est déjà marquée.", "Impossible de cliquer ici");
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
        }

    }
}
