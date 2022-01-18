using System;
using System.Linq;

namespace _01.DiagonalDifference
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
            int sumSecondaryDiagonal = 0;

            int counter = matrix.GetLength(1) - 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        sumPrimaryDiagonal += matrix[row, col];
                    }
                }

                sumSecondaryDiagonal += matrix[row, counter];
                counter--;
            }

            int difference = Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal);

            Console.WriteLine(difference);
        }
    }
}
