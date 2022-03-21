using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private const int CaloriesPerGram = 2;
        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        private const string flourTypeAndBakingTechniqueExceptionMessage = "Invalid type of dough.";
        private string weightExceptionMessage = $"Dough weight should be in the range [{MinWeight}..{MaxWeight}].";

        private Dictionary<string, double> caloryModifiersByFlourType = new Dictionary<string, double>()
        {
            { "white", 1.5 },
            { "wholegrain", 1.0 }
        };

        private Dictionary<string, double> caloryModifiersByBakingTechnique = new Dictionary<string, double>()
        {
            { "crispy", 0.9 },
            { "chewy", 1.1 },
            { "homemade", 1.0 }
        };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        private string FlourType
        {
            get 
            { 
                return this.flourType; 
            }

            set 
            {
                if (!this.caloryModifiersByFlourType.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(flourTypeAndBakingTechniqueExceptionMessage);
                }

                this.flourType = value; 
            }
        }

        private string BakingTechnique
        {
            get 
            { 
                return this.bakingTechnique; 
            }

            set 
            {
                if (!this.caloryModifiersByBakingTechnique.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException(flourTypeAndBakingTechniqueExceptionMessage);
                }

                this.bakingTechnique = value; 
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
                    throw new ArgumentException(weightExceptionMessage);
                }

                this.weight = value; 
            }
        }

        public double CalculateCalories() => (CaloriesPerGram * this.Weight * caloryModifiersByFlourType[this.FlourType.ToLower()] 
                                               * caloryModifiersByBakingTechnique[this.BakingTechnique.ToLower()]);
    }
}
