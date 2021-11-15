using System;

namespace _04._Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            const int GOAL = 10000;

            int sumOfSteps = 0;

            while (sumOfSteps < GOAL)
            {
                string input = Console.ReadLine();

                if (input != "Going home")
                {
                    int steps = int.Parse(input);
                    sumOfSteps += steps;
                }
                else if (input == "Going home")
                {
                    int steps = int.Parse(Console.ReadLine());
                    sumOfSteps += steps;

                    if (sumOfSteps < GOAL)
                    {
                        Console.WriteLine($"{GOAL - sumOfSteps} more steps to reach goal.");
                        break;
                    }
                }
            }

            if (sumOfSteps >= GOAL)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{sumOfSteps - GOAL} steps over the goal!");
            }
        }
    }
}
