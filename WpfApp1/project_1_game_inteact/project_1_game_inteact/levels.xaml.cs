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
using static project_1_game_inteact.start;
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
            BackgroundMusicPlayer.Instance.Play();



        }

        private void Startscherm_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            start start = new start();
            start.Show();
            this.Close();
        }
        private void upgrades_click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Upgrades upgradesWindow = new Upgrades();
            upgradesWindow.Show();
            this.Close();
        }
        private void level1_click(object sender, RoutedEventArgs e)
        {
            SharedData.Instance.levels = 1;
            this.Hide();
            Spel_scherm spel = new Spel_scherm();
            spel.Show();
            this.Close();


        }
        private void level2_click(object sender, RoutedEventArgs e)
        {
            SharedData.Instance.levels = 2;
            this.Hide();
            Spel_scherm spel = new Spel_scherm();
            spel.Show();
            this.Close();

            
        }
        private void level3_click(object sender, RoutedEventArgs e)
        {

            SharedData.Instance.levels = 3;
            this.Hide();
            Spel_scherm spel = new Spel_scherm();
            spel.Show();
            this.Close();
           

        }
    }
}
