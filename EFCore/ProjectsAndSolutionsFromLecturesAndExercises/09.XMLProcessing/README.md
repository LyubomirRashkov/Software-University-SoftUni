## PROBLEMS DESCRIPTION - XML Processing


### Product Shop Database

A products shop holds users, products and categories for the products. Users can sell and buy products.

  +	Users have an id, first name (optional) and last name and age (optional).
  +	Products have an id, nam, price, buyerId (optional) and sellerId as IDs of users.
  +	Categories have an id and name.
  +	Using Entity Framework Code First create a database following the above description.

![изображение](https://user-images.githubusercontent.com/82647282/183114582-bd385948-b8db-4da7-b69b-9d8988a8687c.png)

  +	Users should have many products sold and many products bought. 
  +	Products should have many categories
  +	Categories should have many products
  +	CategoryProducts should map products and categories

### Section I - Import Data

#### Problem 1. Import Users

NOTE: You will need method public static string ImportUsers(ProductShopContext context, string inputXml) and public StartUp class. 

Import the users from the provided file users.xml.

Your method should return string with message $"Successfully imported {Users.Count}";

#### Problem 2. Import Products

NOTE: You will need method public static string ImportProducts(ProductShopContext context, string inputXml) and public StartUp class. 

Import the products from the provided file products.xml.

Your method should return string with message $"Successfully imported {Products.Count}";

#### Problem 3. Import Categories

NOTE: You will need method public static string ImportCategories(ProductShopContext context, string inputXml) and public StartUp class. 

Import the categories from the provided file categories.xml. 

Some of the names will be null, so you don’t have to add them in the database. Just skip the record and continue.

Your method should return string with message $"Successfully imported {Categories.Count}";

#### Problem 4. Import Categories and Products

NOTE: You will need method public static string ImportCategoryProducts(ProductShopContext context, string inputXml) and public StartUp class. 

Import the categories and products ids from the provided file categories-products.xml. If provided category or product id, doesn’t exists, skip the whole entry!

Your method should return string with message $"Successfully imported {CategoryProducts.Count}";

### Section II - Export Data

Write the below described queries and export the returned data to the specified format. Make sure that Entity Framework generates only a single query for each task.

#### Problem 5. Products In Range

NOTE: You will need method public static string GetProductsInRange(ProductShopContext context) and public StartUp class. 

Get all products in a specified price range between 500 and 1000 (inclusive). Order them by price (from lowest to highest). Select only the product name, price and the full name of the buyer. Take top 10 records.

Return the list of suppliers to XML in the format provided below.

![1](https://user-images.githubusercontent.com/82647282/183115354-393296cb-0704-4064-b635-04b709061117.png)

#### Problem 6. Sold Products

NOTE: You will need method public static string GetSoldProducts(ProductShopContext context) and public StartUp class. 

Get all users who have at least 1 sold item. Order them by last name, then by first name. Select the person's first and last name. For each of the sold products, select the product's name and price. Take top 5 records. 

Return the list of suppliers to XML in the format provided below.

![2](https://user-images.githubusercontent.com/82647282/183115485-bedebd14-5585-4578-a5cf-0a58e3009107.png)

#### Problem 7. Categories By Products Count

NOTE: You will need method public static string GetCategoriesByProductsCount(ProductShopContext context) and public StartUp class. 

Get all categories. For each category select its name, the number of products, the average price of those products and the total revenue (total price sum) of those products (regardless if they have a buyer or not). Order them by the number of products (descending) then by total revenue.

Return the list of suppliers to XML in the format provided below.

![3](https://user-images.githubusercontent.com/82647282/183115590-d02733f2-212a-46e6-bef5-4e15ca93d424.png)

#### Problem 8. Users and Products

NOTE: You will need method public static string GetUsersWithProducts(ProductShopContext context) and public StartUp class. 

Select users who have at least 1 sold product. Order them by the number of sold products (from highest to lowest). Select only their first and last name, age, count of sold products and for each product - name and price sorted by price (descending). Take top 10 records.

Follow the format below to better understand how to structure your data. 

Return the list of suppliers to XML in the format provided below.

![4](https://user-images.githubusercontent.com/82647282/183115724-6a7f95a5-e06d-4091-8891-eba4f25850aa.png)

### Car Dealer Database

A car dealer needs information about cars, their parts, parts suppliers, customers and sales. 

  +	Cars have make, model, travelled distance in kilometers
  +	Parts have name, price and quantity
  +	Part supplier have name and info whether he uses imported parts
  +	Customer has name, date of birth and info whether he is young driver
  +	Sale has car, customer and discount percentage

A price of a car is formed by total price of its parts.

![изображение](https://user-images.githubusercontent.com/82647282/183115900-7a573990-2561-45d3-9e93-a300cdbcc121.png)

  +	A car has many parts and one part can be placed in many cars
  +	One supplier can supply many parts and each part can be delivered by only one supplier
  +	In one sale, only one car can be sold
  +	Each sale has one customer and a customer can buy many cars

### Section I - Import Data

Import data from the provided files (suppliers.xml, parts.xml, cars.xml, customers.xml).

#### Problem 9. Import Suppliers

NOTE: You will need method public static string ImportSuppliers(CarDealerContext context, string inputXml) and public StartUp class. 

Import the suppliers from the provided file suppliers.xml. 

Your method should return string with message $"Successfully imported {suppliers.Count}";

#### Problem 10. Import Parts

NOTE: You will need method public static string ImportParts(CarDealerContext context, string inputXml) and public StartUp class. 

Import the parts from the provided file parts.xml. If the supplierId doesn’t exists, skip the record.

Your method should return string with message $"Successfully imported {parts.Count}";

#### Problem 11. Import Cars

NOTE: You will need method public static string ImportCars(CarDealerContext context, string inputXml) and public StartUp class. 

Import the cars from the provided file cars.xml. Select unique car part ids. If the part id doesn’t exists, skip the part record.

Your method should return string with message $"Successfully imported {cars.Count}";

#### Problem 12. Import Customers

NOTE: You will need method public static string ImportCustomers(CarDealerContext context, string inputXml) and public StartUp class. 

Import the customers from the provided file customers.xml.

Your method should return string with message $"Successfully imported {customers.Count}";

#### Problem 13. Import Sales

NOTE: You will need method public static string ImportSales(CarDealerContext context, string inputXml) and public StartUp class. 

Import the sales from the provided file sales.xml. If car doesn’t exists, skip whole entity.

Your method should return string with message $"Successfully imported {sales.Count}";

### Section II - Export Data

Write the below described queries and export the returned data to the specified format. Make sure that Entity Framework generates only a single query for each task.

#### Problem 14. Cars With Distance

NOTE: You will need method public static string GetCarsWithDistance(CarDealerContext context) and public StartUp class. 

Get all cars with distance more than 2,000,000. Order them by make, then by model alphabetically. Take top 10 records.

Return the list of suppliers to XML in the format provided below.

![5](https://user-images.githubusercontent.com/82647282/183116632-496f79b1-2975-4916-95cc-c8e6c0b3bf1f.png)

#### Problem 15. Cars from make BMW

NOTE: You will need method public static string GetCarsFromMakeBmw(CarDealerContext context) and public StartUp class. 

Get all cars from make BMW and order them by model alphabetically and by travelled distance descending.

Return the list of suppliers to XML in the format provided below.

![6](https://user-images.githubusercontent.com/82647282/183116739-58d382ab-4e40-4a6a-af4b-a37a8c80f6de.png)

#### Problem 16. Local Suppliers

NOTE: You will need method public static string GetLocalSuppliers(CarDealerContext context) and public StartUp class. 

Get all suppliers that do not import parts from abroad. Get their id, name and the number of parts they can offer to supply. 

Return the list of suppliers to XML in the format provided below.

![7](https://user-images.githubusercontent.com/82647282/183116857-873aabf9-37c0-401e-b19f-02b328506828.png)

#### Problem 17. Cars with Their List of Parts

NOTE: You will need method public static string GetCarsWithTheirListOfParts(CarDealerContext context) and public StartUp class. 

Get all cars along with their list of parts. For the car get only make, model and travelled distance and for the parts get only name and price and sort all parts by price (descending). Sort all cars by travelled distance (descending) then by model (ascending). Select top 5 records.

Return the list of suppliers to XML in the format provided below.

![8](https://user-images.githubusercontent.com/82647282/183116979-da5aac72-b716-4bbf-a338-03ae26f847a0.png)

#### Problem 18. Total Sales by Customer

NOTE: You will need method public static string GetTotalSalesByCustomer(CarDealerContext context) and public StartUp class. 

Get all customers that have bought at least 1 car and get their names, bought cars count and total spent money on cars. Order the result list by total spent money descending.

Return the list of suppliers to XML in the format provided below.

![9](https://user-images.githubusercontent.com/82647282/183117101-d35e9a0f-9264-4a77-9d6f-95ff9ca003a4.png)

#### Problem 19. Sales with Applied Discount

NOTE: You will need method public static string GetSalesWithAppliedDiscount(CarDealerContext context) and public StartUp class. 

Get all sales with information about the car, customer and price of the sale with and without discount.

Return the list of suppliers to XML in the format provided below.

![10](https://user-images.githubusercontent.com/82647282/183117190-6f6758f5-dad1-4c72-9e28-8afd7459753c.png)
