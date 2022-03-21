using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const int MinPizzaNameLength = 1;
        private const int MaxPizzaNameLength = 15;
        private const int MinNumberOfToppings = 0;
        private const int MaxNumberOfToppings = 10;
        private string nameExceptionMessage = $"Pizza name should be between {MinPizzaNameLength} and {MaxPizzaNameLength} symbols.";
        private string toppingExceptionMessage = $"Number of toppings should be in range [{MinNumberOfToppings}..{MaxNumberOfToppings}].";

        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get 
            {
                return this.name; 
            }

            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > MaxPizzaNameLength)
                {
                    throw new ArgumentException(nameExceptionMessage);
                }

                this.name = value; 
            }
        }

        public IReadOnlyCollection<Topping> Toppings => this.toppings.AsReadOnly();

        public Dough Dough
        {
            get 
            { 
                return this.dough; 
            }
            
            set 
            { 
                this.dough = value; 
            }
        }

        public void AddTopping(Topping topping) 
        {
            if (this.Toppings.Count == MaxNumberOfToppings)
            {
                throw new ArgumentException(toppingExceptionMessage);
            }

            this.toppings.Add(topping);
        }

        public double Calories 
        {
            get 
            {
                double calories = 0;
                calories += this.Dough.CalculateCalories();

                foreach (Topping topping in this.Toppings)
                {
                    calories += topping.CalculateCalories();
                }

                return calories;
            }
        }
    }
}
