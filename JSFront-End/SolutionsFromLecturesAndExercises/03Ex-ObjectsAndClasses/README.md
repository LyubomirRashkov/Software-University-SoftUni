## PROBLEMS DESCRIPTION - OBJECTS AND CLASSES (Exercise)


### Problem 1.	Employees

You're tasked to create a list of employees and their personal numbers.

You will receive an array of strings. Each string is an employee name and to assign them a personal number you have to find the length of the name (whitespace included). 

Try to use an object.

At the end print all the list employees in the following format: "Name: {employeeName} -- Personal Number: {personalNum}" 

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'Silas Butler', <br> &ensp; 'Adnaan Buckley', <br> &ensp; 'Juan Peterson', <br> &ensp; 'Brendan Villarreal' <br> ] | Name: Silas Butler -- Personal Number: 12 <br> Name: Adnaan Buckley -- Personal Number: 14 <br> Name: Juan Peterson -- Personal Number: 13 <br> Name: Brendan Villarreal -- Personal Number: 18 |
| [ <br> &ensp; 'Samuel Jackson', <br> &ensp; 'Will Smith', <br> &ensp; 'Bruce Willis', <br> &ensp; 'Tom Holland' <br> ] | Name: Samuel Jackson -- Personal Number: 14 <br> Name: Will Smith -- Personal Number: 10 <br> Name: Bruce Willis -- Personal Number: 12 <br> Name: Tom Holland -- Personal Number: 11 |

### Problem 2.	Towns

You’re tasked to create and print objects from a text table. 

You will receive the input as an array of strings, where each string represents a table row, with values on the row separated by pipes " | " and spaces.

The table will consist of exactly 3 columns "Town", "Latitude" and "Longitude". The latitude and longitude columns will always contain valid numbers. Check the examples to get a better understanding of your task.

The output should be objects. Latitude and longitude must be parsed to numbers and formatted to the second decimal point!

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'Sofia \| 42.696552 \| 23.32601', <br> &ensp; 'Beijing \| 39.913818 \| 116.363625' <br> ] | { town: 'Sofia', latitude: '42.70', longitude: '23.33' } <br> { town: 'Beijing', latitude: '39.91', longitude: '116.36' } |
| [ <br> &ensp; 'Plovdiv \| 136.45 \| 812.575' <br> ] | { town: 'Plovdiv', latitude: '136.45', longitude: '812.58' } |

### Problem 3.	Store Provision

You will receive two arrays. The first array represents the current stock of the local store. The second array will contain products that the store has ordered for delivery.

The following information applies to both arrays:

Every even index will hold the name of the product and every odd index will hold the quantity of that product. The second array could contain products that are already in the local store. If that happens increase the quantity for the given product. You should store them into an object, and print them in the following format: (product -> quantity)

All of the arrays’ values will be strings.

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2' <br> ], <br> [ <br> &ensp; 'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30' <br> ] | Chips -> 5 <br> CocaCola -> 9 <br> Bananas -> 44 <br> Pasta -> 11 <br> Beer -> 2 <br> Flour -> 44 <br> Oil -> 12 <br> Tomatoes -> 70 |
| [ <br> &ensp; 'Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5' <br> ], <br> [ <br> &ensp; 'Sugar', '44', 'Oil', '12', 'Apple', '7', 'Tomatoes', '7', 'Bananas', '30' <br> ] | Salt -> 2 <br> Fanta -> 4 <br> Apple -> 21 <br> Water -> 4 <br> Juice -> 5 <br> Sugar -> 44 <br> Oil -> 12 <br> Tomatoes -> 7 <br> Bananas -> 30 |

### Problem 4.	Movies

Write a function that stores information about movies inside an array. The movie's object info must be name, director, and date. You can receive several types of input:

  +	"addMovie {movie name}" – add the movie
  +	"{movie name} directedBy {director}" – check if the movie exists and then add the director
  +	"{movie name} onDate {date}" – check if the movie exists and then add the date

