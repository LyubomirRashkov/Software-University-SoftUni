using System;

namespace _06._Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int numOfPieces = width * length;

            int numOfTakenPieces = 0;

            while (input != "STOP")
            {
                int piecesToTake = int.Parse(input);

                numOfTakenPieces += piecesToTake;

                if (numOfTakenPieces > numOfPieces)
                {
                    Console.WriteLine($"No more cake left! You need {numOfTakenPieces - numOfPieces} pieces more.");
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "STOP")
            {
                if (numOfTakenPieces <= numOfPieces)
                {
                    Console.WriteLine($"{numOfPieces - numOfTakenPieces} pieces are left.");
                }
                else
                {
                    Console.WriteLine($"No more cake left! You need {numOfTakenPieces - numOfPieces} pieces more");
                }
            }
        }
    }
}
