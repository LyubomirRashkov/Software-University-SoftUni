using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bomb_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int[] bombData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int bombNumber = bombData[0];
            int bombPower = bombData[1];

            while (true)
            {
                int bombIndex = numbers.IndexOf(bombNumber);

                if (bombIndex == -1)
                {
                    break;
                }

                int startIndex = bombIndex - bombPower;

                if (startIndex < 0)
                {
                    startIndex = 0;
                }

                int count = (bombPower * 2) + 1;

                if (startIndex + count >= numbers.Count)
                {
                    count = (numbers.Count) - startIndex;
                }

                numbers.RemoveRange(startIndex, count);
            }

            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}
