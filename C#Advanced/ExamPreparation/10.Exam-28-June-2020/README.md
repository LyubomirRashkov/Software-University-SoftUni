## PROBLEMS DESCRIPTION


### Problem 1.	Bombs
You will be given two sequence of integers, representing bomb effects and bomb casings.

You need to start from the first bomb effect and try to mix it with the last bomb casing. If the sum of their values is equal to any of the materials in the table below – create the bomb corresponding to the value and remove the both bomb materials. Otherwise, just decrease the value of the bomb casing by 5. You need to stop combining when you have no more bomb effects or bomb casings, or you successfully filled the bomb pouch.

Bombs:
  +	Datura Bombs: 40
  +	Cherry Bombs: 60
  +	Smoke Decoy Bombs: 120

To fill the bomb pouch, Ezio needs three of each of the bomb types.

Input
  +	On the first line, you will receive the integers representing the bomb effects, separated by ", ".
  +	On the second line, you will receive the integers representing the bomb casing, separated by ", ".

Output
  +	On the first line of output – print one of these rows according whether Ezio succeeded fulfill the bomb pouch:
    +	_"Bene! You have successfully filled the bomb pouch!"_
    +	_"You don't have enough materials to fill the bomb pouch."_
  +	On the second line - print all bomb effects left:
    +	If there are no bomb effects: _"Bomb Effects: empty"_
    +	If there are effects: _"Bomb Effects: {bombEffect1}, {bombEffect2}, (…)"_
  +	On the third line - print all bomb casings left:
    +	If there are no bomb casings: _"Bomb Casings: empty"_
    +	If there are casings: _"Bomb Casings: {bombCasing1}, {bombCasing2}, (…)"_
  +	Then, you need to print all bombs and the count you have of them, ordered alphabetically:
    +	_"Cherry Bombs: {count}"_
    +	_"Datura Bombs: {count}"_
    +	_"Smoke Decoy Bombs: {count}"_

Constraints
  +	All of the given numbers will be valid integers in the range [0, 120].
  +	Don't have situation with negative material.

Examples

| Input     | Output |
| --------- | -----|
| 5, 25, 50, 115 <br> 5, 15, 25, 35 | You don't have enough materials to fill the bomb pouch. <br> Bomb Effects: empty <br> Bomb Casings: empty <br> Cherry Bombs: 1 <br> Datura Bombs: 2 <br> Smoke Decoy Bombs: 1 |
| 30, 40, 5, 55, 50, 100, 110, 35, 40, 35, 100, 80 <br> 20, 25, 20, 5, 20, 20, 70, 5, 35, 0, 10 | Bene! You have successfully filled the bomb pouch! <br> Bomb Effects: 100, 80 <br> Bomb Casings: 20 <br> Cherry Bombs: 3 <br> Datura Bombs: 4 <br> Smoke Decoy Bombs: 3 |

### Problem 2.	Snake
You will be given an integer n for the size of the territory with square shape. On the next n lines, you will receive the rows of the territory. The snake will be placed on a random position, marked with the letter _'S'_. There will also be food on random positions, marked with '\*'. The territory may have lair. The lair will have two burrows marked with the letter - _'B'_. All of the empty positions will be marked with '-'.

Each turn, you will be given command for the snake’s movement. When the snake moves it leaves a trail marked with '.'

Move commands will be: _"up", "down", "left", "right"_.

If the snake moves to a food, it will eat the food, which will increase food quantity with one.

If it goes inside to a burrow, it goes out on the position of the other burrow and then both burrows disappear. If the snake goes out of its territory, the game is over. The snake needs at least 10 food quantity to be fed.

If the snake goes outside of its territory or has eaten enough food, the game should end.

Input
  +	On the first line, you are given the integer n – the size of the square matrix.
  +	The next n lines holds the values for every row.
  +	On each of the next lines you will get a move command.

Output
  +	On the first line:
    +	If the snake goes out of its territory, print: _"Game over!"_
    +	If the snake eat enough food, print: _"You won! You fed the snake."_
  +	On the second line print all food eaten: _"Food eaten: {food quantity}"_
  +	In the end print the matrix.

Constraints
  +	The size of the square matrix will be between [2…10].
  +	There will always be 0 or 2 burrows, marked with - _'B'_.
  +	The snake position will be marked with _'S'_.
  +	The snake will always either go out of its territory or eat enough food.
  +	There will be no case in which the snake will go through itself.

Examples

| Input     | Output |
| --------- | -----|
| 6 <br> -----S <br> ----B- <br> ------ <br> ------ <br> --B--- <br> --\*--- <br> left <br> down <br> down <br> down <br> left | Game over! <br> Food eaten: 1 <br> ----.. <br> ----.- <br> ------ <br> ------ <br> --.--- <br> --.--- |
| 7 <br> --\*\*\*S- <br> --\*---- <br> --\*\*\*-- <br> ---\*\*-- <br> ---\*--- <br> ---\*--- <br> ---\*--- <br> left <br> left <br> left <br> down <br> down <br> right <br> right <br> down <br> left <br> down | You won! You fed the snake. <br> Food eaten: 10 <br> --....- <br> --.---- <br> --...-- <br> ---..-- <br> ---S--- <br> ---\*--- <br> ---\*--- |

### Problem 3.	Parking
Your task is to create a repository, which stores items by creating the classes described below.

First, write a C# class Car with the following properties:
  +	Manufacturer: string
  +	Model: string
  +	Year: int

The class constructor should receive manufacturer, model and year and override the ToString() method in the following format: _"{manufacturer} {model} ({year})"_

Next, write a C# class Parking that has data (a collection, which stores the entity Car). All entities inside the repository have the same properties. Also, the Parking class should have those properties:
  +	Type: string
  +	Capacity: int

The class constructor should receive type and capacity, also it should initialize the data with a new instance of the collection. Implement the following features:
  +	Field data – collection that holds added cars
  +	Method Add(Car car) – adds an entity to the data if there is an empty cell for the car.
  +	Method Remove(string manufacturer, string model) – removes the car by given manufacturer and model, if such exists, and returns bool.
  +	Method GetLatestCar() – returns the latest car (by year) or null if have no cars.
  +	Method GetCar(string manufacturer, string model) – returns the car with the given manufacturer and model or null if there is no such car.
  +	Getter Count – returns the number of cars.
  +	GetStatistics() – returns a string in the following format:

_"The cars are parked in {parking type}:_

_{Car1}_

_{Car2}_

_(…)"_

Constraints
  +	The combinations of manufacturers and models will be always unique.
  +	The year of the cars will always be positive.
  +	There won't be cars with the same years.
