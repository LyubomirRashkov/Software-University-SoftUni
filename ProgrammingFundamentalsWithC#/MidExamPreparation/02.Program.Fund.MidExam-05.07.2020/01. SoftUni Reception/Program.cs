using System;

namespace _01._SoftUni_Reception
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());

            int studentsCount = int.Parse(Console.ReadLine());

            int employeesEfficiencyPerHour = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;

            int hours = 0;
            bool isFirstBreak = false;

            while (studentsCount > 0)
            {
                if (hours != 0 && hours % 3 == 0 && !isFirstBreak)
                {
                    hours++;
                    isFirstBreak = true;
                }
                else if (hours != 0 && isFirstBreak && (hours - 3) % 4 == 0)
                {
                    hours++;
                }
                else
                {
                    hours++;
                    studentsCount -= employeesEfficiencyPerHour;
                }
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
