using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataCleaner
{
    class ScheduleParser
    {
        static void Main(string[] args)
        {
            String[] teamNames =  { "ARI", "ATL", "BAL", "BOS", "CHC", "CHW", "CIN", "CLE", "COL", "DET", "HOU", "KCR", "LAA", "LAD", "MIA", "MIL", "MIN", "NYM", "NYY", "OAK", "PHI", "PIT", "SDP", "SEA", "SFG", "STL", "TBR", "TEX", "TOR", "WSN" };
            var files = Directory.GetFiles(@"C:\Dev\SharkWeek\2015");

            foreach (var file in files)
            {
                var csv = new StringBuilder();
                foreach (var name in teamNames)
                {
                    var reader = new StreamReader(File.OpenRead(file));
                    var list = new List<String>();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        if (values[0].Equals(name))
                        {
                            foreach (var value in values)
                                if (!value.Equals(name))
                                    list.Add(value);
                        }
                    }

                    reader.Close();

                    csv.AppendLine(String.Join(",", list));
                }

                File.WriteAllText(file.Substring(0, file.Length - 4) + "Clean.csv", csv.ToString());
            }
            /*
            var reader = new StreamReader(File.OpenRead(@"C:\Dev\SharkWeek\2015\TeamSchedules\WSN.csv"));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            List<string> listC = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                if (values == null || values.Length < 4)
                    continue;

                if (!values[4].Equals("Tm"))
                    listA.Add(values[4]);
                if (!values[6].Equals("Opp"))
                    listB.Add(values[6]);
                if (!values[7].Equals("W/L"))
                    listC.Add(values[7]);
            }

            var csv = new StringBuilder();

            for (var i = 0; i < listA.Count; i++)
            {
                var newLine = string.Format("{0},{1},{2}", listA.ElementAt(i), listB.ElementAt(i), listC.ElementAt(i));
                csv.AppendLine(newLine);
            }
            

            //after your loop
            File.WriteAllText(@"C:\Dev\SharkWeek\Baseball\TeamSchedules\WSNClean.csv", csv.ToString());
            */
        }
    }
}
