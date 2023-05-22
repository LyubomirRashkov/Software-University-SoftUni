﻿using System.Collections.Generic;

namespace BarberShop
{
	public class Barber
	{
		public Barber(string name, int haircutPrice, int stars)
		{
			this.Name = name;
			this.HaircutPrice = haircutPrice;
			this.Stars = stars;

			this.Clients = new List<Client>();
		}

		public string Name { get; set; }

		public int HaircutPrice { get; set; }

		public int Stars { get; set; }

		public List<Client> Clients { get; set; }
	}
}
