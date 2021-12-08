using System;

namespace _01._Bonus_Scoring_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            double currentBonus = 0;
            int maxBonusAttendances = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                int attendances = int.Parse(Console.ReadLine());

                currentBonus = ((double)attendances / lecturesCount) * (5 + additionalBonus);

                if (maxBonus <= currentBonus)
                {
                    maxBonus = currentBonus;
                    maxBonusAttendances = attendances;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {maxBonusAttendances} lectures.");
        }
    }
}
