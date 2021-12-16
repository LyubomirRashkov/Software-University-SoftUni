using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int pairOfRows = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> gradesByStudents = new Dictionary<string, List<double>>();

            for (int i = 0; i < pairOfRows; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (gradesByStudents.ContainsKey(name))
                {
                    gradesByStudents[name].Add(grade);
                }
                else
                {
                    gradesByStudents.Add(name, new List<double>() { grade });
                }
            }

            Dictionary<string, double> sortedGradesByStudents = gradesByStudents
                .Select(s => new KeyValuePair<string, double>(s.Key, s.Value.Average()))
                .Where(s => s.Value >= 4.50)
                .OrderByDescending(s => s.Value)
                .ToDictionary(s => s.Key, s => s.Value);

            foreach (var kvp in sortedGradesByStudents)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:F2}");
            }
        }
    }
}
