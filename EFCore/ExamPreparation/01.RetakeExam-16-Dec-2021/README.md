## PROBLEMS DESCRIPTION - DATABASES ADVANCED RETAKE EXAM – 16 DECEMBER 2021


Your task is to create a database application, using Entity Framework Core, using the Code First approach. Design the domain models and methods for manipulating the data, as described below.

### Artillery

![изображение](https://user-images.githubusercontent.com/82647282/182914500-12cac2c1-291d-4ac4-8beb-3d9be7b3d528.png)

### 1. Project Skeleton Overview

You are given a project skeleton, which includes the following folders:
  +	Data – contains the ArtilleryContext class, Models folder which contains the entity classes, and the Configuration class with the connection string
  +	DataProcessor – contains the Deserializer and Serializer classes, which are used for importing and exporting data
  +	Datasets – contains the .json and .xml files for the import part
  +	ImportResults – contains the import results you make in the Deserializer class
  +	ExportResults – contains the export results you make in the Serializer class

### 2. Model Definition 

Note: Foreign key navigation properties are required! 

The application needs to store the following data:

##### Country

  +	Id – integer, Primary Key
  +	CountryName – text with length [4, 60] (required)
  +	ArmySize – integer in the range [50_000….10_000_000] (required)
  +	CountriesGuns – a collection of CountryGun

##### Manufacturer

  +	Id – integer, Primary Key
  +	ManufacturerName – unique text with length [4…40] (required)
  +	Founded – text with length [10…100] (required)
  +	Guns – a collection of Gun

##### Shell

  +	Id – integer, Primary Key
  +	ShellWeight – double in range  [2…1_680] (required)
  +	Caliber – text with length [4…30] (required)
  +	Guns – a collection of Gun

##### Gun

  +	Id – integer, Primary Key
  +	ManufacturerId – integer, foreign key (required)
  +	GunWeight– integer in range [100…1_350_000] (required)
  +	BarrelLength – double in range [2.00….35.00] (required)
  +	NumberBuild – integer
  +	Range – integer in range [1….100_000] (required)
  +	GunType – enumeration of GunType, with possible values (Howitzer, Mortar, FieldGun, AntiAircraftGun, MountainGun, AntiTankGun) (required)
  +	ShellId – integer, foreign key (required)
  +	CountriesGuns – a collection of CountryGun

##### CountryGun

  +	CountryId – Primary Key integer, foreign key (required)
  +	GunId – Primary Key integer, foreign key (required)

### 3. Data Import 

For the functionality of the application, you need to create several methods that manipulate the database. The project skeleton already provides you with these methods, inside the Deserializer class. Usage of Data Transfer Objects is optional but highly recommended.

Use the provided JSON and XML files to populate the database with data. Import all the information from those files into the database.

If a record does not meet the requirements from the first section, print an error message: "Invalid data.".

#### XML Import

##### Import Countries

Using the file countries.xml, import the data from that file into the database. Print information about each imported object in the format described below.

Constraints

  + If any validation errors occur such as invalid country name or army size, do not import any part of the entity and append an error message "Invalid data." to the method output.
  + Success message: "Successfully import {countryName} with {armySize} army personnel.".

Upon correct import logic, you should have imported 88 countries.

##### Import Manufacturers

Using the file manufacturers.xml, import the data from that file into the database. Print information about each imported object in the format described below.

Constraints

  + If any validation errors occur such as invalid manufacturer name or founded, do not import any part of the entity and append an error message "Invalid data." to the method output. 
  + The Founded entity will be separated by comma and space ", ".
  + Success message: "Successfully import manufacturer {manufacturerName} founded in {townName, countryName}.".

Upon correct import logic, you should have imported 20 unique manufacturers.

##### Import Shells

Using the file shells.xml, import the data from that file into the database. Print information about each imported object in the format described below.

Constraints

  + If any validation errors occur such as invalid shell weight or caliber, do not import any part of the entity and append an error message "Invalid data." to the method output. 
  + Success message: "Successfully import shell caliber #{caliber} weight {shellWeigh} kg.".
  
Upon correct import logic, you should have imported 60 shells.

#### JSON Import

##### Import Guns

Using the file guns.json, import the data from the file into the database. Print information about each imported object in the format described below.

Constraints

  +	If there are any validation errors (such as invalid gun weight, barrel length, range, gun-type), do not import any part of the entity and append an error message to the method output.
  +	The Countries array will always contain valid ids.
  + Success message: "Successfully import gun {gunType} with a total weight of {gunWeight} kg. and barrel length of {barrelLength} m.".
  
Upon correct import logic, you should have imported 138 guns and 785 countries' guns.

### 4. Data Export 

Use the provided methods in the Serializer class. Usage of Data Transfer Objects is optional.

#### JSON Export

##### Export Shells

The given method in the project’s skeleton receives a double representing the shell weight. Export all shells which weights more than the given and the guns which use this shell. For each Shell, export its ShellWeight, Caliber, and Guns. Export only the guns which are AntiAircraftGun gun type. For every gun export GunType, GunWeight, BarrelLength, and Range (if the range is bigger than 3000, export "Long-range", otherwise export "Regular range"). Order the guns by GunWeight (descending). Order the shells by ShellWeight (ascending).

#### XML Export

##### Export Guns

Use the method provided in the project skeleton, which receives a manufacturer. Export all guns with a manufacturer equal to the given. For each gun, export Manufacturer, GunType, BarrelLength, GunWeight, Range, and Countries that use this gun. Select only the Countries which has ArmySize bigger than 4500000. For each country export CountryName and ArmySize. Order the countries by army size (ascending). Order guns by BarrelLength (ascending).