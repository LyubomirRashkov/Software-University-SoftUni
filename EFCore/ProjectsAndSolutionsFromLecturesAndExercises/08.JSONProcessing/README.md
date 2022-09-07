## PROBLEMS DESCRIPTION - JSON PROCESSING


### Products Shop Database

A products shop holds users, products and categories for the products. Users can sell and buy products.

  +	Users have an id, first name (optional) and last name (at least 3 characters) and age (optional).
  +	Products have an id, name (at least 3 characters), price, buyerId (optional) and sellerId as IDs of users.
  +	Categories have an id and name (from 3 to 15 characters)

Using Entity Framework Code First create a database following the above description.

![изображение](https://user-images.githubusercontent.com/82647282/183106360-26b85f60-c383-4446-8a6b-a087f2314671.png)

  +	Users should have many products sold and many products bought. 
  +	Products should have many categories
  +	Categories should have many products
  +	CategoryProducts should map products and categories

### Section I: Import Data

#### Problem 1.	Import Users

NOTE: You will need method public static string ImportUsers(ProductShopContext context, string inputJson) and public StartUp class. 

Import the users from the provided file users.json.

Your method should return string with message $"Successfully imported {Users.Count}";

#### Problem 2.	Import Products

NOTE: You will need method public static string ImportProducts(ProductShopContext context, string inputJson) and public StartUp class. 

Import the users from the provided file products.json.

Your method should return string with message $"Successfully imported {Products.Count}";

#### Problem 3.	Import Categories

NOTE: You will need method public static string ImportCategories(ProductShopContext context, string inputJson) and public StartUp class. 

Import the users from the provided file categories.json. Some of the names will be null, so you don’t have to add them in the database. Just skip the record and continue.

Your method should return string with message $"Successfully imported {Categories.Count}";

#### Problem 4.	Import Categories and Products

NOTE: You will need method public static string ImportCategoryProducts(ProductShopContext context, string inputJson) and public StartUp class. 

Import the users from the provided file categories-products.json. 

Your method should return string with message $"Successfully imported {CategoryProducts.Count}";

### Section II: Export Data

Write the below described queries and export the returned data to the specified format. Make sure that Entity Framework generates only a single query for each task.

#### Problem 5.	Export Products in Range

NOTE: You will need method public static string GetProductsInRange(ProductShopContext context) and public StartUp class. 

Get all products in a specified price range:  500 to 1000 (inclusive). Order them by price (from lowest to highest). Select only the product name, price and the full name of the seller. Export the result to JSON.

![1](https://user-images.githubusercontent.com/82647282/183107258-3ee9fd2c-ba2b-4a33-a59a-d329531df67d.png)

#### Problem 6.	Export Successfully Sold Products

NOTE: You will need method public static string GetSoldProducts(ProductShopContext context) and public StartUp class. 

Get all users who have at least 1 sold item with a buyer. Order them by last name, then by first name. Select the person's first and last name. For each of the sold products (products with buyers), select the product's name, price and the buyer's first and last name.

![2](https://user-images.githubusercontent.com/82647282/183107404-1f23d6e3-a3c0-45dc-8ecf-222cd79cae14.png)

#### Problem 7.	Export Categories by Products Count

NOTE: You will need method public static string GetCategoriesByProductsCount(ProductShopContext context) and public StartUp class. 

Get all categories. Order them in descending order by the category’s products count. For each category select its name, the number of products, the average price of those products (rounded to second digit after the decimal separator) and the total revenue (total price sum and rounded to second digit after the decimal separator) of those products (regardless if they have a buyer or not).

![3](https://user-images.githubusercontent.com/82647282/183107572-3c5522ec-6424-441e-bb4c-a19314323044.png)

#### Problem 8.	Export Users and Products

NOTE: You will need method public static string GetUsersWithProducts(ProductShopContext context) and public StartUp class. 

Get all users who have at least 1 sold product with a buyer. Order them in descending order by the number of sold products with a buyer. Select only their first and last name, age and for each product - name and price. Ignore all null values.

Export the results to JSON. Follow the format below to better understand how to structure your data. 

![4](https://user-images.githubusercontent.com/82647282/183107743-9d2b133d-48bb-4a42-8259-37e4e2f0e993.png)

### Car Dealer Database 

A car dealer needs information about cars, their parts, parts suppliers, customers and sales. 

  +	Cars have make, model, travelled distance in kilometers
  +	Parts have name, price and quantity
  +	Part supplier have name and info whether he uses imported parts
  +	Customer has name, date of birth and info whether he is young driver (Young driver is a driver that has less than 2 years of experience. Those customers get additional 5% off for the sale.)
  +	Sale has car, customer and discount percentage

A price of a car is formed by total price of its parts.

![изображение](https://user-images.githubusercontent.com/82647282/183107935-126a991e-96fa-449c-9b47-72d97838c88e.png)

  +	A car has many parts and one part can be placed in many cars
  +	One supplier can supply many parts and each part can be delivered by only one supplier
  +	In one sale, only one car can be sold
  +	Each sale has one customer and a customer can buy many cars

### Section I: Import Data

Import data from the provided files (suppliers.json, parts.json, cars.json, customers.json)

#### Problem 9.	Import Suppliers

NOTE: You will need method public static string ImportSuppliers(CarDealerContext context, string inputJson) and public StartUp class. 

Import the suppliers from the provided file suppliers.json. 

Your method should return string with message $"Successfully imported {Suppliers.Count}.";

#### Problem 10.	Import Parts

NOTE: You will need method public static string ImportParts(CarDealerContext context, string inputJson) and public StartUp class. 

Import the parts from the provided file parts.json. If the supplierId doesn’t exists, skip the record.

Your method should return string with message $"Successfully imported {Parts.Count}.";

#### Problem 11.	Import Cars

NOTE: You will need method public static string ImportCars(CarDealerContext context, string inputJson) and public StartUp class. 

Import the cars from the provided file cars.json.

Your method should return string with message $"Successfully imported {Cars.Count}.";

#### Problem 12.	Import Customers

NOTE: You will need method public static string ImportCustomers(CarDealerContext context, string inputJson) and public StartUp class. 

Import the customers from the provided file customers.json.

Your method should return string with message $"Successfully imported {Customers.Count}.";

#### Problem 13.	Import Sales

NOTE: You will need method public static string ImportSales(CarDealerContext context, string inputJson) and public StartUp class. 

Import the sales from the provided file sales.json.

Your method should return string with message $"Successfully imported {Sales.Count}.";

### Section II: Export Data

Write the below described queries and export the returned data to the specified format. Make sure that Entity Framework generates only a single query for each task.

#### Problem 14.	Export Ordered Customers

NOTE: You will need method public static string GetOrderedCustomers(CarDealerContext context) and public StartUp class. 

Get all customers ordered by their birth date ascending. If two customers are born on the same date first print those who are not young drivers (e.g. print experienced drivers first). Export the list of customers to JSON in the format provided below.

![5](https://user-images.githubusercontent.com/82647282/183108749-82a3ca72-88ea-47d2-8c33-1cae186ade43.png)

#### Problem 15.	Export Cars from Make Toyota

NOTE: You will need method public static string GetCarsFromMakeToyota(CarDealerContext context) and public StartUp class. 

Get all cars from make Toyota and order them by model alphabetically and by travelled distance descending. Export the list of cars to JSON in the format 
provided below.

![6](https://user-images.githubusercontent.com/82647282/183108893-6d1d9e0b-3290-433b-9c98-7d42a220b3c7.png)

#### Problem 16.	Export Local Suppliers

NOTE: You will need method public static string GetLocalSuppliers(CarDealerContext context) and public StartUp class. 

Get all suppliers that do not import parts from abroad. Get their id, name and the number of parts they can offer to supply. Export the list of suppliers to JSON in the format provided below.

![7](https://user-images.githubusercontent.com/82647282/183109050-8f9b5ef0-a0be-42c2-a2d5-242ab1dc14ef.png)

#### Problem 17.	Export Cars with Their List of Parts

NOTE: You will need method public static string GetCarsWithTheirListOfParts(CarDealerContext context) and public StartUp class. 

Get all cars along with their list of parts. For the car get only make, model and travelled distance and for the parts get only name and price (formatted to 2nd digit after the decimal point). Export the list of cars and their parts to JSON in the format provided below.

![8](https://user-images.githubusercontent.com/82647282/183109154-b8f0c4c9-edee-4ecd-83f9-e90cab617e96.png)

#### Problem 18.	Export Total Sales by Customer

NOTE: You will need method public static string GetTotalSalesByCustomer(CarDealerContext context) and public StartUp class. 

Get all customers that have bought at least 1 car and get their names, bought cars count and total spent money on cars. Order the result list by total spent 
money descending then by total bought cars again in descending order. Export the list of customers to JSON in the format provided below.

![9](https://user-images.githubusercontent.com/82647282/183109285-0cf68cf1-807b-48e6-9286-f511f2224ca7.png)

#### Problem 19.	Export Sales with Applied Discount

NOTE: You will need method public static string GetSalesWithAppliedDiscount(CarDealerContext context) and public StartUp class. 

Get first 10 sales with information about the car, customer and price of the sale with and without discount. Export the list of sales to JSON in the format provided below.

![10](https://user-images.githubusercontent.com/82647282/183109393-5cc6b4bb-7ff4-43d3-815a-6646b2bfff09.png)
