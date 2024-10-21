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
        public int[] time2 { get; set; }
        public endscreen()
        {
            InitializeComponent();
            time.Content = "Tijd: " + SharedData.Instance.time2;
            points.Content = "Punten behaald: " + (SharedData.Instance.Geld1 + SharedData.Instance.Geld2) / 2;
            
    }

       
    }
}

