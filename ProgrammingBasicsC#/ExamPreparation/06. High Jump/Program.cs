using System;

namespace _06._High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());

            int fitstTarget = target - 30;
            int jumpsCounter = 0;
            int badJumpsCounter = 0;

            while (fitstTarget <= target)
            {
                int achievedHeight = int.Parse(Console.ReadLine());
                jumpsCounter++;
                if (achievedHeight > fitstTarget)
                {
                    fitstTarget += 5;
                    badJumpsCounter = 0;
                }
                else
                {
                    badJumpsCounter++;
                }
                if (badJumpsCounter == 3)
                {
                    Console.WriteLine($"Tihomir failed at {fitstTarget}cm after {jumpsCounter} jumps.");
                    return;
                }
            }

            if (fitstTarget > target)
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {target}cm after {jumpsCounter} jumps.");
            }
        }
    }
}
