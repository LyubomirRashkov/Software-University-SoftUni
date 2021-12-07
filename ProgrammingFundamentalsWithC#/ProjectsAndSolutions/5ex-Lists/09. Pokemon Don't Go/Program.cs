using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int sumOfRemovedElements = 0;

            while (numbers.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int elementForCalculations = numbers[0];
                    sumOfRemovedElements += elementForCalculations;
                    numbers.RemoveAt(0);
                    int elementForCopying = numbers[numbers.Count - 1];
                    numbers.Insert(0, elementForCopying);

                    IterateThroughTheList(numbers, elementForCalculations);
                }
                else if (index > numbers.Count - 1)
                {
                    int elementForCalculations = numbers[numbers.Count - 1];
                    sumOfRemovedElements += elementForCalculations;
                    numbers.RemoveAt(numbers.Count - 1);
                    int elementForCopying = numbers[0];
                    numbers.Add(elementForCopying);

                    IterateThroughTheList(numbers, elementForCalculations);
                }
                else
                {
                    int element = numbers[index];
                    sumOfRemovedElements += element;
                    numbers.RemoveAt(index);

                    IterateThroughTheList(numbers, element);
                }
            }

            Console.WriteLine(sumOfRemovedElements);
        }

        private static List<int> IterateThroughTheList(List<int> numbers, int elementForCalculations)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];

                if (currentNumber <= elementForCalculations)
                {
                    numbers[i] += elementForCalculations;
                }
                else
                {
                    numbers[i] -= elementForCalculations;
                }
            }

            return numbers;
        }
    }
}
