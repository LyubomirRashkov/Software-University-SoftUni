using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            this.Name = name;
            this.Alcohol = alcohol;
            this.Quantity = quantity;
        }

        public string Name { get; private set; }

        public int Alcohol { get; private set; }

        public int Quantity { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Ingredient: {this.Name}");
            sb.AppendLine($"Quantity: {this.Quantity}");
            sb.Append($"Alcohol: {this.Alcohol}");

            return sb.ToString();
        }
    }
}
