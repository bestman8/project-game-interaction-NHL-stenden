using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using UItest;
using static project_1_game_inteact.start;

namespace project_1_game_inteact
{
    /// <summary>
    /// Functionaliteit van de upgrade knopen doet nog niks, switcht nu nog alleen tussen de upgrades zelf
    /// </summary>
    public partial class Upgrades : Window
    {
        public Upgrades()
        {
            InitializeComponent();

            if (SharedData.Instance.Upgr1 == null)
                SharedData.Instance.Upgr1 = new string[] { "P1B1", "P1M1", "P1W1", "P1S1" };
            if (SharedData.Instance.Upgr2 == null)
                SharedData.Instance.Upgr2 = new string[] { "P2B1", "P2M1", "P2W1", "P2S1" };

            foreach (var control in this.MainGrid.Children)
            {
                if (control is Button btn && btn.Tag?.ToString() == "P1")
                {
                    if (SharedData.Instance.Upgr1.Contains(btn.Name))
                    {
                        btn.Visibility = Visibility.Visible;  // Show button
                    }
                    else
                    {
                        btn.Visibility = Visibility.Collapsed; // Hide button
                    }
                }
            }
            foreach (var control in this.MainGrid.Children)
            {
                if (control is Button btn && btn.Tag?.ToString() == "P2")
                {
                    if (SharedData.Instance.Upgr2.Contains(btn.Name))
                    {
                        btn.Visibility = Visibility.Visible;  // Show button
                    }
                    else
                    {
                        btn.Visibility = Visibility.Collapsed; // Hide button
                    }
                }
            }


            Speler_1_Knop.Content = SharedData.Instance.Naam1;
            Speler_2_Knop.Content = SharedData.Instance.Naam2;
            GeldSpeler1.Content = "Geld " + SharedData.Instance.Naam1 + ": " + Convert.ToString(SharedData.Instance.Geld1);
            GeldSpeler2.Content = "Geld " + SharedData.Instance.Naam2 + ": " + Convert.ToString(SharedData.Instance.Geld2);
        }

        private void LevelsClick(object sender, RoutedEventArgs e)
        {
            levels gm = new levels();
            gm.Visibility = Visibility.Visible;
            this.Close();
        }

        private void StartschermClick(object sender, RoutedEventArgs e)
        {
            MainWindow gm = new MainWindow();
            gm.Visibility = Visibility.Visible;
            this.Close();
        }

        //Hiermee switch je tussen de upgrades van player 1 en player 2
        private void Speler1Click(object sender, RoutedEventArgs e)
        {
            Speler_1_Knop.IsEnabled = false;
            Speler_2_Knop.IsEnabled = true;

            P1B1.Margin = new Thickness(900, 900, 901, 901);
            P1B2.Margin = new Thickness(900, 900, 901, 901);
            P1B3.Margin = new Thickness(900, 900, 901, 901);
            P1B4.Margin = new Thickness(900, 900, 901, 901);

            P1M1.Margin = new Thickness(900, 900, 901, 901);
            P1M2.Margin = new Thickness(900, 900, 901, 901);
            P1M3.Margin = new Thickness(900, 900, 901, 901);
            P1M4.Margin = new Thickness(900, 900, 901, 901);

            P1W1.Margin = new Thickness(900, 900, 901, 901);
            P1W2.Margin = new Thickness(900, 900, 901, 901);
            P1W3.Margin = new Thickness(900, 900, 901, 901);
            P1W4.Margin = new Thickness(900, 900, 901, 901);

            P1S1.Margin = new Thickness(900, 900, 901, 901);
            P1S2.Margin = new Thickness(900, 900, 901, 901);
            P1S3.Margin = new Thickness(900, 900, 901, 901);
            P1S4.Margin = new Thickness(900, 900, 901, 901);

            P2B1.Margin = new Thickness(25, 99, 651, 98);
            P2B2.Margin = new Thickness(25, 99, 651, 98);
            P2B3.Margin = new Thickness(25, 99, 651, 98);
            P2B4.Margin = new Thickness(25, 99, 651, 98);

            P2M1.Margin = new Thickness(201,99,474,98);
            P2M2.Margin = new Thickness(201,99,474,98);
            P2M3.Margin = new Thickness(201,99,474,98);
            P2M4.Margin = new Thickness(201,99,474,98);

            P2W1.Margin = new Thickness(449,99,226,97);
            P2W2.Margin = new Thickness(449,99,226,97);
            P2W3.Margin = new Thickness(449,99,226,97);
            P2W4.Margin = new Thickness(449,99,226,97);

            P2S1.Margin = new Thickness(619,99,48,97);
            P2S2.Margin = new Thickness(619,99,48,97);
            P2S3.Margin = new Thickness(619,99,48,97);
            P2S4.Margin = new Thickness(619,99,48,97);
        }

