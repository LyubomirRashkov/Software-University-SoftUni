using System;

namespace _11._Multiplication_Table_2._0___2
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            int i = multiplier;
            do
            {
                Console.WriteLine($"{number} X {i} = {number * i}");
                i++;
            } while (i <= 10);
        }
    }
}
