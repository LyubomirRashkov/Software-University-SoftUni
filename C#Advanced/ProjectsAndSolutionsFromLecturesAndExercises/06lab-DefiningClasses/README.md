## PROBLEMS DESCRIPTION - DEFINING CLASSES (Lecture)


### Problem 1.	Car
NOTE: You need a StartUp class with the namespace CarManufacturer.

Create a class named Car. The class should have private fields for:
  +	make: string
  +	model: string
  +	year: int

The class should also have public properties for:
  +	Make: string
  +	Model: string
  +	Year: int

### Problem 2.	Car Extension
NOTE: You need a StartUp class with the namespace CarManufacturer.

Create a class Car (you can use the class from the previous task)

The class should have private fields for:
  +	make: string
  +	model: string
  +	year: int
  +	fuelQuantity: double
  +	fuelConsumption: double

The class should also have properties for:
  +	Make: string
  +	Model: string
  +	Year: int
  +	FuelQuantity: double
  +	FuelConsumption: double

The class should also have methods for:
  +	Drive(double distance): void – this method checks if the car fuel quantity minus the distance multiplied by the car fuel consumption is bigger than zero. If it is remove from the fuel quantity the result of the multiplication between the distance and the fuel consumption. Otherwise write on the console the following message: _"Not enough fuel to perform this trip!"_
  +	WhoAmI(): string – returns the following message: 

_"Make: {this.Make}_

_Model: {this.Model}_

_Year: {this.Year}_

_Fuel: {this.FuelQuantity:F2}"_

### Problem 3.	Car Constructors
Using the class from the previous problem create one parameterless constructor with default values:
  +	Make – VW
  +	Model – Golf
  +	Year – 2025
  +	FuelQuantity – 200
  +	FuelConsumption – 10

Create a second constructor accepting make, model and year upon initialization and calls the base constructor with its default values for fuelQuantity and fuelConsumption.

Create a third constructor accepting make, model, year, fuelQuantity and fuelConsumption upon initialization and reuses the second constructor to set the make, model and year values.

Go to StartUp.cs file and make 3 different instances of the Class Car, using the different overloads of the constructor.

### Problem 4.	Car Engine and Tires
Using the Car class, you already created, define another class Engine.

The class should have private fields for:
  +	horsePower: int
  +	cubicCapacity: double

The class should also have properties for:
  +	HorsePower: int
  +	CubicCapacity: double

The class should also have a constructor, which accepts horsepower and cubicCapacity upon initialization.

Now create a class Tire.

The class should have private fields for:
  +	year: int
  +	pressure: double

The class should also have properties for:
  +	Year: int
  +	Pressure: double

The class should also have a constructor, which accepts year and pressure upon initialization.

Finally, go to the Car class and create private fields and public properties for Engine and Tire[]. Create another constructor, which accepts make, model, year, fuelQuantity, fuelConsumption, Engine and Tire[] upon initialization.

### Problem 5.	Special Cars
This is the final and most interesting problem in this lab. Until you receive the command _"No more tires"_, you will be given tire info in the format:

_{year} {pressure}_

_{year} {pressure}_

_…_

_"No more tires"_

You have to collect all the tires provided. Next, until you receive the command _"Engines done"_ you will be given engine info and you also have to collect all that info.

_{horsePower} {cubicCapacity}_

_{horsePower} {cubicCapacity}_

_…_

The final step - until you receive _"Show special"_, you will be given information about cars in the format: _{make} {model} {year} {fuelQuantity} {fuelConsumption} {engineIndex} {tiresIndex}_

Every time you have to create a new Car with the information provided. The car engine is the provided engineIndex  and the tires are tiresIndex. Finally, collect all the created cars. When you receive the command _"Show special"_, drive 20 kilometers all the cars, which were manufactured during 2017 or after, have horse power above 330 and the sum of their tire pressure is between 9 and 10. Finally, print information about each special car in the following format:

_"Make: {specialCar.Make}"_

_"Model: {specialCar.Model}"_

_"Year: {specialCar.Year}"_

_"HorsePowers: {specialCar.Engine.HorsePower}"_

_"FuelQuantity: {specialCar.FuelQuantity}"_

Examples

| Input     | Output |
| --------- | -----|
| 2 2.6 3 1.6 2 3.6 3 1.6 <br> 1 3.3 2 1.6 5 2.4 1 3.2 <br> No more tires <br> 331 2.2 <br> 145 2.0 <br> Engines done <br> Audi A5 2017 200 12 0 0 <br> BMW X5 2007 175 18 1 1 <br> Show special | Make: Audi <br> Model: A5 <br> Year: 2017 <br> HorsePowers: 331 <br> FuelQuantity: 197.6 |
