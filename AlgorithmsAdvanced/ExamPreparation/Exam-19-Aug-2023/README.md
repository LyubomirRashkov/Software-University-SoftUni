## PROBLEMS DESCRIPTION - Exam 19 August 2023


### Problem 1.	Eco-Friendly Highway Construction

Suppose you are the manager of a construction company that has been hired to build a new highway network connecting several towns in a rural area. 

However, you have been informed that some of the towns are located in areas with difficult terrain or environmental restrictions, making it more expensive to build highways in those areas.

Your goal is to connect all the towns minimizing the total cost of building the highways.

Input

  + The first line will contain a positive integer n (1 <= n <= 10^4), representing the number of connections.
  + On the following n lines you will receive details about each connection in the following format: "{town1} {town2} {cost} {environmentCost}".
    + cost (1 <= cost <= 10^9), representing the cost of building a highway between the towns town1 and town2. 
    +	There will also be an optional integer argument -  environmentCost (0 <= environmentCost <= 10^9) for each highway, representing the additional environmental restriction cost of building the highway.

Output

  +	The output should consist of a single integer, representing the minimum cost of building highways to connect all towns, taking into account the environmental restriction cost and it should be printed in the following format: "Total cost of building highways: {totalCost}".

Constraints

  +	It is guaranteed that there is at least one possible way to connect all the towns using highways.

Examples

| Input | Output |
| --- | --- |
| 3 <br> A B 2 1 <br> B C 3 <br> C D 4 1 | Total cost of building highways: 11 |
| 5 <br> A B 2 3 <br> B C 3 <br> C D 4 <br> A C 2 <br> B D 1 | Total cost of building highways: 6 |

### Problem 2. Social Media Tracker

You are given a social network represented as a collection of users, each with a unique identifier. Each user can have one or more friends, and each friend relationship has a non-negative integer value that represents the strength of the friendship between the users. The higher the integer value, the stronger the friendship between the users.

Your task is to develop an algorithm that will take two user IDs as input and output a path between them with the highest total strength. In other words, the algorithm should find the path with the best sum of friendship strengths between the two users.

However, there is a catch: if there are multiple paths with the same total strength value, you should select the one with the least number of hops. When we say "friend hops", we are referring to the number of friendships that need to be traversed to reach from one user to the other. 

Input

  +	The first line of the input contains an integer r (1 ≤ r ≤ 1000) - the number of friend relationships.
  +	The next r lines each contain three space-separated values: "{userA} {userB} {influence}", where userA and userB are unique user identifiers and influence is a non-negative integer (0 ≤ influence ≤ 10^6). 
    +	These values represent a friendship between userA and userB, with the strength of the friendship being represented by the influence value.
    +	The influence is in the userA -> userB direction. 
    +	On the following line, you will receive the startUser.
    +	On the last line, you will receive the destinationUser.

Output

  +	Print the best sum of friendship strengths and the hops in the following format: "({bestSum}, {hops})".

Constraints

  +	There will be always a path from the startUser to the destinationUser.
  +	There will be no case with multiple paths with equal bestSum and hops.

Examples

| Input | Output |
| --- | --- |
| 5 <br> P G 5 <br> G I 10 <br> P A 3 <br> A N 15 <br> N G 3 <br> P <br> I | (31, 4) |
| 5 <br> P G 21 <br> G I 10 <br> P A 3 <br> A N 15 <br> N G 3 <br> P <br> I | (31, 2) |

### Problem 3. E-Shop

You are the owner of a small online store that sells a variety of products. You want to optimize your store's profits by selecting which products to stock based on their popularity and profit margin. Each product has a weight and value (representing its profit margin), and you have limited storage space.

There is a catch: some of the products have a relationship with each other, and if you decide to include one product, you must also include another. However, this rule also is applied recursively, meaning that if you have Item1-Item2 and Item2-Item3 pairs, you should take Item3 if you pick Item1. 

You must select the optimal products to include in your store to maximize profits while staying within your storage space.

Input

  +	The first line of the input contains a positive integer n (1 <= n <= 10^4), representing the number of items.
  +	The next n lines contain information about the items. Each item is described in the format "{itemName} {itemWeight} {itemValue}".
    +	itemName is a string representing the name of the item and it will unique.
    +	itemWeight is an integer representing the weight of the item (1 <= itemWeight <= 100)
    +	itemValue is an integer representing the value of the item (1 <= itemValue <= 10^3).
  +	On the next line, you will receive a positive integer p (1 <= p <= 10^4), representing the number of pairs.
  +	The next p lines contain information about the item pairs. Each item pair is described in the format "{itemName1} {itemName2}", where itemName1 and itemName2 are the names of two items that are related to each other.
    +	Note that the relationship between items is bidirectional, meaning that if item A is related to item B, then item B is also related to item A.
  +	On the last line, you will receive an integer s (1 <= s <= 10^4), representing the maximum storage capacity of the store.

Output

  +	Print the names of all selected items, ordered alphabetically, one item per line.
    +	There will be always only one valid combination that satisfies all conditions.

Examples

| Input | Output |
| --- | --- |
| 3 <br> Item1 3 3 <br> Item2 2 2 <br> Item3 1 4 <br> 1 <br> Item1 Item2 <br> 4 | Item3 |
| 5 <br> Item1 2 3 <br> Item2 2 3 <br> Item3 2 2 <br> Item4 2 2 <br> Item5 2 20 <br> 2 <br> Item1 Item3 <br> Item1 Item4 <br> 6 | Item2 <br> Item5 |
| 6 <br> Item1 2 3 <br> Item2 2 3 <br> Item3 2 2 <br> Item4 2 2 <br> Item5 2 3 <br> Item6 2 3 <br> 3 <br> Item1 Item2 <br> Item2 Item3 <br> Item3 Item4 <br> 8 | Item1 <br> Item2 <br> Item3 <br> Item4 |