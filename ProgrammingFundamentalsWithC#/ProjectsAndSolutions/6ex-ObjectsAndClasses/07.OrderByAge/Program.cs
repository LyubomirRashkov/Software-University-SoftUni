using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    public class Person
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] personData = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                string id = personData[1];
                int age = int.Parse(personData[2]);

                Person existingPerson = persons
                    .FirstOrDefault(p => p.Id == id);

                if (existingPerson == null)
                {
                    Person person = new Person
                    {
                        Name = name,
                        Id = id,
                        Age = age
                    };

                    persons.Add(person);
                }
                else
                {
                    existingPerson.Name = name;
                    existingPerson.Age = age;
                }
            }

            List<Person> orderedPersons = persons
                .OrderBy(p => p.Age)
                .ToList();

            foreach (Person person in orderedPersons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
