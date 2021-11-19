using System;

namespace _04._Darts
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string input = Console.ReadLine();

            int counterOfSuccess = 0;
            int counterOfUnsuccess = 0;
            int add = 0;
            int goal = 301;

            while (input != "Retire")
            {
                int points = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case "Single":
                        add = points;
                        break;
                    case "Double":
                        add = points * 2;
                        break;
                    case "Triple":
                        add = points * 3;
                        break;
                }

                if (add <= goal)
                {
                    goal -= add;
                    counterOfSuccess++;
                }
                else
                {
                    counterOfUnsuccess++;
                }

                if (goal == 0)
                {
                    Console.WriteLine($"{name} won the leg with {counterOfSuccess} shots.");
                    break;
                }

                input = Console.ReadLine();
            }

            if (input == "Retire")
            {
                Console.WriteLine($"{name} retired after {counterOfUnsuccess} unsuccessful shots.");
            }



        }
    }
}
