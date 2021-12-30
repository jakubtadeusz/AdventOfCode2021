using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021_4_1
{
    class BingoBoard
    {
        int[][] numbers = new int[5][];
        bool[][] isNumberChecked = new bool[5][];
        int [] rowChecked = new int[5];
        int[] columnChecked = new int[5];

        /// <summary>
        /// Add new row of numbers to bingo board
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(int [] row)
        {
            for (int i = 0; i < 5; i++)
            {
                if (numbers[i] == null)
                {
                    numbers[i] = row;
                    isNumberChecked[i] = new bool[5];
                    for (int j = 0; j < 5; j++)
                    {
                        isNumberChecked[i][j] = false;
                    }
                    break;
                }
            }
        }

        public void CheckNumber(int number)
        {
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if(numbers[i][j] == number)
                    {
                        isNumberChecked[i][j] = true;
                        rowChecked[i]++;
                        columnChecked[j]++;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if the board is finished
        /// </summary>
        /// <returns></returns>
        public bool IsBoardFinished()
        {
            for(int i = 0; i<5; i++)
            {
                if(rowChecked[i] == 5 || columnChecked[i]==5)
                {
                    return true;
                }
            }
            return false;
        }       

        /// <summary>
        /// Calculates board score
        /// </summary>
        /// <returns></returns>
        public int GetBoardScore()
        {
            int sum = 0;
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if(isNumberChecked[i][j] == false)
                    {
                        sum += numbers[i][j];
                    }
                }
            }
            return sum;
        }

    }
}
