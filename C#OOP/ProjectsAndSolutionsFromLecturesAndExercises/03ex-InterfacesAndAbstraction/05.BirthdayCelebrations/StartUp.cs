using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main()
        {
            List<IBirthable> birthables = new List<IBirthable>();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "End")
                {
                    break;
                }

                string[] inputInfo = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string inputType = inputInfo[0];
                string inputName = inputInfo[1];

                if (inputType == nameof(Citizen))
                {
                    int inputAge = int.Parse(inputInfo[2]);
                    string inputId = inputInfo[3];
                    string inputBirthdate = inputInfo[4];

                    IBirthable citizen = new Citizen(inputName, inputAge, inputId, inputBirthdate);

                    birthables.Add(citizen);
                }
                else if (inputType == nameof(Pet))
                {
                    string inputBirthdate = inputInfo[2];

                    IBirthable pet = new Pet(inputName, inputBirthdate);

                    birthables.Add(pet);
                }
            }

            string targetYear = Console.ReadLine();

            birthables = birthables.Where(b => b.Birthdate.EndsWith(targetYear)).ToList();

            foreach (IBirthable birthable in birthables)
            {
                Console.WriteLine(birthable.Birthdate);
            }
        }
    }
}
