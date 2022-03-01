using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            int beeRow = 0;
            int beeCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputLine = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            const int targetCountOfPollinatedFolwers = 5;

            int countOfPollinatedFlowers = 0;

            bool IsTheBeeLost = false;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                int[] newCoordinates = GetNewCoordinates(command, beeRow, beeCol);

                int newBeeRow = newCoordinates[0];
                int newBeeCol = newCoordinates[1];

                if (IsGoingOutside(matrix, newBeeRow, newBeeCol))
                {
                    matrix[beeRow, beeCol] = '.';

                    IsTheBeeLost = true;

                    break;
                }

                if (matrix[newBeeRow, newBeeCol] == 'f')
                {
                    countOfPollinatedFlowers++;
                }
                else if (matrix[newBeeRow, newBeeCol] == 'O')
                {
                    matrix[newBeeRow, newBeeCol] = '.';

                    int[] coordinatesAfterTheBonus = GetNewCoordinates(command, newBeeRow, newBeeCol);

                    newBeeRow = coordinatesAfterTheBonus[0];
                    newBeeCol = coordinatesAfterTheBonus[1];

                    if (matrix[newBeeRow, newBeeCol] == 'f')
                    {
                        countOfPollinatedFlowers++;
                    }
                }

                matrix[beeRow, beeCol] = '.';
                matrix[newBeeRow, newBeeCol] = 'B';

                beeRow = newBeeRow;
                beeCol = newBeeCol;
            }

            if (IsTheBeeLost)
            {
                Console.WriteLine("The bee got lost!");
            }

            if (countOfPollinatedFlowers < targetCountOfPollinatedFolwers)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {targetCountOfPollinatedFolwers - countOfPollinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {countOfPollinatedFlowers} flowers!");
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

        private static int[] GetNewCoordinates(string direction, int row, int col)
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
