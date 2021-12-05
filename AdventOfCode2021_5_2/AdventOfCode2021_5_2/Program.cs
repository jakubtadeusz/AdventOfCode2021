using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("input");
            ConcurrentDictionary<string, int> vents = new ConcurrentDictionary<string, int>();
            foreach (var vent in lines)
            {
                var line = vent.Split(' ');
                var start = line[0].Split(',');
                var dest = line[2].Split(',');

                int x = int.Parse(start[0]);
                int y = int.Parse(start[1]);

                int x_dest = int.Parse(dest[0]);
                int y_dest = int.Parse(dest[1]);

                if (x == x_dest)
                {
                    if (y <= y_dest)
                    {
                        for (int i = y; i <= y_dest; i++)
                        {
                            string coord = x.ToString() + "," + i.ToString();
                            vents.AddOrUpdate(coord, 1, (key, count) => count + 1);
                        }
                    }
                    else
                    {
                        for (int i = y; i >= y_dest; i--)
                        {
                            string coord = x.ToString() + "," + i.ToString();
                            vents.AddOrUpdate(coord, 1, (key, count) => count + 1);
                        }
                    }
                }


                if (y == y_dest)
                {

                    if (x <= x_dest)
                    {
                        for (int i = x; i <= x_dest; i++)
                        {
                            string coord = i.ToString() + "," + y.ToString();
                            vents.AddOrUpdate(coord, 1, (key, count) => count + 1);
                        }
                    }
                    else
                    {
                        for (int i = x; i >= x_dest; i--)
                        {
                            string coord = i.ToString() + "," + y.ToString();
                            vents.AddOrUpdate(coord, 1, (key, count) => count + 1);
                        }
                    }
                }

                if(x_dest-x == y_dest-y)
                {
                    if (x <= x_dest)
                    {
                        for (int i = 0; i <= x_dest-x; i++)
                        {
                            string coord = (x+i).ToString() + "," + (y+i).ToString();
                            vents.AddOrUpdate(coord, 1, (key, count) => count + 1);
                        }
                    }
                    else {
                        for (int i = x-x_dest; i >= 0; i--)
                        {
                            string coord = (x-i).ToString() + "," + (y-i).ToString();
                            vents.AddOrUpdate(coord, 1, (key, count) => count + 1);
                        }
                    }
                }

                if (x_dest - x == -(y_dest -y))
                {
                    if(x >= x_dest)
                    {
                        for(int i = 0; i <= x-x_dest; i++)
                        {
                            string coord = (x-i).ToString() + "," + (y+i).ToString();
                            vents.AddOrUpdate(coord, 1, (key, count) => count + 1);
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= x_dest-x; i++)
                        {
                            string coord = (x + i).ToString() + "," + (y - i).ToString();
                            vents.AddOrUpdate(coord, 1, (key, count) => count + 1);
                        }
                    }
                }
            }
            int counter = vents.Where(v => v.Value >= 2).ToArray().Length;
            Console.WriteLine(counter);
        }

    }
}
