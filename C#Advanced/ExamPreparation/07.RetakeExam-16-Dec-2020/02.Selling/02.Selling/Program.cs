using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputLine = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];

                    if (matrix[row, col] == 'S')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            int money = 0;

            const int targetMoney = 50;

            while (true)
            {
                string direction = Console.ReadLine();

                int[] playerMovements = GetPlayerMovements(direction, playerRow, playerCol);

                int newPlayerRow = playerMovements[0];
                int newPlayerCol = playerMovements[1];

                if (IsGoingOutside(matrix, newPlayerRow, newPlayerCol))
                {
                    matrix[playerRow, playerCol] = '-';

                    break;
                }

                matrix[playerRow, playerCol] = '-';

                if (matrix[newPlayerRow, newPlayerCol] == 'O')
                {
                    matrix[newPlayerRow, newPlayerCol] = '-';

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'O')
                            {
                                newPlayerRow = row;
                                newPlayerCol = col;
                            }
                        }
                    }
                }
                else if (char.IsDigit(matrix[newPlayerRow, newPlayerCol]))
                {
                    int currentProfit = matrix[newPlayerRow, newPlayerCol] - '0';

                    money += currentProfit;

                    if (money >= targetMoney)
                    {
                        matrix[newPlayerRow, newPlayerCol] = 'S';

                        break;
                    }
                }

                matrix[newPlayerRow, newPlayerCol] = 'S';
  
                playerRow = newPlayerRow;
                playerCol = newPlayerCol;
            }

            if (money >= targetMoney)
            {
                Console.WriteLine("Good news! You succeeded in collecting enough money!");
            }
            else
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }

            Console.WriteLine($"Money: {money}");

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

        private static int[] GetPlayerMovements(string direction, int row, int col)
        {
            if (direction == "up")
            {
                row--;
            }
            else if (direction == "down")
            {
                row++;
            }
            else if (direction == "left")
            {
                col--;
            }
            else if (direction == "right")
            {
                col++;
            }

            return new int[] { row, col };
        }
    }
}
