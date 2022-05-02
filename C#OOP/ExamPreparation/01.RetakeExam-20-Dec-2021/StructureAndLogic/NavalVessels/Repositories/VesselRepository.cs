using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private IDictionary<string, IVessel> vesselsByName;

        public VesselRepository()
        {
            this.vesselsByName = new Dictionary<string, IVessel>();
        }

        public IReadOnlyCollection<IVessel> Models => this.vesselsByName.Values.ToList().AsReadOnly();

        public void Add(IVessel model)
        {
            this.vesselsByName.Add(model.Name, model);
        }

        public IVessel FindByName(string name) => this.vesselsByName.FirstOrDefault(kvp => kvp.Key == name).Value;

        public bool Remove(IVessel model) => this.vesselsByName.Remove(model.Name);
    }
}
