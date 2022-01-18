using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = sizes[0];
            int cols = sizes[1];

            char[,] matrix = new char[rows, cols];

            string snakeName = Console.ReadLine();

            Queue<char> snakeNameAsAQueue = new Queue<char>(snakeName);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        FillMatrix(matrix, row, col, snakeNameAsAQueue);
                    }
                }
                else
                {
                    for (int col = (matrix.GetLength(1) - 1); col >= 0; col--)
                    {
                        FillMatrix(matrix, row, col, snakeNameAsAQueue);
                    }
                }
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

        private static void FillMatrix(char[,] matrix, int row, int col, Queue<char> snakeNameAsAQueue)
        {
            matrix[row, col] = snakeNameAsAQueue.Peek();
            snakeNameAsAQueue.Enqueue(snakeNameAsAQueue.Dequeue());
        }
    }
}
