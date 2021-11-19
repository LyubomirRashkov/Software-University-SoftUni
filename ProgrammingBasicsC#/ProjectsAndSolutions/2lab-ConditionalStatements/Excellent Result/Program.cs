using System;

namespace Excellent_Result
{
    class Program
    {
        static void Main(string[] args)
        {
            double evaluation = double.Parse(Console.ReadLine());

            if (evaluation >= 5.50)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
