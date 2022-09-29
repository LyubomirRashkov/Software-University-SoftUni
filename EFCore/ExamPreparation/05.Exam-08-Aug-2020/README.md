## PROBLEMS DESCRIPTION - DATABASES ADVANCED EXAM - 08 AUGUST 2020


Your task is to create a database application, using Entity Framework Core, using the Code First approach. Design the domain models and methods for manipulating the data, as described below.

### VaporStore

![изображение](https://user-images.githubusercontent.com/82647282/182941078-ddedfb37-19bf-4816-b94c-152c7ed2bf1e.png)

### 1. Project Skeleton Overview

You are given a project skeleton, which includes the following folders:

  +	Data – contains the VaporStoreDbContext class, Models folder which contains the entity classes and the Configuration class with connection string
  +	DataProcessor – contains the Serializer and Deserializer classes, which are used for importing and exporting data
  +	Datasets – contains the .json and .xml files for the import part
  +	ImportResults – contains the export results you make in the Deserializer class
  +	ExportResults – contains the import results you make in the Serializer class

### 2. Model Definition

Note: Foreign key navigation properties are required! 

The application needs to store the following data:

##### Game

  +	Id – integer, Primary Key
  +	Name – text (required)
  +	Price – decimal (non-negative, minimum value: 0) (required)
  +	ReleaseDate – Date (required)
  +	DeveloperId – integer, foreign key (required)
  +	Developer – the game’s developer (required)
  +	GenreId – integer, foreign key (required)
  +	Genre – the game’s genre (required)
  +	Purchases - collection of type Purchase
  +	GameTags - collection of type GameTag. Each game must have at least one tag.

##### Developer

  +	Id – integer, Primary Key
  +	Name – text (required)
  +	Games - collection of type Game

##### Genre

  +	Id – integer, Primary Key
  +	Name – text (required)
  +	Games - collection of type Game

##### Tag

  +	Id – integer, Primary Key
  +	Name – text (required)
  +	GameTags - collection of type GameTag

##### GameTag

  +	GameId – integer, Primary Key, foreign key (required)
  +	Game – Game
  +	TagId – integer, Primary Key, foreign key (required)
  +	Tag – Tag

##### User

  +	Id – integer, Primary Key
  +	Username – text with length [3, 20] (required)
  +	FullName – text, which has two words, consisting of Latin letters. Both start with an upper letter and are followed by lower letters. The two words are separated by a single space (ex. "John Smith") (required)
  +	Email – text (required)
  +	Age – integer in the range [3, 103] (required)
  +	Cards – collection of type Card

##### Card

  +	Id – integer, Primary Key
  +	Number – text, which consists of 4 pairs of 4 digits, separated by spaces (ex. “1234 5678 9012 3456”) (required)
  +	Cvc – text, which consists of 3 digits (ex. “123”) (required)
  +	Type – enumeration of type CardType, with possible values (“Debit”, “Credit”) (required)
  +	UserId – integer, foreign key (required)
  +	User – the card’s user (required)
  +	Purchases – collection of type Purchase

##### Purchase

  +	Id – integer, Primary Key
  +	Type – enumeration of type PurchaseType, with possible values (“Retail”, “Digital”) (required) 
  +	ProductKey – text, which consists of 3 pairs of 4 uppercase Latin letters and digits, separated by dashes (ex. “ABCD-EFGH-1J3L”) (required)
  +	Date – Date (required)
  +	CardId – integer, foreign key (required)
  +	Card – the purchase’s card (required)
  +	GameId – integer, foreign key (required)
  +	Game – the purchase’s game (required)

### 3. Data Import

For the functionality of the application, you need to create several methods that manipulate the database. The project skeleton already provides you with these methods, inside the Deserializer class. Usage of Data Transfer Objects is optional.

Use the provided JSON and XML files to populate the database with data. Import all the information from those files into the database.

If a record does not meet the requirements from the first section, print the error message: "Invalid Data".

#### JSON Import

##### Import Games, Developers, Genres and Tags

Using the file games.json, import the data from that file into the database. Print information about each imported object in the format described below.

Constraints

  +	If any validation errors occur (such as if a Price is negative, a Name/ReleaseDate/Developer/Genre is missing, Tags are missing or empty), do not import any part of the entity and append an error message to the method output.
  +	Dates are always in the format “yyyy-MM-dd”. Do not forget to use CultureInfo.InvariantCulture!
  +	If a developer/genre/tag with that name doesn’t exist, create it. 
  +	If a game is invalid, do not import its genre, developer or tags.
  + Success message: "Added {gameName} ({gameGenre}) with {tagsCount} tags".
  
Upon correct import logic, you should have imported 74 games, 66 developers, 12 genres and 25 tags.

##### Import Users and Cards

Using the file users.json, import the data from that file into the database. Print information about each imported object in the format described below.

Constraints

  +	If any validation errors occur (such as invalid full name, too short/long username, missing email, too low/high age, incorrect card number/CVC, no cards, etc.), do not import any part of the entity and append an error message to the method output.
  +	If any validation errors occur with card entity (such as invalid number/CVC, invalid Type) you should not import any part of the User entity holding this card and append an error message to the method output. 
  + Success message: "Imported {username} with {cardsCount} cards".
  
Upon correct import logic, you should have imported 30 users and 61 cards.

#### XML Import

##### Import Purchases

Using the file purchases.xml, import the data from the file into the database. Print information about each imported object in the format described below.

Constraints

  + If there are any validation errors, do not import any part of the entity and append an error message to the method output.
  +	Dates will always be in the format: “dd/MM/yyyy HH:mm”. Do not forget to use CultureInfo.InvariantCulture!
  + Success message: "Imported {gameName} for {username}".
  
Upon correct import logic, you should have imported 88 purchases.

### 4. Data Export

Use the provided methods in the Serializer class. Usage of Data Transfer Objects is optional.

#### JSON Export

##### Export All Games by Genres

The given method in the project skeleton receives an array of genre names. Export all games in those genres, which have any purchases. For each genre, export its id, genre name, games and total players (total purchase count). For each game, export its id, name, developer, tags (separated by ", ") and total player count (purchase count). Order the games by player count (descending), then by game id (ascending). Order the genres by total player count (descending), then by genre id (ascending)

#### XML Export

##### Export User Purchases by Type

Use the method provided in the project skeleton, which receives a purchase type as a string. Export all users who have any purchases. For each user, export their username, purchases for that purchase type and total money spent for that purchase type. For each purchase, export its card number, CVC, date in the format "yyyy-MM-dd HH:mm" (make sure you use CultureInfo.InvariantCulture) and the game. For each game, export its title (name), genre and price. Order the users by total spent (descending), then by username (ascending). For each user, order the purchases by date (ascending). Do not export users, who don’t have any purchases.

Note: All prices must be in decimal without any formatting!