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
    /// Interaction logic for Upgrades.xaml
    /// </summary>
    public partial class Upgrades : Window
    {   
        public Upgrades()
        {
            InitializeComponent();

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

        private void LevelsClick(object sender, RoutedEventArgs e)
        {
            levels gm = new levels();
            gm.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void StartschermClick(object sender, RoutedEventArgs e)
        {
            MainWindow gm = new MainWindow();
            gm.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Hidden;
        }

        private void Speler1Click(object sender, RoutedEventArgs e)
        {
            Speler_1_Knop.Visibility = Visibility.Hidden;
            Speler_2_Knop.Visibility = Visibility.Visible;

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

            P2_Upgrade_Body_1.Margin = new Thickness(32, 118, 644, 78);
            P2_Upgrade_Body_2.Margin = new Thickness(32, 118, 644, 78);
            P2_Upgrade_Body_3.Margin = new Thickness(32, 118, 644, 78);
            P2_Upgrade_Body_4.Margin = new Thickness(32, 118, 644, 78);

            P2_Upgrade_Motor_1.Margin = new Thickness(201, 118, 474, 78);
            P2_Upgrade_Motor_2.Margin = new Thickness(201, 118, 474, 78);
            P2_Upgrade_Motor_3.Margin = new Thickness(201, 118, 474, 78);
            P2_Upgrade_Motor_4.Margin = new Thickness(201, 118, 474, 78);

            P2_Upgrade_Wiel_1.Margin = new Thickness(449, 118, 226, 78);
            P2_Upgrade_Wiel_2.Margin = new Thickness(449, 118, 226, 78);
            P2_Upgrade_Wiel_3.Margin = new Thickness(449, 118, 226, 78);
            P2_Upgrade_Wiel_4.Margin = new Thickness(449, 118, 226, 78);

            P2_Upgrade_Suspensie_1.Margin = new Thickness(619, 118, 48, 78);
            P2_Upgrade_Suspensie_2.Margin = new Thickness(619, 118, 48, 78);
            P2_Upgrade_Suspensie_3.Margin = new Thickness(619, 118, 48, 78);
            P2_Upgrade_Suspensie_4.Margin = new Thickness(619, 118, 48, 78);
        }

        private void Speler2Click(object sender, RoutedEventArgs e)
        {
            Speler_2_Knop.Visibility = Visibility.Hidden;
            Speler_1_Knop.Visibility = Visibility.Visible;

            P1_Upgrade_Body_1.Margin = new Thickness(32, 118, 644, 78);
            P1_Upgrade_Body_2.Margin = new Thickness(32, 118, 644, 78);
            P1_Upgrade_Body_3.Margin = new Thickness(32, 118, 644, 78);
            P1_Upgrade_Body_4.Margin = new Thickness(32, 118, 644, 78);

            P1_Upgrade_Motor_1.Margin = new Thickness(201, 118, 474, 78);
            P1_Upgrade_Motor_2.Margin = new Thickness(201, 118, 474, 78);
            P1_Upgrade_Motor_3.Margin = new Thickness(201, 118, 474, 78);
            P1_Upgrade_Motor_4.Margin = new Thickness(201, 118, 474, 78);

            P1_Upgrade_Wiel_1.Margin = new Thickness(449, 118, 226, 78);
            P1_Upgrade_Wiel_2.Margin = new Thickness(449, 118, 226, 78);
            P1_Upgrade_Wiel_3.Margin = new Thickness(449, 118, 226, 78);
            P1_Upgrade_Wiel_4.Margin = new Thickness(449, 118, 226, 78);

            P1_Upgrade_Suspensie_1.Margin = new Thickness(619, 118, 48, 78);
            P1_Upgrade_Suspensie_2.Margin = new Thickness(619, 118, 48, 78);
            P1_Upgrade_Suspensie_3.Margin = new Thickness(619, 118, 48, 78);
            P1_Upgrade_Suspensie_4.Margin = new Thickness(619, 118, 48, 78);

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

        // Einde Upgrades
    }
}
// Funtionalitiet knoppen nog toevoegen en switchen tussen upgrades player 1 en 2 doet niks
