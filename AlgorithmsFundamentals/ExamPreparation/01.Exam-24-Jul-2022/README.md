## PROBLEMS DESCRIPTION - Exam 24 July 2022


### Problem 1.	Trains

As a promising tinker, you are part of Dick Simnel’s locomotion scheduler team.

Given a schedule containing the arrival and departure time of trains in a station, find the minimum number of platforms needed to avoid delay in any train’s arrival.

Input

  +	The input will come from the console on two lines:
    +	The first line will be a sequence of numbers representing the train arrival times.
    +	The second line will be a sequence of numbers representing the train departure times.

Output

  +	The output is a single integer representing the minimum number of platforms, so no trains are delayed.

Constraints

  +	The input numbers will be valid floating-point numbers representing 24h clock system as an example [1.30, 14.20, 6.50, 4.20] etc.
  + When two trains are scheduled to arrive and depart simultaneously, depart the train first.
  +	Arrivals and departures will always be sequences with equal length.

Examples

| Input | Output |
| --- | --- |
| 2.00 2.10 3.00 3.20 3.50 5.00 <br> 2.30 3.40 3.20 4.30 4.00 5.20 | 2 |
| 14.00 14.10 00.40 14.10 1.50 <br> 14.50 14.40 23.50 14.20 2.00 | 4 |

### Problem 2. Conditional Expression Resolver

The conditional operator ?:, also known as the ternary conditional operator, evaluates a boolean expression and returns the result of one of the two expressions, depending on whether the boolean expression evaluates to true or false.

Your task is to create a complex resolver that calculates the result for a given expression.

You can always assume that the given expression is valid and only consists of digits, ?, :, t (true) and f (false).

Input
  
  +	The input will come in one line: the expression.

Output

  +	The output is a single line: the result of the expression.

Constraints

  + The input will always follow this format: "{boolean value} ? {result if the value is true} : {result if the value is false}".
    +	Keep in mind that both results can be expressions too.

Examples

| Input | Output |
| --- | --- |
| t ? 4 : 2 | 4 |
| f ? 4 : 2 | 2 |
| f ? t ? 4 : 2 : 1 | 1 |
| t ? t ? t ? 4 : 1 : 2 : 3 | 4 |

### Problem 3. Guards

The Ankh Morpork guards need your help there has been a flood in the city and some outposts can no longer be reached from a specific starting point your task is to report those.

You will be given the map of the outposts, as a graph from the console with a given start node, print all the unreachable nodes in order by their number ascending.

Input

  +	The input will come from the console on multiple lines:
    + first line N single integer – the number of nodes
    +	second line M single integer – the number of edges
    +	M lines describing the edges connections in the format: {from} {to}
    +	S single integer – the start node

Output

  +	The output is a sequence of integers that represents the unreachable outposts.

Constraints

  + The input graph will not contain more than 30 nodes or edges.

Examples

| Input | Output |
| --- | --- |
| 6 <br> 5 <br> 1 2 <br> 2 4 <br> 3 4 <br> 6 5 <br> 6 4 <br> 1 | 3 5 6 |
| 4 <br> 4 <br> 1 4 <br> 2 3 <br> 3 4 <br> 4 1 <br> 3 | 2 |