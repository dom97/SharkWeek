using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball
{
    public class Statistics
    {
        public String[] TeamNames = { "ARI", "ATL", "BAL", "BOS", "CHC", "CHW", "CIN", "CLE", "COL", "DET", "HOU", "KCR", "LAA", "LAD", "MIA", "MIL", "MIN", "NYM",
            "NYY", "OAK", "PHI", "PIT", "SDP", "SEA", "SFG", "STL", "TBR", "TEX", "TOR", "WSN" };

        public Dictionary<String, Int32> TeamNumbers = new Dictionary<string, int>
        {
            {"ARI", 0},
            {"ATL", 1},
            {"BAL", 2},
            {"BOS", 3},
            {"CHC", 4},
            {"CHW", 5},
            {"CIN", 6},
            {"CLE", 7},
            {"COL", 8},
            {"DET", 9},
            {"HOU", 10},
            {"KCR", 11},
            {"LAA", 12},
            {"LAD", 13},
            {"MIA", 14},
            {"MIL", 15},
            {"MIN", 16},
            {"NYM", 17},
            {"NYY", 18},
            {"OAK", 19},
            {"PHI", 20},
            {"PIT", 21},
            {"SDP", 22},
            {"SEA", 23},
            {"SFG", 24},
            {"STL", 25},
            {"TBR", 26},
            {"TEX", 27},
            {"TOR", 28},
            {"WSN", 29 }
        };

        public Boolean[,] TeamRecord { get; } = new Boolean[30,162];

        public String[,] TeamOpponents { get; } = new String [30,162];

        public Double[][][] TeamStats { get; } = new Double[10][][];
        
        public Statistics()
        {
            for (var i = 0; i < 10; i++)
                TeamStats[i] = new Double[30][];
            for (var i = 0; i < 10; i++)
                for (var j = 0; j < 30; j++)
                    TeamStats[i][j] = new Double[96];
            LoadTeamRecords();
            LoadTeamStats();
        }

        private void LoadTeamRecords()
        {
            var files = Directory.GetFiles(@"C:\Dev\SharkWeek\Baseball\TeamSchedules");
            var index = 0;
            foreach (var file in files)
            {
                var reader = new StreamReader(File.OpenRead(file));
                var game = 0;
                while (!reader.EndOfStream)
                {
                    if (game > 160)
                        break;
                    var data = reader.ReadLine().Split(',');
                    TeamRecord[index, game] = data[2].Contains("W");
                    TeamOpponents[index, game] = data[1];

                    game++;
                }
                index++;
            }
        }
        
        private void LoadTeamStats()
        {
            var dateIndex = 0;
            var statsFile = new StreamReader(File.OpenRead(@"C:\Dev\SharkWeek\Baseball\TeamStats\MLBJune30Clean.csv"));
            var index = 0;
            while (!statsFile.EndOfStream)
            {
                var value = statsFile.ReadLine().Split(',');
                for (var i = 0; i < value.Length; i++)
                {
                    TeamStats[dateIndex][index][i] = Convert.ToDouble(value[i]);
                }
                index++;
            }
            statsFile.Close();
            dateIndex++;

            statsFile = new StreamReader(File.OpenRead(@"C:\Dev\SharkWeek\Baseball\TeamStats\MLBAugust9Clean.csv"));
            index = 0;
            while (!statsFile.EndOfStream)
            {
                var value = statsFile.ReadLine().Split(',');
                for (var i = 0; i < value.Length; i++)
                {
                    TeamStats[dateIndex][index][i] = Convert.ToDouble(value[i]);
                }
                index++;
            }
            statsFile.Close();
            dateIndex++;

            statsFile = new StreamReader(File.OpenRead(@"C:\Dev\SharkWeek\Baseball\TeamStats\MLBAugust21Clean.csv"));
            index = 0;
            while (!statsFile.EndOfStream)
            {
                var value = statsFile.ReadLine().Split(',');
                for (var i = 0; i < value.Length; i++)
                {
                    TeamStats[dateIndex][index][i] = Convert.ToDouble(value[i]);
                }
                index++;
            }
            statsFile.Close();
            dateIndex++;

            statsFile = new StreamReader(File.OpenRead(@"C:\Dev\SharkWeek\Baseball\TeamStats\MLBAugust28Clean.csv"));
            index = 0;
            while (!statsFile.EndOfStream)
            {
                var value = statsFile.ReadLine().Split(',');
                for (var i = 0; i < value.Length; i++)
                {
                    TeamStats[dateIndex][index][i] = Convert.ToDouble(value[i]);
                }
                index++;
            }
            statsFile.Close();
            dateIndex++;

            statsFile = new StreamReader(File.OpenRead(@"C:\Dev\SharkWeek\Baseball\TeamStats\MLBSeptember4Clean.csv"));
            index = 0;
            while (!statsFile.EndOfStream)
            {
                var value = statsFile.ReadLine().Split(',');
                for (var i = 0; i < value.Length; i++)
                {
                    TeamStats[dateIndex][index][i] = Convert.ToDouble(value[i]);
                }
                index++;
            }
            statsFile.Close();
            dateIndex++;

            statsFile = new StreamReader(File.OpenRead(@"C:\Dev\SharkWeek\Baseball\TeamStats\MLBSeptember6Clean.csv"));
            index = 0;
            while (!statsFile.EndOfStream)
            {
                var value = statsFile.ReadLine().Split(',');
                for (var i = 0; i < value.Length; i++)
                {
                    TeamStats[dateIndex][index][i] = Convert.ToDouble(value[i]);
                }
                index++;
            }
            statsFile.Close();
            dateIndex++;

            statsFile = new StreamReader(File.OpenRead(@"C:\Dev\SharkWeek\Baseball\TeamStats\MLBSeptember13Clean.csv"));
            index = 0;
            while (!statsFile.EndOfStream)
            {
                var value = statsFile.ReadLine().Split(',');
                for (var i = 0; i < value.Length; i++)
                {
                    TeamStats[dateIndex][index][i] = Convert.ToDouble(value[i]);
                }
                index++;
            }
            statsFile.Close();
            dateIndex++;

            statsFile = new StreamReader(File.OpenRead(@"C:\Dev\SharkWeek\Baseball\TeamStats\MLBSeptember21Clean.csv"));
            index = 0;
            while (!statsFile.EndOfStream)
            {
                var value = statsFile.ReadLine().Split(',');
                for (var i = 0; i < value.Length; i++)
                {
                    TeamStats[dateIndex][index][i] = Convert.ToDouble(value[i]);
                }
                index++;
            }
            statsFile.Close();
            dateIndex++;

            statsFile = new StreamReader(File.OpenRead(@"C:\Dev\SharkWeek\Baseball\TeamStats\MLBSeptember29Clean.csv"));
            index = 0;
            while (!statsFile.EndOfStream)
            {
                var value = statsFile.ReadLine().Split(',');
                for (var i = 0; i < value.Length; i++)
                {
                    TeamStats[dateIndex][index][i] = Convert.ToDouble(value[i]);
                }
                index++;
            }
            statsFile.Close();
            dateIndex++;

            statsFile = new StreamReader(File.OpenRead(@"C:\Dev\SharkWeek\Baseball\TeamStats\MLBOctober7Clean.csv"));
            index = 0;
            while (!statsFile.EndOfStream)
            {
                var value = statsFile.ReadLine().Split(',');
                for (var i = 0; i < value.Length; i++)
                {
                    TeamStats[dateIndex][index][i] = Convert.ToDouble(value[i]);
                }
                index++;
            }
            statsFile.Close();
            dateIndex++;
        }

    }
}
