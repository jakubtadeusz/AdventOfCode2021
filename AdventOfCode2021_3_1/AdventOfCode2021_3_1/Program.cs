 using System;

namespace AdventOfCode2021_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("input");
            int length = lines[0].Length;
            int[] gamma = new int[length];
            int[] epsilon = new int[length];
            for(int i = 0; i < length; i++)
            {
                int zeros = 0;
                int ones = 0;
                for (int j = 0; j < lines.Length; j++)
                {
                    switch (lines[j].ToCharArray()[i])
                    {
                        case '0': zeros++; break;
                        case '1': ones++; break;
                    }
                }
                if (zeros > ones)
                {
                    gamma[i] = 0;
                    epsilon[i] = 1;
                }
                else
                {
                    gamma[i] = 1;
                    epsilon[i] = 0;
                }
            }

            int gammaValue = 0;
            int epsilonValue = 0;
            int x = 1;
            for(int i = length-1; i >= 0; i--)
            {
                gammaValue += x * gamma[i];
                epsilonValue += x * epsilon[i];
                x *= 2;
            }
            Console.WriteLine(gammaValue*epsilonValue);
        }
    }
}
