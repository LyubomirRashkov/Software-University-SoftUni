using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();

            int numberOfRows = dimensions[0];
            int numberOfCols = dimensions[1];

            int[,] matrix = new int[numberOfRows, numberOfCols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            List<int[]> plantedFlowers = new List<int[]>();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "Bloom Bloom Plow")
                {
                    break;
                }

                int[] coordinates = inputLine
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();

                int currentRow = coordinates[0];
                int currentCol = coordinates[1];

                if (!AreCoordinatesValid(matrix, currentRow, currentCol))
                {
                    Console.WriteLine("Invalid coordinates.");

                    continue;
                }

                plantedFlowers.Add(coordinates);

                matrix[currentRow, currentCol] = 1;
            }

            for (int i = 0; i < plantedFlowers.Count; i++)
            {
                int plantRow = plantedFlowers[i][0];
                int plantCol = plantedFlowers[i][1];

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (col == plantCol)
                    {
                        continue;
                    }

                    matrix[plantRow, col]++;
                }

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    if (row == plantRow)
                    {
                        continue;
                    }

                    matrix[row, plantCol]++;
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static bool AreCoordinatesValid(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
