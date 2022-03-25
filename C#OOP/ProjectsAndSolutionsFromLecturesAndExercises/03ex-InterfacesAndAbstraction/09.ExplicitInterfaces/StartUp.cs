using System;

namespace _09.ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main()
        {
            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "End")
                {
                    break;
                }

                string[] inputInfo = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = inputInfo[0];
                string country = inputInfo[1];
                int age = int.Parse(inputInfo[2]);

                Citizen citizen = new Citizen(name, country, age);

                IPerson person = citizen;
                IResident resident = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
