using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_12
{
    class Day12_2
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
            FindPaths(new Dictionary<string, int>(), path, paths, false);
            Console.WriteLine(pathsAmount);
        }

        private static void FindPaths(Dictionary<string, int> visited, List<string> path, Dictionary<string, List<string>> paths, bool twoVisited)
        {
            string last = path.Last();
            if (last == "end")
            {
               // PrintPath(path);
                pathsAmount++;
                return;
            }

            if (paths[path.Last()].Where(x => x != "start").ToList().Count == 0)
            {
                return;
            }
            foreach (var item in paths[path.Last()].Where(x => x != "start").ToList())
            {
                if (visited.ContainsKey(item))
                {
                    if (twoVisited || visited[item] == 2) continue;
                }
                Dictionary<string, int> newVisited = new Dictionary<string, int>(visited);
                List<string> newPath;
                if (item == item.ToLower())
                {
                    if (visited.ContainsKey(item))
                    {
                        if (!twoVisited && visited[item] == 1)
                        {
                            newVisited[item] = 2;
                            newPath = new List<string>(path);
                            newPath.Add(item);
                            FindPaths(newVisited, newPath, paths, true);
                            continue;
                        }
                        continue;
                    }
                    else
                    {
                        newVisited[item] = 1;
                        newPath = new List<string>(path);
                        newPath.Add(item);
                        FindPaths(newVisited, newPath, paths, twoVisited);
                        continue;
                    }
  
                }
                newPath = new List<string>(path);
                newPath.Add(item);
                FindPaths(newVisited, newPath, paths, twoVisited);
            }
        }

        private static void PrintPath(List<string> path)
        {
            for (int i = 0; i < path.Count; i++)
            {
                Console.Write(path[i] + ",");
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
