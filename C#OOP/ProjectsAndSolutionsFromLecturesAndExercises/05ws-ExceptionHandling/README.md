## PROBLEMS DESCRIPTION - EXCEPTIONS AND ERROR HANDLING (Workshop)


### Problem 1.	Square Root
Write a program that reads an integer number and calculates and prints its square root. 
  +	If the number is negative, print _"Invalid number."_
  +	In all cases finally, print _"Goodbye."_

Use try-catch-finally.

Examples

| Input     | Output |
| --------- | -----|
| 9 | 3 <br> Goodbye. |
| -1 | Invalid number. <br> Goodbye. |

### Problem 2.	Enter Numbers
Write a method ReadNumber(int start, int end) that enters an integer number in a given range (start…end), excluding the numbers start and end. If an invalid number or a non-number text is entered, the method should throw an exception. Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100. If the user enters an invalid number, continue while there are 10 valid numbers entered. Print the array elements, separated with comma and space _", "_.

Hints
  +	When the entered input holds a non-integer value, print _"Invalid Number!"_
  +	When the entered input holds an integer that is out of range, print _"Your number is not in range {currentNumber} - 100!"_

Examples

| Input     | Output |
| --------- | -----|
| 2 <br> 3 <br> 4 <br> 5 <br> 6 <br> 7 <br> 8 <br> 9 <br> 10 <br> 11 | 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 |
| 1 <br> 2 <br> 1 <br> 3 <br> p <br> 4 <br> 5 <br> 6 <br> 7 <br> 8 <br> 9 <br> 10 <br> 11 | Your number is not in range (1 - 100) <br> Your number is not in range (2 – 100) <br> 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 |

### Problem 3.	Cards
Create a class Card to hold a card’s face and suit.
  +	Valid card faces are: 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A
  +	Valid card suits are: S (♠), H (♥), D (♦), C (♣)

Both face and suit are expected as an uppercase string. The class also needs to have a ToString() method that prints the card’s face and suit as a string in the following format: _"[{face}{suit}]"_ – example: _[A♠] [5♣] [10♦]_

Use the following UTF code literals to represent the suits:
  +	\u2660 – Spades (♠)
  +	\u2665 – Hearts (♥)
  +	\u2666 – Diamonds (♦)
  +	\u2663 – Clubs (♣)

Write a program that takes a deck of cards as a string array and prints them as a sequence of cards (space separated). Print an exception message _"Invalid card!"_ when an invalid card definition is passed as input.

Input
  +	A single line with the faces and suits of the cards in the format: _"{face} {suit}, {face} {suit}, …"_

Output
  +	As output, print on the console the list of cards as strings, separated by space.

Examples

| Input     | Output |
| --------- | -----|
| A S, 10 D, K H, 2 C | [A♠] [10♦] [K♥] [2♣] |
| 5 C, 10 D, king C, K C, Q heart, Q H | Invalid card! <br> Invalid card! <br> [5♣] [10♦] [K♣] [Q♥] |

### Problem 4.	Sum of Integers
You will receive a sequence of elements of different types, separated by space. Your task is to calculate the sum of all valid integer numbers in the input. Try to add each element of the array to the sum and write messages for the possible exceptions while processing the element:
  +	If you receive an element, which is not in the correct format (FormatException): _"The element '{element}' is in wrong format!"_
  +	If you receive an element, which is out of the integer type range (OverflowException): _"The element '{element}' is out of range!"_

After each processed element add the following message: _"Element '{element}' processed - current sum: {sum}"_

At the end print the total sum of all integers: _"The total sum of all integers is: {sum}"_

Examples

