## PROBLEMS DESCRIPTION - ALGORITHMS INTRODUCTION


### Problem 1.	Recursive Array Sum
Create a program that sums all elements in an array. Use recursion.

Note: In practice recursion should not be used here (instead use an iterative solution), this is just an exercise.

Examples

| Input     | Output |
| --------- | -----|
| 1 2 3 4 | 10 |
| -1 0 1 | 0 |

### Problem 2.	Recursive Factorial
Create a program that finds the factorial of a given number. Use recursion.

Note: In practice, recursion should not be used here. Instead, you should use an iterative solution. This type of solution is for exercise purposes.

Examples


| Input     | Output |
| --------- | -----|
| 5 | 120 |
| 10 | 3628800 |

### Problem 3.	Sum of Coins
Create a program, which gathers a sum of money, using the least possible number of coins. The range of possible coin values is 1, 2, 5, 10, 20, 50.

The goal is to reach the desired sum using as few coins as possible. You can solve the task by using a greedy approach.

Input

As input, you will receive two lines:
  +	An array of integers separated by space and comma (_", "_) – coins which should be used
  +	A single integer – the desired sum.

Output
  +	As an output on the first line print : _"Number of coins to take: {coins}"_
  +	On the next n lines print how many coins were used, with their value: _"{numberOfCoins} coin(s) with value {valueOfCoin}"_
  +	If you cannot reach the desire sum, throw _"InvalidOperationException()"_.

Examples

| Input     | Output |
| --------- | -----|
| 1, 2, 5, 10, 20, 50 <br> 923 | Number of coins to take: 21 <br> 18 coin(s) with value 50 <br> 1 coin(s) with value 20 <br> 1 coin(s) with value 2 <br> 1 coin(s) with value 1 |
| 1, 9, 10 <br> 27 | Number of coins to take: 9 <br> 2 coin(s) with value 10 <br> 7 coin(s) with value 1 |

### Problem 4.	Set Cover
Create a program that finds the smallest subset of sets, which contains all elements from a given sequence.

In the Set Cover Problem, we are given two sets - a set of sets (we’ll call it sets) and a universe (a sequence). The sets contain all elements from universe and no others; however, some elements are repeated. The task is to find the smallest subset of sets which contains all elements in universe.

Input

The input is consist of three lines:
  +	Universe -  an array of integers separated by space and comma (_", "_) 
  +	Numbers of sets – a single integer representing the numbers of rows of the array
  +	Multidementional (jagged) array of integers separated by space and comma (_", "_)

Output
  +	As an output on the first line print the number of sets: _"Sets to take ({number of sets}):"_
  +	On the next n lines print actual sets in the following format:
  
    _"{ {number1}, {number2},… }_
  
    _{ {number1}, {number2},… }_
         
    _…"_

Examples

| Input     | Output |
| --------- | -----|
| 1, 2, 3, 4, 5 <br> 4 <br> 1 <br> 2, 4 <br> 5 <br> 3 | Sets to take (4): <br> { 2, 4 } <br> { 1 } <br> { 5 } <br> { 3 } |
| 1, 2, 3, 4, 5 <br> 4 <br> 1, 2, 3, 4, 5 <br> 2, 3, 4, 5 <br> 5 <br> 3 | Sets to take (1): <br> { 1, 2, 3, 4, 5 } |

### Problem 5.	Binary Search
Implement an algorithm that finds the index of an element in a sorted array of integers in logarithmic time.

Examples

| Input     | Output |
| --------- | -----|
| 1 2 3 4 5 <br> 1 | 0 |
| -1 0 1 2 4 <br> 1 | 2 |
