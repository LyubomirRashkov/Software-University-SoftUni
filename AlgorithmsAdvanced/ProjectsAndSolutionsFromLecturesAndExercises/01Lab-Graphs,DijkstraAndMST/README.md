## PROBLEMS DESCRIPTION - GRAPHS, DIJKSTRA, MST (Lecture)


### Problem 1.	Dijkstra's Algorithm

Finding the shortest path between two nodes in an unweighted graph is done by applying simple BFS. Though we're working with weighted graphs, things get more complicated. Dijkstra's algorithm is one of the most famous ones that solve this task.

A classical application of the shortest path algorithm might be to find the shortest path between two towns on a map holding towns connected with roads where each road holds the distance between two towns.

In this problem, we'll try to implement the optimized version of Dijkstra's algorithm using a priority queue.

Input

  + On the first, you will receive an integer – e – number of edges.
  + On the next e lines, you will receive an edge in the following format: "{start}, {end}, {weight}".
  + On the next line, you will receive a start node.
  + On the last line, you will receive an end node.

Output

  + Print the cost of the shortest path.
  + Print all nodes that form the shortest path.
  + If the end node can't be reached from the start node, then you have to print: "There is no such path."

Example

| Input | Output |
| --- | --- |
| 18 <br> 0, 6, 10 <br> 0, 8, 12 <br> 6, 4, 17 <br> 6, 5, 6 <br> 8, 5, 3 <br> 5, 4, 5 <br> 5, 11, 33 <br> 8, 2, 14 <br> 2, 11, 9 <br> 2, 7, 15 <br> 4, 1, 20 <br> 4, 11, 11 <br> 11, 1, 6 <br> 11, 7, 20 <br> 1, 9, 5 <br> 1, 7, 26 <br> 7, 9, 3 <br> 3, 10, 7 <br> 0 <br> 9 | 42 <br> 0 8 5 4 11 1 9 |

### Problem 2. Kruskal's Algorithm

If we have a weighted undirected graph, we can extract a sub-graph where edges connect all nodes (vertices) of the original graph without any cycles. This is referred to as a spanning tree. A minimum spanning tree (MST) is the spanning tree with the smallest weight (several MST could exist in some graphs).

For example, a cable operator wants to connect its customers to a cable network. The customers' homes are connected by streets (edges) with different lengths (weights). You need to find the MST to find out how to connect all homes to its network most efficiently (least distance covered).

Input

  + On the first line, you will receive e – an integer – the number of edges you must read.
  + On the next e lines, you will receive an edge in the following format: "{firstNode}, {seconNode}, {weight}".

Example

| Input | Output |
| --- | --- |
| 11 <br> 0, 3, 9 <br> 0, 5, 4 <br> 0, 8, 5 <br> 1, 4, 8 <br> 1, 7, 7 <br> 2, 6, 12 <br> 3, 5, 2 <br> 3, 6, 8 <br> 3, 8, 20 <br> 4, 7, 10 <br> 6, 8, 7 | 3 - 5 <br> 0 - 5 <br> 0 - 8 <br> 1 - 7 <br> 6 - 8 <br> 1 - 4 <br> 2 - 6 |

### Problem 3. Prim's Algorithm

If we have a weighted undirected graph, we can extract a sub-graph where edges connect all nodes (vertices) of the original graph without any cycles. This is referred to as a spanning tree. A minimum spanning tree (MST) is the spanning tree with the smallest weight (several MST could exist in some graphs).

For example, a cable operator wants to connect its customers to a cable network. The customers' homes are connected by streets (edges) with different lengths (weights). You need to find the MST to find out how to connect all homes to its network most efficiently (least distance covered).

Input

  + On the first line, you will receive e – an integer – the number of edges you must read.
  + On the next e lines, you will receive an edge in the following format: "{firstNode}, {seconNode}, {weight}".

Output

  + Print all edges part of the minimum spanning tree in the following format: "{first} - {second}".
  + The order of the output doesn't matter.

Example

| Input | Output |
| --- | --- |
| 11 <br> 0, 2, 5 <br> 2, 4, 7 <br> 4, 5, 12 <br> 0, 1, 4 <br> 1, 3, 2 <br> 0, 3, 9 <br> 2, 3, 20 <br> 3, 4, 8 <br> 6, 7, 8 <br> 6, 8, 10 <br> 7, 8, 7 | 0 - 1 <br> 1 - 3 <br> 0 - 2 <br> 2 - 4 <br> 4 - 5 <br> 6 - 7 <br> 7 - 8 |