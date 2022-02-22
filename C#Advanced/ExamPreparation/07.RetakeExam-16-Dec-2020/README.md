## PROBLEMS DESCRIPTION


### Problem 1.	Cooking
First, you will be given a sequence of integers, representing liquids. Afterwards, you will be given another sequence of integers representing ingredients.

You need to start from the first liquid and try to mix it with the last ingredient. If the sum of their values is equal to any of the items in the table below – cook the food corresponding to the value and remove both the liquid and the ingredient. Otherwise, remove only the liquid and increase the value of the ingredient by 3. You need to stop cooking when you have no more liquids or ingredients.

| Food     | Value needed |
| --------- | -----|
| Bread | 25 |
| Cake | 50 |
| Pastry | 75 |
| Fruit Pie | 100 |

In order to cook enough food for the bakery, you need one of each of the foods. 

Input
  +	On the first line, you will receive the integers representing the liquids, separated by a single space. 
  +	On the second line, you will receive the integers representing the ingredients, separated by a single space.

Output
  +	On the first line of output – print if you succeeded in cooking everything:
    +	_"Wohoo! You succeeded in cooking all the food!"_
    +	_"Ugh, what a pity! You didn't have enough materials to cook everything."_
  +	On the second line - print all liquids you have left:
    +	If there are no liquids: _"Liquids left: none"_
    +	If there are liquids: _"Liquids left: {liquid1}, {liquid2}, {liquid3}, (…)"_
  +	On the third line - print all ingredients you have left:
    +	If there are no items: _"Ingredients left: none"_
    +	If there are items: _"Ingredients left: {ingredient}, {ingredient}, {ingredient}, (…)"_
  +	Then, you need to print all products you have cooked and the amount you have of them, ordered alphabetically:
    +	_"Bread: {amount}"_
    +	_"Cake: {amount}"_
    +	_"Fruit Pie: {amount}"_
    +	_"Pastry: {amount}"_

Constraints
  +	All of the given numbers will be valid integers in the range [0, 100].

Examples

| Input     | Output |
| --------- | -----|
| 1 25 50 50 <br> 50 25 25 24 | Wohoo! You succeeded in cooking all the food! <br> Liquids left: none <br> Ingredients left: none <br> Bread: 1 <br> Cake: 1 <br> Fruit Pie: 1 <br> Pastry: 1 |
| 10 20 30 40 50 <br> 50 40 30 30 15 | Ugh, what a pity! You didn't have enough materials to cook everything. <br> Liquids left: none <br> Ingredients left: 39, 40, 50 <br> Bread: 1 <br> Cake: 1 <br> Fruit Pie: 0 <br> Pastry: 0 |

### Problem 2.	Selling
You will be given an integer n for the size of the bakery with square shape. On the next n lines, you will receive the rows of the bakery. You will be placed on a random position, marked with the letter _'S'_. On random positions there will be clients, marked with a single digit. There may also be pillars. Their count will be either 0 or 2 and they are marked with the letter - _'O'_. All of the empty positions will be marked with '-'.

Each turn, you will be given commands for the your movement. Move commands will be: _"up", "down", "left", "right"_. If you move to a client, you collects the price equal to the digit there and the client disappears. If you move to a pillar, you move on the position of the other pillar and then both pillars disappear. If you go out of the bakery, you disappear from the bakery and you are out of there. You need at least 50 dollars to rent your own Bakery.

When you are out of the bakery or you collect enough money, the program ends.

Input
  +	On the first line, you are given the integer n – the size of the square matrix.
  +	The next n lines holds the values for every row.
  +	On each of the next lines you will get a move command.

Output
  +	On the first line:
    +	If the player goes to the void, print: _"Bad news, you are out of the bakery."_
    +	If the player collects enough star power, print: _"Good news! You succeeded in collecting enough money!"_
  +	On the second line print all star power collected: _"Money: {money}"_
  +	In the end print the matrix.

Constraints
  +	The size of the square matrix will be between [2…10].
  +	There will always be 0 or 2 pillars, marked with the letter - _'O'_.
  +	Your position will be marked with _'S'_.
  +	You will always go out of the bakery or collect enough money. 

Examples

| Input     | Output |
| --------- | -----|
| 5 <br> SO--- <br> ----- <br> ----- <br> ----- <br> ----O <br> right <br> right | Bad news, you are out of the bakery. <br> Money: 0 <br> ----- <br> ----- <br> ----- <br> ----- <br> ----- |
| 6 <br> S98--- <br> 99---- <br> 666666 <br> ------ <br> --77-- <br> -6-6-6 <br> right <br> right <br> down <br> left <br> left <br> down <br> right <br> right | Good news! You succeeded in collecting enough money! <br> Money: 53 <br> ------ <br> ------ <br> --S666 <br> ------ <br> --77-- <br> -6-6-6 |

### Problem 3.	Openning
Your task is to create a repository, which stores departments by creating the classes described below.

First, write a C# class Employee with the following properties:
  +	Name: string
  +	Age: int
  +	Country: string

The class constructor should receive name, age and country and override the ToString() method in the following format: _"Employee: {name}, {age} ({country})"_

Next, write a C# class Bakery that has data (a collection, which stores the entity Employee). All entities inside the repository have the same properties. Also, the Bakery class should have those properties:
  +	Name: string
  +	Capacity: int

The class constructor should receive name and capacity, also it should initialize the data with a new instance of the collection. Implement the following features:
  +	Field data – collection that holds added Employees
  +	Method Add(Employee employee) – adds an entity to the data if there is room for him/her.
  +	Method Remove(string name) – removes an employee by given name, if such exists, and returns bool.
  +	Method GetOldestEmployee() – returns the oldest employee.
  +	Method GetEmployee(string name) – returns the employee with the given name.
  +	Getter Count – returns the number of employees.
  +	Report() – returns a string in the following format:

_"Employees working at Bakery {bakeryName}:_

_{Employee1}_

_{Employee2}_

_(…)"_

Constraints
  +	The names of the employees will be always unique.
  +	The age of the employees will always be with positive values.
  +	You will always have an employee added before receiving methods manipulating the Space Station’s Employees.
