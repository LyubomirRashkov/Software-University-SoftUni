## PROBLEMS DESCRIPTION - OBJECTS AND CLASSES (More Exercises)


### Problem 1.	Class Storage

Create a class Storage. It should have the following properties, while the constructor should only receive a capacity:

  +	capacity – a number that decreases when adding a given quantity of products to storage
  +	storage – list of products (object). Each product should have:
    +	name - a string
    +	price – a number (price is for a single piece of product)
    +	quantity – a number
  +	totalCost – the sum of the cost of the products

The class should also have the following methods:

  +	addProduct – a function that receives a product and adds it to the storage
  +	getProducts – a function that returns all the products in storage in JSON format, each on a new line

Examples

| Input | Output |
| --- | --- |
| let productOne = {name: 'Cucamber', price: 1.50, quantity: 15}; <br> let productTwo = {name: 'Tomato', price: 0.90, quantity: 25}; <br> let productThree = {name: 'Bread', price: 1.10, quantity: 8}; <br> let storage = new Storage(50); <br> storage.addProduct(productOne); <br> storage.addProduct(productTwo); <br> storage.addProduct(productThree); <br> console.log(storage.getProducts()); <br> console.log(storage.capacity); <br> console.log(storage.totalCost); | {"name":"Cucamber","price":1.5,"quantity":15} <br> {"name":"Tomato","price":0.9,"quantity":25} <br> {"name":"Bread","price":1.1,"quantity":8} <br> 2 <br> 53.8 |
| let productOne = {name: 'Tomato', price: 0.90, quantity: 19}; <br> let productTwo = {name: 'Potato', price: 1.10, quantity: 10}; <br> let storage = new Storage(30); <br> storage.addProduct(productOne); <br> storage.addProduct(productTwo); <br> console.log(storage.totalCost); | 28.1 |

### Problem 2.	Catalogue

You have to create a sorted catalog of store products. You will be given the products’ names and prices. You need to order them in alphabetical order. 

The input comes as an array of strings. Each element holds info about a product in the following format: "{productName} : {productPrice}"

The product’s name will be a string, which will always start with a capital letter, and the price will be a number. You can safely assume there will be NO duplicate product input. The comparison for alphabetical order is case-insensitive.

As output, you must print all the products in a specified format. They must be ordered exactly as specified above. The products must be divided into groups, by the initial of their name. The group's initial should be printed, and after that, the products should be printed with 2 spaces before their names.

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'Appricot : 20.4', <br> &ensp; 'Fridge : 1500', <br> &ensp; 'TV : 1499', <br> &ensp; 'Deodorant : 10', <br> &ensp; 'Boiler : 300', <br> &ensp; 'Apple : 1.25', <br> &ensp; 'Anti-Bug Spray : 15', <br> &ensp; 'T-Shirt : 10' <br> ] | A <br> &ensp; Anti-Bug Spray: 15 <br> &ensp; Apple: 1.25 <br> &ensp; Appricot: 20.4 <br> B <br> &ensp; Boiler: 300 <br> D <br> &ensp; Deodorant: 10 <br> F <br> &ensp; Fridge: 1500 <br> T <br> &ensp; T-Shirt: 10 <br> &ensp; TV: 1499 |
| [ <br> &ensp; 'Omlet : 5.4', <br> &ensp; 'Shirt : 15', <br> &ensp; 'Cake : 59' <br> ] | C <br> &ensp; Cake: 59 <br> O <br> &ensp; Omlet: 5.4 <br> S <br> &ensp; Shirt: 15 |

### Problem 3.	Class Laptop

Create a class Laptop that has the following properties:

  +	info – object that contains:
    +	producer – string
    +	age – number
    +	brand – string
  +	isOn – boolean (false by default)
  +	turnOn – a function that sets the isOn variable to true
  +	turnOff – a function that sets the isOn variable to false
  +	showInfo – a function that returns the producer, age, and brand as JSON
  +	quality – number (every time the laptop is turned on/off the quality decreases by 1)
  +	getter price – number (800 – {age * 2} + (quality * 0.5)) 

