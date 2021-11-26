using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            int addedLiters = 0;

            for (int i = 1; i <= numberOfLines; i++)
            {
                int inputLiters = int.Parse(Console.ReadLine());

                if (addedLiters + inputLiters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                addedLiters += inputLiters;
            }

            Console.WriteLine(addedLiters);
        }
    }
}
