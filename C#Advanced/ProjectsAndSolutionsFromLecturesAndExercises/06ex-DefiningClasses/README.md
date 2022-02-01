## PROBLEMS DESCRIPTION - DEFINING CLASSES (Exercise)


### Problem 1.	Define a Class Person
NOTE: You need a StartUp class with the namespace DefiningClasses.

Define a class Person with private fields for name and age and public properties Name and Age. Try to create a few objects of type Person:

| Name     | Age |
| --------- | -----|
| Peter | 20 |
| George | 18 |
| Jose | 43 |

### Problem 2.	Creating Constructors
NOTE: You need a StartUp class with the namespace DefiningClasses.

Add 3 constructors to the Person class from the last task. Use constructor chaining to reuse code:
  +	The first should take no arguments and produce a person with name _"No name"_ and age = 1. 
  +	The second should accept only an integer number for the age and produce a person with name _"No name"_ and age equal to the passed parameter.
  +	The third one should accept a string for the name and an integer for the age and should produce a person with the given name and age.

### Problem 3.	Oldest Family Member
Use your Person class from the previous tasks. Create a class Family. The class should have a list of people, a method for adding members - void AddMember(Person member) and a method returning the oldest family member – Person GetOldestMember(). Write a program that reads the names and ages of N people and adds them to the family. Then print the name and age of the oldest member.

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> Peter 3 <br> George 4 <br> Annie 5 | Annie 5 |
| 5 <br> Steve 10 <br> Christopher 15 <br> Annie 4 <br> Ivan 35 <br> Maria 34 | Ivan 35 |

### Problem 4.	Opinion Poll
Using the Person class, write a program that reads from the console N lines of personal information and then prints all people, whose age is more than 30 years, sorted in alphabetical order.

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> Peter 12 <br> Sam 31 <br> Ivan 48 | Ivan - 48 <br> Sam - 31 |
| 5 <br> Niki 33 <br> Yord 88 <br> Teo 22 <br> Lily 44 <br> Stan 11 | Lily - 44 <br> Niki - 33 <br> Yord - 88 |

### Problem 5.	Date Modifier
Create a class DateModifier, which stores the difference of the days between two dates. It should have a method which takes two string parameters representing a date as strings and calculates the difference in the days between them.  

Examples

| Input     | Output |
| --------- | -----|
| 1992 05 31 <br> 2016 06 17 | 8783 |
| 2016 05 31 <br> 2016 04 19 | 42 |

### Problem 6.	Speed Racing
Create a program that keeps track of cars and their fuel and supports methods for moving the cars. Define a class Car. Each Car has the following properties:
  +	string Model
  +	double FuelAmount
  +	double FuelConsumptionPerKilometer
  +	double TravelledDistance

A car's model is unique - there will never be 2 cars with the same model. On the first line of the input, you will receive a number N – the number of cars you need to track. On each of the next N lines, you will receive information about a car in the following format: _"{model} {fuelAmount} {fuelConsumptionFor1km}"_

All cars start at 0 kilometers traveled. After the N lines, until the command _"End"_ is received, you will receive commands in the following format: _"Drive {carModel} {amountOfKm}"_

Implement a method in the Car class to calculate whether or not a car can move that distance. If it can, the car’s fuel amount should be reduced by the amount of used fuel and its traveled distance should be increased by the number of the traveled kilometers. Otherwise, the car should not move (its fuel amount and the traveled distance should stay the same) and you should print on the console: _"Insufficient fuel for the drive"_

After the _"End"_ command is received, print each car and its current fuel amount and the traveled distance in the format: _"{model} {fuelAmount} {distanceTraveled}"_. Print the fuel amount formatted two digits after the decimal separator. 

Examples

| Input     | Output |
| --------- | -----|
| 2 <br> AudiA4 23 0.3 <br> BMW-M2 45 0.42 <br> Drive BMW-M2 56 <br> Drive AudiA4 5 <br> Drive AudiA4 13 <br> End | AudiA4 17.60 18 <br> BMW-M2 21.48 56 |
| 3 <br> AudiA4 18 0.34 <br> BMW-M2 33 0.41 <br> Ferrari-488Spider 50 0.47 <br> Drive Ferrari-488Spider 97 <br> Drive Ferrari-488Spider 35 <br> Drive AudiA4 85 <br> Drive AudiA4 50 <br> End | Insufficient fuel for the drive <br> Insufficient fuel for the drive <br> AudiA4 1.00 50 <br> BMW-M2 33.00 0 <br> Ferrari-488Spider 4.41 97 |

### Problem 7.	Raw Data
Create a program that tracks cars and their cargo. 

Start by define a class Car that holds information about:
  +	Model: a string property
  +	Engine: a class with two properties – speed and power
  +	Cargo: a class with two properties – type and weight 
  +	Tires: a collection of exactly 4 tires. Each tire should have two properties: age and pressure.

Create a constructor that receives all of the information about the Car and creates and initializes the model and its inner components (engine, cargo, and tires).

