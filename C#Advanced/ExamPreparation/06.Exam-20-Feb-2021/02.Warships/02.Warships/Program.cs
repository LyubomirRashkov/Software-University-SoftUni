using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Warships
{
    public class Program
    {
        public static void Main()
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());

            string[] attackCommands = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            int shipsOfFirstPlayer = 0;
            int shipsOfSecondPlayer = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine()
                                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                     .Select(char.Parse)
                                     .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == '<')
                    {
                        shipsOfFirstPlayer++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        shipsOfSecondPlayer++;
                    }
                }
            }

            int countOfSunkenShips = 0;

            for (int i = 0; i < attackCommands.Length; i++)
            {
                int[] attackCoordinates = attackCommands[i]
                                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

                int attackRow = attackCoordinates[0];
                int attackCol = attackCoordinates[1];

                if (!AreCoordinatesValid(matrix, attackRow, attackCol))
                {
                    continue;
                }

                if (matrix[attackRow, attackCol] == '<')
                {
                    matrix[attackRow, attackCol] = 'X';
                    shipsOfFirstPlayer--;
                    countOfSunkenShips++;

                    if (shipsOfFirstPlayer == 0)
                    {
                        break;
                    }
                }
                else if (matrix[attackRow, attackCol] == '>')
                {
                    matrix[attackRow, attackCol] = 'X';
                    shipsOfSecondPlayer--;
                    countOfSunkenShips++;

                    if (shipsOfSecondPlayer == 0)
                    {
                        break;
                    }
                }
                else if (matrix[attackRow, attackCol] == '#')
                {
                    matrix[attackRow, attackCol] = 'X';

                    List<int[]> validCells = GetValidCells(matrix, attackRow, attackCol);

                    foreach (int[] cell in validCells)
                    {
                        int row = cell[0];
                        int col = cell[1];

                        if (matrix[row, col] == '<')
                        {
                            shipsOfFirstPlayer--;
                            countOfSunkenShips++;
                        }
                        else if (matrix[row, col] == '>')
                        {
                            shipsOfSecondPlayer--;
                            countOfSunkenShips++;
                        }
                    }

                    if (shipsOfFirstPlayer <= 0 || shipsOfSecondPlayer <= 0)
                    {
                        break;
                    }
                }
            }

            if (shipsOfSecondPlayer <= 0)
            {
                Console.WriteLine($"Player One has won the game! {countOfSunkenShips} ships have been sunk in the battle.");
            }
            else if (shipsOfFirstPlayer <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {countOfSunkenShips} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {shipsOfFirstPlayer} ships left. Player Two has {shipsOfSecondPlayer} ships left.");
            }
        }

        private static List<int[]> GetValidCells(char[,] matrix, int row, int col)
        {
            List<int[]> validCells = new List<int[]>();

            if ((row - 1) >= 0 && (col - 1) >= 0)
            {
                validCells.Add(new int[] { row - 1, col - 1 });
            }
            if ((row - 1) >= 0)
            {
                validCells.Add(new int[] { row - 1, col});
            }
            if ((row - 1) >= 0 && (col + 1) < matrix.GetLength(1))
            {
                validCells.Add(new int[] { row - 1, col + 1 });
            }

            if ((col - 1) >= 0)
            {
                validCells.Add(new int[] { row, col - 1 });
            }
            if ((col + 1) < matrix.GetLength(1))
            {
                validCells.Add(new int[] { row, col + 1 });
            }

            if ((row + 1) < matrix.GetLength(0) && (col - 1) >= 0)
            {
                validCells.Add(new int[] { row + 1, col - 1 });
            }
            if ((row + 1) < matrix.GetLength(0))
            {
                validCells.Add(new int[] { row + 1, col });
            }
            if ((row + 1) < matrix.GetLength(0) && (col + 1) < matrix.GetLength(1))
            {
                validCells.Add(new int[] { row + 1, col + 1 });
            }

            return validCells;
        }

        private static bool AreCoordinatesValid(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
