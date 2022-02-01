using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] personInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);

                people.Add(person);
            }

            List<Person> sortedPeople = people
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (Person person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
