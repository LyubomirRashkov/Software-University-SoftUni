using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private IDictionary<string, IFormulaOneCar> carsByModel;

        public FormulaOneCarRepository()
        {
            this.carsByModel = new Dictionary<string, IFormulaOneCar>();
        }

        public IReadOnlyCollection<IFormulaOneCar> Models => this.carsByModel.Values.ToList().AsReadOnly();

        public void Add(IFormulaOneCar model) => this.carsByModel.Add(model.Model, model);

        public IFormulaOneCar FindByName(string name) => this.carsByModel.FirstOrDefault(kvp => kvp.Key == name).Value;

        public bool Remove(IFormulaOneCar model) => this.carsByModel.Remove(model.Model);
    }
}
