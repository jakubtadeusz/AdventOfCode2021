using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_10
{
    class Day10_1
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines("input");

            int points = 0;

            char[] left = { '(', '[', '{', '<' };
            char[] right = { ')', ']', '}', '>' };

            foreach (var line in lines)
            {
                char[] characters = line.ToCharArray();
                Stack<char> characterStack = new Stack<char>();
                for (int i = 0; i < characters.Length; i++)
                {
                    char character = characters[i];
                    if (Array.IndexOf(left, character) != -1)
                    {
                        characterStack.Push(character);
                    }
                    else
                    {
                        char leftCharacter = characterStack.Pop();
                        if (Array.IndexOf(left, leftCharacter) != Array.IndexOf(right, character))
                        {
                            points += CalculatePoints(character);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(points);
        }

        private static int CalculatePoints(char character)
        {
            switch (character)
            {
                case ')': return 3;
                case ']': return 57;
                case '}': return 1197;
                case '>': return 25137;
                default: return 0;
            }
        }
    }
}
