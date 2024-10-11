using project_1_game_inteact;
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

namespace UItest
{
    /// <summary>
    /// Interaction logic for levels.xaml
    /// </summary>
    public partial class levels : Window
    {
        public levels()
        {
            InitializeComponent();

           


        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UItest.MainWindow secondWindow = new UItest.MainWindow();
            secondWindow.Show();
        }
        private void upgrades_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Upgrades upgradesWindow = new Upgrades();
            upgradesWindow.Show();
        }
        private void level1_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            start start = new start();
            start.Show();

        }
    }
}
