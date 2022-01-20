## PROBLEMS DESCRIPTION - SETS AND DICTIONARIES ADVANCED (Lecture)


### Problem 1.	Count Same Values in Array
Create a program that counts in a given array of double values the number of occurrences of each value. 

Examples

| Input     | Output |
| --------- | -----|
| -2.5 4 3 -2.5 -5.5 4 3 3 -2.5 3 | -2.5 - 3 times <br> 4 - 2 times <br> 3 - 4 times <br> -5.5 - 1 times |
| 2 4 4 5 5 2 3 3 4 4 3 3 4 3 5 3 2 5 4 3 | 2 - 3 times <br> 4 - 6 times <br> 5 - 4 times <br> 3 - 7 times |

### Problem 2.	Average Student Grades
Create a program, which reads a name of a student and his/her grades and adds them to the student record, then prints the student's names with their grades and their average grade.

Examples

| Input     | Output |
| --------- | -----|
| 7 <br> John 5.20 <br> Maria 5.50 <br> John 3.20 <br> Maria 2.50 <br> Sam 2.00 <br> Maria 3.46 <br> Sam 3.00 | John -> 5.20 3.20 (avg: 4.20) <br> Maria -> 5.50 2.50 3.46 (avg: 3.82) <br> Sam -> 2.00 3.00 (avg: 2.50) |
| 4 <br> Vlad 4.50 <br> Peter 3.00 <br> Vlad 5.00 <br> Peter 3.66 | Vlad -> 4.50 5.00 (avg: 4.75) <br> Peter -> 3.00 3.66 (avg: 3.33) |
| 5 <br> George 6.00 <br> George 5.50 <br> George 6.00 <br> John 4.40 <br> Peter 3.30 | George -> 6.00 5.50 6.00 (avg: 5.83) <br> John -> 4.40 (avg: 4.40) <br> Peter -> 3.30 (avg: 3.30) |

### Problem 3.	Product Shop
Create a program that prints information about food shops in Sofia and the products they store. Until the _"Revision"_ command is received, you will be receiving input in the format: _"{shop}, {product}, {price}"_.  Keep in mind that if you receive a shop you already have received, you must collect its product information.

Your output must be ordered by shop name and must be in the format:

_"{shop}->_

_Product: {product}, Price: {price}"_

Note: The price should not be rounded or format.

Examples

| Input     | Output |
| --------- | -----|
| lidl, juice, 2.30 <br> fantastico, apple, 1.20 <br> kaufland, banana, 1.10 <br> fantastico, grape, 2.20 <br> Revision | fantastico-> <br> Product: apple, Price: 1.2 <br> Product: grape, Price: 2.2 <br> kaufland-> <br> Product: banana, Price: 1.1 <br> lidl-> <br> Product: juice, Price: 2.3 |
| tmarket, peanuts, 2.20 <br> GoGrill, meatballs, 3.30 <br> GoGrill, HotDog, 1.40 <br> tmarket, sweets, 2.20 <br> Revision | GoGrill-> <br> Product: meatballs, Price: 3.3 <br> Product: HotDog, Price: 1.4 <br> tmarket-> <br> Product: peanuts, Price: 2.2 <br> Product: sweets, Price: 2.2 |

### Problem 4.	Cities by Continent and Country
Create a program that reads continents, countries and their cities, puts them in a nested dictionary and prints them.

Examples

| Input     | Output |
| --------- | -----|
| 9 <br> Europe Bulgaria Sofia <br> Asia China Beijing <br> Asia Japan Tokyo <br> Europe Poland Warsaw <br> Europe Germany Berlin <br> Europe Poland Poznan <br> Europe Bulgaria Plovdiv <br> Africa Nigeria Abuja <br> Asia China Shanghai | Europe: <br>   Bulgaria -> Sofia, Plovdiv <br>   Poland -> Warsaw, Poznan <br> Germany -> Berlin <br> Asia: <br>   China -> Beijing, Shanghai <br>   Japan -> Tokyo <br> Africa: <br>   Nigeria -> Abuja |
| 3 <br> Europe Germany Berlin <br> Europe Bulgaria Varna <br> Africa Egypt Cairo | Europe: <br>   Germany -> Berlin <br>   Bulgaria -> Varna <br> Africa: <br>   Egypt -> Cairo |

