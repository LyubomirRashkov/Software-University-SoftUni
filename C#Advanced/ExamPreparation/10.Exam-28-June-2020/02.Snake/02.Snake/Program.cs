using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            int snakeRow = 0;
            int snakeCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputLine = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            int foodEaten = 0;

            const int foodRequired = 10;

            bool hasEatEnoughFood = false;

            while (true)
            {
                string direction = Console.ReadLine();

                int[] newCoordinates = GetNewCoordinates(direction, snakeRow, snakeCol);

                int newSnakeRow = newCoordinates[0];
                int newSnakeCol = newCoordinates[1];

                if (IsGoingOutside(matrix, newSnakeRow, newSnakeCol))
                {
                    matrix[snakeRow, snakeCol] = '.';

                    Console.WriteLine("Game over!");

                    break;
                }

                if (matrix[newSnakeRow, newSnakeCol] == '*')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    matrix[newSnakeRow, newSnakeCol] = 'S';

                    foodEaten++;

                    if (foodEaten == foodRequired)
                    {
                        hasEatEnoughFood = true;

                        break;
                    }
                }
                else if (matrix[newSnakeRow, newSnakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    matrix[newSnakeRow, newSnakeCol] = '.';

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'B')
                            {
                                newSnakeRow = row;
                                newSnakeCol = col;
                            }
                        }
                    }

                    matrix[newSnakeRow, newSnakeCol] = 'S';
                }
                else
                {
                    matrix[snakeRow, snakeCol] = '.';
                    matrix[newSnakeRow, newSnakeCol] = 'S';
                }

                snakeRow = newSnakeRow;
                snakeCol = newSnakeCol;

            }

            if (hasEatEnoughFood)
            {
                Console.WriteLine("You won! You fed the snake.");
            }

            Console.WriteLine($"Food eaten: {foodEaten}");

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

        private static int[] GetNewCoordinates(string direction, int currentRow, int currentCol)
        {
            if (direction == "up")
            {
                currentRow--;
            }
            else if (direction == "down")
            {
                currentRow++;
            }
            else if (direction == "left")
            {
                currentCol--;
            }
            else if (direction == "right")
            {
                currentCol++;
            }

            return new int[] { currentRow, currentCol };
        }
    }
}
