using AutoMapper;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.IO;
using System.Linq;

namespace ProductShop
{
    public class StartUp
    {
        static string inputXml;

        static string result;

        static IMapper mapper;

        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();

            //dbContext.Database.EnsureCreated();

            // // Problem 1:

            //inputXml = File.ReadAllText("Datasets/users.xml");

            //result = ImportUsers(dbContext, inputXml);

            // // Problem 2:

            //inputXml = File.ReadAllText("Datasets/products.xml");

            //result = ImportProducts(dbContext, inputXml);

            // // Problem 3:

            //inputXml = File.ReadAllText("Datasets/categories.xml");

            //result = ImportCategories(dbContext, inputXml);

            // // Problem 4:

            //inputXml = File.ReadAllText("Datasets/categories-products.xml");

            //result = ImportCategoryProducts(dbContext, inputXml);

            // // Problem 5:

            //result = GetProductsInRange(dbContext);

            // // Problem 6:

            //result = GetSoldProducts(dbContext);

            // // Problem 7:

            //result = GetCategoriesByProductsCount(dbContext);

            // // Problem 8:

            //result = GetUsersWithProducts(dbContext);

            Console.WriteLine(result);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var userDtos = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .Include(u => u.ProductsSold)
                .AsEnumerable()
                .Select(u => new UserWithProductsOutputModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductOutputModel
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new UserProductOutputModel
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .Take(10)
                .ToArray();

            var userWithProductsBaseDto = new UserWithProductsBaseOutputModel();

            userWithProductsBaseDto.Count = context.Users
                                                   .Where(u => u.ProductsSold.Count > 0)
                                                   .Count();

            userWithProductsBaseDto.Users = new UserWithProductsOutputModel[userDtos.Count()];

            for (int i = 0; i < userDtos.Length; i++)
            {
                userWithProductsBaseDto.Users[i] = userDtos[i];
            }

            string result = XmlConverter.Serialize<UserWithProductsBaseOutputModel>(userWithProductsBaseDto, "Users");

            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoryDtos = context.Categories
                .Select(c => new CategoryOutputModel
                {
                    Name = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Any()
                                   ? c.CategoryProducts.Average(cp => cp.Product.Price)
                                   : 0,
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(x => x.ProductsCount)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            string result = XmlConverter.Serialize<CategoryOutputModel>(categoryDtos, "Categories");

            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var userDtos = context.Users
                .Where(u => u.ProductsSold.Any())
                .Select(u => new UserOutputModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(p => new UserProductOutputModel
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                     .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            string result = XmlConverter.Serialize<UserOutputModel>(userDtos, "Users");

            return result;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productDtos = context.Products
                .Where(p => p.Price >= 500 & p.Price <= 1000)
                .Select(p => new ProductOutputModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            var result = XmlConverter.Serialize<ProductOutputModel>(productDtos, "Products");

            return result;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoriesId = context.Categories.Select(c => c.Id).ToList();

            var productsId = context.Products.Select(p => p.Id).ToList();

            var categoryProductDtos = XmlConverter.Deserialize<CategoryProductInputModel>(inputXml, "CategoryProducts")
                                                  .Where(cp => categoriesId.Contains(cp.CategoryId) 
                                                               && productsId.Contains(cp.ProductId));

            InitializeAutoMapper();

            var categoriesProducts = mapper.Map<CategoryProduct[]>(categoryProductDtos);

            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoryDtos = XmlConverter.Deserialize<CategoryInputModel>(inputXml, "Categories")
                                           .Where(c => c.Name != null);

            InitializeAutoMapper();

            var categories = mapper.Map<Category[]>(categoryDtos);

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var produstDtos = XmlConverter.Deserialize<ProductInputModel>(inputXml, "Products");

            InitializeAutoMapper();

            var products = mapper.Map<Product[]>(produstDtos);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var userDtos = XmlConverter.Deserialize<UserInputModel>(inputXml, "Users");

            InitializeAutoMapper();

            var users = mapper.Map<User[]>(userDtos);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());

            mapper = config.CreateMapper();
        }
    }
}