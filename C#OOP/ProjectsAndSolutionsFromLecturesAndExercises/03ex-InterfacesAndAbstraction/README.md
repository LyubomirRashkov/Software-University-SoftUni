## PROBLEMS DESCRIPTION - INTERFACES AND ABSTRACTION (Exercise)


### Problem 1.	Define an Interface IPerson
NOTE: You need a public StartUp class with the namespace PersonInfo.

Define an interface IPerson with properties for Name and Age. Define a class Citizen that implements IPerson and has a constructor which takes a string name and an int age.

Try to create a new Person like this:

| string name = Console.ReadLine(); <br> int age = int.Parse(Console.ReadLine()); <br> IPerson person = new Citizen(name, age); <br> Console.WriteLine(person.Name); <br> Console.WriteLine(person.Age); |
|:--- |

Examples

| Input     | Output |
| --------- | -----|
| Peter <br> 25 | Peter <br> 25 |

### Problem 2.	Multiple Implementation
NOTE: You need a public StartUp class with the namespace PersonInfo.

Using the code from the previous task, define an interface IIdentifiable with a string property Id and an interface IBirthable with a string property Birthdate and implement them in the Citizen class. Rewrite the Citizen constructor to accept the new parameters.

Test your class like this:

| string name = Console.ReadLine(); <br> int age = int.Parse(Console.ReadLine()); <br> string id = Console.ReadLine(); <br> string birthdate = Console.ReadLine(); <br> IIdentifiable identifiable = new Citizen(name, age,id, birthdate); <br> IBirthable birthable = new Citizen(name, age, id, birthdate); <br> Console.WriteLine(identifiable.Id); <br> Console.WriteLine(birthable.Birthdate); |
|:--- |

Examples

| Input     | Output |
| --------- | -----|
| Peter <br> 25 <br> 9105152287 <br> 15/05/1991 | 9105152287 <br> 15/05/1991 |

### Problem 3.	Telephony
You have a business - manufacturing phones. However, you have no software developers, so you call some friends of yours and ask them to help you create a phone software. They have already agreed and you started working on the project. The project consists of two main models – Smartphone and StationaryPhone. Each of your smartphones should have functionalities of calling other phones and browsing in the world wide web. The StationaryPhone can only call other phones.

These friends of yours though are very busy, so you decide to write the code on your own. Here is the mandatory assignment:

You should have a model - Smartphone and two separate functionalities, which your Smartphone has - to call other phones and to browse in the world wide web. You should also have a model – StationaryPhone and one fuctionality which your StationaryPhone has – to call other phones. You should end up with two classes and two interfaces.

Input

The input comes from the console. It will hold two lines:
  +	First line: phone numbers to call (string), separated by spaces.
  +	Second line: sites to visit (string), separated by spaces.

Output
  +	First call all numbers in the order of input then browse all sites in order of input
  +	The functionality of calling phones is printing on the console the number which is being called
  +	If the number is 10 digits long, you are making a call from your smartphone and you print: _"Calling... {number}"_
  +	If the number is 7 digits long, you are making a call from your stationary phone and you print: _"Dialing... {number}"_
  +	The functionality of the browser should print on the console the site in format: _"Browsing: {site}!"_
  +	If there is a number in the input of the URLs, print: _"Invalid URL!"_ and continue printing the rest of the URLs.
  +	If there is a character different from a digit in a number, print: _"Invalid number!"_ and continue to the next number.

Constraints
  +	Each site's URL should consist only of letters and symbols (No digits are allowed in the URL address)
  +	The phone numbers will always be 7 or 10 digits long

Examples

| Input     | Output |
| --------- | -----|
| 0882134215 0882134333 0899213421 0558123 3333123 <br> http:&#xfeff;//softuni.bg http:&#xfeff;//y0utube.com | Calling... 0882134215 <br> Calling... 0882134333 <br> Calling... 0899213421 <br> Dialing... 0558123 <br> Dialing... 3333123 <br> Browsing: http:&#xfeff;//softuni.bg! <br> Invalid URL! |

### Problem 4.	Border Control
It’s the future, you’re the ruler of a totalitarian dystopian society inhabited by citizens and robots, since you’re afraid of rebellions you decide to implement strict control of who enters your city. Your soldiers check the Ids of everyone who enters and leaves.

