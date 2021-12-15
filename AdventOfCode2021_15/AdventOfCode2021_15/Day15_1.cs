using System;
using System.Collections.Generic;

namespace AdventOfCode2021_15
{
    internal class Day15_1
    {
        internal static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines("input");
            int[][] map = new int[lines.Length][];
            int[][] d = new int[map.Length][];
            //    int[][] prev = new int[map.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                map[i] = new int[lines[i].Length];
                d[i] = new int[map.Length ];
                //   prev[i] = new int[lines[i].Length];
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i][j] = int.Parse(lines[i][j].ToString());
                }
            }


            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map.Length; j++)
                {
                    d[i][j] = int.MaxValue;
                    //         prev[i][j] = -1;
                }
            }
            d[0][0] = 0;


            List<(int, int)> Q = new List<(int, int)>();
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map.Length; j++)
                {
                    Q.Add((i, j));
                }
            }

            while (Q.Count > 0)
            {

                (int, int) u = FindMin(Q, d);

                List<(int, int)> neighbors = GetNeighbors(u.Item1, u.Item2, map.Length);
                foreach (var neighbor in neighbors)
                {
                    (int, int) mapCoords = (neighbor.Item1 % map.Length, neighbor.Item2 % map.Length);
                    int w = (map[mapCoords.Item1][mapCoords.Item2] + neighbor.Item1 / map.Length + neighbor.Item2 / map.Length);
                    if (w > 9) w -= 9;
                    if (d[neighbor.Item1][neighbor.Item2] > d[u.Item1][u.Item2] + w)
                    {

                        d[neighbor.Item1][neighbor.Item2] = d[u.Item1][u.Item2] + w;
                    }
                }
            }
            Console.WriteLine(d[d.Length - 1][d.Length - 1]);
        }

        private static (int, int) FindMin(List<(int, int)> Q, int[][] d)
        {
            int min = int.MaxValue;
            (int, int) u = (-1, -1);
            foreach (var item in Q)
            {
                if (d[item.Item1][item.Item2] < min)
                {
                    u = item;
                    min = d[item.Item1][item.Item2];
                }
            }
            Q.Remove(u);
            return u;
        }

        private static List<(int, int)> GetNeighbors(int i, int j, int length)
        {
            List<(int, int)> neighbors = new List<(int, int)>();
            if (i > 0) neighbors.Add((i - 1, j));
            if (i < length - 1) neighbors.Add((i + 1, j));
            if (j > 0) neighbors.Add((i, j - 1));
            if (j < length - 1) neighbors.Add((i, j + 1));
            return neighbors;
        }
    }
}