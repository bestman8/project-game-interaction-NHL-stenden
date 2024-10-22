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
    /// Interaction logic for instellingen.xaml
    /// </summary>
    public partial class instellingen : Window
    {
        private MediaPlayer mediaPlayer;

        public instellingen()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            PlayBackgroundMusic();
        }

        private void PlayBackgroundMusic()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("pack://application:,,,/BackMusic.mp3"));
            mediaPlayer.Volume = 1;  // Set the volume (0.0 to 1.0)
            mediaPlayer.Play();
        }

        private void Startscherm_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            project_1_game_inteact.start start2 = new project_1_game_inteact.start();
            start2.Show();
            this.Close();
        }
    }
}
