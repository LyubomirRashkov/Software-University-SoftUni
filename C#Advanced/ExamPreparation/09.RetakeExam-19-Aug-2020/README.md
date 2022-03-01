## PROBLEMS DESCRIPTION


### Problem 1.	Flower Wreaths
You will be given two sequences of integers, representing roses and lilies. You need to start making wreaths knowing that one wreath needs 15 flowers. Your goal is to make at least 5 flower wreaths.

You will start crafting from the last lilies and the first roses. If the sum of their values is equal to 15 – create one wreath and remove them. If the sum is bigger than 15, just decrease the value of the lilies by 2. If the sum is less than 15 you have to store them for later and remove them. You need to stop combining when you have no more roses or lilies. In the end, if you have any stored flowers you should make as many wreaths as you can with them. 

Input
  +	On the first line, you will receive the integers representing the lilies, separated by ", ".
  +	On the second line, you will receive the integers representing the roses, separated by ", ".

Output
  +	Print whether you have succeeded making at least 5 wreaths:
    +	_"You made it, you are going to the competition with {count of wreaths} wreaths!"_ 
    +	_"You didn't make it, you need {wreaths needed} wreaths more!"_

Constraints
  +	All of the given numbers will be valid integers in the range [0, 120].
  +	Don't have situation with negative number.

Examples

| Input     | Output |
| --------- | -----|
| 10, 15, 2, 7, 9, 13 <br> 2, 10, 8, 12, 0, 5 | You made it, you are going to the competition with 5 wreaths! |
| 10, 5, 3, 7, 8 <br> 5, 10, 8, 7, 6 | You didn't make, you need 1 wreaths more! |

### Problem 2.	Bee
You will be given an integer n for the size of the bee territory with square shape. On the next n lines, you will receive the rows of the territory. The bee will be placed on a random position, marked with the letter _'B'_. On random positions there will be flowers, marked with _'f'_. There may also be а bonus on the territory. There will always be only one bonus. It will be marked with the letter - _'O'_. All of the empty positions will be marked with '.'.

Each turn, you will be given a command for the bee’s movement. The commands will be: _"up", "down", "left", "right", "End"_.

If the bee moves to a flower, it pollinates the flower and increases the pollinated flowers with one.

If it goes to a bonus, the bee gets a bonus one move forward and then the bonus disappears. If the bee goes out she can't return back and the program ends. If the bee receives the _"End"_ command the program ends. The bee needs at least 5 pollinated flowers.

Input
  +	On the first line, you are given the integer n – the size of the square matrix.
  +	The next n lines hold the values for every row.
  +	On each of the next lines, until you receive _"End"_ command,  you will receive a move command.

Output
  +	On the first line:
    +	If the bee goes out of its territory print: _"The bee got lost!"_
  +	On the second line:
    +	 If the bee couldn’t pollinate enough flowers, print: _"The bee couldn't pollinate the flowers, she needed {needed} flowers more"_
    +	If the bee successfully pollinated enough flowers, print: _"Great job, the bee managed to pollinate {polinationed flowers} flowers!"_
  +	In the end print the matrix.

Constraints
  +	The size of the square matrix will be between [2…10].
  +	There will always be 0 or 1 bonus, marked with - _'O'_.
  +	The bee position will be marked with _'B'_.
  +	There won't be a case where a bonus moves the bee out of its territory.

Examples

| Input     | Output |
| --------- | -----|
| 5 <br> Bff.. <br> ..O.. <br> f.f.f <br> ..... <br> fffff <br> right <br> right <br> down <br> left <br> left <br> down <br> down <br> right <br> down | The bee got lost! <br> Great job, the bee managed to pollinate 6 flowers! <br> ..... <br> ..... <br> ....f <br> ..... <br> ..fff |
| 4 <br> .... <br> .O.. <br> ff.. <br> f.B. <br> left <br> left <br> up <br> right <br> up <br> End | The bee couldn't pollinate the flowers, she needed 2 flowers more <br> .B.. <br> .... <br> .... <br> .... |

### Problem 3.	Vet Clinic
Your task is to create a repository, which stores items by creating the classes described below.

First, write a C# class Pet with the following properties:
  +	Name: string
  +	Age: int
  +	Owner: string

The class constructor should receive name, age and owner. The class should override the ToString() method in the following format: _"Name: {Name} Age: {Age} Owner: {Owner}"_

Next, write a C# class Clinic that has data (a collection, which stores the Pets). All entities inside the repository have the same properties. Also, the Clinic class should have those properties:
  +	Capacity: int

The class constructor should receive capacity, also it should initialize the data with a new instance of the collection. Implement the following features:
  +	Field data – collection that holds added pets
  +	Method Add(Pet pet) – adds an entity to the data if there is an empty cell for the pet.
  +	Method Remove(string name) – removes the pet by given name, if such exists, and returns bool.
  +	Method GetPet(string name, string owner) – returns the pet with the given name and owner or null if no such pet exists.
  +	Method GetOldestPet() – returns the oldest Pet.
  +	Getter Count – returns the number of pets.
  +	GetStatistics() – returns a string in the following format:

_"The clinic has the following patients:_

_Pet {Name} with owner: {Owner}_

_Pet {Name} with owner: {Owner}_

_(…)"_

Constraints
  +	The combinations of names and owners will always be unique.
  +	The age of the pets will always be positive.
