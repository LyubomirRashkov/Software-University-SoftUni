## PROBLEMS DESCRIPTION - INHERITANCE (Exercise)


### Problem 1.	Person
You are asked to model an application for storing data about people. You should be able to have a person and a child. The child derives from the person. Your task is to model the application. The only constraints are:
  +	People should not be able to have a negative age
  +	Children should not be able to have an age greater than 15.
  +	Person – represents the base class by which all of the others are implemented
  +	Child - represents a class, which derives from Person.

Note: Your class’s names MUST be the same as the names shown above!!!

Examples

| Input     | Output |
| --------- | -----|
| Peter <br> 12 | Name: Peter, Age: 13 |

### Problem 2.	Zoo
NOTE: You need a public class StartUp.

Create a project Zoo. It needs to contain the following classes: 
  + Animal;
    + Reptile - derives from Animal;
      + Lizard - derives from Reptile;
      + Snake - derives from Reptile;
    + Mammal - derives from Animal;
      + Gorilla - derives from Mammal;
      + Bear - derives from Mammal.
 
Each of the classes, except the Animal class, should inherit from another class. Every class should have:
  +	A constructor, which accepts one parameter: name. 
  +	Property Name - string.

### Problem 3.	Players and Monsters
NOTE: You need a public class StartUp.

Your task is to create the following game hierarchy: 
  + Hero;
    + Elf - derives from Hero;
      + MuseElf - derives from Elf;
    + Wizard - derives from Hero;
      + DarkWizard - derives from Wizard;
        + SoulMaster - derives from DarkWizard;
    + Knight - derives from Hero;
      + DarkKnight - derives from Knight;
        + BladeKnight - derives from DarkKnight.
 
Create a class Hero. It should contain the following members:
  +	A constructor, which accepts:
    +	username – string
    + level – int
  +	The following properties:
    +	Username - string
    +	Level – int
  + Override the ToString() method

### Problem 4.	Need for Speed
NOTE: You need a public class StartUp. Create the following hierarchy with the following classes:  
  + Vehicle;
    + Motorcycle - derives from Vehicle;
      + RaceMotorcycle - derives from Motorcycle;
      + CrossMotorcycle - derives form Motorcycle;
    + Car - derives from Vehicle;
      + FamilyCar - derives from Car;
      + SportCar - derives from Car.

Create a base class Vehicle. It should contain the following members:
  +	A constructor that accepts the following parameters: int horsePower, double fuel    
  +	DefaultFuelConsumption – double 
  +	FuelConsumption – virtual double
  +	Fuel – double
  +	HorsePower – int
  +	virtual void Drive(double kilometers)
    +	The Drive method should have a functionality to reduce the Fuel based on the traveled kilometers.

The default fuel consumption for Vehicle is 1.25. Some of the classes have different default fuel consumption values:
  +	SportCar – DefaultFuelConsumption = 10
  +	RaceMotorcycle – DefaultFuelConsumption = 8
  +	Car – DefaultFuelConsumption = 3

### Problem 5.	Restaurant
NOTE: You need a public class StartUp. Create a Restaurant project with the following classes and hierarchy: there are Food and Beverages in the restaurant, and they are all products. 

The Product class must have the following members:
  +	A constructor with the following parameters:
    +	Name – string
    +	Price – decimal

Beverage and Food classes are products. 

The Beverage class must have the following members:
  +	A constructor with the following parameters: string name, decimal price, double milliliters
    +	Reuse the constructor of the inherited class
  + Name – string
  +	Price – decimal
  +	Milliliters – double

HotBeverage and ColdBeverage are beverages and they accept the following parameters upon initialization: string name, decimal price, double milliliters. Reuse the constructor of the inherited class.

Coffee and Tea are hot beverages. The Coffee class must have the following additional members:
  +	double CoffeeMilliliters = 50
  +	decimal CoffeePrice = 3.50
  +	Caffeine – double

The Food class must have the following members:
  +	A constructor with the following parameters: string name, decimal price, double grams
    +	Name – string
    +	Price – decimal
    +	Grams – double

MainDish, Dessert and Starter are food. They all accept the following parameters upon initialization: string name, decimal price, double grams. Reuse the base class constructor.

Dessert must accept one more parameter in its constructor: double calories, and has a property:
  +	Calories

Make Fish, Soup and Cake inherit the proper classes. 

The Cake class must have the following default values:
  +	Grams = 250
  +	Calories = 1000
  +	CakePrice = 5

A Fish must have the following default values:
  +	Grams = 22

### Problem 6.	Animals
NOTE: You need a public class StartUp.

Create a hierarchy of Animals. Your program should have three different animals – Dog, Frog and Cat. Deeper in the hierarchy you should have two additional classes – Kitten and Tomcat. Kittens are female and Tomcats are male. All types of animals should be able to produce some kind of sound - ProduceSound(). For example, the dog should be able to bark. Your task is to model the hierarchy and test its functionality. Create an animal of each kind and make them all produce sound.

You will be given some lines of input. Every two lines will represent an animal. On the first line will be the type of animal and on the second – the name, the age and the gender. When the command _"Beast!"_ is given, stop the input and print all the animals in the format shown below.

Output
  +	Print the information for each animal on three lines. On the first line, print: _"{AnimalType}"_
  +	On the second line print: _"{Name} {Age} {Gender}"_
  +	On the third line print the sounds it produces: _"{ProduceSound()}"_

Constraints
  +	Each Animal should have a name, an age, and a gender
  +	All input values should not be blank (e.g. name, age, and so on…)
  +	If you receive an input for the gender of a Tomcat or a Kitten, ignore it but create the animal
  +	If the input is invalid for one of the properties, throw an exception with the message: _"Invalid input!"_
  +	Each animal should have the functionality to ProduceSound()
  +	Here is the type of sound each animal should produce:
    +	Dog: _"Woof!"_
    +	Cat: _"Meow meow"_
    +	Frog: _"Ribbit"_
    +	Kittens: _"Meow"_
    +	Tomcat: _"MEOW"_

Examples

| Input     | Output |
| --------- | -----|
| Cat <br> Tom 12 Male <br> Dog <br> Buddy 132 Male <br> Beast! | Cat <br> Tom 12 Male <br> Meow meow <br> Dog <br> Buddy 132 Male <br> Woof! |
| Frog <br> Jelly -2 Male <br> Frog <br> Bully 2 Male <br> Beast! | Invalid input! <br> Frog <br> Bully 2 Male <br> Ribbit |