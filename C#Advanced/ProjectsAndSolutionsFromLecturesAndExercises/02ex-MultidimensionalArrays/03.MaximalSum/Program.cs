using System;
using System.Linq;

namespace _03.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            int[,] matrix = new int[rows, cols];

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

            long maxSum = int.MinValue;
            int rowOfTheFirstElement = -1;
            int colOfTheFirstElement = -1;

            for (int row = 0; row < (matrix.GetLength(0) - 2); row++)
            {
                for (int col = 0; col < (matrix.GetLength(1) - 2); col++)
                {
                    long currentSum = CalculateSum(matrix, row, col);

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowOfTheFirstElement = row;
                        colOfTheFirstElement = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            PrintSubmatrix(matrix, rowOfTheFirstElement, colOfTheFirstElement);
        }

        private static void PrintSubmatrix(int[,] matrix, int rowOfTheFirstElement, int colOfTheFirstElement)
        {
            for (int row = rowOfTheFirstElement; row < (rowOfTheFirstElement + 3); row++)
            {
                for (int col = colOfTheFirstElement; col < (colOfTheFirstElement + 3); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static long CalculateSum(int[,] matrix, int row, int col)
        {
            long sum = 0;

            for (int rows = row; rows < row + 3; rows++)
            {
                for (int currentCol = col; currentCol < col + 3; currentCol++)
                {
                    sum += matrix[rows, currentCol];
                }
            }

            return sum;
        }
    }
}
