using System;

namespace PersonsInfo
{
    public class Person
    {
        private const int MinNameLength = 3;
        private const int MinAge = 1;
        private const decimal MinSalary = 650;

        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get => this.firstName;

            private set
            {
                if (value.Length < MinNameLength)
                {
                    throw new ArgumentException($"First name cannot contain fewer than {MinNameLength} symbols!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;

            private set
            {
                if (value.Length < MinNameLength)
                {
                    throw new ArgumentException($"Last name cannot contain fewer than {MinNameLength} symbols!");
                }

                this.lastName = value;
            }
        }
        public int Age
        {
            get => this.age;

            private set
            {
                if (value < MinAge)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                this.age = value;
            }
        }

        public decimal Salary { get => this.salary; private set => this.salary = value; }
    }
}
