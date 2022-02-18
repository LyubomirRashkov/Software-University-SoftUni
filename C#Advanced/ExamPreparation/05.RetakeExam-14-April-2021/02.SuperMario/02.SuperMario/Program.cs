using System;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerLives = int.Parse(Console.ReadLine());

            int numberOfRows = int.Parse(Console.ReadLine());

            string inputLine = Console.ReadLine();

            char[,] matrix = new char[numberOfRows, inputLine.Length];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row > 0)
                {
                    inputLine = Console.ReadLine();
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];

                    if (matrix[row, col] == 'M')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            bool isDead = false;

            int newPlayerRow = 0;
            int newPlayerCol = 0;

            while (true)
            {
                string[] commandParts = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string direction = commandParts[0];
                int rowSpawn = int.Parse(commandParts[1]);
                int colSpawn = int.Parse(commandParts[2]);

                matrix[rowSpawn, colSpawn] = 'B';

                int[] newMovements = GetNewMovements(direction);

                newPlayerRow = playerRow + newMovements[0];
                newPlayerCol = playerCol + newMovements[1];

                playerLives--;

                if (IsGoingOutside(matrix, newPlayerRow, newPlayerCol))
                {
                    newPlayerRow = playerRow;
                    newPlayerCol = playerCol;

                    if (playerLives == 0)
                    {
                        matrix[playerRow, playerCol] = 'X';

                        isDead = true;

                        break;
                    }
                }
                else
                {
                    if (matrix[newPlayerRow, newPlayerCol] == 'P')
                    {
                        matrix[playerRow, playerCol] = '-';
                        matrix[newPlayerRow, newPlayerCol] = '-';

                        break;
                    }
                    else
                    {
                        if (playerLives == 0)
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[newPlayerRow, newPlayerCol] = 'X';

                            isDead = true;

                            break;
                        }

                        if (matrix[newPlayerRow, newPlayerCol] == 'B')
                        {
                            playerLives -= 2;

                            if (playerLives <= 0)
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[newPlayerRow, newPlayerCol] = 'X';

                                isDead = true;

                                break;
                            }
                            else
                            {
                                matrix[playerRow, playerCol] = '-';
                                matrix[newPlayerRow, newPlayerCol] = 'M';
                            }
                        }
                        else
                        {
                            matrix[playerRow, playerCol] = '-';
                            matrix[newPlayerRow, newPlayerCol] = 'M';
                        }
                    }

                    playerRow = newPlayerRow;
                    playerCol = newPlayerCol;
                }
            }

            if (isDead)
            {
                Console.WriteLine($"Mario died at {newPlayerRow};{newPlayerCol}.");
            }
            else
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {playerLives}");
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

        private static bool IsGoingOutside(char[,] matrix, int row, int col)
        {
            return row < 0 || row == matrix.GetLength(0) || col < 0 || col == matrix.GetLength(1);

        }

        private static int[] GetNewMovements(string direction)
        {
            int newPlayerRow = 0;
            int newPlayerCol = 0;

            if (direction == "W")
            {
                newPlayerRow--;
            }
            else if (direction == "S")
            {
                newPlayerRow++;
            }
            else if (direction == "A")
            {
                newPlayerCol--;
            }
            else if (direction == "D")
            {
                newPlayerCol++;
            }

            return new int[] { newPlayerRow, newPlayerCol };
        }
    }
}
