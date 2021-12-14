using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021_14
{
    internal class Day14_1
    {
        private static int STEPS = 10;

        internal static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines("input");
            string polymer = lines[0];

            int step = 0;
            while (step < STEPS)
            {
                string newPolymer = polymer;
                int offset = 0;
                for (int j = 0; j < polymer.Length - 1; j++)
                {
                    for (int i = 2; i < lines.Length; i++)
                    {
                        var input = lines[i].Split();
                        string template = input[0];
                        if (polymer[j] == template[0] && polymer[j + 1] == template[1])
                        {
                            newPolymer = newPolymer.Substring(0, j + 1 + offset) + input[2] + polymer.Substring(j + 1);
                            offset++;
                            break;
                        }
                    }
                }
                polymer = newPolymer;
                step++;
            }

            Dictionary<char, int> result = polymer.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            Console.WriteLine(result.Values.Max() - result.Values.Min());
        }
    }
}