The constructor should receive the info as an object and the quality.

Examples

| Input | Output |
| --- | --- |
| let info = {producer: "Dell", age: 2, brand: "XPS"} <br> let laptop = new Laptop(info, 10) <br> laptop.turnOn() <br> console.log(laptop.showInfo()) <br> laptop.turnOff() <br> console.log(laptop.quality) <br> laptop.turnOn() <br> console.log(laptop.isOn) <br> console.log(laptop.price) | {"producer":"Dell","age":2,"brand":"XPS"} <br> 8 <br> true <br> 799.5 |
| let info = {producer: "Lenovo", age: 1, brand: "Legion"} <br> let laptop = new Laptop(info, 10) <br> laptop.turnOn() <br> console.log(laptop.showInfo()) <br> laptop.turnOff() <br> laptop.turnOn() <br> laptop.turnOff() <br> console.log(laptop.isOn) | {"producer":"Lenovo","age":1,"brand":"Legion"} <br> false |

### Problem 4.	Flight Schedule

You will receive an array with arrays.

The first array (at index 0) will hold all flights on a specific sector in the airport. The second array (at index 1) will contain newly changed statuses of some of the flights at this airport. The third array (at index 2) will have a single string, which will be the flight status you need to check. When you put all flights into an object and change the statuses depends on the new information on the second array. You must print all flights with the given status from the last array.

  +	If the value of the string obtained from the third array is "Ready to fly":
    +	then you must print flights that have not changed their status in the second array 
    +	and automatically change the status to "Ready to fly"
  +	Otherwise, print only flights that have changed their status.

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; [ <br> &ensp; &ensp; 'WN269 Delaware', <br> &ensp; &ensp; 'FL2269 Oregon', <br> &ensp; &ensp; 'WN498 Las Vegas', <br> &ensp; &ensp; 'WN3145 Ohio', <br> &ensp; &ensp; 'WN612 Alabama', <br> &ensp; &ensp; 'WN4010 New York', <br> &ensp; &ensp; 'WN1173 California', <br> &ensp; &ensp; 'DL2120 Texas', <br> &ensp; &ensp; 'KL5744 Illinois', <br> &ensp; &ensp; 'WN678 Pennsylvania' <br> &ensp; ], <br> &ensp; [ <br> &ensp; &ensp; 'DL2120 Cancelled', <br> &ensp; &ensp; 'WN612 Cancelled', <br> &ensp; &ensp; 'WN1173 Cancelled', <br> &ensp; &ensp; 'SK430 Cancelled' <br> &ensp; ], <br> &ensp;	['Cancelled'] <br> ] | { Destination: 'Alabama', Status: 'Cancelled' } <br> { Destination: 'California', Status: 'Cancelled' } <br> { Destination: 'Texas', Status: 'Cancelled' } |
| [ <br> &ensp; [ <br> &ensp; &ensp; 'WN269 Delaware', <br> &ensp; &ensp; 'FL2269 Oregon', <br> &ensp; &ensp; 'WN498 Las Vegas', <br> &ensp; &ensp; 'WN3145 Ohio', <br> &ensp; &ensp; 'WN612 Alabama', <br> &ensp; &ensp; 'WN4010 New York', <br> &ensp; &ensp; 'WN1173 California', <br> &ensp; &ensp; 'DL2120 Texas', <br> &ensp; &ensp; 'KL5744 Illinois', <br> &ensp; &ensp; 'WN678 Pennsylvania' <br> &ensp; ], <br> &ensp; [ <br> &ensp; &ensp; 'DL2120 Cancelled', <br> &ensp; &ensp; 'WN612 Cancelled', <br> &ensp; &ensp; 'WN1173 Cancelled', <br> &ensp; &ensp; 'SK330 Cancelled' <br> &ensp; ], <br> &ensp; ['Ready to fly'] <br> ] | { Destination: 'Delaware', Status: 'Ready to fly' } <br> { Destination: 'Oregon', Status: 'Ready to fly' } <br> { Destination: 'Las Vegas', Status: 'Ready to fly' } <br> { Destination: 'Ohio', Status: 'Ready to fly' } <br> { Destination: 'New York', Status: 'Ready to fly' } <br> { Destination: 'Illinois', Status: 'Ready to fly' } <br> { Destination: 'Pennsylvania', Status: 'Ready to fly' } |

