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
            project_1_game_inteact.handleiding handleiding2 = new handleiding();
            handleiding2.Show();
            this.Close();
        }

        private void instellingen_Click(object sender, RoutedEventArgs e)
        {
            // als jelle gemerged heeft kan hier de code naar het instellingen scherm worden toegevoegd

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
        }

        private void nspeler2_KeyUp(object sender, KeyEventArgs e)
        {
            SharedData.Instance.Naam2 = nspeler2.Text;
        }

        private void nspeler1_KeyUp(object sender, KeyEventArgs e)
        {
            SharedData.Instance.Naam1 = nspeler1.Text;
        }

        private void G2Up(object sender, KeyEventArgs e)
        {
            SharedData.Instance.Geld2 = Convert.ToInt32(G2.Text);
        }

        private void G1Up(object sender, KeyEventArgs e)
        {
            SharedData.Instance.Geld1 = Convert.ToInt32(G1.Text);
        }
    }
}
