## PROBLEMS DESCRIPTION - GRAPH THEORY, TRAVERSAL AND SHORTEST PATHS (Lecture)


### Problem 1.	Connected Components

The first part of this lab aims to implement the DFS algorithm (Depth-First-Search) to traverse a graph and find its connected components (nodes connected either directly, or through other nodes). 

The graph nodes are numbered from 0 to n-1. The graph comes from the console in the following format:

  + First line: number of lines n
  + Next n lines: list of child nodes for the nodes 0 … n-1 (separated by a space)

Print the connected components in the same format as in the examples below.

Examples

| Input | Output |
| --- | --- |
| 9 <br> 3 6 <br> 3 4 5 6 <br> 8 <br> 0 1 5 <br> 1 6 <br> 1 3 <br> 0 1 4 <br>  <br> 2 | Connected component: 6 4 5 1 3 0 <br> Connected component: 8 2 <br> Connected component: 7 |
| 0 |  |

### Problem 2. Topological Sorting

We’re given a directed graph which means that if node A is connected to node B and the vertex is directed from A to B, we can move from A to B, but not the other way around, i.e. we have a one-way street. We’ll call A "source" or "predecessor" and B – "child".

Let’s consider the tasks a SoftUni student needs to perform during an exam – "Read description", "Receive input", "Print output", etc.

Some of the tasks depend on other tasks – we cannot print the output of a problem before we get the input. If all such tasks are nodes in a graph, a directed vertex will represent dependency between two tasks, e.g. if A -> B (A is connected to B and the direction is from A to B), this means B cannot be performed before completing A first. Having all tasks as nodes and the relationships between them as vertices, we can order the tasks using topological sorting.

After the sorting procedure, we’ll obtain a list showing all tasks in the order in which they should be performed. Of course, there may be more than one such order, and there usually is, but in general, the tasks which are less dependent on other tasks will appear first in the resulting list.

For this problem, you need to implement topological sorting over a directed graph of strings.

Input

  + On the first line, you will receive an integer n – nodes count.
  + On the next n lines, you will receive nodes in the following format: "{key} -> {children1}, {children2},… {childrenN}".
    + It is possible some of the keys to not having any children.

Output

  + If the sorting is possible then print "Topological sorting: {sortedKey1}, {sortedKey2}, …{sortedKeyN}".
  + Otherwise, print "Invalid topological sorting".

Examples

| Input | Output |
| --- | --- |
| 6 <br> A -> B, C <br> B -> D, E <br> C -> F <br> D -> C, F <br> E -> D <br> F -> | Topological sorting: A, B, E, D, C, F |
| 5 <br> IDEs -> variables, loops <br> variables -> conditionals, loops, bits <br> conditionals -> loops <br> loops -> bits <br> bits -> | Topological sorting: IDEs, variables, conditionals, loops, bits |
| 2 <br> A -> B <br> B -> A | Invalid topological sorting |

### Problem 3.Shortest Path

You will be given a graph from the console your task is to find the shortest path and print it back on the console. The first line will be the number of Nodes - N the second one the number of Edges - E, then on each E line the edge in form {destination} – {source}. On the last two lines, you will read the start node and the end node.

Print on the first line the length of the shortest path and the second the path itself, see the examples below.

Examples

| Input | Output |
| --- | --- |
| 8 <br> 10 <br> 1 2 <br> 1 4 <br> 2 3 <br> 4 5 <br> 5 8 <br> 5 6 <br> 5 7 <br> 5 8 <br> 6 7 <br> 7 8 <br> 1 <br> 7 | Shortest path length is: 3 <br> 1 4 5 7 |
| 11 <br> 11 <br> 1 5 <br> 1 4 <br> 5 7 <br> 7 8 <br> 8 2 <br> 2 3 <br> 3 4 <br> 4 1 <br> 6 2 <br> 9 10 <br> 11 9 <br> 6 <br> 3 | Shortest path length is: 2 <br> 6 2 3 |