## PROBLEMS DESCRIPTION - DATABASES ADVANCED EXAM - 06 AUGUST 2022


Your task is to create a database application, using Entity Framework Core, using the Code First approach. Design the domain models and methods for manipulating the data, as described below.

### Footballers

![изображение](https://user-images.githubusercontent.com/82647282/183256355-6783c19e-e997-4197-9c2e-a2a4317e3434.png)

### 1.	Project Skeleton Overview

You are given a project skeleton, which includes the following folders:

  +	Data – contains the FootballersContext class, Models folder, which contains the entity classes and the Configuration class with connection string
  +	DataProcessor – contains the Serializer and Deserializer classes, which are used for importing and exporting data
  +	Datasets – contains the .json and .xml files for the import part
  +	ImportResults – contains the import results you make in the Deserializer class
  +	ExportResults – contains the export results you make in the Serializer class

### 2.	Model Definition 

The application needs to store the following data:

#### Footballer

  +	Id – integer, Primary Key
  +	Name – text with length [2, 40] (required)
  +	ContractStartDate – date and time (required)
  +	ContractEndDate – date and time (required)
  +	PositionType – enumeration of type PositionType, with possible values (Goalkeeper, Defender, Midfielder, Forward) (required) 
  +	BestSkillType – enumeration of type BestSkillType, with possible values (Defence, Dribble, Pass, Shoot, Speed) (required)
  +	CoachId – integer, foreign key (required)
  +	Coach – Coach 
  +	TeamsFootballers – collection of type TeamFootballer

NOTE: For the enumeration types, use the default associated values – 0, 1, 2, … The possible values must be ordered as listed in this document.

#### Team

  +	Id – integer, Primary Key
  +	Name – text with length [3, 40]. May contain letters (lower and upper case), digits, spaces, a dot sign ('.') and a dash ('-'). (required)
  +	Nationality – text with length [2, 40] (required)
  +	Trophies – integer (required)
  +	TeamsFootballers – collection of type TeamFootballer

#### Coach

  +	Id – integer, Primary Key
  +	Name – text with length [2, 40] (required)
  +	Nationality – text (required)
  +	Footballers – collection of type Footballer

#### TeamFootballer

  +	TeamId – integer, Primary Key, foreign key (required)
  +	Team – Team
  +	FootballerId – integer, Primary Key, foreign key (required)
  +	Footballer – Footballer

### 3.	Data Import 

For the functionality of the application, you need to create several methods that manipulate the database. The project skeleton already provides you with these methods, inside the Deserializer class. 

NOTE: Usage of Data Transfer Objects and AutoMapper is optional. Should you choose to use AutoMapper, go to the StartUp class and uncomment the line below:

Mapper.Initialize(config => config.AddProfile<FootballersProfile>());

Use the provided JSON and XML files to populate the database with data. Import all the information from those files into the database.

If a record does not meet the requirements from the first section, print the error message: "Invalid data!".

#### XML Import

##### Import Coaches

Using the file coaches.xml, import the data from the file into the database. Print information about each imported object in the format described below.

Constraints

  +	If there are any validation errors for the coach entity (such as invalid name or null or empty nationality), do not import any part of the entity and append an error message to the method output.
  +	If there are any validation errors for the footballer entity (such as invalid name, start or end contract date are missing or invalid, contract start date is after contract end date), do not import it (only the footballer itself, not the whole coach info) and append an error message to the method output.
  + Success message: "Successfully imported coach – {coachName} with {footballersCount} footballers.";
  
Upon correct import logic, you should have imported 22 coaches and 38 footballers.

#### JSON Import

##### Import Teams

Using the file teams.json, import the data from that file into the database. Print information about each imported object in the format described below.

Constraints

  +	If any validation errors occur (such as invalid name, missing nationality, zero (0) or less trophies), do not import any part of the entity and append an error message to the method output.
  +	Take only the unique footballers.
  +	If a footballer does not exist in the database, append an error message to the method output and continue with the next footballer.
  + Success message: "Successfully imported team - {teamName} with {teamFootballersCount} footballers.";
  
### 4.	Data Export 

Use the provided methods in the Serializer class. Usage of Data Transfer Objects and AutoMapper is optional.

#### JSON Export

##### Export Teams With Most Footballers

Select the top 5 teams that have at least one footballer that their contract start date is higher or equal to the given date. Select them with their footballers who meet the same criteria (their contract start date is after or equals the given date). For each team, export their name and their footballers. For each footballer, export their name and contract start date (must be in format "d"), contract end date (must be in format "d"), position and best skill type. Order the footballers by contract end date (descending), then by name (ascending). Order the teams by all footballers (meeting above condition) count (descending), then by name (ascending).

NOTE: Do not forget to use CultureInfo.InvariantCulture. You may need to call .ToArray() function before the selection in order to detach entities from the database and avoid runtime errors (EF Core bug). 

#### XML Export

##### Export Coaches with Their Footballers

Export all coaches that train at least one footballer. For each coach, export their name and footballers count. For each footballer, export their name and position type. Order the footballers by name (ascending). Order the coaches by footballers count (descending), then by name (ascending).

NOTE: You may need to call .ToArray() function before the selection, in order to detach entities from the database and avoid runtime errors (EF Core bug). 