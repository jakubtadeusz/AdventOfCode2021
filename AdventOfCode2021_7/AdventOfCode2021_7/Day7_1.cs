using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_7
{
    class Day7_1
    {
        public static void Run()
        {
            int[] lines = Array.ConvertAll(System.IO.File.ReadAllLines("input")[0].Split(','), l => int.Parse(l));
            Array.Sort(lines);
            int median = 0;
            if (lines.Length % 2 == 0)
            {
                var firstValue = lines[(lines.Length / 2) - 1];
                var secondValue = lines[(lines.Length / 2)];
                median = (int)((firstValue + secondValue) / 2.0);
            }
            if (lines.Length % 2 == 1)
            {
                median = lines[(lines.Length / 2)];
            }

            int fuelCost = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                fuelCost += Math.Abs(lines[i] - median);
            }
            Console.WriteLine(fuelCost);
        }
    }
}
