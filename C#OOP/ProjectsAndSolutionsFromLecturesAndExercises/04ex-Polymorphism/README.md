## PROBLEMS DESCRIPTION - POLYMORPHISM (Exercise)


### Problem 1.	Vehicles
Write a program that models 2 vehicles (a Car and a Truck) and simulates driving and refueling them. Car and truck both have fuel quantity, fuel consumption in liters per km and can be driven a given distance and refueled with a given amount of fuel. Its summer, so both vehicles use air conditioners and their fuel consumption per km is increased by 0.9 liters for the car and with 1.6 liters for the truck. Also, the truck has a tiny hole in its tank and when it’s refueled it keeps only 95% of the given fuel. The car has no problems and adds all the given fuel to its tank. If a vehicle cannot travel the given distance, its fuel does not change.

Input
  +	On the first line – information about the car in the format: _"Car {fuel quantity} {liters per km}"_
  +	On the second line – info about the truck in the format: _"Truck {fuel quantity} {liters per km}"_
  +	On the third line – the number of commands N that will be given on the next N lines
  +	On the next N lines – commands in the format:
    +	_"Drive Car {distance}"_
    +	_"Drive Truck {distance}"_
    +	_"Refuel Car {liters}"_
    +	_"Refuel Truck {liters}"_

Output
  +	After each Drive command, if there was enough fuel, print on the console a message in the format:	_"Car/Truck travelled {distance} km"_
  +	If there was not enough fuel, print: _"Car/Truck needs refueling"_
  +	After the End command, print the remaining fuel for both the car and the truck, rounded to 2 digits after the floating point in the format:
    +	_"Car: {liters}"_
    +	_"Truck: {liters}"_

Examples

| Input     | Output |
| --------- | -----|
| Car 15 0.3 <br> Truck 100 0.9 <br> 4 <br> Drive Car 9 <br> Drive Car 30 <br> Refuel Car 50 <br> Drive Truck 10 | Car travelled 9 km <br> Car needs refueling <br> Truck travelled 10 km <br> Car: 54.20 <br> Truck: 75.00 |
| Car 30.4 0.4 <br> Truck 99.34 0.9 <br> 5 <br> Drive Car 500 <br> Drive Car 13.5 <br> Refuel Truck 10.300 <br> Drive Truck 56.2 <br> Refuel Car 100.2 | Car needs refueling <br> Car travelled 13.5 km <br> Truck needs refueling <br> Car: 113.05 <br> Truck: 109.12 |

### Problem 2.	Vehicles Extension
Use your solution of the previous task for the starting point and add more functionality. Add a new vehicle – Bus. Add to every vehicle a new property – tank capacity. A vehicle cannot start with or refuel above its tank capacity.

If you try to put more fuel in the tank than the available space, print on the console _"Cannot fit {fuel amount} fuel in the tank"_ and do not add any fuel in the vehicle’s tank. If you try to create a vehicle with more fuel than its tank capacity, create it but start with an empty tank.

Add a new command for the bus. You can drive the bus with or without people. With people, the air-conditioner is turned on and its fuel consumption per kilometer is increased by 1.4 liters. If there are no people in the bus, the air-conditioner is turned off and does not increase the fuel consumption.

Finally, add a validation for the amount of fuel given to the Refuel command – if it is 0 or negative, print _"Fuel must be a positive number"_.

Input
  +	On the first three lines you will receive information about the vehicles in the format: _"Vehicle {initial fuel quantity} {liters per km} {tank capacity}"_
  +	On the fourth line – the number of commands N that will be given on the next N lines
  +	On the next N lines – commands in format:
    +	_"Drive Car {distance}"_
    +	_"Drive Truck {distance}"_
    +	_"Drive Bus {distance}"_
    +	_"DriveEmpty Bus {distance}"_
    +	_"Refuel Car {liters}"_
    +	_"Refuel Truck {liters}"_
    +	_"Refuel Bus {liters}"_

Output
  +	After each Drive command, if there was enough fuel, print on the console a message in the format:	_"Car/Truck/Bus travelled {distance} km"_
  +	If there was not enough fuel, print: _"Car/Truck/Bus needs refueling"_
  +	If you try to refuel with an amount ≤ 0 print: _"Fuel must be a positive number"_
  +	If the given fuel cannot fit in the tank, print: _"Cannot fit {fuel amount} fuel in the tank"_
  +	After the End command, print the remaining fuel for all vehicles, rounded to 2 digits after the floating point in the format:

  _"Car: {liters}"_
  
  _"Truck: {liters}"_
  
  _"Bus: {liters}"_
  
Example

| Input     | Output |
| --------- | -----|
| Car 30 0.04 70 <br> Truck 100 0.5 300 <br> Bus 40 0.3 150 <br> 8 <br> Refuel Car -10 <br> Refuel Truck 0 <br> Refuel Car 10 <br> Refuel Car 300 <br> Drive Bus 10 <br> Refuel Bus 1000 <br> DriveEmpty Bus 100 <br> Refuel Truck 1000 | Fuel must be a positive number <br> Fuel must be a positive number <br> Cannot fit 300 fuel in the tank <br> Bus travelled 10 km <br> Cannot fit 1000 fuel in the tank <br> Bus needs refueling <br> Cannot fit 1000 fuel in the tank <br> Car: 40.00 <br> Truck: 100.00 <br> Bus: 23.00 |

