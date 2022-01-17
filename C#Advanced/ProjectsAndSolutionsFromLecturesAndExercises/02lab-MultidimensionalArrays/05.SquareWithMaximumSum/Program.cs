using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeOfTheMatrix = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizeOfTheMatrix[0];
            int cols = sizeOfTheMatrix[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputLine = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }

            long maxSum = int.MinValue;
            int rowOfTheFirstElementOfTheMaxSum = -1;
            int colOfTheFirstElementOfTheMaxSum = -1;

            for (int row = 0; row < (matrix.GetLength(0) - 1); row++)
            {
                for (int col = 0; col < (matrix.GetLength(1) - 1); col++)
                {
                    long currentSum = CalculateSum2x2(matrix, row, col);

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowOfTheFirstElementOfTheMaxSum = row;
                        colOfTheFirstElementOfTheMaxSum = col;
                    }
                }
            }

            for (int row = rowOfTheFirstElementOfTheMaxSum; row < rowOfTheFirstElementOfTheMaxSum + 2; row++)
            {
                for (int col = colOfTheFirstElementOfTheMaxSum; col < colOfTheFirstElementOfTheMaxSum + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }

        private static long CalculateSum2x2(int[,] matrix, int row, int col)
        {
            return (matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1]);
        }
    }
}
