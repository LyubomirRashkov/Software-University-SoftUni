## PROBLEMS DESCRIPTION - JS SYNTAX FUNDAMENTALS  (More Exercises)


### Problem 1.	Validity Checker

Write a program that receives a total of 4 parameters in the format x1, y1, x2, y2. Check if the distance between each point (x, y) and the beginning of the Cartesian coordinate system (0, 0) is valid. A distance between two points is considered valid if it is an integer value. 

Note: You can use the following formula to help you calculate the distance between the points (x1, y1) and (x2, y2).

![изображение](https://user-images.githubusercontent.com/82647282/221634616-b9abb38d-b45f-4ded-aa14-95b17cc370e9.png)

The order of comparisons should always be first {x1, y1} to {0, 0}, then {x2, y2} to {0, 0} and finally {x1, y1} to {x2, y2}. 

In case a distance is valid, print: \`{x1, y1} to {x2, y2} is valid`

If the distance is invalid, print: \`{x1, y1} to {x2, y2} is invalid`

The input consists of two points given as 4 numbers.

For each comparison print either \`{x1, y1} to {x2, y2} is valid\` if the distance is valid, or \`{x1, y1} to {x2, y2} is invalid` if it is invalid.

Examples

| Input | Output |
| --- | --- |
| 3, 0, 0, 4 | {3, 0} to {0, 0} is valid <br> {0, 4} to {0, 0} is valid <br> {3, 0} to {0, 4} is valid |
| 2, 1, 1, 1 | {2, 1} to {0, 0} is invalid <br> {1, 1} to {0, 0} is invalid <br> {2, 1} to {1, 1} is valid |

### Problem 2.	Words Uppercase

Write a program that extracts all words from a passed-in string and converts them to upper case. The extracted words in the upper case must be printed on a single line separated by ", ".

The input comes as a single string argument - the text to extract and convert words from.

The output should be a single line containing the converted string.

Examples

| Input | Output |
| --- | --- |
| 'Hi, how are you?' | HI, HOW, ARE, YOU |
| 'hello' | HELLO |

### Problem 3.	Calculator

Write a function that receives 3 parameters: a number, an operator (string), and another number.

The operator can be:  '+', '-', '/', '*'. Print the result of the calculation on the console formatted to the second decimal point.

Examples

| Input | Output |
| --- | --- |
| 5, '+', 10 | 15.00 |
| 25.5, '-', 3 | 22.50 |

### Problem 4.	Gladiator Expenses

As a gladiator, Peter has to repair his broken equipment when he loses a fight. His equipment consists of a helmet, sword, shield, and armor. You will receive Peter's lost fights count. 

  +	Every second lost game, his helmet is broken.
  +	Every third lost game, his sword is broken.
  +	When both his sword and helmet are broken in the same lost fight, his shield also breaks.
  +	Every second time, when his shield brakes, his armor also needs to be repaired. 

You will receive the price of each item in his equipment. Calculate his expenses for the year for renewing his equipment. 

Input / Constraints

You will receive 5 parameters to your function:

  +	The first parameter - lost fights count - is an integer in the range [0, 1000].
  +	The second parameter - helmet price - is the floating-point number in the range [0, 1000]. 
  +	The third parameter - sword price - is the floating-point number in the range [0, 1000]. 
  +	The fourth parameter - shield price - is the floating-point number in the range [0, 1000]. 
  +	The fifth parameter - armor price - is the floating-point number in the range [0, 1000]. 

Output

  +	As output you must print Peter's total expenses for new equipment rounded to the second decimal point: "Gladiator expenses: {expenses} aureus"
  +	Allowed working time / memory: 100ms / 16MB.

Examples

| Input | Output |
| --- | --- |
| 7, 2, 3, 4, 5 | Gladiator expenses: 16.00 aureus |
| 23, 12.50, 21.50, 40, 200 | Gladiator expenses: 608.00 aureus |

### Problem 5.  Spice Must Flow

Write a program that calculates the total amount of spice that can be extracted from a source. The source has a starting yield, which indicates how much spice can be mined on the first day. After it has been mined for a day, the yield drops by 10, meaning on the second day it’ll produce 10 less spice than on the first, on the third day 10 less than on the second, and so on. A source is considered profitable only while its yield is at least 100 – when less than 100 spices are expected in a day, abandon the source. 

The mining crew consumes 26 spices every day at the end of their shift and an additional 26 after the mine has been exhausted. Note that the workers cannot consume more spice than there is in storage. 

When the operation is complete, print on the console on two separate lines how many days the mine has operated and the total amount of spice extracted. 

Input 

You will receive a number, representing the starting yield of the source. 

Output 

Print on the console on two separate lines how many days the mine has operated and the total amount of spice extracted.

Constraints 
  
  +	The starting yield will be a number within range [0…228].

Examples

| Input | Output |
| --- | --- |
| 111 | 2 <br> 134 |
| 450 | 36 <br> 8938 |

### Problem 6.	Login

You will be given a string representing a username. The correct password will be that username reversed. Until you receive the correct password print on the console: "Incorrect password. Try again.". When you receive the correct password print: "User {username} logged in.". 

However, on the fourth try if the password is still not correct print: "User {username} blocked!" and end the program. 

The input comes as an array of strings - the first string represents username and each subsequent string is a password.

Examples

| Input | Output |
| --- | --- |
| ['Acer','login','go','let me in','recA'] | Incorrect password. Try again. <br> Incorrect password. Try again. <br> Incorrect password. Try again. <br> User Acer logged in. |
| ['momo','omom'] | User momo logged in. |
| ['sunny','rainy','cloudy','sunny','not sunny'] | Incorrect password. Try again. <br> Incorrect password. Try again. <br> Incorrect password. Try again. <br> User sunny blocked! |

### Problem 7.  Bitcoin "Mining"

Write a JavaScript program that calculates the total amount of bitcoins you purchased with the gold you mined during your shift at the mine. Your shift consists of a certain number of days where you mine an amount of gold in grams. Your program will receive an array with the amount of gold you mined each day, where the first day of your shift is the first index of the array. Also, someone was stealing every third day from the start of your shift 30% from the mined gold for this day. You need to check, which day you have enough money to buy your first bitcoin. For the different exchanges use these prices:

| 1 Bitcoin | 1 g of gold |
|:---:|:---:|
| 11949.16 lv. | 67.51 lv. |

Input

You will receive an array of numbers, representing your shift at the mine.

Output

Print on the console these lines in the following formats:
  
  +	First-line prints the total amount of bought bitcoins: \`Bought bitcoins: {count}\`
  +	Second-line prints which day you bought your first bitcoin: \`Day of the first purchased bitcoin: {day}\`. In case you did not purchase any bitcoins, do not print the second line.
  +	Third-line prints the amount of money that’s left after the bitcoin purchases rounded by the second digit after the decimal point: \`Left money: {money} lv.\`

Constraints
  +	The input array may contain up to 1,000 elements
  +	The numbers in the array are in the range [0.01..5,000.00] inclusive
  +	Allowed time/memory: 100ms/16MB

Examples

| Input | Output |
| --- | --- |
| [100, 200, 300] | Bought bitcoins: 2 <br> Day of the first purchased bitcoin: 2 <br> Left money: 10531.78 lv. |
| [50, 100] | Bought bitcoins: 0 <br> Left money: 10126.50 lv. |
| [3124.15, 504.212, 2511.124] | Bought bitcoins: 30 <br> Day of the first purchased bitcoin: 1 <br> ILeft money: 5144.11 lv. |

### Problem 8.	The Pyramid of King Djoser

Write a JS program that calculates how much resources will be required for the construction of a pyramid. It is made out of stone, marble, lapis lazuli, and gold. Your program will receive an integer that will be the base width and length of the pyramid and an increment that is the height of each step. The bulk is made out of stone, while the outer layer is made out of marble. Every fifth step’s outer layer is made out of lapis lazuli instead of marble. The final step is made out of gold.

The pyramid is built with 1x1 blocks with a height equal to the given increment. The first step of the pyramid has a width and length equal to the given base and every next step is reduced by 2 blocks (1 from each side). The height of every step equals the given increment. See the drawing for an example. White steps are covered in marble, blue steps are covered in lapis lazuli (every fifth layer from the bottom), and yellow steps are made entirely out of gold (top-most step).

![изображение](https://user-images.githubusercontent.com/82647282/221641836-36fd06ff-cad6-4fef-8766-7c347397c98e.png)

Since the outer layer of each step is made of decorative material, to calculate the required stone for one step, reduce the width and length by 2 blocks (one from each side), find its area, and multiply it by the increment. The rest of the step is made out of lapis lazuli for every fifth step from the bottom and marble for all other steps. To find the amount needed, you may, for example, find its perimeter and reduce it by 4 (to compensate for the overlapping corners), and multiply the result by the increment. See the drawing for details (grey is stone, white is decoration).

![изображение](https://user-images.githubusercontent.com/82647282/221641972-b84f115e-7693-401e-89c4-ee30e1ff4959.png)

5x5 step

Stone required – 9 x increment

Marble required– 16 x increment

![изображение](https://user-images.githubusercontent.com/82647282/221642045-4d93b91a-0f96-476f-bdd8-c7f43a3ef1e5.png)

7x7 step

Stone required – 25 x increment

Marble required – 24 x increment

![изображение](https://user-images.githubusercontent.com/82647282/221642095-b409cd75-08fe-4ffd-83a9-38408861e2ea.png)

8x8 step

Stone required – 36 x increment

Marble required – 28 x increment

Note the top-most layer is made entirely out of gold, with a height equal to the given increment. See the examples for complete calculations.

Input

You will receive two number parameters base and increment.

Output

Print on the console on separate lines the total required amounts of each material rounded up and the final height of the pyramid rounded down, as shown in the examples.

Constraints

  +	The base will always be an integer greater than zero
  +	The increment will always be a number greater than zero
  +	Number.MAX_SAFE_INTEGER will never be exceeded for any of the calculations

Examples

| Input | Output |
| --- | --- |
| 11, 1 | Stone required: 165 <br> Marble required: 112 <br> Lapis Lazuli required: 8 <br> Gold required: 1 <br> Final pyramid height: 6 |
| 11, 0.75 | Stone required: 124 <br> Marble required: 84 <br> Lapis Lazuli required: 6 <br> Gold required: 1 <br> Final pyramid height: 4 |
| 12, 1 | Stone required: 220 <br> Marble required: 128 <br> Lapis Lazuli required: 12 <br> Gold required: 4 <br> Final pyramid height: 6 |
| 23, 0.5 | Stone required: 886 <br> Marble required: 228 <br> Lapis Lazuli required: 36 <br> Gold required: 1 <br> Final pyramid height: 6 |