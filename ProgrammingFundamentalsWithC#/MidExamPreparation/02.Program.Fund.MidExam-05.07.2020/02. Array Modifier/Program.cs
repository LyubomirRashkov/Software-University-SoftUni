using System;
using System.Linq;
using System.Numerics;

namespace _02._Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(BigInteger.Parse)
                .ToArray();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parts[0] == "swap")
                {
                    int firstIndex = int.Parse(parts[1]);
                    int secondIndex = int.Parse(parts[2]);

                    BigInteger element = numbers[firstIndex];

                    numbers[firstIndex] = numbers[secondIndex];
                    numbers[secondIndex] = element;
                }
                else if (parts[0] == "multiply")
                {
                    int firstIndex = int.Parse(parts[1]);
                    int secondIndex = int.Parse(parts[2]);

                    numbers[firstIndex] *= numbers[secondIndex];
                }
                else if (parts[0] == "decrease")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] -= 1;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