You will receive an unknown amount of lines from the console until the command _"End"_ is received, on each line there will be a piece of information for either a citizen or a robot who tries to enter your city in the format: _"{name} {age} {id}"_ for citizens and _"{model} {id}"_ for robots. After the end command on the next line you will receive a single number representing the last digits of fake ids, all citizens or robots whose Id ends with the specified digits must be detained.

The output of your program should consist of all detained Ids each on a separate line in the order of input.

Input

The input comes from the console. Every commands’ parameters before the command _"End"_ will be separated by a single space.

Examples

| Input     | Output |
| --------- | -----|
| Peter 22 9010101122 <br> MK-13 558833251 <br> MK-12 33283122 <br> End <br> 122 | 9010101122 <br> 33283122 |
| Teo 31 7801211340 <br> Peter 29 8007181534 <br> IV-228 999999 <br> Sam 54 3401018380 <br> KKK-666 80808080 <br> End | 7801211340 |

### Problem 5.	Birthday Celebrations
It is a well known fact that people celebrate birthdays, it is also known that some people also celebrate their pets’ birthdays. Extend the program from your last task to add birthdates to citizens and include a class Pet, pets have a name and a birthdate. Encompass repeated functionality into interfaces and implement them in your classes. 

You will receive from the console an unknown amount of lines. Until the command _"End"_ is received, each line will contain information in one of the following formats _"Citizen \<name\> \<age\> \<id\> \<birthdate\>"_ for Citizen, _"Robot \<model\> \<id\>"_ for Robot or _"Pet \<name\> \<birthdate\>"_ for Pet. After the _"End"_ command on the next line you will receive a single number representing a specific year, your task is to print all birthdates (of both Citizen and Pet) in that year in the format day/month/year in the order of input.

Examples

| Input     | Output |
| --------- | -----|
| Citizen Peter 22 9010101122 10/10/1990 <br> Pet Sharo 13/11/2005 <br> Robot MK-13 558833251 <br> End <br> 1990 | 10/10/1990 |
| Citizen Stam 16 0041018380 01/01/2000 <br> Robot MK-10 12345678 <br> Robot PP-09 00000001 <br> Pet Topcho 24/12/2000 <br> Pet Rex 12/06/2002 <br> End <br> 2000 | 01/01/2000 <br> 24/12/2000 |

### Problem 6.	Food Shortage
Your totalitarian dystopian society suffers a shortage of food, so many rebels appear. Extend the code from your previous task with new functionality to solve this task.

Define a class Rebel which has a name, age and group (string), names are unique - there will never be 2 Rebels/Citizens or a Rebel and Citizen with the same name. 

Define an interface IBuyer which defines a method BuyFood() and an integer property Food. Implement the IBuyer interface in the Citizen and Rebel class, both Rebels and Citizens start with 0 food, when a Rebel buys food his Food increases by 5, when a Citizen buys food his Food increases by 10.

On the first line of the input you will receive an integer N - the number of people, on each of the next N lines you will receive information in one of the following formats _"\<name\> \<age\> \<id\> \<birthdate\>"_ for a Citizen or _"\<name\> \<age\>\<group\>"_ for a Rebel. After the N lines until the command _"End"_ is received, you will receive names of people who bought food, each on a new line. Note that not all names may be valid, in case of an incorrect name - nothing should happen.  

Output

The output consists of only one line on which you should print the total amount of food purchased.

Examples

| Input     | Output |
| --------- | -----|
| 2 <br> Peter 25 8904041303 04/04/1989 <br> Stan 27 WildMonkeys <br> Peter <br> George <br> Peter <br> End | 20 |
| 4 <br> Stam 23 TheSwarm <br> Ton 44 7308185527 18/08/1973 <br> George 31 Terrorists <br> Pen 27 881222212 22/12/1988 <br> John <br> Geo rge <br> John <br> Joro <br> Stam <br> Pen <br> End | 15 |

### Problem 7.	Military Elite
Create the following class hierarchy:

