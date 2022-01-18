using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    public class Bunny
    {
        public int Row { get; set; }

        public int Col { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region ReadTheInput

            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            char[,] matrix = new char[rows, cols];

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputLine = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];

                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string moves = Console.ReadLine();

            #endregion

            bool IsDead = false;
            bool HasWon = false;

            foreach (char symbol in moves)
            {
                matrix[playerRow, playerCol] = '.';

                #region MoveThePlayer

                if (symbol == 'L')
                {
                    if (IsGoingOutside(matrix, playerRow, playerCol - 1))
                    {
                        HasWon = true;
                    }
                    else
                    {
                        if (matrix[playerRow, playerCol - 1] == 'B')
                        {
                            playerCol--;
                            IsDead = true;
                        }
                        else
                        {
                            matrix[playerRow, playerCol - 1] = 'P';
                            playerCol--;
                        }
                    }
                }
                else if (symbol == 'R')
                {
                    if (IsGoingOutside(matrix, playerRow, playerCol + 1))
                    {
                        HasWon = true;
                    }
                    else
                    {
                        if (matrix[playerRow, playerCol + 1] == 'B')
                        {
                            playerCol++;
                            IsDead = true;
                        }
                        else
                        {
                            matrix[playerRow, playerCol + 1] = 'P';
                            playerCol++;
                        }
                    }
                }
                else if (symbol == 'U')
                {
                    if (IsGoingOutside(matrix, playerRow - 1, playerCol))
                    {
                        HasWon = true;
                    }
                    else
                    {
                        if (matrix[playerRow - 1, playerCol] == 'B')
                        {
                            playerRow--;
                            IsDead = true;
                        }
                        else
                        {
                            matrix[playerRow - 1, playerCol] = 'P';
                            playerRow--;
                        }
                    }
                }
                else if (symbol == 'D')
                {
                    if (IsGoingOutside(matrix, playerRow + 1, playerCol))
                    {
                        HasWon = true;
                    }
                    else
                    {
                        if (matrix[playerRow + 1, playerCol] == 'B')
                        {
                            playerRow++;
                            IsDead = true;
                        }
                        else
                        {
                            matrix[playerRow + 1, playerCol] = 'P';
                            playerRow++;
                        }
                    }
                }

                #endregion

                #region SpreadBunnies

                List<Bunny> bunnies = new List<Bunny>();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            Bunny bunny = new Bunny
                            {
                                Row = row,
                                Col = col
                            };

                            bunnies.Add(bunny);
                        }
                    }
                }

                foreach (Bunny bunny in bunnies)
                {
                    int bunnyRow = bunny.Row;
                    int bunnyCol = bunny.Col;

                    if (!IsGoingOutside(matrix, bunnyRow, bunnyCol - 1))
                    {
                        if (matrix[bunnyRow, bunnyCol - 1] == 'P')
                        {
                            matrix[bunnyRow, bunnyCol - 1] = 'B';
                            IsDead = true;
                        }
                        else
                        {
                            matrix[bunnyRow, bunnyCol - 1] = 'B';
                        }
                    }

                    if (!IsGoingOutside(matrix, bunnyRow, bunnyCol + 1))
                    {
                        if (matrix[bunnyRow, bunnyCol + 1] == 'P')
                        {
                            matrix[bunnyRow, bunnyCol + 1] = 'B';
                            IsDead = true;
                        }
                        else
                        {
                            matrix[bunnyRow, bunnyCol + 1] = 'B';
                        }
                    }

                    if (!IsGoingOutside(matrix, bunnyRow - 1, bunnyCol))
                    {
                        if (matrix[bunnyRow - 1, bunnyCol] == 'P')
                        {
                            matrix[bunnyRow - 1, bunnyCol] = 'B';
                            IsDead = true;
                        }
                        else
                        {
                            matrix[bunnyRow - 1, bunnyCol] = 'B';
                        }
                    }

                    if (!IsGoingOutside(matrix, bunnyRow + 1, bunnyCol))
                    {
                        if (matrix[bunnyRow + 1, bunnyCol] == 'P')
                        {
                            matrix[bunnyRow + 1, bunnyCol] = 'B';
                            IsDead = true;
                        }
                        else
                        {
                            matrix[bunnyRow + 1, bunnyCol] = 'B';
                        }
                    }
                }

                #endregion

                if (HasWon)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    break;
                }

                if (IsDead)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsGoingOutside(char[,] matrix, int row, int col)
        {
            return (row < 0 || row == matrix.GetLength(0)
                || col < 0 || col == matrix.GetLength(1));
        }
    }
}
