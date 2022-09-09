using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        static string inputXml;

        static IMapper mapper;

        static string result;

        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();

            //dbContext.Database.EnsureCreated();

            // // Problem 9:

            //inputXml = File.ReadAllText("Datasets/suppliers.xml");

            //result = ImportSuppliers(dbContext, inputXml);

            // // Problem 10:

            //inputXml = File.ReadAllText("Datasets/parts.xml");

            //result = ImportParts(dbContext, inputXml);

            // // Problem 11:

            //inputXml = File.ReadAllText("Datasets/cars.xml");

            //result = ImportCars(dbContext, inputXml);

            // // Problem 12:

            //inputXml = File.ReadAllText("Datasets/customers.xml");

            //result = ImportCustomers(dbContext, inputXml);

            // // Problem 13:

            //inputXml = File.ReadAllText("Datasets/sales.xml");

            //result = ImportSales(dbContext, inputXml);

            // // Problem 14:

            //result = GetCarsWithDistance(dbContext);

            // // Problem 15:

            //result = GetCarsFromMakeBmw(dbContext);

            // // Problem 16:

            //result = GetLocalSuppliers(dbContext);

            // // Problem 17:

            //result = GetCarsWithTheirListOfParts(dbContext);

            // // Problem 18:

            //result = GetTotalSalesByCustomer(dbContext);

            // // Problem 19:

            //result = GetSalesWithAppliedDiscount(dbContext);

            Console.WriteLine(result);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var saleDtos = context.Sales
                .Select(s => new SaleOutputModel
                {
                    Car = new SaleCarOutputModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price)) 
                                        - (s.Car.PartCars.Sum(pc => pc.Part.Price)) * s.Discount / 100M
                })
                .ToArray();

            string result = XmlConverter.Serialize<SaleOutputModel>(saleDtos, "sales");

            return result;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customerDtos = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new CustomerOutputModel
                {
                    Name = c.Name,
                    BoughtCarsCount = c.Sales.Count,
                    SpentMoney = c.Sales.SelectMany(s => s.Car.PartCars).Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            string result = XmlConverter.Serialize<CustomerOutputModel>(customerDtos, "customers");

            return result;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carDtos = context.Cars
                .Select(c => new CarWithPartsOutputModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(pc => new PartOutputModel
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            string result = XmlConverter.Serialize<CarWithPartsOutputModel>(carDtos, "cars");

            return result;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Include(s => s.Parts)
                .Where(s => !s.IsImporter)
                .ToArray();

            InitializeAutoMapper();

            var supplierDtos = mapper.Map<SupplierOutputModel[]>(suppliers);

            string result = XmlConverter.Serialize<SupplierOutputModel>(supplierDtos, "suppliers");

            return result;
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            InitializeAutoMapper();

            var carDtos = mapper.Map<BMWOutputModel[]>(cars);

            string result = XmlConverter.Serialize<BMWOutputModel>(carDtos, "cars");

            return result;
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            InitializeAutoMapper();

            var carDtos = mapper.Map<CarOutputModel[]>(cars);

            string result = XmlConverter.Serialize<CarOutputModel>(carDtos, "cars");

            return result;
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var carsId = context.Cars.Select(c => c.Id).ToList();

            var saleDtos = XmlConverter.Deserialize<SaleInputModel>(inputXml, "Sales")
                                       .Where(s => carsId.Contains(s.CarId));

            InitializeAutoMapper();

            var sales = mapper.Map<Sale[]>(saleDtos);

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var customerDtos = XmlConverter.Deserialize<CustomerInputModel>(inputXml, "Customers");

            InitializeAutoMapper();

            var customers = mapper.Map<Customer[]>(customerDtos);

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var partsId = context.Parts.Select(p => p.Id).ToList();

            var carDtos = XmlConverter.Deserialize<CarInputModel>(inputXml, "Cars");

            //var cars = new List<Car>();

            //foreach (var carDto in carsDto)
            //{
            //    var car = new Car
            //    {
            //        Make = carDto.Make,
            //        Model = carDto.Model,
            //        TravelledDistance = carDto.TravelledDistance
            //    };

            //    var distinctedPartsId = carDto.Parts.Select(p => p.Id).Distinct();

            //    foreach (var partId in distinctedPartsId)
            //    {
            //        if (partsId.Contains(partId))
            //        {
            //            car.PartCars.Add(new PartCar
            //            {
            //                PartId = partId
            //            });
            //        }
            //    }

            //    cars.Add(car);
            //}

            var cars = carDtos
                .Select(c => new Car
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    PartCars = c.Parts
                                .Select(p => p.Id)
                                .Distinct()
                                .Intersect(partsId)
                                .Select(id => new PartCar
                                {
                                    PartId = id
                                })
                                .ToList()
                })
                .ToList();

            context.Cars.AddRange(cars);

            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var suppliersId = context.Suppliers.Select(s => s.Id).ToList();

            var partDtos = XmlConverter.Deserialize<PartInputModel>(inputXml, "Parts")
                                       .Where(p => suppliersId.Contains(p.SupplierId));

            InitializeAutoMapper();

            var parts = mapper.Map<Part[]>(partDtos);

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var supplierDtos = XmlConverter.Deserialize<SupplierInputModel>(inputXml, "Suppliers");

            InitializeAutoMapper();

            var suppliers = mapper.Map<Supplier[]>(supplierDtos);

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());

            mapper = config.CreateMapper();
        }
    }
}