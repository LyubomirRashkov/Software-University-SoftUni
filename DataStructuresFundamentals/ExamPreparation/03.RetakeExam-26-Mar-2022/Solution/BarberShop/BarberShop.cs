using System;
using System.Collections.Generic;
using System.Linq;

namespace BarberShop
{
	public class BarberShop : IBarberShop
	{
		private readonly Dictionary<string, Barber> barbersByName = new Dictionary<string, Barber>();

		private readonly Dictionary<string, Client> clientsByName = new Dictionary<string, Client>();

		public void AddBarber(Barber b)
		{
			if (this.barbersByName.ContainsKey(b.Name))
			{
				throw new ArgumentException();
			}

			this.barbersByName.Add(b.Name, b);
		}

		public void AddClient(Client c)
		{
			if (this.clientsByName.ContainsKey(c.Name))
			{
				throw new ArgumentException();
			}

			this.clientsByName.Add(c.Name, c);
		}

		public bool Exist(Barber b) => this.barbersByName.ContainsKey(b.Name);

		public bool Exist(Client c) => this.clientsByName.ContainsKey(c.Name);

		public IEnumerable<Barber> GetBarbers() => this.barbersByName.Values;

		public IEnumerable<Client> GetClients() => this.clientsByName.Values;

		public void AssignClient(Barber b, Client c)
		{
			if (!this.barbersByName.ContainsKey(b.Name)
				|| !this.clientsByName.ContainsKey(c.Name))
			{
				throw new ArgumentException();
			}

			this.barbersByName[b.Name].Clients.Add(c);

			this.clientsByName[c.Name].Barber = b;
		}

		public void DeleteAllClientsFrom(Barber b)
		{
			if (!this.barbersByName.ContainsKey(b.Name))
			{
				throw new ArgumentException();
			}

			foreach (var client in b.Clients)
			{
				this.clientsByName.Remove(client.Name);
			}

			this.barbersByName[b.Name].Clients.Clear();
		}

		public IEnumerable<Client> GetClientsWithNoBarber()
			=> this.clientsByName.Values
				.Where(c => c.Barber is null);

		public IEnumerable<Barber> GetAllBarbersSortedWithClientsCountDesc()
			=> this.barbersByName.Values
				.OrderByDescending(b => b.Clients.Count);

		public IEnumerable<Barber> GetAllBarbersSortedWithStarsDecsendingAndHaircutPriceAsc()
			=> this.barbersByName.Values
				.OrderByDescending(b => b.Stars)
				.ThenBy(b => b.HaircutPrice);

		public IEnumerable<Client> GetClientsSortedByAgeDescAndBarbersStarsDesc()
			=> this.clientsByName.Values
				.Where(c => c.Barber != null)
				.OrderByDescending(c => c.Age)
				.ThenByDescending(c => c.Barber.Stars);
	}
}
