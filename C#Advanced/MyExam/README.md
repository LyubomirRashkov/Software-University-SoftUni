## PROBLEMS DESCRIPTION


### Problem 1.	Bakery Shop
Create a program that calculates the ratio between water and flour for predefined bakery products.

You will be given two sequences of real numbers, representing water and flour.

You should start from the first water and mix it with the last flour. If the ratio of water/flour corresponds to some of the following bakery products:
  +	Croissant – consists of 50% water and 50% flour
  +	Muffin – consists of 40% water and 60% flour
  +	Baguette – consists of 30% water and 70% flour
  +	Bagel – consists of 20% water and 80% flour 

Create the corresponding bakery product and remove both the water and the flour from each collection.

If none of the products could be made, you should create the best-selling bakery product which is Croissant. To bake a Croissant, take only so much flour to meet the required ratio of 50% water and 50% flour. The water is removed, and all the excessive flour should be inserted back into the collection. You should stop mixing when you have no more flour or water left.

As a result, you should print two lines for output
  +	On the first line print all the products which were baked ordered by amount baked descending, then by name of the products alphabetically. 
  +	On the second line print how much water and flour have left.

Input
  +	On the first line, you will receive a sequence of real numbers representing the amount of water, separated by a single space (" ").
  +	On the second line, you will receive a sequence of real numbers representing the flour, separated by a single space (" ").

Output
  +	On the first line print only products which were baked successfully and how many of them, ordered by amount baked descending, then by product name alphabetically:

  _"{product name}: {amount baked}_
  
  _{product name}: {amount baked}_
  
  _…"_
  +	On the second line - print all water you have left:
    +	If there is no water: _"Water left: None"_
    +	If there are water left unused: _"Water left: { water1}, { water2}, { water3}, (…)"_
  +	On the third line - print all flour you have left:
    +	If there is no flour: _"Flour left: None"_
    +	If there are flour left unused: _"Flour left: { flour1}, { flour2}, { flour3}, (…)"_

Constraints
  +	All numbers will be in rage [1.0…100.0].
  +	The input will be always valid.
  +	The flour will never go below zero.

Examples

| Input     | Output |
| --------- | -----|
| 16.8 32.4 19.5 25 <br> 15 30 45.5 48.6 25.2 | Muffin: 2 <br> Baguette: 1 <br> Croissant: 1 <br> Water left: None <br> Flour left: 5, 15 |
| 10 20 12 14 30.2 <br> 30.2 56 48 30 10 | Bagel: 2 <br> Croissant: 2 <br> Muffin: 1 <br> Water left: None <br> Flour left: None |

### Problem 2.	Beaver at Work
You will receive an integer n for the size of the pond with a square shape. On the next n lines, you will receive the matrix, which represents the pond.

The Beaver will be placed in a random cell, marked with the letter _'B'_. Each cell stands for a place where the beaver can move. If the cell is marked with а lowercase character, that means there is a wood branch. If the cell is marked with _'F'_, the beaver catch and eats a fish. All of the empty positions will be marked with a _'-'_ (dash).

The Beaver can move _"up"_, _"down"_, _"left"_, and _"right"_. These will be the commands that you'll receive. Anytime the beaver moves, change the value of the cell of his new position to _'B'_ and the cell it left to _'-'_ (dash).
  +	If the beaver moves to a wood branch it puts it away for his new home.
  +	If the beaver moves outside of the pond (field), he drops his last collected wood branch (if there are any), without changing its current position.
  +	If the beaver moves to _'F'_, he eats a fish and gains the strength to swim underwater for a very long time.
    +	If the fish is NOT located in the last index, the beaver swims to the last index in the direction it received. 
    
    Еxample: If the beaver is located on [0;0] and moves right, eats a fish in [0;1], he swims all the way right to the column's last position, [0;lastIndex] (row remains the same). 
    +	 If the braver is eats a fish on the last index – it swims in the opposite direction. Opposite of _"up"_ is _"down"_, opposite of _"left"_ is _"right"_ and vice versa. Set the value of the fish's cell to _'-'_ (dash). If there is a wood branch at the cell the beaver swims to, it collects the wood branch. While swimming underwater, the beaver does not collect any wood branches.
    
    Еxample: If the beaver moves up, and eats a fish in [0;0], he can't swim all the way up, so he swims all the way down to the row's last position, [lastIndex;0] (column remains the same).
    
