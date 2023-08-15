## PROBLEMS DESCRIPTION - Exam 15 October 2022


### Problem 1.	Trains Part Three

There is an issue with the fuel system you designed for the new Iron Girder 3.0. To be honest the fuel system is a mess, you created complex network but its not efficient enough and you need to fix it. Compute the most efficient fuel path, where most efficient means the most fuel delivered to the engine.

Input

  +	The first line holds an integer n – the number of places where the fuel system splits into different tubes
  +	On the second line, you will receive the number m – the number of tubes 
  +	On the third line the fuel source and the injector you need to put most fuel to as {source} {injector}
  +	At the next m lines, you will receive the fuel system in the format: {from} {to} {throughput}

Output

  +	Single number the max fuel you can transfer.

Constraints

  +	Number of fuel system splits will be an integer in the range [0…10000]
  +	Number of fuel tubes will be an integer in the range [0…10000]
  +	The throughput will be an integer in the range [0…10000]
  +	All fuel split nodes will be numbered from 0 to N - 1.

Examples

| Input | Output |
| --- | --- |
| 5 <br> 5 <br> 0 4 <br> 0 1 1 <br> 0 1 5 <br> 2 3 4 <br> 3 4 15 <br> 0 3 10 | 10 |
| 10 <br> 9 <br> 0 8 <br> 0 1 12 <br> 1 2 14 <br> 1 3 6 <br> 2 3 32 <br> 3 7 7 <br> 2 4 1 <br> 7 6 9 <br> 7 8 8 <br> 1 8 10 | 12 |

### Problem 2. Reaper Man

Using Reapers is mandatory however this time you are not the one sending them to scout, you are the developer implementing the path finding logic behind the movement of this unit.

You need to find the shortest path that the Reaper will use, keep in mind that there are obstacles along the way and units cannot move through those.

Input

  +	The first line holds an integer n – the number of blocked paths, once a path is blocked other paths will start from there 
  +	On the second line, you will receive the number m – the number of paths 
  +	On the next line the start and end positions separated by space
  +	At the next m lines, you will receive the paths in the format: {from} {to} {distance}

Output

  +	First line of output prints the path
  +	On the second line print the total distance

Constraints

  +	Number n will be an integer in the range [0…10000]
  +	Number m will be an integer in the range [0…10000]
  +	The distances will be integers in the range [0…10000]
  +	All n will be numbered from 0 to N - 1.

Examples

| Input | Output |
| --- | --- |
| 4 <br> 6 <br> 0 3 <br> 0 1 1 <br> 0 1 2 <br> 1 2 3 <br> 1 2 1 <br> 2 3 5 <br> 2 3 2 | 0 1 2 3 <br> 5 |
| 5 <br> 5 <br> 1 3 <br> 0 1 1 <br> 1 2 3 <br> 2 4 5 <br> 2 3 3 <br> 1 4 14 | 1 2 3 <br> 6 |

### Problem 3. Medivac

The medivac is one of the transport units that you can use. Each medivac has different storage capacity. Each unit uses different amount of that capacity, as an example a tank requires 4 units of space while a marine requires just 1. You will be given different units, with their capacity requirement and the urgency with which the unit needs to be transferred to the battlefield. Your task is to fill the medivac in the most optimal way which is to gather the highest urgency value.

Input

  + The first line will be the medivac capacity
  +	On the next lines until you reach the Launch command you will read the units with their capacity and urgency rating in the following format {unit} {capacity} {urgencyRating}

Output

  +	On the first line print the capacity used
  +	On the second line print the urgency rating achieved
  +	On the next lines the units taken in ascending order

Constraints

  +	The medivac capacity is an integer between [0… 100]
  +	The unit, capacity and the ratings are integers

Examples

| Input | Output |
| --- | --- |
| 4 <br> 2 2 3 <br> 3 2 1 <br> 0 1 3 <br> Launch | 3 <br> 6 <br> 0 <br> 2 |
| 18 <br> 3 5 30 <br> 6 8 120 <br> 7 7 10 <br> 2 0 20 <br> 1 4 50 <br> 0 5 80 <br> 8 2 10 <br> Launch | 17 <br> 270 <br> 0 <br> 1 <br> 2 <br> 6 |