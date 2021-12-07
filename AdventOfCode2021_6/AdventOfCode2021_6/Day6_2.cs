using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_6
{
    class Day6_2
    {
        public static void Run()
        {
            const int DAYS_LENGTH = 256;
            string lanternfishesInput = System.IO.File.ReadAllLines("input")[0];
            long [] startingLanternfishes = Array.ConvertAll(lanternfishesInput.Split(','), l => long.Parse(l));
            long lanternfishesAmount = startingLanternfishes.Length;
            long[] lanternfishesCounter = new long[9];

            for(int i = 0; i < lanternfishesAmount; i++)
            {
                lanternfishesCounter[startingLanternfishes[i]]++;
            }

            for(int i = 0; i < DAYS_LENGTH; i++)
            {
                long[] newLanternfishesCounter = new long[9];
                lanternfishesAmount += lanternfishesCounter[0];
                newLanternfishesCounter[8] = lanternfishesCounter[0];
                newLanternfishesCounter[6] += lanternfishesCounter[0];
                for(int j = 1; j <= 8; j++)
                {
                    newLanternfishesCounter[j - 1] += lanternfishesCounter[j];
                }
                lanternfishesCounter = newLanternfishesCounter;
            }

            Console.WriteLine(lanternfishesAmount);
        }
    }
}
