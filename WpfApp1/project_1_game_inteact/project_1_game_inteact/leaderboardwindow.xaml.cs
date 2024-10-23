using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Resources;

namespace project_1_game_inteact
{
    /// <summary>  
    /// Interaction logic for leaderboardwindow.xaml  
    /// </summary>  
    public partial class leaderboardwindow : Window
    {



        public leaderboardwindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

            string relativepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "db", "Database1.mdf");
            string connectionString = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={relativepath};Integrated Security=True";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT [name], [points] FROM [Table]";
                cmd.Connection = connection;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
        
                DataTable datatable = new DataTable("waarden");
                adapter.Fill(datatable);
                cmd.ExecuteNonQuery();
                connection.Close();

                //bron: rené velthausz
                
                datag.ItemsSource = datatable.DefaultView;
                datag.Background = Brushes.LawnGreen;
               
                //
            }

           

        }

        private void datag_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void datag_Loaded(object sender, RoutedEventArgs e)
        {
                if (datag.Columns.Count > 0)
                {
                    datag.Columns[0].Header = "Namen";
                    datag.Columns[1].Header = "Punten";
                }

            MessageBox.Show(datag.Columns[0].Header.ToString());
        }
    }
}

