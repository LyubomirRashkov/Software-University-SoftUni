using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine()
                                               .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                               .Select(int.Parse)
                                               .ToArray());

            Queue<int> roses = new Queue<int>(Console.ReadLine()
                                              .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                                              .Select(int.Parse)
                                              .ToArray());

            const int neededFlowersForAWreath = 15;
            const int targetNumberOfWreaths = 5;

            int countOfCreatedWreaths = 0;
            int sumOfWastedFlowers = 0;

            while (lilies.Any() && roses.Any())
            {
                int currentLily = lilies.Pop();
                int currentRose = roses.Peek();

                int sum = currentLily + currentRose;

                if (sum == neededFlowersForAWreath)
                {
                    countOfCreatedWreaths++;

                    roses.Dequeue();
                }
                else if (sum > neededFlowersForAWreath)
                {
                    lilies.Push(currentLily - 2);
                }
                else
                {
                    sumOfWastedFlowers += sum;

                    roses.Dequeue();
                }
            }

            countOfCreatedWreaths += (sumOfWastedFlowers / neededFlowersForAWreath);

            if (countOfCreatedWreaths >= targetNumberOfWreaths)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countOfCreatedWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {targetNumberOfWreaths - countOfCreatedWreaths} wreaths more!");
            }
        }
    }
}
