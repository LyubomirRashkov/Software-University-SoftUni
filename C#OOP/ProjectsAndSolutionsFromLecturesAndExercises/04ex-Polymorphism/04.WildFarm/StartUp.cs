using _04.WildFarm.Animals;
using _04.WildFarm.Animals.Birds;
using _04.WildFarm.Animals.Mammals;
using _04.WildFarm.Animals.Mammals.Felines;
using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class StartUp
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "End")
                {
                    break;
                }

                Animal animal = CreateAnimal(inputLine);
                animals.Add(animal);

                string inputFood = Console.ReadLine();

                Food food = CreateFood(inputFood);

                Console.WriteLine(animal.ProduceSound());

                animal.Eat(food);
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private static Food CreateFood(string inputFood)
        {
            Food food = null;

            string[] foodInfo = inputFood.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string type = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            if (type == nameof(Vegetable))
            {
                food = new Vegetable(quantity);
            }
            else if (type == nameof(Fruit))
            {
                food = new Fruit(quantity);
            }
            else if (type == nameof(Meat))
            {
                food = new Meat(quantity);
            }
            else if (type == nameof(Seeds))
            {
                food = new Seeds(quantity);
            }

            return food;
        }

        private static Animal CreateAnimal(string inputLine)
        {
            Animal animal = null;

            string[] animalInfo = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            if (type == nameof(Cat))
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];

                animal = new Cat(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Tiger))
            {
                string livingRegion = animalInfo[3];
                string breed = animalInfo[4];

                animal = new Tiger(name, weight, livingRegion, breed);
            }
            else if (type == nameof(Owl))
            {
                double wingSize = double.Parse(animalInfo[3]);

                animal = new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Hen))
            {
                double wingSize = double.Parse(animalInfo[3]);

                animal = new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                string livingRegion = animalInfo[3];

                animal = new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                string livingRegion = animalInfo[3];

                animal = new Dog(name, weight, livingRegion);
            }

            return animal;
        }
    }
}
