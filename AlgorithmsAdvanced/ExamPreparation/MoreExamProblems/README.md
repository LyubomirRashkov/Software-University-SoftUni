## PROBLEMS DESCRIPTION - More Exam Problems


### Problem 1.	Food Programme

You have a new job as a planner for the Food Programme. 

Your task is to plan the new food delivery from a given logistic center to those in need. The only requirement is to find the fastest way possible. The road network will be represented as zones (numbers from 0 … n-1) and the time for travelling between each pair of towns will be another integer. 

There may be many roads between different towns, consider this as a regular road network. As in normal non-regulated road you can move in the both directions.

Input

  +	The first line holds an integer n – the number of zones
  +	On the second line, you will receive the number m – the number of roads 
  +	On the third line the start and the destination {start} {destination}
  +	At the next m lines, you will receive the roads in the format: {from} {to} {time}

Output

  +	Print on the first line the path for the delivery
  +	On the second line the pre-calculated time

Constraints

  +	Number of zones will be an integer in the range [0…10000]
  +	Number of roads will be an integer in the range [0…10000]
  +	The time for travelling will be an integer in the range [0…10000]
  +	All zones will be numbered from 0 to N - 1.

Examples

| Input | Output |
| --- | --- |
| 7 <br> 10 <br> 0 6 <br> 0 2 13 <br> 2 1 2 <br> 1 0 3 <br> 3 0 42 <br> 3 1 4 <br> 2 4 12 <br> 3 4 8 <br> 4 5 7 <br> 5 6 16 <br> 6 3 3 | 0 1 3 6 <br> 10 |
| 3 <br> 3 <br> 0 2 <br> 0 1 12 <br> 1 2 30 <br> 0 2 3 | 0 2 <br> 3 |

### Problem 2. Vampire Labyrinth

You have to do something to help the team of vampire slayers to reach the temple of Bag' Hara and defeat the master vampire. 

You need to plan the path from the landing place to the temple through a labyrinth. The only requirement is to find the way with least vampire guards. The labyrinth contains many different ways to go through and for each way you know the vampires count, thanks to your hi-tech vamp-detector. 

Input

  +	The first line holds an integer n – the number of nodes
  +	On the second line, you will receive the number m – the number of ways
  +	On the third line the landing place and the temple {landingPlace} {temple}
  +	At the next m lines, you will receive the labyrinth in the format: {from} {to} {vampiresCount}

Output

  +	Print on the first line the way to the temple
  +	On the second line the number of vampires along the way

Constraints

  +	Number of nodes will be an integer in the range [0…10000]
  +	Number of ways will be an integer in the range [0…10000]
  +	The number of vampires will be an integer in the range [0…10000]
  +	All nodes will be numbered from 0 to N - 1.

Examples

| Input | Output |
| --- | --- |
| 4 <br> 3 <br> 0 3 <br> 0 1 8 <br> 1 2 4 <br> 2 3 5 | 0 1 2 3 <br> 17 |
| 7 <br> 9 <br> 3 5 <br> 0 1 8 <br> 1 2 4 <br> 2 3 5 <br> 3 4 12 <br> 4 5 8 <br> 4 6 1 <br> 6 5 2 <br> 3 4 2 <br> 0 1 2 | 3 4 6 5 <br> 5 |

### Problem 3. Data Transfer

This time you are transferring data.

Your task is to transfer the optimal amount of data from emitter to receiver which are a part of a network. 

You will be given the network represented by emitters and receivers and a specified single source and destination to which you want to calculate the optimal data transferable from that source.  

You can transfer data from any emitter to any receiver as long as there is connection between them a connection can be directly linked or sequence of connections linking those elements. Each connection will have specified data volume transferable through it. 

Input

  +	The first line holds an integer n – the number of devices
  +	On the second line, you will receive the number m – the number of connections 
  +	On the third line the emitter and the receiver as {source} {destination}
  +	At the next m lines, you will receive the network in the format: {from} {to} {dataVolume}

Output

  +	On a single line print the optimal amount of data transferable.

Constraints

  +	Number of devices will be an integer in the range [0…10000]
  +	Number of connections will be an integer in the range [0…10000]
  +	The data transfer will be an integer in the range [0…10000]
  +	All devices will be numbered from 0 to N - 1.

Examples

| Input | Output |
| --- | --- |
| 5 <br> 5 <br> 2 4 <br> 0 1 3 <br> 1 4 2 <br> 2 4 4 <br> 0 2 15 <br> 0 3 3 | 4 |
| 10 <br> 9 <br> 1 8 <br> 0 1 17 <br> 1 2 14 <br> 1 3 6 <br> 2 3 32 <br> 3 7 7 <br> 2 4 1 <br> 7 6 9 <br> 7 8 8 <br> 1 8 10 | 17 |

### Problem 4. Picker

Your task is simple you are the best programmer of automated pickers inside the new all in automated storage. But a client has a strange request for the picking process. 

You will be given strange sculpture created only by steel spheres connected by steel bars. The bars weight differently. You need to print the minimum bars that are required to hold the entire structure and also add up to the least weight. That is they right way for picking.

Input

  +	The first line holds an integer n – the number of spheres
  +	On the second line, you will receive the number m – the number of bars 
  +	At the next m lines, you will receive the sculpture in the format: {from} {to} {barWeight}

Output

  +	Each bar of the minimum required to pick up the sculpture the represented by {from} {to} separated by space each on a new line
  +	On the last line print the added up sum of the above bar's weights

Constraints

  +	Number of spheres will be an integer in the range [0…10000]
  +	Number of bars will be an integer in the range [0…10000]
  +	The weights will be an integer in the range [0…10000]
  +	All spheres will be numbered from 0 to N - 1.

Examples

| Input | Output |
| --- | --- |
| 5 <br> 5 <br> 0 1 3 <br> 1 4 2 <br> 2 4 4 <br> 0 2 15 <br> 0 3 3 | 1 4 <br> 0 1 <br> 0 3 <br> 2 4 <br> 12 |
| 10 <br> 9 <br> 0 1 17 <br> 1 2 14 <br> 1 3 6 <br> 2 3 32 <br> 3 7 7 <br> 2 4 1 <br> 7 6 9 <br> 7 8 8 <br> 1 8 10 | 2 4 <br> 1 3 <br> 3 7 <br> 7 8 <br> 7 6 <br> 1 2 <br> 0 1 <br> 62 |