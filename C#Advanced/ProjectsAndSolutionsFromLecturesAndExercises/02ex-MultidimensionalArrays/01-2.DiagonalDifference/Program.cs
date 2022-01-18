using System;
using System.Linq;

namespace _01_2.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());

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

            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonaal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumPrimaryDiagonal += matrix[row, row];
                sumSecondaryDiagonaal += matrix[row, (matrix.GetLength(1) - 1 - row)];
            }

            int difference = Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonaal);

            Console.WriteLine(difference);
        }
    }
}
