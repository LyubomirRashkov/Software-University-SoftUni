using System;

namespace _02._Exam_Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPoorGrades = int.Parse(Console.ReadLine());

            string taskName = Console.ReadLine();

            int sumOfGrades = 0;
            int counterOfTasks = 0;
            int counterOfPoorGrades = 0;
            string lastTask = "";

            while (taskName != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());

                if (grade <= 4)
                {
                    counterOfPoorGrades++;
                }

                if (counterOfPoorGrades == numOfPoorGrades)
                {
                    Console.WriteLine($"You need a break, {counterOfPoorGrades} poor grades.");
                    break;
                }

                sumOfGrades += grade;
                counterOfTasks++;

                lastTask = taskName;

                taskName = Console.ReadLine();
            }

                if (taskName == "Enough")
                {
                    Console.WriteLine($"Average score: {((1.0 * sumOfGrades) / counterOfTasks):f2}");
                    Console.WriteLine($"Number of problems: {counterOfTasks}");
                    Console.WriteLine($"Last problem: {lastTask}");
                }
        }
    }
}
