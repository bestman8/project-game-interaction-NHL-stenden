using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using UItest;
using static project_1_game_inteact.start;

namespace project_1_game_inteact
{
    /// <summary>
    /// Interaction logic for Upgrades.xaml
    /// </summary>
    public partial class Upgrades : Window
    {
        int speler = 0;
        private DispatcherTimer timer;
        private int Rood = 0;
        private int MaxRood = 10;
        public Upgrades()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Upgrades_Check();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Roodgeld;
            BackgroundMusicPlayer.Instance.Play();

        }
        private void LevelsClick(object sender, RoutedEventArgs e)
        {
            levels gm = new levels();
            gm.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void StartschermClick(object sender, RoutedEventArgs e)
        {
            start gm = new start();
            gm.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }
        // checkt geld en level upgrades en zet nieuwe waarden
        public void Upgrades_Check()
        {
            Speler_1_Knop.Content = SharedData.Instance.Naam1;
            Speler_2_Knop.Content = SharedData.Instance.Naam2;
            GeldSpeler1.Content = "Geld " + SharedData.Instance.Naam1 + ": " + Convert.ToString(SharedData.Instance.Geld1);
            GeldSpeler2.Content = "Geld " + SharedData.Instance.Naam2 + ": " + Convert.ToString(SharedData.Instance.Geld2);
            if (speler == 0)
            {
                if (SharedData.Instance.Upgr1[0] < 5)
                {
                    P1M.Content = "Motor" + Convert.ToString(SharedData.Instance.Upgr1[0]);
                    SharedData.Instance.max_Speed = SharedData.Instance.Upgr1[0] * 1.1; }
                else
                    P1M.Content = "Max Motor";
                if (SharedData.Instance.Upgr1[1] < 5)
                {
                    P1W.Content = "Wiel" + Convert.ToString(SharedData.Instance.Upgr1[1]);
                }

                else
                    P1W.Content = "Max Wiel ";
                if (SharedData.Instance.Upgr1[2] < 5)
                {
                    P1S.Content = "Suspensie" + Convert.ToString(SharedData.Instance.Upgr1[2]);
                    SharedData.Instance.gravity = SharedData.Instance.Upgr1[2] * 0.01;
                }
                else
                    P1S.Content = "Max Suspensie ";
            }
            else
            {
                if (SharedData.Instance.Upgr2[0] < 5)
                    P1M.Content = "Motor" + Convert.ToString(SharedData.Instance.Upgr2[0]);
                else
                    P1M.Content = "Max Motor ";
                    
                if (SharedData.Instance.Upgr2[1] < 5)
                        P1W.Content = "Wiel" + Convert.ToString(SharedData.Instance.Upgr2[1]);
                else
                        P1W.Content = "Max Wiel ";
                if (SharedData.Instance.Upgr2[2] < 5)
                    P1S.Content = "Suspensie" + Convert.ToString(SharedData.Instance.Upgr2[2]);
                else
                    P1S.Content = "Max Suspensie ";

            }

        }
        // laat het geld tabel roodknipperen als er niet genoeg geld is
        private void Roodgeld(object sender, EventArgs e)
        {
            if (Rood >= MaxRood)
            {
                GeldSpeler1.Background = Brushes.LightGray;
                GeldSpeler2.Background = Brushes.LightGray;
                timer.Stop();
            }
            else
            {
                if (speler == 0)
                {
                    GeldSpeler1.Background = (GeldSpeler1.Background == Brushes.LightGray) ? Brushes.Red : Brushes.LightGray;
                }
                else
                {
                    GeldSpeler2.Background = (GeldSpeler2.Background == Brushes.LightGray) ? Brushes.Red : Brushes.LightGray;
                }
                Rood++;
            }
        }

        //Hiermee switch je tussen de upgrades van player 1 en player 2
        private void SpelerClick(object sender, RoutedEventArgs e)
        {

            if (speler == 0)
            {
                timer.Stop();
                GeldSpeler1.Background = Brushes.LightGray;
                Speler_1_Knop.IsEnabled = false;
                Speler_2_Knop.IsEnabled = true;
                speler = 1;
                Upgrades_Check();
            }
            else
            {
                timer.Stop();
                GeldSpeler2.Background = Brushes.LightGray;
                Speler_1_Knop.IsEnabled = true;
                Speler_2_Knop.IsEnabled = false;
                speler = 0;
                Upgrades_Check();
            }

        }

        //Upgrades Player 1 en 2
        private void P1M_Click(object sender, RoutedEventArgs e)
        {
            if (speler == 0)
            {
                if (SharedData.Instance.Upgr1[0] < 5)
                {
                    if (SharedData.Instance.Geld1 >= 5)
                    {
                        SharedData.Instance.Upgr1[0] = SharedData.Instance.Upgr1[0] + 1;
                        SharedData.Instance.Geld1 = SharedData.Instance.Geld1 - 5;
                        SharedData.Instance.max_Speed = SharedData.Instance.max_Speed + 5;
                        Upgrades_Check();
                    }
                    else
                    {
                        Rood = 0;
                        timer.Start();
                    }
                }
            }
            else if (SharedData.Instance.Upgr2[0] < 5)
            {
                if (SharedData.Instance.Geld2 >= 5)
                {
                    SharedData.Instance.Upgr2[0] = SharedData.Instance.Upgr2[0] + 1;
                    SharedData.Instance.Geld2 = SharedData.Instance.Geld2 - 5;
                    Upgrades_Check();
                }
                else
                {
                    Rood = 0;
                    timer.Start();
                }
            }
        }
        private void P1W_Click(object sender, RoutedEventArgs e)
        {
            if (speler == 0)
            {
                if (SharedData.Instance.Upgr1[1] < 5)
                {
                    if (SharedData.Instance.Geld1 >= 5)
                    {
                        SharedData.Instance.Upgr1[1] = SharedData.Instance.Upgr1[1] + 1;
                        SharedData.Instance.Geld1 = SharedData.Instance.Geld1 - 1;
                        SharedData.Instance.acceleration = SharedData.Instance.acceleration + 0.02;
                        Upgrades_Check();
                    }
                    else
                    {
                        Rood = 0;
                        timer.Start();
                    }
                }
            }
            else if (SharedData.Instance.Upgr2[1] < 5)
            {
                if (SharedData.Instance.Geld2 >= 5)
                {
                    SharedData.Instance.Upgr2[1] = SharedData.Instance.Upgr2[1] + 1;
                    SharedData.Instance.Geld2 = SharedData.Instance.Geld2 - 5;
                    Upgrades_Check();
                }
                else
                {
                    Rood = 0;
                    timer.Start();
                }
            }
        }
        private void P1S_Click(object sender, RoutedEventArgs e)
        {
            if (speler == 0)
            {
                if (SharedData.Instance.Upgr1[2] < 5)
                {
                    if (SharedData.Instance.Geld1 >= 5)
                    {
                        SharedData.Instance.Upgr1[2] = SharedData.Instance.Upgr1[2] + 1;
                        SharedData.Instance.Geld1 = SharedData.Instance.Geld1 - 5;
                        SharedData.Instance.gravity = SharedData.Instance.gravity - 0.0001;
                        Upgrades_Check();
                    }
                    else
                    {
                        Rood = 0;
                        timer.Start();
                    }
                }
            }
            else if (SharedData.Instance.Upgr2[2] < 5)
            {
                if (SharedData.Instance.Geld2 >= 5)
                {
                    SharedData.Instance.Upgr2[2] = SharedData.Instance.Upgr2[2] + 1;
                    SharedData.Instance.Geld2 = SharedData.Instance.Geld2 - 5;
                    Upgrades_Check();
                }
                else
                {
                    Rood = 0;
                    timer.Start();
                }
            }
        }

        //Info over wat de upgrades doen

        private void Suspensie_MouseEnter(object sender, MouseEventArgs e)
        {
            Suspensie_info.Visibility = Visibility.Visible;
        }

        private void Motor_MouseEnter(object sender, MouseEventArgs e)
        {
            Motor_Info.Visibility = Visibility.Visible;
        }

        private void Motor_MouseLeave(object sender, MouseEventArgs e)
        {
            Motor_Info.Visibility = Visibility.Hidden;
        }

        private void Wiel_MouseEnter(object sender, MouseEventArgs e)
        {
            Wiel_info.Visibility = Visibility.Visible;
        }

        private void Wiel_MouseLeave(object sender, MouseEventArgs e)
        {
            Wiel_info.Visibility = Visibility.Hidden;
        }

        private void Suspensie_MouseLeave(object sender, MouseEventArgs e)
        {
            Suspensie_info.Visibility = Visibility.Hidden;
        }
        //Einde info
    }
}
// Funtionalitiet knoppen nog toevoegen en switchen tussen upgrades player 1 en 2 doet niks
