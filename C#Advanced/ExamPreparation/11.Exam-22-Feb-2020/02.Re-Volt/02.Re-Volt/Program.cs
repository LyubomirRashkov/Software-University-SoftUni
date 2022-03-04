using System;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());

            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool hasPlayerWon = false;

            for (int i = 0; i < countOfCommands; i++)
            {
                string direction = Console.ReadLine();

                int[] playerCoordinates = GetNewCoordinates(matrix, direction, playerRow, playerCol);

                int newPlayerRow = playerCoordinates[0];
                int newPlayerCol = playerCoordinates[1];

                if (matrix[newPlayerRow, newPlayerCol] == 'T')
                {
                    continue;
                }
                else if (matrix[newPlayerRow, newPlayerCol] == 'B')
                {
                    playerCoordinates = GetNewCoordinates(matrix, direction, newPlayerRow, newPlayerCol);

                    newPlayerRow = playerCoordinates[0];
                    newPlayerCol = playerCoordinates[1];

                    if (matrix[newPlayerRow, newPlayerCol] == 'F')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[newPlayerRow, newPlayerCol] = 'f';

                        hasPlayerWon = true;

                        break;
                    }

                    matrix[playerRow, playerCol] = '-';
                    matrix[newPlayerRow, newPlayerCol] = 'f';

                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }
                else if (matrix[newPlayerRow, newPlayerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = '-';
                    matrix[newPlayerRow, newPlayerCol] = 'f';

                    hasPlayerWon = true;

                    break;
                }
                else if (matrix[newPlayerRow, newPlayerCol] == '-')
                {
                    matrix[playerRow, playerCol] = '-';
                    matrix[newPlayerRow, newPlayerCol] = 'f';

                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }
            }

            if (hasPlayerWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static int[] GetNewCoordinates(char[,] matrix, string direction, int playerRow, int playerCol)
        {
            int[] coordinates = new int[2];

            if (direction == "up")
            {
                if ((playerRow - 1) >= 0)
                {
                    playerRow--;
                }
                else
                {
                    playerRow = matrix.GetLength(0) - 1;
                }
            }
            else if (direction == "down")
            {
                if ((playerRow + 1) < matrix.GetLength(0))
                {
                    playerRow++;
                }
                else
                {
                    playerRow = 0;
                }
            }
            else if (direction == "left")
            {
                if ((playerCol - 1) >= 0)
                {
                    playerCol--;
                }
                else
                {
                    playerCol = matrix.GetLength(1) - 1;
                }
            }
            else if (direction == "right")
            {
                if ((playerCol + 1) < matrix.GetLength(1))
                {
                    playerCol++;
                }
                else
                {
                    playerCol = 0;
                }
            }

            coordinates[0] = playerRow;
            coordinates[1] = playerCol;

            return coordinates;
        }
    }
}
