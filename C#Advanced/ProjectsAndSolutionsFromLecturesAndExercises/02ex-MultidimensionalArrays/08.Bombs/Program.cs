using System;
using System.Linq;

namespace _08.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());

            if (sizeOfTheSquareMatrix == 0)
            {
                Console.WriteLine("Alive cells: 0");
                Console.WriteLine("Sum: 0");
                return;
            }

            int[,] matrix = new int[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }

            string[] bombsCoordinates = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int currentBomb = 0; currentBomb < bombsCoordinates.Length; currentBomb++)
            {
                int[] coordinates = bombsCoordinates[currentBomb]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentBombRow = coordinates[0];
                int currentBombCol = coordinates[1];

                if (IsPositive(matrix[currentBombRow, currentBombCol]))
                {
                    int bombPower = matrix[currentBombRow, currentBombCol];


                    if (AreCoordinatesValid(matrix, currentBombRow - 1, currentBombCol - 1) && IsPositive(matrix[currentBombRow - 1, currentBombCol - 1]))
                    {
                        matrix[currentBombRow - 1, currentBombCol - 1] -= bombPower;
                    }

                    if (AreCoordinatesValid(matrix, currentBombRow - 1, currentBombCol) && IsPositive(matrix[currentBombRow - 1, currentBombCol]))
                    {
                        matrix[currentBombRow - 1, currentBombCol] -= bombPower;
                    }

                    if (AreCoordinatesValid(matrix, currentBombRow - 1, currentBombCol + 1) && IsPositive(matrix[currentBombRow - 1, currentBombCol + 1]))
                    {
                        matrix[currentBombRow - 1, currentBombCol + 1] -= bombPower;
                    }

                    if (AreCoordinatesValid(matrix, currentBombRow, currentBombCol - 1) && IsPositive(matrix[currentBombRow, currentBombCol - 1]))
                    {
                        matrix[currentBombRow, currentBombCol - 1] -= bombPower;
                    }

                    if (AreCoordinatesValid(matrix, currentBombRow, currentBombCol + 1) && IsPositive(matrix[currentBombRow, currentBombCol + 1]))
                    {
                        matrix[currentBombRow, currentBombCol + 1] -= bombPower;
                    }

                    if (AreCoordinatesValid(matrix, currentBombRow + 1, currentBombCol - 1) && IsPositive(matrix[currentBombRow + 1, currentBombCol - 1]))
                    {
                        matrix[currentBombRow + 1, currentBombCol - 1] -= bombPower;
                    }

                    if (AreCoordinatesValid(matrix, currentBombRow + 1, currentBombCol) && IsPositive(matrix[currentBombRow + 1, currentBombCol]))
                    {
                        matrix[currentBombRow + 1, currentBombCol] -= bombPower;
                    }

                    if (AreCoordinatesValid(matrix, currentBombRow + 1, currentBombCol + 1) && IsPositive(matrix[currentBombRow + 1, currentBombCol + 1]))
                    {
                        matrix[currentBombRow + 1, currentBombCol + 1] -= bombPower;
                    }

                    matrix[currentBombRow, currentBombCol] -= bombPower;

                }
            }

            int countOfPositiveValues = 0;
            long sumOfPositiveValues = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        countOfPositiveValues++;
                        sumOfPositiveValues += matrix[row, col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {countOfPositiveValues}");
            Console.WriteLine($"Sum: {sumOfPositiveValues}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsPositive(int value)
        {
            if (value > 0)
            {
                return true;
            }

            return false;
        }

        private static bool AreCoordinatesValid(int[,] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1));
        }
    }
}
