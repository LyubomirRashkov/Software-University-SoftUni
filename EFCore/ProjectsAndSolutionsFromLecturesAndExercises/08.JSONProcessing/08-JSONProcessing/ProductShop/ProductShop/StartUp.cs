using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTO;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;

        static string inputJson;

        static string result;

        public static void Main(string[] args)
        {
            var dbContext = new ProductShopContext();

            //dbContext.Database.EnsureCreated();

            // // Problem 1:

            //inputJson = File.ReadAllText("../../../Datasets/users.json");

            //result = ImportUsers(dbContext, inputJson);

            // // Problem 2:

            //inputJson = File.ReadAllText("../../../Datasets/products.json");

            //result = ImportProducts(dbContext, inputJson);

            // // Problem 3:

            //inputJson = File.ReadAllText("../../../Datasets/categories.json");

            //result = ImportCategories(dbContext, inputJson);

            // // Problem 4:

            //inputJson = File.ReadAllText("../../../Datasets/categories-products.json");

            //result = ImportCategoryProducts(dbContext, inputJson);

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
            var filteredUsers = context.Users
                .Include(u => u.ProductsSold)
                .ToList()
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                            .Where(p => p.BuyerId != null)
                            .Count(),
                        products = u.ProductsSold
                            .Where(p => p.BuyerId != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            })
                            .ToList()
                    }
                })
                .OrderByDescending(x => x.soldProducts.count)
                .ToList();

            var output = new
            {
                usersCount = filteredUsers.Count,
                users = filteredUsers
            };

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(output, jsonSettings);

            return json;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Count == 0
                                   ? 0.ToString("F2")
                                   : (c.CategoryProducts.Sum(cp => cp.Product.Price) / c.CategoryProducts.Count).ToString("F2"),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("F2")
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(p => new
                        {
                            name = p.Name,
                            price = p.Price,
                            buyerFirstName = p.Buyer.FirstName,
                            buyerLastName = p.Buyer.LastName
                        })
                        .ToList()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(x => x.price)
                .ToList();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);

            return json;
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProductsDto = JsonConvert.DeserializeObject<IEnumerable<CategoryProductDto>>(inputJson);

            InitializeAutoMapper();

            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoriesProductsDto);

            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categoriesDto = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson);

            InitializeAutoMapper();

            var categories = mapper.Map<IEnumerable<Category>>(categoriesDto).Where(cDto => cDto.Name != null);

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var productsDto = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            InitializeAutoMapper();

            var products = mapper.Map<IEnumerable<Product>>(productsDto);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var usersDto = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            InitializeAutoMapper();

            var users = mapper.Map<IEnumerable<User>>(usersDto);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());

            mapper = config.CreateMapper();
        }
    }
}