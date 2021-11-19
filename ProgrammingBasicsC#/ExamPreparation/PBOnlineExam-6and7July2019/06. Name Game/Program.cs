using System;

namespace _06._Name_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int stringLength = 0;
            int currentNumber = 0;
            char currentSymbol = '\0';
            int maxPoints = 0;
            string winner = "";

            while (input != "Stop")
            {
                stringLength = input.Length;
                int points = 0;

                for (int i = 0; i < stringLength; i++)
                {
                    currentNumber = int.Parse(Console.ReadLine());
                    currentSymbol = input[i];
                    if (currentNumber == currentSymbol)
                    {
                        points += 10;
                    }
                    else
                    {
                        points += 2;
                    }
                }

                if (maxPoints <= points)
                {
                    maxPoints = points;
                    winner = input;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The winner is {winner} with {maxPoints} points!");
        }
    }
}
