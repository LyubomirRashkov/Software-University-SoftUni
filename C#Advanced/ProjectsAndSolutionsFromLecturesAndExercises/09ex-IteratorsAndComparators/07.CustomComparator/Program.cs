using System;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> customComparator = (number1, number2) => (number1 % 2 == 0 && number2 % 2 != 0) ? -1 : 
                                                                         (number1 % 2 != 0 && number2 % 2 == 0) ? 1 :
                                                                          number1.CompareTo(number2);

            Array.Sort(numbers, new Comparison<int>(customComparator));

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}