### Problem 5.	School Register

In this problem, you have to arrange all students by grade. You as the secretary of the school principal will process students and store them into a school register before the new school year hits. As a draft, you have a list of all the students from last year but mixed. Keep in mind that if a student has a lower score than 3, he does not go into the next class. As a result of your work, you have to print the entire school register sorted in ascending order by grade already filled with all the students from last year in the format: 

'{nextGrade} Grade

List of students: {All students in that grade}

Average annual score from last year: {average annual score on the entire class from last year}'

And empty row {console.log}

The input will be an array with strings, each containing a student's name, last year's grade, and an annual score. The average annual score from last year should be formatted to the second decimal point.

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; "Student name: Mark, Grade: 8, Graduated with an average score: 4.75", <br> &ensp; "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66", <br> &ensp; "Student name: George, Grade: 8, Graduated with an average score: 2.83", <br> &ensp; "Student name: Steven, Grade: 10, Graduated with an average score: 4.20", <br> &ensp; "Student name: Joey, Grade: 9, Graduated with an average score: 4.90", <br> &ensp; "Student name: Angus, Grade: 11, Graduated with an average score: 2.90", <br> &ensp; "Student name: Bob, Grade: 11, Graduated with an average score: 5.15", <br> &ensp; "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95", <br> &ensp; "Student name: Bill, Grade: 9, Graduated with an average score: 6.00", <br> &ensp; "Student name: Philip, Grade: 10, Graduated with an average score: 5.05", <br> &ensp; "Student name: Peter, Grade: 11, Graduated with an average score: 4.88", <br> &ensp; "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00" <br> ] | 9 Grade <br> List of students: Mark, Daryl <br> Average annual score from last year: 5.35 <br> <br> 10 Grade <br> List of students: Ethan, Joey, Bill <br> Average annual score from last year: 5.52 <br> <br> 11 Grade <br> List of students: Steven, Philip, Gavin <br> Average annual score from last year: 4.42 <br> <br> 12 Grade <br> List of students: Bob, Peter <br> Average annual score from last year: 5.02 |
| [ <br> &ensp; 'Student name: George, Grade: 5, Graduated with an average score: 2.75', <br> &ensp; 'Student name: Alex, Grade: 9, Graduated with an average score: 3.66', <br> &ensp; 'Student name: Peter, Grade: 8, Graduated with an average score: 2.83', <br> &ensp; 'Student name: Boby, Grade: 5, Graduated with an average score: 4.20', <br> &ensp; 'Student name: John, Grade: 9, Graduated with an average score: 2.90', <br> &ensp; 'Student name: Steven, Grade: 2, Graduated with an average score: 4.90', <br> &ensp; 'Student name: Darsy, Grade: 1, Graduated with an average score: 5.15' <br> ] | 2 Grade <br> List of students: Darsy <br> Average annual score from last year: 5.15 <br> <br> 3 Grade <br> List of students: Steven <br> Average annual score from last year: 4.90 <br> <br> 6 Grade <br> List of students: Boby <br> Average annual score from last year: 4.20 <br> <br> 10 Grade <br> List of students: Alex <br> Average annual score from last year: 3.66 |

### Problem 6.	Browser History

As input, you will receive two parameters: an object and a string array.

The object will be in format: {Browser Name}:{Name of the browser}, Open tabs:[…], Recently Closed: […], Browser Logs: […]. Your task is to fill in the object based on the actions we will get in the array of strings.

