using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int MinNameLength = 5;
        private const int MinNumberOfLaps = 1;

        private string name;
        private int laps;
        private IDictionary<string, IDriver> driversByName;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;

            this.driversByName = new Dictionary<string, IDriver>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowExceptionIfParameterIsNullEmptyOrHasLengthLessThanMinimumLength(value, MinNameLength, 
                                                string.Format(ExceptionMessages.InvalidName, value, MinNameLength));

                this.name = value;
            }
        }

        public int Laps
        {
            get => this.laps;
            private set 
            {
                if (value < MinNumberOfLaps)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidNumberOfLaps, MinNumberOfLaps));
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.driversByName.Values.ToList().AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (this.driversByName.ContainsKey(driver.Name))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, 
                                                                                                    this.Name));
            }

            this.driversByName.Add(driver.Name, driver);
        }
    }
}
