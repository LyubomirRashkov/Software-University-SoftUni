﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_2.Students2._0
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Hometown { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] studentData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string firstName = studentData[0];
                string lastName = studentData[1];
                int age = int.Parse(studentData[2]);
                string hometown = studentData[3];

                Student student = students
                    .FirstOrDefault(s => s.FirstName == firstName
                                      && s.LastName == lastName);

                if (student == null)
                {
                    Student newstudent = new Student
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        Hometown = hometown
                    };

                    students.Add(newstudent);
                }
                else
                {
                    student.Age = age;
                    student.Hometown = hometown;
                }
            }

            string targetHometown = Console.ReadLine();

            List<Student> filteredStudents = students
                .Where(n => n.Hometown == targetHometown)
                .ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}
