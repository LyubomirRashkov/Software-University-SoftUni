
using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] inputInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string inputName = inputInfo[0];
                int inputAge = int.Parse(inputInfo[1]);
                string inputTown = inputInfo[2];

                Person person = new Person(inputName, inputAge, inputTown);

                people.Add(person);
            }

            int inputIndex = int.Parse(Console.ReadLine());

            int indexOfPersonToCompareWith = inputIndex - 1;

            Person personToCompareWith = people[indexOfPersonToCompareWith];

            int countOfEqualPeople = 0;

            int countOfNotEqualPeople = 0;

            foreach (var person in people)
            {
                if (personToCompareWith.CompareTo(person) == 0)
                {
                    countOfEqualPeople++;
                }
                else
                {
                    countOfNotEqualPeople++;
                }
            }

            if (countOfEqualPeople == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfEqualPeople} {countOfNotEqualPeople} {people.Count}");
            }
        }
    }
}
