using System;
using System.Linq;

namespace _02_2.SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizesOfMatrix = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizesOfMatrix[0];
            int cols = sizesOfMatrix[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] inputLine = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }

            int[] colSum = new int[matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    colSum[col] += matrix[row, col];
                }
            }

            foreach (int element in colSum)
            {
                Console.WriteLine(element);
            }
        }
    }
}
