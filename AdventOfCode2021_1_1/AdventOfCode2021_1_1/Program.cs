using System;
using System.IO;

namespace AdventOfCode2021_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] lines = File.ReadAllLines("input");
            int largerMeasurements = 0;
            for(int i = 1; i < lines.Length; i++)
            {
                if (int.Parse(lines[i]) > int.Parse(lines[i - 1])) largerMeasurements++;
            }
            Console.WriteLine(largerMeasurements);
        }
    }
}