You can open any site in the world as many times as you like; if you do that add it to the open tabs.

You can close only these tabs you have opened already! If the current action contains a valid opened site, you should remove it from "Open Tabs" and put it into "Recently closed", otherwise don't do anything!

Browser Logs will hold every single Valid action, which you did (Open and Close).

There is a special case in which you can get an action that says: "Clear History and Cache". That means you should empty the whole object.

In the end, print the object in the format:

{Browser name}

Open Tabs: {[…]} // Joined by comma and space

Recently Closed: {[…]} // Joined by comma and space

Browser Logs: {[…]} // Joined by comma and space

Examples

| Input | Output |
| --- | --- |
| { <br> &ensp; "Browser Name":"Google Chrome", <br> &ensp; "Open Tabs":["Facebook","YouTube","Google Translate"], <br> &ensp; "Recently Closed":["Yahoo","Gmail"], <br> &ensp; "Browser Logs":["Open YouTube","Open Yahoo","Open Google Translate","Close Yahoo","Open Gmail","Close Gmail","Open Facebook"] <br> }, <br> ["Close Facebook", "Open StackOverFlow", "Open Google"] | Google Chrome <br> Open Tabs: YouTube, Google Translate, StackOverFlow, Google <br> Recently Closed: Yahoo, Gmail, Facebook <br> Browser Logs: Open YouTube, Open Yahoo, Open Google Translate, Close Yahoo, Open Gmail, Close Gmail, Open Facebook, Close Facebook, Open StackOverFlow, Open Google |
| { <br> &ensp; "Browser Name":"Mozilla Firefox", <br> &ensp; "Open Tabs":["YouTube"], <br> &ensp; "Recently Closed":["Gmail", "Dropbox"], <br> &ensp; "Browser Logs":["Open Gmail", "Close Gmail", "Open Dropbox", "Open YouTube", "Close Dropbox"] <br> }, <br> ["Open Wikipedia", "Clear History and Cache", "Open Twitter"] | Mozilla Firefox <br> Open Tabs: Twitter <br> Recently Closed: <br> Browser Logs: Open Twitter |

### Problem 7.	Sequences

You are tasked with storing sequences of numbers. You will receive an array of strings; each of them will contain an unknown amount of arrays containing numbers, from which you must store only the unique arrays (duplicate arrays should be discarded). An array is considered the same (NOT unique) if it contains the same numbers as another array, regardless of their order. 

After storing all arrays, your program should print them back in ascending order based on their length, if two arrays have the same length, they should be printed in order of being received from the input. Each array should be printed in descending order in the format "[a1, a2, a3,… an]".

The input comes as an array of strings where each entry is a JSON representing an array of numbers.

The output should be printed on the console - each array printed on a new line in the format "[a1, a2, a3,… an]", following the above-mentioned ordering.

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; "[-3, -2, -1, 0, 1, 2, 3, 4]", <br> &ensp; "[10, 1, -17, 0, 2, 13]", <br> &ensp; "[4, -3, 3, -2, 2, -1, 1, 0]" <br> ] | [13, 10, 2, 1, 0, -17] <br> [4, 3, 2, 1, 0, -1, -2, -3] |
| [ <br> &ensp; "[7.14, 7.180, 7.339, 80.099]", <br> &ensp; "[7.339, 80.0990, 7.140000, 7.18]", <br> &ensp; "[7.339, 7.180, 7.14, 80.099]" <br> ] | [80.099, 7.339, 7.18, 7.14] |

### Problem 8.	Garage

Write a function that stores cars in garages. You will be given an array of strings. Each string will contain a number of a garage and info about a car. You have to store the car (with its info) in the given garage. The info about the car will be in the format: "{key1}: {value1}, {key2}: {value2}…"

If the garage does not exist, create it. The cars will always be unique. At the end print the result in the format:

"Garage № {number}

--- {carOneKeyOne} - {carOneValueOne}, {carOneKeyTwo} - {carOneValueTwo}…

--- {the same for the next car}

