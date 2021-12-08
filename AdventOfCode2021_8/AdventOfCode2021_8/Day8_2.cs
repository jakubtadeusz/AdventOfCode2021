using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2021_8
{
    class Day8_2
    {
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines("input");
            int count = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var inputString = lines[i].Split('|');
                char[] digitsFormat = new char[7];
                // List<string> patterns = new List<string>(inputString[0].Split(' '));
                var patterns = inputString[0].Split(' ').Where(x => x != "").OrderBy(x => x.Length).ToArray();
                digitsFormat = GetDigitFormat(patterns);
                var outputDigits = inputString[1].Split(' ').Where(x => x != "").ToArray();
                int value = CalculateValue(outputDigits, digitsFormat);
                Console.WriteLine(value);
                count += value;
            }
            Console.WriteLine(count);
        }

        private static int CalculateValue(string[] outputDigits, char[] digitsFormat)
        {
            int val = 0;
            for(int i = 0; i < outputDigits.Length ; i++)
            {
                int digit = GetDigitValue(outputDigits[i], digitsFormat);
                val += (int)Math.Pow(10, (outputDigits.Length - 1) - i) * digit;
            }
            return val;
        }

        private static int GetDigitValue(string digit, char[] digitsFormat)
        {
            switch (digit.Length)
            {
                case 2: return 1;
                case 3: return 7;
                case 4: return 4;
                case 7: return 8;
                case 5:
                    if (digit.Contains(digitsFormat[4]))
                    {
                        return 2;
                    }
                    else
                    {
                        if (digit.Contains(digitsFormat[2]))
                        {
                            return 3;
                        }
                        else return 5;
                    }
                case 6:
                    if (!digit.Contains(digitsFormat[3])) return 0;
                    if (digit.Contains(digitsFormat[2])) return 9;
                    return 6;
            }
            return -1;
        }

        private static char[] GetDigitFormat(string [] patterns)
        {
            char[] digitsFormat = new char[7];
            
            digitsFormat[0] = Subtract(patterns[1], patterns[0])[0];

            List<char> x = new List<char>();
            foreach (var item in patterns.Where(p => p.Length == 6))
            {
                x.AddRange(Subtract(patterns[9], item));
            }

            var temp = Subtract(Subtract(patterns[2], x), patterns[0]);
            digitsFormat[1] = temp[0];

            foreach (var item in patterns.Where(p => p.Length == 6))
            {
                var common = GetCommon(patterns[0], item);
                if (common.Count == 1) digitsFormat[2] = Subtract(patterns[0], common)[0];
            }

            x = Subtract(Subtract(patterns[2], patterns[0]), digitsFormat[1].ToString());
            digitsFormat[3] = x[0];

            x = Subtract(patterns[0], digitsFormat[2].ToString());
            digitsFormat[5] = x[0];

            foreach (var item in patterns.Where(p => p.Length == 5))
            {
                var t = Subtract(item, new List<char>(digitsFormat));
                if (t.Count == 1) { 
                    digitsFormat[6] = t[0];
                    break;
                }
            }
            digitsFormat[4] = Subtract(patterns[9], new List<char>(digitsFormat))[0];
            return digitsFormat;
        }

        private static List<char> GetCommon(string v1, string v2)
        {
            List<char> v1Chars = new List<char>(v1.ToCharArray());
            List<char> commons = new List<char>();
            foreach (var item in v1Chars)
            {
                if (v2.Contains(item)) commons.Add(item);
            }
            return commons;
        }

        private static List<char> Subtract(List<char> v1, string v2)
        {
            List<char> v1Chars = v1;
            List<char> result = new List<char>();
            foreach (var item in v1Chars)
            {
                if (!v2.Contains(item)) result.Add(item);
            }
            return result;
        }

        private static List<char> Subtract(string v1, List<char> v2)
        {
            List<char> v1Chars = new List<char>(v1.ToCharArray());
            List<char> result = new List<char>();
            foreach (var item in v1Chars)
            {
                if (!v2.Contains(item)) result.Add(item);
            }
            return result;
        }

        private static List<char> Subtract(string v1, string v2)
        {
            List<char> v1Chars = new List<char>(v1.ToCharArray());
            List<char> result = new List<char>();
            foreach (var item in v1Chars)
            {
                if (!v2.Contains(item)) result.Add(item);
            }
            return result;
        }
    }
}
