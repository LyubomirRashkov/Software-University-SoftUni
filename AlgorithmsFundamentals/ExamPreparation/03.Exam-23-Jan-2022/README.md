## PROBLEMS DESCRIPTION - Exam 23 January 2022


### Problem 1.	Move Down / Right

Marinette has the ability to transform into Ladybug. She is stuck on a grid. Her initial location is at the top-left corner and tries to move to the bottom-right corner. 

However, she can only move either down or right at any point in time.

Write a program that prints the number of all possible unique paths that Marinette can take to reach the bottom-right corner.

Input

  +	On the first line you will receive an integer – m – number of rows.
  +	On the second line you will receive an integer – n – number of cols.

Output

  +	Print the number of all possible unique paths to the bottom-right corner. 

Constraints
 
  +	m and n will always be in the range [0… 1000].

Examples

| Input | Output |
| --- | --- |
| 3 <br> 2 | 3 |
| 3 <br> 5 | 15 |
| 35 <br> 12 | 10150595910 |

### Problem 2. Universes

There are n planets. Some of them are connected, while some are not. If planet a is connected directly with planet b, and planet b is connected directly with planet c, then planet a is connected indirectly with planet c.

A universe is a group of directly or indirectly connected planets and no other planets outside of the group.

Write a program that prints the total number of universes.

Input

  +	On the first line you will receive an integer – l – number of lines.
  +	On the next l lines, you will receive a list in the following format: "{planet1} - {planet2}".
    +	This means that planet1 and planet2 are connected.

Output

  +	Print the total number of universes. 

Constraints
  
  +	Number of planets will be in the range [1… 20].
  +	Number of lines will be in the range [1… 100].

Examples

| Input | Output |
| --- | --- |
| 5 <br> Mercury - Mars <br> Mars - Saturn <br> Saturn - Venus <br> Dibiasky - Arion <br> Dimidium - Galileo | 3 |

### Problem 3. Strings Mashup

Given a string, you should convert every letter to be lowercase or uppercase to create a mashup string.

Write a program that prints all possible mashup strings we could create.

Input

  +	You will receive a string – str.

Output

  +	Print all possible result strings, each on a new line. 
    +	Order doesn’t matter.

Constraints

  +	str length will be in the range [1… 20].
  +	str may contain only letters.

Examples

| Input | Output |
| --- | --- |
| x1y2z | X1Y2Z <br> X1Y2z <br> X1y2Z <br> X1y2z <br> x1Y2Z <br> x1Y2z <br> x1y2Z <br> x1y2z |