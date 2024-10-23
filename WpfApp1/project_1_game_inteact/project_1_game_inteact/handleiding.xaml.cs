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
        hnd_txt.Content = "Hier is een uitleg over hoe je de auto's in het spel kunt laten bewegen.\r\n\r\nDe Auto aan de linkerkant van het scherm:\r\nDruk op de knop A om de auto naar links te laten rijden.\r\nDruk op de knop D om de auto naar rechts te laten rijden.\r\n\r\nDe auto aan de rechterkant van het scherm:\r\nDruk op de pijl naar links (←) om de auto naar links te laten rijden.\r\nDruk op de pijl naar rechts (→) om de auto naar rechts te laten rijden."; // handleiding van de besturing
        }

        private void spelen_Click(object sender, RoutedEventArgs e)
        {
            hnd_txt.Content = ""; // maakt de string leeg zodra er op de knop wordt gedrukt van de handleiding
            hnd_txt.Content = "Voordat je kunt beginnen met racen, moet je eerst je naam invullen.\r\nSpeler 1 vult zijn of haar naam in voor de linker auto.\r\nSpeler 2 vult zijn of haar naam in voor de rechter auto.\r\n\r\nHoe werkt de race?\r\nJe auto begint bij de start.\r\nHet doel is om zo snel mogelijk naar de finish te komen!\r\nBovenin het scherm zie je de tijd lopen.\r\nZodra je over de finish komt, stopt je auto vanzelf."; // handleiding van het spel
        }

        private void punten_Click(object sender, RoutedEventArgs e)
        {
            hnd_txt.Content = ""; // maakt de string leeg zodra er op de knop wordt gedrukt van de handleiding
            hnd_txt.Content = "Hoe verdien je punten?\r\nHoe sneller je bij de finish bent, hoe meer punten je krijgt.\r\n\r\nWat kun je met de punten? \r\nMet de punten kun je leuke upgrades kopen voor je auto, zoals snellere wielen of een coole motor!"; // handleiding van de punten
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            start start2 = new start();
            start2.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
