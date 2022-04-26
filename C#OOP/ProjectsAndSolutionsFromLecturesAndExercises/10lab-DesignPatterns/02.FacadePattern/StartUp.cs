using System;

namespace _02.FacadePattern
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new CarBuilderFacade()
                            .CarInfo
                                .WithType("BMW")
                                .WithColor("Black")
                                .WithNumberOfDoors(5)
                            .CarAddressBuilder
                                .InCity("Leipzig")
                                .AtAddress("some address")
                            .Build();

            Console.WriteLine(car);
        }
    }
}
