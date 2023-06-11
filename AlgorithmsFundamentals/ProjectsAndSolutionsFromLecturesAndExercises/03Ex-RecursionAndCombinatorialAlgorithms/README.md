## PROBLEMS DESCRIPTION - RECURSION AND COMBINATORIAL PROBLEMS (Exercise)


### Problem 1.	Reverse Array

Write a program that reverses and prints an array. Use recursion.

Examples

| Input | Output |
| --- | --- |
| 1 2 3 4 5 6 | 6 5 4 3 2 1 |
| -1 0 1 | 1 0 -1 |

### Problem 2. Nested Loops To Recursion

Write a program that simulates the execution of n nested loops from 1 to n which prints the values of all its iteration variables at any given time on a single line. Use recursion.

Examples

| Input | Output |
| --- | --- |
| 2 | 1 1 <br> 1 2 <br> 2 1 <br> 2 2 |
| 3 | 1 1 1 <br> 1 1 2 <br> 1 1 3 <br> 1 2 1 <br> 1 2 2 <br> ... <br> 3 2 3 <br> 3 3 1 <br> 3 3 2 <br> 3 3 3 |

### Problem 3. Connected Areas in a Matrix

Let’s define a connected area in a matrix as an area of cells in which there is a path between every two cells.

Write a program to find all connected areas in a matrix.

Input

  + On the first line, you will get the number of rows.
  + On the second line, you will get the number of columns.
  + The rest of the input will be the actual matrix.

Output

  + Print on the console the total number of areas found.
  + On a separate line for each area print its starting coordinates and size.
  + Order the areas by size (in descending order) so that the largest area is printed first.
    + If several areas have the same size, order them by their position, first by the row, then by the column of the top-left corner.
    + If there are two connected areas of the same size, the one which is above and/or to the left of the other will be printed first.

Examples

| Input | Output |
| --- | --- |
| 4 <br> 9 <br> ---\*---\*- <br> ---\*---\*- <br> ---\*---\*- <br> ----\*-\*-- | Total areas found: 3 <br> Area #1 at (0, 0), size: 13 <br> Area #2 at (0, 4), size: 10 <br> Area #3 at (0, 8), size: 5 |
| 5 <br> 10 <br> \*--\*---\*-- <br> \*--\*---\*-- <br> \*--\*\*\*\*\*-- <br> \*--\*---\*-- <br> \*--\*---\*-- | Total areas found: 4 <br> Area #1 at (0, 1), size: 10 <br> Area #2 at (0, 8), size: 10 <br> Area #3 at (0, 4), size: 6 <br> Area #4 at (3, 4), size: 6 |

### Problem 4. Cinema

Write a program that prints all of the possible distributions of a group of friends in a cinema hall. On the first line, you will be given all of the friends' names separated by comma and space. Until you receive the command "generate" you will be given some of those friends' names and a number of the place that they want to have. (format: "{name} - {place}") So here comes the tricky part. Those friends want only to sit in the place that they have chosen. They cannot sit in other places.

Output

Print all the possible ways to distribute the friends having in mind that some of them want a particular place and they will sit there only. The order of the output does not matter.

Constrains
  + The friends' names and the number of the place will always be valid.

Examples

| Input | Output |
| --- | --- |
| Peter, Amy, George, Rick <br> Amy - 1 <br> Rick - 4 <br> generate | Amy Peter George Rick <br> Amy George Peter Rick |
| Garry, Liam, Teddy, Anna, Buddy, Simon <br> Buddy - 3 <br> Liam - 5 <br> Simon - 1 <br> generate | Simon Garry Buddy Teddy Liam Anna <br> Simon Garry Buddy Anna Liam Teddy <br> Simon Teddy Buddy Garry Liam Anna <br> Simon Teddy Buddy Anna Liam Garry <br> Simon Anna Buddy Garry Liam Teddy <br> Simon Anna Buddy Teddy Liam Garry |

### Problem 5. School Teams

Write a program that receives the names of girls and boys in a class and generates all possible ways to create teams with 3 girls and 2 boys. Print each team on a separate line separated by comma and space ", " (first the girls then the boys).

Note: "Linda, Amy, Katty, John, Bill" is the same as "Linda, Amy, Katty, Bill, John", so print only the first case.

Input

  + On the first line, you will receive the girls' names separated by comma and space ", ".
  + On the second line, you will receive the boys' names separated by comma and space ", ".

Output

  + On separate lines print all the possible teams with exactly 3 girls and 2 boys separated by comma and space and starting with the girls.

Constrains

  + There will always be at least 3 girls and 2 boys in the input.

Examples

| Input | Output |
| --- | --- |
| Linda, Amy, Katty <br> John, Bill | Linda, Amy, Katty, John, Bill |
| Lisa, Yoana, Marta, Rachel <br> George, Garry, Bob | Lisa, Yoana, Marta, George, Garry <br> Lisa, Yoana, Marta, George, Bob <br> Lisa, Yoana, Marta, Garry, Bob <br> Lisa, Yoana, Rachel, George, Garry <br> Lisa, Yoana, Rachel, George, Bob <br> Lisa, Yoana, Rachel, Garry, Bob <br> Lisa, Marta, Rachel, George, Garry <br> Lisa, Marta, Rachel, George, Bob <br> Lisa, Marta, Rachel, Garry, Bob <br> Yoana, Marta, Rachel, George, Garry <br> Yoana, Marta, Rachel, George, Bob <br> Yoana, Marta, Rachel, Garry, Bob |

### Problem 6. Word Cruncher

Write a program that receives some strings and forms another string that is required. On the first line, you will be given all of the strings separated by comma and space. On the next line, you will be given the string that needs to be formed from the given strings.

Input

  + On the first line, you will receive the strings (separated by comma and space ", ").
  + On the next line, you will receive the target string.

Output

  + Print each of them found ways to form the required string as shown in the examples.

Constrains

  + There might be repeating elements in the input.

Examples

| Input | Output |
| --- | --- |
| text, me, so, do, m, ran <br> somerandomtext | so me ran do m text |
| Word, cruncher, cr, h, unch, c, r, un, ch, er <br> Wordcruncher | Word c r un ch er <br> Word c r unch er <br> Word cr un c h er <br> Word cr un ch er <br> Word cr unch er <br> Word cruncher |
| tu, stu, p, i, d, pi, pid, s, pi <br> stupid | s tu p i d <br> s tu pi d <br> s tu pid <br> stu p i d <br> stu pi d <br> stu pid |