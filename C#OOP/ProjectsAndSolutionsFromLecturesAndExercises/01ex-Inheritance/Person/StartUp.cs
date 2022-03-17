using System;

namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            const int RequiredAgeToBeAPerson = 15;

            string inputName = Console.ReadLine();

            int inputAge = int.Parse(Console.ReadLine());

            Person person = null;

            if (inputAge > RequiredAgeToBeAPerson)
            {
                person = new Person(inputName, inputAge);
            }
            else if (inputAge >= 0 && inputAge <= RequiredAgeToBeAPerson)
            {
                person = new Child(inputName, inputAge);
            }

            if (person != null)
            {
                Console.WriteLine(person);
            }
        }
    }
}