using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private Dictionary<string, Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new Dictionary<string, Student>();
        }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return this.students.Count;
            }
        }

        public string RegisterStudent(Student student)
        {
            if (this.Capacity > this.Count)
            {
                string fullName = student.FirstName + " " + student.LastName;

                this.students.Add(fullName, student);

                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            string fullName = firstName + " " + lastName;

            if (this.students.Remove(fullName))
            {
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            Dictionary<string, Student> filteredStudentsBySubject = this.students
                                                                     .Where(kvp => kvp.Value.Subject == subject)
                                                                     .ToDictionary(k => k.Key, v => v.Value);

            if (filteredStudentsBySubject.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var kvp in filteredStudentsBySubject)
                {
                    sb.AppendLine($"{kvp.Key}");
                }

                return sb.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount() => this.Count;

        public Student GetStudent(string firstName, string lastName)
        {
            string fullName = firstName + " " + lastName;

            return this.students[fullName];
        }
    }
}
