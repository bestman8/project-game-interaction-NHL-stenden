﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Windows;
using static project_1_game_inteact.start;
using System.Resources;
namespace project_1_game_inteact
{
    public class LeaderboardEntry
    {
        public string Namen { get; set; }
        public int Punten { get; set; }  
    }

    public partial class Leaderboard : Window  
    {
        private Dictionary<string, List<LeaderboardEntry>> entries = new Dictionary<string, List<LeaderboardEntry>>();

        public Leaderboard()
        {
            InitializeComponent();  
            Load("datastorage.json");              
            AddEntry("level_1");               
        }
        public void Load(string filename)
        {
            filename = "datastorage.json";
            if (File.Exists(filename))
            {
                try
                {
                    string json = File.ReadAllText(filename);
                    var data = JsonConvert.DeserializeObject<structure>(json);

                    if (data?.entries != null)
                    {
                        entries = data.entries;  
                    }               
                }
                catch (JsonException jsonEx)
                {
                    Console.WriteLine($"JSON error: {jsonEx.Message}");
                    entries = new Dictionary<string, List<LeaderboardEntry>>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"error: {ex.Message}");
                    entries = new Dictionary<string, List<LeaderboardEntry>>();
                }
            }
            else
            {
                Console.WriteLine("geen datastorage gevonden");
            }
            LeaderboardDataGrid.ItemsSource = entries["level_1"];
        
        }

        public void AddEntry(string levelName)
        {
            if (!entries.ContainsKey(levelName))
            {
                entries[levelName] = new List<LeaderboardEntry>();
            }         
            entries[levelName].Add(new LeaderboardEntry{Namen = SharedData.Instance.Naam1, Punten = SharedData.Instance.Geld1});
            entries[levelName].Add(new LeaderboardEntry{Namen = SharedData.Instance.Naam2, Punten = SharedData.Instance.Geld2});
            Save("datastorage.json");
        }

        public void Save(string filename)
        {
            filename = "datastorage.json";
            var rootObject = new structure { entries = entries };
            string json = JsonConvert.SerializeObject(rootObject, Formatting.Indented);
            File.WriteAllText(filename, json);
        }

        public class structure
        {
            public Dictionary<string, List<LeaderboardEntry>> entries { get; set; }
            public List<string> exclude { get; set; }
        }

        private void level_click(object sender, RoutedEventArgs e)
        {
            project_1_game_inteact.start start2 = new project_1_game_inteact.start();
            start2.Show();
            this.Close();
        }
    }

}
