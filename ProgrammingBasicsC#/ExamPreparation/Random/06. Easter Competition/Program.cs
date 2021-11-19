using System;

namespace _06._Easter_Competition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEasterBreads = int.Parse(Console.ReadLine());

            int maxPoints = 0;
            string bestBaker = "";

            for (int i = 1; i <= numberOfEasterBreads; i++)
            {
                string nameOfTheBaker = Console.ReadLine();
                string input = Console.ReadLine();

                int points = 0;

                while (input != "Stop")
                {
                    int grade = int.Parse(input);
                    points += grade;

                    input = Console.ReadLine();
                }

                Console.WriteLine($"{nameOfTheBaker} has {points} points.");

                if (maxPoints < points)
                {
                    maxPoints = points;
                    bestBaker = nameOfTheBaker;
                    Console.WriteLine($"{nameOfTheBaker} is the new number 1!");
                }
            }

            Console.WriteLine($"{bestBaker} won competition with {maxPoints} points!");
        }
    }
}