Garage № {number} …"

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; '1 - color: blue, fuel type: diesel', <br> &ensp; '1 - color: red, manufacture: Audi', <br> &ensp; '2 - fuel type: petrol', <br> &ensp; '4 - color: dark blue, fuel type: diesel, manufacture: Fiat' <br> ] | Garage № 1 <br> --- color - blue, fuel type - diesel <br> --- color - red, manufacture - Audi <br> Garage № 2 <br> --- fuel type - petrol <br> Garage № 4 <br> --- color - dark blue, fuel type - diesel, manufacture - Fiat |
| [ <br> &ensp; '1 - color: green, fuel type: petrol', <br> &ensp; '1 - color: dark red, manufacture: WV', <br> &ensp; '2 - fuel type: diesel', <br> &ensp; '3 - color: dark blue, fuel type: petrol' <br> ] | Garage № 1 <br> --- color - green, fuel type - petrol <br> --- color - dark red, manufacture - WV <br> Garage № 2 <br> --- fuel type - diesel <br> Garage № 3 <br> --- color - dark blue, fuel type - petrol |

### Problem 9.	Armies

Write a function that stores information about an army leader and his armies. The input will be an array of strings. The strings can be in some of the following formats:

  + "{leader} arrives" – add the leader (no army)
  + "{leader}: {army name}, {army count}" – add the army with its count to the leader (if he exists)
  + "{army name} + {army count}" – if the army exists somewhere add the count
  + "{leader} defeated" – delete the leader and his army (if he exists)

When finished reading the input sort the leaders by total army count in descending. Then each army should be sorted by count in descending.

Output

Print in the following format:

"{leader one name}: {total army count}

\>\>\> {armyOne name} - {army count}

\>\>\> {armyTwo name} - {army count}

…

{leader two name}: {total army count}

…"

Constrains

  +	The new leaders will always be unique
  +	When adding a new army to the leader, the army will be unique

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'Rick Burr arrives', <br> &ensp; 'Fergus: Wexamp, 30245', <br> &ensp; 'Rick Burr: Juard, 50000', <br> &ensp; 'Findlay arrives', <br> &ensp; 'Findlay: Britox, 34540', <br> &ensp; 'Wexamp + 6000', <br> &ensp; 'Juard + 1350', <br> &ensp; 'Britox + 4500', <br> &ensp; 'Porter arrives', <br> &ensp; 'Porter: Legion, 55000', <br> &ensp; 'Legion + 302', <br> &ensp; 'Rick Burr defeated', <br> &ensp; 'Porter: Retix, 3205' <br> ] | Porter: 58507 <br> >>> Legion - 55302 <br> >>> Retix - 3205 <br> Findlay: 39040 <br> >>> Britox - 39040 |
| [ <br> &ensp; 'Rick Burr arrives', <br> &ensp; 'Findlay arrives', <br> &ensp; 'Rick Burr: Juard, 1500', <br> &ensp; 'Wexamp arrives', <br> &ensp; 'Findlay: Wexamp, 34540', <br> &ensp; 'Wexamp + 340', <br> &ensp; 'Wexamp: Britox, 1155', <br> &ensp; 'Wexamp: Juard, 43423' <br> ] | Wexamp: 44578 <br> >>> Juard - 43423 <br> >>> Britox - 1155 <br> Findlay: 34880 <br> >>> Wexamp - 34880 <br> Rick Burr: 1500 <br> >>> Juard - 1500 |

### Problem 10.	Comments

Write a function that stores information about users and their comments on a website. You have to store the users, the comments as an object with title and content, and the article that the comment is about. The user can only comment, when he is on the list of users and the article is in the list of articles. 

Input

The input comes as an array of strings. The strings will be in the format:

  + "user {username}" – add the user to the list of users
  + "article {article name}" – add the article to the article list
  + "{username} posts on {article name}: {comment title}, {comment content}" – save the info

At the end sort the articles by a count of comments in descending and print the users with their comments ordered by usernames in ascending.

