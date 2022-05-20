using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : Repository<IRace>
    {
        public override void Add(IRace model)
        {
            this.entities.Add(model.Name, model);
        }

        public override bool Remove(IRace model) => this.entities.Remove(model.Name);
    }
}
