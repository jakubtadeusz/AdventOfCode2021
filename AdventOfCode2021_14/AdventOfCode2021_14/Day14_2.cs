using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021_14
{
    public class Day14_2
    {
        private static int STEPS =40;

        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines("input");
            string polymer = lines[0];
            Dictionary<char, ulong> result = new Dictionary<char, ulong>();

            Dictionary<string, char> templates = new Dictionary<string, char>();
            Dictionary<string, ulong> pairs = new Dictionary<string, ulong>();
            foreach(var item in templates.Values)
            {
                result[item] = 0;
            }


            for (int i = 2; i < lines.Length; i++)
            {
                var input = lines[i].Split();
                string template = input[0];
                templates[template] = input[2].ToCharArray()[0];
            }

            for(int i = 0; i < polymer.Length-1; i++)
            {
                string pair = polymer[i].ToString() + polymer[i + 1].ToString();
                if (!pairs.ContainsKey(pair)) pairs[pair] = 0;
                pairs[pair]++;

                if (!result.ContainsKey(polymer[i])) result[polymer[i]] = 0;
                result[polymer[i]]++;
            }
            if (!result.ContainsKey(polymer[polymer.Length-1])) result[polymer[polymer.Length-1]] = 0;
            result[polymer[polymer.Length-1]]++;
            int step = 0;
            while (step < STEPS)
            {
                var newPairs = new Dictionary<string, ulong>(pairs);
                foreach (var pair in pairs)
                {
                    if (templates.ContainsKey(pair.Key))
                    {

                        newPairs[pair.Key] -= pair.Value;
                        if (!result.ContainsKey(templates[pair.Key]))
                        {
                            result[templates[pair.Key]] = pair.Value;
                        }
                        else result[templates[pair.Key]] += pair.Value;

                        


                        if (!newPairs.ContainsKey(pair.Key[0].ToString() + templates[pair.Key].ToString()))
                        {
                            newPairs[pair.Key[0].ToString() + templates[pair.Key].ToString()] = pair.Value;
                        }
                        else
                        {
                            newPairs[pair.Key[0].ToString() + templates[pair.Key].ToString()] += pair.Value;
                        }


                        if (!newPairs.ContainsKey(templates[pair.Key].ToString() + pair.Key[1].ToString()))
                        {
                            newPairs[templates[pair.Key].ToString() + pair.Key[1].ToString()] = pair.Value;
                        }
                        else
                        {
                            newPairs[templates[pair.Key].ToString() + pair.Key[1].ToString()] += pair.Value;
                        }
                        
                    }
                }
                pairs = newPairs;
            //    ulong sum = 0;
                step++;
          /*      foreach (var item in result.Values)
                {
                    sum += item;
                }
                Console.WriteLine("Step " + step + ": " +sum );  */
            }


           /* foreach (var character in polymer.ToCharArray())
            {
                if (!result.ContainsKey(character)) result[character] = 0;
                result[character]++;
            }*/


            Console.WriteLine(result.Values.Max() - result.Values.Min());
        }

    }
}