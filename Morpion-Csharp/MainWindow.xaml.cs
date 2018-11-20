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

        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image img = sender as Image;
            BitmapImage marque;

            // On vérifie que la case ne soit pas déjà marquée
            if (img.Source.ToString() == "pack://application:,,,/Morpion-Csharp;component/Images/j0.png")
            {
                marque = new BitmapImage(new Uri("Images/j1.png", UriKind.Relative));
                img.Source = marque;
            }

            // Si la case est déjà marquée, on affiche un message d'erreur
            else
            {
                MessageBox.Show("Cette case est déjà marquée.", "Impossible de cliquer ici");
            }
        }
    }
}
