using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private readonly Dictionary<string, Deliverer> deliverersById = new Dictionary<string, Deliverer>();

        private readonly Dictionary<string, Package> packagesById = new Dictionary<string, Package>();

        public void AddDeliverer(Deliverer deliverer)
        {
            if (!this.deliverersById.ContainsKey(deliverer.Id))
            {
                this.deliverersById.Add(deliverer.Id, deliverer);
            }
        }

        public void AddPackage(Package package)
        {
            if (!this.packagesById.ContainsKey(package.Id))
            {
                this.packagesById.Add(package.Id, package);
            }
        }

        public bool Contains(Deliverer deliverer) => this.deliverersById.ContainsKey(deliverer.Id);

        public bool Contains(Package package) => this.packagesById.ContainsKey(package.Id);

        public IEnumerable<Deliverer> GetDeliverers() => this.deliverersById.Values;

        public IEnumerable<Package> GetPackages() => this.packagesById.Values;

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            if (!this.deliverersById.ContainsKey(deliverer.Id)
                || !this.packagesById.ContainsKey(package.Id))
            {
                throw new ArgumentException();
            }

            this.deliverersById[deliverer.Id].Packages.Add(package);

            this.packagesById[package.Id].Deliverer = deliverer;
        }

        public IEnumerable<Package> GetUnassignedPackages() => this.packagesById.Values.Where(p => p.Deliverer is null);

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
            => this.packagesById.Values
                .OrderByDescending(p => p.Weight)
                .ThenBy(p => p.Receiver);

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
            => this.deliverersById.Values
                .OrderByDescending(d => d.Packages.Count)
                .ThenBy(d => d.Name);
    }
}
