## PROBLEMS DESCRIPTION - Exam 09 January 2021


### Problem 1.	Super Set

Write a program that receives an array of unique integers and prints its super set.

Input

  +	On the first line you will receive an array of integers in the following format: "{el1}, …, {elN}".

Output

  +	Print the super set.
    +	Each subset should be printed on a single line.
      +	Elements in the subset should be printed in the following format: "{el1}, …, {elN}".

Constraints

  +	Elements in the array will be unique.
  +	Elements in the array will be positive integers in the range [-2147483648, 2147483647].
  +	Array’s length will be in the range [1, 50].

Examples

| Input | Output |
| --- | --- |
| 4, 5, 6 | 4 <br> 5 <br> 6 <br> 4 5 <br> 4 6 <br> 5 6 <br> 4 5 6 |
| 1, 3, 5, 7 | 1 <br> 3 <br> 5 <br> 7 <br> 1 3 <br> 1 5 <br> 1 7 <br> 3 5 <br> 3 7 <br> 5 7 <br> 1 3 5 <br> 1 3 7 <br> 1 5 7 <br> 3 5 7 <br> 1 3 5 7 |

### Problem 2. Paths

Given a directed acyclic graph (DAG) of n nodes (from 0 to n – 1), find all possible paths from each node to the last (n – 1) node.

Input

  +	On the first line you will receive an integer – n – number of nodes.
  +	On the next n lines, you will receive a list of children for the nodes 0 … n - 1 (separated by a space).

Output

  +	Print each path on a new line.
  +	Nodes in the path should be joined by a space.

Constraints

  +	Nodes in the path will always be in the range [0… n – 1].

Examples

| Input | Output |
| --- | --- |
| 5 <br> 1 <br> 2 3 <br> 3 <br> 4 | 0 1 2 3 4 <br> 0 1 3 4 <br> 1 2 3 4 <br> 1 3 4 <br> 2 3 4 <br> 3 4 |
| 5 <br> 1 3 <br> 2 3 <br> 3 4 <br> 4 | 0 1 2 3 4 <br> 0 1 2 4 <br> 0 1 3 4 <br> 0 3 4 <br> 1 2 3 4 <br> 1 2 4 <br> 1 3 4 <br> 2 3 4 <br> 2 4 <br> 3 4 |

### Problem 3. Climbing

Roi has to climb a building (N x M matrix with positive integers) from bottom right to top left. However, his path must be the path with the highest possible sum. Also, he can move only up or left.

Roi needs your help to find the path with the highest sum by following rules described above.

Input

  +	You will receive an integer – n – number of rows.
  +	You will receive an integer – m – number of cols.
  +	On the next n lines, you will receive col elements in the following format: "{colEl0} {colEl1} … {colElN}". 

Output

  +	Print the sum of the highest path.
  +	Print all cells value that are part of the highest sum path on a single line joined by a space.

Constraints

  +	n and m will be positive integers in the range [1,	 15].
  +	Column elements will be positive integers in the range [1, 999 999].

Examples

| Input | Output |
| --- | --- |
| 4 <br> 4 <br> 1 3 2 1 <br> 5 3 2 1 <br> 1 7 3 1 <br> 1 3 1 1 | 21 <br> 1 1 3 7 3 5 1 |
| 3 <br> 3 <br> 1 1 1 <br> 1 1 1 <br> 1 1 1 | 5 <br> 1 1 1 1 1 |