Input

On the first line of input, you will receive a number N represent the number of cars you have.

1.	On the next N lines, you will receive information about each car in the format: _"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"_
  +	The speed, power, weight, and tire age are integers.
  +	The tire pressure is a floating point number. 
2.	Next, you will receive a single line with one of the following commands:  _"fragile"_ or _"flammable"_ 

Output

As an output if the command is:
  +	_"fragile"_ - print all cars whose cargo is _"fragile"_ and have a pressure of a single tire < 1
  +	_"flammable"_ - print all cars, whose cargo is _"flammable"_ and have engine power > 250

The cars should be printed in order of appearing in the input.

Examples

| Input     | Output |
| --------- | -----|
| 2 <br> ChevroletAstro 200 180 1000 fragile 1.3 1 1.5 2 1.4 2 1.7 4 <br> Citroen2CV 190 165 1200 fragile 0.9 3 0.85 2 0.95 2 1.1 1 <br> fragile | Citroen2CV |
| 4 <br> ChevroletExpress 215 255 1200 flammable 2.5 1 2.4 2 2.7 1 2.8 1 <br> ChevroletAstro 210 230 1000 flammable 2 1 1.9 2 1.7 3 2.1 1 <br> DaciaDokker 230 275 1400 flammable 2.2 1 2.3 1 2.4 1 2 1 <br> Citroen2CV 190 165 1200 fragile 0.8 3 0.85 2 0.7 5 0.95 2 <br> flammable | ChevroletExpress <br> DaciaDokker |

### Problem 8.	Car Salesman
Define two classes Car and Engine. 

Start by defining a class Car that holds information about:
  +	Model: a string property.
  +	Engine: a property holding the engine object.
  +	Weight: an int property, it is optional.
  +	Color: a string property, it is optional.

Next, the Engine class has the following properties:
  +	Model: a string property.
  +	Power: an int property.
  +	Displacement: an int property, it is optional.
  +	Efficiency: a string property, it is optional.

Input

1.	On the first line, you will read a number N, which will specify how many lines of engines you will receive. 
    +	On each of the next N lines, you will receive information about an Engine in the following format: _"{model} {power} {displacement} {efficiency}"_
    +	Keep in mind that _"displacement"_ and _"efficiency"_ are optional, they could be missing from the command.
2.	Next, you will receive a number M, which will specify how many lines of car you will receive. 
    +	On each of the next M lines, you will receive information about a Car in the following format: _"{model} {engine} {weight} {color}"_.
    +	Keep in mind that _"weight"_ and _"color"_ are optional, they could be missing from the command.
    +	The _"engine"_ will always be the model of an existing Engine.
    +	When creating the object for a Car, you should keep a reference to the real engine in it, instead of just the engine’s model. 

Note: The optional properties might be missing from the formats.

Output

Your task is to print all the cars in the order they were received and their information in the format defined bellow. If any of the optional fields is missing, print _"n/a"_ in its place:

_"{CarModel}:_

  _{EngineModel}:_

   _Power: {EnginePower}_
    
   _Displacement: {EngineDisplacement}_
 
   _Efficiency: {EngineEfficiency}_
  
  _Weight: {CarWeight}_
  
  _Color: {CarColor}"_

Examples

| Input     | Output |
| --------- | -----|
| 2 <br> V8-101 220 50 <br> V4-33 140 28 B <br> 3 <br> FordFocus V4-33 1300 Silver <br> FordMustang V8-101 <br> VolkswagenGolf V4-33 Orange | FordFocus: <br>   V4-33: <br> Power: 140 <br> Displacement: 28 <br> Efficiency: B <br> Weight: 1300 <br> Color: Silver <br> FordMustang: <br>   V8-101: <br> Power: 220 <br> Displacement: 50 <br> Efficiency: n/a <br> Weight: n/a <br> Color: n/a <br> VolkswagenGolf: <br> V4-33: <br> Power: 140 <br> Displacement: 28 <br> Efficiency: B <br> Weight: n/a <br> Color: Orange |
| 4 <br> DSL-10 280 B <br> V7-55 200 35 <br> DSL-13 305 55 A+ <br> V7-54 190 30 D <br> 4 <br> FordMondeo DSL-13 Purple <br> VolkswagenPolo V7-54 1200 Yellow <br> VolkswagenPassat DSL-10 1375 Blue <br> FordFusion DSL-13 | FordMondeo: <br> DSL-13: <br> Power: 305 <br> Displacement: 55 <br> Efficiency: A+ <br> Weight: n/a <br> Color: Purple <br> VolkswagenPolo: <br> V7-54: <br> Power: 190 <br> Displacement: 30 <br> Efficiency: D <br> Weight: 1200 <br> Color: Yellow <br> VolkswagenPassat: <br> DSL-10: <br> Power: 280 <br> Displacement: n/a <br> Efficiency: B <br> Weight: 1375 <br> Color: Blue <br> FordFusion: <br> DSL-13: <br> Power: 305 <br> Displacement: 55 <br> Efficiency: A+ <br> Weight: n/a <br> Color: n/a |