When the command _"end"_ is received or the beaver manages to collect all the wood branches, stop the program, and print the result in the format below.

Input
  +	On the first line – integer n – the size of the pond (field).
  +	The next n lines hold the values for every row.
  +	On each of the next lines, you will receive a command.

Output
  +	If the Beaver manages to collect all wood branches in the pond, print: _"The Beaver successfully collect {numberOfbranches} wood branches: {branch1}, {branch2}, {branch3}(…)."_
  +	If the Beaver could not collect every branch in the pond, print: _"The Beaver failed to collect every wood branch. There are {numberOfbranches} branches left."_
  +	Then print the last state of the pond.

Constraints
  +	The size of the square matrix will be between [2…15].
  +	The Beaver's position will be marked with _'B'_.
  +	The fish will be marked with _'F'_.
  +	Wood branches will be smaller case letters from the English alphabet (a - z).
  +	There will be no case where the Beaver will move to a fish two consecutive times.

Examples

| Input     | Output |
| --------- | -----|
| 4 <br> - F e - <br> - B F y <br> - - - q <br> - - z x <br> up <br> right <br> right <br> right <br> up <br> end | The Beaver failed to collect every wood branch. There are 2 branches left. <br> - - e - <br> - - F y <br> - - - B <br> - - - - |
| 3 <br> - - - <br> B F - <br> d b m <br> down <br> left <br> right <br> right <br> right | The Beaver successfully collect 2 wood branches: b, m. <br> - - - <br> - F - <br> - - B |

### Problem 3.	Fishing Net
#### Preparation
Download the skeleton provided in Judge. Do not change the StartUp class or its namespace.
####  Problem description
##### Fish
You are given a class Fish, create the following fields:
  +	FishType: string
  +	Length: double
  +	Weight: double

The class constructor should receive fish type, length, and weight. 

The class should also have a method:
  +	Override the ToString() method in the format: _"There is a {fishType}, {length} cm. long, and {weight} gr. in weight."_

##### Net
Next, a class named Net is given that has a collection (fish) of type Fish. The name of the collection should be Fish, which could not be modified. All the entities of the Fish collection have the same properties. The Net also has some additional properties:
  +	Material: string
  +	Capacity: int

The constructor of the Net class should receive the material, and capacity.

Implement the following features:
  +	Getter Count - returns the total count of the fish in the net.
  +	string AddFish(Fish fish) - adds a Fish to the fish's collection if there is room for it. Before adding a fish, check:
    +	If the fish type is null or whitespace.
    +	If the fish’s length or weight is zero or less.

If the fish type, length, or weight properties are not valid, return: _"Invalid fish."_. If the net is full (there is no room for more fish), return _"Fishing net is full."_. Otherwise, return: _"Successfully added {fishType} to the fishing net."_
  +	bool ReleaseFish(double weight) – removes a fish by given length, if such exists return true, otherwise false.
  +	Fish GetFish(string fishType) – search and returns a fish by given fish type.
  +	Fish GetBiggestFish()– search and returns the longest fish in the collection.
  +	Report() - returns information about the Net and all fish that were not released, order by fish's length descending  in the following format:	
  	_"Into the {material}:_

    _{Fish1}_
    
    _{Fish2}_
    
    _(…)"_

Note: Do not use _"\n\r"_ for a new line. 

Constraints
  +	You will always have a fish added before receiving methods that manipulate the fish in the Net.