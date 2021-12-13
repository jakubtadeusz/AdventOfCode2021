using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_13
{
    class Day13_1
    {
        int xMax, yMax;
        public static void Run()
        {


            string[] lines = System.IO.File.ReadAllLines("input");
            HashSet<(int, int)> paper = new HashSet<(int, int)>();
            int i = 0;  
            while(lines[i].Length != 0)
            {
                int x = int.Parse(lines[i].Split(',')[0]);
                int y = int.Parse(lines[i].Split(',')[1]);
                paper.Add((x, y));
                i++;
            }
            i++;

            (int, int) fold = GetFold(lines[i]);
            paper = FoldPaper(paper, fold);
            Console.WriteLine(paper.Count);

            
        }

        private static HashSet<(int, int)> FoldPaper(HashSet<(int, int)> paper, (int, int) fold)
        {
            HashSet<(int, int)> newPaper = new HashSet<(int, int)>();
            if (fold.Item1 == 0)
            {
                foreach (var item in paper)
                {
                    int itemX = item.Item1;
                    int itemY = item.Item2;
                    if(itemY < fold.Item2)
                    {
                        newPaper.Add(item);
                    }
                    else
                    {
                        newPaper.Add((itemX, fold.Item2-(itemY-fold.Item2)));
                    }
                }

            }
            else
            {
                foreach (var item in paper)
                {
                    int itemX = item.Item1;
                    int itemY = item.Item2;
                    if (itemX < fold.Item1)
                    {
                        newPaper.Add(item);
                    }
                    else
                    {
                        newPaper.Add((fold.Item1 - (itemX - fold.Item1), itemY));
                    }
                }
            }
            return newPaper;
        }

        private static (int, int) GetFold(string v)
        {
            v = v.Replace("fold along ", "");
            if(v[0] == 'y')
            {
                return (0, int.Parse(v.Split('=')[1]));
            }
            else
            {
                return (int.Parse(v.Split('=')[1]), 0);
            }

        }
    }
}
