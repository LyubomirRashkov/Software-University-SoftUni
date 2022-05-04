using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private IDictionary<string, IPlanet> planetsByName;

        public PlanetRepository()
        {
            this.planetsByName = new Dictionary<string, IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => this.planetsByName.Values.ToList().AsReadOnly();

        public void Add(IPlanet model)
        {
            this.planetsByName.Add(model.Name, model);
        }

        public IPlanet FindByName(string name) => this.planetsByName.First(kvp => kvp.Key == name).Value;

        public bool Remove(IPlanet model) => this.planetsByName.Remove(model.Name);
    }
}
