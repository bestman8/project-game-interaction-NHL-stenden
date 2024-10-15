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
using System.Windows.Threading;

namespace project_1_game_inteact
{
    /// <summary>
    /// Interaction logic for Spel_scherm.xaml
    /// </summary>
    public partial class Spel_scherm : Window
    {
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private int tijd = 0;
        int Countdown = 5;
        bool Go = false;

        public Spel_scherm()
        {
            InitializeComponent();
            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += Timer;
            gameTimer.Start();
        }
        //Klok voor de countdown en timer
        private void Timer(object sender, EventArgs e)
        {

            if (Countdown <= 0 && Go == true)
            {
                LabelCountdown.Visibility = Visibility.Hidden;
                Label2Countdown.Visibility = Visibility.Hidden;
                tijd++;
                int minuten = tijd / 60;
                int seconden = tijd % 60;
                string Minuten = Convert.ToString(minuten);
                string Seconden = Convert.ToString(seconden);
                GlobalTimer.Content = Minuten + ":" + Seconden;
            }
            else if (Go == true)
            {

                LabelCountdown.Content = Countdown.ToString();
                Label2Countdown.Content = Countdown.ToString();
                --Countdown;

            }

        }
        //knop om de countdown en timer te starten
        private void StartCountdown_Click(object sender, RoutedEventArgs e)
        {
            StartCountdown.Visibility= Visibility.Hidden;
            Go = true;
        }


        private void Upgrades_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Upgrades upgradesWindow = new Upgrades();
            upgradesWindow.Show();
        }

        private void Startscherm_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UItest.MainWindow secondWindow = new UItest.MainWindow();
            secondWindow.Show();
        }

        private void Levels_button_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();


            UItest.levels secondWindow = new UItest.levels();
            secondWindow.Show();
        }


    }
}
