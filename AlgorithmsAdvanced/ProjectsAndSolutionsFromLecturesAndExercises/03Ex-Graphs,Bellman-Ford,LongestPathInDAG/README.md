## PROBLEMS DESCRIPTION - GRAPHS, DIJKSTRA, MST, BELLMAN-FORD, LONGEST PATH IN DAG (Exercise)


### Problem 1.	Most Reliable Path

We have a set of towns, and some of them are connected by direct paths. Each path has a coefficient of reliability (in percentage) -> the chance to pass without incidents.

Your goal is to compute the most reliable path between two given nodes. Assume all percentages will be integer numbers and round the result to the second digit after the decimal separator.

Input

  + On the first line, you will receive an integer – n – number of nodes.
  + On the second line, you will receive an integer – e – number of edges.
  + On the next e lines, you will receive edges in the following format: "{first} {second} {weight}".
  + On the next line, you will receive an integer – source – starting of the path.
  + On the last line, you will receive an integer – destination – end of the path.

Output

  + First print " Most reliable path reliability: {reliability}%" on the console.
    + reliability should be formatted to the 2nd digit after the decimal point.
  + Print the most reliable path in the following format: "{sourceNode} -> {node1} -> … -> {destination"}".

Examples

| Input | Output |
| --- | --- |
| 7 <br> 10 <br> 0 3 85 <br> 0 4 88 <br> 3 1 95 <br> 3 5 98 <br> 4 5 99 <br> 4 2 14 <br> 5 1 5 <br> 5 6 90 <br> 1 6 100 <br> 2 6 95 <br> 0 <br> 6 | Most reliable path reliability: 81.11% <br> 0 -> 4 -> 5 -> 3 -> 1 -> 6 |
| 4 <br> 4 <br> 0 1 94 <br> 0 2 97 <br> 2 3 99 <br> 1 3 98 <br> 0 <br> 1 | Most reliable path reliability: 94.11% <br> 0 -> 2 -> 3 -> 1 |

### Problem 2. Cheap Town Tour

You now live in a new country, and you want to start a tour and visit every town in the country, and since you are new in the country, your finances are minimalized, so you want your trip to be as cheap as possible.

You will be given the amount of the cities on the first line, then the amount of the roads (n), and on the next n lines, you will receive which tows the road connects and the cost to use it.

Assume you can start from any town, and your target is to visit every one of them at the minimum cost.

Input

  + On the first line, you will be given the number of the towns.
  + On the second line, you will be given the number of streets (n).
  + On the next n lines, you will be given a connection in the format: "{first} -> {second} -> {cost}"

Output

  + Print the total cost of the road you have chosen in the format: "Total cost: {totalCost}"

Example

| Input | Output |
| --- | --- |
| 4 <br> 5 <br> 0 - 1 - 10 <br> 0 - 2 - 6 <br> 0 - 3 - 5 <br> 1 - 3 - 15 <br> 2 - 3 - 4 | Total cost: 19 |

### Problem 3. Undefined

Your task is to find the shortest path in a graph from S vertex to D vertex. However, edges might have negative weights, so you should be cautious of negative cycles.

Input

  + On the first line, you will receive an integer – n – number of nodes.
  + On the second line, you will receive an integer – e – number of edges.
  + On the next e lines, you will receive edges in the following format: "{source} {destination} {weight}".
  + On the next line, you will receive an integer – source – the start of the path.
  + On the last line, you will receive an integer – destination – end of the path.

Output

  + If there is a negative cycle, you should print "Undefined".
  + Otherwise, first, print on a single line the path, and after that, print the path weight.

Examples

| Input | Output |
| --- | --- |
| 5 <br> 8 <br> 1 2 -1 <br> 1 3 4 <br> 2 3 3 <br> 2 4 2 <br> 2 5 2 <br> 4 2 1 <br> 4 3 5 <br> 5 4 -3 <br> 1 <br> 4 | 1 2 5 4 <br> -2 |
| 5 <br> 8 <br> 1 2 -1 <br> 1 3 4 <br> 2 3 3 <br> 2 4 2 <br> 2 5 2 <br> 4 2 -1 <br> 4 3 5 <br> 5 4 -3 <br> 1 <br> 4 | Undefined |

### Problem 4. Big Trip

Your task is to find how much time it will cost for the longest trip possible from the source vertex to the destination vertex.

Input

  + On the first line, you will receive an integer – n – number of nodes.
  + On the second line, you will receive an integer – e – number of edges.
  + On the next e lines, you will receive edges in the following format: "{source} {destination} {time}".
  + On the next line, you will receive an integer – source – the start of the path.
  + On the last line, you will receive an integer – destination – end of the path.

Output

  + First, print on a single line the path, and after that, print the path weight.

Examples

| Input | Output |
| --- | --- |
| 6 <br> 10 <br> 1 2 3 <br> 1 5 5 <br> 2 4 4 <br> 2 3 7 <br> 2 6 2 <br> 3 4 -1 <br> 3 6 2 <br> 5 3 6 <br> 5 2 2 <br> 4 6 -2 <br> 1 <br> 3 | 14 <br> 1 5 2 3 |
| 6 <br> 10 <br> 1 2 3 <br> 1 5 5 <br> 2 4 4 <br> 2 3 -7 <br> 2 6 2 <br> 3 4 -1 <br> 3 6 2 <br> 5 3 6 <br> 5 2 2 <br> 4 6 -2 <br> 1 <br> 3 | 11 <br> 1 5 3 |

### Problem 5. Cable Network

A cable networking company plans to extend its existing cable network by connecting as many customers as possible within a fixed budget limit. The company has calculated the cost of building some prospective connections.

You are given the existing cable network (a set of customers and connections between them) along with the estimated connection costs between some pairs of customers and prospective customers. A customer can only be connected to the network via a direct connection with an already connected customer.

NOTE that each edge, at the time of its addition to the network, connects a new customer with an existing one.

Input

  + On the first line, you will receive an integer – budget.
  + On the second line, you will receive an integer – n – number of nodes.
  + On the third line, you will receive an integer – e – number of edges.
  + On the next e lines, you will receive edges in the following format: "{start} {end} {weight} {connected}".

Output

  + Print "Budget used: {usedBudget}" on the console.

Examples

| Input | Output |
| --- | --- |
| 20 <br> 9 <br> 15 <br> 1 4 8 <br> 4 0 6 connected <br> 1 7 7 <br> 4 7 10 <br> 4 8 3 <br> 7 8 4 <br> 0 8 5 connected <br> 8 6 9 <br> 8 3 20 connected <br> 0 5 4 <br> 0 3 9 connected <br> 6 3 8 <br> 6 2 12 <br> 5 3 2 <br> 3 2 14 connected | Budget used: 13 |
| 7 <br> 4 <br> 5 <br> 0 1 9 <br> 0 3 4 connected <br> 3 1 6 <br> 3 2 11 connected <br> 1 2 5 | Budget used: 5 |
| 20 <br> 8 <br> 16 <br> 0 1 4 <br> 0 2 5 <br> 0 3 1 connected <br> 1 2 8 <br> 1 3 2 <br> 2 3 3 <br> 2 4 16 <br> 2 5 9 <br> 3 4 7 <br> 3 5 14 <br> 4 5 12 <br> 4 6 22 <br> 4 7 9 <br> 5 6 6 <br> 5 7 18 <br> 6 7 15 | Budget used: 12 |