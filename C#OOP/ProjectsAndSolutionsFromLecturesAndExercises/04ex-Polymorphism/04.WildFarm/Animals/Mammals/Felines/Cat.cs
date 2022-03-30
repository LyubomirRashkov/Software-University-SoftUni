﻿using _04.WildFarm.Foods;
using System.Collections.Generic;

namespace _04.WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double WeightModifier = 0.3;

        private static HashSet<string> allowedFoods = new HashSet<string> 
        {
            nameof(Vegetable),
            nameof(Meat)
        };

        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, allowedFoods, livingRegion, breed, WeightModifier)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
