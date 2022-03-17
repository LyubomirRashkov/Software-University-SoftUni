using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "Beast!")
                {
                    break;
                }

                string animalType = inputLine;

                string[] animalInfo = Console.ReadLine()
                                       .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (animalType != "Dog" && animalType != "Frog" && animalType != "Cat" && animalType != "Kitten" && animalType != "Tomcat")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (animalInfo.Length != 3)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string animalName = animalInfo[0];

                bool intResultTryParse = int.TryParse(animalInfo[1], out int animalAge);

                if (!intResultTryParse || animalAge < 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string animalGender = animalInfo[2];

                Animal currentAnimal;

                if (animalType == "Dog")
                {
                    if (!IsInputGenderValid(animalGender))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    currentAnimal = new Dog(animalName, animalAge, animalGender);
                }
                else if (animalType == "Frog")
                {
                    if (!IsInputGenderValid(animalGender))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    currentAnimal = new Frog(animalName, animalAge, animalGender);
                }
                else if (animalType == "Cat")
                {
                    if (!IsInputGenderValid(animalGender))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    currentAnimal = new Cat(animalName, animalAge, animalGender);
                }
                else if (animalType == "Kitten")
                {
                    currentAnimal = new Kitten(animalName, animalAge);
                }
                else
                {
                    currentAnimal = new Tomcat(animalName, animalAge);
                }

                animals.Add(currentAnimal);
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine($"{animal.GetType().Name}");
                Console.WriteLine(animal.AnimalInfo());
                Console.WriteLine(animal.ProduceSound());
            }
        }

        private static bool IsInputGenderValid(string inputGender)
        {
            if (inputGender == "Male" || inputGender == "Female")
            {
                return true;
            }

            return false;
        }
    }
}
