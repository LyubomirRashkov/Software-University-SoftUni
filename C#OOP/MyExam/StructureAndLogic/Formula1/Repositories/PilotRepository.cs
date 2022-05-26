using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private IDictionary<string, IPilot> pilotsByFullName;

        public PilotRepository()
        {
            this.pilotsByFullName = new Dictionary<string, IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models => this.pilotsByFullName.Values.ToList().AsReadOnly();

        public void Add(IPilot model) => this.pilotsByFullName.Add(model.FullName, model);

        public IPilot FindByName(string name) => this.pilotsByFullName.FirstOrDefault(kvp => kvp.Key == name).Value;

        public bool Remove(IPilot model) => this.pilotsByFullName.Remove(model.FullName);
    }
}
