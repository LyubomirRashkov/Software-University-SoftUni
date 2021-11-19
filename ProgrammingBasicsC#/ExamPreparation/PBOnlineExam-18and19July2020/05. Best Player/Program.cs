using System;

namespace _05._Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {
            string player = Console.ReadLine();
            int goals = 0;

            string bestPlayer = "";
            int maxGoals = 0;

            while (player != "END")
            {
                goals = int.Parse(Console.ReadLine());

                if (goals > maxGoals)
                {
                    maxGoals = goals;
                    bestPlayer = player;
                }

                if (maxGoals >= 10)
                {
                    Console.WriteLine($"{bestPlayer} is the best player!");
                    Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
                    break;
                }

                player = Console.ReadLine();
            }

            if (maxGoals >= 3 && maxGoals < 10)
            {
                Console.WriteLine($"{bestPlayer} is the best player!");
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            }
            else if (maxGoals < 3)
            {
                Console.WriteLine($"{bestPlayer} is the best player!");
                Console.WriteLine($"He has scored {maxGoals} goals.");
            }
        }
    }
}