### Problem 3.	Raiding
Your task is to create a class hierarchy like the described below. The BaseHero class should be abstract.
  +	BaseHero – string Name, int Power, string CastAbility()
    +	Druid – power = 80
    +	Paladin – power = 100
    + Rogue – power = 80
    + Warrior – power = 100

Each hero should override the CastAbility() method:
  + Druid – _"{Type} – {Name} healed for {Power}"_
  + Paladin – _"{Type} – {Name} healed for {Power}"_
  + Rogue – _"{Type} – {Name} hit for {Power} damage"_
  + Warrior – _"{Type} – {Name} hit for {Power} damage"_

Now use the classes you created to form a raid group and defeat a boss. You will receive an integer N from the console. On the next lines you will receive {heroName} and {heroType} until you create N amount of heroes. If the hero type is invalid print: _"Invalid hero!"_ and don’t add it to the raid group. After the raid group is formed you will receive an integer from the console which will be the boss’s power. Then each of the heroes in the raid group should cast his ability once. You should sum the power of all of the heroes and if the total power is greater or equal to the boss’s power you have defeated him and you should print: _"Victory!"_, else print: _"Defeat..."_

Constraints

You need to create heroes until you have N amount of valid heroes.

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> Mike <br> Paladin <br> Josh <br> Druid <br> Scott <br> Warrior <br> 250 | Paladin - Mike healed for 100 <br> Druid - Josh healed for 80 <br> Warrior - Scott hit for 100 damage <br> Victory! |
| 2 <br> Mike <br> Warrior <br> Tom <br> Rogue <br> 200 | Warrior - Mike hit for 100 damage <br> Rogue - Tom hit for 80 damage <br> Defeat... |

### Problem 4.	Wild Farm
Your task is to create a class hierarchy like the described below. The Animal, Bird, Mammal, Feline and Food classes should be abstract. Override the method ToString().

Food – int Quantity;
  +	Vegetable;
  +	Fruit;
  +	Meat;
  +	Seeds;

Animal – string Name, double Weight, int FoodEaten;
  +	Bird – double WingSize;
    +	Owl;
    +	Hen;
  +	Mammal – string LivingRegion;
    +	Mouse;
    +	Dog;
    +	Feline – string Breed;
        +	Cat;
        +	Tiger;

All animals should also have the ability to ask for food by producing a sound.
  +	Owl – _"Hoot Hoot"_;
  +	Hen – _"Cluck"_;
  +	Mouse – _"Squeak"_;
  +	Dog – _"Woof!"_;
  +	Cat – _"Meow"_;
  +	Tiger – _"ROAR!!!"_;

Now use the classes that you have created to instantiate some animals and feed them.

Input should be read from the console: 
  + Every even line (starting from 0) will contain information about an animal in the following format:
    +	Felines - _"{Type} {Name} {Weight} {LivingRegion} {Breed}"_;
    +	Birds - _"{Type} {Name} {Weight} {WingSize}"_;
    +	Mice and Dogs - _"{Type} {Name} {Weight} {LivingRegion}"_;
  + On the odd lines, you will receive information about a piece of food that you should give to that animal. The line will consist of a FoodType and quantity, separated by a whitespace.

Animals will only eat a certain type of food, as follows:
  +	Hens eat everything;
  +	Mice eat vegetables and fruits;
  +	Cats eat vegetables and meat;
  +	Tigers, Dogs and Owls eat only meat;

If you try to give an animal a different type of food, it will not eat it and you should print: _"{AnimalType} does not eat {FoodType}!"_

The weight of an animal will increase with every piece of food it eats, as follows:
  +	Hen – 0.35;
  +	Owl – 0.25;
  +	Mouse – 0.10;
  +	Cat – 0.30;
  +	Dog – 0.40;
  +	Tiger – 1.00;

Override the ToString() method to print the information about an animal in the formats:
  +	Birds – _"{AnimalType} [{AnimalName}, {WingSize}, {AnimalWeight}, {FoodEaten}]"_
  +	Felines – _"{AnimalType} [{AnimalName}, {Breed}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"_
  +	Mice and Dogs – _"{AnimalType} [{AnimalName}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"_

After you have read the information about the animal and the food, the animal will produce a sound (print it on the console). Next, you should try to feed it. After receiving the _"End"_ command, print information about every animal in order of input.

Examples

| Input     | Output |
| --------- | -----|
| Cat Sammy 1.1 Home Persian <br> Vegetable 4 <br> End | Meow <br> Cat [Sammy, Persian, 2.3, Home, 4] |
| Tiger Rex 167.7 Asia Bengal <br> Vegetable 1 <br> Dog Tommy 500 Street <br> Vegetable 150 <br> End | ROAR!!! <br> Tiger does not eat Vegetable! <br> Woof! <br> Dog does not eat Vegetable! <br> Tiger [Rex, Bengal, 167.7, Asia, 0] <br> Dog [Tommy, 500, Street, 0] |