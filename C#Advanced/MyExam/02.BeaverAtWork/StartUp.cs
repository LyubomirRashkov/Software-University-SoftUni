using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BeaverAtWork
{
    public class StartUp
    {
        public static void Main()
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            int playerRow = -1;
            int playerCol = -1;

            int countOfWoodBranches = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputRow = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(char.Parse)
                                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputRow[col];

                    if (matrix[row, col] == 'B')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (char.IsLower(matrix[row, col]))
                    {
                        countOfWoodBranches++; ;
                    }
                }
            }

            List<char> collectedWoodBranches = new List<char>(0);
            int totalCountOfCollectedWoodBranches = 0;

            while (true)
            {
                string direction = Console.ReadLine();

                if (direction == "end")
                {
                    break;
                }

                int[] newCoordinates = GetNewCoordinates(direction, playerRow, playerCol);
                int wantedRow = newCoordinates[0];
                int wantedCol = newCoordinates[1];

                if (IsGoingOutside(matrix, wantedRow, wantedCol))
                {
                    if (collectedWoodBranches.Count > 0)
                    {
                        collectedWoodBranches.RemoveAt(collectedWoodBranches.Count - 1);
                    }
                    continue;
                }

                matrix[playerRow, playerCol] = '-';

                playerRow = wantedRow;
                playerCol = wantedCol;

                if (matrix[playerRow, playerCol] == '-')
                {
                    matrix[playerRow, playerCol] = 'B';
                }
                else if (char.IsLower(matrix[playerRow, playerCol]))
                {
                    collectedWoodBranches.Add(matrix[playerRow, playerCol]);
                    totalCountOfCollectedWoodBranches++;
                    matrix[playerRow, playerCol] = 'B';

                    if (totalCountOfCollectedWoodBranches == countOfWoodBranches)
                    {
                        break;
                    }
                }
                else if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = '-';

                    int[] coordinatesAfterFish = GetCoordinatesAfterFish(matrix, direction, playerRow, playerCol);
                    playerRow = coordinatesAfterFish[0];
                    playerCol = coordinatesAfterFish[1];

                    if (char.IsLower(matrix[playerRow, playerCol]))
                    {
                        collectedWoodBranches.Add(matrix[playerRow, playerCol]);
                        totalCountOfCollectedWoodBranches++;
                    }

                    matrix[playerRow, playerCol] = 'B';

                    if (totalCountOfCollectedWoodBranches == countOfWoodBranches)
                    {
                        break;
                    }
                }
            }

            if (totalCountOfCollectedWoodBranches == countOfWoodBranches)
            {
                Console.WriteLine($"The Beaver successfully collect {collectedWoodBranches.Count} wood branches: {string.Join(", ", collectedWoodBranches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {countOfWoodBranches - totalCountOfCollectedWoodBranches} branches left.");
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

        private static int[] GetCoordinatesAfterFish(char[,] matrix, string direction, int row, int col)
        {
            int[] coordinates = new int[2];

            if (direction == "up")
            {
                if (row == 0)
                {
                    coordinates[0] = matrix.GetLength(0) - 1;
                }
                else
                {
                    coordinates[0] = 0;
                }

                coordinates[1] = col;
            }
            else if (direction == "down")
            {
                if (row == matrix.GetLength(0) - 1)
                {
                    coordinates[0] = 0;
                }
                else
                {
                    coordinates[0] = matrix.GetLength(0) - 1;
                }

                coordinates[1] = col;
            }
            else if (direction == "left")
            {
                if (col == 0)
                {
                    coordinates[1] = matrix.GetLength(1) - 1;
                }
                else
                {
                    coordinates[1] = 0;
                }

                coordinates[0] = row;
            }
            else if (direction == "right")
            {
                if (col == matrix.GetLength(1) - 1)
                {
                    coordinates[1] = 0;
                }
                else
                {
                    coordinates[1] = matrix.GetLength(1) - 1;
                }

                coordinates[0] = row;
            }

            return coordinates;
        }

        private static bool IsGoingOutside(char[,] matrix, int row, int col)
        {
            return row < 0 || row == matrix.GetLength(0) || col < 0 || col == matrix.GetLength(1);
        }

        private static int[] GetNewCoordinates(string direction, int row, int col)
        {
            int[] coordinates = new int[2];

            if (direction == "up")
            {
                coordinates[0] = row - 1;
                coordinates[1] = col;
            }
            else if (direction == "down")
            {
                coordinates[0] = row + 1;
                coordinates[1] = col;
            }
            else if (direction == "left")
            {
                coordinates[0] = row;
                coordinates[1] = col - 1;
            }
            else if (direction == "right")
            {
                coordinates[0] = row;
                coordinates[1] = col + 1;
            }

            return coordinates;
        }
    }
}
