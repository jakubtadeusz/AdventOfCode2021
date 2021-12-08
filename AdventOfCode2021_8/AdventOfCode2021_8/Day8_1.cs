using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021_8
{
    class Day8_1
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines("input");
            int count = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var outputString = lines[i].Split('|')[1];
                List<string> digits = new List<string>(outputString.Split(' '));
                digits.RemoveAt(0);
                foreach (var item in digits)
                {
                    if (item.Length == 2 || item.Length == 4 || item.Length == 3 || item.Length == 7) count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
