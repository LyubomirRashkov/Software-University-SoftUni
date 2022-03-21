using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const int CaloriesPerGram = 2;
        private const int MinWeight = 1;
        private const int MaxWeight = 50;

        private Dictionary<string, double> caloryModifiersByType = new Dictionary<string, double>()
        {
            { "meat", 1.2 },
            { "veggies", 0.8 },
            { "cheese", 1.1 },
            { "sauce", 0.9 }
        };

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        private string Type
        {
            get 
            { 
                return this.type; 
            }

            set 
            {
                if (!this.caloryModifiersByType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.type = value; 
            }
        }

        private double Weight
        {
            
            get 
            {
                return this.weight; 
            }

            set 
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value; 
            }
        }

        public double CalculateCalories() => (CaloriesPerGram * this.Weight * caloryModifiersByType[this.Type.ToLower()]);
    }
}
