using System;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputLine = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }

            char targetSymbol = char.Parse(Console.ReadLine());

            int rowOfTheTargetSymbol = 0;
            int colOfTheTargetSymbol = 0;

            bool isFound = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == targetSymbol)
                    {
                        rowOfTheTargetSymbol = row;
                        colOfTheTargetSymbol = col;

                        isFound = true;

                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            if (isFound)
            {
                Console.WriteLine($"({rowOfTheTargetSymbol}, {colOfTheTargetSymbol})");
            }
            else
            {
                Console.WriteLine($"{targetSymbol} does not occur in the matrix");
            }
        }
    }
}
