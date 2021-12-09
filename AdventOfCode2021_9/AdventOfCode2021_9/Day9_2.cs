using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_9
{
    class Day9_2
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines("input");
            List<int> basins = new List<int>();
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    List<int> neighbors = new List<int>();
                    int number = int.Parse(lines[i].ToCharArray()[j].ToString());
                    if (i > 0)
                    {
                        neighbors.Add(int.Parse(lines[i - 1].ToCharArray()[j].ToString()));
                    }
                    if (i < lines.Length - 1)
                    {
                        neighbors.Add(int.Parse(lines[i + 1].ToCharArray()[j].ToString()));
                    }
                    if (j > 0)
                    {
                        neighbors.Add(int.Parse(lines[i].ToCharArray()[j - 1].ToString()));
                    }
                    if (j < lines[i].Length - 1)
                    {
                        neighbors.Add(int.Parse(lines[i].ToCharArray()[j + 1].ToString()));
                    }
                    bool smallest = true;
                    foreach (var item in neighbors)
                    {
                        if (item <= number) smallest = false;
                    }
                    if (smallest)
                    {
                        basins.Add(GetBasinValue(GetBasin(i, j, lines), lines));
                    }
                }
            }
            var orderedBasins = basins.OrderByDescending(b=>b).ToArray();
            Console.WriteLine(orderedBasins[0] * orderedBasins[1] * orderedBasins[2]);
        }

        private static int GetBasinValue(HashSet<(int, int)> hashSet, string [] lines)
        {
            int sum = hashSet.Count;
            return sum;
        }

        private static HashSet<(int, int)> GetBasin(int i, int j, string[] lines)
        {
            HashSet<(int, int)> basins = new HashSet<(int, int)>();
            int number = int.Parse(lines[i].ToCharArray()[j].ToString());
            if (number != 9) basins.Add((i, j));

            if (i > 0)
            {
                int nextNumber = int.Parse(lines[i - 1].ToCharArray()[j].ToString());
                if (nextNumber > number)
                {
                    basins.UnionWith(GetBasin(i - 1, j, lines));
                }
            }

            if (i < lines.Length - 1)
            {
                int nextNumber = int.Parse(lines[i + 1].ToCharArray()[j].ToString());
                if (nextNumber > number)
                {
                    basins.UnionWith(GetBasin(i + 1, j, lines));
                }
            }
            if (j > 0)
            {
                int nextNumber = int.Parse(lines[i].ToCharArray()[j - 1].ToString());
                if (nextNumber > number)
                {
                    basins.UnionWith(GetBasin(i, j - 1, lines));
                }
            }
            if (j < lines[i].Length - 1)
            {
                int nextNumber = int.Parse(lines[i].ToCharArray()[j + 1].ToString());
                if (nextNumber > number)
                {
                    basins.UnionWith(GetBasin(i, j + 1, lines));
                }
            }

            return basins;
        }
    }
}
