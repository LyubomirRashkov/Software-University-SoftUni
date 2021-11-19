using System;

namespace _06._High_Jump
{
    class Program
    {
        static void Main(string[] args)
        {
            int target = int.Parse(Console.ReadLine());

            int start = target - 30;
            int counterAllJumps = 0;
            int counterBadJumps = 0;

            while (start <= target)
            {
                int jump = int.Parse(Console.ReadLine());
                counterAllJumps++;

                if (jump > start)
                {
                    start += 5;
                    counterBadJumps = 0;
                }
                else
                {
                    counterBadJumps++;
                }

                if (counterBadJumps == 3)
                {
                    Console.WriteLine($"Tihomir failed at {start}cm after {counterAllJumps} jumps.");
                    return;
                }
            }

            if (start > target)
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {target}cm after {counterAllJumps} jumps.");
            }
        }
    }
}
