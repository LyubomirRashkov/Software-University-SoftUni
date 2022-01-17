using System;
using System.Linq;

namespace _01.SumMatrixElements
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
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }

            int countOfRows = matrix.GetLength(0);
            int countOfCols = matrix.GetLength(1);
            int sumOfElements = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sumOfElements += matrix[row, col];
                }
            }

            Console.WriteLine(countOfRows);
            Console.WriteLine(countOfCols);
            Console.WriteLine(sumOfElements);
        }
    }
}
