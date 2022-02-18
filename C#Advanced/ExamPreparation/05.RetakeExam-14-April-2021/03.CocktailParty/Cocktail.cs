using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new Dictionary<string, Ingredient>();
            this.CurrentAlcoholLevel = 0;
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int MaxAlcoholLevel { get; private set; }

        public Dictionary<string, Ingredient> Ingredients { get; private set; }

        public int CurrentAlcoholLevel { get; private set; }

        public void Add(Ingredient ingredient)
        {
            if (!this.Ingredients.ContainsKey(ingredient.Name)
                && this.Ingredients.Count < this.Capacity
                && (this.CurrentAlcoholLevel + ingredient.Alcohol) <= this.MaxAlcoholLevel)
            {
                this.Ingredients.Add(ingredient.Name, ingredient);

                this.CurrentAlcoholLevel += ingredient.Alcohol;
            }
        }

        public bool Remove(string name)
        {
            if (this.Ingredients.ContainsKey(name))
            {
                Ingredient ingredient = this.Ingredients[name];

                this.CurrentAlcoholLevel -= ingredient.Alcohol;

                this.Ingredients.Remove(name);

                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name) => this.Ingredients.FirstOrDefault(kvp => kvp.Key == name).Value;

        public Ingredient GetMostAlcoholicIngredient() => this.Ingredients.OrderByDescending(kvp => kvp.Value.Alcohol).First().Value;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var kvp in this.Ingredients)
            {
                sb.AppendLine(kvp.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
