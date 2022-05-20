using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected IDictionary<string, T> entities;

        protected Repository()
        {
            this.entities = new Dictionary<string, T>();
        }

        public IReadOnlyCollection<T> GetAll() => this.entities.Values.ToList().AsReadOnly();

        public T GetByName(string name) => this.entities.FirstOrDefault(kvp => kvp.Key == name).Value;

        public abstract void Add(T model);

        public abstract bool Remove(T model);
    }
}
