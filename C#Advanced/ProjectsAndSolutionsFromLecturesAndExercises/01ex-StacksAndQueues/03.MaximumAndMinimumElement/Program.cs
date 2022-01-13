using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());

            Stack<int> numbers = new Stack<int>();

            for (int i = 0; i < numberOfQueries; i++)
            {
                string query = Console.ReadLine();

                if (query != "2" && query != "3" && query != "4")
                {
                    string[] queryParts = query.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    int number = int.Parse(queryParts[1]);

                    numbers.Push(number);
                }
                else if (query == "2" && DoesStackHasElements(numbers))
                {
                    numbers.Pop();
                }
                else if (query == "3" && DoesStackHasElements(numbers))
                {
                    Console.WriteLine(numbers.Max());
                }
                else if (query == "4" && DoesStackHasElements(numbers))
                {
                    Console.WriteLine(numbers.Min());
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static bool DoesStackHasElements(Stack<int> numbers)
        {
            if (numbers.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}
