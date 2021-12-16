using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> studentsByCourse = new Dictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string course = parts[0];
                string student = parts[1];

                if (studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse[course].Add(student);
                }
                else
                {
                    studentsByCourse.Add(course, new List<string>() { student });
                }
            }

            Dictionary<string, List<string>> orderedStudentsByCourse = studentsByCourse
                .OrderByDescending(c => c.Value.Count)
                .ToDictionary(c => c.Key, c => c.Value);

            foreach (var kvp in orderedStudentsByCourse)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                kvp.Value.Sort();

                foreach (var student in kvp.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
