using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private const double RequiredOxygen = 60;

        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private IMission mission;
        private int countOfExploredPlanets;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();

            this.mission = new Mission();

            this.countOfExploredPlanets = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type != nameof(Biologist) && type != nameof(Geodesist) && type != nameof(Meteorologist))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            IAstronaut astronaut = this.CreateAstronaut(type, astronautName);

            this.astronauts.Add(astronaut);

            return String.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName, items);

            this.planets.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);

            //Planet planet = new Planet(planetName);

            //foreach (string item in items)
            //{
            //    planet.AddItem(item);
            //}

            //this.planets.Add(planet);

            //return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = this.planets.FindByName(planetName);

            List<IAstronaut> suitableAstronauts = this.astronauts.Models.Where(a => a.Oxygen > RequiredOxygen).ToList();

            if (!suitableAstronauts.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            this.mission.Explore(planet, suitableAstronauts);

            this.countOfExploredPlanets++;

            List<IAstronaut> deadAstronauts = suitableAstronauts.Where(a => a.CanBreath == false).ToList();

            return String.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts.Count);
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronauts.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, 
                                                                                             astronautName));
            }

            this.astronauts.Remove(astronaut);

            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.countOfExploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (IAstronaut astronaut in this.astronauts.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        private IAstronaut CreateAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else
            {
                astronaut = new Meteorologist(astronautName);
            }

            return astronaut;
        }
    }
}
