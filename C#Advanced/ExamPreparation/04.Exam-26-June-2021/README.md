## PROBLEMS DESCRIPTION


### Problem 1.	Masterchef
First you will receive a sequence of integers, representing the number of ingredients in a single basket. After that you will be given another sequence of integers - the freshness level of the ingredients.

Your task is to cook them so you can impress the judges. The names of the dishes are listed in the table below with the exact freshness level. 

| Dish     | Freshness Level needed |
| --------- | -----|
| Dipping sauce | 150 |
| Green salad | 250 |
| Chocolate cake | 300 |
| Lobster | 400 |

To cook a dish, you have to take the first ingredient value and the last freshness level value. The total freshness level is calculated by their multiplication.
  +	If the product of this operation equals one of the levels described in the table, you make the dish and remove both ingredient and freshness value. 
  +	Otherwise you should remove the freshness level, then increase the ingredient value by 5
    +	Remove the ingredient from the collection and add it again in last place, already increased by 5. 
  +	In case you have an ingredient with value 0 you have to remove it and continue cooking.

You need to stop cooking only when you run out of ingredients or freshness level values.

Your task is considered successful if you make at least four dishes - one of each type.

Input
  +	The first line of input will represent the ingredients' values - integers, separated by single space
  +	On the second line you will be given the freshness values - integers again, separated by single space

Output
  +	On the first line of output - print if you've succeeded in preparing the dishes
    +	_"Applause! The judges are fascinated by your dishes!"_
    +	_"You were voted off. Better luck next year."_
  +	On the next output line - print the sum of the ingredients only if they are left any in the format: _"Ingredients left: {ingridientsSum}"_
  +	On the last few lines you have to print the dishes you have made ordered alphabetically, but only the ones that were made at least once in the format: _" # {dish name} --> {amount}"_

Constraints
  + All of the ingredients' values and freshness level values will be integers in range [0, 100]
  +	We can have more than one cooked dish of the types specified in the table above

Examples

| Input     | Output |
| --------- | -----|
| 10 10 12 8 10 12 <br> 25 15 50 25 25 15 | Applause! The judges are fascinated by your dishes!  <br>  # Chocolate cake --> 2 <br>  # Dipping sauce --> 2 <br> # Green salad --> 1 <br> # Lobster --> 1 |
| 12 20 0 6 19 <br> 12 12 25 | You were voted off. Better luck next year. <br> Ingredients left: 55 <br> # Chocolate cake --> 1 |

### Problem 2.	Survivor
Write a program, that collects tokens from the beach. First you will be given the number of rows of the beach – an integer n. On the next n lines, you will receive the available tokens to collect for each row, separated by a single space in the format: _"{token1} {token2} … {tokenn}"_

The positions (cells) without tokens in them are considered empty and they will be marked with a dash ('-').

After that you will start receiving commands. There are three possibilities:
  +	_"Find {row} {col}"_:
    +	You have to go to the given place if it is valid and collect the token, if there is one. 
    +	When you collect it, you have to mark the place as an empty, using dash symbol.
  +	_"Opponent {row} {col} {direction}"_:
    +	One of your opponents is searching for a token at the given coordinates if they exist. 
    +	After going at the given coordinates (if they exist) and collecting the token (if there is such), the opponent is beginning a movement in the given direction by 3 steps. He collects all the tokens that are placed on his way.
    +	If opponent's movement is going to step outside of the field, he is stepping only on the possible indexes.
    + When he finds tokens, he marks the cells as empty. 
    +	There are four possible directions, in which he can go: _"up", "down", "left", "right"_.
  +	_"Gong"_ - the gong rings and the challenge is over.

In the end, print on the console the last condition of the beach. The cells, containing a token or not, should be separated by single space. After that print the count of the tokens you've collected: _"Collected tokens: {countOfCollected}"_. Last step is to print the number of found by your opponent tokens in the format:
_"Opponent's tokens: {countOfOpponentsTokens}"_

Input
  +	On the first line, you will receive the number of beach's rows - integer n
  +	On the next n lines, for each row, the situation of the seashells at the beach in the described format above
  +	Next, until you receive _"Gong"_, you will get the commands in the specified format.

Output
  +	Print the resulting beach - each cell separated by single space
  +	On the next output line - print information for tokens you've collected in the described format
  +	On the last line - print the number of tokens found by the opponent

Constraints
  +	The number of rows will be positive integer between [1, 10]
  +	Not all rows will have the same length
  +	The tokens will be marked with _'T'_ 
  +	Move commands will be: _"up", "down", "left", "right"_

Examples

| Input     | Output |
| --------- | -----|
| 6 <br> T T - T T - T <br> - T - - <br> T - T - T T - - <br> - T - T - T <br> T T <br> T T T - T <br> Find 2 2 <br> Find 4 1 <br> Opponent 3 1 up <br> Find 4 3 <br> Find 5 0 <br> Find 4 0 <br> Opponent 2 0 down <br> Gong | T - - T T - T  <br> - - - -  <br> - - - - T T - -  <br> - - - T - T  <br> - -  <br> - T T - T  <br> Collected tokens: 4 <br> Opponent's tokens: 4 |
| 4 <br> - T T <br> T <br> T - - - <br> T <br> Find 9 0 <br> Find 1 4 <br> Opponent 0 2 right <br> Opponent 5 5 up <br> Gong | - T -  <br> T  <br> T - - -  <br> T  <br> Collected tokens: 0 <br> Opponent's tokens: 1 |

### Problem 3.	Ski Rental
Your task is to create a repository, which stores items by creating the classes described below.

First, write a C# class Ski with the following properties:
  +	Manufacturer: string
  +	Model: string
  +	Year: int

The class constructor should receive manufacturer, model and year and override the ToString() method in the following format: _"{manufacturer} - {model} - {year}"_

Next, write a C# class SkiRental that has data (a collection, which stores the entity Ski). All entities inside the repository have the same properties. Also, the Ski Rental class should have those properties:
  +	Name: string
  +	Capacity: int

The class constructor should receive name and capacity, also it should initialize the data with a new instance of the collection. Implement the following features:
  +	Field data – collection that holds added Skis
  +	Method Add(Ski ski) – adds an entity to the data if there is an empty slot for the Ski.
  +	Method Remove(string manufacturer, string model) – removes the Ski by given manufacturer and model, if such exists, and returns bool.
  +	Method GetNewestSki() – returns the newest Ski (by year) or null if there are no Skis stored.
  +	Method GetSki(string manufacturer, string model) – returns the Ski with the given manufacturer and model or null if there is no such Ski.
  +	Getter Count – returns the number of Skis.
  +	GetStatistics() – returns a string in the following format:

_"The skis stored in {Ski Rental Name}:_

_{Ski1}_

_{Ski2}_

_(…)"_

Constraints
  +	The combinations of manufacturers and models will be always unique.
  +	The year of the Skis will always be positive.
  +	There won't be Skis with the same years.