### Problem 5.	Record Unique Names
Create a program, which will take a list of names and print only the unique names in the list.

Examples

| Input     | Output |
| --------- | -----|
| 8 <br> John <br> Alex <br> John <br> Sam <br> Alex <br> Alice <br> Peter <br> Alex | John <br> Alex <br> Sam <br> Alice <br> Peter |
| 7 <br> Lyle <br> Bruce <br> Alice <br> Easton <br> Shawn <br> Alice <br> Shawn | Lyle <br> Bruce <br> Alice <br> Easton <br> Shawn |

### Problem 6.	Parking Lot
Create a program that:
  +	Records a car number for every car that enters the parking lot
  +	Removes a car number when the car leaves the parking lot

The input will be a string in the format: _"direction, carNumber"_. You will be receiving commands, until the _"END"_ command is given.

Print the car numbers of the cars, which are still in the parking lot.

Examples

| Input     | Output |
| --------- | -----|
| IN, CA2844AA <br> IN, CA1234TA <br> OUT, CA2844AA <br> IN, CA9999TT <br> IN, CA2866HI <br> OUT, CA1234TA <br> IN, CA2844AA <br> OUT, CA2866HI <br> IN, CA9876HH <br> IN, CA2822UU <br> END | CA9999TT <br> CA2844AA <br> CA9876HH <br> CA2822UU |
| IN, CA2844AA <br> IN, CA1234TA <br> OUT, CA2844AA <br> OUT, CA1234TA <br> END | Parking Lot is Empty |

### Problem 7.	SoftUni Party
There is a party in SoftUni. Many guests are invited and there are two types of them: VIP and Regular. When a guest comes, check if he/she exists in any of the two reservation lists.

All reservation numbers will be with the length of 8 chars.

All VIP numbers start with a digit.

First, you will be receiving the reservation numbers of the guests. You can also receive 2 possible commands:
  +	_"PARTY"_ – After this command you will begin receiving the reservation numbers of the people, who actually came to the party.
  +	_"END"_ – The party is over and you have to stop the program and print the appropriate output.

In the end, print the count of the quests who didn't come to the party and afterwards, print their reservation numbers. the VIP guests must be first.

Examples

| Input     | Output |
| --------- | -----|
| 7IK9Yo0h <br> 9NoBUajQ <br> Ce8vwPmE <br> SVQXQCbc <br> tSzE5t0p <br> PARTY <br> 9NoBUajQ <br> Ce8vwPmE <br> SVQXQCbc <br> END | 2 <br> 7IK9Yo0h <br> tSzE5t0p |
| m8rfQBvl <br> fc1oZCE0 <br> UgffRkOn <br> 7ugX7bm0 <br> 9CQBGUeJ <br> 2FQZT3uC <br> dziNz78I <br> mdSGyQCJ <br> LjcVpmDL <br> fPXNHpm1 <br> HTTbwRmM <br> B5yTkMQi <br> 8N0FThqG <br> xys2FYzn <br> MDzcM9ZK <br> PARTY <br> 2FQZT3uC <br> dziNz78I <br> mdSGyQCJ <br> LjcVpmDL <br> fPXNHpm1 <br> HTTbwRmM <br> B5yTkMQi <br> 8N0FThqG <br> m8rfQBvl <br> fc1oZCE0 <br> UgffRkOn <br> 7ugX7bm0 <br> 9CQBGUeJ <br> END | 2 <br> xys2FYzn <br> MDzcM9ZK |
