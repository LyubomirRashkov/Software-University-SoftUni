## PROBLEMS DESCRIPTION - DATABASES ADVANCED EXAM – 04 DECEMBER 2021


Your task is to create a database application, using Entity Framework Core, using the Code First approach. Design the domain models and methods for manipulating the data, as described below.

### Theatre

![изображение](https://user-images.githubusercontent.com/82647282/182928243-8b789341-9083-4b07-80b1-3f2fd6245ead.png)

### 1. Project Skeleton Overview

You are given a project skeleton, which includes the following folders:
  +	Data – contains the TheatreContext class, Models folder which contains the entity classes, and the Configuration class with the connection string
  +	DataProcessor – contains the Deserializer and Serializer classes, which are used for importing and exporting data
  +	Datasets – contains the .json and .xml files for the import part
  +	ImportResults – contains the import results you make in the Deserializer class
  +	ExportResults – contains the export results you make in the Serializer class

### 2. Model Definition 

Note: Foreign key navigation properties are required! 

The application needs to store the following data:

##### Theatre

  +	Id – integer, Primary Key
  +	Name – text with length [4, 30] (required)
  +	NumberOfHalls – sbyte between [1…10] (required)
  +	Director – text with length [4, 30] (required)
  +	Tickets - a collection of type Ticket

##### Play

  +	Id – integer, Primary Key
  +	Title – text with length [4, 50] (required)
  +	Duration – TimeSpan in format {hours:minutes:seconds}, with a minimum length of 1 hour. (required)
  +	Rating – float in the range [0.00….10.00] (required)
  +	Genre – enumeration of type Genre, with possible values (Drama, Comedy, Romance, Musical) (required)
  +	Description – text with length up to 700 characters (required)
  + Screenwriter – text with length [4, 30] (required)
  +	Casts - a collection of type Cast
  +	Tickets - a collection of type Ticket

##### Cast

  +	Id – integer, Primary Key
  +	FullName – text with length [4, 30] (required)
  +	IsMainCharacter – Boolean represents if the actor plays the main character in a play (required)
  +	PhoneNumber  - text in the following format: "+44-{2 numbers}-{3 numbers}-{4 numbers}". Valid phone numbers are: +44-53-468-3479, +44-91-842-6054, +44-59-742-3119 (required)
  +	PlayId - integer, foreign key (required)

##### Ticket

  +	Id – integer, Primary Key
  +	Price – decimal in the range [1.00….100.00] (required)
  +	RowNumber – sbyte in range [1….10] (required)
  +	PlayId – integer, foreign key (required)
  +	TheatreId – integer, foreign key (required)

### 3. Data Import 

For the functionality of the application, you need to create several methods that manipulate the database. The project skeleton already provides you with these methods, inside the Deserializer class. Usage of Data Transfer Objects is optional but highly recommended.

Use the provided JSON and XML files to populate the database with data. Import all the information from those files into the database.

If a record does not meet the requirements from the first section, print an error message: "Invalid data!".

#### XML Import

##### Import Plays

Using the file plays.xml, import the data from that file into the database. Print information about each imported object in the format described below.

Constraints

  +	If any validation errors occur (such as invalid title, genre, rating, description, screenwriter or duration of the play is less than 1(one) hour) do not import any part of the entity and append an error message "Invalid data!" to the method output.
  +	Durations will always be in the format "c". Do not forget to use CultureInfo.InvariantCulture!
  + Success message: "Successfully imported {playTitle} with genre {genreType} and a rating of {rating}!".
  
Upon correct import logic, you should have imported 30 plays.
  
##### Import Casts
  
Using the file casts.xml, import the data from that file into the database. Print information about each imported object in the format described below.

Constraints
  
  +	If any validation errors occur (such as invalid full name, phone number) do not import any part of the entity and append an error message "Invalid data!" to the method output. 
  + PlayId will be always valid.
  + Success message: "Successfully imported actor {fullName} as a {main/lesser} character!".
  
Upon correct import logic, you should have imported 287 actors.

#### JSON Import

##### Import Projections

Using the file theatres-and-tickets.json, import the data from the file into the database. Print information about each imported object in the format described below.

Constraints

  +	If there are any validation errors, do not import any part of the entity and append an error message to the method output.
  +	If there are any Ticket validation errors, do not import the invalid ticket, print "Invalid data!", and continue to the next ticket. 
  + PlayId will be always valid.
  + Success message: "Successfully imported theatre {theatreName} with #{totalNumber} tickets!".
  
Upon correct import logic, you should have imported 30 theaters and 704 tickets.

### 4. Data Export 

Use the provided methods in the Serializer class. Usage of Data Transfer Objects is optional.

#### JSON Export

##### Export Top Theaters

The given method in the project’s skeleton receives a number representing the number of halls. Export all theaters where the hall's count is bigger or equal to the given and have 20 or more tickets available. For each theater, export its Name, Halls, TotalIncome of tickets which are between the first and fifth row inclusively, and Tickets. For each ticket (between first and fifth row inclusively), export its price, and the row number. Order the theaters by the number of halls descending, then by name (ascending). Order the tickets by price descending.

NOTE: If you receive correct output when running the query locally, but judge gives an error, materialize the query (.ToArray(), .ToList() etc.) before the .Where() statement.

#### XML Export

##### Export Plays

Use the method provided in the project skeleton, which receives a rating. Export all plays with a rating equal or smaller to the given. For each play, export Title, Duration (in the format: "c"), Rating, Genre, and Actors which play the main character only. 

Keep in mind:

  +	If the rating is 0, you should print "Premier". 
  +	For each actor display:
    +	FullName 
    +	MainCharacter in the format: "Plays main character in '{playTitle}'."

Order the result by play title (ascending), then by genre (descending). Order actors by their full name descending.