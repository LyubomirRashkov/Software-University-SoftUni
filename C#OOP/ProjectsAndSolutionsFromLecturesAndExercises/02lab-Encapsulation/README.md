## PROBLEMS DESCRIPTION - ENCAPSULATION (Lecture)


### Problem 1.	Persons
NOTE: You need a public StartUp class with the namespace PersonsInfo.

Create a class Person, which should have public properties with private setters for:
  +	FirstName: string
  +	LastName: string
  +	Age: int
  +	ToString(): string - override

Examples

| Input     | Output |
| --------- | -----|
| 5 <br> Brandi Anderson 65 <br> Andrew Williams 57 <br> Newton Holland 27 <br> Andrew Clark 44 <br> Brandi Scott 35 | Andrew Clark is 44 years old. <br> Andrew Williams is 57 years old. <br> Brandi Scott is 35 years old. <br> Brandi Anderson is 65 years old. <br> Newton Holland is 27 years old. |

### Problem 2.	Salary
NOTE: You need a public StartUp class with the namespace PersonsInfo. Refactor the project from the last task.

Create objects of the class Person. Read their name, age and salary from the console. Read the percentage of the bonus to every Person salary. People younger than 30 get half the increase. Expand Person from the previous task.

New properties and methods:
  +	Salary: decimal 
  +	IncreaseSalary(decimal percentage)

Examples

| Input     | Output |
| --------- | -----|
| 5 <br> Andrew Williams 65 2200 <br> Newton Holland 57 3333 <br> Rachelle Nelson 27 600 <br> Brandi Scott 44 666.66 <br> George Miller 35 559.4 <br> 20 | Andrew Williams receives 2640.00 leva. <br> Newton Holland receives 3999.60 leva. <br> Rachelle Nelson receives 660.00 leva. <br> Brandi Scott receives 799.99 leva. <br> George Miller receives 671.28 leva. |

### Problem 3.	Validation
NOTE: You need a public StartUp class with the namespace PersonsInfo.

Expand Person with proper validation for every field:
  +	Name must be at least 3 symbols
  +	Age must not be zero or negative
  +	Salary can't be less than 650 (decimal)

Print proper messages to the user:
  +	_"Age cannot be zero or a negative integer!"_
  +	_"First name cannot contain fewer than 3 symbols!"_
  +	_"Last name cannot contain fewer than 3 symbols!"_
  +	_"Salary cannot be less than 650 leva!"_

Use ArgumentExeption with the listed message.

Examples

| Input     | Output |
| --------- | -----|
| 5 <br> Andrew Williams -6 2200 <br> B Gomez 57 3333 <br> Carolina Richards 27 670 <br> Gilbert H 44 666.66 <br> Joshua Anderson 35 300 <br> 20 | Age cannot be zero or a negative integer! <br> First name cannot contain fewer than 3 symbols! <br> Last name cannot contain fewer than 3 symbols! <br> Salary cannot be less than 650 leva! <br> Carolina Richards receives 737.00 leva. |

### Problem 4.	Team
NOTE: You need a public StartUp class with the namespace PersonsInfo.

Create a Team class. Add to this team all of the people you have received. Those who are younger than 40 go to the first team, others go to the reserve team. At the end print the sizes of the first and the reserved team.

The class should have private fields for:
  +	name: string
  +	firstTeam: List\<Person\>
  +	reserveTeam: List\<Person\>

The class should have constructors:
  +	Team(string name)

The class should also have public properties for:
  +	FirstTeam: List\<Person\> (read only!)
  +	ReserveTeam: List\<Person\> (read only!)

And a method for adding players:
  +	AddPlayer(Person person): void

Examples

| Input     | Output |
| --------- | -----|
| 5 <br> Andrew Williams 20 2200 <br> Newton Holland 57 3333 <br> Rachelle Nelson 27 600 <br> Grigor Dimitrov 25 666.66 <br> Brandi Scott 35 555 | First team has 4 players. <br> Reserve team has 1 players. |