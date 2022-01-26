## PROBLEMS DESCRIPTION - FUNCTIONAL PROGRAMMING (Exercise)


### Problem 1.	Action Point
Create a program that reads a collection of strings from the console and then prints them onto the console. Each name should be printed on a new line. Use Action\<T>.

Examples

| Input     | Output |
| --------- | -----|
| Lucas Noah Tea | Lucas <br> Noah <br> Tea |
| Teo Lucas Harry | Teo <br> Lucas <br> Harry |

### Problem 2. Knights of Honor
Create a program that reads a collection of names as strings from the console, appends _"Sir"_ in front of every name and prints it back on the console. Use Action\<T>.

Examples

| Input     | Output |
| --------- | -----|
| Eathan Lucas Noah Arthur | Sir Eathan <br> Sir Lucas <br> Sir Noah <br> Sir Arthur |
| Lucas Jade Hugo | Sir Lucas <br> Sir Jade <br> Sir Hugo |
  
### Problem 3. Custom Min Function
Create a simple program that reads from the console a set of integers and prints back on the console the smallest number from the collection. Use Func<T, T>.

Examples

| Input     | Output |
| --------- | -----|
| 1 4 3 2 1 7 13 | 1 |
| 4 5 -2 3 -5 8 | -5 |
  
### Problem 4. Find Evens or Odds
You are given a lower and an upper bound for a range of integer numbers. Then a command specifies if you need to list all even or odd numbers in the given range. Use Predicate\<T>.

Examples

| Input     | Output |
| --------- | -----|
| 1 10 <br> odd | 1 3 5 7 9 |
| 20 30 <br> even | 20 22 24 26 28 30 |

### Problem 5. Applied Arithmetics
Create a program that executes some mathematical operations on a given collection. On the first line you are given a list of numbers. On the next lines you are passed different commands that you need to apply to all the numbers in the list:
  +	_"add"_ -> add 1 to each number
  +	_"multiply"_ -> multiply each number by 2
  +	_"subtract"_ -> subtract 1 from each number
  +	_"print"_ -> print the collection
  +	_"end"_ -> ends the input 

Note: Use functions.

Examples

| Input     | Output |
| --------- | -----|
| 1 2 3 4 5 <br> add <br> add <br> print <br> end | 3 4 5 6 7 |
| 5 10 <br> multiply <br> subtract <br> print <br> end | 9 19 |

### Problem 6. Reverse and Exclude
Create a program that reverses a collection and removes elements that are divisible by a given integer n. Use predicates/functions.

Examples

| Input     | Output |
| --------- | -----|
| 1 2 3 4 5 6 <br> 2 | 5 3 1 |
| 20 10 40 30 60 50 <br> 3 | 50 40 10 20 |

### Problem 7. Predicate for Names
Write a program that filters a list of names according to their length. On the first line, you will be given an integer n, representing a name's length. On the second line, you will be given some names as strings separated by space. Write a function that prints only the names whose length is less than or equal to n.

Examples

| Input     | Output |
| --------- | -----|
| 4 <br> Karl Anna Kris Yahto | Karl <br> Anna <br> Kris |
| 4 <br> Karl James George Robert Patricia | Karl |

### Problem 8. List of Predicates
Find all numbers in the range 1...N that are divisible by the numbers of a given sequence. On the first line, you will be given an integer N – which is the end of the range. On the second line, you will be given a sequence of integers which are the dividers. Use predicates/functions.

Examples

| Input     | Output |
| --------- | -----|
| 10 <br> 1 1 1 2 | 2 4 6 8 10 |
| 100 <br> 2 5 10 20 | 20 40 60 80 100 |

### Problem 9. Predicate Party!
Ivan’s parents are on a vacation for the holidays and he is planning an epic party at home. Unfortunately, his organizational skills are next to non-existent, so you are given the task to help him with the reservations.

On the first line, you receive a list with all the people that are coming. On the next lines, until you get the _"Party!"_ command, you may be asked to double or remove all the people that apply to a given criteria. There are three different criteria: 
  +	Everyone that has his name starting with a given string 
  +	Everyone that has a name ending with a given string
  +	Everyone that has a name with a given length.

Finally, print all the guests who are going to the party separated by ", " and then add the ending _"are going to the party!"_. If there are no guests going to the party print _"Nobody is going to the party!"_.

Examples

| Input     | Output |
| --------- | -----|
| Peter Misha Stephen <br> Remove StartsWith P <br> Double Length 5 <br> Party! | Misha, Misha, Stephen are going to the party! |
| Peter <br> Double StartsWith Pete <br> Double EndsWith eter <br> Party! | Peter, Peter, Peter, Peter are going to the party! |

### Problem 10. Party Reservation Filter Module
You need to implement a filtering module to a party reservation software. First, to the Party Reservation Filter Module (PRFM for short) is passed a list with invitations. Next the PRFM receives a sequence of commands that specify whether you need to add or remove a given filter.

Each PRFM command is in the given format: _"{command;filter type;filter parameter}"_

You can receive the following PRFM commands: 
  +	_"Add filter"_
  +	_"Remove filter"_
  +	_"Print"_ 

The possible PRFM filter types are: 
  +	_"Starts with"_
  +	_"Ends with"_
  +	_"Length"_
  +	_"Contains"_

All PRFM filter parameters will be a string (or an integer only for the _"Length"_ filter). Each command will be valid e.g. you won’t be asked to remove a non-existent filter. The input will end with a _"Print"_ command, after which you should print all the party-goers that are left after the filtration.

Examples

| Input     | Output |
| --------- | -----|
| Peter Misha Slav <br> Add filter;Starts with;P <br> Add filter;Starts with;M <br> Print | Slav |
| Peter Misha John <br> Add filter;Starts with;P <br> Add filter;Starts with;M <br> Remove filter;Starts with;M <br> Print | Misha John |

### Problem 11. TriFunction
Create a program that traverses a collection of names and returns the first name, whose sum of characters is equal to or larger than a given number N, which will be given on the first line. Use a function that accepts another function as one of its parameters. Start off by building a regular function to hold the basic logic of the program. Something along the lines of Func<string, int, bool>. Afterwards create your main function which should accept the first function as one of its parameters.

Examples

| Input     | Output |
| --------- | -----|
| 350 <br> Rob Mary Paisley Spencer | Mary |
| 666 <br> Paul Thomas William | William |
