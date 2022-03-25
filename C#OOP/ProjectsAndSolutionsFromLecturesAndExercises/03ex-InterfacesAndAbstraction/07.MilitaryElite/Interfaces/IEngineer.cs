using System.Collections.Generic;

namespace _07.MilitaryElite.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
         
        void AddRepair(IRepair repair);
    }
}
