## PROBLEMS DESCRIPTION


### Problem 1.	Loot box
Every purchase gives you two loot boxes and they are represented as a sequence of integers. First, you will be given a sequence of integers, representing the first loot box. Afterwards, you will be given another sequence of integers representing the second loot box. 

You need to start from the first item in the first box and sum it with the last item in the second box. If the sum of their values is an even number, add the summed item to your collection of claimed items and remove them both from the boxes. Otherwise, move the last item from the second box and add it at the last position in the first box. You need to stop summing items when one of the boxes becomes empty.

If the first loot box becomes empty print: _"First lootbox is empty"_

If the second loot box becomes empty print: _"Second lootbox is empty"_

In the end you need to determine the quality of your claimed items. If the sum of the claimed items equal to or greater than 100, print: _"Your loot was epic! Value: {sum of claimed items}"_

Else print:	_"Your loot was poor... Value: {sum of claimed items}"_

Input
  +	On the first line, you will receive the integers representing the first loot box, separated by a single space. 
  +	On the second line, you will receive the integers representing the second loot box, separated by a single space.

Output
  +	On the first line of output – print which box got empty in the format described above.
  +	On the second line – the quality of your loot in the format described above.

Constraints
  +	All of the given numbers will be valid integers in the range [0, 100].
  +	There won’t be a case where both loot boxes become empty at the same time.

Examples

| Input     | Output |
| --------- | -----|
| 10 11 8 13 5 6 <br> 0 4 7 3 6 23 3 | Second lootbox is empty <br> Your loot was poor... Value: 42 |
| 20 40 60 80 100 <br> 10 20 30 40 50 60 | First lootbox is empty <br> Your loot was epic! Value: 500 |

### Problem 2.	Re-Volt
You will be given an integer n for the size of the square matrix and an integer for the count of commands. On the next n lines, you will receive the rows of the matrix. The player starts at a random position (the player is marked with _"f"_) and all of the empty slots will be filled with "-" (dash). The goal is to reach the finish mark which will be marked with _"F"_. On the field there can also be bonuses and traps. Bonuses are marked with _"B"_ and traps are marked with _"T"_.

Each turn you will be given commands for the player’s movement. If the player goes out of the matrix, he comes in from the other side. For example, if the player is on 0, 0 and the next command is left, he goes to the last spot on the first row.

If the player steps on a bonus, he should move another step forward in the direction he is going. If the player steps on a trap, he should move a step backwards.

When the player reaches the finish mark or the count of commands is reached the game ends.

Input
  +	On the first line, you are given the integer N – the size of the square matrix.
  +	On the second you are given the count of commands.
  +	The next N lines holds the values for every row.
  +	On each of the next lines you will get commands for movement directions.

Output
  +	If the player reaches the finish mark, print: _"Player won!"_
  +	If the player reaches the commands count and hasn’t reached the finish mark print: _"Player lost!"_
  +	In the end print the matrix.

Constraints
  +	The size of the matrix will be between [2…20].
  +	The players will always be indicated with _"f"_.
  +	If the player steps on the finish mark at the same time as his last command, he wins the game.
  +	Commands will be in the format up, down, left or right.
  +	There won't be a case where you bypass the finish while you are on a trap or a bonus.
  +	A trap will never place you into a bonus or another trap and a bonus will never place you into a trap or another bonus.

Examples

| Input     | Output |
| --------- | -----|
| 5 <br> 5 <br> ----- <br> -f--- <br> -B--- <br> --T-- <br> -F--- <br> down <br> right <br> down | Player won! <br> ----- <br> ----- <br> -B--- <br> --T-- <br> -f--- |
| 4 <br> 3 <br> ---- <br> -f-B <br> --T- <br> ---F <br> up <br> up <br> left | Player lost! <br> ---- <br> ---B <br> --T- <br> f--F |

### Problem 3.	Guild
Your task is to create a repository which stores players by creating the classes described below.

First, write a C# class Player with the following properties:
  +	Name: string
  +	Class: string
  +	Rank: string – _"Trial"_ by default
  +	Description: string – _"n/a"_ by default

The class constructor should receive name and class. Override the ToString() method in the following format:

_"Player {Name}: {Class}_

_Rank: {Rank}_

_Description: {Description}"_

Next, write a C# class Guild that has a roster (a collection which stores the entity Player). All entities inside the repository have the same properties. Also, the Guild class should have those properties:
  +	Name: string
  +	Capacity: int

The class constructor should receive name and capacity, also it should initialize the roster with a new instance of the collection. Implement the following features:
  +	Field roster - collection that holds added players
  +	Method AddPlayer(Player player) - adds an entity to the roster if there is room for it
  +	Method RemovePlayer(string name) - removes a player by given name, if such exists, and returns bool
  +	Method PromotePlayer(string name) - promote (set his rank to _"Member"_) the first player with the given name. If the player is already a _"Member"_, do nothing.
  +	Method DemotePlayer(string name)- demote (set his rank to _"Trial"_) the first player with the given name. If the player is already a _"Trial"_,  do nothing.
  +	Method KickPlayersByClass(string class) - removes all the players by the given class and returns all players from that class as an array
  +	Getter Count - returns the number of players
  +	Report() - returns a string in the following format:	

_"Players in the guild: {guildName}_

_{Player1}_

_{Player2}_

_(…)"_

Constraints
  +	The names of the players will be always unique.
  +	You will always have a player added before receiving methods manipulating the Guild's players.
