using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("input");
            List<int> numbers = new List<int>();
            foreach (var item in lines[0].Split(','))
            {
                numbers.Add(int.Parse(item));
            }
            int n = 1;
            List<BingoBoard> bingoBoards = new List<BingoBoard>();
            while (n < lines.Length)
            {
                BingoBoard bingoBoard = new BingoBoard();
                for (int i = 1; i <= 5; i++)
                {
                    var x = lines[i + n].Split(null).Where(k => k != "").ToArray();
                    var arr = Array.ConvertAll(x, s => int.Parse(s));
                    bingoBoard.AddRow(arr);
                }
                bingoBoards.Add(bingoBoard);
                n += 6;
            }

            int notChecked = bingoBoards.Count;

            //check all the numbers
            for (int i = 0; i < numbers.Count; i++)
            {
                for(int j = bingoBoards.Count-1; j >=0; j--)
                {
                    BingoBoard board = bingoBoards[j];
                    board.CheckNumber(numbers[i]);
                    if (bingoBoards[j].IsBoardFinished())
                    {
                        bingoBoards.Remove(board);
                        //if there is only one board left, finish
                        if (bingoBoards.Count == 0)
                        {
                            Console.WriteLine(numbers[i] * board.GetBoardScore());
                            return;
                        }
                        
                    }
                }
            }


        }
    }
}
