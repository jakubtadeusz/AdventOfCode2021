using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2021_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = new List<int>();
            StreamReader dataStream = new StreamReader("input");
            string datasample;
            while ((datasample = dataStream.ReadLine()) != null)
            {
                //parse data from input file
                lines.Add(int.Parse(datasample));
            }

            int largerMeasurements = 0;
            //get first value of measurement window
            int prevSum = lines[0] + lines[1] + lines[2];
            for (int i = 1; i < lines.Count-2; i++)
            {
                //get next value of measurement window
                int newSum = lines[i] + lines[i + 1] + lines[i + 2];
                //compare values
                if (newSum > prevSum) largerMeasurements++;
                prevSum = newSum;
            }
            Console.WriteLine(largerMeasurements);
        }
    }
}
