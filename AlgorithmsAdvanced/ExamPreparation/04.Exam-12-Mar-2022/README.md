## PROBLEMS DESCRIPTION - Exam 12 March 2022


### Problem 1.	Best Team

There are n soldiers standing in a line. Each soldier is assigned a unique rating value.

Your task is to find the best team of soldiers (the team with the most soldiers) amongst them under the following rule:

  +	All soldiers of a team are sorted in increasing or decreasing order.

If several teams with equal length exist, find the left-most of them.

Input

  +	You will receive a line with all soldiers separated by space.

Output
  +	If there is a route from the start and back to it, print the route.

Constraints

  +	Ratings will be integers in the range [0…1000].
  +	The input will always be in valid format.
  +	The best team in increasing order and the best team in decreasing order will never have equal length.

Examples


| Input | Output |
| --- | --- |
| 2 5 3 4 7 | 2 3 4 7 |
| 2 5 4 3 7 2 1 4 | 5 4 3 2 1 |

### Problem 2. Pipelines

We have X agents and Y pipelines. 

Each agent can complete at most one pipeline and vice versa. 

Each agent has a specific configurations and each pipeline has different demands (capabilities the agent must have to run this pipeline), therefore we have a mapping that shows which agents can complete which pipelines. 

Find the maximum distribution that assigns pipelines to agents to complete a maximum number of builds. 

Input

  +	On the first line, you will receive an integer – agents.
  +	On the next line, you will receive an integer – pipelines.
  +	On the next agents lines you will receive a string – unique agent identifier.
  +	On the next pipelines lines you will receive a string – name of the pipeline.
  +	On the next agents lines you will receive which agent which pipelines can run in the following format: "{agent}, {pipeline…1}, … {pipelineN}".

Output

  +	Print the maximum distribution that assigns agents to pipelines to complete a maximum number of builds in the following format: "{agent} - {pipeline}".
  +	Order of the output doesn’t matter.

Constraints
  
  +	agents will be in the range [1… 10].
  +	pipelines will be in the range [1… 15].
  +	agent-pipeline mappings will always be valid.

Examples

| Input | Output |
| --- | --- |
| 3 <br> 3 <br> 07a85db1 <br> d294508d <br> 6fcb0c04 <br> Judge <br> SoftUni <br> SoftUni Digital <br> 07a85db1, Judge, SoftUni Digital <br> d294508d, SoftUni, SoftUni Digital <br> 6fcb0c04, Judge, SoftUni | 6fcb0c04 - Judge <br> d294508d - SoftUni <br> 07a85db1 - SoftUni Digital |
| 3 <br> 3 <br> 07a85db1 <br> d294508d <br> 6fcb0c04 <br> Google <br> Gmail <br> YouTube <br> 07a85db1, Google, YouTube <br> d294508d, Google, Gmail, YouTube <br> 6fcb0c04, Google, YouTube | 07a85db1 - Google <br> d294508d - Gmail <br> 6fcb0c04 - YouTube |

### Problem 3. Travel Optimizer

We have a set of towns and some of them are connected by bi-direct paths. Each path has a price that has to be paid.

Write a program that prints the cheapest path from a starting city to the destination city with at most k stops. 

Input

  +	On the first, you will receive an integer – e – number of edges.
  +	On the next e lines, you will receive an edge in the following format: "{start}, {end}, {weight}".
  +	On the next line, you will receive a start city.
  +	On the last line, you will receive a  destination city.
  +	On the next line, you will receive an integer – k – how many stops you can use.

Output

  +	Print all cities that form the cheapest path separated by a space.
  +	If the destination city can’t be reached from the starting point, then you have to print: "There is no such path."

Constraints

  +	e will be in the range [1… 50].
  +	Cities will always be represented by positive integers.
  +	Prices will always be positive integers.
  +	Start city and destination city will always be valid cities.
  +	k will be in the range [1… 10].

Examples

| Input | Output |
| --- | --- |
| 3 <br> 0, 1, 15 <br> 1, 2, 5 <br> 0, 2, 50 <br> 0 <br> 2 <br> 0 | 0 2 |
| 5 <br> 0, 1, 1 <br> 1, 2, 5 <br> 0, 2, 50 <br> 1, 3, 25 <br> 3, 2, 10 <br> 0 <br> 3 <br> 3 | 0 1 2 3 |