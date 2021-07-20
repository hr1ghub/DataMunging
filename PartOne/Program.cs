using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace PartOne
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileStream = new FileStream("weather.dat", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                Regex rgx = new Regex("\\s+");
                int min_spread = Int32.MaxValue;
                int min_day = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var toks = rgx.Split(line.Trim());
                    int day;
                    if (!Int32.TryParse(toks[0], out day)) {
                        continue;
                    }
                    int max_temp = Int32.Parse(toks[1].Trim('*'));
                    int min_temp = Int32.Parse(toks[2].Trim('*'));
                    int spread = max_temp - min_temp;
                    if (spread < min_spread)
                    {
                        min_spread = spread;
                        min_day = day;
                    }
                }
                System.Console.WriteLine($"The day of the smallest spread is day number {min_day}");
            }
        }
    }
}
