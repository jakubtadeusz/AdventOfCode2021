using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_10
{
    class Day10_2
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines("input");


            char[] left = { '(', '[', '{', '<' };
            char[] right = { ')', ']', '}', '>' };

            List<long> scores = new List<long>();

            foreach (var line in lines)
            {
                char[] characters = line.ToCharArray();
                Stack<char> characterStack = new Stack<char>();
                bool incomplete = true;
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
                            incomplete = false;
                            break;
                        }
                    }
                }
                //  Console.Write(line + "   ");
                long score = 0;
                if (incomplete)
                {
                    while (characterStack.Count != 0)
                    {
                        score = score * 5;
                        score += GetCharacterScore(characterStack.Pop());
                    }
                    scores.Add(score);
                }
            }
            scores.Sort();
            Console.WriteLine(scores[scores.Count/2]);
        }

        private static int GetCharacterScore(char v)
        {
            switch (v)
            {
                case '(': return 1;
                case '[': return 2;
                case '{': return 3;
                case '<': return 4;
                default: return 0;
            }
        }
    }
}
