using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace PartThree
{
    class Program
    {
        static void Main(string[] args)
        {
            var file1 = "weather.dat";
            var msg1 = "The day of the smallest spread is day number";
            var file2 = "football.dat";
            var msg2 = "The team with the smallest difference in ‘for’ and ‘against’ goals is";

            DisplaySmallest(file1, 1, 2, 0, msg1);
            DisplaySmallest(file2, 6, 8, 1, msg2);
        }

        static void DisplaySmallest(string infile, int col_l, int col_r, int col_out, string msg)
        {
            var fileStream = new FileStream(infile, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                Regex rgx = new Regex("\\s+");
                int minDifference = int.MaxValue;
                string minField = string.Empty;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var toks = rgx.Split(line.Trim());
                    if (!int.TryParse(toks[0].Trim('.'), out var _))
                    {
                        continue;
                    }
                    int val_l = int.Parse(toks[col_l].Trim('*'));
                    int val_r = int.Parse(toks[col_r].Trim('*'));
                    // TODO wait for clarification
                    int difference = val_l - val_r;
                    if (difference < minDifference)
                    {
                        minDifference = difference;
                        minField = toks[col_out];
                    }
                }
                System.Console.WriteLine($"{msg} {minField}.");
            }
        }
    }
}
