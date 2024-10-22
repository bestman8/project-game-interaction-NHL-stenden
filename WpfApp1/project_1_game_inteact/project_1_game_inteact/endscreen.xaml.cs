using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Runtime.ConstrainedExecution;
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
using static project_1_game_inteact.start;
using System.Windows.Threading;
using Microsoft.VisualBasic;

namespace project_1_game_inteact
{
    /// <summary>
    /// Interaction logic for endscreen.xaml
    /// </summary>
    public partial class endscreen : Window
    {
        public int[] time1 { get; set; }
        public int[] time2 { get; set; }
        public endscreen()
        {



            InitializeComponent();
            time_s1.Content = "Tijd " + SharedData.Instance.Naam1 + ": " + SharedData.Instance.time1[0].ToString("0:00");
            time_s2.Content = "Tijd" + SharedData.Instance.Naam2 + ": " + SharedData.Instance.time2[0].ToString("0:00");



            if (SharedData.Instance.time1[0] < 10)
            {
                int multiplier = 100;
                points_s1.Content = "Punten: " + multiplier.ToString("0");
                SharedData.Instance.Geld1 = Convert.ToInt16(SharedData.Instance.Geld1 + SharedData.Instance.time1[0] * multiplier);


            }
            else if (SharedData.Instance.time1[0] < 15)
            {
                int multiplier = 75;
                points_s1.Content = "Punten: " + multiplier.ToString("0");
                SharedData.Instance.Geld1 = Convert.ToInt16(SharedData.Instance.Geld1 + SharedData.Instance.time1[0] * multiplier);

            }
            else if (SharedData.Instance.time1[0] < 25)
            {
                int multiplier = 40;
                points_s1.Content = "Punten: " + multiplier.ToString("0");
                SharedData.Instance.Geld1 = Convert.ToInt16(SharedData.Instance.Geld1 + SharedData.Instance.time1[0] * multiplier);

            }
            else
            {
                int multiplier = 0;
                points_s1.Content = "Punten: " + multiplier.ToString("0");
                SharedData.Instance.Geld1 = Convert.ToInt16(SharedData.Instance.Geld1 + SharedData.Instance.time1[0] * multiplier);

            }

            if (SharedData.Instance.time2[0] < 10)
            {
                int multiplier = 100;
                points_s2.Content = "Punten: " + multiplier.ToString("0");
                SharedData.Instance.Geld2 = Convert.ToInt16(SharedData.Instance.Geld2 + SharedData.Instance.time2[0] * multiplier);
            }
            else if (SharedData.Instance.time2[0] < 15)
            {
                int multiplier = 75;
                points_s2.Content = "Punten: " + multiplier.ToString("0");
                SharedData.Instance.Geld2 = Convert.ToInt16(SharedData.Instance.Geld2 + SharedData.Instance.time2[0] * multiplier);

            }
            else if (SharedData.Instance.time2[0] < 25)
            {
                int multiplier = 40;
                points_s2.Content = "Punten: " + multiplier.ToString("0");
                SharedData.Instance.Geld2 = Convert.ToInt16(SharedData.Instance.Geld2 + SharedData.Instance.time2[0] * multiplier);
            }
            else
            {
                int multiplier = 0;
                points_s2.Content = "Punten: " + multiplier.ToString("0");
                SharedData.Instance.Geld2 = Convert.ToInt16(SharedData.Instance.Geld2 + SharedData.Instance.time2[0] * multiplier);

            }

            //Console.WriteLine(SharedData.Instance.Geld1);


        }

     
            private void mainmenu_Click(object sender, RoutedEventArgs e)
            {
                project_1_game_inteact.start start = new start();
                start.Show();
                this.Close();
            }
        }
    }





