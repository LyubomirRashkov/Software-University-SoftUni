using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        public override void Add(ICar model)
        {
            this.entities.Add(model.Model, model);
        }

        public override bool Remove(ICar model) => this.entities.Remove(model.Model);
    }
}
