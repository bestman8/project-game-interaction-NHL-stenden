
using System.Runtime.ExceptionServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UItest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            multi.Content = "Alleen spelen";
         
        }
        private int j = 0;
        private void multi_Click(object sender, RoutedEventArgs e)
        {


            if (j == 1)
            {
                multi.Content = "Alleen spelen";
                j = 0;
                speler1.Visibility = Visibility.Visible;
                speler2.Visibility = Visibility.Visible;
                lspeler1.Visibility = Visibility.Visible;   
                lspeler2.Visibility = Visibility.Visible;   
                
            }
            else if (j == 0)
            {
                multi.Content = "Samen spelen";
                j = 1;
                speler1.Visibility = Visibility.Visible;        
                lspeler1.Visibility = Visibility.Visible;
                lspeler2.Visibility = Visibility.Hidden;
                speler2.Visibility = Visibility.Hidden;
               
            }

        }

        private void levels_Click(object sender, RoutedEventArgs e)
        {


            this.Hide();


            UItest.levels secondWindow = new UItest.levels();
            secondWindow.Show();


        }
    }
}