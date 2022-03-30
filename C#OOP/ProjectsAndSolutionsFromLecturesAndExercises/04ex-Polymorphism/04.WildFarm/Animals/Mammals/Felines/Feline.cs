using System.Collections.Generic;

namespace _04.WildFarm.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, 
                        double weight, 
                        HashSet<string> allowedFoods,   
                        string livingRegion, 
                        string breed, 
                        double weightModifier) 

            : base(name, weight, allowedFoods, livingRegion, weightModifier)
        {
            this.Breed = breed;
        }

        public string Breed  { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEatenQuantity}]";
        }
    }
}