Output

Print the result in the following format:

"Comments on {article1 name}

--- From user {username1}: {comment title} - {comment content}

--- From user {username2}: …

Comments on {article2 name}

…"

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'user aUser123', <br> &ensp; 'someUser posts on someArticle: NoTitle, stupidComment', <br> &ensp; 'article Books', <br> &ensp; 'article Movies', <br> &ensp; 'article Shopping', <br> &ensp; 'user someUser', <br> &ensp; 'user uSeR4', <br> &ensp; 'user lastUser', <br> &ensp; 'uSeR4 posts on Books: I like books, I do really like them', <br> &ensp; 'uSeR4 posts on Movies: I also like movies, I really do', <br> &ensp; 'someUser posts on Shopping: title, I go shopping every day', <br> &ensp; 'someUser posts on Movies: Like, I also like movies very much' <br> ] | Comments on Movies <br> --- From user someUser: Like - I also like movies very much <br> --- From user uSeR4: I also like movies - I really do <br> Comments on Books <br> --- From user uSeR4: I like books - I do really like them <br> Comments on Shopping <br> --- From user someUser: title - I go shopping every day |
| [ <br> &ensp; 'user Mark', <br> &ensp; 'Mark posts on someArticle: NoTitle, stupidComment', <br> &ensp; 'article Bobby', <br> &ensp; 'article Steven', <br> &ensp; 'user Liam', <br> &ensp; 'user Henry', <br> &ensp; 'Mark posts on Bobby: Is, I do really like them', <br> &ensp; 'Mark posts on Steven: title, Run', <br> &ensp; 'someUser posts on Movies: Like' <br> ] | Comments on Bobby <br> --- From user Mark: Is - I do really like them <br> Comments on Steven <br> --- From user Mark: title - Run |

### Problem 11.	Book Shelf

Write a function that stores information about shelves and the books on the shelves. Each shelf has an Id and a genre of books that can be on it. Each book has a title, an author, and a genre. The input comes as an array of strings. They will be in the format:

  + "{shelf id} -> {shelf genre}" – create a shelf if the id is not taken.
  + "{book title}: {book author}, {book genre}" – if a shelf with that genre exists, add the book to the shelf.

After finishing reading input, sort the shelves by a count of books in it in descending. For each shelf sort the books by title in ascending. Then print them in the following format:

"{shelfOne id} {shelf genre}: {books count}

--> {bookOne title}: {bookOne author}

--> {bookTwo title}: {bookTwo author}

…

{shelfTwo id} {shelf genre}: {books count}

…"

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; '1 -> history', <br> &ensp; '1 -> action', <br> &ensp; 'Death in Time: Criss Bell, mystery', <br> &ensp; '2 -> mystery', <br> &ensp; '3 -> sci-fi', <br> &ensp; 'Child of Silver: Bruce Rich, mystery', <br> &ensp; 'Hurting Secrets: Dustin Bolt, action', <br> &ensp; 'Future of Dawn: Aiden Rose, sci-fi', <br> &ensp; 'Lions and Rats: Gabe Roads, history', <br> &ensp; '2 -> romance', <br> &ensp; 'Effect of the Void: Shay B, romance', <br> &ensp; 'Losing Dreams: Gail Starr, sci-fi', <br> &ensp; 'Name of Earth: Jo Bell, sci-fi', <br> &ensp; 'Pilots of Stone: Brook Jay, history' <br> ] | 3 sci-fi: 3 <br> --> Future of Dawn: Aiden Rose <br> --> Losing Dreams: Gail Starr <br> --> Name of Earth: Jo Bell <br> 1 history: 2 <br> --> Lions and Rats: Gabe Roads <br> --> Pilots of Stone: Brook Jay <br> 2 mystery: 1 <br> --> Child of Silver: Bruce Rich |
| [ <br> &ensp; '1 -> mystery', <br> &ensp; '2 -> sci-fi', <br> &ensp; 'Child of Silver: Bruce Rich, mystery', <br> &ensp; 'Lions and Rats: Gabe Roads, history', <br> &ensp; 'Effect of the Void: Shay B, romance', <br> &ensp; 'Losing Dreams: Gail Starr, sci-fi', <br> &ensp; 'Name of Earth: Jo Bell, sci-fi' <br> ] | 2 sci-fi: 2 <br> --> Losing Dreams: Gail Starr <br> --> Name of Earth: Jo Bell <br> 1 mystery: 1 <br> --> Child of Silver: Bruce Rich |

