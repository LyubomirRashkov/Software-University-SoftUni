## PROBLEMS DESCRIPTION


### Problem 1.	Blacksmith
First, you will be given a sequence representing steel. Afterward, you will be given another sequence representing carbon.

You should start from the first steel and try to mix it with the last carbon. If the sum of their values is equal to any of the swords in the table below you should forge the sword corresponding to the value and remove both the steel and the carbon. Otherwise, remove only the steel, increase the value of the carbon by 5 and insert it back into the collection. You need to stop forging when you have no more steel or carbon left.

| Sword     | Resources needed |
| --------- | -----|
| Gladius | 70 |
| Shamshir | 80 |
| Katana | 90 |
| Sabre | 110 |
| Broadsword | 150 |

Forge as many swords as possible.

Input
  +	On the first line, you will receive the steel, separated by a single space (" "). 
  +	On the second line, you will receive the carbon, separated by a single space (" ").

Output
  +	On the first line of output depending on the result:
    +	If at least one sword was forged: _"You have forged {totalNumberOfSwords} swords."_
    +	If no sword was forged: _"You did not have enough resources to forge a sword."_
  +	On the second line - print all steel you have left:
    +	If there are no steel: _"Steel left: none"_
    +	If there are steel: _"Steel left: {steel1}, {steel2}, {steel3}, (…)"_
  +	On the third line - print all carbon you have left:
    +	If there are no carbon: _"Carbon left: none"_
    +	If there are carbon: _"Carbon left: {carbon1}, {carbon2}, {carbon3}, (…)"_
  +	Then, you need to print only the swords that you manage to forge and how many of them, ordered alphabetically:
    +	_"Broadsword: {amount}"_
    +	_"Sabre: {amount}"_
    +	_"Katana: {amount}"_
    +	_"Shamshir: {amount}"_
    +	_"Gladius: {amount}"_

Constraints
  +	All of the given numbers will be valid resources in the range [0, 130].

Examples

| Input     | Output |
| --------- | -----|
| 40 50 70 120 10 20 <br> 30 20 30 20 30 50 | You have forged 4 swords. <br> Steel left: none <br> Carbon left: 30, 30 <br> Broadsword: 1 <br> Katana: 2 <br> Shamshir: 1 |
| 10 5 30 <br> 30 20 10 | You did not have enough resources to forge a sword. <br> Steel left: none <br> Carbon left: 25, 20, 30 |

### Problem 2.	Armory
You will be given an integer n for the size of the armory with a square shape. On the next n lines, you will receive the rows of the armory. The army officer will be placed in a random position, marked with the letter _'A'_. On random positions, there will be swords, marked with a single digit (the price of the sword). There may also be mirrors, the count will be either 0 or 2 and they are marked with the letter - _'M'_. All of the empty positions will be marked with '-'.

Each turn, you will tell the army officer which direction he should move. Move commands will be: _"up", "down", "left", "right"_. If the army officer moves to a sword, he buys the sword for a price equal to the digit there and the sword disappears. If the army officer moves to a mirror, he teleports on the position of the other mirror, and then both mirrors disappear. If you guide the army officer out of the armory, he leaves with the swords that he has bought. In advance, you negotiate with the king, that he'll buy at least 65 gold coins worth of blades.

The program ends when the army officer buys blades for at least 65 gold coins, or you guide him out of the armory.

Input
  +	On the first line, you are given the integer n – the size of the matrix (armory).
  +	The next n lines hold the values for every row.
  +	On each of the next lines, you will get a move command.

Output
  +	On the first line:
    +	If the army officer leaves the armory, print: _"I do not need more swords!"_
    +	If the army officer fulfills the initial deal, print: _"Very nice swords, I will come back for more!"_
  +	On the second line print the profit you’ve made: _"The king paid {amount} gold coins."_
  +	At the end print the final state of the matrix (armory).

Constraints
  +	The size of the square matrix (armory) will be between [2…10].
  +	There will always be 0 or 2 mirrors, marked with the letter - _'M'_.
  +	The army officer’s position will be marked as _'A'_.
  +	There will be always two output scenarios: the army officer leaves or buys swords worth at least 65 gold coins.
  	
Examples

| Input     | Output |
| --------- | -----|
| 4 <br> A9-- <br> -M-- <br> ---- <br> M--- <br> right <br> down <br> left | I do not need more swords! <br> The king paid 9 gold coins. <br> ---- <br> ---- <br> ---- <br> ---- |
| 6 <br> A99--- <br> 99---- <br> 99996- <br> ---9-- <br> ---9-- <br> -6-6-- <br> right <br> right <br> down <br> left <br> left <br> down <br> right <br> right <br> right | Very nice swords, I will come back for more! <br> The king paid 72 gold coins. <br> ------ <br> ------ <br> ---A6- <br> ---9-- <br> ---9-- <br> -6-6-- |

### Problem 3.	Drones
Your task is to create an airfield where drones can take of and land.

You are given a class Drone,  create the following fields:
  +	Name: string
  +	Brand: string
  +	Range: int
  +	Available: boolean - true by default

The class constructor should receive (name, brand, range). 

The class should also have a method:
  +	Override the ToString() method in the format:

_"Drone: {name}_

_Manufactured by: {brand}_

_Range: {range} kilometers"_

Next, a class named Airfield is given that has a collection (drones) of type Drone. The name of the collection should be Drones. All the entities of the Drones collection have the same properties. The Airfield has also some additional properties:
  +	Name: string
  +	Capacity: int
  +	LandingStrip - double

The constructor of the Airfield class should receive the name, capacity, and landing strip.

Implement the following features:
  +	Getter Count - returns the count of the drones in the airfield.
  +	string AddDrone(Drone drone) - adds a drone to the drone's collection if there is room for it. Before adding a drone, check:
    +	If the name or brand are null or empty.
    +	If the range is NOT between 5-15 kilometers.
    + If the name, brand, or range properties are not valid, return: _"Invalid drone."_. If the airfield is full (there is no room for more drones), return _"Airfield is full."_. Otherwise, return: _"Successfully added {droneName} to the airfield."_
  +	bool RemoveDrone(string name) - removes a drone by given name, if such exists return true, otherwise false.
  +	int RemoveDroneByBrand(string brand) - removes all drones by the given brand, if such exists, return how many drones were removed, otherwise 0.
  +	Drone FlyDrone(string name) method – fly (set its available property to false without removing it from the collection) the drone with the given name if exists. As a result return the drone, or null if does not exist.
  +	List\<Drone> FlyDronesByRange(int range) method - fly and returns all drones which have a range equal or bigger to the given. Return a list of all drones which have been flown. The range will always be valid.
  +	Report() - returns information about the airfield and drones which are not in flight in the following format:	

_"Drones available at {airfieldName}:_

_{Drone1}_

_{Drone2}_

_(…)"_

Note: Do not use _"\n\r"_ for a new line. 

Constraints
  +	The names of the drones will be always unique.
  +	You will always have a drone added before receiving methods manipulating the Airfield’s drones.
