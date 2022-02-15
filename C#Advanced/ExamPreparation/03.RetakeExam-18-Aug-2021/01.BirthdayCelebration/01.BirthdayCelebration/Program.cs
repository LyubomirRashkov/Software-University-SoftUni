using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] guestsInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] platesInput = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> guests = new Queue<int>(guestsInput);

            Stack<int> plates = new Stack<int>(platesInput);

            int wastedFood = 0;

            int currentGuest = guests.Peek();

            while (plates.Count > 0)
            {
                int currentPlate = plates.Pop();

                if (currentGuest <= currentPlate)
                {
                    guests.Dequeue();

                    wastedFood += (currentPlate - currentGuest);

                    if (guests.Count == 0)
                    {
                        break;
                    }

                    currentGuest = guests.Peek();
                }
                else
                {
                    currentGuest -= currentPlate;
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(' ', guests)}");
            }
            else if (plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(' ', plates)}");
            }

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
