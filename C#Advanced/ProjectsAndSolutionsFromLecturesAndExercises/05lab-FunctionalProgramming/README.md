## PROBLEMS DESCRIPTION - FUNCTIONAL PROGRAMMING (Lecture)


### Problem 1.	Sort Even Numbers
Create a program that reads one line of integers separated by ", ". Then prints the even numbers of that sequence sorted in increasing order.

Examples

| Input     | Output |
| --------- | -----|
| 4, 2, 1, 3, 5, 7, 1, 4, 2, 12 | 2, 2, 4, 4, 12 |
| 1, 3, 5 |  |

### Problem 2.	Sum Numbers
Create a program that reads a line of integers separated by ", ". Print on two lines the count of numbers and their sum.

Examples

| Input     | Output |
| --------- | -----|
| 4, 2, 1, 3, 5, 7, 1, 4, 2, 12 | 10 <br> 41 |
| 2, 4, 6 | 3 <br> 12 |

### Problem 3.	Count Uppercase Words
Create a program that reads a line of text from the console. Print all the words that start with an uppercase letter in the same order you've received them in the text.

Examples

| Input     | Output |
| --------- | -----|
| The following example shows how to use Function | The <br> Function |
| Write a program that reads one line of text from console. Print count of words that start with Uppercase, after that print all those words in the same order like you find them in text. | Write <br> Print <br> Uppercase, |

### Problem 4.	Add VAT
Create a program that reads one line of double prices separated by ", ". Print the prices with added VAT for all of them. Format them to 2 signs after the decimal point. The order of the prices must be the same. VAT is equal to 20% of the price.

Examples

| Input     | Output |
| --------- | -----|
| 1.38, 2.56, 4.4 | 1.66 <br> 3.07 <br> 5.28 |
| 1, 3, 5, 7 | 1.20 <br> 3.60 <br> 6.00 <br> 8.40 |

### Problem 5.	Filter by Age
Write a program that receives an integer N on first line. On the next N lines, read pairs of _"[name], [age]"_. Then read three lines with:
  +	Condition - _"younger"_ or _"older"_
  +	Age - Integer
  +	Format - _"name"_, _"age"_ or _"name age"_

Depending on the condition, print the correct pairs in the correct format. Don’t use the built-in functionality from .NET. Create your own methods.

Examples

| Input     | Output |
| --------- | -----|
| 5 <br> Lucas, 20 <br> Tomas, 18 <br> Mia, 29 <br> Noah, 31 <br> Simo, 16 <br> older <br> 20 <br> name age | Lucas - 20 <br> Mia - 29 <br> Noah - 31 |
| 5 <br> Lucas, 20 <br> Tomas, 18 <br> Mia, 29 <br> Noah, 31 <br> Simo, 16 <br> younger <br> 20 <br> name | Tomas <br> Simo |
