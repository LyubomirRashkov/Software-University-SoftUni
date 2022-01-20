using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> gradesByStudent = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] lineParts = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string studentName = lineParts[0];
                decimal studentGrade = decimal.Parse(lineParts[1]);

                if (!gradesByStudent.ContainsKey(studentName))
                {
                    gradesByStudent.Add(studentName, new List<decimal>());
                }

                gradesByStudent[studentName].Add(studentGrade);
            }

            foreach (var kvp in gradesByStudent)
            {
                Console.Write($"{kvp.Key} -> ");

                foreach (decimal grade in kvp.Value)
                {
                    Console.Write($"{grade:F2} ");
                }

                if (kvp.Value.Count == 0)
                {
                    Console.WriteLine("(avg: 0.00)");
                }
                else
                {
                    Console.WriteLine($"(avg: {kvp.Value.Average():F2})");
                }
            }
        }
    }
}
