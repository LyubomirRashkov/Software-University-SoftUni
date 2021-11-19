using System;

namespace _04._Trekking_Mania
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroups = int.Parse(Console.ReadLine());
            int numberOfPeopleInTheGroup = 0;

            double allPeople = 0;

            int peopleForMusala = 0;
            int peopleForMonblan = 0;
            int peopleForKilimanjaro = 0;
            int peopleForK2 = 0;
            int peopleForEverest = 0;

            for (int i = 1; i <= numberOfGroups; i++)
            {
                numberOfPeopleInTheGroup = int.Parse(Console.ReadLine());

                allPeople += numberOfPeopleInTheGroup;

                if (numberOfPeopleInTheGroup <= 5)
                {
                    peopleForMusala += numberOfPeopleInTheGroup;
                }
                else if (numberOfPeopleInTheGroup <= 12)
                {
                    peopleForMonblan += numberOfPeopleInTheGroup;
                }
                else if (numberOfPeopleInTheGroup <= 25)
                {
                    peopleForKilimanjaro += numberOfPeopleInTheGroup;
                }
                else if (numberOfPeopleInTheGroup <= 40)
                {
                    peopleForK2 += numberOfPeopleInTheGroup;
                }
                else if (numberOfPeopleInTheGroup > 40)
                {
                    peopleForEverest += numberOfPeopleInTheGroup;
                }
            }

            Console.WriteLine($"{((peopleForMusala * 100) / allPeople):f2}%");
            Console.WriteLine($"{((peopleForMonblan * 100) / allPeople):f2}%");
            Console.WriteLine($"{((peopleForKilimanjaro * 100) / allPeople):f2}%");
            Console.WriteLine($"{((peopleForK2 * 100) / allPeople):f2}%");
            Console.WriteLine($"{((peopleForEverest * 100) / allPeople):f2}%");
        }
    }
}
