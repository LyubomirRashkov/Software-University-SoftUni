## PROBLEMS DESCRIPTION - MORE EXAM PROBLEMS


### Problem 1.	Alpha Decay

You are part of the "no-real-science-team" and you are the computer specialist, you will be given data collected after the alpha decay of some heavy elements N where each value is the resulting nucleus after the alpha decay of some heavier nucleus represented by a single integer. 

Your head theoretical physicist wants to see if there are any patterns in the resulting nucleus, however after doing some calculations the theorist have claimed that the only number of results worth looking at is K of those N nucleus at a time.

Here comes your task you need to take those N nucleus and print all the possible ways that they can be observed as a sequence of K nucleus, without using the same nucleus twice.

Input

  +	The input will come from the console on two lines.
  +	First line will be the resulting nucleus after the alpha decay N as a sequence of integers separated by spaces.
  +	On the second line a single integer K the count of integers the physicist wants to observe at the same time.

Output

  +	The output is each possible way to observe K nucleus out of N on a new line where each nucleus is separated by a single space.

Constraints

  +	N will be in the range [3…10] where K will always be less than N.
  +	The nucleus numbers will be unique.

Examples

| Input | Output |
| --- | --- |
| 234 232 230 <br> 2 | 234 232 <br> 234 230 <br> 232 234 <br> 232 230 <br> 230 234 <br> 230 232 |
| 109 113 234 232 <br> 3 | 109 113 234 <br> 109 113 232 <br> 109 234 113 <br> 109 234 232 <br> 109 232 113 <br> 109 232 234 <br> 113 109 234 <br> 113 109 232 <br> 113 234 109 <br> 113 234 232 <br> 113 232 109 <br> 113 232 234 <br> 234 109 113 <br> 234 109 232 <br> 234 113 109 <br> 234 113 232 <br> 234 232 109 <br> 234 232 113 <br> 232 109 113 <br> 232 109 234 <br> 232 113 109 <br> 232 113 234 <br> 232 234 109 <br> 232 234 113 |

### Problem 2. Nuclear Waste

It is a bit different when a nuclear power plant needs to replace the fuel inside a reactor or the cooling rods, the old one become waste. They are highly radioactive and require much more complex process which often includes transporting the radioactive materials to disposal facilities often far away from the power plants and somewhere deep underground. 

Still business is business and you are looking for the cheapest possible way to transport the nuclear waste to some of the facilities. The transport company offers to transport flasks of waste at different cost for the different count of flasks. You will be given this information as a sequence of integers as an example:
12 20 30 40 means that 1 flask transport costs 12, two costs 20, three costs 30 etc.

You will also be given N the number of flasks you want to transport.

The input will come from the console on two lines.

  +	On the first line the sequence representing the cost of the flasks transport.
  +	On the second line single integer N the number of flasks you need to transport.

Output

  +	First print the minimum cost for all the flasks transport. In the format: "Cost: {minimumCost}"
  +	Then print the optima setup as the count of flasks and the corresponding cost.
    +	"{flasksCount} => {cost}"
    +	Note: the flasks should be printed in increasing order by count of flasks transported NOT by cost.

Constraints

  +	All input lines will be valid integers you do not need to check that.
  +	The range of the integers will be [1…10000]

Examples

| Input | Output |
| --- | --- |
| 12 21 31 43 79 <br> 10 | Cost: 104 <br> 2 => 21 <br> 2 => 21 <br> 3 => 31 <br> 3 => 31 |
| 12 21 31 40 49 58 69 79 90 101 <br> 15 | Cost: 147 <br> 3 => 31 <br> 6 => 58 <br> 6 => 58 |

### Problem 3. Black Mesa

You have been accepted to work as a part of the high end research laser team I guess congratulations are in order… or have been in order. 

You see working with high energy lasers to condense the space time continuum sometimes has some strange side effects. And as your gut feelings suggest there has been quiet small malfunction which resulted in unexpected and quiet interesting incident. 

The space time around the laser research facility has gone wild things are happening in multiple time dimensions, the problem seems to be multiple wormholes opened after the last experiment which caused many alternative universes to cross at those points.

Your task is very simple, since this is not the first incident the security protocol is in place.

You know one thing you can go from a previous version to the corresponding next version in straight timeline, think about it as a persistent model of the multiverse. There is one thing that you don’t know and you can't find it anywhere in the protocol from which version you should retrieve all the steps to the latest version before the incident. However you are lucky one of your fellow scientists has remembered the initial state and the latest state, or at least he claims he did, do you trust him? 


You need to use those values in order to compute the new input settings for the lasers so you can reverse the process and fix the multiverse. 

First you will be given – N an integer – the total count of version, then you will be given – M an integer – the count of transitions from one version to the other. 

After that you have to read the persistent state model of the multiverse as integers from the console represented in the following format:

  +	{prevVersion} {nextVersion}

And on the last two lines your colleague will tell you the start version and the target version you want to reach.

