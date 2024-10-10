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
using System.Windows.Shapes;
using System.Windows.Media;

namespace project_1_game_inteact
{
    /// <summary>
    /// Interaction logic for start.xaml
    /// </summary>
    public partial class start : Window
    {
        public start()
        {
            InitializeComponent();
        }

        private void solo_Click(object sender, RoutedEventArgs e)
        {
            nspeler2.Visibility = Visibility.Hidden;
            lspeler2.Visibility = Visibility.Hidden;
            solo.Background = Brushes.LightGreen;
            duo.Background = Brushes.LightGray;
        }

        private void duo_Click(object sender, RoutedEventArgs e)
        {
            nspeler2.Visibility = Visibility.Visible;
            lspeler2.Visibility = Visibility.Visible;
            duo.Background = Brushes.LightGreen;
            solo.Background = Brushes.LightGray;
        }

        private void levels_Click(object sender, RoutedEventArgs e)
        {
            
            UItest.levels levels = new UItest.levels();
            levels.Show();
            this.Close();
        }

        private void handleiding2_Click(object sender, RoutedEventArgs e)
        {
            project_1_game_inteact.handleiding handleiding2 = new handleiding();
            handleiding2.Show();
            this.Close();
        }

        private void instellingen_Click(object sender, RoutedEventArgs e)
        {
            // als jelle gemerged heeft kan hier de code naar het instellingen scherm worden toegevoegd
        }
    }
}
