namespace SpaceStation.Models.Mission.Contracts
{
    using System.Collections.Generic;

    using Astronauts.Contracts;
    using Planets;
    using Planets.Contracts;

    public interface IMission
    {
        void Explore(Planets.Contracts.IPlanet planet, ICollection<IAstronaut> astronauts);
    }
}
