## PROBLEMS DESCRIPTION - DATABASES ADVANCED RETAKE EXAM - 14 AUGUST 2020


Your task is to create a database application, using Entity Framework Core using the Code First approach. Design the domain models and methods for manipulating the data, as described below.

### SoftJail

![изображение](https://user-images.githubusercontent.com/82647282/182937659-23dafe1b-02b7-4211-9294-e7bd43494e83.png)

### 1. Project Skeleton Overview

You are given a project skeleton, which includes the following folders:
 
  +	Data – contains the SoftJailDbContext class, Models folder which contains the entity classes and the Configuration class with connection string
  +	DataProcessor – contains the Serializer and Deserializer classes, which are used for importing and exporting data
  +	Datasets – contains the .json and .xml files for the import part
  +	ImportResults – contains the import results you make in the Deserializer class
  +	ExportResults – contains the export results you make in the Serializer class

### 2. Model Definition 

Every Prisoner has a cell and a collection of Mails which he gets during his staying at the prison. Each Officer has special position and one or more prisoners to watch. Every Cell and Officer are placed in different Department.

The application needs to store the following data:

##### Prisoner

  +	Id – integer, Primary Key
  +	FullName – text with min length 3 and max length 20 (required)
  +	Nickname – text starting with "The " and a single word only of letters with an uppercase letter for beginning(example: The Prisoner) (required)
  +	Age – integer in the range [18, 65] (required)
  +	IncarcerationDate ¬– Date (required)
  +	ReleaseDate– Date
  +	Bail– decimal (non-negative, minimum value: 0)
  +	CellId - integer, foreign key
  +	Cell – the prisoner's cell
  +	Mails - collection of type Mail
  +	PrisonerOfficers - collection of type OfficerPrisoner

##### Officer

  +	Id – integer, Primary Key
  +	FullName – text with min length 3 and max length 30 (required)
  +	Salary – decimal (non-negative, minimum value: 0) (required)
  +	Position - Position enumeration with possible values: “Overseer, Guard, Watcher, Labour” (required)
  +	Weapon - Weapon enumeration with possible values: “Knife, FlashPulse, ChainRifle, Pistol, Sniper” (required)
  +	DepartmentId - integer, foreign key (required)
  +	Department – the officer's department (required)
  +	OfficerPrisoners - collection of type OfficerPrisoner

##### Cell

  +	Id – integer, Primary Key
  +	CellNumber – integer in the range [1, 1000] (required)
  +	HasWindow – bool (required)
  +	DepartmentId - integer, foreign key (required)
  +	Department – the cell's department (required)
  +	Prisoners - collection of type Prisoner

##### Mail

  +	Id – integer, Primary Key
  +	Description– text (required)
  +	Sender – text (required)
  +	Address – text, consisting only of letters, spaces and numbers, which ends with “ str.” (required) (Example: “62 Muir Hill str.“)
  +	PrisonerId - integer, foreign key (required)
  +	Prisoner – the mail's Prisoner (required)

##### Department

  +	Id – integer, Primary Key
  +	Name – text with min length 3 and max length 25 (required)
  +	Cells - collection of type Cell

##### OfficerPrisoner

  +	PrisonerId – integer, Primary Key
  +	Prisoner – the officer’s prisoner (required)
  +	OfficerId – integer, Primary Key
  +	Officer – the prisoner’s officer (required)

### 3. Data Import 

For the functionality of the application, you need to create several methods that manipulate the database. The project skeleton already provides you with these methods, inside the Deserializer class. Use Data Transfer Objects as needed.

Use the provided JSON and XML files to populate the database with data. Import all the information from those files into the database.

If a record does not meet the requirements from the first section, print the error message: "Invalid Data".

#### JSON Import

##### Import Departments and Cells

Using the file ImportDepartmentsCells.json, import the data from that file into the database. Print information about each imported object in the format described below. 

Constraints

  +	If any validation errors occur (such as if a department name is too long/short or a cell number is out of range) proceed as described above
  +	If a department is invalid, do not import its cells.
  +	If a Department doesn’t have any Cells, he is invalid.
  +	If one Cell has invalid CellNumber, don’t import the Department.
  + Success message: "Imported {department name} with {cells count} cells".
  
Upon correct import logic, you should have imported 6 departments and 34 cells.

##### Import Prisoners and Mails

Using the file ImportPrisonersMails.json, import the data from that file into the database. Print information about each imported object in the format described below.

Constraints

  +	The release and incarceration dates will be in the format “dd/MM/yyyy”. Make sure you use CultureInfo.InvariantCulture.
  +	If any validation errors occur (such as invalid prisoner name or invalid nickname), ignore the entity and print an error message.
  +	If a mail has incorrect address print error message and do not import the prisoner and his mails
  + Success message: "Imported {prisoner name} {prisoner age} years old".
  
Upon correct import logic, you should have imported 19 prisoners and 47 mails.

#### XML Import

##### Import Officers and Prisoners

Using the file ImportOfficersPrisoners.xml, import the data from the file into the database. Print information about each imported object in the format described below.

If any of the model requirements is violated continue with the next entity.

Constraints

  +	If there are any validation errors (such as negative salary or invalid position/weapon), proceed as described above.
  +	The prisoner Id will always be valid
  + Success message: "Imported {officer name} ({prisoners count} prisoners)".
  
Upon correct import logic, you should have imported 16 officers and 31 officers’ prisoners.

### 4. Data Export

Use the provided methods in the Serializer class. Usage of Data Transfer Objects is optional.

#### JSON Export

##### Export All Prisoners with Cells and Officers by Ids

The given method in the project skeleton receives an array of prisoner ids. Export all prisoners that were processed which have these ids. For each prisoner, get their id, name, cell number they are placed in, their officers with each officer name, and the department name they are responsible for. At the end export the total officer salary with exactly two digits after the decimal place. Sort the officers by their name (ascending),  sort the prisoners by their name (ascending), then by the prisoner id (ascending).

#### XML Export

##### Export Inbox for Prisoner

Use the method provided in the project skeleton, which receives a string of comma-separated prisoner names. Export the prisoners: for each prisoner, export its id, name, incarcerationDate in the format “yyyy-MM-dd” and their encrypted mails. The encrypted algorithm you have to use is just to take each prisoner mail description and reverse it. Sort the prisoners by their name (ascending), then by their id (ascending).