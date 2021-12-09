using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_9
{
    class Day9_1
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines("input");
            int sum = 0;
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
                        sum += (number + 1);
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
