## PROBLEMS DESCRIPTION - Exam 20 February 2021


### Problem 1.	Black Friday

The year is 1955 and online shopping doesn’t exist. However, "Black Friday" is approaching, and Roi wants to be prepared.

Roi wants to visit every shop in the town for as little time as possible. So, you are appointed to solve this problem.

You will be given the number of shops on the first line, then the number of roads (n), and on the next n lines you will receive which shops the road connects and the travel time. 

Assume you can start from any shop and your target is to visit every one of them with the minimum travel time.

Input

  +	On the first line you will be given the number of the shops.
  +	On the second line you will be given the number of streets (n)
  +	On the next n lines, you will be given a connection in the format: "{firstShop} {secondShop} {time}"

Output

  +	Print the total time of the trip you have chosen. 

Example

| Input | Output |
| --- | --- |
| 5 <br> 6 <br> 0 3 10 <br> 0 4 2 <br> 4 1 6 <br> 1 3 11 <br> 2 3 5 <br> 2 4 15 | 23 |

### Problem 2. Boxes

You're given a sequence of arrays where each array holds three integers and represents a box. 

These integers denote each box width, depth, and height, respectively. Your goal is to stack up the boxes and to maximize the total height of the stack. A box must have a strictly smaller width, depth, and height than any other box below it.

Write a program that prints the boxes in the final stack, starting with the top box and ending with the bottom box. If several sequences with equal length exist, find the left-most of them.

Input

  +	On the first you will receive an integer – boxes – number of boxes that you will receive.
  +	On the next boxes lines you will receive the width, depth, and height of a box in the following format: "{width} {depth} {height}".

Output

  +	Print the boxes in the final stack, starting with the top box and ending with the bottom box.
  +	Print each box in the following format: "{width} {depth} {height}".

Example

| Input | Output |
| --- | --- |
| 6 <br> 2 1 2 <br> 3 2 3 <br> 2 2 8 <br> 2 3 4 <br> 1 3 1 <br> 4 4 5 | 2 1 2 <br> 3 2 3 <br> 4 4 5 |

### Problem 3. Emergency Plan

You are given a building plan of a school:

![изображение](https://github.com/LyubomirRashkov/Software-University-SoftUni/assets/82647282/ba5693fd-92e0-4ae1-8b3d-8aa137d594a8)

In the example above, we are given the time it takes to go from one room to another (e.g. from A to B it takes exactly 7 minutes). 

All students must evacuate in time T = 9 minutes. The red circles denote exits. Assume that the students know the quickest way to an exit and will always take it. We find quickest exit routes for each room:

| Room | A | B | C | D | G |
| --- | --- | --- | --- | --- | --- |
| Time to Exit | 8:55 | 4:10 | 7:00 | 6:40 | 9:15 |

Room G cannot be evacuated in time T = 9 minutes. Therefore, the room is not safe.+

Input

  +	On the first input line the number of rooms N will be given. Rooms will be numbered from 0 to N-1.
  +	On the second input line the the exit rooms will be given in the format "E1 E2 … En".
  +	On the third input line the number of connections C between rooms will be given.
  +	On the next C lines connections will be given in the format "RA RB T", denoting the time it takes to go from room A to room B (applies for both directions).
  +	On the last line you will be given the time T in which all rooms must be evacuated. 

Output

  +	For each room (starting from 0) print one of the following:
    +	If the room can be evacuated: "Safe {room} ({best time to nearest exit})".
    +	If the room cannot be evacuated: "Unsafe {room} ({best time to nearest exit})".
    +	If a room has no access to an exit: "Unreachable {room} (N/A)".
    +	All output times should be printed in the format "hh:mm:ss". 

Constraints

  +	All input times will be given in the format "mm:ss". They will be in the range [00:01…59:59].
  +	The number of rooms N will be an integer number in the range [1…100].
  +	Output times will not exceed 23:59:59.
  +	The number of exits E will be an integer number in the range [1…100]

Examples

| Input | Output |
| --- | --- |
| 7 <br> 5 4 <br> 7 <br> 1 5 04:10 <br> 2 4 07:00 <br> 6 2 02:15 <br> 0 3 02:15 <br> 1 0 07:00 <br> 1 3 02:30 <br> 2 0 03:30 <br> 09:00 | Safe 0 (00:08:55) <br> Safe 1 (00:04:10) <br> Safe 2 (00:07:00) <br> Safe 3 (00:06:40) <br> Unsafe 6 (00:09:15) |
| 5 <br> 4 <br> 5 <br> 1 2 02:30 <br> 2 3 07:30 <br> 1 3 02:15 <br> 1 4 04:30 <br> 4 3 01:15 <br> 04:00 | Unreachable 0 (N/A) <br> Safe 1 (00:03:30) <br> Unsafe 2 (00:06:00) <br> Safe 3 (00:01:15) |