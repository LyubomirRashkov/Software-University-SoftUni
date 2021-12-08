using System;

namespace _01_3._SoftUni_Reception
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

            int workingHours = (int)Math.Ceiling((double)studentsCount / employeesEfficiencyPerHour);

            int restingHours = workingHours / 3;

            if (workingHours % 3 == 0 && restingHours > 0)
            {
                restingHours--;
            }

            int hours = workingHours + restingHours;

            Console.WriteLine($"Time needed: {hours}h.");

        }
    }
}
