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
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace project_1_game_inteact
{
    /// <summary>
    /// Interaction logic for leaderboard.xaml
    /// </summary>
    public partial class leaderboard : Window
    {
        private Dictionary<string, List<leaderboard>> entries = new Dictionary<string, List<leaderboard>>();
        public string name { get; set; }
        public int points { get; set; }
        public leaderboard()
        {
            InitializeComponent();
        }
        public void Load(string filename)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                entries = JsonConvert.DeserializeObject<Dictionary<string, List<leaderboard>>>(json);
            }
            else
            {
                entries = new Dictionary<string, List<leaderboard>>();
            }


        }

        public void Add(string name, int points)
        {
            if (!entries.ContainsKey(name))
            {
                entries[name] = new List<leaderboard>();
            }
            entries[name].Add(new leaderboard() { Name = name, points = points });
        }

        public void Save(string filename)
        {
            string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
            File.WriteAllText(filename, json);
        }

        public void DisplayEntries()
        {
            // Flatten the dictionary to a list of entries
            List<leaderboard> allEntries = new List<leaderboard>();
            foreach (var entryList in entries.Values)
            {
                allEntries.AddRange(entryList);
            }

            // Bind the list to the DataGrid
            LeaderboardDataGrid.ItemsSource = allEntries;
        }

        public class LeaderboardEntry
        {
            public string name { get; set; }
            public int points { get; set; }  // Or Time if you're tracking time
        }
    }
}
