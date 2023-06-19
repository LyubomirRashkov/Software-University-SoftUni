## PROBLEMS DESCRIPTION - GRAPH THEORY, TRAVERSAL AND SHORTEST PATHS (Exercise)


### Problem 1.	Distance Between Vertices

We are given a directed graph. We are given also a set of pairs of vertices. Find the shortest distance between each pair of vertices or -1 if there is no path connecting them.

On the first line, you will get N, the number of vertices in the graph. On the second line, you will get P, the number of pairs between which to find the shortest distance.

On the next N lines will be the edges of the graph and on the next P lines, the pairs.

Examples

| Input | Output |
| --- | --- |
| 2 <br> 2 <br> 1:2 <br> 2: <br> 1-2 <br> 2-1 | {1, 2} -> 1 <br> {2, 1} -> -1 |
| 8 <br> 4 <br> 1:4 <br> 2:4 <br> 3:4 5 <br> 4:6 <br> 5:3 7 8 <br> 6: <br> 7:8 <br> 8: <br> 1-6 <br> 1-5 <br> 5-6 <br> 5-8 | {1, 6} -> 2 <br> {1, 5} -> -1 <br> {5, 6} -> 3 <br> {5, 8} -> 1 |
| 9 <br> 8 <br> 11:4 <br> 4:12 1 <br> 1:12 21 7 <br> 7:21 <br> 12:4 19 <br> 19:1 21 <br> 21:14 31 <br> 14:14 <br> 31: <br> 11-7 <br> 11-21 <br> 21-4 <br> 19-14 <br> 1-4 <br> 1-11 <br> 31-21 <br> 11-14 | {11, 7} -> 3 <br> {11, 21} -> 3 <br> {21, 4} -> -1 <br> {19, 14} -> 2 <br> {1, 4} -> 2 <br> {1, 11} -> -1 <br> {31, 21} -> -1 <br> {11, 14} -> 4 |

### Problem 2. Areas in Matrix

We are given a matrix of letters of size N * M. Two cells are neighbors if they share a common wall. Write a program to find the connected areas of neighbor cells holding the same letter. Display the total number of areas and the number of areas for each alphabetical letter (ordered by alphabetical order).

On the first line is given the number of rows.

Examples

| Input | Output |
| --- | --- |
| 6 <br> 8 <br> aacccaac <br> baaaaccc <br> baabaccc <br> bbdaaccc <br> ccdccccc <br> ccdccccc | Areas: 8 <br> Letter 'a' -> 2 <br> Letter 'b' -> 2 <br> Letter 'c' -> 3 <br> Letter 'd' -> 1 |
| 3 <br> 3 <br> aaa <br> aaa <br> aaa | Areas: 1 <br> Letter 'a' -> 1 |
| 5 <br> 9 <br> asssaadas <br> adsdasdad <br> sdsdadsas <br> sdasdsdsa <br> ssssasddd | Areas: 21 <br> Letter 'a' -> 6 <br> Letter 'd' -> 7 <br> Letter 's' -> 8 |

### Problem 3. Cycles in a Graph

Write a program to check whether a directed graph is acyclic or holds any cycles. The input ends with "End" line.

Examples

| Input | Output |
| --- | --- |
| C-G <br> End | Acyclic: Yes |
| A-F <br> F-D <br> D-A <br> End | Acyclic: No |
| E-Q <br> Q-P <br> P-B <br> End | Acyclic: Yes |
| K-J <br> J-N <br> N-L <br> N-M <br> M-I <br> End | Acyclic: Yes |

### Problem 4. Salaries

We have a hierarchy between the employees in a company.

Employees can have one or several direct managers. People who manage nobody are called regular employees and their salaries are 1. People who manage at least one employee are called managers. Each manager takes a salary which is equal to the sum of the salaries of their directly managed employees.

Managers cannot manage directly or indirectly themselves. Some employees might have no manager. See a sample hierarchy in a company along with the salaries computed following the above-described rule:

