using System;

namespace _07.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int countOfRemovedKnights = 0;

            while (true)
            {
                int maxCountOfAttacks = 0;
                int rowOfTheBestAttacker = -1;
                int colOfTheBestAttacker = -1;
                bool isAttackerFound = false;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int countOfAttacksOfTheCurrentKnight = 0;

                            if (IsValidMove(matrix, row - 1, col - 2))
                            {
                                if (matrix[row - 1, col - 2] == 'K')
                                {
                                    countOfAttacksOfTheCurrentKnight++;
                                }
                            }

                            if (IsValidMove(matrix, row - 2, col - 1))
                            {
                                if (matrix[row - 2, col - 1] == 'K')
                                {
                                    countOfAttacksOfTheCurrentKnight++;
                                }
                            }

                            if (IsValidMove(matrix, row - 2, col + 1))
                            {
                                if (matrix[row - 2, col + 1] == 'K')
                                {
                                    countOfAttacksOfTheCurrentKnight++;
                                }
                            }

                            if (IsValidMove(matrix, row - 1, col + 2))
                            {
                                if (matrix[row - 1, col + 2] == 'K')
                                {
                                    countOfAttacksOfTheCurrentKnight++;
                                }
                            }

                            if (IsValidMove(matrix, row + 1, col + 2))
                            {
                                if (matrix[row + 1, col + 2] == 'K')
                                {
                                    countOfAttacksOfTheCurrentKnight++;
                                }
                            }

                            if (IsValidMove(matrix, row + 2, col + 1))
                            {
                                if (matrix[row + 2, col + 1] == 'K')
                                {
                                    countOfAttacksOfTheCurrentKnight++;
                                }
                            }

                            if (IsValidMove(matrix, row + 2, col - 1))
                            {
                                if (matrix[row + 2, col - 1] == 'K')
                                {
                                    countOfAttacksOfTheCurrentKnight++;
                                }
                            }

                            if (IsValidMove(matrix, row + 1, col - 2))
                            {
                                if (matrix[row + 1, col - 2] == 'K')
                                {
                                    countOfAttacksOfTheCurrentKnight++;
                                }
                            }

                            if (maxCountOfAttacks < countOfAttacksOfTheCurrentKnight)
                            {
                                maxCountOfAttacks = countOfAttacksOfTheCurrentKnight;
                                rowOfTheBestAttacker = row;
                                colOfTheBestAttacker = col;
                                isAttackerFound = true;
                            }
                        }
                    }
                }

                if (isAttackerFound)
                {
                    matrix[rowOfTheBestAttacker, colOfTheBestAttacker] = '0';
                    countOfRemovedKnights++;
                }

                if (maxCountOfAttacks == 0)
                {
                    break;
                }
            }

            Console.WriteLine(countOfRemovedKnights);
        }

        private static bool IsValidMove(char[,] matrix, int row, int col)
        {
            return (row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1));
        }
    }
}
