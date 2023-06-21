## PROBLEMS DESCRIPTION - INTRODUCTION TO DYNAMIC PROGRAMMING (Lecture)


### Problem 1.	Fibonacci

Write a dynamic programming solution for finding nth Fibonacci members.

  + F0 = 0
  + F1 = 1

Examples

| Input | Output |
| --- | --- |
| 20 | 6765 |
| 50 | 12586269025 |

### Problem 2. Move Down/Right

Given a matrix of N by M cells filled with positive integers, find the path from top left to bottom right with the highest sum of cells by moving only down or right.

Examples

| Input | Output |
| --- | --- |
| 3 <br> 3 <br> 1 1 1 <br> 1 1 1 <br> 1 1 1 | [0, 0] [1, 0] [2, 0] [2, 1] [2, 2] |
| 3 <br> 3 <br> 1 0 6 <br> 8 3 7 <br> 2 4 9 | [0, 0] [1, 0] [1, 1] [1, 2] [2, 2] |
| 8 <br> 7 <br> 2 6 1 8 9 4 2 <br> 1 8 0 3 5 6 7 <br> 3 4 8 7 2 1 8 <br> 0 9 2 8 1 7 9 <br> 2 7 1 9 7 8 2 <br> 4 5 6 1 2 5 6 <br> 9 3 5 2 8 1 9 <br> 2 3 4 1 7 2 8 | [0, 0] [0, 1] [1, 1] [2, 1] [2, 2] [2, 3] [3, 3] [4, 3] [4, 4] [4, 5] [5, 5] [5, 6] [6, 6] [7, 6] |

### Problem 3. Longest Common Subsequence

Considering two sequences S1 and S2, the longest common subsequence is a sequence that is a subsequence of both S1 and S2. For instance, if we have two strings (sequences of characters), "abc" and "adb", the LCS is "ab" – it is a subsequence of both sequences and it is the longest (there are two other subsequences – "a" and "b").

Input

  + On the first line, you will receive a string – str1 – first string.
  + On the second line, you will receive a string – str2 – second string.

Output

  + Print the length of the longest common subsequence.

Examples

| Input | Output |
| --- | --- |
| abc <br> adb | 2 |
| ink some beer <br> drink se ber | 10 |
| tree <br> team | 2 |