At the end print all the movies that have all the info (if the movie has no director, name, or date, don’t print it) in JSON format.

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'addMovie Fast and Furious', <br> &ensp; 'addMovie Godfather', <br> &ensp; 'Inception directedBy Christopher Nolan', <br> &ensp; 'Godfather directedBy Francis Ford Coppola', <br> &ensp; 'Godfather onDate 29.07.2018', <br> &ensp; 'Fast and Furious onDate 30.07.2018', <br> &ensp; 'Batman onDate 01.08.2018', <br> &ensp; 'Fast and Furious directedBy Rob Cohen' <br> ] | {"name":"Fast and Furious","date":"30.07.2018","director":"Rob Cohen"} <br> {"name":"Godfather","director":"Francis Ford Coppola","date":"29.07.2018"} |
| [ <br> &ensp; 'addMovie The Avengers', <br> &ensp; 'addMovie Superman', <br> &ensp; 'The Avengers directedBy Anthony Russo', <br> &ensp; 'The Avengers onDate 30.07.2010', <br> &ensp; 'Captain America onDate 30.07.2010', <br> &ensp; 'Captain America directedBy Joe Russo' <br> ] | {"name":"The Avengers","director":"Anthony Russo","date":"30.07.2010"} |

### Problem 5.	Inventory

Create a function, which creates a register for heroes, with their names, level, and items (if they have such). 

The input comes as an array of strings. Each element holds data for a hero, in the following format: "{heroName} / {heroLevel} / {item1}, {item2}, {item3}..." 

You must store the data about every hero. The name is a string, the level is a number and the items are all strings.

The output is all of the data for all the heroes you’ve stored sorted ascending by level. The data must be in the following format for each hero:

Hero: {heroName}

level => {heroLevel}

items => {item1}, {item2}, {item3}

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'Isacc / 25 / Apple, GravityGun', <br> &ensp; 'Derek / 12 / BarrelVest, DestructionSword', <br> &ensp; 'Hes / 1 / Desolator, Sentinel, Antara' <br> ] | Hero: Hes <br> level => 1 <br> items => Desolator, Sentinel, Antara <br> Hero: Derek <br> level => 12 <br> items => BarrelVest, DestructionSword <br> Hero: Isacc <br> level => 25 <br> items => Apple, GravityGun |
| [ <br> &ensp; 'Batman / 2 / Banana, Gun', <br> &ensp; 'Superman / 18 / Sword', <br> &ensp; 'Poppy / 28 / Sentinel, Antara' <br> ] | Hero: Batman <br> level => 2 <br> items => Banana, Gun <br> Hero: Superman <br> level => 18 <br> items => Sword <br> Hero: Poppy <br> level => 28 <br> items => Sentinel, Antara |

### Problem 6.	Words Tracker

Write a function that receives an array of words and finds occurrences of given words in that sentence.

The input will come as an array of strings. The first string will contain the words you will be looking for separated by a space. All strings after that will be the words in which you will check for a match.

Print for each word how many times it occurs. The words should be sorted by count in descending.

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'this sentence', <br> &ensp; 'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task' <br> ] | this - 3 <br> sentence - 2 |
| [ <br> &ensp; 'is the', <br> &ensp; 'first', 'sentence', 'Here', 'is', 'another', 'the', 'And', 'finally', 'the', 'the', 'sentence' <br> ] | the – 3 <br> is - 1 |

### Problem 7.	Odd Occurrences

Write a function that extracts the elements of a sentence, if it appears an odd number of times (case-insensitive).

The input comes as a single string. The words will be separated by a single space.

Examples

| Input | Output |
| --- | --- |
| 'Java C# Php PHP Java PhP 3 C# 3 1 5 C#' | 1 5 c# php |
| 'Cake IS SWEET is Soft CAKE sweet Food' | soft food |

### Problem 8.	Piccolo

Write a function that:

  +	Records a car number for every car that enters the parking lot
  +	Removes a car number when the car goes out
  +	Input will be an array of strings in format [direction, carNumber]

Print the output with all car numbers which are in the parking lot sorted in ascending by number.

