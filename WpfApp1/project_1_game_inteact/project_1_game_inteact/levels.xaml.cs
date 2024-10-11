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
    /// Interaction logic for levels.xaml
    /// </summary>
    public partial class levels : Window
    {
        public levels()
        {
            InitializeComponent();

           


        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            project_1_game_inteact.Spel_scherm secondWindow = new project_1_game_inteact.Spel_scherm();
            secondWindow.Show();
        }
    }
}
