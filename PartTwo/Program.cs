using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace PartTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileStream = new FileStream("football.dat", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                Regex rgx = new Regex("\\s+");
                int minDifference = int.MaxValue;
                string minTeam = string.Empty;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var toks = rgx.Split(line.Trim());
                    if (!int.TryParse(toks[0].Trim('.'), out var _))
                    {
                        continue;
                    }
                    int scored_for = int.Parse(toks[6]);
                    int scored_against = int.Parse(toks[8]);
                    // TODO wait for clarification
                    int difference = scored_for - scored_against;
                    if (difference < minDifference)
                    {
                        minDifference = difference;
                        minTeam = toks[1];
                    }
                }
                System.Console.WriteLine($"The team with the smallest difference in ‘for’ and ‘against’ goals is {minTeam}.");
            }
        }
    }
}