From now on the first thing left is to print the shortest sequence of versions from the start to the target on a single line separated by a single space.

On the second line you have to print all the versions you cannot reach from the start version on a single line separated by a single space in increasing order of the version.

The input will come from the console:

  +	On the first line the number of versions N single integer
  +	On the second line the number of connections between the versions M
  +	On each M line the data describing the versions in a straight timeline: {prevVersion} {nextVersion}
  +	On the next two lines two integer the start version and the target version you need to go to

Output

  +	On the first output line print the versions you pass through from the start to the target version.
  +	On the second line print the versions you cannot go to from the start version in increasing order. If there are none (all versions are reachable from the start one) print nothing.

Constraints

  +	All input lines will be valid integers you do not need to check that.
  +	The range of the integers will be in the range [1…1000]
  +	The versions number will be numbers from one increasing for each next version.
  +	There will always be a path from the start version to the target one, however there may not always be versions unreachable from the start one

Examples

| Input | Output |
| --- | --- |
| 6 <br> 6 <br> 1 2 <br> 2 3 <br> 3 4 <br> 4 5 <br> 6 5 <br> 6 4 <br> 1 <br> 5 | 1 2 3 4 5 <br> 6 |
| 11 <br> 11 <br> 5 11 <br> 1 4 <br> 5 10 <br> 7 8 <br> 8 2 <br> 2 3 <br> 3 4 <br> 4 1 <br> 6 2 <br> 9 10 <br> 11 9 <br> 6 <br> 1 | 6 2 3 4 1 <br> 5 7 8 9 10 11 |

### Problem 4. Molecules

You have found a peace of tissue which consist of different molecules connected in order. 

The biology team want from you do develop a program which by given molecule as a source determines to which other molecules there is no way to transport energy. On the way to any other molecule you may have to pass through other molecules etc.

Print on a new line separated by spaces print the numbers of molecules you cannot transport energy to from the start molecule. Print them in increasing order.

The input will come from the console:

  +	On the first line the number of molecules N
  +	On the second line the number of connections between the molecules M
  +	On each M line the data describing the connections: {fromMolecule} {toMolecule}
  +	On the next line single integer the start molecule number 

Output

  +	On the single output line print the molecules in increasing order to which there is no connection from start molecule.

Constraints

  +	All input lines will be valid integers you do not need to check that.
  +	The range of the integers will be in the range [1…1000]
  +	The molecules number will be numbers from one increasing for each molecule.

Examples

| Input | Output |
| --- | --- |
| 8 <br> 9 <br> 1 2 <br> 1 3 <br> 2 5 <br> 2 4 <br> 3 4 <br> 4 5 <br> 3 6 <br> 5 6 <br> 7 8 <br> 1 | 7 8 |
| 11 <br> 11 <br> 1 5 <br> 1 4 <br> 5 7 <br> 7 8 <br> 8 2 <br> 2 3 <br> 3 4 <br> 4 1 <br> 6 2 <br> 9 10 <br> 11 9 <br> 6 | 9 10 11 |

### Problem 5. Monkey Business

You have found a number N and now you want to see in how many ways you can combine the numbers from 1 to N in such a way that by using addition or subtraction you will end up with zero as a result. Find the possible expressions print them on the console each on a new line then followed by the total number of solutions in the following format:

  +	Total Solutions: {possibleSolutions}

Input

  +	The input will come from the console on single line.

Output

  +	The output is each expression on a new line followed by the total solutions see the examples below.

Constraints
  
  + The input will only be a single positive integer.
  +	The input will be in the range [1…25]

Examples

| Input | Output |
| --- | --- |
| 4 | +1 -2 -3 +4 <br> -1 +2 +3 -4 <br> Total Solutions: 2 |
| 8 | +1 +2 +3 +4 -5 -6 -7 +8 <br> +1 +2 +3 -4 +5 -6 +7 -8 <br> +1 +2 -3 +4 +5 +6 -7 -8 <br> +1 +2 -3 -4 -5 -6 +7 +8 <br> +1 -2 +3 -4 -5 +6 -7 +8 <br> +1 -2 -3 +4 +5 -6 -7 +8 <br> +1 -2 -3 +4 -5 +6 +7 -8 <br> -1 +2 +3 -4 +5 -6 -7 +8 <br> -1 +2 +3 -4 -5 +6 +7 -8 <br> -1 +2 -3 +4 +5 -6 +7 -8 <br> -1 -2 +3 +4 +5 +6 -7 -8 <br> -1 -2 +3 -4 -5 -6 +7 +8 <br> -1 -2 -3 +4 -5 +6 -7 +8 <br> -1 -2 -3 -4 +5 +6 +7 -8 <br> Total Solutions: 14 |

### Problem 6. Cluster Border

There is a war going on between different Clusters and borders have been set, which means there is border control. You are part of the Laniakea Supercluster border control IT team. 

You have been assigned task to develop a program which maximizes the work of the administration.

There is the way in which this works all the spaceships come in line one after the other. 

