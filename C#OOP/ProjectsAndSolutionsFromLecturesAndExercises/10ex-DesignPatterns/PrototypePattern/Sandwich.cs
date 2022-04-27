using System;

namespace PrototypePattern
{
    public class Sandwich : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.Bread = bread;
            this.Meat = meat;
            this.Cheese = cheese;
            this.Veggies = veggies;
        }

        public string Bread 
        {
            get => this.bread;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.bread = "without bread";
                }
                else
                {
                    this.bread = value;
                }
            }
        }

        public string Meat 
        {
            get => this.meat;

            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.meat = "without meat";
                }
                else
                {
                    this.meat = value;
                }
            } 
        }

        public string Cheese 
        {
            get => this.cheese;

            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.cheese = "without cheese";
                }
                else
                {
                    this.cheese = value;
                }
            } 
        }

        public string Veggies 
        {
            get => this.veggies;

            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    this.veggies = "without veggies";
                }
                else
                {
                    this.veggies = value;
                }
            } 
        }

        public override SandwichPrototype Clone()
        {
            string ingredients = GetIngredients();

            Console.WriteLine($"Cloning sandwich with ingredients: {ingredients}");

            return MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngredients() 
        {
            return $"bread - {this.Bread}, meat - {this.Meat}, cheese - {this.Cheese}, veggies - {this.Veggies}";
        }
    }
}
