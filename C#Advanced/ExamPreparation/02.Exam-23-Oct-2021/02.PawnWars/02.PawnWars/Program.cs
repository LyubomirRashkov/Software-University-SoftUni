using System;
using System.Text;

namespace _02.PawnWars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];

            int whiteRow = 0;
            int whiteCol = 0;

            int blackRow = 0;
            int blackCol = 0;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string inputLine = Console.ReadLine();

                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = inputLine[col];

                    if (board[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    else if (board[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            bool doesWhiteCapture = false;
            bool doesBlackCapture = false;

            bool doesWhiteReachesTheEnd = false;
            bool doesBlackReachesTheEnd = false;

            while (true)
            {
                if (WhiteWillCapture(whiteRow, whiteCol, blackRow, blackCol))
                {
                    whiteRow = blackRow;
                    whiteCol = blackCol;

                    doesWhiteCapture = true;

                    break;
                }

                if (whiteRow - 1 == 0)
                {
                    whiteRow = 0;

                    doesWhiteReachesTheEnd = true;

                    break;
                }

                whiteRow--;

                if (BlackWillCapture(blackRow, blackCol, whiteRow, whiteCol))
                {
                    blackRow = whiteRow;
                    blackCol = whiteCol;

                    doesBlackCapture = true;

                    break;
                }

                if (blackRow + 1 == 7)
                {
                    blackRow = 7;

                    doesBlackReachesTheEnd = true;

                    break;
                }

                blackRow++;
            }


            if (doesWhiteCapture)
            {
                string winnerCoordinates = GetCoordinates(whiteRow, whiteCol);

                Console.WriteLine($"Game over! White capture on {winnerCoordinates}.");
            }
            else if (doesBlackCapture)
            {
                string winnerCoordinates = GetCoordinates(blackRow, blackCol);

                Console.WriteLine($"Game over! Black capture on {winnerCoordinates}.");
            }
            else if (doesWhiteReachesTheEnd)
            {
                string winnerCoordinates = GetCoordinates(whiteRow, whiteCol);

                Console.WriteLine($"Game over! White pawn is promoted to a queen at {winnerCoordinates}.");
            }
            else if (doesBlackReachesTheEnd)
            {
                string winnerCoordinates = GetCoordinates(blackRow, blackCol);

                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {winnerCoordinates}.");
            }
        }

        private static string GetCoordinates(int row, int col)
        {
            StringBuilder sb = new StringBuilder();

            if (col == 0)
            {
                sb.Append("a");
            }
            else if (col == 1)
            {
                sb.Append("b");
            }
            else if (col == 2)
            {
                sb.Append("c");
            }
            else if (col == 3)
            {
                sb.Append("d");
            }
            else if (col == 4)
            {
                sb.Append("e");
            }
            else if (col == 5)
            {
                sb.Append("f");
            }
            else if (col == 6)
            {
                sb.Append("g");
            }
            else if (col == 7)
            {
                sb.Append("h");
            }

            if (row == 0)
            {
                sb.Append("8");
            }
            else if (row == 1)
            {
                sb.Append("7");
            }
            else if (row == 2)
            {
                sb.Append("6");
            }
            else if (row == 3)
            {
                sb.Append("5");
            }
            else if (row == 4)
            {
                sb.Append("4");
            }
            else if (row == 5)
            {
                sb.Append("3");
            }
            else if (row == 6)
            {
                sb.Append("2");
            }
            else if (row == 7)
            {
                sb.Append("1");
            }

            return sb.ToString();
        }

        private static bool BlackWillCapture(int blackRow, int blackCol, int whiteRow, int whiteCol)
        {
            if (blackRow + 1 == whiteRow)
            {
                if (blackCol - 1 == whiteCol || blackCol + 1 == whiteCol)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool WhiteWillCapture(int whiteRow, int whiteCol, int blackRow, int blackCol)
        {
            if (whiteRow - 1 == blackRow)
            {
                if (whiteCol - 1 == blackCol || whiteCol + 1 == blackCol)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
