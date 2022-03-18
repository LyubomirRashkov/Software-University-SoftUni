﻿namespace PersonsInfo
{
    public class Person
    {
        private const int TargetAge = 30;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public decimal Salary { get; private set; }

        public void IncreaseSalary(decimal percentage) 
        {
            if (this.Age < TargetAge)
            {
                percentage /= 2;
            }

            this.Salary += this.Salary * (percentage / 100);
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }
    }
}
