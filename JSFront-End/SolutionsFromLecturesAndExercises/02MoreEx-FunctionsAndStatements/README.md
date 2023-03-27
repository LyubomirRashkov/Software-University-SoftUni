## PROBLEMS DESCRIPTION - FUNCTIONS AND STATEMENTS (More Exercises)


### Problem 1.	Car Wash

Write a JS function that receives some commands. Depending on the command, add or subtract a percentage of how much the car is cleaned or dirty. Start from 0. The first command will always be 'soap':

  +	soap – add 10 to the value
  +	water – increase the value by 20%
  +	vacuum cleaner – increase the value by 25%
  +	mud – decrease the value by 10%

The input comes as an array of strings. When finished cleaning the car, print the resulting value in the format: \`The car is {value}% clean.\`

Note: The value should be rounded to the second decimal point.

Examples

| Input | Output |
| --- | --- |
| ['soap', 'soap', 'vacuum cleaner', 'mud', 'soap', 'water'] | The car is 39.00% clean. |
| ["soap", "water", "mud", "mud", "water", "mud", "vacuum cleaner"] | The car is 13.12% clean. |

### Problem 2.	Number Modification

Write a JS program that changes a number until the average of all its digits is not higher than 5. To modify the number, your program should append a 9 to the end of the number, when the average value of all its digits is higher than 5 the program should stop appending. 

The input is a single number.

The output should consist of a single number - the final modified number which has an average value of all its digits higher than 5. The output should be printed on the console.

Constraints
  
  +	The input number will consist of no more than 6 digits.
  +	The input will be a valid number (there will be no leading zeroes).

Examples

| Input | Output |
| --- | --- |
| 101 | 1019999 |
| 5835 | 5835 |

### Problem 3.	Points Validation

Write a JS program that receives two points in the format [x1, y1, x2, y2] and checks if the distances between each point (x, y) and the start of the Cartesian coordinate system (0, 0) and between the points themselves is valid. A distance between two points is considered valid if it is an integer value.

  +	In case a distance is valid print: \`{x1, y1} to {x2, y2} is valid\`
  +	In case the distance is invalid print: \`{x1, y1} to {x2, y2} is invalid\` 

The order of comparisons should always be first {x1, y1} to {0, 0}, then {x2, y2} to {0, 0} and finally {x1, y1} to {x2, y2}. 

The input consists of two points given as an array of numbers.

You can use the following formula to help you calculate the distance between the points (x1, y1) and (x2, y2):

![изображение](https://user-images.githubusercontent.com/82647282/223179802-d6f8203a-5061-42e0-af1e-5a8750f92a7c.png)

Examples

| Input | Output |
| --- | --- |
| [3, 0, 0, 4] | {3, 0} to {0, 0} is valid <br> {0, 4} to {0, 0} is valid <br> {3, 0} to {0, 4} is valid |
| [2, 1, 1, 1] | {2, 1} to {0, 0} is invalid <br> {1, 1} to {0, 0} is invalid <br> {2, 1} to {1, 1} is valid |

### Problem 4.	Radio Crystals 

You need to write a JS program that monitors the current thickness of the crystal and recommends the next procedure that will bring it closer to the desired frequency. To reduce waste and the time it takes to make each crystal your program needs to complete the process with the least number of operations. Each operation takes the same amount of time, but since they are done at different parts of the factory, the crystals have to be transported and thoroughly washed every time an operation different from the previous must be performed, so this must also be taken into account. When determining the order, always attempt to start from the operation that removes the largest amount of material.

The different operations you can perform are the following:

  +	Cut – cuts the crystal in 4
  +	Lap – removes 20% of the crystal’s thickness
  +	Grind – removes 20 microns of thickness
  +	Etch – removes 2 microns of thickness
  +	X-ray – increases the thickness of the crystal by 1 micron; this operation can only be done once!
  +	Transporting and washing – removes any imperfections smaller than 1 micron (round down the number); do this after every batch of operations that remove material

At the beginning of your program, you will receive a number representing the desired final thickness and a series of numbers, representing the thickness of crystal ore in microns. Process each chunk and print to the console the order of operations and the number of times they need to be repeated to bring them to the desired thickness.

The input comes as a numeric array with a variable number of elements. The first number is the target thickness and all following numbers are the thickness of different chunks of quartz ore.

The output is the order of operation and how many times they are repeated, every operation on a new line. See the examples for more information.

Examples

| Input | Output |
| --- | --- |
| [1375, 50000] | Processing chunk 50000 microns <br> Cut x2 <br> Transporting and washing <br> Lap x3 <br> Transporting and washing <br> Grind x11 <br> Transporting and washing <br> Etch x3 <br> Transporting and washing <br> X-ray x1 <br> Finished crystal 1375 microns |
| [1000, 4000, 8100] | Processing chunk 4000 microns <br> Cut x1 <br> Transporting and washing <br> Finished crystal 1000 microns <br> Processing chunk 8100 microns <br> Cut x1 <br> Transporting and washing <br> Lap x3 <br> Transporting and washing <br> Grind x1 <br> Transporting and washing <br> Etch x8 <br> Transporting and washing <br> Finished crystal 1000 microns |

### Problem 5.	Print DNA

Write a JS program that prints a DNA helix with a length, specified by the user. The helix has a repeating structure, but the symbol in the chain follows the sequence ATCGTTAGGG. See the examples for more information.

The input comes as a single number. It represents the length of the required helix.

The output is the completed structure, printed on the console.

Examples

| Input | Output |
| --- | --- |
| 4 | \*\*AT\*\* <br> \*C--G\* <br> T----T <br> \*A--G\* |
| 10 | \*\*AT\*\* <br> \*C--G\* <br> T----T <br> \*A--G\* <br> \*\*GG\*\* <br> \*A--T\* <br> C----G <br> \*T--T\* <br> \*\*AG\*\* <br> \*G--G\* |

### Problem 6. Array Manipulator

Write a function that receives an array of integers and an array of string commands and executes them over the array. The commands are as follows:

  +	add \<index\> \<element\> – adds element at the specified index (elements right from this position inclusively are shifted to the right).
  +	addMany \<index\> \<element 1\> \<element 2\> … \<element n\> – adds a set of elements at the specified index.
  +	contains \<element\> – prints the index of the first occurrence of the specified element (if exists) in the array or -1 if the element is not found.
  +	remove \<index\> – removes the element at the specified index.
  +	shift \<positions\> – shifts every element of the array the number of positions to the left (with rotation).
    +	For example, [1, 2, 3, 4, 5] -> shift 2 -> [3, 4, 5, 1, 2]
  +	sumPairs – sums the elements in the array by pairs (first + second, third + fourth, …).
    +	For example, [1, 2, 4, 5, 6, 7, 8] -> [3, 9, 13, 8].
  +	print – stop receiving more commands and print the last state of the array in the following format: \`[ {element1}, {element2}, …elementN} ]\`
 
 Note: The elements in the array must be joined by comma and space (, ).

Examples

| Input | Output |
| --- | --- |
| [1, 2, 4, 5, 6, 7], ['add 1 8', 'contains 1', 'contains 3', 'print'] | 0 <br> -1 <br> [ 1, 8, 2, 4, 5, 6, 7 ] |
| [1, 2, 3, 4, 5], ['addMany 5 9 8 7 6 5', 'contains 15', 'remove 3', 'shift 1', 'print'] | -1 <br> [ 2, 3, 5, 9, 8, 7, 6, 5, 1 ] |