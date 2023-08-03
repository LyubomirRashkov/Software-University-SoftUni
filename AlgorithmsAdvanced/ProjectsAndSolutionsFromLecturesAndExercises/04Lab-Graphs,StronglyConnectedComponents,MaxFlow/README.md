## PROBLEMS DESCRIPTION - GRAPHS, STRONGLY CONNECTED COMPONENTS, MAX FLOW (Lecture)


### Problem 1.	Strongly Connected Components (SCC)

A strongly connected component is any subgraph in a graph that fulfills the prerequisite that for any two vertices u and v in the subgraph, there exists a path from u to v.

For example, you want to check if all towns on a map are reachable using the current road network. The towns are represented as vertexes, and the roads are represented as edges.

To find the groups in which all towns can reach one another, we need an algorithm for finding Strongly Connected Components (SCC).

We can use the Kosaraju-Sharir algorithm.

Input

  + On the first line, you will receive an integer – n – number of nodes starting from 0.
  + On the second line, you will receive an integer – l – number of lines.
  + On the next l lines, you will receive a node and its children in the following format: "{node}, {children1}, … {childrenN}".

Output

  + First, print "Strongly Connected Components:" on a single line.
  + After that, print all strongly connected components in topological order in the following format: "{{node1}, {node2},… {nodeN}}".
    + Nodes in each component should be printed in topological order too.

Example

| Input | Output |
| --- | --- |
| 14 <br> 13 <br> 0, 1, 11, 13 <br> 1, 6 <br> 2, 0 <br> 3, 4 <br> 4, 3, 6 <br> 5, 13 <br> 6, 0, 11 <br> 7, 12 <br> 8, 6, 11 <br> 9, 0 <br> 10, 4, 6, 10 <br> 12, 7 <br> 13, 2, 9 | Strongly Connected Components: <br> {10} <br> {8} <br> {7, 12} <br> {5} <br> {3, 4} <br> {0, 9, 6, 1, 2, 13} <br> {11} |

### Problem 2. Max Flow algorithm - Edmonds-Karp

Max flow algorithms are important because many problems can be modified and then represented as a max flow problem. In this problem, we'll try to implement the Edmonds-Karp algorithm.

Input

  + On the first line, you will receive an integer – n – number of nodes.
  + On the next n lines, you will receive n count elements separated by ", ".
    + Each element will represent the initial capacity for the given from and to indices.
      + Assume from the index is the line index and to index is the element index.
  + On the next line, you will receive an integer – source – starting node.
  + On the next line, you will receive an integer – destination – end node.

Output
  
  + Print the max flow in the following format: "Max flow = {maxFlow}".

Example

| Input | Output |
| --- | --- |
| 6 <br> 0, 10, 10, 0, 0, 0 <br> 0, 0, 2, 4, 8, 0 <br> 0, 0, 0, 0, 9, 0 <br> 0, 0, 0, 0, 0, 10 <br> 0, 0, 0, 6, 0, 10 <br> 0, 0, 0, 0, 0, 0 <br> 0 <br> 5 | Max flow = 19 |

### Problem 3. Articulation Points

Sometimes we need to find articulation points (cut vertices) in a certain network – points that, when removed, will split the graph into separated components.

In situations such as networks for ISPs (Internet Service Providers), electricity, or water, it is very important to have redundancy in the networks. If between every vertex u and vertex v in a network, there existed at least 2 different paths (paths that have no vertexes in common aside from the beginning and the end vertex), such a network would be called biconnected. However, if there existed some point x (different from u and v) which is always a part of any path between u and v, such a point would be an articulation point.

Let's implement the Hopcroft-Tarjan algorithm for finding the articulation points in the following graph.

Input

  + On the first line, you will receive an integer – n – number of nodes starting from 0.
  + On the second line, you will receive an integer – l – number of lines.
  + On the next l lines, you will receive a node and its children in the following format: "{node}, {children1}, … {childrenN}".

Output

  + Print all articulation points in the following format: "Articulation points: {articulationPoint1}, …, { articulationPointN}".

Example

| Input | Output |
| --- | --- |
| 12 <br> 12 <br> 0, 1, 2, 6, 7, 9 <br> 1, 0, 6 <br> 2, 0, 7 <br> 3, 4 <br> 4, 3, 6, 10 <br> 5, 7 <br> 6, 0, 1, 4, 8, 10, 11 <br> 7, 0, 2, 5, 9 <br> 8, 6, 11 <br> 9, 0, 7 <br> 10, 4, 6 <br> 11, 6, 8 | Articulation points: 4, 6, 7, 0 |