using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students_2._0
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
                
                if (IsStudentExisting(firstName, lastName, students))
                {
                    Student student = GetStudent(firstName, lastName, students);

                    student.Age = age;
                    student.Hometown = hometown;
                }
                else
                {
                    Student student = new Student
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        Hometown = hometown
                    };

                    students.Add(student);
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

        private static Student GetStudent(string firstName, string lastName, List<Student> students)
        {
            Student existingStudent = null;

            foreach (Student student in students)
            {
                if (firstName == student.FirstName && lastName == student.LastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
        }

        private static bool IsStudentExisting(string firstName, string lastName, List<Student> students)
        {
            foreach (Student student in students)
            {
                if (firstName == student.FirstName && lastName == student.LastName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
