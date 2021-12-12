using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_12
{
    class Day12_1
    {
        static int pathsAmount = 0;
        public static void Run()
        {
            string[] lines = System.IO.File.ReadAllLines("input");
            Dictionary<string, List<string>> paths = new Dictionary<string, List<string>>();
            foreach (var line in lines)
            {
                string a, b;
                a = line.Split('-')[0];
                b = line.Split('-')[1];
                AddVertice(a, b, paths);
                AddVertice(b, a, paths);
            }
            List<string> path = new List<string> { "start" };
            FindPaths(new List<string>(), path, paths);
            Console.WriteLine(pathsAmount);
        }

        private static void FindPaths(List<string> visited, List<string> path, Dictionary<string, List<string>> paths)
        {
            string last = path.Last();
            if (last == "end")
            {
                pathsAmount++;
                return;
            }

            if (paths[path.Last()].Where(x => x != "start").ToList().Count == 0)
            {
                return;
            }
            foreach (var item in paths[path.Last()].Where(x=>x!="start").ToList())
            {
                if (visited.Contains(item)) continue;
                List<string> newVisited = new List<string>(visited);
                if(item == item.ToLower())
                {
                    newVisited.Add(item);
                }
                List<string> newPath = new List<string>(path);
                newPath.Add(item);
                FindPaths(newVisited, newPath, paths);
            }
        }

        private static void PrintPath(List<string> path)
        {
            for(int i = 0; i < path.Count; i++)
            {
                Console.Write(path[i] +",");
            }
            Console.WriteLine();
        }

        private static void AddVertice(string a, string b, Dictionary<string, List<string>> paths)
        {
            List<string> vertices;
            if (!paths.TryGetValue(a, out vertices))
            {
                vertices = new List<string>();
            }
            vertices.Add(b);
            paths[a] = vertices;
        }
    }
}
