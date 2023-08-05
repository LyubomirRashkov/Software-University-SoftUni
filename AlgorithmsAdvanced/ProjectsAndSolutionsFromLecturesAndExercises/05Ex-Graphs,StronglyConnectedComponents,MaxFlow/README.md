## PROBLEMS DESCRIPTION - GRAPHS, STRONGLY CONNECTED COMPONENTS, MAX FLOW (Exercise)


### Problem 1.	Electrical Substation Network

Print all connected electrical substations in a town using the existing network. The substations are represented as vertices, and the connections are represented as edges.

Input

  + On the first line, you will receive an integer – n – number of nodes starting from 0.
  + On the second line, you will receive an integer – l – number of lines.
  + On the next l lines, you will receive a node and its children in the following format: "{node}, {children1}, … {childrenN}".

Output

  + Print all connected electrical substations in topological order in the following format: "{node1}, {node2},… {nodeN}".
    + Nodes in each component should be printed in topological order too.

Examples

| Input | Output |
| --- | --- |
| 3 <br> 3 <br> 0, 1 <br> 1, 2 <br> 2, 0 | 0, 2, 1 |
| 15 <br> 15 <br> 0, 0, 2 <br> 1, 0 <br> 2, 1, 4 <br> 3, 0, 1, 11, 12 <br> 4, 5, 7 <br> 5, 7, 9, 6 <br> 6, 9 <br> 7, 8, 9 <br> 8, 4, 10 <br> 9, 8, 10, 13 <br> 10, 11, 13 <br> 11, 12 <br> 12, 10, 14 <br> 13, 12 <br> 14, 13 | 3 <br> 0, 1, 2 <br> 4, 8, 9, 6, 7, 5 <br> 10, 12, 13, 14, 11 |

### Problem 2. Maximum Tasks Assignment

We have L people and R tasks. Each person can complete at most one task. One task can be completed by at most one person. We have a table that shows which people can complete which tasks. Find the maximum assignment that assigns tasks to people to complete a maximum number of tasks.

Input

  + On the first line, you will receive an integer – people.
  + On the next line, you will receive an integer – task.
  + On the next people lines, you will receive a line consisting of either "Y" or "N".
    + "Y" means that this person can complete the ith task.

Examples

Assume people will be marked by letters of the English alphabet and tasks by numbers starting from 1

| Input | Output |
| --- | --- |
| 3 <br> 3 <br> YNY <br> NYY <br> YYN | A-3 <br> B-2 <br> C-1 |
| 4 <br> 4 <br> YNYN <br> NYYN <br> YNYY <br> NNNY | A-1 <br> B-2 <br> C-3 <br> D-4 |

### Problem 3. Find Bi-Connected Components

Finding the articulation points in an undirected graph is a well-known problem in computer science. A related problem (a bit harder) is to find the bi-connected components in a graph – it's a set of maximal bi-connected subgraphs.

Each bi-connected component has the property that removing any of its nodes does not break the paths between all its other nodes.

Input

  + On the first line, you will receive an integer – n – number of nodes starting from zero.
  + On the second line, you will receive an integer – e – number of edges.
  + On the next e lines, you will receive edges in the following format: "{first} {second}".

Examples

| Input | Output |
| --- | --- |
| 13 <br> 17 <br> 0 1 <br> 0 2 <br> 0 6 <br> 0 7 <br> 0 9 <br> 1 6 <br> 2 7 <br> 3 4 <br> 4 6 <br> 4 10 <br> 5 7 <br> 6 8 <br> 6 10 <br> 6 11 <br> 7 9 <br> 7 12 <br> 8 11 | Number of bi-connected components: 7 |
| 13 <br> 20 <br> 0 1 <br> 0 2 <br> 0 6 <br> 0 7 <br> 0 9 <br> 0 11 <br> 1 6 <br> 2 7 <br> 3 4 <br> 3 8 <br> 4 6 <br> 4 10 <br> 5 7 <br> 5 12 <br> 6 8 <br> 6 10 <br> 6 11 <br> 7 9 <br> 7 12 <br> 8 11 | Number of bi-connected components: 3 |