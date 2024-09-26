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
using UItest;

namespace project_1_game_inteact
{
    /// <summary>
    /// Interaction logic for Upgrades.xaml
    /// </summary>
    public partial class Upgrades : Window
    {
        public Upgrades()
        {
            InitializeComponent();
        }

        private void LevelsClick(object sender, RoutedEventArgs e)
        {
            levels gm = new levels();
            gm.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void StartschermClick(object sender, RoutedEventArgs e)
        {
            MainWindow gm = new MainWindow();
            gm.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
    }
}
