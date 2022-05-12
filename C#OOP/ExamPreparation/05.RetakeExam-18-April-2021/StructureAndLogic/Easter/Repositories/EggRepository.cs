using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private IDictionary<string, IEgg> eggsByName;

        public EggRepository()
        {
            this.eggsByName = new Dictionary<string, IEgg>();
        }

        public IReadOnlyCollection<IEgg> Models => this.eggsByName.Values.ToList().AsReadOnly();

        public void Add(IEgg model)
        {
            this.eggsByName.Add(model.Name, model);
        }

        public IEgg FindByName(string name) => this.eggsByName.FirstOrDefault(kvp => kvp.Key == name).Value;

        public bool Remove(IEgg model) => this.eggsByName.Remove(model.Name);
    }
}
