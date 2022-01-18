using System;
using System.Linq;

namespace _04.MatrixShuffling
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

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] inputLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] commandParts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandParts[0];

                if (commandParts.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else if (command != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                else if (!AreCoordinatesValid(matrix, commandParts))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(commandParts[1]);
                int col1 = int.Parse(commandParts[2]);
                int row2 = int.Parse(commandParts[3]);
                int col2 = int.Parse(commandParts[4]);

                string temp = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = temp;

                PrintMatrix(matrix);
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool AreCoordinatesValid(string[,] matrix, string[] commandParts)
        {
            int row1 = int.Parse(commandParts[1]);
            int col1 = int.Parse(commandParts[2]);
            int row2 = int.Parse(commandParts[3]);
            int col2 = int.Parse(commandParts[4]);

            return (row1 >= 0 && row1 < matrix.GetLength(0)
                && col1 >= 0 && col1 < matrix.GetLength(1)
                && row2 >= 0 && row2 < matrix.GetLength(0)
                && col2 >= 0 && col2 < matrix.GetLength(1));
        }
    }
}