### Problem 12.	SoftUni Students

Write a function that stores the students that signed up for different courses at SoftUni. For each course, you have to store the name, the capacity, and the students that are in it. For each student store the username, the email, and their credits. The input will come as an array of strings. The strings will be in some of the following formats:

  + "{course name}: {capacity}" – add the course with that capacity. If the course exists, add the capacity to the existing one
  + "{username}[{credits count}] with email {email} joins {course name}" – add the student if the course exists (each student can be in multiple courses) and if there are places left (count of students are less than the capacity)

Finally, you should sort the courses by the count of students in descending. Each course should have its students sorted by credits in descending.

Output

Print the result in the format:

"{course one}: {places left} places left

--- {credits}: {username one}, {email one}

…"

Examples

| Input | Output |
| --- | --- |
| [ <br> &ensp; 'JavaBasics: 2', <br> &ensp; 'user1[25] with email user1@user.com joins C#Basics', <br> &ensp; 'C#Advanced: 3', <br> &ensp; 'JSCore: 4', <br> &ensp; 'user2[30] with email user2@user.com joins C#Basics', <br> &ensp; 'user13[50] with email user13@user.com joins JSCore', <br> &ensp; 'user1[25] with email user1@user.com joins JSCore', <br> &ensp; 'user8[18] with email user8@user.com joins C#Advanced', <br> &ensp; 'user6[85] with email user6@user.com joins JSCore', <br> &ensp; 'JSCore: 2', <br> &ensp; 'user11[3] with email user11@user.com joins JavaBasics', <br> &ensp; 'user45[105] with email user45@user.com joins JSCore', <br> &ensp; 'user007[20] with email user007@user.com joins JSCore', <br> &ensp; 'user700[29] with email user700@user.com joins JSCore', <br> &ensp; 'user900[88] with email user900@user.com joins JSCore' <br> ] | JSCore: 0 places left <br> --- 105: user45, user45@user.com <br> --- 85: user6, user6@user.com <br> --- 50: user13, user13@user.com <br> --- 29: user700, user700@user.com <br> --- 25: user1, user1@user.com <br> --- 20: user007, user007@user.com <br> JavaBasics: 1 places left <br> --- 3: user11, user11@user.com <br> C#Advanced: 2 places left <br> --- 18: user8, user8@user.com |
| [ <br> &ensp; 'JavaBasics: 15', <br> &ensp; 'user1[26] with email user1@user.com joins JavaBasics', <br> &ensp; 'user2[36] with email user11@user.com joins JavaBasics', <br> &ensp; 'JavaBasics: 5', <br> &ensp; 'C#Advanced: 5', <br> &ensp; 'user1[26] with email user1@user.com joins C#Advanced', <br> &ensp; 'user2[36] with email user11@user.com joins C#Advanced', <br> &ensp; 'user3[6] with email user3@user.com joins C#Advanced', <br> &ensp; 'C#Advanced: 1', <br> &ensp; 'JSCore: 8', <br> &ensp; 'user23[62] with email user23@user.com joins JSCore' <br> ] | C#Advanced: 3 places left <br> --- 36: user2, user11@user.com <br> --- 26: user1, user1@user.com <br> --- 6: user3, user3@user.com <br> JavaBasics: 18 places left <br> --- 36: user2, user11@user.com <br> --- 26: user1, user1@user.com <br> JSCore: 7 places left <br> --- 62: user23, user23@user.com |