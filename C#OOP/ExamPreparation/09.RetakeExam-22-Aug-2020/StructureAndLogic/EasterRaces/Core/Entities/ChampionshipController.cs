using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MinCountOfDrivers = 3;

        private DriverRepository drivers;
        private CarRepository cars;
        private RaceRepository races;

        public ChampionshipController()
        {
            this.drivers = new DriverRepository();
            this.cars = new CarRepository();
            this.races = new RaceRepository();
        }

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            ICar car = this.cars.GetByName(carModel);

            if (car == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.CarNotFound, carModel));
            }

            driver.AddCar(car);

            return String.Format(OutputMessages.CarAdded, driverName, carModel);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            IDriver driver = this.drivers.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            race.AddDriver(driver);

            return String.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.cars.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }

            type += "Car";

            ICar car = this.InstantiatedCar(type, model, horsePower);

            this.cars.Add(car);

            return string.Format(OutputMessages.CarCreated, type, model);
        }

        public string CreateDriver(string driverName)
        {
            if (this.drivers.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            IDriver driver = new Driver(driverName);

            this.drivers.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);
        }

        public string CreateRace(string name, int laps)
        {
            if (this.races.GetByName(name) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }

            IRace race = new Race(name, laps);

            this.races.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            IRace race = this.races.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (race.Drivers.Count < MinCountOfDrivers)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName,  
                                                                                                 MinCountOfDrivers));
            }

            List<IDriver> fastestDrivers = race.Drivers
                                                       .OrderByDescending(d => d.Car.CalculateRacePoints(race.Laps))
                                                       .Take(3)
                                                       .ToList();

            this.races.Remove(race);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format(OutputMessages.DriverFirstPosition, fastestDrivers[0].Name, raceName));
            sb.AppendLine(String.Format(OutputMessages.DriverSecondPosition, fastestDrivers[1].Name, raceName));
            sb.Append(String.Format(OutputMessages.DriverThirdPosition, fastestDrivers[2].Name, raceName));

            return sb.ToString();
        }

        private ICar InstantiatedCar(string type, string model, int horsePower)
        {
            ICar car = null;

            if (type == nameof(MuscleCar))
            {
                car = new MuscleCar(model, horsePower);
            }
            else 
            {
                car = new SportsCar(model, horsePower);
            }

            return car;
        }
    }
}
