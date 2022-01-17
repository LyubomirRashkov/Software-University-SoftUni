using System;
using System.Linq;

namespace _06.Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfJagged = int.Parse(Console.ReadLine());

            long[][] jagged = new long[sizeOfJagged][];

            for (int i = 0; i < jagged.Length; i++)
            {
                int[] inputLine = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jagged[i] = new long[inputLine.Length];

                for (int j = 0; j < jagged[i].Length; j++)
                {
                    jagged[i][j] = inputLine[j];
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
                int rowIndex = int.Parse(commandParts[1]);
                int colIndex = int.Parse(commandParts[2]);
                int value = int.Parse(commandParts[3]);

                if (!AreValid(jagged, rowIndex, colIndex))
                {
                    Console.WriteLine("Invalid coordinates");
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

        private static bool AreValid(long[][] jagged, int rowIndex, int colIndex)
        {
            return (rowIndex >= 0 && rowIndex < jagged.Length && colIndex >= 0 && colIndex < jagged[rowIndex].Length);
        }
    }
}
