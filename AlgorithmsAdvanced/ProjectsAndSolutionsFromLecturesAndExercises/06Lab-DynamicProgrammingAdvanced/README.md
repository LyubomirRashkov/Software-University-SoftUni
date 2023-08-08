## PROBLEMS DESCRIPTION - DYNAMIC PROGRAMMING ADVANCED (Lecture)


### Problem 1.	Rod Cutting

Find the best way to cut up a rod with a specified length. You are also given prices of all possible lengths starting from 0.

Examples

| Input | Output |
| --- | --- |
| 0 1 5 8 9 10 17 17 20 24 30 <br> 4 | 10 <br> 2 2 |
| 0 1 5 8 9 10 17 17 20 24 30 <br> 8 | 22 <br> 2 6 |
| 0 1 5 8 9 10 17 17 20 24 30 <br> 10 | 30 <br> 10 |

### Problem 2. Knapsack

Imagine you have a bag (knapsack) and want to fill it with as many of your most valuable items as possible. The knapsack, of course, cannot hold an infinite number of items. It has a weight limit (capacity). Based on this capacity, you need to decide which items to put in it to maximize the value of the items in the knapsack.

We'll assume that the value and weight of each item and the weight limit of the knapsack are all non-negative integers.

Input

  + On the first line, you will receive an integer – capacity – knapsack's capacity.
  + On the next lines until "end" is not entered, you will receive an item in the following format: "{name} {weight} {value}".

Output

  + Print the used capacity of the knapsack in the following format: "Total Weight: {usedCapacity}".
  + Print the total value of all items in the knapsack in the following format: "Total Value: {totalValue}".
  + Print names of all items in the knapsack sorted by name in alphabetical order.

Example

| Input | Output |
| --- | --- |
| 20 <br> Item1 5 30 <br> Item2 8 120 <br> Item3 7 10 <br> Item4 0 20 <br> Item5 4 50 <br> Item6 5 80 <br> Item7 2 10 <br> end | Total Weight: 19 <br> Total Value: 280 <br> Item2 <br> Item4 <br> Item5 <br> Item6 <br> Item7 |

### Problem 3. Longest Increasing Subsequence

Let’s have a sequence of numbers S = {a1, a2, … an}. An increasing subsequence is a sequence of numbers within S where each number is larger than the previous. We do not change the relative positions of the numbers, e.g., we do not move smaller elements to the left to obtain longer sequences. If several sequences with equal length exist, find the left-most of them.

Examples

| Input | Output |
| --- | --- |
| 1 2 5 3 4 | 1 2 3 4 |
| 4 3 2 1 | 4 |
| 4 2 -1 3 5 5 | 2 3 5 |