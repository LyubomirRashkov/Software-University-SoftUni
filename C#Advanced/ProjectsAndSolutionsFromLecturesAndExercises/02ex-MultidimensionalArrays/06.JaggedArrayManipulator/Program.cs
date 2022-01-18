using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            double[][] jagged = new double[numberOfRows][];

            for (int i = 0; i < jagged.Length; i++)
            {
                double[] inputLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();

                jagged[i] = inputLine;
            }

            for (int row = 0; row < jagged.Length - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                        jagged[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /= 2;
                    }

                    for (int col = 0; col < jagged[row + 1].Length; col++)
                    {
                        jagged[row + 1][col] /= 2;
                    }
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] commandParts = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandParts[0];
                int rowIndex = int.Parse(commandParts[1]);
                int colIndex = int.Parse(commandParts[2]);
                int value = int.Parse(commandParts[3]);

                if (!AreValid(jagged, rowIndex, colIndex))
                {
                    continue;
                }

                if (command == "Add")
                {
                    jagged[rowIndex][colIndex] += value;
                }
                else if (command == "Subtract")
                {
                    jagged[rowIndex][colIndex] -= value;
                }
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine(string.Join(' ', jagged[i]));
            }
        }

        private static bool AreValid(double[][] jagged, int rowIndex, int colIndex)
        {
            return (rowIndex >= 0 && rowIndex < jagged.Length
                && colIndex >= 0 && colIndex < jagged[rowIndex].Length);
        }
    }
}