![изображение](https://github.com/LyubomirRashkov/Software-University-SoftUni/assets/82647282/32668842-c0a6-4658-b757-f107bb56d515)

In the above example, employees 0 and 3 are regular employees and take salary 1. All others are managers and take the sum of the salaries of their directly managed employees. For example, manager 1 takes salary 3 + 2 + 1 = 6 (sum of the salaries of employees 2, 5 and 0). In the above example employees, 4 and 1 have no manager.

If we have N employees, they will be indexed from 0 to N – 1. For each employee, you will be given a string with N symbols. The symbols are either 'Y' or 'N', showing all employees that are managed by the current employee.

Input

  + On the first line, you will be given an integer N.
  + On the next N lines, you will be given strings with N symbols (either 'Y' or 'N').
  + The input data will always be valid and in the format described. There is no need to check it explicitly.

Output

  + Print the sum of the salaries of all employees.

Constraints

  + N will be an integer in the range [1 … 50].
  + If employee A is the manager of employee B, B will not be a manager of A.

Examples

| Input | Output |
| --- | --- |
| 1 <br> N | 1 |
| 4 <br> NNYN <br> NNYN <br> NNNN <br> NYYN | 5 |
| 6 <br> NNNNNN <br> YNYNNY <br> YNNNNY <br> NNNNNN <br> YNYNNN <br> YNNYNN | 17 |

### Problem 5. Break Cycles

You are given an undirected multi-graph. Remove a minimal number of edges to make the graph acyclic (to break all cycles). As a result, print the number of edges removed and the removed edges. If several edges can be removed to break a certain cycle, remove the smallest of them in alphabetical order (smallest start vertex in alphabetical order and smallest end vertex in alphabetical order).

Examples

| Input | Output |
| --- | --- |
| 8 <br> 1 -> 2 5 4 <br> 2 -> 1 3 <br> 3 -> 2 5 <br> 4 -> 1 <br> 5 -> 1 3 <br> 6 -> 7 8 <br> 7 -> 6 8 <br> 8 -> 6 7 | Edges to remove: 2 <br> 1 - 2 <br> 6 - 7 |
| 14 <br> K -> X J <br> J -> K N <br> N -> J X L M <br> X -> K N Y <br> M -> N I <br> Y -> X L <br> L -> N I Y <br> I -> M L <br> A -> Z Z Z <br> Z -> A A A <br> F -> E B P <br> E -> F P <br> P -> B F E <br> B -> F P | Edges to remove: 7 <br> A - Z <br> A - Z <br> B - F <br> E - F <br> I - L <br> J - K <br> L - N |

### Problem 6. Road Reconstruction

Write a program that finds all the roads without which buildings in the city will become unreachable.

You will receive how many buildings the town has on the first line, then you will receive the number of streets and finally, for each street, you will receive which buildings it connects. Find all the streets that are important and cannot be removed and print them in ascending order (e. g. 3 0 should be printed as 0 3).

Input

  +  On the first line, you will receive the number of buildings.
  + On the second line, you will receive the amount of the streets (n).
  + On the next "n" lines you will receive which buildings each street connects.

Output

  + On the first line print: "Important streets:".
  + On the next lines (if any) print the street in the format: "{firstBuilding} {secondBuilding}".
  + The order of the output does not matter if you print all the important streets.

Examples

| Input | Output |
| --- | --- |
| 5 <br> 5 <br> 1 - 0 <br> 0 - 2 <br> 2 - 1 <br> 0 - 3 <br> 3 - 4 | Important streets: <br> 0 3 <br> 3 4 |
| 7 <br> 8 <br> 0 - 1 <br> 1 - 2 <br> 2 - 0 <br> 1 - 3 <br> 1 - 4 <br> 1 - 6 <br> 3 - 5 <br> 4 - 5 | Important streets: <br> 1 6 |