There are two ways of processing the ships the first is to check a single ship and the other is to check one ship but let two pass as long as the first guaranties for the second (which means that those two ships have to agree for that) or said in a simpler way to pass as a pair, however a ship can only make an agreement with the ship before him or the ship after him in the line, since reorder is not allowed.

But here is the problem since the paperwork (yes, the public administration will still use paper even thousands of decades from now), takes different amount of time for each type of ship and for each pair of ships making a deal with other ships will not always benefit in time.

You will be given two integer sequences the first is the time for each ship to pass as single client, the second one will represent the time of ships passing if they go as pair. 

You have to find the minimum time of ships processing and display that then you need to print the order of the ships passing as numbers, not times.

The input will come from the console on two lines.

  +	On the first line the sequence representing the time for each ship to go through.
  +	On the second line the sequence representing the time for two ships combination.

Output

  + First print the minimum time for processing all the ships. In the format: "Optimal Time: {optimalTime}"
  +	Then print the ships with their pair.
    +	If ship has no pair "Single {shipNumber}"
    +	If there is pair "Pair of {shipNumber} and {shipNumber}"

Constraints
  
  +	All input lines will be valid integers you do not need to check that.
  +	The range of the sequences will be [1…1000]

Examples

| Input | Output |
| --- | --- |
| 8 5 3 9 2 1 4 4 1 17 <br> 1 3 9 4 2 4 9 3 8 | Optimal Time: 24 <br> Pair of 1 and 2 <br> Single 3 <br> Pair of 4 and 5 <br> Pair of 6 and 7 <br> Single 8 <br> Pair of 9 and 10 |
| 12 24 3 1 22 1 9 1 <br> 1 50 10 12 5 8 7 | Optimal Time: 17 <br> Pair of 1 and 2 <br> Single 3 <br> Single 4 <br> Pair of 5 and 6 <br> Pair of 7 and 8 |

### Problem 7. Stairs

You need to climb N steps on the stairs, the catch is on each step you can either climb one stair or two (by jumping over one), so the question is knowing on each step you can make that choice in how many ways can you climb the stairs.

Input

  +	The input will come from the console on a single line a single number N the number of steps on the stairs. 

Output

  + The output is a single integer that represents how many ways you can climb the stairs.

Constraints

  + The input will be an integer in the range [0…10 000].

Examples

| Input | Output |
| --- | --- |
| 3 | 3 |
| 8 | 34 |

### Problem 8. Gateways

You are wrapping through space and time using different gateways that are connected with each other in some way. You will be given the gateways, their connections, your start gateway number, and your target gateway. Then the task is simple you need to print the shortest distance from the start to the target gateway and print the gateways you used in the process.

Input

  +	The input will come from the console on multiple lines:
    +	first line N single integer – the number of gateways
    +	second line M single integer – the number of connections
    +	M lines describing the connections in the format: {from} {to}
    +	S single integer – the start gateway
    +	T the target gateway

Output

  +	The output is a sequence of integers that represents the path from the start gateway to the target one.
  +	If there is no path found - there is no output 

Constraints

  +	The input will not contain more than 30 gateways or connections.

Examples

| Input | Output |
| --- | --- |
| 6 <br> 5 <br> 1 2 <br> 2 4 <br> 3 4 <br> 6 5 <br> 6 4 <br> 1 <br> 4 | 1 2 4 |
| 4 <br> 4 <br> 1 4 <br> 2 3 <br> 3 4 <br> 4 1 <br> 2 <br> 1 | 2 3 4 1 |

### Problem 9. Numbers

By given number N print all the possible ways to get that number by summing other numbers which may repeat, see the examples below. 

Input

  +	The input will come from the console as a single integer N

Output

  +	The output is the ways you can get that number N by summing other numbers. See the examples below.

Constraints

  +	The input numbers will be valid integer in the range [0…100]

Examples

| Input | Output |
| --- | --- |
| 3 | 3 <br> 2 + 1 <br> 1 + 1 + 1 |
| 5 | 5 <br> 4 + 1 <br> 3 + 2 <br> 3 + 1 + 1 <br> 2 + 2 + 1 <br> 2 + 1 + 1 + 1 <br> 1 + 1 + 1 + 1 + 1 |

### Problem 10. The Tyrant

Lord Vetinari has tasked you with a strange request. He is playing a long-distance game with the lord of Überwald.

The rules are simple by given a sequence of positive integers you need to find the minimum sum subsequence from the array such that at least one value among all groups of four consecutive elements is picked. And since Lord Vetinari is bored of that game you have been tasked to create a program that calculates the solution.

Input

  +	The input will come from the console on a single line as a sequence of integers 

Output

  +	The output is a single integer that represents the minimum sum.

Constraints

  +	The input will contain only positive integers.

Examples

| Input | Output |
| --- | --- |
| 1 2 3 4 5 6 7 8 | 6 |
| 11 34 23 8 1 3 5 13 4 69 | 13 |