If the parking lot is empty, print: "Parking Lot is Empty".

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'IN, CA2844AA', <br> &ensp; 'IN, CA1234TA', <br> &ensp; 'OUT, CA2844AA', <br> &ensp; 'IN, CA9999TT', <br> &ensp; 'IN, CA2866HI', <br> &ensp; 'OUT, CA1234TA', <br> &ensp; 'IN, CA2844AA', <br> &ensp; 'OUT, CA2866HI', <br> &ensp; 'IN, CA9876HH', <br> &ensp; 'IN, CA2822UU' <br> ] | CA2822UU <br> CA2844AA <br> CA9876HH <br> CA9999TT |
| [ <br> &ensp; 'IN, CA2844AA', <br> &ensp; 'IN, CA1234TA', <br> &ensp; 'OUT, CA2844AA', <br> &ensp; 'OUT, CA1234TA' <br> ] | Parking Lot is Empty |

### Problem 9.	Make a Dictionary

You will receive an array with strings in the form of JSON's. 

You have to parse these strings and combine them into one object. Every string from the array will hold terms and a description. If you receive the same term twice, replace it with the new definition.

Print every term and definition in that dictionary on new line in format: 'Term: {term} => Definition: {definition}'

Don't forget to sort the dictionary alphabetically by the terms as in real dictionaries.

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}', <br> &ensp; '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}', <br> &ensp; '{"Boiler":"A fuel-burning apparatus or container for heating water."}', <br> &ensp; '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}', <br> &ensp; '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}' <br> ] | Term: Boiler => Definition: A fuel-burning apparatus or container for heating water. <br> Term: Bus => Definition: A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare. <br> Term: Coffee => Definition: A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub. <br> Term: Microphone => Definition: An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded. <br> Term: Tape => Definition: A narrow strip of material, typically used to hold or fasten something. |
| [ <br> &ensp; '{"Cup":"A small bowl-shaped container for drinking from, typically having a handle"}', <br> &ensp; '{"Cake":"An item of soft sweet food made from a mixture of flour, fat, eggs, sugar, and other ingredients, baked and sometimes iced or decorated."} ', <br> &ensp; '{"Watermelon":"The large fruit of a plant of the gourd family, with smooth green skin, red pulp, and watery juice."} ', <br> &ensp; '{"Music":"Vocal or instrumental sounds (or both) combined in such a way as to produce beauty of form, harmony, and expression of emotion."} ', <br> &ensp; '{"Art":"The expression or application of human creative skill and imagination, typically in a visual form such as painting or sculpture, producing works to be appreciated primarily for their beauty or emotional power."} ' <br> ] | Term: Art => Definition: The expression or application of human creative skill and imagination, typically in a visual form such as painting or sculpture, producing works to be appreciated primarily for their beauty or emotional power. <br> Term: Cake => Definition: An item of soft sweet food made from a mixture of flour, fat, eggs, sugar, and other ingredients, baked and sometimes iced or decorated. <br> Term: Cup => Definition: A small bowl-shaped container for drinking from, typically having a handle <br> Term: Music => Definition: Vocal or instrumental sounds (or both) combined in such a way as to produce beauty of form, harmony, and expression of emotion. <br> Term: Watermelon => Definition: The large fruit of a plant of the gourd family, with smooth green skin, red pulp, and watery juice. |

### Problem 10.	Class Vehicle

Create a class with the name Vehicle that has the following properties:

  +	type – a string
  +	model – a string
  +	parts – an object that contains:
    +	engine – number (quality of the engine)
    +	power – number
    +	quality – engine * power
  +	fuel – a number
  +	drive – a method that receives fuel loss and decreases the fuel of the vehicle by that number

The constructor should receive the type, the model, the parts as an object, and the fuel

Examples

| Input | Output |
| --- | --- |
| let parts = { engine: 6, power: 100 }; <br> let vehicle = new Vehicle('a', 'b', parts, 200); <br> vehicle.drive(100); <br> console.log(vehicle.fuel); <br> console.log(vehicle.parts.quality); | 100 <br> 600 |
| let parts = {engine: 9, power: 500}; <br> let vehicle = new Vehicle('l', 'k', parts, 840); <br> vehicle.drive(20); <br> console.log(vehicle.fuel); | 820 |