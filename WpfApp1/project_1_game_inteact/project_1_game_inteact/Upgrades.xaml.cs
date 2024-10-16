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
            // de knopen van player 2 buiten beeld zetten
            P2_Upgrade_Body_1.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Body_2.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Body_3.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Body_4.Margin = new Thickness(900, 900, 901, 901);

            P2_Upgrade_Motor_1.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Motor_2.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Motor_3.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Motor_4.Margin = new Thickness(900, 900, 901, 901);

            P2_Upgrade_Wiel_1.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Wiel_2.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Wiel_3.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Wiel_4.Margin = new Thickness(900, 900, 901, 901);

            P2_Upgrade_Suspensie_1.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Suspensie_2.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Suspensie_3.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Suspensie_4.Margin = new Thickness(900, 900, 901, 901);

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

            P1_Upgrade_Body_1.Margin = new Thickness(900, 900, 901, 901);
            P1_Upgrade_Body_2.Margin = new Thickness(900, 900, 901, 901);
            P1_Upgrade_Body_3.Margin = new Thickness(900, 900, 901, 901);
            P1_Upgrade_Body_4.Margin = new Thickness(900, 900, 901, 901);

            P1_Upgrade_Motor_1.Margin = new Thickness(900, 900, 901, 901);
            P1_Upgrade_Motor_2.Margin = new Thickness(900, 900, 901, 901);
            P1_Upgrade_Motor_3.Margin = new Thickness(900, 900, 901, 901);
            P1_Upgrade_Motor_4.Margin = new Thickness(900, 900, 901, 901);

            P1_Upgrade_Wiel_1.Margin = new Thickness(900, 900, 901, 901);
            P1_Upgrade_Wiel_2.Margin = new Thickness(900, 900, 901, 901);
            P1_Upgrade_Wiel_3.Margin = new Thickness(900, 900, 901, 901);
            P1_Upgrade_Wiel_4.Margin = new Thickness(900, 900, 901, 901);

            P1_Upgrade_Suspensie_1.Margin = new Thickness(900, 900, 901, 901);
            P1_Upgrade_Suspensie_2.Margin = new Thickness(900, 900, 901, 901);
            P1_Upgrade_Suspensie_3.Margin = new Thickness(900, 900, 901, 901);
            P1_Upgrade_Suspensie_4.Margin = new Thickness(900, 900, 901, 901);

            P2_Upgrade_Body_1.Margin = new Thickness(25, 98, 651, 99);
            P2_Upgrade_Body_2.Margin = new Thickness(25, 98, 651, 99);
            P2_Upgrade_Body_3.Margin = new Thickness(25, 98, 651, 99);
            P2_Upgrade_Body_4.Margin = new Thickness(25, 98, 651, 99);

            P2_Upgrade_Motor_1.Margin = new Thickness(201,99,474,98);
            P2_Upgrade_Motor_2.Margin = new Thickness(201,99,474,98);
            P2_Upgrade_Motor_3.Margin = new Thickness(201,99,474,98);
            P2_Upgrade_Motor_4.Margin = new Thickness(201,99,474,98);

            P2_Upgrade_Wiel_1.Margin = new Thickness(449,99,226,97);
            P2_Upgrade_Wiel_2.Margin = new Thickness(449,99,226,97);
            P2_Upgrade_Wiel_3.Margin = new Thickness(449,99,226,97);
            P2_Upgrade_Wiel_4.Margin = new Thickness(449,99,226,97);

            P2_Upgrade_Suspensie_1.Margin = new Thickness(619,99,48,97);
            P2_Upgrade_Suspensie_2.Margin = new Thickness(619,99,48,97);
            P2_Upgrade_Suspensie_3.Margin = new Thickness(619,99,48,97);
            P2_Upgrade_Suspensie_4.Margin = new Thickness(619,99,48,97);
        }

        private void Speler2Click(object sender, RoutedEventArgs e)
        {
            Speler_1_Knop.IsEnabled = true;
            Speler_2_Knop.IsEnabled = false;

            P1_Upgrade_Body_1.Margin = new Thickness(25, 98, 651, 99);
            P1_Upgrade_Body_2.Margin = new Thickness(25, 98, 651, 99);
            P1_Upgrade_Body_3.Margin = new Thickness(25, 98, 651, 99);
            P1_Upgrade_Body_4.Margin = new Thickness(25, 98, 651, 99);

            P1_Upgrade_Motor_1.Margin = new Thickness(201,99,474,98);
            P1_Upgrade_Motor_2.Margin = new Thickness(201,99,474,98);
            P1_Upgrade_Motor_3.Margin = new Thickness(201,99,474,98);
            P1_Upgrade_Motor_4.Margin = new Thickness(201,99,474,98);

            P1_Upgrade_Wiel_1.Margin = new Thickness(449,99,226,97);
            P1_Upgrade_Wiel_2.Margin = new Thickness(449,99,226,97);
            P1_Upgrade_Wiel_3.Margin = new Thickness(449,99,226,97);
            P1_Upgrade_Wiel_4.Margin = new Thickness(449,99,226,97);

            P1_Upgrade_Suspensie_1.Margin = new Thickness(619,99,48,97);
            P1_Upgrade_Suspensie_2.Margin = new Thickness(619,99,48,97);
            P1_Upgrade_Suspensie_3.Margin = new Thickness(619,99,48,97);
            P1_Upgrade_Suspensie_4.Margin = new Thickness(619,99,48,97);

            P2_Upgrade_Body_1.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Body_2.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Body_3.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Body_4.Margin = new Thickness(900, 900, 901, 901);

            P2_Upgrade_Motor_1.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Motor_2.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Motor_3.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Motor_4.Margin = new Thickness(900, 900, 901, 901);

            P2_Upgrade_Wiel_1.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Wiel_2.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Wiel_3.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Wiel_4.Margin = new Thickness(900, 900, 901, 901);

            P2_Upgrade_Suspensie_1.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Suspensie_2.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Suspensie_3.Margin = new Thickness(900, 900, 901, 901);
            P2_Upgrade_Suspensie_4.Margin = new Thickness(900, 900, 901, 901);

        }
        //Upgrades Player 1
        private void P1_Upgrade_Body_1_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Body_1.Visibility = Visibility.Hidden;
            P1_Upgrade_Body_2.Visibility = Visibility.Visible;
        }

        private void P1_Upgrade_Body_2_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Body_2.Visibility= Visibility.Hidden;
            P1_Upgrade_Body_3.Visibility = Visibility.Visible;
        }

        private void P1_Upgrade_Body_3_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Body_3.Visibility = Visibility.Hidden;
            P1_Upgrade_Body_4.Visibility = Visibility.Visible;
        }

        private void P1_Upgrade_Body_4_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Body_4.IsEnabled = false;
        }

        private void P1_Upgrade_Motor_1_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Motor_1.Visibility = Visibility.Hidden;
            P1_Upgrade_Motor_2.Visibility = Visibility.Visible;
        }

        private void P1_Upgrade_Motor_2_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Motor_2.Visibility = Visibility.Hidden;
            P1_Upgrade_Motor_3.Visibility = Visibility.Visible;
        }

        private void P1_Upgrade_Motor_3_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Motor_3.Visibility = Visibility.Hidden;
            P1_Upgrade_Motor_4.Visibility = Visibility.Visible;
        }

        private void P1_Upgrade_Motor_4_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Motor_4.IsEnabled = false;
        }

        private void P1_Upgrade_Wiel_1_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Wiel_1.Visibility = Visibility.Hidden;
            P1_Upgrade_Wiel_2.Visibility = Visibility.Visible;
        }

        private void P1_Upgrade_Wiel_2_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Wiel_2.Visibility = Visibility.Hidden;
            P1_Upgrade_Wiel_3.Visibility = Visibility.Visible;
        }

        private void P1_Upgrade_Wiel_3_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Wiel_3.Visibility = Visibility.Hidden;
            P1_Upgrade_Wiel_4.Visibility = Visibility.Visible;
        }

        private void P1_Upgrade_Wiel_4_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Wiel_4.IsEnabled = false;
        }

        private void P1_Upgrade_Suspensie_1_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Suspensie_1.Visibility = Visibility.Hidden;
            P1_Upgrade_Suspensie_2.Visibility = Visibility.Visible;
        }

        private void P1_Upgrade_Suspensie_2_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Suspensie_2.Visibility = Visibility.Hidden;
            P1_Upgrade_Suspensie_3.Visibility = Visibility.Visible;
        }

        private void P1_Upgrade_Suspensie_3_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Suspensie_3.Visibility = Visibility.Hidden;
            P1_Upgrade_Suspensie_4.Visibility = Visibility.Visible;
        }

        private void P1_Upgrade_Suspensie_4_Click(object sender, RoutedEventArgs e)
        {
            P1_Upgrade_Suspensie_4.IsEnabled = false;
        }

        //Upgrades Player 2
        private void P2_Upgrade_Body_1_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Body_1.Visibility = Visibility.Hidden;
            P2_Upgrade_Body_2.Visibility = Visibility.Visible;
        }

        private void P2_Upgrade_Body_2_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Body_2.Visibility = Visibility.Hidden;
            P2_Upgrade_Body_3.Visibility = Visibility.Visible;
        }

        private void P2_Upgrade_Body_3_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Body_3.Visibility = Visibility.Hidden;
            P2_Upgrade_Body_4.Visibility = Visibility.Visible;
        }

        private void P2_Upgrade_Body_4_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Body_4.IsEnabled = false;
        }

        private void P2_Upgrade_Motor_1_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Motor_1.Visibility = Visibility.Hidden;
            P2_Upgrade_Motor_2.Visibility = Visibility.Visible;
        }

        private void P2_Upgrade_Motor_2_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Motor_2.Visibility = Visibility.Hidden;
            P2_Upgrade_Motor_3.Visibility = Visibility.Visible;
        }

        private void P2_Upgrade_Motor_3_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Motor_3.Visibility = Visibility.Hidden;
            P2_Upgrade_Motor_4.Visibility = Visibility.Visible;
        }

        private void P2_Upgrade_Motor_4_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Motor_4.IsEnabled = false;
        }

        private void P2_Upgrade_Wiel_1_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Wiel_1.Visibility = Visibility.Hidden;
            P2_Upgrade_Wiel_2.Visibility = Visibility.Visible;
        }

        private void P2_Upgrade_Wiel_2_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Wiel_2.Visibility = Visibility.Hidden;
            P2_Upgrade_Wiel_3.Visibility = Visibility.Visible;
        }

        private void P2_Upgrade_Wiel_3_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Wiel_3.Visibility = Visibility.Hidden;
            P2_Upgrade_Wiel_4.Visibility = Visibility.Visible;
        }

        private void P2_Upgrade_Wiel_4_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Wiel_4.IsEnabled = false;
        }

        private void P2_Upgrade_Suspensie_1_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Suspensie_1.Visibility = Visibility.Hidden;
            P2_Upgrade_Suspensie_2.Visibility = Visibility.Visible;
        }

        private void P2_Upgrade_Suspensie_2_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Suspensie_2.Visibility = Visibility.Hidden;
            P2_Upgrade_Suspensie_3.Visibility = Visibility.Visible;
        }

        private void P2_Upgrade_Suspensie_3_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Suspensie_3.Visibility = Visibility.Hidden;
            P2_Upgrade_Suspensie_4.Visibility = Visibility.Visible;
        }

        private void P2_Upgrade_Suspensie_4_Click(object sender, RoutedEventArgs e)
        {
            P2_Upgrade_Suspensie_4.IsEnabled = false;
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
