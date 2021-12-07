using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_6
{
    class Day6_1
    {
        public static void Run()
        {
            const int DAYS_LENGTH = 80;
            string lanternfishesInput = System.IO.File.ReadAllLines("input")[0];
            List<int> lanternfishes = new List<int>(Array.ConvertAll(lanternfishesInput.Split(','), l=>int.Parse(l)));
            for(int i = 0; i < DAYS_LENGTH; i++)
            {
                List<int> newLanternfishes = new List<int>();
                for(int j = 0; j < lanternfishes.Count; j++)
                {
                    if(lanternfishes[j] == 0)
                    {
                        lanternfishes[j] = 6;
                        newLanternfishes.Add(8);
                    }
                    else
                    {
                        lanternfishes[j] = lanternfishes[j] - 1;
                    }
                }
                lanternfishes.AddRange(newLanternfishes);
            }
            Console.WriteLine(lanternfishes.Count);
        }
    }
}
