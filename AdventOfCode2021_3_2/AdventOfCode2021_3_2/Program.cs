using System;
using System.Collections.Generic;

namespace AdventOfCode2021_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("input");
            int length = lines[0].Length;

            //find oxygen generator rating
            List<string> linesList = new List<string>(lines);
            int i = 0;
            while (linesList.Count != 1)
            {
                int ones = 0;
                int zeros = 0;
                //calculate number of ones and zeros
                for(int j = 0; j < linesList.Count; j++)
                {
                    if(linesList[j].ToCharArray()[i] == '1')
                    {
                        ones++;
                    }
                    else zeros++;
                }
                //keep only numbers with the most common value in the current bit position, if equals, keep values with 1
                if(ones >= zeros)
                {
                    linesList.RemoveAll(x => x.ToCharArray()[i] == '0');
                }else linesList.RemoveAll(x => x.ToCharArray()[i] == '1');
                i++;
            }
            string oxygenRating = linesList[0];


            //find CO2 scrubber rating
            linesList = new List<string>(lines);
            i = 0;
            while (linesList.Count != 1)
            {
                int ones = 0;
                int zeros = 0;
                //calculate number of ones and zeros
                for (int j = 0; j < linesList.Count; j++)
                {
                    if (linesList[j].ToCharArray()[i] == '1')
                    {
                        ones++;
                    }
                    else zeros++;
                }
                //keep only numbers with the least common value in the current bit position, if equals, keep values with 0
                if (ones < zeros)
                {
                    linesList.RemoveAll(x => x.ToCharArray()[i] == '0');
                }
                else linesList.RemoveAll(x => x.ToCharArray()[i] == '1');
                i++;
            }

            string co2ScrubberRating = linesList[0];

            int oxygenValue = 0;
            int co2ScrubberValue = 0;
            int x = 1;
            //calculate binary values of both ratings
            for (i = length - 1; i >= 0; i--)
            {
                oxygenValue += x * int.Parse(oxygenRating.ToCharArray()[i].ToString());
                co2ScrubberValue += x * int.Parse(co2ScrubberRating.ToCharArray()[i].ToString());
                x *= 2;
            }
            //print life support rating to console
            Console.WriteLine(oxygenValue * co2ScrubberValue);

        }
    }
}
