using DIFrameworks.Core;
using DIFrameworks.Interfaces;
using DIFrameworks.Models;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIFrameworks.Infrastructure
{
    public static class DependencyResolverMEDI
    {
        public static IServiceProvider GetServiceProvider()
        {
            ServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection
                .AddTransient<IReader, ConsoleReader>()
                .AddTransient<IConsoleWriter, ConsoleWriter>()
                .AddTransient<IFileWriter, FileWriter>()
                .AddTransient<EngineMEDI>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
