## PROBLEMS DESCRIPTION - STACKS AND QUEUES (Lecture)


### Problem 1.	Reverse Strings
Create a program that:
  +	Reads an input string
  +	Reverses it using a Stack<T>
  +	Prints the result back at the terminal
  
Examples

| Input     | Output |
| --------- | -----|
| I Love C# | #C evoL I |
| Stacks and Queues | seueuQ dna skcatS |
  
### Problem 2.	Stack Sum
Create a program that:
  +	Reads an input of integer numbers and adds them to a stack
  +	Reads commands until _"end"_ is received
  +	Prints the sum of the remaining elements of the stack

Input
  +	On the first line you will receive an array of integers
  +	On the next lines, until the _"end"_ command is given, you will receive commands – a single command and one or two numbers after the command, depending on what command you are given
  +	If the command is _"add"_, you will always receive exactly two numbers after the command which you need to add in the stack
  +	If the command is _"remove"_, you will always receive exactly one number after the command which represents the count of the numbers you need to remove from the stack. If there are not enough elements skip the command.

Output
  +	When the command _"end"_ is received, you need to print the sum of the remaining elements in the stack

Examples

| Input     | Output |
| --------- | -----|
| 1 2 3 4 <br> adD 5 6 <br> REmove 3 <br> eNd | Sum: 6 |
| 3 5 8 4 1 9 <br> add 19 32 <br> remove 10 <br> add 89 22 <br> remove 4 <br> remove 3 <br> end | Sum: 16 |
  
### Problem 3.	Simple Calculator
Create a simple calculator that can evaluate simple expressions with only addition and subtraction. There will not be any parentheses.
Solve the problem using a Stack.
  
Examples
  
| Input     | Output |
| --------- | -----|
| 2 + 5 + 10 - 2 - 1 | 14 |
| 2 - 2 + 5 | 5 |
  
### Problem 4.	Matching Brackets
We are given an arithmetic expression with brackets. Scan through the string and extract each sub-expression.
Print the result back at the terminal.

Examples

| Input     | Output |
| --------- | -----|
| 1 + (2 - (2 + 3) * 4 / (3 + 1)) * 5 | (2 + 3) <br> (3 + 1) <br> (2 - (2 + 3) * 4 / (3 + 1)) |
|(2 + 3) - (2 + 3) | (2 + 3) <br> (2 + 3) |
  
### Problem 5.	Print Even Numbers
Create a program that:
  +	Reads an array of integers and adds them to a queue
  +	Prints the even numbers separated by ", "
  
Examples

| Input     | Output |
| --------- | -----|
| 1 2 3 4 5 6 | 2, 4, 6 |
| 11 13 18 95 2 112 81 46 | 18, 2, 112, 46 |
  
### Problem 6.	Supermarket
Reads an input consisting of a name and adds it to a queue until _"End"_ is received. If you receive _"Paid"_, print every customer name and empty the queue, otherwise we receive a client and we have to add him to the queue. When we receive _"End"_ we have to print the count of the remaining people in the queue in the format: _"{count} people remaining."_.
  
Examples

| Input     | Output |
| --------- | -----|
| Liam <br> Noah <br> James <br> Paid <br> Oliver <br> Lucas <br> Logan <br> Tiana <br> End | Liam <br> Noah <br> James <br> 4 people remaining. |
| Amelia <br> Thomas <br> Elias <br> End | 3 people remaining. |
  
### Problem 7.	Hot Potato
Hot potato is a game in which children form a circle and start passing a hot potato. The counting starts with the first kid. Every nth toss the child left with the potato leaves the game. When a kid leaves the game, it passes the potato along. This continues until there is only one kid left.
  
Create a program that simulates the game of Hot Potato.  Print every kid that is removed from the circle. In the end, print the kid that is left last.
  
Examples

| Input     | Output |
| --------- | -----|
| Alva James William <br> 2 | Removed James <br> Removed Alva <br> Last is William |
| Lucas Jacob Noah Logan Ethan <br> 10 | Removed Ethan <br> Removed Jacob <br> Removed Noah <br> Removed Lucas <br> Last is Logan |
| Carter Dylan Jack Luke Gabriel <br> 1 | Removed Carter <br> Removed Dylan <br> Removed Jack <br> Removed Luke <br> Last is Gabriel |
  
### Problem 8.	Traffic Jam
Create a program that simulates the queue that forms during a traffic jam. During a traffic jam only N cars can pass the crossroads when the light goes green. Then the program reads the vehicles that arrive one by one and adds them to the queue. When the light goes green N number of cars pass the crossroads and for each a message _"{car} passed!"_ is displayed. When the _"end"_ command is given, terminate the program and display a message with the total number of cars that passed the crossroads.
  
Input
  +	On the first line you will receive N – the number of cars that can pass during a green light
  +	On the next lines, until the _"end"_ command is given, you will receive commands – a single string, either a car or _"green"_

Output
  +	Every time the _"green"_ command is given, print out a message for every car that passes the crossroads in the format _"{car} passed!"_
  +	When the _"end"_ command is given, print out a message in the format _"{number of cars} cars passed the crossroads."_
  
Examples

| Input     | Output |
| --------- | -----|
| 4 <br> Hummer H2 <br> Audi <br> Lada <br> Tesla <br> Renault <br> Trabant <br> Mercedes <br> MAN Truck <br> green <br> green <br> Tesla <br> Renault <br> Trabant <br> end | Hummer H2 passed! <br> Audi passed! <br> Lada passed! <br> Tesla passed! <br> Renault passed! <br> Trabant passed! <br> Mercedes passed! <br> MAN Truck passed! <br> 8 cars passed the crossroads. |
| 3 <br> Enzo's car <br> Jade's car <br> Mercedes CLS <br> Audi <br> green <br> BMW X5 <br> green <br> end | Enzo's car passed! <br> Jade's car passed! <br> Mercedes CLS passed! <br> Audi passed! <br> BMW X5 passed! <br> 5 cars passed the crossroads. |
  