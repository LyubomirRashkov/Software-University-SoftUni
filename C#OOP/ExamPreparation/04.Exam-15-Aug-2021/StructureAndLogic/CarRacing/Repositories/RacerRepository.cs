using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private IDictionary<string, IRacer> racersByUsernames;

        public RacerRepository()
        {
            this.racersByUsernames = new Dictionary<string, IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => this.racersByUsernames.Values.ToList().AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }

            this.racersByUsernames.Add(model.Username, model);
        }

        public IRacer FindBy(string property) => this.racersByUsernames.FirstOrDefault(kvp => kvp.Key == property).Value;

        public bool Remove(IRacer model) => this.racersByUsernames.Remove(model.Username);
    }
}
