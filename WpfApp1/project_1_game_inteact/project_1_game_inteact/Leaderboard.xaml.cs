using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Windows;

namespace project_1_game_inteact
{
    public class LeaderboardEntry
    {
        public string Name { get; set; }
        public int Punten { get; set; }  // Changed Time to Punten
    }

    public partial class Leaderboard : Window  // Assuming this is a WPF Window
    {
        private Dictionary<string, List<LeaderboardEntry>> entries = new Dictionary<string, List<LeaderboardEntry>>();

        public Leaderboard()
        {
            InitializeComponent();  // Ensure you have this if it's a WPF window
            Load("datastorage.json");  // Load data from datastorage.json when the window is initialized
          
            // Use ShareData to add entries to the leaderboard
            AddEntry("level_1", SharedData.Instance.Naam1, SharedData.Instance.Geld1, SharedData.Instance.Naam2, SharedData.Instance.Geld2);
          

            DisplayEntries();  // Display the entries in the DataGrid
        }

        public void Load(string filename)
        {
            filename = "datastorage.json";
            if (File.Exists(filename))
            {
                try
                {
                    string json = File.ReadAllText(filename);
                    var data = JsonConvert.DeserializeObject<RootObject>(json);

                    if (data?.entries != null)
                    {
                        entries = data.entries;  // Assign the loaded entries
                    }

                    Console.WriteLine("Leaderboard entries loaded successfully.");
                }
                catch (JsonException jsonEx)
                {
                    Console.WriteLine($"JSON deserialization error: {jsonEx.Message}");
                    entries = new Dictionary<string, List<LeaderboardEntry>>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    entries = new Dictionary<string, List<LeaderboardEntry>>();
                }
            }
            else
            {
                Console.WriteLine("No existing leaderboard file found, initializing a new leaderboard.");
            }
        }


        public void AddEntry(string levelName, string name1, int punten1, string name2, int punten2)
        {
            if (!entries.ContainsKey(levelName))
            {
                entries[levelName] = new List<LeaderboardEntry>();
            }

            entries[levelName].AddRange(new List<LeaderboardEntry>
            {
        new LeaderboardEntry { Name = name1, Punten = punten1 },
        new LeaderboardEntry { Name = name2, Punten = punten2 }
            });
        }


        public void Save(string filename)
        {
            string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
            File.WriteAllText(filename, json);
            Save("datastorage.json");
        }

        public void DisplayEntries()
        {
            // You would implement this method to display entries in a WPF DataGrid
            foreach (var level in entries)
            {
                Console.WriteLine($"Entries for {level.Key}:");
                foreach (var entry in level.Value)
                {
                    Console.WriteLine($"Name: {entry.Name}, Punten: {entry.Punten}");
                }
            }
        }


        public class SharedData
        {
            private static SharedData _instance;
            public static SharedData Instance => _instance ??= new SharedData();

            public string Naam1 { get; set; }
            public string Naam2 { get; set; } 
            public int Geld1 { get; set; } 
            public int Geld2 { get; set; } 

            // Constructor to initialize ShareData (optional)

        }
        public class RootObject
        {
            public Dictionary<string, List<LeaderboardEntry>> entries { get; set; }
            public List<string> exclude { get; set; }
        }
    }
}
