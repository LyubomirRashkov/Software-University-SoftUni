using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private IDictionary<string, IRace> racesByName;

        public RaceRepository()
        {
            this.racesByName = new Dictionary<string, IRace>();
        }

        public IReadOnlyCollection<IRace> Models => this.racesByName.Values.ToList().AsReadOnly();

        public void Add(IRace model) => this.racesByName.Add(model.RaceName, model);

        public IRace FindByName(string name) => this.racesByName.FirstOrDefault(kvp => kvp.Key == name).Value;

        public bool Remove(IRace model) => this.racesByName.Remove(model.RaceName);
    }
}
