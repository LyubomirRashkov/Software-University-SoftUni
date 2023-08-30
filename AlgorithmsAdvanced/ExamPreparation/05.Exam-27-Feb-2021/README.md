## PROBLEMS DESCRIPTION - Exam 27 February 2021


### Problem 1.	PokemonGo

You are working in the SPD – Sofia Police Department. You are given a car with limited amount of fuel and your job is to catch Pokémon while patrolling so that's what you do. 

You will be given the possible streets to patrol for the shift and information about each street. It will contain the length of the street (1 unit of length costs 1 fuel) and the count of Pokémon on it.

You want to maximize caught Pokémon based on the fuel you have. 

Your report must contain the following information.

  +	All streets that you are going to patrol.
  +	Total Pokémon's caught 
  +	The remaining fuel after the shift

Input

  +	The first line holds an integer f – fuel in the car.
  +	On the next lines, you will receive the streets in the format below, until receiving the "End" command
    +	{street name}, {pokemon count}, {length}

Output

  +	On the first line, you need to print all streets that you will check in alphabetical order.
    +	{street name} -> {street name} -> …
    +	If there are no streets for patrolling, don't print anything.
  +	On the second line, you need to print the Pokémon count.
    +	"Total Pokemon caught -> {count}"
  +	On the third line, you need to print the remaining fuel.
    +	"Fuel left -> {fuel}"

Constraints

  +	The fuel – f will be an integer in the range [0…1000]
  +	The number of streets will be an integer in the range [0…1000]
  +	The street length will be an integer in the range [0…1000]
  +	The Pokémon count per street will be an integer in the range [0…100]

Examples

| Input | Output |
| --- | --- |
| 4 <br> Street 1, 4, 1 <br> Street 2, 8, 3 <br> Street 3, 2, 2 <br> Street 4, 5, 4 <br> End | Street 1 -> Street 2 <br> Total Pokemon caught -> 12 <br> Fuel Left -> 0 |
| 10 <br> DoNotPickMe, 1, 50 <br> End | Total Pokemon caught -> 0 <br> Fuel Left -> 10 |

### Problem 2. Robbery

You are robber who just stole a TV. Now you must escape the cops without being caught. 

You are given a map of the city streets. There are few rules:

  +	Going from one point to other costs you some energy (displayed as a value on each arrow) and takes one turn.
  +	Each point is being watched by a video camera. A point can be black (a camera is not watching it) or white (a camera is watching it). 
  +	You can only travel to points where the camera is off.

Find the path that requires the least energy to go to the final point. Print the required energy.

Input

  +	On the first line you will receive a number - n specifying the number of points.
  +	On the second line you will receive a number - c specifying the number of point connections.
  +	On the next c lines you will receive the connections in the format "\<firstPoint\> \<secondPoint\> \<distance\>"
  +	On the next line you will receive all points in the format "\<point1\>\<color1\> \<point2\>\<color2\> …\<pointK\>\<colorK\>".  
  +	On the next line, you will receive the starting point.
  +	On the next line, you will receive the ending point.

Output

  +	Print the energy of the path that requires the least energy to go to the final point. 

Constraints
  
  +	The number of points in the city will be between [2…20000].
  +	The distance of a connection will be a valid integer between [0…10000].
  +	The points will always be numbers starting from [0… number of points – 1].
  +	The color will be either "b" or "w" – b means the camera is currently not watching, w means the camera is currently watching.
  +	There will always be a valid path from start to end.

Example

| Input | Output |
| --- | --- |
| 5 <br> 7 <br> 0 1 30 <br> 0 2 2 <br> 1 3 12 <br> 1 4 15 <br> 2 1 3 <br> 2 3 15 <br> 3 4 18 <br> 0b 1b 2w 3b 4b <br> 0 <br> 4 | 45 |

### Problem 3. Water Supply System Disaster

You are given a system of pipes and N connecting parts. The pipes are bidirectional, so the water can flow both ways.  

Your task is to find the connecting part, which if blown with an explosive, will leave exactly M separated parts of the system. 

Input

  +	On the first line there will be N – the total number of connecting parts in the system.
    +	The parts are numbered from 1 to N.
  +	On the second line there will be M – the separated parts of the system after the explosion.
  +	On the next N lines there will be the connections between the connecting parts. 
    +	List of connections (separated by a space) for the connecting parts from 1 to N. 
      +	On the first of the lines there will be connections for the first connecting part.
      +	On the second – the connections of the second connecting part and so on.

Output

  +	If the system is connected initially but we cannot separate it to exactly M parts with one explosive – print the number 0.
  +	If the system is connected initially and we can separate it to exactly M parts – print the part, we want to explode.

Constraints

  +	N will be an integer in the range [2…1000].
  +	M will be an integer in the range [2…10].
  +	There will be only one possible solution in all tests.

Examples

| Input | Output |
| --- | --- |
| 5 <br> 2 <br> 4 5 <br> 3 5 <br> 2 5 <br> 1 5 <br> 1 2 3 4 | 5 |
| 5 <br> 2 <br> 5 <br> 3 5 <br> 2 5 <br> 5 <br> 1 2 3 4 | 0 |