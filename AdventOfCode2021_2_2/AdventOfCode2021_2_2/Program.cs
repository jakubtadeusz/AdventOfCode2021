using System;
using System.IO;

namespace AdventOfCode2021_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;
            StreamReader dataStream = new StreamReader("input");
            string datasample;
            while ((datasample = dataStream.ReadLine()) != null)
            {
                //parse data from input file
                string command = datasample.Split(' ')[0];
                int data = int.Parse(datasample.Split(' ')[1]);
                switch (command)
                {
                    case "down": aim+= data; break;
                    case "up": aim -= data; break;
                    case "forward": 
                        horizontal += data;
                        depth += data * aim;
                        break;
                }
            }
            Console.WriteLine(horizontal * depth);
        }
    }
}
