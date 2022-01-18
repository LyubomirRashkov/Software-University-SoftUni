using System;
using System.Linq;

namespace _02.SquaresInMatrix
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

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }

            int countOfSubmatrices = 0;

            for (int row = 0; row < (matrix.GetLength(0) - 1); row++)
            {
                for (int col = 0; col < (matrix.GetLength(1) - 1); col++)
                {
                    if (DoesMakeASubmatrix(matrix, row, col))
                    {
                        countOfSubmatrices++;
                    }
                }
            }

            Console.WriteLine(countOfSubmatrices);
        }

        private static bool DoesMakeASubmatrix(char[,] matrix, int row, int col)
        {
            return (matrix[row, col] == matrix[row, col + 1]
                && matrix[row, col] == matrix[row + 1, col]
                && matrix[row, col] == matrix[row + 1, col + 1]);
        }
    }
}
