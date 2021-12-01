using System;
using System.Linq;

namespace _09_2._Kamino_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int DNALength = int.Parse(Console.ReadLine());

            int longestSequenceSize = 0;
            int longestSequenceStartingIndex = DNALength;
            int highestDNASum = 0;
            int[] bestArray = new int[DNALength];
            int bestSample = 1;
            int sample = 0;

            while (true)
            {
                string command = Console.ReadLine();

                sample++;

                if (command == "Clone them!")
                {
                    break;
                }

                int[] array = command.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int DNASum = 0;

                foreach (var number in array)
                {
                    DNASum += number;
                }

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == 0)
                    {
                        continue;
                    }

                    int currentSequenceSize = 1;

                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] == array[j])
                        {
                            currentSequenceSize++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (currentSequenceSize > longestSequenceSize)
                    {
                        longestSequenceSize = currentSequenceSize;
                        longestSequenceStartingIndex = i;
                        highestDNASum = DNASum;
                        bestArray = array;
                        bestSample = sample;
                    }

                    else if (currentSequenceSize == longestSequenceSize)
                    {
                        if (i < longestSequenceStartingIndex)
                        {
                            longestSequenceStartingIndex = i;
                            highestDNASum = DNASum;
                            bestArray = array;
                            bestSample = sample;
                        }

                        else if (i == longestSequenceStartingIndex && DNASum > highestDNASum)
                        {
                            highestDNASum = DNASum;
                            bestArray = array;
                            bestSample = sample;
                        }
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {highestDNASum}.");
            Console.WriteLine(string.Join(" ", bestArray));
        }
    }
}