        private void Speler2Click(object sender, RoutedEventArgs e)
        {
            Speler_1_Knop.IsEnabled = true;
            Speler_2_Knop.IsEnabled = false;

            P1B1.Margin = new Thickness(25, 99, 651, 98);
            P1B2.Margin = new Thickness(25, 99, 651, 98);
            P1B3.Margin = new Thickness(25, 99, 651, 98);
            P1B4.Margin = new Thickness(25, 99, 651, 98);

            P1M1.Margin = new Thickness(201,99,474,98);
            P1M2.Margin = new Thickness(201,99,474,98);
            P1M3.Margin = new Thickness(201,99,474,98);
            P1M4.Margin = new Thickness(201,99,474,98);

            P1W1.Margin = new Thickness(449,99,226,97);
            P1W2.Margin = new Thickness(449,99,226,97);
            P1W3.Margin = new Thickness(449,99,226,97);
            P1W4.Margin = new Thickness(449,99,226,97);

            P1S1.Margin = new Thickness(619,99,48,97);
            P1S2.Margin = new Thickness(619,99,48,97);
            P1S3.Margin = new Thickness(619,99,48,97);
            P1S4.Margin = new Thickness(619,99,48,97);

            P2B1.Margin = new Thickness(900, 900, 901, 901);
            P2B2.Margin = new Thickness(900, 900, 901, 901);
            P2B3.Margin = new Thickness(900, 900, 901, 901);
            P2B4.Margin = new Thickness(900, 900, 901, 901);

            P2M1.Margin = new Thickness(900, 900, 901, 901);
            P2M2.Margin = new Thickness(900, 900, 901, 901);
            P2M3.Margin = new Thickness(900, 900, 901, 901);
            P2M4.Margin = new Thickness(900, 900, 901, 901);

            P2W1.Margin = new Thickness(900, 900, 901, 901);
            P2W2.Margin = new Thickness(900, 900, 901, 901);
            P2W3.Margin = new Thickness(900, 900, 901, 901);
            P2W4.Margin = new Thickness(900, 900, 901, 901);

            P2S1.Margin = new Thickness(900, 900, 901, 901);
            P2S2.Margin = new Thickness(900, 900, 901, 901);
            P2S3.Margin = new Thickness(900, 900, 901, 901);
            P2S4.Margin = new Thickness(900, 900, 901, 901);

        }
        //Upgrades Player 1
        private void P1B1_Click(object sender, RoutedEventArgs e)
        {
            P1B1.Visibility = Visibility.Hidden;
            P1B2.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr1[0] = "P1B2";
        }

        private void P1B2_Click(object sender, RoutedEventArgs e)
        {
            P1B2.Visibility= Visibility.Hidden;
            P1B3.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr1[0] = "P1B3";
        }

        private void P1B3_Click(object sender, RoutedEventArgs e)
        {
            P1B3.Visibility = Visibility.Hidden;
            P1B4.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr1[0] = "P1B4";
        }

        private void P1B4_Click(object sender, RoutedEventArgs e)
        {
            P1B4.IsEnabled = false;
            SharedData.Instance.Upgr1[0] = "P1B5";
        }

        private void P1M1_Click(object sender, RoutedEventArgs e)
        {
            P1M1.Visibility = Visibility.Hidden;
            P1M2.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr1[1] = "P1M2";
        }

        private void P1M2_Click(object sender, RoutedEventArgs e)
        {
            P1M2.Visibility = Visibility.Hidden;
            P1M3.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr1[1] = "P1M3";
        }

        private void P1M3_Click(object sender, RoutedEventArgs e)
        {
            P1M3.Visibility = Visibility.Hidden;
            P1M4.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr1[1] = "P1M4";
        }

        private void P1M4_Click(object sender, RoutedEventArgs e)
        {
            P1M4.IsEnabled = false;
            SharedData.Instance.Upgr1[1] = "P1M5";
        }

        private void P1W1_Click(object sender, RoutedEventArgs e)
        {
            P1W1.Visibility = Visibility.Hidden;
            P1W2.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr1[2] = "P1W2";
        }

        private void P1W2_Click(object sender, RoutedEventArgs e)
        {
            P1W2.Visibility = Visibility.Hidden;
            P1W3.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr1[2] = "P1W3";
        }

        private void P1W3_Click(object sender, RoutedEventArgs e)
        {
            P1W3.Visibility = Visibility.Hidden;
            P1W4.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr1[2] = "P1W4";
        }

