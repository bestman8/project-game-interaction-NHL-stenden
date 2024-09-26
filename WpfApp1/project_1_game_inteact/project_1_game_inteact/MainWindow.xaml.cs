
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
            multi.Content = "Samen spelen \n Alleen spelen";
        }

        private void multi_Click(object sender, RoutedEventArgs e)
        {
            bool knop = true;

            if (knop == true) 
            {
              

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