using System;
using System.Linq;

namespace _02._The_Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());

            int[] lift = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int MAXIMUM = 4;

            for (int i = 0; i < lift.Length; i++)
            {
                int currentWagon = lift[i];

                if (currentWagon < MAXIMUM)
                {
                    int liftedPeopleInTheWagon = MAXIMUM - currentWagon;

                    if (peopleCount >= liftedPeopleInTheWagon)
                    {
                        lift[i] = MAXIMUM;
                        peopleCount -= liftedPeopleInTheWagon;
                    }
                    else
                    {
                        lift[i] += peopleCount;
                        peopleCount = 0;
                        break;
                    }
                }
            }

            if (lift[lift.Length -1] != MAXIMUM && peopleCount == 0)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", lift));
            }
            else if (lift[lift.Length - 1] == MAXIMUM && peopleCount > 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleCount} people in a queue!");
                Console.WriteLine(string.Join(" ", lift));
            }
            else if (lift[lift.Length - 1] == MAXIMUM && peopleCount == 0)
            {
                Console.WriteLine(string.Join(" ", lift));
            }
        }
    }
}
