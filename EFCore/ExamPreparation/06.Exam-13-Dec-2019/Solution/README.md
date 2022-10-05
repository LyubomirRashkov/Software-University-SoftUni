## PROBLEMS DESCRIPTION - DATABASES ADVANCED EXAM - 13 DECEMBER 2019


Your task is to create a database application, using Entity Framework Core, using the Code First approach. Design the domain models and methods for manipulating the data, as described below.

### BookShop

![изображение](https://user-images.githubusercontent.com/82647282/182943567-9c786e4d-73ad-4900-9415-07f68f3959cf.png)

### 1. Project Skeleton Overview

You are given a project skeleton, which includes the following folders:

  + Data - contains the BookShopContext class, Models folder which contains the entity classes and the Configuration class with connection string
  +	DataProcessor - contains the Serializer and Deserializer classes, which are used for importing and exporting data
  +	Datasets - contains the .json and .xml files for the import part
  +	ImportResults - contains the import results you make in the Deserializer class
  +	ExportResults - contains the export results you make in the Serializer class

### 2. Model Definition

The application needs to store the following data:

##### Author

  +	Id - integer, Primary Key
  +	FirstName - text with length [3, 30]. (required)
  +	LastName - text with length [3, 30]. (required)
  +	Email - text (required). Validate it! There is attribute for this job.
  +	Phone - text. Consists only of three groups (separated by '-'), the first two consist of three digits and the last one - of 4 digits. (required)
  +	AuthorsBooks - collection of type AuthorBook

##### Book

  +	Id - integer, Primary Key
  +	Name - text with length [3, 30]. (required)
  +	Genre - enumeration of type Genre, with possible values (Biography = 1, Business = 2, Science = 3) (required)
  +	Price - decimal in range between 0.01 and max value of the decimal (required)
  +	Pages – integer in range between 50 and 5000 (required)
  +	PublishedOn - date and time (required)
  +	AuthorsBooks - collection of type AuthorBook

##### AuthorBook

  +	AuthorId - integer, Primary Key, Foreign key (required)
  +	Author -  Author
  +	BookId - integer, Primary Key, Foreign key (required)
  +	Book - Book

### 3.	Data Import

For the functionality of the application, you need to create several methods that manipulate the database. The project skeleton already provides you with these methods, inside the Deserializer class. Usage of Data Transfer Objects is optional.

Use the provided JSON and XML files to populate the database with data. Import all the information from those files into the database.

If a record does not meet the requirements from the first section, print the error message: "Invalid data!".

#### XML Import

##### Import Books

Using the file books.xml, import the data from the file into the database. Print information about each imported object in the format described below.

Constraints

  +	If there are any validation errors for the book entity (such as invalid name, genre, price, pages or published date), do not import any part of the entity and append an error message to the method output.
  + Date will be in format "MM/dd/yyyy", do not forget to use CultureInfo.InvariantCulture
  + Success message: "Successfully imported book {bookName} for {bookPrice}.".
  
Upon correct import logic, you should have imported 70 books.

#### JSON Import

##### Import Authors

Using the file authors.json, import the data from that file into the database. Print information about each imported object in the format described below.

Constraints

  +	If any validation errors occur (such as invalid first name, last name, email or phone), do not import any part of the entity and append an error message to the method output.
  +	If an email exists, do not import the author and append and error message.
  +	If a book does not exist in the database, do not append an error message and continue with the next book.
  +	If an author have zero books (all books are invalid) do not import the author and append an error message to the method output.
  + Success message: "Successfully imported author - {first name + last name} with {booksCount} books.".
  
Upon correct import logic, you should have imported 75 authors and 150 author books.

### 4. Data Export

Use the provided methods in the Serializer class. Usage of Data Transfer Objects is optional.

#### JSON Export

##### Export Most Craziest Authors

Select all authors along with their books. Select their name in format first name + ' ' + last name. For each book select its name and price formatted to the second digit after the decimal point. Order the books by price in descending order. Finally sort all authors by book count descending and then by author full name.

NOTE: Before the orders, materialize the query (This is issue by Microsoft in InMemory database library)!!!

#### XML Export

##### Export Oldest Books

Export top 10 books that are published before the given date and are of type science. For each book select its name, date (in format "d") and pages. Sort them by pages in descending order and then by date in descending order.

NOTE: Before the orders, materialize the query (This is issue by Microsoft in InMemory database library)!!!