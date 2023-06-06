## PROBLEMS DESCRIPTION - RECURSION AND BACKTRACKING (Lecture)


### Problem 1.	Recursive Array Sum

Write a program that finds the sum of all elements in an integer array. Use recursion.

Note: In practice, this recursion should not be used here (instead use an iterative solution), this is just an exercise.

Examples

| Input | Output |
| --- | --- |
| 1 2 3 4 | 10 |
| -1 0 1 | 0 |

### Problem 2. Recursive Drawing

Write a program that draws the figure below depending on n.

Examples

| Input | Output |
| --- | --- |
| 2 | ** <br> * <br> # <br> ## |
| 5 | ***** <br> **** <br> *** <br> ** <br> * <br> # <br> ## <br> ### <br> #### <br> ##### |

### Problem 3. Generating 0/1 Vectors

Generate all n-bit vectors of 0 and 1 in lexicographic order.

Examples

| Input | Output |
| --- | --- |
| 3 | 000 <br> 001 <br> 010 <br> 011 <br> 100 <br> 101 <br> 110 <br> 111 |
| 5 | 00000 <br> 00001 <br> 00010 <br> ... <br> 11110 <br> 11111 |

### Problem 4. Recursive Factorial

Write a program that calculates the recursively factorial of a given number.

NOTE: In practice, this recursion should not be used here (instead use an iterative solution).

Examples

| Input | Output |
| --- | --- |
| 5 | 120 |
| 10 | 3628800 |

### Problem 5. Find All Paths in a Labyrinth

You are given a labyrinth. Your goal is to find all paths from the start (cell 0, 0) to the exit, marked with 'e'.

  + Empty cells are marked with a dash '-'.
  + Walls are marked with a star '\*'.

On the first line, you will receive the dimensions of the labyrinth. Next, you will receive the actual labyrinth.

The order of the paths does not matter.

Examples

| Input | Output |
| --- | --- |
| 3 <br> 3 <br> --- <br> -\*- <br> --e | RRDD <br> DDRR |
| 3 <br> 5 <br> -\*\*-e <br> ----- <br> \*\*\*\*\* | DRRRRU <br> DRRRUR |

### Problem  6. Queens Puzzle

In this lab, we will implement a recursive algorithm to solve the "8 Queens" puzzle. Our goal is to write a program to find all possible placements of 8 chess queens on a chessboard so that no two queens can attack each other (on a row, column, or diagonal).

Examples

| Input | Output |
| --- | --- |
| (no input) | * - - - - - - - <br> - - - - * - - - <br> - - - - - - - * <br> - - - - - * - - <br> - - * - - - - - <br> - - - - - - * - <br> - * - - - - - - <br> - - - * - - - - <br>  <br> * - - - - - - - <br> - - - - - * - - <br> - - - - - - - * <br> - - * - - - - - <br> - - - - - - * - <br> - - - * - - - - <br> - * - - - - - - <br> - - - - * - - - <br>  <br> ... <br>  <br> (90 solutions more) |

### Problem  7.Recursive Fibonacci

Each member of the Fibonacci sequence is calculated from the sum of the two previous members. The first two elements are 1, 1. Therefore the sequence goes like 1, 1, 2, 3, 5, 8, 13, 21, 34 …

The following sequence can be generated with an array, but that’s easy, so your task is to implement it recursively.

Input

  + On the only line in the input, the user should enter the wanted Fibonacci number N where 1 ≤ N ≤ 49

Output

  + The output should be the nth Fibonacci number counting from 0

Examples 

| Input | Output |
| --- | --- |
| 5 | 8 |
| 10 | 89 |
| 21 | 17711 |