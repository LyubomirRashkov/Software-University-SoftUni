## PROBLEMS DESCRIPTION - INTRODUCTION TO DYNAMIC PROGRAMMING (Exercise)


### Problem 1.	Binomial Coefficients

Write a program that finds the binomial coefficient for given non-negative integers n and k. The coefficient can be found recursively by adding the two numbers above using the formula:

![изображение](https://github.com/LyubomirRashkov/Software-University-SoftUni/assets/82647282/9acd2942-6341-489c-8938-765ed88f879c)

However, this leads to calculating the same coefficient multiple times (a problem that also occurs when solving the Fibonacci problem recursively). Use memoization to improve performance.

You can check your answers using the picture below (row and column indices start from 0):

![изображение](https://github.com/LyubomirRashkov/Software-University-SoftUni/assets/82647282/b2eda637-b161-4033-a7d1-35a6af2b6b50)

Examples

| Input | Output |
| --- | --- |
| 3 <br> 2 | 3 |
| 4 <br> 0 | 1 |
| 6 <br> 2 | 15 |
| 49 <br> 10 | 8217822536 |

### Problem 2. Dividing Presents

Alan and Bob are twins. For their birthday they received some presents and now they need to split them amongst themselves. The goal is to minimize the difference between the values of the presents received by the two brothers, i.e. to divide the presents as equally as possible.

Assume the presents have values represented by positive integer numbers and that presents cannot be split in half (a present can only go to one brother or the other).

Find the minimal difference that can be obtained and print which presents each brother has received (you may only print the presents for one of them, it is obvious that the rest will go to the other brother).

In the examples below Alan always takes a value less than or equal to Bob, but you may do it the other way around.

Examples

| Input | Output |
| --- | --- |
| 3 2 3 2 2 77 89 23 90 11 | Difference: 30 <br> Alan:136 Bob:166 <br> Alan takes: 11 90 23 2 2 3 2 3 <br> Bob takes the rest. |
| 2 2 4 4 1 1 | Difference: 0 <br> Alan:7 Bob:7 <br> Alan takes: 1 4 2 <br> Bob takes the rest. |
| 7 17 45 91 11 32 102 33 6 3 | Difference: 1 <br> Alan:173 Bob:174 <br> Alan takes: 33 32 91 17 <br> Bob takes the rest. |
| 1 1 1 1 1 1 1 1 1 22 | Difference: 13 <br> Alan:9 Bob:22 <br> Alan takes: 1 1 1 1 1 1 1 1 1 <br> Bob takes the rest. |

### Problem 3. Sum with Unlimited Amount of Coins

We have a set of coins with predetermined values, e.g. 1, 2, 5, 10, 20, 50. Given a sum S, the task is to find how many combinations of coins will sum up to S. For each value, we can use an unlimited number of coins, e.g. we can use S coins of value 1 or S/2 coins of value 2 (if S is even), etc.

Examples

| Input | Output |
| --- | --- |
| 1 2 3 4 6 <br> 6 | 10 |
| 1 2 5 <br> 5 | 4 |
| 1 2 5 10 <br> 13 | 16 |
| 1 2 5 10 20 50 100 <br> 100 | 4563 |

### Problem 4. Sum with Limited Amount of Coins

In the previous problem, the coins represented values, not actual coins (we could take as many coins of a certain value as we wanted). In this problem, we’ll regard the coins as actual coins, e.g. 1, 2, 5 are three coins and we can use each of them only once. We can, of course, have more coins of a given value, e.g. – 1, 1, 2, 2, 10.

The task is the same - find the number of ways we can combine the coins to obtain a certain sum S.

Examples

| Input | Output |
| --- | --- |
| 1 2 2 3 3 4 6 <br> 6 | 4 |
| 1 2 2 5 <br> 5 | 2 |
| 1 2 2 5 5 10 <br> 13 | 2 |
| 50 20 20 20 20 20 10 <br> 100 | 2 |

### Problem 5. Word Differences

Write a program that finds all the differences between two strings. You have to determine the smallest set of deletions and insertions to make the first string equal to the second. Finally, you have to print the count of the minimum insertions and deletions.

Input

  + You will receive the two strings on separate lines

Output

  + Print the minimum amount of deletions and insertions as described below

Examples

| Input | Output |
| --- | --- |
| YMCA <br> HMBB | Deletions and Insertions: 6 |
| JFEIOWHGOW <br> GHEWQHFEWQ | Deletions and Insertions: 12 |

### Problem 6. Connecting Cables

We are in a rectangular room. On opposite sides of the room, there are sets of n cables (n < 1000). The cables are indexed from 1 to n.

On each side of the room, there is a permutation of the cables, e.g. on one side we always have ordered {1, 2, 3, 4, 5} and on the other side, we have some permutation {5, 1, 3, 4, 2}. We are trying to connect each cable from one side with the corresponding cable on the other side – connect 1 with 1, 2 with 2, etc. The cables are straight and should not overlap!

The task is to find the maximum number of pairs we can connect given the restrictions above.

Examples

| Input | Output |
| --- | --- |
| 2 5 3 8 7 4 6 9 1 | Maximum pairs connected: 5 |
| 4 3 2 1 | Maximum pairs connected: 1 |
| 1 2 3 | Maximum pairs connected: 3 |

### Problem 7. Minimum Edit Distance

We have two strings, s1 and s2. The goal is to obtain s2 from s1 by applying the following operations:

  + replace(i, x) – in s1, replace the symbol at index with the character x
  + insert(i, x) – in s1, inserts the character x at index i
  + delete(i) – from s1, remove the character at index i

We are only allowed to modify s1, s2 always stays unchanged. Each of the three operations has a certain cost associated with it (positive integer number).

Note: the cost of the replace(i, x) operation is 0 if it does not change the character.

The goal is to find the sequence of operations which will produce s2 from s1 with minimal cost.

Input

  + The input consists of five lines.
  + The first line is the replacement cost. 
  + The second line is the insert cost.
  + The third line is the delete cost.
  + After that on the next two lines are the two strings s1 and s2.

Examples

| Input | Output |
| --- | --- |
| 3 <br> 2 <br> 1 <br> abracadabra <br> mabragabra | Minimum edit distance: 7 |
| 3 <br> 3 <br> 3 <br> equal <br> equal | Minimum edit distance: 0 |
| 1 <br> 1 <br> 1 <br> equal <br> different | Minimum edit distance: 8 |