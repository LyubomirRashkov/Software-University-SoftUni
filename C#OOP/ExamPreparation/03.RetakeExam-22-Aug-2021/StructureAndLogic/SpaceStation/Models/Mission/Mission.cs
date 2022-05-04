using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            List<string> itemsForPicking = planet.Items.ToList();

            foreach (IAstronaut astronaut in astronauts)
            {
                if (!astronaut.CanBreath)
                {
                    continue;
                }

                for (int i = 0; i < itemsForPicking.Count; i++)
                {
                    astronaut.Breath();
                    astronaut.Bag.Items.Add(itemsForPicking[i]);
                    itemsForPicking.RemoveAt(i);
                    i--;

                    if (!astronaut.CanBreath)
                    {
                        break;
                    }
                }
            }
        }
    }
}