Soldier - general class for Soldiers, holding id, first name and last name.
  +	Private - lowest base Soldier type, holding the salary(decimal). 
     +	LieutenantGeneral - holds a set of Privates under his command.
     +	SpecialisedSoldier - general class for all specialised Soldiers - holds the corps of the Soldier. The corps can only be one of the following: Airforces or Marines.
        +	Engineer - holds a set of Repairs. A Repair holds a part name and hours worked(int).
        +	Commando - holds a set of Missions. A mission holds code name and a state (inProgress or Finished). A Mission can be finished through the method CompleteMission().
  +	Spy - holds the code number of the Spy (int).

Extract interfaces for each class. (e.g. ISoldier, IPrivate, ILieutenantGeneral, etc.) The interfaces should hold their public properties and methods (e.g. ISoldier should hold id, first name and last name). Each class should implement its respective interface. Validate the input where necessary (corps, mission state) - input should match exactly one of the required values, otherwise it should be treated as invalid. In case of invalid corps the entire line should be skipped, in case of an invalid mission state only the mission should be skipped.

You will receive from the console an unknown amount of lines containing information about soldiers until the command _"End"_ is received. The information will be in one of the following formats:
  +	Private: _"Private \<id\> \<firstName\> \<lastName\> \<salary\>"_
  +	LeutenantGeneral: _"LieutenantGeneral \<id\> \<firstName\> \<lastName\> \<salary\> \<private1Id\> \<private2Id\> … \<privateNId\>"_ where privateXId will always be an Id of a Private already received through the input.
  +	Engineer: _"Engineer \<id\> \<firstName\> \<lastName\> \<salary\> \<corps\> \<repair1Part\> \<repair1Hours\> … \<repairNPart\> \<repairNHours\>"_ where repairXPart is the name of a repaired part and repairXHours the hours it took to repair it (the two parameters will always come paired). 
  +	Commando: _"Commando \<id\> \<firstName\> \<lastName\> \<salary\> \<corps\> \<mission1CodeName\> \<mission1state\> … \<missionNCodeName\> \<missionNstate\>"_ a missions code name, description and state will always come together.
  +	Spy: _"Spy \<id\> \<firstName\> \<lastName\> \<codeNumber\>"_

Define proper constructors. Avoid code duplication through abstraction. Override ToString() in all classes to print detailed information about the object.
  +	Privates:

_Name: \<firstName\> \<lastName\> Id: \<id\> Salary: \<salary\>_
  +	Spy:

_Name: \<firstName\> \<lastName\> Id: \<id\>_

_Code Number: \<codeNumber\>_
  +	LieutenantGeneral:

_Name: \<firstName\> \<lastName\> Id: \<id\> Salary: \<salary\>_

_Privates:_

  _\<private1 ToString()\>_

  _\<private2 ToString()\>_

  _…_
  
  _\<privateN ToString()\>_
  +	Engineer:

_Name: \<firstName\> \<lastName\> Id: \<id\> Salary: \<salary\>_

_Corps: \<corps\>_

_Repairs:_

  _\<repair1 ToString()\>_
  
  _\<repair2 ToString()\>_
  
  _…_
  
  _\<repairN ToString()\>_
  +	Commando:

_Name: \<firstName\> \<lastName\> Id: \<id\> Salary: \<salary\>_

_Corps: \<corps\>_

_Missions:_

  _\<mission1 ToString()\>

  _\<mission2 ToString()\>

  _…_
  
  _\<missionN ToString()\>_
  +	Repair:

_Part Name: \<partName\> Hours Worked: \<hoursWorked\>_
  +	Mission:

_Code Name: \<codeName\> State: \<state\>_

NOTE: Salary should be printed rounded to two decimal places after the separator.

Examples

| Input     | Output |
| --------- | -----|
| Private 1 Peter Johnson 22.22 <br> Commando 13 Sam Stamov 13.1 Airforces <br> Private 222 Tony Samthon 80.08 <br> LieutenantGeneral 3 George Jorj 100 222 1 <br> End | Name: Peter Johnson Id: 1 Salary: 22.22 <br> Name: Sam Stamov Id: 13 Salary: 13.10 <br> Corps: Airforces <br> Missions: <br> Name: Tony Samthon Id: 222 Salary: 80.08 <br> Name: George Jorj Id: 3 Salary: 100.00 <br> Privates: <br> Name: Tony Samthon Id: 222 Salary: 80.08 <br> Name: Peter Johnson Id: 1 Salary: 22.22 |
| Engineer 7 Peter Johnson 12.23 Marines Boat 2 Crane 17 <br> Commando 19 George Jorj 150.15 Airforces HairyFoot finished Freedom inProgress <br> End | Name: Peter Johnson Id: 7 Salary: 12.23 <br> Corps: Marines <br> Repairs: <br> Part Name: Boat Hours Worked: 2 <br> Part Name: Crane Hours Worked: 17 <br> Name: George Jorj Id: 19 Salary: 150.15 <br> Corps: Airforces <br> Missions: <br> Code Name: Freedom State: inProgress |

