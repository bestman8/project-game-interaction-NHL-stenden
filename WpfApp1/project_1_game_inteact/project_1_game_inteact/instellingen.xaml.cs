using System;
using System.Windows;
using System.Windows.Controls;

namespace UItest
{
    /// <summary>
    /// Interaction logic for instellingen.xaml
    /// </summary>
    public partial class instellingen : Window
    {
        public instellingen()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            // Zet de slider op het huidige volume van de muziek
            volumeSlider.Value = BackgroundMusicPlayer.Instance.GetVolume();
        }

        private void Startscherm_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            project_1_game_inteact.start start2 = new project_1_game_inteact.start();
            start2.Show();
            this.Close();
        }

        // Event handler voor het aanpassen van het volume
        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (BackgroundMusicPlayer.Instance != null)
            {
                // Stel het volume in op basis van de sliderwaarde
                BackgroundMusicPlayer.Instance.SetVolume(volumeSlider.Value);
            }
        }
    }
}
