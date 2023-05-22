using System;
using System.Collections.Generic;
using System.Linq;

namespace TripAdministrations
{
	public class TripAdministrator : ITripAdministrator
	{
		private readonly Dictionary<string, Company> companiesByName = new Dictionary<string, Company>();

		private readonly Dictionary<string, Trip> tripsById = new Dictionary<string, Trip>();

		public void AddCompany(Company c)
		{
			if (this.companiesByName.ContainsKey(c.Name))
			{
				throw new ArgumentException();
			}

			this.companiesByName.Add(c.Name, c);
		}

		public void AddTrip(Company c, Trip t)
		{
			if (!this.companiesByName.ContainsKey(c.Name)
				|| this.tripsById.ContainsKey(t.Id))
			{
				throw new ArgumentException();
			}

			if (this.companiesByName[c.Name].CurrentTrips >= this.companiesByName[c.Name].TripOrganizationLimit)
			{
				return;
			}

			this.companiesByName[c.Name].Trips.Add(t);

			this.tripsById.Add(t.Id, t);

			this.tripsById[t.Id].Company = c;
		}

		public bool Exist(Company c) => this.companiesByName.ContainsKey(c.Name);

		public bool Exist(Trip t) => this.tripsById.ContainsKey(t.Id);

		public void RemoveCompany(Company c)
		{
			if (!this.companiesByName.ContainsKey(c.Name))
			{
				throw new ArgumentException();
			}

			foreach (var trip in this.companiesByName[c.Name].Trips)
			{
				this.tripsById.Remove(trip.Id);
			}

			this.companiesByName.Remove(c.Name);
		}

		public IEnumerable<Company> GetCompanies() => this.companiesByName.Values;

		public IEnumerable<Trip> GetTrips() => this.tripsById.Values;

		public void ExecuteTrip(Company c, Trip t)
		{
			if (!this.companiesByName.ContainsKey(c.Name)
				|| !this.tripsById.ContainsKey(t.Id)
				|| this.tripsById[t.Id].Company != c)
			{
				throw new ArgumentException();
			}

			this.companiesByName[c.Name].Trips.Remove(t);

			this.tripsById.Remove(t.Id);
		}

		public IEnumerable<Company> GetCompaniesWithMoreThatNTrips(int n)
			=> this.companiesByName.Values
				.Where(c => c.Trips.Count > n);

		public IEnumerable<Trip> GetTripsWithTransportationType(Transportation t)
			=> this.tripsById.Values
				.Where(trip => trip.Transportation == t);

		public IEnumerable<Trip> GetAllTripsInPriceRange(int lo, int hi)
			=> this.tripsById.Values
				.Where(t => t.Price >= lo && t.Price <= hi);
	}
}
