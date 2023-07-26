## PROBLEMS DESCRIPTION - GRAPHS, BELLMAN-FORD, LONGEST PATH IN DAG (Lecture)


### Problem 1.	Bellman-Ford

Find the shortest path in a graph and print it as a sequence from S vertex to D vertex.

Implement the Bellman-Ford algorithm.

The input comes from the console:

  + On the first line, you will receive an integer – n – the number of nodes.
  + On the next line, you will receive an integer – e – the number of edges.
  + On the next e lines, you will receive an edge in the following format: "{from} {to} {weight}".
  + On the last two lines, you will receive source and destination nodes.

Output

  + Print "Negative Cycle Detected" if you detect a negative cycle.
  + Otherwise, print the shortest path separated by a space and the total distance.

Examples

| Input | Output |
| --- | --- |
| 6 <br> 8 <br> 1 2 8 <br> 1 3 10 <br> 2 4 1 <br> 3 6 2 <br> 4 3 -4 <br> 4 6 -1 <br> 6 5 -2 <br> 5 3 1 <br> 1 <br> 6 | 1 2 4 3 6 <br> 7 |
| 4 <br> 4 <br> 1 2 1 <br> 2 3 -1 <br> 3 4 -1 <br> 4 1 -1 <br> 1 <br> 4 | Negative Cycle Detected |

### Problem 2. Longest Path

Find the longest path from S to D in a graph and print the total distance of that path.

The input comes from the console:

  + On the first line, you will receive an integer – n – number of nodes.
  + On the second line, you will receive an integer – e – number of edges.
  + On the next e lines, you will receive edges in the following format: "{source} {destination} {weight}".
  + On the next line, you will receive an integer – s – the start of the path.
  + On the last line, you will receive an integer – d – the destination of the path.

Output

  + Print the total distance of the longest path.

Examples

| Input | Output |
| --- | --- |
| 4 <br> 4 <br> 1 2 5 <br> 1 3 3 <br> 3 4 6 <br> 4 2 4 <br> 1 <br> 2 | 13 |
| 6 <br> 10 <br> 1 2 5 <br> 1 3 3 <br> 2 4 6 <br> 2 3 2 <br> 3 5 4 <br> 3 6 2 <br> 3 4 7 <br> 4 6 1 <br> 4 5 3 <br> 5 6 4 <br> 1 <br> 6 | 21 |