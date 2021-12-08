using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int currentPosition = 0;

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Love!")
                {
                    break;
                }

                string[] jump = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int jumpLength = int.Parse(jump[1]);

                if (currentPosition + jumpLength >= numbers.Count)
                {
                    currentPosition = 0;
                }
                else
                {
                    currentPosition += jumpLength;
                }

                if (numbers[currentPosition] == 0)
                {
                    Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
                }
                else
                {
                    numbers[currentPosition] -= 2;

                    if (numbers[currentPosition] == 0)
                    {
                        Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                    }
                }
            }

            Console.WriteLine($"Cupid's last position was {currentPosition}.");

            int housesWithoutCelebraiting = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != 0)
                {
                    housesWithoutCelebraiting++;
                }
            }

            if (housesWithoutCelebraiting == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {housesWithoutCelebraiting} places.");
            }
        }
    }
}
