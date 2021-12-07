using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_7
{
    class Day7_2
    {
        public static void Run()
        {
            int[] lines = Array.ConvertAll(System.IO.File.ReadAllLines("input")[0].Split(','), l => int.Parse(l));
            int mean = (int)Math.Round(lines.Average());
            int solution = mean;
            int solutionCost = CalculateSolutionCost(lines, solution);
            int newSolutionRight = solution + 1;
            int newSolutionLeft = solution - 1;
            int rightSolutionCost = CalculateSolutionCost(lines, newSolutionRight);
            int leftSolutionCost = CalculateSolutionCost(lines, newSolutionLeft);
            while(rightSolutionCost < solutionCost)
            {
                solution = newSolutionRight;
                newSolutionRight = solution + 1;
                solutionCost = rightSolutionCost;
            }

            while (leftSolutionCost < solutionCost)
            {
                solution = newSolutionLeft;
                newSolutionLeft = solution + 1;
                solutionCost = leftSolutionCost;
            }

            Console.WriteLine(solutionCost);
        }

        private static int CalculateSolutionCost(int[] lines, int solution)
        {
            int cost = 0;
            for(int i = 0; i < lines.Length; i++)
            {
                cost  += CalculateFuelConsumption(lines[i], solution);
            }
            return cost;
        }

        public static int CalculateFuelConsumption(int start, int end)
        {
            int cost = 1;
            int fuelConsumption = 0;
            if(end < start)
            {
                int temp = start;
                start = end;
                end = temp;
            }
            for(int i = start; i <end; i++)
            {
                fuelConsumption += cost;
                cost++;
            }
            return fuelConsumption;
        }
    }
}
