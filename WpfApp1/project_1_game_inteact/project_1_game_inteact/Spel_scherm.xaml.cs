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
using System.Windows.Threading;

namespace project_1_game_inteact
{
    /// <summary>
    /// Interaction logic for Spel_scherm.xaml
    /// </summary>
    public partial class Spel_scherm : Window
    {

        private bool left1, right1, left2, right2;
        private DispatcherTimer timer = new DispatcherTimer();
        private int HeadX1 = 50, HeadX2 = 50;
        private int speed = 3;
        public Spel_scherm()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(16);
            timer.Tick += tick;
            timer.Start();
        }

        private void tick(object sender, EventArgs e)
        {
            double x = LeftCanvas.ActualWidth - 51.5;
            double y = RightCanvas.ActualWidth - 51.5;

            if (left1 && HeadX1 > 0)
            {
                HeadX1 -= speed; 
            }
            else if (right1 && HeadX1 < x)
            {
                HeadX1 += speed;
            }
            if (left2 && HeadX2 > 0)
            {
                HeadX2 -= speed;
            }
            else if (right2 && HeadX2 < y)
            {
                HeadX2 += speed;
            }


            Canvas.SetLeft(speler1, HeadX1);
            Canvas.SetLeft(speler2, HeadX2);

        }

        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                right1 = true;
            }
            else if(e.Key == Key.A)
            {
                left1 = true;
            }
            if (e.Key == Key.Right)
            {
                right2 = true;
            }
            else if (e.Key == Key.Left)
            {
                left2 = true;
            }
        }
        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
                right1 = false;
            }
            else if (e.Key == Key.A)
            {
                left1 = false;
            }
            if (e.Key == Key.Right)
            {
                right2 = false;
            }
            else if (e.Key == Key.Left)
            {
                left2 = false;
            }
        }


        private void Upgrades_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Upgrades upgradesWindow = new Upgrades();
            upgradesWindow.Show();
        }

        private void Startscherm_button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UItest.MainWindow secondWindow = new UItest.MainWindow();
            secondWindow.Show();
        }

        private void Levels_button_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();


            UItest.levels secondWindow = new UItest.levels();
            secondWindow.Show();
        }
    }
}
