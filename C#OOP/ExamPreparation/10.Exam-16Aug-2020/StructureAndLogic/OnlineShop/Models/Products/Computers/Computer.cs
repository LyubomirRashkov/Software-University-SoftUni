using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Any())
                {
                    return (base.OverallPerformance + this.Components.Average(c => c.OverallPerformance));
                }
                else
                {
                    return base.OverallPerformance;
                }
            }
        }

        public override decimal Price
        {
            get
            {
                if (this.Components.Any() && this.Peripherals.Any())
                {
                    return (base.Price + this.Components.Sum(c => c.Price) + this.Peripherals.Sum(p => p.Price));
                }
                else if (this.Components.Any())
                {
                    return (base.Price + this.Components.Sum(c => c.Price));
                }
                else if (this.Peripherals.Any())
                {
                    return (base.Price + this.Peripherals.Sum(p => p.Price));
                }
                else
                {
                    return base.Price;
                }
            }
        }

        public void AddComponent(IComponent component)
        {
            string componentType = component.GetType().Name;

            IComponent containedComponent = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (containedComponent != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            string peripheralType = peripheral.GetType().Name;

            IPeripheral containedPeripheral = this.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (containedPeripheral != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent component = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            this.components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral peripheral = this.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" Components ({this.Components.Count}):");

            if (this.Components.Any())
            {
                foreach (IComponent component in this.Components)
                {
                    sb.AppendLine($"  {component}");
                }
            }

            if (this.Peripherals.Any())
            {
                sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({this.Peripherals.Average(p => p.OverallPerformance):F2}):");

                foreach (IPeripheral peripheral in this.Peripherals)
                {
                    sb.AppendLine($"  {peripheral}");
                }
            }
            else
            {
                sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance (0.00):");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
