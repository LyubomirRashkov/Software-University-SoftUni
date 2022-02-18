## PROBLEMS DESCRIPTION


### Problem 1.	Warm Winter
First you will be given a sequence of integers representing the hats. Afterwards you will be given another sequence of integers representing the scarfs. 

Check all of the hats and scarfs in order to make sets. Take the last given hat, and the first given scarf and check if the hat is bigger than the scarf and if it is – you have to create a set. A set is created when you add the value of the hat to the value of the scarf (that is the price of the set). If you have a set, remove both the hat and the scarf from their collections. 

If the scarf’s value is bigger – remove the hat and check the next one. 

If their values are equal – remove the scarf and increment the value of the hat with 1.

Mary wants to give her mother the most expensive set size, so you have to find out which one it is and print it in the following format: _"The most expensive set is: {maxPriceSet}"_.

Afterwards print the created sets from the first added to the last, separated by a space. 

Input
  +	On the first line of input you will receive the integers, representing the hats, separated by a single space. 
  +	On the second line of input you will receive the integers, representing the scarfs, separated by a single space.

Output
  +	On the first line of output - print the biggest set in the format specified above. 
  +	On the second line - print the sets, separated by a single space in the order specified above.

Constraints
  +	All of the given numbers will be valid integers in the range [1, 10000].
  +	There will always be at least 1 set.
  +	Allowed time/memory: 100ms/16MB.

Examples

| Input     | Output |
| --------- | -----|
| 10 8 7 13 8 4 <br> 4 7 3 6 4 12 | The most expensive set is: 16 <br> 15 16 13 12 |
| 9 5 4 7 8 5 2 6 9 <br> 1 4 5 7 9 6 3 5 4 7 | The most expensive set is: 16 <br> 10 10 15 16 |

### Problem 2.	Super Mario
After Mario gets into the tower, he has to fight his way to the princess. In order to do that, he has to walk through the maze where the dangerous Bowser is guarding, but he also has to be careful not to loose all his lives and not be able to proceed with his mission. If Mario successfully reaches the throne, he saves princess Peach.

The castles maze may looks like this:

| The Maze     | Legend |
| --------- | -----|
| ------P--- <br> -------B-- <br> --B------- <br> ---------- <br> ----M----- | M - Mario, the player character <br> B - Bowser, the enemy <br> P - Princess Peach <br> - - Empty space |

Each turn proceeds as follows:
  +	First, Bowser spawns on the given index.
  +	Then, Mario moves in a direction, which decreases his lives by 1.
    +	It can be _"W"_ (up), _"S"_ (down), _"A"_ (left), _"D"_ (right).
    +	If Mario tries to move outside of the maze, he doesn’t move but still has his lives decreased.
  +	If an enemy is on the same cell where Mario moves, Bowser fights him, which decreases his lives by 2. If Mario’s lives drop at 0 or below, he dies and you should mark his position with _‘X’_.
  +	If Mario kills the enemy successfully, the enemy disappears.
  +	If Mario reaches the index where the throne is, he saves Princess Peach and they both run away (disappear from the field), even if his lives are 0 or below.

Input
  +	On the first line of input, you will receive e – the lives Mario has.
  +	On the second line of input, you will receive n – the number of rows the castle’s maze will consist of. Range: [5-20]
  +	On the next n lines, you will receive how each row looks.
  +	Then, until Mario dies, or reaches the princess, you will receive a move command and spawn row and column.

Output
  +	If Mario runs out of lives, print _"Mario died at {row};{col}."_
  +	If Mario reaches the throne, print _"Mario has successfully saved the princess! Lives left: {lives}"_
  +	Then, in all cases, print the final state of the field on the console.


Constraints
  +	The field will always be rectangular.
  +	Mario will always run out of lives or reach the throne.
  +	There will be no case with spawn on invalid index.
  +	There will be no case with two enemies on the same cell.
  +	There will be no case with enemy spawning on the index where Mario or the princess are.

Examples

| Input     | Output |
| --------- | -----|
| 100 <br> 5 <br> --P-- <br> ----- <br> ----- <br> ----- <br> --M-- <br> W 3 0 <br> W 3 1 <br> W 3 2 <br> W 3 3 | Mario has successfully saved the princess! Lives left: 96 <br> ----- <br> ----- <br> ----- <br> BBBB- <br> ----- |
| 3 <br> 5 <br> --P-- <br> ----- <br> ----- <br> ----- <br> --M-- <br> W 3 2 | Mario died at 3;2. <br> --P-- <br> ----- <br> ----- <br> --X-- <br> ----- |

### Problem 3.	Cocktail Party
Your task is to create a cocktail which is made of different ingredients.

First, write a C# class, called Ingredient with properties:
  +	Name: string
  +	Alcohol: int
  +	Quantity: int

The constructor of Ingredient class should receive name, alcohol and quantity.

The class should also have the following methods:
  +	Override ToString() method in the format:

_"Ingredient: {Name}_

_Quantity: {Quantity}_

_Alcohol: {Alcohol}"_

Next step is to write Cocktail class that has a collection of type Ingredient with corresponding unique name of an Ingredient. The name of the collection should be Ingredients. All the entities of the Ingredients collection have the same properties. The Cocktail has also some additional properties:
  +	Name: string
  +	Capacity: int - the maximum allowed number of ingredients in the cocktail
  +	MaxAlcoholLevel: int - the maximum allowed amount of alcohol in the cocktail

The constructor of the Cocktail class should receive name, capacity and maxAlcoholLevel.

Implement the coming features:
  +	Method Add(Ingredient ingredient) - adds the entity if there isn't an Ingredient with the same name and if there is enough space in terms of quantity and alcohol.
  +	Method Remove(string name) - removes an Ingredient from the cocktail with the given name, if such exists and returns bool if the deletion is successful.
  +	Method FindIngredient(string name) - returns an Ingredient with the given name. If it doesn't exist, return null.
  +	Method GetMostAlcoholicIngredient() – returns the Ingredient with most Alcohol.
  +	Getter CurrentAlcoholLevel – returns the amount of alcohol currently in the cocktail.
  +	Method Report() - returns information about the Cocktail and the Ingredients inside it in the following format:

_"Cocktail: {name} - Current Alcohol Level: {CurrentAlcoholLevel}_

_{Ingredient1}_

_{Ingredient2}_

_… "_

Constraints
  +	The name of each Ingredient in the pool will always be unique
  +	Each Ingredient will have different number of Alcohol
  +	The Alcohol of an Ingredient and the MaxAlcoholLevel of the Cocktail will always be positive numbers
  +	You will always be given Ingredient added before receiving method for its manipulation 
