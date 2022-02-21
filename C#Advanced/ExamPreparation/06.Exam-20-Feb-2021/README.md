## PROBLEMS DESCRIPTION


### Problem 1.	The Fight for Gondor
First, you will be given a number equal to the waves of orcs. On the second line you will be given the plates of the Aragorn's defense. Then, on each next line (for each wave), you receive the power of each orc warrior. Additionally, on every third wave, the people build a new plate (extra line with a single integer) before the Sauron's warriors attack. In order to enter the city, the orcs have to destroy all the plates.

Until there are no more plates or orcs, the last orc warrior attacks the first plate:
  +	If the warrior's value is greater, he destroys the plate and lowers his value by the plate's value, then attacks the next plate, until his value reaches 0.
  +	If the plate's value is greater, the warrior dies and the plate decreases its value by the warrior's value.
  +	If their values are equal, the warrior dies and the plate is destroyed.

Input
  +	First line: integer - the number of waves
  +	Second line: integers, representing the plates, separated by a single space.
  +	For each wave: integers, representing the warrior orcs, separated by a single space.
    +	On every third wave, you will be given an extra line with a single integer, which will be the plate you need to add. [!] Add the plate before processing the attacks. [!]

Output
  +	On the first line of output – print if the orcs destroyed the Gondor's defense:
    +	True: _"The orcs successfully destroyed the Gondor's defense."_
    +	False: _"The people successfully repulsed the orc's attack."_
  +	On the second line - print all plates or orcs left, separated by comma and a white space:
    +	If there are warriors: _"Orcs left: {orc1}, {orc2}, {orc3}, …"_
    +	If there are plates: _"Plates left: {plate1}, {plate2}, {plate3}, …"_

Constraints
  +	All of the given numbers will be valid integers in the range [1, 100].
  +	Not all waves may be needed to destroy the defense.
  +	There will always be a winning side, meaning either no orcs or plates left. 

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> 10 20 30 <br> 4 5 1 <br> 10 5 5 <br> 10 10 10 <br> 4 | The people successfully repulsed the orc's attack. <br> Plates left: 4 |
| 5 <br> 10 30 10 <br> 3 3 4 <br> 10 10 10 <br> 5 5 <br> 5 <br> 7 6 <br> 8 6 7 | The orcs successfully destroyed the Gondor's defense. <br> Orcs left: 1, 7 |

### Problem 2.	Warships
We get as input the size of the field in which our Warships are situated. The field is always a square. After that we will receive the coordinates for the attacks for each player in pairs of integers (row, column). If there is an attack on invalid coordinates - ignore the attack. The possible characters that may appear on the screen are:
  +	\* – a regular position on the field
  +	< – ship of the first player.
  +	\> – ship of the second player
  +	\# – a sea mine that explodes when attacked

Each time when an attack hits a ship or a mine replace it with _'X'_. Keep track of the count of ships remaining for each player. If a player hits a mine it explodes destroying all ships in adjacent fields (friend or foe). If a player destroys all enemy ships, the program stops and you have to print the following message: _"Player {One/Two} has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle."_

If the list of attack commands ends before any of the player has won, you have to print the following message: _"It's a draw! Player One has {countOfShips} left. Player Two has {countOfShips} left."_

Input
  +	Field size – an integer number.
  +	Attack commands – All attack coordinates will be received on a single line. There will be a comma (,) between each set of coordinates and a whitespace (" ") between every two integers representing the row and column to attack.
  +	The field: some of the following characters (\*, <, >, #), separated by whitespace (" ");

Output
  +	There are three types of output:
    +	If player One wins, print the following output: _"Player One has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle."_
    +	If player Two wins, print the following output: _"Player Two has won the game! {totalCountShipsDestroyed} ships have been sunk in the battle."_
    +	If there are no more commands and none of the above cases had happened, you have to print the following message: _"It's a draw! Player One has {countOfShips} ships left. Player Two has {countOfShips} ships left."_

Constraints
  +	The field size will be a 32-bit integer in the range [4 … 2 147 483 647].
  +	Player One always starts first.
  +	A player will never attack the coordinates of one of his own ships. 
  +	There will be no incomplete sets of attack coordinates – e.g. – _"0 1,2 3,2"_.
  +	There will never be 2 mines in adjacent fields.
  +	There will not be a test where both players lose their last ships in the same turn.

Examples

| Input     | Output |
| --------- | -----|
| 5 <br> 0 0,-1 -1,2 2,4 4,4 2,3 3,3 6 <br> # < * < * <br> > > * < * <br> * * > * * <br> < * * * * <br> * * > * * | Player One has won the game! 5 ships have been sunk in the battle. |
| 6 <br> 0 0,1 0,5 5 <br> * * * * * * <br> < * * * < * <br> * * > > * * <br> * * * * * * <br> * * * * * * <br> * * * * * * | It’s a draw! Player One has 1 ships left. Player Two has 2 ships left. |

### Problem 3.	The Race
Your task is to create a repository, which stores departments by creating the classes described below.

First, write a C# class Car with the following properties:
  +	Name: string
  +	Speed: int

The class constructor should receive name, and speed.

Next, write a C# class Racer with the following properties:
  +	Name: string
  +	Age: int
  +	Country: string
  +	Car: Car

The class constructor should receive name, age, country and Car and override the ToString() method in the following format: _"Racer: {name}, {age} ({country})"_

Next, write a C# class Race that has data (a collection, which stores the entity Racer). All entities inside the repository have the same properties. Also, the Race class should have those properties:
  +	Name: string
  +	Capacity: int

The class constructor should receive name and capacity (the maximum allowed number of racers), also it should initialize the data with a new instance of the collection. Implement the following features:
  +	Field data – collection that holds added Racers
  +	Method Add(Racer Racer) – adds an entity to the data if there is room for him/her.
  +	Method Remove(string name) – removes an Racer by given name, if such exists, and returns bool.
  +	Method GetOldestRacer() – returns the oldest Racer.
  +	Method GetRacer(string name) – returns the Racer with the given name.
  +	Method GetFastestRacer() – returns the Racer whose car has the highest speed.
  +	Getter Count – returns the number of Racers.
  +	Report() – returns a string in the following format:

_"Racers participating at {RaceName}:_

_{Racer1}_

_{Racer2}_

_(…)"_

Constraints
  +	The names of the Racers will be always unique.
  +	The age of the Racers will always be with positive values.
  +	You will always have a Racer added before receiving methods manipulating the Race’s data.
