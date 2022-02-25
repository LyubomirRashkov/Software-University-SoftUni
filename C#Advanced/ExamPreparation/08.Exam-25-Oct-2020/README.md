## PROBLEMS DESCRIPTION


### Problem 1.	Scheduling
On the first line you will be given some tasks as integer values, separated by comma and space ", ". On the second line you will be given some threads as integer values, separated by a single space. On the third line, you will receive the integer value of a task that you need to kill. Your job is to stop the work of the CPU as soon as you get to this task, otherwise your CPU will crash. The thread that gets first to this task, kills it.

The CPU works in the following way:
  +	It takes the first given thread value and the last given task value.
  +	If the thread value is greater than or equal to the task value, the task and thread get removed.
  +	If the thread value is less than the task value, the thread gets removed, but the task remains.

After you finish the needed task, print on a single line: _"Thread with value {thread} killed task {taskToBeKilled}"_

Then print the remaining threads (including the one that killed the task) starting from the first on a single line, separated by a single space.

Input
  +	On the first line you will receive the tasks, separated by ", ".
  +	On the second line you will the threads, separated by a single space.
  +	On the third line, you will receive a single integer – value of the task to be killed.

Output
  +	Print the thread that killed the task and task itself in the format given above.
  +	Print the remaining threads starting from the first on a single line, separated by a single space.

Constraints
  +	The needed task will always be with a unique value
  +	You will always have enough threads to get to the needed task

Examples

| Input     | Output |
| --------- | -----|
| 20, 23, 54, 34, 90 <br> 150 64 20 34 <br> 54 | Thread with value 20 killed task 54 <br> 20 34 |
| 33, 12, 15, 40, 45, 60 <br> 30 20 53 67 84 90 <br> 40 | Thread with value 90 killed task 40 <br> 90 |

### Problem 2.	Garden
You will be given N and M – integers, indicating the dimensions of the square garden. The garden is empty at the beginning – it has no flowers. Furion wants every place for a flower to be presented with a zero (0) when it is empty. After you finish creating the garden, you will start receiving two integers – Row and Column, separated by a single space – which represent the position at which Furion currently plants a flower. If you receive a position, which is outside of the garden, you should print _"Invalid coordinates."_ and move on with the next position. This happens until you receive the command _"Bloom Bloom Plow”_. When you receive that input, all planted flowers should bloom.

The flowers are magical. When a flower blooms it instantly blooms flowers to all places to its left, right, up, and down, increasing their value with 1. Flowers can bloom multiple times, and each time the flower blooms – it becomes more and more beautiful, which means its value increases by 1. 

Input
  +	On the first line of input you will receive two integers, separated by a single space – indicating the dimensions of the garden.
  +	On the next several lines you will be receiving two integers separated by a single space – indicating the position at which Furion currently plants a flower.
  +	When you receive the input line _"Bloom Bloom Plow”_ the input sequence should end.

Output
  +	Print _"Invalid coordinates."_ each time you receive positions outside the garden.
  +	The output is simple. Print the whole garden – each row of it on a new line, and each column – separated by a single space.

Constraints
  +	The dimensions of the matrix (N and M) will contains be integers in the range [3, 500].
  +	The amount of input commands will be in the range [0, N * M].
  +	Flowers will always be planted on empty places.

Examples

| Input     | Output |
| --------- | -----|
| 5 5 <br> 1 1 <br> 3 3 <br> Bloom Bloom Plow | 0 1 0 1 0 <br> 1 1 1 2 1 <br> 0 1 0 1 0 <br> 1 2 1 1 1 <br> 0 1 0 1 0 |
| 4 4 <br> 0 0 <br> 3 3 <br> 1 1 <br> 2 2 <br> Bloom Bloom Plow | 1 2 2 2 <br> 2 1 2 2 <br> 2 2 1 2 <br> 2 2 2 1 |

### Problem 3.	Classroom
Your task is to create a repository, which stores items by creating the classes described below.

First, write a C# class Student with the following properties:
  +	FirstName: string
  +	LastName: string
  +	Subject: string

The class constructor should receive firstName, lastName and subject. You need to create the appropriate getters and setters. The class should override the ToString() method in the following format: _"Student: First Name = {firstName}, Last Name = {lastName}, Subject = {subject}"_

Next, write a C# class Classroom that has students (a collection, which stores the students) and a certain capacity. All entities inside the repository have the same fields. Also, the Classroom class should have the following properties:
  +	Capacity: int
  +	Count: int – returns the number of students in the classroom
The class constructor should receive capacity, also it should initialize the students with a new instance of the collection. Implement the following features:
  +	Field students – collection that holds added students
  +	Method RegisterStudent(Student student) – adds an entity to the students if there is an empty seat for the student.
    +	Returns _"Added student {firstName} {lastName}"_ if the student is successfully added
    +	Returns _"No seats in the classroom"_ – if there are no more seats in the classroom
  +	Method DismissStudent(string firstName, string lastName) – removes the student by the given names
    +	Returns _"Dismissed student {firstName} {lastName}"_ if the student is successfully dismissed
    +	Returns _"Student not found"_ if the student is not in the classroom
  +	Method GetSubjectInfo(string subject): 
  	+ returns _"No students enrolled for the subject"_ if the student is not in the classroom
    + returns all the students with the given subject in the following format:

_"Subject: {subjectName}_

_Students:_

_{firstName} {lastName}_

_{firstName} {lastName}_

_"…"_
    
  +	Method GetStudentsCount() – returns the count of the students in the classroom.
  +	Method GetStudent(string firstName, string lastName) – returns the student with the given names. 
 
Constraints
  +	The combinations of names will always be unique.
  +	The capacity will always be a positive number.
