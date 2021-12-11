using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_11
{
    class Day11_1
    {
        private static int STEPS = 100;
        private static int flashes = 0;

        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines("input");

            int[][] octopuses = new int[10][];
            for(int i = 0; i < 10; i++)
            {
                char[] numbers = lines[i].ToCharArray();
                octopuses[i] = Array.ConvertAll<char, int>(numbers, number=>number-'0');
            }

            
            for(int day = 0; day < Day11_1.STEPS; day++)
            {
                IncreaseEnergyLevels(octopuses);

                for(int i = 0; i < 10; i++)
                {
                    for(int j = 0; j < 10; j++)
                    {
                        if (octopuses[i][j] > 9) FlashOctopus(i, j, octopuses);
                    }
                }
              /*  Console.WriteLine("Day " + (day+1) + ":") ;
                for(int i = 0; i < 10; i++)
                {
                    Console.WriteLine();
                    for(int j = 0; j < 10; j++)
                    {
                        Console.Write(octopuses[i][j]);
                    }   
                }
                Console.WriteLine();*/
            }
            Console.WriteLine(flashes);
        }

        private static void FlashOctopus(int i, int j, int[][] octopuses)
        {
            flashes++;
            octopuses[i][j] = 0;

            List<(int, int)> neighbors = new List<(int, int)>();
            if(i > 0)
            {
                if(j > 0)
                {
                    neighbors.Add((i-1, j-1));
                }
                neighbors.Add((i - 1, j));
                if(j < octopuses.Length-1)
                {
                    neighbors.Add((i - 1, j+1));
                }
            }
            if(j > 0)
            {
                neighbors.Add((i, j - 1));
            }
            if (j < octopuses.Length-1)
            {
                neighbors.Add((i, j + 1));
            }
            if (i < octopuses.Length-1)
            {
                {
                    if (j > 0)
                    {
                        neighbors.Add((i + 1, j - 1));
                    }
                    neighbors.Add((i + 1, j));
                    if (j < octopuses.Length-1)
                    {
                        neighbors.Add((i + 1, j + 1));
                    }
                }
            }

            foreach(var octopus in neighbors)
            {
                if (octopuses[octopus.Item1][octopus.Item2] != 0)
                {
                    octopuses[octopus.Item1][octopus.Item2]++;
                    if (octopuses[octopus.Item1][octopus.Item2] > 9) FlashOctopus(octopus.Item1, octopus.Item2, octopuses);

                }
            }

        }

        private static void IncreaseEnergyLevels(int[][] octopuses)
        {
            for(int i = 0; i < octopuses.Length; i++)
            {
                for(int j = 0; j < octopuses[i].Length; j++)
                {
                    octopuses[i][j]++;
                }
            }
        }
    }
}