### Problem 9.	Pokemon Trainer
Define a class Trainer and a class Pokemon. 

Trainers have:
  +	Name
  +	Number of badges
  +	A collection of pokemon

Pokemon have:
  +	Name
  +	Element
  +	Health

All values are mandatory. Every Trainer starts with 0 badges.

You will be receiving lines until you receive the command _"Tournament"_. Each line will carry information about a pokemon and the trainer who caught it in the format: _"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"_

TrainerName is the name of the Trainer who caught the pokemon. Trainers’ names are unique.

After receiving the command _"Tournament"_, you will start receiving commands until the _"End"_ command is received. They can contain one of the following:
  +	_"Fire"_
  +	_"Water"_
  +	_"Electricity"_

For every command you must check if a trainer has at least 1 pokemon with the given element. If he does, he receives 1 badge. Otherwise, all of his pokemon lose 10 health. If a pokemon falls to 0 or less health, he dies and must be deleted from the trainer’s collection. In the end, you should print all of the trainers, sorted by the amount of badges they have in descending order (if two trainers have the same amount of badges, they should be sorted by order of appearance in the input) in the format: _"{trainerName} {badges} {numberOfPokemon}"_

Examples

| Input     | Output |
| --------- | -----|
| Peter Charizard Fire 100 <br> George Squirtle Water 38 <br> Peter Pikachu Electricity 10 <br> Tournament <br> Fire <br> Electricity <br> End | Peter 2 2 <br> George 0 1 |
| Sam Blastoise Water 18 <br> Narry Pikachu Electricity 22 <br> John Kadabra Psychic 90 <br> Tournament <br> Fire <br> Electricity <br> Fire <br> End | Narry 1 1 <br> Sam 0 0 <br> John 0 1 |

### Problem 10.	SoftUni Parking
Your task is to create a repository, which stores cars by creating the classes described below.

First, write a C# class Car with the following properties:
  +	Make: string
  +	Model: string
  +	HorsePower: int
  +	RegistrationNumber: string

The class' constructor should receive make, model, horsePower and registrationNumber and override the ToString() method in the following format:

_"Make: {make}"_

_"Model: {model}"_

_"HorsePower: {horse power}"_

_"RegistrationNumber: {registration number}"_

Create a C# class Parking that has Cars (a collection which stores the entity Car). All entities inside the class have the same properties.

The class' constructor should initialize the Cars with a new instance of the collection and accept capacity as a parameter. 

Implement the following fields:
  +	Field cars –  a collection that holds added cars.
  +	Field capacity – accessed only by the base class (responsible for the parking capacity).

Implement the following methods:

AddCar(Car Car)

The method first checks if there is already a car with the provided car registration number and if there is, the method returns the following message: _"Car with that registration number, already exists!"_

Next checks if the count of the cars in the parking is more than the capacity and if it is returns the following message: _"Parking is full!"_

Finally if nothing from the previous conditions is true it just adds the current car to the cars in the parking and returns the message: _"Successfully added new car {Make} {RegistrationNumber}"_

RemoveCar(string RegistrationNumber)

Removes a car with the given registration number. If the provided registration number does not exist returns the message: _"Car with that registration number, doesn't exist!"_

Otherwise, removes the car and returns the message: _"Successfully removed {registrationNumber}"_

GetCar(string RegistrationNumber)

Returns the Car with the provided registration number.

RemoveSetOfRegistrationNumber(List\<string> RegistrationNumbers)

A void method, which removes all cars that have the provided registration numbers. Each car is removed only if the registration number exists.

And the following property:
  +	Count - Returns the number of stored cars.

Example - this is an example how the Parking class is intended to be used:

| Sample code usage | 
| --------- | 
| var car = new Car("Skoda", "Fabia", 65, "CC1856BG"); <br> var car2 = new Car("Audi", "A3", 110, "EB8787MN"); <br> Console.WriteLine(car.ToString()); <br> //Make: Skoda <br> //Model: Fabia <br> //HorsePower: 65 <br> //RegistrationNumber: CC1856BG <br> var parking = new Parking(5); <br> Console.WriteLine(parking.AddCar(car)); <br> //Successfully added new car Skoda CC1856BG <br> Console.WriteLine(parking.AddCar(car)); <br> //Car with that registration number, already exists! <br> Console.WriteLine(parking.AddCar(car2)); <br> //Successfully added new car Audi EB8787MN <br> Console.WriteLine(parking.GetCar("EB8787MN").ToString()); <br> //Make: Audi <br> //Model: A3 <br> //HorsePower: 110 <br> //RegistrationNumber: EB8787MN <br> Console.WriteLine(parking.RemoveCar("EB8787MN")); <br> //Successfully removed EB8787MN <br> Console.WriteLine(parking.Count); //1 | 
