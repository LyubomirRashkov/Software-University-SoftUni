using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private IDictionary<string, ICar> carsByVINs;

        public CarRepository()
        {
            this.carsByVINs = new Dictionary<string, ICar>();
        }

        public IReadOnlyCollection<ICar> Models => this.carsByVINs.Values.ToList().AsReadOnly();

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }

            this.carsByVINs.Add(model.VIN, model);
        }

        public ICar FindBy(string property) => this.carsByVINs.FirstOrDefault(kvp => kvp.Key == property).Value;

        public bool Remove(ICar model) => this.carsByVINs.Remove(model.VIN);
    }
}