### Problem 8.	Collection Hierarchy
Create 3 different string collections - AddCollection, AddRemoveCollection and MyList.

The AddCollection should have:
  +	Only a single method Add which adds an item to the end of the collection.

The AddRemoveCollection should have:
  +	An Add method - which adds an item to the start of the collection.
  +	A Remove method, which removes the last item in the collection.

The MyList collection should have:
  +	An Add method, which adds an item to the start of the collection.
  +	A Remove method, which removes the first element in the collection.
  +	A Used property, which displays the number of elements currently in the collection. 

Create interfaces, which define the collections functionality, think how to model the relations between interfaces to reuse code. Add an extra bit of functionality to the methods in the custom collections, Add methods should return the index in which the item was added, Remove methods should return the item that was removed. 

Your task is to create a single copy of your collections, after which on the first input line you will receive a random amount of strings in a single line separated by spaces - the elements you must add to each of your collections. For each of your collections write a single line in the output that holds the results of all Add operations separated by spaces (check the examples to better understand the format). On the second input line, you will receive a single number - the amount of Remove operations you have to call on each collection. In the same manner, as with the Add operations for each collection (except the AddCollection), print a line with the results of each Remove operation separated by spaces.

Input

The input comes from the console. It will hold two lines:
  +	The first line will contain a random amount of strings separated by spaces - the elements you have to Add to each of your collections.
  +	The second line will contain a single number - the amount of Remove operations.

Output

The output will consist of 5 lines:
  +	The first line contains the results of all Add operations on the AddCollection separated by spaces.
  +	The second line contains the results of all Add operations on the AddRemoveCollection separated by spaces.
  +	The third line contains the result of all Add operations on the MyList collection separated by spaces.
  +	The fourth line contains the result of all Remove operations on the AddRemoveCollection separated by spaces.
  +	The fifth line contains the result of all Remove operations on the MyList collection separated by spaces.

Constraints
  +	All collections should have a length of 100.
  +	There will never be more than 100 add operations.
  +	The number of remove operations will never be more than the amount of add operations.

Examples

| Input     | Output |
| --------- | -----|
| banitsa cola donuts <br> 3 | 0 1 2 <br> 0 0 0 <br> 0 0 0 <br> banitsa cola donuts <br> donuts cola banitsa |
| one two three four five six seven <br> 4 | 0 1 2 3 4 5 6 <br> 0 0 0 0 0 0 0 <br> 0 0 0 0 0 0 0 <br> one two three four <br> seven six five four |

### Problem 9.	Explicit Interfaces
Create 2 interfaces IResident and IPerson. IResident should have a name, country and a method GetName(). IPerson should have a name, an age and a method GetName(). Create a class Citizen which implements both IResident and IPerson, explicitly declare that IResident’s GetName() method should return _"Mr/Ms/Mrs "_ before the name while IPerson’s GetName() method should return just the name. You will receive lines of Citizen information from the console until the command _"End"_ is received. Each will be in the format _"\<name\> \<country\> \<age\>"_ for each line create the corresponding Citizen and print his IPerson’s GetName() and his IResident’s GetName().

Examples

| Input     | Output |
| --------- | -----|
| PeterPetrov Bulgaria 20 <br> End | PeterPetrov <br> Mr/Ms/Mrs PeterPetrov |
| GeorgeSmith Bulgaria 33 <br> EricAnderson GreatBritain 28 <br> PeterArmstrong USA 19 <br> End | GeorgeSmith <br> Mr/Ms/Mrs GeorgeSmith <br> EricAnderson <br> Mr/Ms/Mrs EricAnderson <br> PeterArmstrong <br> Mr/Ms/Mrs PeterArmstrong |