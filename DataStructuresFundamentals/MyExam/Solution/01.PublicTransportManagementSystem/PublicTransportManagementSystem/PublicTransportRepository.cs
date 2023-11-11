using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportManagementSystem
{
    public class PublicTransportRepository : IPublicTransportRepository
    {
        private readonly HashSet<Passenger> passengers;
        private readonly HashSet<Bus> buses;

        public PublicTransportRepository()
        {
            this.passengers = new HashSet<Passenger>();
            this.buses = new HashSet<Bus>();
        }

        public void RegisterPassenger(Passenger passenger) => this.passengers.Add(passenger);

        public void AddBus(Bus bus) => this.buses.Add(bus);

        public bool Contains(Passenger passenger) => this.passengers.Contains(passenger);

        public bool Contains(Bus bus) => this.buses.Contains(bus);

        public IEnumerable<Bus> GetBuses() => this.buses;

        public void BoardBus(Passenger passenger, Bus bus)
        {
            if (!this.passengers.Contains(passenger) 
                || !this.buses.Contains(bus))
            {
                throw new ArgumentException();
            }

            passenger.Bus = bus;

            bus.Passengers.Add(passenger);
        }

        public void LeaveBus(Passenger passenger, Bus bus)
        {
			if (!this.passengers.Contains(passenger) 
                || !this.buses.Contains(bus)
                || passenger.Bus != bus)
			{
				throw new ArgumentException();
			}

			passenger.Bus = null;

			bus.Passengers.Remove(passenger);
		}

        public IEnumerable<Passenger> GetPassengersOnBus(Bus bus) => bus.Passengers;

        public IEnumerable<Bus> GetBusesOrderedByOccupancy() => this.buses.OrderBy(b => b.Passengers.Count);

        public IEnumerable<Bus> GetBusesWithCapacity(int capacity) => this.buses.Where(b => b.Capacity >= capacity);
    }
}