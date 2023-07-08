## PROBLEMS DESCRIPTION - Exam 03 January 2021


### Problem 1.	TBC

Given a matrix (city map) of 't's (tunnel) and 'd's (dirt), count the number of connected tunnels in the city. 

A connected tunnel is surrounded by dirt and is formed by connecting adjacent 't's horizontally, vertically or diagonally. 

Input

  +	On the first line you will receive an integer – r – representing the number of rows in the map.
  +	On the second line you will receive an integer – c – representing the number of columns in the map.
  +	On the next r lines, you will receive values for each row in a single line.

Output

  +	Print the number of connected tunnels.

Constraints

  +	You may assume all four edges of the city map are all surrounded by dirt.
  +	r and c will be in the range [1, 1000].
  + Map elements will be either t or d.

Examples

| Input | Output |
| --- | --- |
| 4 <br> 6 <br> tddddt <br> dtdddt <br> ddtddt <br> dddtdt | 2 |
| 4 <br> 6 <br> tdttdt <br> tdttdt <br> tdttdt <br> tdttdt | 3 |

### Problem 2. Socks

You will be given two sequences of integers representing socks – left and right socks. 

We are trying to connect each sock from one side with the corresponding sock on the other side. Find the longest sequence that appears in the same relative order, but not necessarily contiguous.

Input

  +	You will receive 2 arrays of integers – left and right socks – in the following format: "{sock1} … {sockN}".

Output
  
  +	Print the length of the longest sequence that appears in the same relative order.

Constraints

  +	Prices will be integers in the range [1… 2 147 483 647].
  +	The input arrays will always contain at least 1 element.

Examples

| Input | Output |
| --- | --- |
| 31 41 29 32 42 40 26 <br> 31 30 32 42 28 29 29 | 3 |
| 32 32 29 32 29 <br> 29 32 32 29 32 | 4 |

### Problem 3. Path Finder

Write a program to check if a given path is existing in a graph.

Input

  +	You will receive an integer – n – number of nodes in a graph.
    +	The graph nodes are numbered from 0 to n - 1.
  +	On the next n lines, you will receive a list of children for the nodes 0 … n - 1 (separated by a space).
  +	On the next line you will receive an integer – p – number of paths to check.
  + On the next p lines, you will receive a path of nodes (separated by a space).

Output

  +	For each path print either "yes" – if the path exists, or "no" if the path does not exist.

Constraints

  +	Path will always contain at least 2 nodes.
  +	Nodes in the path will always be in the range [0… n – 1].

Examples

| Input | Output |
| --- | --- |
| 7 <br> 3 6 <br> 4 5 <br>  <br> 1 <br>  <br>  <br> 1 2 <br> 3 <br> 0 3 1 5 <br> 0 3 1 5 6 <br> 0 6 2 | yes <br> no <br> yes |
| 5 <br> 3 4 <br> 2 <br>  <br> 1 <br> 1 <br> 3 <br> 0 3 2 1 <br> 0 4 1 2 <br> 0 4 1 3 | no <br> yes <br> no |