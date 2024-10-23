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
    /// Interaction logic for handleiding.xaml
    /// </summary>
    public partial class handleiding : Window
    {
        public handleiding()
        {
            InitializeComponent();
            BackgroundMusicPlayer.Instance.Play();
        }



        private void txtfunctiongame()
        {
           
        }

        private void bewegen_Click(object sender, RoutedEventArgs e)
        {
        hnd_txt.Content = ""; // maakt de string leeg zodra er op de knop wordt gedrukt van de handleiding
        hnd_txt.Content = ""; // handleiding van het spel
        }

        private void upgrades_Click(object sender, RoutedEventArgs e)
        {
            hnd_txt.Content = ""; // maakt de string leeg zodra er op de knop wordt gedrukt van de handleiding
            hnd_txt.Content = ""; // handleiding van het upgraden
        }

        private void instellingen_Click(object sender, RoutedEventArgs e)
        {
            hnd_txt.Content = ""; // maakt de string leeg zodra er op de knop wordt gedrukt van de handleiding
            hnd_txt.Content = ""; // handleiding van de instellingen
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            start start2 = new start();
            start2.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
