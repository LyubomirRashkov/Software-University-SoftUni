## PROBLEMS DESCRIPTION - Exam 30 January 2022


### Problem 1.	Strings Mashup

Given a string str and an integer n, write a program that prints all strings of length n that consist only of letters from str and are lexicographically sorted. You can use one symbol multiple times in one string.

Input

  +	You will receive a string – str – letters you must use to generate all solutions.
  +	You will receive an integer – n – max length of a string.

Output

  +	Print all strings of length n that can be generated. 

Constraints

  +	str length will be in the range [1…26].
  +	str will consist only of unique chars.
  +	n will be in the range [1… 10].

Examples

| Input | Output |
| --- | --- |
| cba <br> 2 | aa <br> ab <br> ac <br> bb <br> bc <br> cc |
| bacefd <br> 1 | a <br> b <br> c <br> d <br> e <br> f |

### Problem 2. Rumors

You are given a network of n people, labeled from 1 to n. 

We will run a rumor from a given person x. Write a program that prints the quickest time it takes for each person in person x network to receive the rumor. 

You can assume that the time for the rumor to spread between two people is 1.

Input

  +	First, you will receive an integer – n – number of people in the network.
  +	After that, you will receive an integer – e – number of connections in the network.
  +	On the next e lines, you will receive all connections in the following format: "{person1} {person2}".
  +	On the last line, you will receive an integer – x – the person to run the rumor.

Output

  +	Print the quickest time for each person in the person x network to hear the rumor in the following format: "{person x} -> {personi} (time)"
    +	Order of the output doesn’t matter.

Constraints

  +	n will be in the range [1… 30].
  +	e will be in the range [1… 50].
  +	Person connections (e) will always be in the range [1… n].
  +	x will always be in the range [1… n].

Examples

| Input | Output |
| --- | --- |
| 8 <br> 10 <br> 1 2 <br> 1 4 <br> 2 3 <br> 4 5 <br> 5 8 <br> 5 6 <br> 5 7 <br> 5 8 <br> 6 7 <br> 7 8 <br> 1 | 1 -> 2 (1) <br> 1 -> 3 (2) <br> 1 -> 4 (1) <br> 1 -> 5 (2) <br> 1 -> 6 (3) <br> 1 -> 7 (3) <br> 1 -> 8 (3) |
| 11 <br> 11 <br> 1 5 <br> 1 4 <br> 5 7 <br> 7 8 <br> 8 2 <br> 2 3 <br> 3 4 <br> 4 1 <br> 6 2 <br> 9 10 <br> 11 9 <br> 6 | 6 -> 1 (4) <br> 6 -> 2 (1) <br> 6 -> 3 (2) <br> 6 -> 4 (3) <br> 6 -> 5 (4) <br> 6 -> 7 (3) <br> 6 -> 8 (2) |

### Problem 3. Bank Robbery

Josh and Prakash just robbed a bank. They stole n safe deposit boxes. Each deposit box has a different amount of gold bars in it. 

Write a program that prints how Josh and Prakash can share the deposit boxes evenly, so they end up with an equal amount of gold without splitting gold bars.

Input

  +	You will receive single line with integers, separated by space.
    +	Each integer represents a safe deposit box.

Output

  +	First, print safe deposit boxes that Josh will take.
  +	After that, print safe deposit boxes that Prakash will take.
  +	Both sequences should be sorted in ascending order.

Constraints

  + Integers representing safe deposit boxes will be in the range [1... 150].
  +	Integers will be unique.
  +	Safe deposit boxes always can be divided evenly.

Examples

| Input | Output |
| --- | --- |
| 8 17 45 91 11 32 102 33 6 1 | 17 32 33 91 <br> 1 6 8 11 45 102 |
| 5 10 2 3 | 10 <br> 2 3 5 |