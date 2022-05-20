using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : Repository<IDriver>
    {
        public override void Add(IDriver model)
        {
            this.entities.Add(model.Name, model);
        }

        public override bool Remove(IDriver model) => this.entities.Remove(model.Name);
    }
}
