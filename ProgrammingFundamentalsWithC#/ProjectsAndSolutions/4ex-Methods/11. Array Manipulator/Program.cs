using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] command = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "exchange")
                {
                    int index = int.Parse(command[1]);

                    if (index < 0 || index > numbers.Length - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    numbers = ExchangeArrayByGivenIndex(numbers, index);
                }
                else if (command[0] == "max")
                {
                    int index = GetMax(numbers, command[1]);

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }
                else if (command[0] == "min")
                {
                    int index = GetMin(numbers, command[1]);

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine(index);
                    }
                }
                else if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);

                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    int[] firstElements = GetFirstElements(numbers, int.Parse(command[1]), command[2]);

                    PrintArray(firstElements);
                }
                else if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);

                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    int[] lastElements = GetLastElements(numbers, int.Parse(command[1]), command[2]);

                    PrintArray(lastElements);
                }
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static int[] GetLastElements(int[] array, int length, string parameter)
        {
            int[] lastElements = new int[length];
            int parity = GetParity(parameter);
            int index = 0;

            for (int i = 0; i < lastElements.Length; i++)
            {
                lastElements[i] = -1;
            }

            for (int i = array.Length-1; i >= 0; i--)
            {
                if (array[i] % 2 == parity)
                {
                    lastElements[index] = array[i];
                    index++;

                    if (index == lastElements.Length)
                    {
                        break;
                    }
                }
            }

            return lastElements.Reverse().ToArray();
        }

        private static void PrintArray(int[] elements)
        {
            bool printed = false;

            Console.Write("[");

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != -1)
                {
                    if (printed)
                    {
                        Console.Write($", {elements[i]}");
                    }
                    else
                    {
                        Console.Write($"{elements[i]}");
                        printed = true;
                    }
                }
            }

            Console.WriteLine("]");
        }

        private static int[] GetFirstElements(int[] array, int length, string parameter)
        {
            int[] firstElements = new int[length];
            int parity = GetParity(parameter);
            int index = 0;

            for (int i = 0; i < firstElements.Length; i++)
            {
                firstElements[i] = -1;
            }

            foreach (int number in array)
            {
                if (number % 2 == parity)
                {
                    firstElements[index] = number;
                    index++;

                    if (index == firstElements.Length)
                    {
                        break;
                    }
                }
            }

            return firstElements;
        }

        private static int GetMin(int[] array, string parameter)
        {
            int parity = GetParity(parameter);

            int index = -1;
            int minNumber = int.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] <= minNumber && array[i] % 2 == parity)
                {
                    minNumber = array[i];
                    index = i;
                }
            }

            return index;
        }

        private static int GetParity(string parameter)
        {
            if (parameter == "even")
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        private static int GetMax(int[] array, string parameter)
        {
            int parity = GetParity(parameter);

            int index = -1;
            int maxNumber = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= maxNumber && array[i] % 2 == parity)
                {
                    maxNumber = array[i];
                    index = i;
                }
            }

            return index;
        }

        private static int[] ExchangeArrayByGivenIndex(int[] array, int index)
        {
            for (int i = 0; i <= index; i++)
            {
                int temp = array[0];

                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }

                array[array.Length - 1] = temp;
            }

            return array;
        }
    }
}
