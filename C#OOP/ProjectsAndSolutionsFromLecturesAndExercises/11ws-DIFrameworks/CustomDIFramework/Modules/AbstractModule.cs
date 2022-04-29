using CustomDIFramework.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDIFramework.Modules
{
    public abstract class AbstractModule : IModule
    {
        private readonly IDictionary<Type, Dictionary<string, Type>> implementations;
        private readonly IDictionary<Type, object> instances;

        public AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
            {
                this.instances.Add(implementation, instance);
            }
        }

        public object GetInstance(Type implementation)
        {
            this.instances.TryGetValue(implementation, out object value);

            return value;
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            Type result = null;

            if (this.implementations.ContainsKey(currentInterface))
            {
                Dictionary<string, Type> currentImplementations = this.implementations[currentInterface];

                if (currentImplementations == null || !currentImplementations.Any())
                {
                    throw new ArgumentException($"No available implementations for type {currentInterface.FullName}!");
                }

                if (attribute is InjectAttribute)
                {
                    result = currentImplementations.Values.FirstOrDefault();
                }
                else if (attribute is NamedAttribute)
                {
                    NamedAttribute named = attribute as NamedAttribute;

                    result = currentImplementations[named.Name];
                }
            }
            else
            {
                throw new ArgumentException($"No available implementations for type {currentInterface.FullName}!");
            }

            return result;
        }

        protected void CreateMapping<TInterface, TImplementation>()
        {
            Type interfaceType = typeof(TInterface);
            Type implementationType = typeof(TImplementation);

            if (!this.implementations.ContainsKey(interfaceType))
            {
                this.implementations.Add(interfaceType, new Dictionary<string, Type>());
            }

            this.implementations[interfaceType].Add(implementationType.Name, implementationType);
        }

        public abstract void Configure();
    }
}
