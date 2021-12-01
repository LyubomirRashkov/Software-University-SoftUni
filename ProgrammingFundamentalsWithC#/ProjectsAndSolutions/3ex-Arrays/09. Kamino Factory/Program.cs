using System;
using System.Linq;

namespace _09._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int maxCountOfOnes = 0;
            int firstIndexOfOnes = length - 1;
            int biggestSum = 0;
            int[] bestArray = new int[length];
            int currentArray = 0;
            int bestArrayNumber = 1;
            int sumOfTheBestArray = 0;

            while (input != "Clone them!")
            {
                int[] array = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int countOfOnesInTheArray = 0;
                int maxCountOfOnesInTheArray = 0;
                int firstIndexOfOnesInTheArray = length - 1;
                int sumOfElementsOfTheArray = 0;

                currentArray++;

                for (int i = 0; i < length; i++)
                {
                    if (array[i] == 1)
                    {
                        countOfOnesInTheArray++;

                        if (maxCountOfOnesInTheArray < countOfOnesInTheArray)
                        {
                            maxCountOfOnesInTheArray = countOfOnesInTheArray;

                            if (i == 0)
                            {
                                firstIndexOfOnesInTheArray = i;
                            }
                            else
                            {
                                firstIndexOfOnesInTheArray = i - maxCountOfOnesInTheArray + 1;
                            }
                        }
                    }
                    else
                    {
                        countOfOnesInTheArray = 0;
                    }

                    sumOfElementsOfTheArray += array[i];
                }

                if (maxCountOfOnes < maxCountOfOnesInTheArray)
                {
                    maxCountOfOnes = maxCountOfOnesInTheArray;
                    bestArray = array;
                    bestArrayNumber = currentArray;
                    sumOfTheBestArray = sumOfElementsOfTheArray;
                }
                if (maxCountOfOnes == maxCountOfOnesInTheArray && firstIndexOfOnes > firstIndexOfOnesInTheArray)
                {
                    firstIndexOfOnes = firstIndexOfOnesInTheArray;
                    bestArray = array;
                    bestArrayNumber = currentArray;
                    sumOfTheBestArray = sumOfElementsOfTheArray;
                }
                if (maxCountOfOnes == maxCountOfOnesInTheArray && firstIndexOfOnes == firstIndexOfOnesInTheArray && biggestSum < sumOfElementsOfTheArray)
                {
                    biggestSum = sumOfElementsOfTheArray;
                    bestArray = array;
                    bestArrayNumber = currentArray;
                    sumOfTheBestArray = sumOfElementsOfTheArray;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestArrayNumber} with sum: {sumOfTheBestArray}.");
            Console.WriteLine(string.Join(" ", bestArray));

        }
    }
}
