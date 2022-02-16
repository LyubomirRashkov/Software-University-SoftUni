using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfBeachRows = int.Parse(Console.ReadLine());

            char[][] beach = new char[numberOfBeachRows][];

            for (int row = 0; row < beach.Length; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                beach[row] = currentRow;
            }

            int playerTokens = 0;
            int opponentTokens = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Gong")
                {
                    break;
                }

                string[] commandInfo = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string player = commandInfo[0];
                int row = int.Parse(commandInfo[1]);
                int col = int.Parse(commandInfo[2]);

                if (player == "Find")
                {
                    if (IsNotValidPlace(beach, row, col))
                    {
                        continue;
                    }

                    if (beach[row][col] == 'T')
                    {
                        playerTokens++;
                        beach[row][col] = '-';
                    }
                }
                else if (player == "Opponent")
                {
                    string direction = commandInfo[3];

                    if (IsNotValidPlace(beach, row, col))
                    {
                        continue;
                    }

                    if (beach[row][col] == 'T')
                    {
                        opponentTokens++;
                        beach[row][col] = '-';
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        if (direction == "up" && row - 1 >= 0)
                        {
                            row--;
                        }
                        else if (direction == "down" && row + 1 < beach.Length)
                        {
                            row++;
                        }
                        else if (direction == "left" && col - 1 >= 0)
                        {
                            col--;
                        }
                        else if (direction == "right" && col + 1 < beach[row].Length)
                        {
                            col++;
                        }

                        if (beach[row][col] == 'T')
                        {
                            opponentTokens++;
                            beach[row][col] = '-';
                        }
                    }
                }
            }

            for (int row = 0; row < beach.Length; row++)
            {
                Console.WriteLine(string.Join(' ', beach[row]));
            }

            Console.WriteLine($"Collected tokens: {playerTokens}");

            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        private static bool IsNotValidPlace(char[][] beach, int row, int col)
        {
            return row < 0 || row >= beach.Length || col < 0 || col >= beach[row].Length;
        }
    }
}
