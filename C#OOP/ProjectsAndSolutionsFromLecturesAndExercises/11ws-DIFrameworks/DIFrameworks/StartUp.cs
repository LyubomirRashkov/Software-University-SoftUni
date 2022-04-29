using CustomDIFramework.Injectors;
using DIFrameworks.Core;
using DIFrameworks.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIFrameworks
{
    public class StartUp
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = DependencyResolverMEDI.GetServiceProvider();
            EngineMEDI engineMEDI = serviceProvider.GetService<EngineMEDI>();
            engineMEDI.Run();



            Injector injector = DependencyInjector.CreateInjector(new DependencyResolverCDIF());

            EngineCDIFField engineCDIFField = injector.Inject<EngineCDIFField>();
            engineCDIFField.Run();

            EngineCDIFConstructor engineCDIFConstructor = injector.Inject<EngineCDIFConstructor>();
            engineCDIFConstructor.Run();
        }
    }
}
