## PROBLEMS DESCRIPTION - OBJECTS AND CLASSES (Lecture)


### Problem 1.	Person Info

Write a function that receives 3 parameters, sets them to an object, and returns that object.

The input comes as 3 separate strings in the following order: firstName, lastName, age.

Examples

| Input | Object Properties |
| --- | --- |
| "Peter", "Pan", "20" | firstName: Peter <br> lastName: Pan <br> age: 20 |
| "George", "Smith", "18" | firstName: George <br> lastName: Smith <br> age: 18 |

### Problem 2.	City

Write a function that receives a single parameter – an object, containing five properties: { name, area, population, country, postcode }

Loop through all the keys and print them with their values in format: "{key} -> {value}"

Examples

| Input | Output |
| --- | --- |
| { <br> &ensp; name: "Sofia", <br> &ensp; area: 492, <br> &ensp; population: 1238438, <br> &ensp; country: "Bulgaria", <br> &ensp; postCode: "1000" <br> } | name -> Sofia <br> area -> 492 <br> population -> 1238438 <br> country -> Bulgaria <br> postCode -> 1000 |
| { <br> &ensp; name: "Plovdiv", <br> &ensp; area: 389, <br> &ensp; population: 1162358, <br> &ensp; country: "Bulgaria", <br> &ensp; postCode: "4000" <br> } | name -> Plovdiv <br> area -> 389 <br> population -> 1162358 <br> country -> Bulgaria <br> postCode -> 4000 |

### Problem 3.	City Taxes

This task is an extension of Problem 1, you may use your solution from that task as a base.

You will receive a city’s name (string), population (number), and treasury (number) as arguments, which you will need to set as properties of an object and return it. In addition to the input parameters, the object must have a property taxRate with an initial value of 10, and three methods for managing the city:

  +	collectTaxes() - Increase treasury by population * taxRate
  +	applyGrowth(percentage) - Increase population by given percentage
  +	applyRecession(percentage) - Decrease treasury by given percentage

Round down the values after each calculation.

Input

Your solution will receive three valid parameters. The methods that expect parameters will be tested with valid input.

Output

Return an object as described above. The methods of the object modify the object and don’t return anything.

Examples

| Input | Output |
| --- | --- |
| const city = cityTaxes('Tortuga', 7000, 15000); <br> console.log(city); | { <br> &ensp; name: 'Tortuga', <br> &ensp; population: 7000, <br> &ensp; treasury: 15000, <br> &ensp; taxRate: 10, <br> &ensp; collectTaxes: [Function: collectTaxes], <br> &ensp; applyGrowth: [Function: applyGrowth], <br> &ensp; applyRecession: [Function: applyRecession] <br> } |
| const city = cityTaxes('Tortuga', 7000, 15000); <br> city.collectTaxes(); <br> console.log(city.treasury); <br> city.applyGrowth(5); <br> console.log(city.population); | 85000 <br> 7350 |

### Problem 4.	Convert to Object

Write a function that receives a string in JSON format and converts it to an object.

Loop through all the keys and print them with their values in format: "{key}: {value}"

Examples

| Input | Output |
| --- | --- |
| '{"name": "George", "age": 40, "town": "Sofia"}' | name: George <br> age: 40 <br> town: Sofia |
| '{"name": "Peter", "age": 35, "town": "Plovdiv"}' | name: Peter <br> age: 35 <br> town: Plovdiv |

### Problem 5.	Convert to JSON

Write a function that receives a first name, last name, hair color and sets them to an object.

Convert the object to JSON string and print it.

Input is provided as 3 single strings in the order stated above.

Examples

| Input | Output |
| --- | --- |
| 'George', 'Jones', 'Brown' | {"name":"George","lastName":"Jones","hairColor":"Brown"} |
| 'Peter', 'Smith', 'Blond' | {"name":"Peter","lastName":"Smith","hairColor":"Blond"} |

### Problem 6.	Phone Book

Write a function that stores information about a person’s name and phone number. The input is an array of strings with space-separated name and number. Replace duplicate names. Print the result as shown.

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'Tim 0834212554', <br> &ensp; 'Peter 0877547887', <br> &ensp; 'Bill 0896543112', <br> &ensp; 'Tim 0876566344' <br> ] | Tim -> 0876566344 <br> Peter -> 0877547887 <br> Bill -> 0896543112 |
| [ <br> &ensp; 'George 0552554', <br> &ensp; 'Peter 087587', <br> &ensp; 'George 0453112', <br> &ensp; 'Bill 0845344' <br> ] | George -> 0453112 <br> Peter -> 087587 <br> Bill -> 0845344 |

