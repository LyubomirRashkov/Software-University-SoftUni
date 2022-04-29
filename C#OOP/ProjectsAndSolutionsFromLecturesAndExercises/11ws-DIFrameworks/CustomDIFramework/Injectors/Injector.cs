using CustomDIFramework.Attributes;
using CustomDIFramework.Modules;
using System;
using System.Linq;
using System.Reflection;

namespace CustomDIFramework.Injectors
{
    public class Injector
    {
        private readonly IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        public TClass Inject<TClass>()
        {
            bool hasConstructorAttribute = this.CheckForConstructorInjection<TClass>();
            bool hasFieldAttribute = this.CheckForFieldInjection<TClass>();

            if (hasConstructorAttribute && hasFieldAttribute)
            {
                throw new InvalidOperationException("There must be only constructor or field annotated with Inject attribute!");
            }

            if (hasConstructorAttribute)
            {
                return this.CreateConstructorInjection<TClass>();
            }

            if (hasFieldAttribute)
            {
                return this.CreateFieldsInjection<TClass>();
            }

            return default(TClass);
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(f => f.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(c => c.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            Type desireClass = typeof(TClass);

            if (desireClass == null)
            {
                return default(TClass);
            }

            ConstructorInfo[] constructors = desireClass.GetConstructors();

            foreach (ConstructorInfo constructor in constructors)
            {
                if (!CheckForConstructorInjection<TClass>())
                {
                    continue;
                }

                InjectAttribute inject = constructor.GetCustomAttributes(typeof(InjectAttribute), true).FirstOrDefault() as InjectAttribute;

                ParameterInfo[] parameters = constructor.GetParameters();

                object[] constructorParams = new object[parameters.Length];

                int i = 0;

                foreach (ParameterInfo parameter in parameters)
                {
                    Attribute named = parameter.GetCustomAttribute(typeof(NamedAttribute));

                    Type dependency = null;

                    if (named != null)
                    {
                        dependency = this.module.GetMapping(parameter.ParameterType, named);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(parameter.ParameterType, inject);
                    }

                    if (parameter.ParameterType.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstance(dependency);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            this.module.SetInstance(parameter.ParameterType, instance);
                        }

                        constructorParams[i++] = instance;
                    }
                }

                return (TClass)Activator.CreateInstance(desireClass, constructorParams);
            }

            return default(TClass);
        }

        private TClass CreateFieldsInjection<TClass>()
        {
            Type desireClass = typeof(TClass);

            object desireClassInstance = this.module.GetInstance(desireClass);

            if (desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                this.module.SetInstance(desireClass, desireClassInstance);
            }

            FieldInfo[] fields = desireClass.GetFields((BindingFlags)62);

            foreach (FieldInfo field in fields)
            {
                if (field.GetCustomAttributes(typeof(InjectAttribute)).Any())
                {
                    InjectAttribute injection = field.GetCustomAttributes(typeof(InjectAttribute), true).FirstOrDefault() as InjectAttribute;

                    Type dependency = null;

                    Attribute named = field.GetCustomAttribute(typeof(NamedAttribute), true);

                    Type type = field.FieldType;

                    if (named == null)
                    {
                        dependency = this.module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependency = this.module.GetMapping(type, named);
                    }

                    if (type.IsAssignableFrom(dependency))
                    {
                        object instance = this.module.GetInstance(dependency);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependency);
                            this.module.SetInstance(dependency, instance);
                        }

                        field.SetValue(desireClassInstance, instance);
                    }
                }
            }

            return (TClass)desireClassInstance;
        }
    }
}
