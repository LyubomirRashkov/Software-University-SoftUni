## PROBLEMS DESCRIPTION - SEARCHING, SORTING AND GREEDY ALGORITHMS (Lecture)


### Problem 1.	Binary Search

Implement an algorithm that finds the index of an element in a sorted array of integers in logarithmic time.

Examples

| Input | Output |
| --- | --- |
| 1 2 3 4 5 <br> 1 | 0 |
| -1 0 1 2 4 <br> 1 | 2 |

### Problem 2. Selection Sort

Write an implementation of Selection Sort. You should read an array of integers and sort them.

Output

  + You should print out the sorted list in the format described below.

Example

| Input | Output |
| --- | --- |
| 5 4 3 2 1 | 1 2 3 4 5 |

### Problem 3. Bubble Sort

Write an implementation of Bubble Sort. You should read an array of integers and sort them.

Output

  + You should print out the sorted list in the format described below.

Example

| Input | Output |
| --- | --- |
| 5 4 3 2 1 | 1 2 3 4 5 |

### Problem 4. Insertion Sort

Write an implementation of Insertion Sort. You should read an array of integers and sort them.

Output

  + You should print out the sorted list in the format described below.

Example

| Input | Output |
| --- | --- |
| 5 4 3 2 1 | 1 2 3 4 5 |

### Problem 5. Quicksort

Sort an array of elements using the famous quicksort.

Example

| Input | Output |
| --- | --- |
| 5 4 3 2 1 | 1 2 3 4 5 |

### Problem 6. Merge Sort

Sort an array of elements using the famous merge sort.

Example

| Input | Output |
| --- | --- |
| 5 4 3 2 1 | 1 2 3 4 5 |

### Problem 7. Sum of Coins

Write a program, which receives a set of coins and a target sum. The goal is to reach the sum using as few coins as possible. You should use a greedy approach.

Constraints

  + We’ll assume that each coin value and the desired sum are integers.

Output

  + If the target sum can be reached:
    + First, print the number of used coins in the following format: "Number of coins to take: {coins}".
    + For each used coin print its value and how many times has been used in the following format: "{counter} coin(s) with value {coinValue}".
  + Otherwise, print "Error".

Examples

| Input | Output |
| --- | --- |
| 1, 2, 5, 10, 20, 50 <br> 923 | Number of coins to take: 21 <br> 18 coin(s) with value 50 <br> 1 coin(s) with value 20 <br> 1 coin(s) with value 2 <br> 1 coin(s) with value 1 |
| 3, 7 <br> 11 | Error |

### Problem 8. Set Cover

Write a program that finds the smallest subset of sets, which contains all elements from a given sequence.

You are given two sets - a set of sets (we’ll call it sets) and a universe (a sequence). The sets contain only elements from the universe, however, some elements are repeated. Your task is to find the smallest subset of sets that contains all elements in universe.

Examples

| Input | Output |
| --- | --- |
| 1, 2, 3, 4, 5 <br> 4 <br> 1 <br> 2, 4 <br> 5 <br> 3 | Sets to take (4): <br> 2, 4 <br> 1 <br> 5 <br> 3 |
| 1, 3, 5, 7, 9, 11, 20, 30, 40 <br> 6 <br> 20 <br> 1, 5, 20, 30 <br> 3, 7, 20, 30, 40 <br> 9, 30 <br> 11, 20, 30, 40 <br> 3, 7, 40 | Sets to take (4): <br> 3, 7, 20, 30, 40 <br> 1, 5, 20, 30 <br> 9, 30 <br> 11, 20, 30, 40 |