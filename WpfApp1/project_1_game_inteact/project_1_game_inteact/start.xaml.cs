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
using UItest;

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
            nspeler1.Text = SharedData.Instance.Naam1;
            nspeler2.Text = SharedData.Instance.Naam2;
            startinf();
            BackgroundMusicPlayer.Instance.Play();
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
            project_1_game_inteact.Leaderboard handleiding2 = new Leaderboard();
            handleiding2.Show();
            this.Close();
        }

        private void instellingen_Click(object sender, RoutedEventArgs e)
        {
            UItest.instellingen instellingen = new UItest.instellingen();
            instellingen.Show();
            this.Close();
        }

        /// <summary/>
        /// Code voor data verwisselen tussen schermen
        /// "using static project_1_game_inteact.start;" moet bovenaan de cs code staan voordat het werkt
        /// <summary/>
        public class SharedData
        {
            private static SharedData _instance;

            public static SharedData Instance => _instance ??= new SharedData();
            // voeg hier wat je wil gebruiken tussen pages
            public string Naam1 { get; set; }
            public string Naam2 { get; set; }
            public int Geld1 { get; set; }
            public int Geld2 { get; set; }
            public int[] Upgr1 { get; set; }
            public int[] Upgr2 { get; set; }
            public double max_Speed { get; set; }
            public double acceleration {  get; set; }
            public double gravity { get; set; }
            public int VolumeSlider { get; set; }

            public double[] time1 { get; set; } =  new double[1];
            public double[] time2 { get; set; } = new double[1];
            public int levels { get; set; }
        }
        private void startinf()
        {
            if (SharedData.Instance.Upgr1 == null)
            {
                SharedData.Instance.Upgr1 = new int[] { 1, 1, 1, };
                SharedData.Instance.Upgr2 = new int[] { 1, 1, 1, };
                SharedData.Instance.max_Speed = 5;
                SharedData.Instance.Geld1 = 50;
                SharedData.Instance.Geld2 = 50;
                SharedData.Instance.acceleration = 0.1;
                SharedData.Instance.gravity = 0.00051; //0.01 is natural ish
                SharedData.Instance.VolumeSlider = 100;
                SharedData.Instance.Naam1 = "Speler 1";
                SharedData.Instance.Naam2 = "Speler 2";
                SharedData.Instance.levels = 1;
                SharedData.Instance.time2 = new double[] { 0.0 };
                SharedData.Instance.time2 = new double[] { 0.0 };

            }
        }

        private void nspeler2_KeyUp(object sender, KeyEventArgs e)
        {
            SharedData.Instance.Naam2 = nspeler2.Text;
        }

        private void nspeler1_KeyUp(object sender, KeyEventArgs e)
        {
            SharedData.Instance.Naam1 = nspeler1.Text;
        }
    }
}
