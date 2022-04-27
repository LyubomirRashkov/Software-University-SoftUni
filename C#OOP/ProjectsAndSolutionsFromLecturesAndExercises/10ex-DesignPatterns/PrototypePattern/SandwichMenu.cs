using System.Collections.Generic;

namespace PrototypePattern
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches;

        public SandwichMenu()
        {
            sandwiches = new Dictionary<string, SandwichPrototype>();
        }

        public SandwichPrototype this[string name] 
        {
            get => this.sandwiches[name];

            set => this.sandwiches.Add(name, value);
        }
    }
}