### Problem 7.	Meetings

Write a function that manages meeting appointments. The input comes as an array of strings. Each string contains a weekday and person’s name. For each successful meeting, print a message. If you receive the same weekday twice, the meeting cannot be scheduled so print a conflicting message. In the end, print a list of all successful meetings. 

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'Monday Peter', <br> &ensp; 'Wednesday Bill', <br> &ensp; 'Monday Tim', <br> &ensp; 'Friday Tim' <br> ] | Scheduled for Monday <br> Scheduled for Wednesday <br> Conflict on Monday! <br> Scheduled for Friday <br> Monday -> Peter <br> Wednesday -> Bill <br> Friday -> Tim |
| [ <br> &ensp; 'Friday Bob', <br> &ensp; 'Saturday Ted', <br> &ensp; 'Monday Bill', <br> &ensp; 'Monday John', <br> &ensp; 'Wednesday George' <br> ] | Scheduled for Friday <br> Scheduled for Saturday <br> Scheduled for Monday <br> Conflict on Monday! <br> Scheduled for Wednesday <br> Friday -> Bob <br> Saturday -> Ted <br> Monday -> Bill <br> Wednesday -> George |

### Problem 8.	Address Book

Write a function that stores information about a person’s name and his address. The input comes as an array of strings. Each string contains the name and the address separated by a colon. If you receive the same name twice just replace the address. In the end, print the full list, sorted alphabetically by the person’s name.

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'Tim:Doe Crossing', <br> &ensp; 'Bill:Nelson Place', <br> &ensp; 'Peter:Carlyle Ave', <br> &ensp; 'Bill:Ornery Rd' <br> ] | Bill -> Ornery Rd <br> Peter -> Carlyle Ave <br> Tim -> Doe Crossing |
| [ <br> &ensp; 'Bob:Huxley Rd', <br> &ensp; 'John:Milwaukee Crossing', <br> &ensp; 'Peter:Fordem Ave', <br> &ensp; 'Bob:Redwing Ave', <br> &ensp; 'George:Mesta Crossing', <br> &ensp; 'Ted:Gateway Way', <br> &ensp; 'Bill:Gateway Way', <br> &ensp; 'John:Grover Rd', <br> &ensp; 'Peter:Huxley Rd', <br> &ensp; 'Jeff:Gateway Way', <br> &ensp; 'Jeff:Huxley Rd' <br> ] | Bill -> Gateway Way <br> Bob -> Redwing Ave <br> George -> Mesta Crossing <br> Jeff -> Huxley Rd <br> John -> Grover Rd <br> Peter -> Huxley Rd <br> Ted -> Gateway Way |

### Problem 9.	Cats

Write a function that receives array of strings in the following format '{cat name} {age}'.

Create a Cat class that receives in the constructor the name and the age parsed from the input. 

It should also have a method named "meow" that will print "{cat name}, age {age} says Meow" on the console.

For each of the strings provided, you must create a cat object and invoke the .meow () method.

Examples

| Input | Output |
| --- | --- |
| ['Mellow 2', 'Tom 5'] | Mellow, age 2 says Meow <br> Tom, age 5 says Meow |
| ['Candy 1', 'Poppy 3', 'Nyx 2'] | Candy, age 1 says Meow <br> Poppy, age 3 says Meow <br> Nyx, age 2 says Meow |

### Problem 10.	Songs

Define a class Song, which holds the following information about songs: typeList, name, and time.

You will receive the input as an array.

The first element n will be the number of songs. Next n elements will be the songs data in the following format: "{typeList}\_{name}\_{time}", and the last element will be typeList / "all".

Print only the names of the songs, which have the same typeList (obtained as the last parameter). If the value of the last element is "all", print the names of all the songs.

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 3, <br> &ensp; 'favourite_DownTown_3:14', <br> &ensp; 'favourite_Kiss_4:16', <br> &ensp; 'favourite_Smooth Criminal_4:01', <br> &ensp; 'favourite' <br> ] | DownTown <br> Kiss <br> Smooth Criminal |
| [ <br> &ensp; 4, <br> &ensp; 'favourite_DownTown_3:14', <br> &ensp; 'listenLater_Andalouse_3:24', <br> &ensp; 'favourite_In To The Night_3:58', <br> &ensp; 'favourite_Live It Up_3:48', <br> &ensp; 'listenLater' <br> ] | Andalouse |
| [ <br> &ensp; 2, <br> &ensp; 'like_Replay_3:15', <br> &ensp; 'ban_Photoshop_3:48', <br> &ensp; 'all' <br> ] | Replay <br> Photoshop |