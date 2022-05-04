using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private IDictionary<string, IAstronaut> astronautsByName;

        public AstronautRepository()
        {
            this.astronautsByName = new Dictionary<string, IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => this.astronautsByName.Values.ToList().AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.astronautsByName.Add(model.Name, model);
        }

        public IAstronaut FindByName(string name) => this.astronautsByName.FirstOrDefault(kvp => kvp.Key == name).Value;

        public bool Remove(IAstronaut model) => this.astronautsByName.Remove(model.Name);
    }
}
