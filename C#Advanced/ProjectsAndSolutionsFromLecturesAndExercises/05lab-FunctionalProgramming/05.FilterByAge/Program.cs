using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>(numberOfLines);

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] lineParts = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = lineParts[0];
                int age = int.Parse(lineParts[1]);

                Person person = new Person
                {
                    Name = name,
                    Age = age
                };

                people.Add(person);
            }


            string condition = Console.ReadLine();
            int targetAge = int.Parse(Console.ReadLine());

            Func<Person, bool> filter = p => true;

            if (condition == "older")
            {
                filter = p => p.Age >= targetAge;
            }
            else
            {
                filter = p => p.Age < targetAge;
            }

            List<Person> filteredPeople = people
                .Where(p => filter(p))
                .ToList();

            string formatForPrinting = Console.ReadLine();

            Func<Person, string> formatedInfo = p => p.Name + " - " + p.Age;

            if (formatForPrinting == "name")
            {
                formatedInfo = p => p.Name;
            }
            else if (formatForPrinting == "age")
            {
                formatedInfo = p => p.Age.ToString();
            }

            string[] personInfo = filteredPeople
                .Select(p => formatedInfo(p))
                .ToArray();

            foreach (string person in personInfo)
            {
                Console.WriteLine(person);
            }
        }
    }
}
