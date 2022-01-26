using System;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printCollection = collection => Console.WriteLine(string.Join('\n', collection));

            printCollection(names);
        }
    }
}
