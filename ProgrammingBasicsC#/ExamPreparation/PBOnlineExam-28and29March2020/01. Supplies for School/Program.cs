using System;

namespace _01._Supplies_for_School
{
    class Program
    {
        static void Main(string[] args)
        {
            int pens = int.Parse(Console.ReadLine());
            int markers = int.Parse(Console.ReadLine());
            double prepation = double.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double sum = (pens * 5.80) + (markers * 7.20) + (prepation * 1.20);
            double clearSum = sum - ((1.0 * discount) / 100) * sum;

            Console.WriteLine($"{clearSum:f3}");
        }
    }
}
