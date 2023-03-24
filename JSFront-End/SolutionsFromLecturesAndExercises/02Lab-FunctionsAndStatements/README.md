## PROBLEMS DESCRIPTION - FUNCTIONS AND STATEMENTS (Lecture)


### Problem 1.	Format Grade

Write a function that receives a grade between 2.00 and 6.00 and prints a formatted line with grade and description.
  
  +	< 3.00 - "Fail"
  +	\>= 3.00 and < 3.50 - "Poor"
  +	\>= 3.50 and < 4.50 - "Good"
  +	\>= 4.50 and < 5.50 - "Very good"
  +	\>= 5.50 - "Excellent"

Examples

| Input | Output |
| --- | --- |
| 3.33 | Poor (3.33) |
| 4.50 | Very good (4.50) |
| 2.99 | Fail (2) |

### Problem 2. Math Power

Write a function that calculates and print the value of a number raised to a given power.

Examples

| Input | Output |
| --- | --- |
| 2,8 | 256 |
| 3,4 | 81 |

### Problem 3. Repeat String

Write a function that receives a string and a repeat count n. The function should return a new string (the old one repeated n times).

Examples

| Input | Output |
| --- | --- |
| "abc", 3 | abcabcabc |
| "String", 2 | StringString |

### Problem 4. Orders

Write a function that calculates the total price of an order and prints it on the console. The function should receive one of the following products: coffee, coke, water, snacks; and a quantity of the product. 

The prices for a single piece of each product are: 

  +	coffee - 1.50
  +	water - 1.00
  +	coke - 1.40
  +	snacks - 2.00

Print the result formatted to the second decimal place.

Examples

| Input | Output |
| --- | --- |
| "water", 5 | 5.00 |
| "coffee", 2 | 3.00 |

### Problem 5. Simple Calculator

Write a function that receives three parameters – two numbers and an operator (string) – and calculates the result depending on the operator. Operator can be 'multiply', 'divide', 'add' or 'subtract'. Try to solve this task using arrow functions.

Bonus: Solve this task without using any conditional statements (no if or switch statements or ternary operators).

Input

The input comes as parameters named numOne, numTwo, operator.

Examples

| Input | Output |
| --- | --- |
| 5, 5, 'multiply' | 25 |
| 40, 8, 'divide' | 5 |
| 12, 19, 'add' | 31 |
| 50, 13, 'subtract' | 37 |

### Problem 6. Sign Check

Write a function, that checks whether the result of the multiplication numOne * numTwo * numThree is positive or negative. Try to do this WITHOUT multiplying the 3 numbers.

Input

The input comes as parameters named numOne, numTwo, numThree.

Output

  +	If the result is positive, print on the console -> "Positive"
  +	Otherwise, print -> "Negative"

Examples

| Input | Output |
| --- | --- |
|  5, 12, -15 | Negative |
| -6, -12, 14 | Positive |
| -1, -2, -3 | Negative |
| -5, 1, 1 | Negative |