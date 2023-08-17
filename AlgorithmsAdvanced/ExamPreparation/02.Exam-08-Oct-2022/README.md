## PROBLEMS DESCRIPTION - Exam 08 October 2022


### Problem 1.	Trains Part Two

You need to come up with a solution for the shortest spare parts distribution system. You have the map with the train depots on it all you need to do is find the shortest way to deliver part from the depot in which they have it, to the depot that requires it.

Input

  +	The input will come from the console on several lines:
    +	The first line holds an integer n – the number of depots
    +	On the second line, you will receive the number m – the number of train tracks between all the depots
    +	On the third line the depot that has the part and the one that needs the part {start} {end}
    +	At the next m lines, you will receive the network in the format: {a} {b} {distance}

Output

  +	On the first line print the shortest way to deliver the part.
  +	On the second line print the total distance of the way.

Constraints
  
  +	Number of depots will be an integer in the range [0…10000]
  +	Number of train tracks will be an integer in the range [0…10000]
  +	The distance is always an integer [0…10000]
  +	All depots will be numbered from 0 to N - 1.
  +	You can consider that if there is a train track between two depots you can travel in both directions

Examples

| Input | Output |
| --- | --- |
| 6 <br> 6 <br> 0 4 <br> 0 1 13 <br> 1 2 12 <br> 2 4 1 <br> 2 3 43 <br> 4 5 21 <br> 5 0 1 | 0 5 4 <br> 22 |
| 8 <br> 9 <br> 4 0 <br> 0 1 1 <br> 0 7 2 <br> 7 6 3 <br> 6 5 3 <br> 5 0 4 <br> 1 2 5 <br> 2 3 5 <br> 2 4 6 <br> 4 5 7 | 4 5 0 <br> 11 |

### Problem 2. Creep

The Zerg hivemind needs creep to so it can swarm new zones. You task here would be to optimize the creep tumors spread in such a way that creep can be placed at all the new zones but with minimum creep tumor vines length used. You will be given all the possible positions of the creep tumors and the vine’s lengths required to connect all of them.

Input

  +	The first line holds an integer n – the number of tumors/zones
  +	On the second line, you will receive the number m – the number of vines 
  +	At the next m lines, you will receive the vines lengths and connections in the format: {from} {to} {length}

Output

  +	First line prints all the vines that you selected each on a new line in the following format {from} {to}
  +	On the last line print the total sum of vine length used

Constraints

  +	Number of tumors will be an integer in the range [0…10000]
  +	Number of vines will be an integer in the range [0…10000]
  +	The distances will be integers in the range [0…10000]
  +	All tumors will be numbered from 0 to N - 1.

Examples

| Input | Output |
| --- | --- |
| 5 <br> 4 <br> 0 1 3 <br> 1 4 2 <br> 2 4 4 <br> 0 3 3 | 1 4 <br> 0 1 <br> 0 3 <br> 2 4 <br> 12 |
| 5 <br> 10 <br> 1 0 29 <br> 3 4 63 <br> 2 3 1 <br> 0 2 52 <br> 4 0 27 <br> 0 3 99 <br> 4 2 35 <br> 3 2 9 <br> 3 1 57 <br> 4 0 10 | 2 3 <br> 4 0 <br> 1 0 <br> 4 2 <br> 75 |

### Problem 3. Code

The clacks towers are sending a very urgent coded message, your task is to decode it. The messages travel as integers.

You will be given two sequences of integers representing two separate messages in which the code is hidden. You need to decode it. To decode it you must find the equal parts from both messages that are with the longest length.

Input

  +	Two lines of integers separated by spaces those are the messages

Output

  +	On the first line print the decoded message, it should be the rightmost
  +	On the second line print the length

Constraints

  +	The length of the messages will be between [1…5000]

Examples

| Input | Output |
| --- | --- |
| 7 42 8 4 13 21 6 <br> 7 32 8 13 19 6 | 7 8 13 6 <br> 4 |
| 7 6 5 4 3 2 1 <br> 7 10 6 12 5 13 4 14 3 15 2 16 1 17 | 7 6 5 4 3 2 1 <br> 7 |