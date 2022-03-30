using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;

namespace _04.WildFarm.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, HashSet<string> allowedFoods, double weightModifier)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEatenQuantity = 0;
            this.AllowedFoods = allowedFoods;
            this.WeightModifier = weightModifier;
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEatenQuantity { get; private set; }

        private HashSet<string> AllowedFoods { get; set; }

        public double WeightModifier { get; private set; }

        public abstract string ProduceSound();

        public void Eat(Food food) 
        {
            string foodName = food.GetType().Name;

            if (!this.AllowedFoods.Contains(foodName))
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {foodName}!");
            }
            else
            {
                this.FoodEatenQuantity += food.Quantity;

                this.Weight += food.Quantity * this.WeightModifier;
            }
        }
    }
}
