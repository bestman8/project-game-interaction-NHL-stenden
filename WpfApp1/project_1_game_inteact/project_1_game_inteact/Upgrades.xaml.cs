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
            InitializeComponent();
            Upgrades_Check();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Roodgeld;
            BackgroundMusicPlayer.Instance.Play();;
        }
        private void LevelsClick(object sender, RoutedEventArgs e)
        {
            levels gm = new levels();
            gm.Visibility = Visibility.Visible;
            this.Close();
        }

        private void StartschermClick(object sender, RoutedEventArgs e)
        {
            start gm = new start();
            gm.Visibility = Visibility.Visible;
            this.Close();
        }
        // checkt geld en level upgrades en zet nieuwe waarden
        public void Upgrades_Check()
        {
            Speler_1_Knop.Content = SharedData.Instance.Naam1;
            Speler_2_Knop.Content = SharedData.Instance.Naam2;
            GeldSpeler1.Content = "Punten " + SharedData.Instance.Naam1 + ": " + Convert.ToString(SharedData.Instance.Geld1);
            GeldSpeler2.Content = "Punten " + SharedData.Instance.Naam2 + ": " + Convert.ToString(SharedData.Instance.Geld2);
            if (speler == 0)
            {
                if (SharedData.Instance.Upgr1[0] < 5)
                {
                    double prijs = 50 * (SharedData.Instance.Upgr1[0] * 0.5);
                    P1M.Text = "Motor " + Convert.ToString(SharedData.Instance.Upgr1[0]) + " Punten: " + prijs;
                }
                else
                    P1M.Text = "Max Motor";
                if (SharedData.Instance.Upgr1[1] < 5)
                {
                    double prijs = 50 * (SharedData.Instance.Upgr1[1] * 0.5);
                    P1W.Text = "Wiel " + Convert.ToString(SharedData.Instance.Upgr1[1]) + " Punten:" + prijs;
                }
                else
                    P1W.Text = "Max Wiel ";
                if (SharedData.Instance.Upgr1[2] < 5)
                {
                    double prijs = 50 * (SharedData.Instance.Upgr1[2] * 0.5);
                    P1S.Text = "Suspensie " + Convert.ToString(SharedData.Instance.Upgr1[2]) + " Punten:" + prijs;
                }
                else
                    P1S.Text = "Max Suspensie ";
            }
            else
            {
                if (SharedData.Instance.Upgr2[0] < 5)
                {
                    double prijs = 50 * (SharedData.Instance.Upgr2[0] * 0.5);
                    P1M.Text = "Motor " + Convert.ToString(SharedData.Instance.Upgr2[0]) + " Punten:" + prijs;
                }
                else
                    P1M.Text = "Max Motor ";

                if (SharedData.Instance.Upgr2[1] < 5)
                {
                    double prijs = 50 * (SharedData.Instance.Upgr2[1] * 0.5);
                    P1W.Text = "Wiel " + Convert.ToString(SharedData.Instance.Upgr2[1]) + " Punten:" + prijs;
                }
                else
                    P1W.Text = "Max Wiel ";
                if (SharedData.Instance.Upgr2[2] < 5)
                {
                    double prijs = 50 * (SharedData.Instance.Upgr2[2] * 0.5);
                    P1S.Text = "Suspensie " + Convert.ToString(SharedData.Instance.Upgr2[2]) + " Punten:" + prijs;
                }
                else
                    P1S.Text = "Max Suspensie ";

            }

        }
        // laat het geld tabel roodknipperen als er niet genoeg geld is
        private void Roodgeld(object sender, EventArgs e)
        {
            if (Rood >= MaxRood)
            {
                GeldSpeler1.Background = Brushes.LawnGreen;
                GeldSpeler2.Background = Brushes.LawnGreen;
                timer.Stop();
            }
            else
            {
                if (speler == 0)
                {
                    GeldSpeler1.Background = (GeldSpeler1.Background == Brushes.LawnGreen) ? Brushes.Red : Brushes.LawnGreen;
                }
                else
                {
                    GeldSpeler2.Background = (GeldSpeler2.Background == Brushes.LawnGreen) ? Brushes.Red : Brushes.LawnGreen;
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
                GeldSpeler1.Background = Brushes.LawnGreen;
                Speler_1_Knop.IsEnabled = true;
                Speler_2_Knop.IsEnabled = false;
                speler = 1;
                Upgrades_Check();
            }
            else
            {
                timer.Stop();
                GeldSpeler2.Background = Brushes.LawnGreen;
                Speler_1_Knop.IsEnabled = false;
                Speler_2_Knop.IsEnabled = true;
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
                    double prijs1m = 50 * (SharedData.Instance.Upgr1[0] * 0.5);
                    if (SharedData.Instance.Geld1 >= prijs1m)
                    {
                        SharedData.Instance.Upgr1[0] = SharedData.Instance.Upgr1[0] + 1;
                        SharedData.Instance.Geld1 = SharedData.Instance.Geld1 - Convert.ToInt16(prijs1m);
                        prijs1m = prijs1m * 1.5; ;
                        SharedData.Instance.max_Speed1 = SharedData.Instance.max_Speed1 + 0.5;
                        SharedData.Instance.acceleration1 = SharedData.Instance.acceleration1 + 0.01;
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
                double prijs = 50 * (SharedData.Instance.Upgr2[0] * 0.5);
                if (SharedData.Instance.Geld2 >= prijs)
                {
                    SharedData.Instance.Upgr2[0] = SharedData.Instance.Upgr2[0] + 1;
                    SharedData.Instance.Geld2 = SharedData.Instance.Geld2 - Convert.ToInt16(prijs);
                    prijs = prijs * 1.5;
                    SharedData.Instance.max_Speed2 = SharedData.Instance.max_Speed2 + 0.5;
                    SharedData.Instance.acceleration2 = SharedData.Instance.acceleration2 + 0.01;
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
                    double prijs = 50 * (SharedData.Instance.Upgr1[1] * 0.5);
                    if (SharedData.Instance.Geld1 >= prijs)
                    {
                        SharedData.Instance.Upgr1[1] = SharedData.Instance.Upgr1[1] + 1;
                        SharedData.Instance.Geld1 = SharedData.Instance.Geld1 - Convert.ToInt16(prijs);
                        prijs = prijs * 1.5; ;
                        SharedData.Instance.deceleration1 = SharedData.Instance.deceleration1 - 0.0005;
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
                double prijs = 50 * (SharedData.Instance.Upgr2[1] * 0.5);
                if (SharedData.Instance.Geld2 >= prijs)
                {
                    SharedData.Instance.Upgr2[1] = SharedData.Instance.Upgr2[1] + 1;
                    SharedData.Instance.Geld2 = SharedData.Instance.Geld2 - Convert.ToInt16(prijs);
                    prijs = prijs * 1.5; ;
                    SharedData.Instance.deceleration2 = SharedData.Instance.deceleration2 - 0.0005;
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
                    double prijs = 50 * (SharedData.Instance.Upgr1[2] * 0.5);
                    if (SharedData.Instance.Geld1 >= prijs)
                    {
                        SharedData.Instance.Upgr1[2] = SharedData.Instance.Upgr1[2] + 1;
                        SharedData.Instance.Geld1 = SharedData.Instance.Geld1 - Convert.ToInt16(prijs);
                        prijs = prijs * 1.5;
                        SharedData.Instance.gravity1 = SharedData.Instance.gravity1 - 0.01;
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
                double prijs = 50 * (SharedData.Instance.Upgr2[2] * 0.5);
                if (SharedData.Instance.Geld2 >= prijs)
                {
                    SharedData.Instance.Upgr2[2] = SharedData.Instance.Upgr2[2] + 1;
                    SharedData.Instance.Geld2 = SharedData.Instance.Geld2 - Convert.ToInt16(prijs);
                    prijs = prijs * 1.5; ;
                    SharedData.Instance.gravity2 = SharedData.Instance.gravity2 - 0.01;
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