        private void P1W4_Click(object sender, RoutedEventArgs e)
        {
            P1W4.IsEnabled = false;
            SharedData.Instance.Upgr1[2] = "P1W5";
        }

        private void P1S1_Click(object sender, RoutedEventArgs e)
        {
            P1S1.Visibility = Visibility.Hidden;
            P1S2.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr1[3] = "P1S2";
        }

        private void P1S2_Click(object sender, RoutedEventArgs e)
        {
            P1S2.Visibility = Visibility.Hidden;
            P1S3.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr1[3] = "P1S3";
        }

        private void P1S3_Click(object sender, RoutedEventArgs e)
        {
            P1S3.Visibility = Visibility.Hidden;
            P1S4.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr1[3] = "P1S4";
        }

        private void P1S4_Click(object sender, RoutedEventArgs e)
        {
            P1S4.IsEnabled = false;
            SharedData.Instance.Upgr1[3] = "P1S5";
        }

        //Upgrades Player 2
        private void P2B1_Click(object sender, RoutedEventArgs e)
        {
            P2B1.Visibility = Visibility.Hidden;
            P2B2.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr2[0] = "P2B2";
        }

        private void P2B2_Click(object sender, RoutedEventArgs e)
        {
            P2B2.Visibility = Visibility.Hidden;
            P2B3.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr2[0] = "P2B3";
        }

        private void P2B3_Click(object sender, RoutedEventArgs e)
        {
            P2B3.Visibility = Visibility.Hidden;
            P2B4.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr2[0] = "P2B4";
        }

        private void P2B4_Click(object sender, RoutedEventArgs e)
        {
            P2B4.IsEnabled = false;
            SharedData.Instance.Upgr2[0] = "P2B5";
        }

        private void P2M1_Click(object sender, RoutedEventArgs e)
        {
            P2M1.Visibility = Visibility.Hidden;
            P2M2.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr2[1] = "P2M2";
        }

        private void P2M2_Click(object sender, RoutedEventArgs e)
        {
            P2M2.Visibility = Visibility.Hidden;
            P2M3.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr2[1] = "P2M3";
        }

        private void P2M3_Click(object sender, RoutedEventArgs e)
        {
            P2M3.Visibility = Visibility.Hidden;
            P2M4.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr2[1] = "P2M4";
        }

        private void P2M4_Click(object sender, RoutedEventArgs e)
        {
            P2M4.IsEnabled = false;
            SharedData.Instance.Upgr2[1] = "P2M5";
        }

        private void P2W1_Click(object sender, RoutedEventArgs e)
        {
            P2W1.Visibility = Visibility.Hidden;
            P2W2.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr2[2] = "P2W2";
        }

        private void P2W2_Click(object sender, RoutedEventArgs e)
        {
            P2W2.Visibility = Visibility.Hidden;
            P2W3.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr2[2] = "P2W3";
        }

        private void P2W3_Click(object sender, RoutedEventArgs e)
        {
            P2W3.Visibility = Visibility.Hidden;
            P2W4.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr2[2] = "P2W4";
        }

        private void P2W4_Click(object sender, RoutedEventArgs e)
        {
            P2W4.IsEnabled = false;
            SharedData.Instance.Upgr2[2] = "P2W5";
        }

        private void P2S1_Click(object sender, RoutedEventArgs e)
        {
            P2S1.Visibility = Visibility.Hidden;
            P2S2.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr2[3] = "P2S2";
        }

        private void P2S2_Click(object sender, RoutedEventArgs e)
        {
            P2S2.Visibility = Visibility.Hidden;
            P2S3.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr2[3] = "P2S3";
        }

        private void P2S3_Click(object sender, RoutedEventArgs e)
        {
            P2S3.Visibility = Visibility.Hidden;
            P2S4.Visibility = Visibility.Visible;
            SharedData.Instance.Upgr2[3] = "P2S4";
        }

        private void P2S4_Click(object sender, RoutedEventArgs e)
        {
            P2S4.IsEnabled = false;
            SharedData.Instance.Upgr2[3] = "P2S5";
        }

        //Info over wat de upgrades doen
        private void Lichaam_MouseEnter(object sender, MouseEventArgs e)
        {
            Lichaam_Info.Visibility = Visibility.Visible; 
        }

        private void Lichaam_MouseLeave(object sender, MouseEventArgs e)
        {
            Lichaam_Info.Visibility= Visibility.Hidden;
        }

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
            Wiel_info.Visibility= Visibility.Hidden;
        }

        private void Suspensie_MouseLeave(object sender, MouseEventArgs e)
        {
            Suspensie_info.Visibility = Visibility.Hidden;
        }
        //Einde info


        // Einde Upgrades
    }
}
