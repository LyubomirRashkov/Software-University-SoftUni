using CustomDIFramework.Modules;

namespace CustomDIFramework.Injectors
{
    public class DependencyInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();

            return new Injector(module);
        }
    }
}
