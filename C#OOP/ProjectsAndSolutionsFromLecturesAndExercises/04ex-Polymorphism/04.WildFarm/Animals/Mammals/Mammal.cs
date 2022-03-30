using System.Collections.Generic;

namespace _04.WildFarm.Animals.Mammals
{
    public abstract class Mammal : Animal
    {
        protected Mammal(string name, double weight, HashSet<string> allowedFoods, string livingRegion, double weightModifier) 
            : base(name, weight, allowedFoods, weightModifier)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEatenQuantity}]";
        }
    }
}
