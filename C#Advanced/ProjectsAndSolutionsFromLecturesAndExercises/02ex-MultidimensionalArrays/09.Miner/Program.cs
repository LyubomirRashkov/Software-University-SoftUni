using System;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());

            string[] moves = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            int countOfAllCoals = 0;
            int minerRow = -1;
            int minerCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];

                    if (matrix[row, col] == 'c')
                    {
                        countOfAllCoals++;
                    }

                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                }
            }

            int collectedCoals = 0;

            bool AreAllCoalsCollected = false;
            bool DoesGameOver = false;

            foreach (string move in moves)
            {
                if (move == "left")
                {
                    if (IsGoingOutside(matrix, minerRow, minerCol - 1))
                    {
                        continue;
                    }

                    minerCol--;

                    if (matrix[minerRow, minerCol] == 'c')
                    {
                        collectedCoals++;
                        matrix[minerRow, minerCol] = '*';

                        if (collectedCoals == countOfAllCoals)
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            AreAllCoalsCollected = true;
                            break;
                        }
                    }
                    else if (matrix[minerRow, minerCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        DoesGameOver = true;
                        break;
                    }
                }
                else if (move == "right")
                {
                    if (IsGoingOutside(matrix, minerRow, minerCol + 1))
                    {
                        continue;
                    }

                    minerCol++;

                    if (matrix[minerRow, minerCol] == 'c')
                    {
                        collectedCoals++;
                        matrix[minerRow, minerCol] = '*';

                        if (collectedCoals == countOfAllCoals)
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            AreAllCoalsCollected = true;
                            break;
                        }
                    }
                    else if (matrix[minerRow, minerCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        DoesGameOver = true;
                        break;
                    }
                }
                else if (move == "up")
                {
                    if (IsGoingOutside(matrix, minerRow - 1, minerCol))
                    {
                        continue;
                    }

                    minerRow--;

                    if (matrix[minerRow, minerCol] == 'c')
                    {
                        collectedCoals++;
                        matrix[minerRow, minerCol] = '*';

                        if (collectedCoals == countOfAllCoals)
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            AreAllCoalsCollected = true;
                            break;
                        }
                    }
                    else if (matrix[minerRow, minerCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        DoesGameOver = true;
                        break;
                    }
                }
                else if (move == "down")
                {
                    if (IsGoingOutside(matrix, minerRow + 1, minerCol))
                    {
                        continue;
                    }

                    minerRow++;

                    if (matrix[minerRow, minerCol] == 'c')
                    {
                        collectedCoals++;
                        matrix[minerRow, minerCol] = '*';

                        if (collectedCoals == countOfAllCoals)
                        {
                            Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                            AreAllCoalsCollected = true;
                            break;
                        }
                    }
                    else if (matrix[minerRow, minerCol] == 'e')
                    {
                        Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                        DoesGameOver = true;
                        break;
                    }
                }
            }

            if (!AreAllCoalsCollected && !DoesGameOver)
            {
                Console.WriteLine($"{countOfAllCoals - collectedCoals} coals left. ({minerRow}, {minerCol})");
            }
        }

        private static bool IsGoingOutside(char[,] matrix, int row, int col)
        {
            return (row < 0 || row == matrix.GetLength(0)
                || col < 0 || col == matrix.GetLength(1));
        }
    }
}
