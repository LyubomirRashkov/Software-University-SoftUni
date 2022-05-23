using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly IDictionary<int, IComputer> computersById;
        private readonly IDictionary<int, IComponent> componentsById;
        private readonly IDictionary<int, IPeripheral> peripheralsById;

        public Controller()
        {
            this.computersById = new Dictionary<int, IComputer>();
            this.componentsById = new Dictionary<int, IComponent>();
            this.peripheralsById = new Dictionary<int, IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (this.componentsById.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            if (!Enum.TryParse(componentType, out ComponentType realComponentType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            if (!this.computersById.ContainsKey(computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComponent component = this.CreateComponent(id, componentType, manufacturer, model, price, overallPerformance, generation);

            this.computersById[computerId].AddComponent(component);
            this.componentsById.Add(id, component);

            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computersById.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (!Enum.TryParse(computerType, out ComputerType realComputerType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            IComputer computer = this.CreateComputer(computerType, id, manufacturer, model, price);

            this.computersById.Add(id, computer);

            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (this.peripheralsById.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            if (!Enum.TryParse(peripheralType, out PeripheralType realPeripheralType))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            if (!this.computersById.ContainsKey(computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IPeripheral peripheral = this.CreatePeripheral(id, peripheralType, manufacturer, model, price, overallPerformance, connectionType);

            this.computersById[computerId].AddPeripheral(peripheral);
            this.peripheralsById.Add(id, peripheral);

            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            IComputer bestComputer = this.computersById.Values.Where(c => c.Price <= budget)
                                                              .OrderByDescending(c => c.OverallPerformance)
                                                              .FirstOrDefault();

            if (bestComputer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            foreach (IComponent component in bestComputer.Components)
            {
                this.componentsById.Remove(component.Id);
            }

            foreach (IPeripheral peripheral in bestComputer.Peripherals)
            {
                this.peripheralsById.Remove(peripheral.Id);
            }

            this.computersById.Remove(bestComputer.Id);

            string result = bestComputer.ToString();

            return result;
        }

        public string BuyComputer(int id)
        {
            if (!this.computersById.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComputer computer = this.computersById[id];

            foreach (IComponent component in computer.Components)
            {
                this.componentsById.Remove(component.Id);
            }

            foreach (IPeripheral peripheral in computer.Peripherals)
            {
                this.peripheralsById.Remove(peripheral.Id);
            }

            this.computersById.Remove(id);

            string result = computer.ToString();

            return result;
        }

        public string GetComputerData(int id)
        {
            if (!this.computersById.ContainsKey(id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return this.computersById[id].ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!this.computersById.ContainsKey(computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IComponent component = this.computersById[computerId].RemoveComponent(componentType);

            this.componentsById.Remove(component.Id);

            return String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!this.computersById.ContainsKey(computerId))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            IPeripheral peripheral = this.computersById[computerId].RemovePeripheral(peripheralType);

            this.peripheralsById.Remove(peripheral.Id);

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        private IComputer CreateComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = null;

            if (computerType == nameof(DesktopComputer))
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else
            {
                computer = new Laptop(id, manufacturer, model, price);
            }

            return computer;
        }

        private IComponent CreateComponent(int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComponent component = null;

            if (componentType == nameof(CentralProcessingUnit))
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(Motherboard))
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(PowerSupply))
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(RandomAccessMemory))
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(SolidStateDrive))
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }

            return component;
        }

        private IPeripheral CreatePeripheral(int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheral = null;

            if (peripheralType == nameof(Headset))
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Keyboard))
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Monitor))
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }

            return peripheral;
        }
    }
}
