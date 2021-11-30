using System;
using System.Linq;

namespace _04_2._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
