using System;

namespace _05._Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int height = 0;

            int counterOfDays = 1;
            int target = 8848;
            int start = 5364;

            while (input != "END")
            {
                if (input == "Yes")
                {
                    counterOfDays++;
                }

                if (counterOfDays > 5)
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine($"{start}");
                    break;
                }

                height = int.Parse(Console.ReadLine());

                start += height;

                if (start >= target)
                {
                    Console.WriteLine($"Goal reached for {counterOfDays} days!");
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "END")
            {
                if (start >= target)
                {
                    Console.WriteLine($"Goal reached for {counterOfDays} days!");
                }
                else
                {
                    Console.WriteLine("Failed!");
                    Console.WriteLine($"{start}");
                }
            }
        }
    }
}
