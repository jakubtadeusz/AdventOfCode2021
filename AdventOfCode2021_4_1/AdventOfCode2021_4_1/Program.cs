using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021_4_1
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

            //create bingo boards
            List<BingoBoard> bingoBoards = new List<BingoBoard>();
            while(n < lines.Length)
            {   
                //create new bingo board
                BingoBoard bingoBoard = new BingoBoard();
                for(int i = 1; i <=5; i++)
                {
                    var x = lines[i + n].Split(null).Where(k=>k!="").ToArray();
                    var arr = Array.ConvertAll(x, s => int.Parse(s));
                    bingoBoard.AddRow(arr);
                }
                bingoBoards.Add(bingoBoard);
                //move to the next board in the input file
                n += 6;
            }

            for(int i = 0; i < numbers.Count; i++)
            {
                foreach (var board in bingoBoards)
                {
                    //check next number
                    board.CheckNumber(numbers[i]);
                    //check if the board is finished
                    if (board.IsBoardFinished())
                    {
                        //print result score
                        Console.WriteLine(numbers[i]*board.GetBoardScore());
                        return;
                    }
                }
            }

        }
    }
}
