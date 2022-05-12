using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private IDictionary<string, IBunny> bunniesByName;

        public BunnyRepository()
        {
            this.bunniesByName = new Dictionary<string, IBunny>();
        }

        public IReadOnlyCollection<IBunny> Models => this.bunniesByName.Values.ToList().AsReadOnly();

        public void Add(IBunny model)
        {
            this.bunniesByName.Add(model.Name, model);
        }

        public IBunny FindByName(string name) => this.bunniesByName.FirstOrDefault(kvp => kvp.Key == name).Value;

        public bool Remove(IBunny model) => this.bunniesByName.Remove(model.Name);
    }
}
