using System;

namespace _04._Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            int seats = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int people = 0;
            int currentIncome = 0;
            int totalIncome = 0;

            while (input != "Movie time!")
            {
                people = int.Parse(input);
                if (seats < people)
                {
                    Console.WriteLine("The cinema is full.");
                    break;
                }
                currentIncome = people * 5;
                if (people % 3 == 0)
                {
                    currentIncome -= 5;
                }
                totalIncome += currentIncome;
                seats -= people;

                input = Console.ReadLine();
            }

            if (input == "Movie time!")
            {
                Console.WriteLine($"There are {seats} seats left in the cinema.");
            }

            Console.WriteLine($"Cinema income - {totalIncome} lv.");
        }
    }
}