| Input     | Output |
| --------- | -----|
| 2147483649 2 3.4 5 invalid 24 -4 | The element '2147483649' is out of range! <br> Element '2147483649' processed - current sum: 0 <br> Element '2' processed - current sum: 2 <br> The element '3.4' is in wrong format! <br> Element '3.4' processed - current sum: 2 <br> Element '5' processed - current sum: 7 <br> The element 'invalid' is in wrong format! <br> Element 'invalid' processed - current sum: 7 <br> Element '24' processed - current sum: 31 <br> Element '-4' processed - current sum: 27 <br> The total sum of all integers is: 27 |
| 9876 string 10 -2147483649 -8 3 4.86555 8 | Element '9876' processed - current sum: 9876 <br> The element 'string' is in wrong format! <br> Element 'string' processed - current sum: 9876 <br> Element '10' processed - current sum: 9886 <br> The element '-2147483649' is out of range! <br> Element '-2147483649' processed - current sum: 9886 <br> Element '-8' processed - current sum: 9878 <br> Element '3' processed - current sum: 9881 <br> The element '4.86555' is in wrong format! <br> Element '4.86555' processed - current sum: 9881 <br> Element '8' processed - current sum: 9889 <br> The total sum of all integers is: 9889 |

### Problem 5.	Play Catch
You will receive on the first line an array of integers. After that you will receive commands, which should manipulate the array:
  +	_"Replace {index} {element}"_ – Replace the element at the given index with the given element. 
  +	_"Print {startIndex} {endIndex}"_ – Print the elements from the start index to the end index inclusive.
  +	_"Show {index}"_ – Print the element at the index.

You have the task to rewrite the messages from the exceptions which can be produced from your program:
  +	If you receive an index, which does not exist in the array print: _"The index does not exist!"_
  +	If you receive a variable, which is of invalid type: _"The variable is not in the correct format!"_
 
When you catch 3 exceptions – stop the input and print the elements of the array separated with _", "_.

Constraints
  +	The elements of the array will be in integers in the interval [-2147483648…2147483647]
  +	You will always receive a valid string for the first part of the command, but the parameters might be invalid
  +	In the _"Print"_ command always be true startIndex <= endIndex
  +	You will always receive at least 3 exceptions

Examples

| Input     | Output |
| --------- | -----|
| 1 2 3 4 5 <br> Replace 1 9 <br> Replace 6 3 <br> Show 3 <br> Show peter <br> Show 6 | The index does not exist! <br> 4 <br> The variable is not in the correct format! <br> The index does not exist! <br> 1, 9, 3, 4, 5 |
| 1 2 3 4 5 <br> Replace 3 9 <br> Print 1 4 <br> Print -3 12 <br> Print 1 5 <br> Show 3 <br> Show 12.3 | 2, 3, 9, 5 <br> The index does not exist! <br> The index does not exist! <br> 9 <br> The variable is not in the correct format! <br> 1, 2, 3, 9, 5 |

### Problem 6.	Money Transactions
You will receive on the first line a collection of bank accounts, consisting of an account number (integer) and its balance (double), in the following format: _"{account number}-{account balance},{account number}-{account balance},…"_

After that, until the _"End"_ command, you will receive commands, which should manipulate the given account`s balance:
  +	_"Deposit {account number} {sum}"_ – Add the given sum to the given account`s balance. 
  +	_"Withdraw {account number} {sum}"_ – Subtract the given sum from the account`s balance.

Print the following messages from the exceptions which can be produced from your program:
  +	If you receive an invalid command: _"Invalid command!"_
  +	If you receive an account, which does not exist: _"Invalid account!"_
  +	If you receive the _"Withdraw"_ command with the sum, which is bigger than the balance: _"Insufficient balance!"_

In all cases, after each received command, print the message: _"Enter another command"_

After each successful operation print, the new balance is formatted to the second integer after the decimal point: _"Account {account number} has new balance: {balance}"_

Constraints
  +	The types of the elements of the given command line will be valid
  +	You will always receive 3 elements in each command line

Examples

| Input     | Output |
| --------- | -----|
| 1-45.67,2-3256.09,3-97.34 <br> Deposit 1 50 <br> Withdraw 3 100 <br> End | Account 1 has new balance: 95.67 <br> Enter another command <br> Insufficient balance! <br> Enter another command |
| 1473653-97.34,44643345-2347.90 <br> Withdraw 1473653 150.50 <br> Deposit 44643345 200 <br> Block 1473653 30 <br> Deposit 1 30 <br> End | Insufficient balance! <br> Enter another command <br> Account 44643345 has new balance: 2547.90 <br> Enter another command <br> Invalid command! <br> Enter another command <br> Invalid account! <br> Enter another command |