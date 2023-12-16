using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.PackageManagerLite
{
	public class PackageManager : IPackageManager
	{
		private readonly HashSet<Package> packages;
		private readonly Dictionary<string, Package> packagesById;

		public PackageManager()
		{
			this.packages = new HashSet<Package>();
			this.packagesById = new Dictionary<string, Package>();
		}

		public void RegisterPackage(Package package)
		{
			if (this.packages.Contains(package))
			{
				throw new ArgumentException();
			}

			this.packages.Add(package);

			this.packagesById.Add(package.Id, package);
		}

		public void RemovePackage(string packageId)
		{
			this.ValidatePackageExists(packageId);

			foreach (var packageItem in packages)
			{
				packageItem.DependenciesIds.Remove(packageId);
			}

			var package = this.packagesById[packageId];

			this.packages.Remove(package);

			this.packagesById.Remove(packageId);
		}

		public void AddDependency(string packageId, string dependencyId)
		{
			this.ValidatePackageExists(packageId);

			this.ValidatePackageExists(dependencyId);

			this.packagesById[packageId].DependenciesIds.Add(dependencyId);
		}

		public bool Contains(Package package) => this.packages.Contains(package);

		public int Count() => this.packagesById.Count;

		public IEnumerable<Package> GetDependants(Package package)
		{
			if (!this.packages.Contains(package))
			{
				return Enumerable.Empty<Package>();
			}

			return this.packages
				.Where(p => p.DependenciesIds.Contains(package.Id));
		}

		public IEnumerable<Package> GetIndependentPackages()
			=> this.packages
			   .Where(p => p.DependenciesIds.Count == 0)
			   .OrderByDescending(p => p.ReleaseDate)
			   .ThenBy(p => p.Version);

		public IEnumerable<Package> GetOrderedPackagesByReleaseDateThenByVersion()
		{
			if (this.packages.Count == 0)
			{
				return Enumerable.Empty<Package>();
			}

			var groups = this.packages
				.GroupBy(p => p.Name);

			List<Package> filteredPackages = new List<Package>();

			foreach (var group in groups)
			{
				filteredPackages.Add(group.OrderByDescending(g => g.Version).First());
			}

			return filteredPackages
				.OrderByDescending(p => p.ReleaseDate)
				.ThenBy(p => p.Version);
		}

		private void ValidatePackageExists(string packageId)
		{
			if (!this.packagesById.ContainsKey(packageId))
			{
				throw new ArgumentException();
			}
		}
	}
}
