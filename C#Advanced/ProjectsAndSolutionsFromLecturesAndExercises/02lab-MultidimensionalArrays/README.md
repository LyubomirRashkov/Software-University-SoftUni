## PROBLEMS DESCRIPTION - MULTIDIMENSIONAL ARRAYS (Lecture)


### Problem 1.	Sum Matrix Elements
Write program that reads a matrix from the console and print:
  +	Count of rows
  +	Count of columns
  +	Sum of all matrix elements

On first line you will get matrix sizes in format [rows, columns]

Examples

| Input     | Output |
| --------- | -----|
| 3, 6 <br> 7, 1, 3, 3, 2, 1 <br> 1, 3, 9, 8, 5, 6 <br> 4, 6, 7, 9, 1, 0 | 3 <br> 6 <br> 76 |

### Problem 2.	Sum Matrix Columns
Create a program that read a matrix from console and print the sum for each column. On first line you will get matrix rows. On the next rows lines, you will get elements for each column separated with a space. 

Examples

| Input     | Output |
| --------- | -----|
| 3, 6 <br> 7 1 3 3 2 1 <br> 1 3 9 8 5 6 <br> 4 6 7 9 1 0 | 12 <br> 10 <br> 19 <br> 20 <br> 8 <br> 7 |
| 3, 3 <br> 1 2 3 <br> 4 5 6 <br> 7 8 9 | 12 <br> 15 <br> 18 |

### Problem 3.	Primary Diagonal
Create a program that finds the sum of matrix primary diagonal.

Input
  +	On the first line, you are given the integer N – the size of the square matrix
  +	The next N lines holds the values for every row – N numbers separated by a space

Examples

| Input     | Output |
| --------- | -----|
|3 <br> 11 2 4 <br> 4 5 6 <br> 10 8 -12 | 4 |
| 3 <br> 1 2 3 <br> 4 5 6 <br> 7 8 9 | 15 |

### Problem 4.	Symbol in Matrix
Create a program that reads N, number representing rows and cols of a matrix. On the next N lines, you will receive rows of the matrix. Each row consists of ASCII characters. After that, you will receive a symbol. Find the first occurrence of that symbol in the matrix and print its position in the format: _"({row}, {col})"_. If there is no such symbol print an error message _"{symbol} does not occur in the matrix"_

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> ABC <br> DEF <br> X!@ <br> ! | (2, 1) |
| 4 <br> asdd <br> xczc <br> qwee <br> qefw <br> 4 | 4 does not occur in the matrix |

### Problem 5.	Square with Maximum Sum
Create a program that read a matrix from console. Then find biggest sum of 2x2 submatrix and print it to console.

On first line you will get matrix sizes in format rows, columns.

One next rows lines you will get elements for each column separated with coma.

Print biggest top-left square, which you find and sum of its elements.

Examples

| Input     | Output |
| --------- | -----|
| 3, 6 <br> 7, 1, 3, 3, 2, 1 <br> 1, 3, 9, 8, 5, 6 <br> 4, 6, 7, 9, 1, 0 | 9 8 <br> 7 9 <br> 33 |
| 2, 4 <br> 10, 11, 12, 13 <br> 14, 15, 16, 17 | 12 13 <br> 16 17 <br> 58 |

### Problem 6.	Jagged-Array Modification
Create a program that reads a matrix from the console. On the first line you will get matrix rows. On next rows lines you will get elements for each column separated with space. You will be receiving commands in the following format:
  +	Add {row} {col} {value} – Increase the number at the given coordinates with the value.
  +	Subtract {row} {col} {value} – Decrease the number at the given coordinates by the value.
  
Coordinates might be invalid. In this case you should print _"Invalid coordinates"_. When you receive _"END"_ you should print the matrix and stop the program.

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> 1 2 3 <br> 4 5 6 <br> 7 8 9 <br> Add 0 0 5 <br> Subtract 1 1 2 <br> END | 6 2 3 <br> 4 3 6 <br> 7 8 9 |
| 4 <br> 1 2 3 4 <br> 5 6 7 8 <br> 8 7 6 5 <br> 4 3 2 1 <br> Add 4 4 100 <br> Add 3 3 100 <br> Subtract -1 -1 42 <br> Subtract 0 0 42 <br> END | Invalid coordinates <br> Invalid coordinates <br> -41 2 3 4 <br> 5 6 7 8 <br> 8 7 6 5 <br> 4 3 2 101 |

### Problem 7.	Pascal Triangle
The triangle may be constructed in the following manner: In row 0 (the topmost row), there is a unique nonzero entry 1. Each entry of each subsequent row is constructed by adding the number above and to the left with the number above and to the right, treating blank entries as 0. For example, the initial number in the first (or any other) row is 1 (the sum of 0 and 1), whereas the numbers 1 and 3 in the third row are added to produce the number 4 in the fourth row.

Print each row elements separated with whitespace.

Examples

| Input     | Output |
| --------- | -----|
| 4 | 1 <br> 1 1 <br> 1 2 1 <br> 1 3 3 1 |
| 13 | 1 <br> 1 1 <br> 1 2 1 <br> 1 3 3 1 <br> 1 4 6 4 1 <br> 1 5 10 10 5 1 <br> 1 6 15 20 15 6 1 <br> 1 7 21 35 35 21 7 1 <br> 1 8 28 56 70 56 28 8 1 <br> 1 9 36 84 126 126 84 36 9 1 <br> 1 10 45 120 210 252 210 120 45 10 1 <br> 1 11 55 165 330 462 462 330 165 55 11 1 <br> 1 12 66 220 495 792 924 792 495 220 66 12 1 |
