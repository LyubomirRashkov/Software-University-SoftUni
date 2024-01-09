using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MobileX
{
	public class VehicleRepository : IVehicleRepository
    {
        private readonly Dictionary<string, HashSet<Vehicle>> vehiclesBySeller;

        private readonly Dictionary<string, Vehicle> vehiclesById;

        public VehicleRepository()
        {
            this.vehiclesBySeller = new Dictionary<string, HashSet<Vehicle>>();
            this.vehiclesById = new Dictionary<string, Vehicle>();
        }

        public void AddVehicleForSale(Vehicle vehicle, string sellerName)
        {
            if (!this.vehiclesBySeller.ContainsKey(sellerName))
            {
                this.vehiclesBySeller.Add(sellerName, new HashSet<Vehicle>());
            }

            vehicle.Seller = sellerName;

            this.vehiclesBySeller[sellerName].Add(vehicle);

            this.vehiclesById.Add(vehicle.Id, vehicle);
        }

        public bool Contains(Vehicle vehicle) => this.vehiclesById.ContainsKey(vehicle.Id);

        public int Count => this.vehiclesById.Count;

        public IEnumerable<Vehicle> GetVehicles(List<string> keywords)
            => this.vehiclesById.Values
               .Where(v => keywords.Contains(v.Brand)
                           || keywords.Contains(v.Model)
                           || keywords.Contains(v.Location)
                           || keywords.Contains(v.Color))
               .OrderByDescending(v => v.IsVIP)
               .ThenBy(v => v.Price);

        public IEnumerable<Vehicle> GetVehiclesBySeller(string sellerName)
        {
            if (!this.vehiclesBySeller.ContainsKey(sellerName))
            {
                throw new ArgumentException();
            }

            return this.vehiclesBySeller[sellerName];
        }

        public IEnumerable<Vehicle> GetVehiclesInPriceRange(double lowerBound, double upperBound)
            => this.vehiclesById.Values
               .Where(v => v.Price >= lowerBound && v.Price <= upperBound)
               .OrderByDescending(v => v.Horsepower);

        public Dictionary<string, List<Vehicle>> GetAllVehiclesGroupedByBrand()
        {
            if (this.Count == 0)
            {
                throw new ArgumentException();
            }

            return this.vehiclesById.Values
                   .GroupBy(v => v.Brand)
                   .ToDictionary(key => key.Key, value => value.OrderBy(v => v.Price).ToList());
        }

        public void RemoveVehicle(string vehicleId)
        {
            if (!this.vehiclesById.ContainsKey(vehicleId))
            {
                throw new ArgumentException();
            }

            Vehicle vehicle = this.vehiclesById[vehicleId];

            this.vehiclesBySeller[vehicle.Seller].Remove(vehicle);

            this.vehiclesById.Remove(vehicleId);
        }

        public IEnumerable<Vehicle> GetAllVehiclesOrderedByHorsepowerDescendingThenByPriceThenBySellerName()
            => this.vehiclesById.Values
               .OrderByDescending(v => v.Horsepower)
               .ThenBy(v => v.Price)
               .ThenBy(v => v.Seller);

        public Vehicle BuyCheapestFromSeller(string sellerName)
        {
            if (!this.vehiclesBySeller.ContainsKey(sellerName) || this.vehiclesBySeller.Count == 0)
            {
                throw new ArgumentException();
            }

            Vehicle vehicle = this.vehiclesBySeller[sellerName].OrderBy(v => v.Price).First();

            this.vehiclesBySeller[sellerName].Remove(vehicle);

            this.vehiclesById.Remove(vehicle.Id);

            return vehicle;
        }
    }
}
