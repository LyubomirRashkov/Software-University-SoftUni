using CustomDIFramework.Modules;
using DIFrameworks.Interfaces;
using DIFrameworks.Models;

namespace DIFrameworks.Infrastructure
{
    public class DependencyResolverCDIF : AbstractModule
    {
        public override void Configure()
        {
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IWriter, ConsoleWriter>();
            CreateMapping<IWriter, FileWriter>();
        }
    }
}
