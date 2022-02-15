## PROBLEMS DESCRIPTION


### Problem 1.	Birthday Celebration
You will be given a sequence of integers – each indicating the eating capacity of a single guest. After that you will be given another sequence of integers - the plates. Your job is to make sure everyone is full, so you decide to serve them yourself.

Serving is done exactly one plate at a time. You must start picking from the last stacked plate and start serving from the first entered guest. If the current plate has N grams of food, you give the first entered guest N grams and reduce its integer value by N.

When a guest's integer value reaches 0 or less, it gets removed. It is possible that the current guest's value is greater than the current food's value. In that case you pick plates until you reduce the guest's integer value to 0 or less. If a plate's value is greater or equal to the guest's current value, you fill up the guest and the remaining food becomes wasted. You should keep track of the wasted grams of food and print it at the end of the program. 

If you have managed to fill up all of the guests, print the remaining prepared plates of food, from the last entered – to the first, otherwise you must print the remaining guests, by order of entrance – from the first entered – to the last. 

Input
  +	On the first line of input you will receive the integers, representing the guests' capacity, separated by a single space. 
  +	On the second line of input you will receive the integers, representing the prepared plates of food, separated by a single space.

Output
  +	On the first line of output you must print the remaining plates, or the remaining guests, depending on the case you are in. Just keep the orders of printing exactly as specified: _"Plates: {remainingPlates}"_ or _"Guests: {remainingGuests}"_
  +	On the second line print the wasted grams of food in the following format: _"Wasted grams of food: {wastedGramsOfFood}"_

Constraints
  +	All of the given numbers will be valid integers in the range [1, 500].
  +	It is safe to assume that there will be NO case in which the food is exactly as much as the guests' values, so that at the end there are no guests and no food on the plates.
  +	Allowed time/memory: 100ms/16MB.

Examples

| Input     | Output |
| --------- | -----|
| 4 2 10 5 <br> 3 15 15 11 6 | Plates: 3 <br> Wasted grams of food: 26 |
| 10 20 30 40 50 <br> 20 11 | Guests: 30 40 50 <br> Wasted grams of food: 1 |

### Problem 2.	The Battle of the Five Armies
A standard map of the Middle World looks like this:

| The Middle World     | Legend |
| --------- | -----|
| ------M--- <br> -------O-- <br> --O------- <br> ---------- <br> -----A---- | A - The Army, the player character <br> O - Orcs, enemy <br> M - Mordor <br> - - Empty space |

Each turn proceeds as follows:
  +	First, Orcs spawn on the given index.
  +	Then, the army moves in a direction, which decreases their armor by 1.
    +	It can be _“up”, “down”, “left”, “right”_
    +	If the army tries to move outside of the field, they don't move but still has their energy decreased.
  +	If an enemy is on the same cell where the army moves, the army fights him, which decreases their armor by 2. If the army’s armor drops at 0 or below, they die and you should mark this position with _‘X’_.
  +	If the army kills the enemy successfully, the enemy disappears.
  + If the army reaches the index where Mordor is, they win the war (disappear from the field), even if their armor is 0 or below.

Input
  +	On the first line of input, you will receive e – the armor the army has.
  +	On the second line of input, you will receive n – the number of rows the map of the Middle World will consist of. Range: [5-20]
  +	On the next n lines, you will receive how each row looks.
  +	Then, until the army dies, or reaches the throne, you will receive a move command and spawn row and column.

Output
  +	If the army is runs out of armor, print _"The army was defeated at {row};{col}."_
  +	If the army reaches Mordor, print _"The army managed to free the Middle World! Armor left: {armor}"_
  +	Then, in all cases, print the final state of the map on the console.

Constraints
  +	The map will always be rectangular.
  +	The army will always run out of armor or reach Mordor.
  +	There will be no case with spawn on invalid index.
  +	There will be no case with two enemies on the same cell.
  +	There will be no case with enemy spawning on the index where the army or Mordor is.

Examples

| Input     | Output |
| --------- | -----|
| 100 <br> 5 <br> --M-- <br> ----- <br> ----- <br> ----- <br> --A-- <br> up 3 0 <br> up 3 1 <br> up 3 2 <br> up 3 3 | The army managed to free the Middle World! Armor left: 96 <br> ----- <br> ----- <br> ----- <br> OOOO- <br> ----- |
| 3 <br> 5 <br> --М-- <br> ----- <br> ----- <br> ----- <br> --A-- <br> up 3 2 | The army was defeated at 3;2. <br> --М-- <br> ----- <br> ----- <br> --X-- <br> ----- |

### Problem 3.	Street Racing
Your task is to create a race in which participate different cars.

First, write a C# class, called Car with properties:
  +	Make: string
  +	Model: string
  +	LicensePlate: string
  +	HorsePower: int
  +	Weight: double

The constructor of Car class should receive make, model, licensePlate, horsePower and weight.

The class should also have the following methods:
  +	Override ToString() method in the format:

_"Make: {Make}_

 _Model: {Model}_
 
 _License Plate: {LicensePlate}_
 
 _Horse Power: {HorsePower}_
 
 _Weight: {Weight}"_
 
Next step is to write Race class that has a collection of type Car with corresponding unique License Plate of a Car. The name of the collection should be Participants. All the entities of the Participants collection have the same properties. The Race has also some additional properties:
  +	Name: string
  +	Type: string
  +	Laps: int
  +	Capacity: int - the maximum allowed number of participants in the race
  +	MaxHorsePower: int - the maximum allowed Horse Power of a Car in the Race

The constructor of the Race class should receive name, type, laps, capacity and maxHorsePower.

Implement the coming features:
  +	Getter Count - returns the count of the currently enrolled participants
  +	Method Add(Car car) - adds the entity if there isn't a Car with the same License plate and if there is enough space in terms of race capacity and if the car meets the maximum horse power requirment of the race.
  +	Method Remove(string licensePlate) - removes a Car from the race with the given License plate, if such exists and returns bool if the deletion is successful.
  +	Method FindParticipant(string licensePlate) - returns a Car with the given License plate. If it doesn't exist, return null.
  +	Method GetMostPowerfulCar() – returns the Car with most HorsePower. If there are no Cars in the Race, method should return null. 
  +	Method Report() - returns information about the Race and the Cars participating it in the following format:

_"Race: {Name} - Type: {Type} (Laps: {Laps})_

_{Car1}_

_{Car2}_

_… "_

Constraints
  +	The License plate of each Car in the race will always be unique
  +	The HorsePower of a Car and the MaxHorsePower of the Race will always be positive numbers
  +	There will not be a case where two Cars have the same HorsePower
  +	You will always be given Car added before receiving method for its manipulation 
