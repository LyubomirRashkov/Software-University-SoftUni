## PROBLEMS DESCRIPTION - EXAM PREPARATION


### Problem 1.	Le Tour de Sofia

Pierre is training for the famous bicycle tour of Sofia. He is a cyclist, the laziest at that, and he is planning a workout route… the shortest one.

You are given all junctions and all one-way streets in Sofia with the distance from junction A to junction B. 

Help Pierre find the length of the shortest route starting at a given junction and ending back there. 

If there is no such route print the numbers of junctions reachable from the start.

Input

  +	The first line holds an integer n – the number of junctions.
  +	On the second line, you will receive the number m – the number of streets. 
  +	On the third line, s - the start of the route
  +	At the next m lines, you will receive the streets in the format: {from junction} {to junction} {distance}

Output

  +	If there is a route from the start and back to it, print the length of the route.
  +	If there is no such route, print the count of reachable junctions from the start. 

Constraints

  +	The number of junctions will be an integer in the range [0…10000]
  +	The number of streets will be an integer in the range [0…10000]
  +	All junctions will be numbered from 0 to N - 1.
  +	Time limit: 100 ms. Allowed memory: 20 MB.

Examples

| Input | Output |
| --- | --- |
| 7 <br> 10 <br> 0 <br> 0 2 5 <br> 2 1 10 <br> 1 0 25 <br> 3 0 30 <br> 3 1 55 <br> 2 4 15 <br> 3 4 25 <br> 4 5 1 <br> 5 6 2 <br> 6 3 3 | 40 |
| 3 <br> 2 <br> 1 <br> 0 1 5 <br> 1 2 10 | 2 |

### Problem 2. Chain Lightning

You are given all neighborhoods in Sofia and the distances between them. A thunderstorm is raging above the city with lightning strikes falling all around. 

When lightning falls, it damages all connected neighborhoods, but the damage halves with each jump (integer division). The lightning always jumps to a neighborhood that has the smallest distance to any neighborhood already damaged. Note that lightning doesn’t necessarily fork only at its tail. Also, the same lightning cannot damage the same neighborhood twice.

Your job is to find the condition of the most heavily damaged neighborhood after multiple strikes on top of different city neighborhoods, so a team of highly skilled technicians can be dispatched.

Input

  +	The first line holds an integer n – the number of neighborhoods
  +	On the second line, you will receive the number m – the number of distances
  +	On the third line, l - the number of lightning
  +	At the next m lines, you will receive the distances: {from neighbourhood} {to neighbourhood} {distance}
  +	At the next l lines, you will receive the lightning strikes: {neighborhood} {damage}
  +	The neighborhood will always be numbered from 0 to N - 1

Output

  +	Print the condition of the most heavily damaged neighborhood

Constraints

  +	The number of neighborhoods will be an integer in the range [0…5000]
  +	The number of connections will be an integer in the range [0…10000]
  +	The number of lightning strikes will be an integer in the range [0…1000]
  +	Distance between neighborhoods will be a unique integer in the range [0…100000]
  +	Lightning damage will be an integer in the range [0…1000]
  +	Time limit: 200 ms. Allowed memory: 32 MB

Examples

| Input | Output |
| --- | --- |
| 5 <br> 5 <br> 2 <br> 0 1 10 <br> 1 4 20 <br> 2 4 30 <br> 0 2 35 <br> 0 3 50 <br> 0 40 <br> 4 20 | 45 |
| 10 <br> 8 <br> 3 <br> 0 1 5 <br> 1 2 4 <br> 1 3 6 <br> 2 3 3 <br> 2 5 7 <br> 2 4 2 <br> 7 6 8 <br> 7 8 1 <br> 2 100 <br> 0 200 <br> 9 100 | 225 |

### Problem 3. Road Trip

You have to plan out your trip and you have to choose the stuff that you can take with you. Since your vehicle is small, you have to choose only the most important items to take. You will receive the value of the items, the space that they will take, and the max capacity of your trunk. Print the maximum value of items that is possible for you to take.

Input
  
  +	On the first line, you will receive the value of the items separated by comma and space ", ".
  +	On the next line, you will receive the amount of space that they take separated by comma and space ", ".
  +	Finally, you will receive the max capacity of your trunk.

Output

  +	Print the maximum value of items that you can take without exceeding the capacity of your trunk with you in the format: "Maximum value: {maxValue}".

Examples

| Input | Output |
| --- | --- |
| 10, 5, 20, 23, 45 <br> 2, 4, 5, 1, 7 <br> 7 | Maximum value: 45 |
| 60, 100, 120 <br> 10, 20, 30 <br> 50 | Maximum value: 220 |