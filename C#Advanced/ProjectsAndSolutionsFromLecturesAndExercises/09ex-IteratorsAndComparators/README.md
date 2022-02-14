## PROBLEMS DESCRIPTION - ITERATORS AND COMPARATORS (Exercise)


### Problem 1.	ListyIterator
Create a generic class ListyIterator. The collection, which it will iterate through, should be received by the constructor. You should store the elements in a List. The class should have three main functions:
  +	_Move_ - should move an internal index position to the next index in the list. The method should return true if it had successfully moved the index and false if there is no next index.
  +	_HasNext_ - should return true, if there is a next index and false if the index is already at the last element of the list.
  +	_Print_ - should print the element at the current internal index. Calling Print on a collection without elements should throw an appropriate exception with the message _"Invalid Operation!"_. 

By default, the internal index should be pointing to the 0th index of the List. Your program should support the following commands:

| Command     | Return Type | Description |
| --------- | -----| --- |
| Create {e1 e2 …} | void | Creates a ListyIterator from the specified collection. In case of a Create command without any elements, you should create a ListyIterator with an empty collection. |
| Move | boolean | This command should move the internal index to the next index. |
| Print | void | This command should print the element at the current internal index. |
| HasNext | boolean | Returns whether the collection has the next element. |
| END | void | Stops the input. |

Your program should catch any exceptions thrown because of the described validations - calling Print on an empty collection - and print their messages instead.

Input
  +	Input will come from the console as lines of commands. 
  +	The first line will always be the Create command in the input. 
  +	The last command received will always be the END command.

Output
  +	For every command from the input (except for the END and Create commands), print the result of that command on the console, each on a new line. 
  +	In the case of Move or HasNext commands, print the return value of the methods.
  +	In the case of a Print command, you don’t have to do anything additional as the method itself should already print on the console.

Constraints
  +	There will always be only one Create command and it will always be the first command passed.
  +	The number of commands received will be between [1…100].
  +	The last command will always be the only END command.

Examples

| Input     | Output |
| --------- | -----|
| Create <br> Print <br> END | Invalid Operation! |
| Create Steve George <br> HasNext <br> Print <br> Move <br> Print <br> END | True <br> Steve <br> True <br> George |

### Problem 2.  Collection
Using the ListyIterator from the last problem, extend it by implementing the IEnumerable\<T> interface, implement all methods desired by the interface manually. Use yield return for the GetEnumerator() method. Add a new command PrintAll that should foreach the collection and print all of the elements on a single line separated by a space. Your program should catch any exceptions thrown because of validations and print their messages instead.

Input
  +	Input will come from the console as lines of commands. 
  +	The first line will always be the Create command in the input. 
  +	The last command received will always be the END command.

Output
  +	For every command from the input (except for the END and Create commands), print the result of that command on the console, each on a new line. 
  +	In the case of Move or HasNext commands print the return value of the method
  +	In the case of a Print command, you don’t have to do anything additional as the method itself should already print on the console.
  +	In the case of a PrintAll command, you should print all of the elements on a single line separated by spaces. 

Constraints
  +	Do NOT use the GetEnumerator() method from the base class. Use your implementation using _"yield return"_.
  +	There will always be only one Create command and it will always be the first command passed.
  +	The number of commands received will be between [1…100].
  +	The last command will always be the only END command.

Examples

| Input     | Output |
| --------- | -----|
| Create 1 2 3 4 5 <br> Move <br> PrintAll <br> END | True <br> 1 2 3 4 5 |
| Create Stefcho Goshky Peshu <br> PrintAll <br> Move <br> Move <br> Print <br> HasNext <br> END | Stefcho Goshky Peshu <br> True <br> True <br> Peshu <br> False |

### Problem 3.  Stack
Create your custom stack. You are aware of Stack's structure. There is a collection to store the elements and two functions (not from the functional programming) - to push an element and to pop it. Keep in mind that the first element, which is popped is the last in the collection. The Push method adds an element at the top of the collection and the Pop method returns the top element and removes it. Push and Pop will be the only commands and they will come in the following format:

_"Push {element1}, {element2}, … {elementN}_

 _Pop_
 
_… "_

Write your custom implementation of Stack\<T> and implement IEnumerable\<T> interface. Your implementation of the GetEnumerator() method should follow the rules of the Abstract Data Type – Stack (return the elements in reverse order of adding them to the stack).

Input
  +	The input will come from the console as lines of commands. 
  +	Push and pop will be the only possible commands, followed by integers for the push command and no other input for the pop command. 

Output
  +	When you receive END, the input is over. Foreach the stack twice and print all elements each on the new line.

Constraints
  +	The elements in the push command will be valid integers between [2-31…231-1].
  +	The commands will always be valid (always be either _Push_, _Pop_, or _END_).
  +	If the Pop command could not be executed as expected (e.g. no elements in the stack), print on the console: _"No elements"_.

Examples

| Input     | Output |
| --------- | -----|
| Push 1, 2, 3, 4 <br> Pop <br> Pop <br> END | 2 <br> 1 <br> 2 <br> 1 |
| Push 1, 2, 3, 4  <br> Pop <br> Pop <br> Pop <br> Pop <br> Pop <br> END | No elements |

### Problem 4.  Froggy
Let's play a game. You have a tiny little Frog and a Lake that has a path of stones in it. Every stone has a number. Our frog must cross the lake along that path and then return. But there are some rules. First, the frog must jump on all the stones, which are in even positions in ascending order, and then on all the odd ones, but in reversed order. The order of the stones and their numbers will be given on the first line of input. Then you must print the order of stones in which our frog jumped from one to another.

Try to achieve this functionality by creating a class Lake (it will hold all stone numbers in order) that implements the IEnumerable\<int> interface and overrides its GetEnumerator() methods.

Examples

| Input     | Output |
| --------- | -----|
| 1, 2, 3, 4, 5, 6, 7, 8 | 1, 3, 5, 7, 8, 6, 4, 2 |
| 13, 23, 1, -8, 4, 9 | 13, 1, 4, 9, -8, 23 |

### Problem 5.  Comparing Objects
Create a class Person. Each person should have a name, an age, and a town. You should implement the interface – IComparable\<T> and implement the CompareTo method. When you compare two people, first you should compare their names, after that – their age and finally – their towns. You will be receiving input with information about the people until you receive the _"END"_ command in the following format: _"{name} {age} {town}"_

After that, you will receive n – the n'th person from your collection, starting from 1. You should bring statistics, how many people are equal to him, how many people are not equal to him, and the total people in your collection in the following format: _"{count of matches} {number of not equal people} {total number of people}"_

If there are no equal people print: _"No matches"_.

Input
  +	You will be receiving lines in the format described above, until the _"END"_ command.
  +	After the _"END"_ command, you will receive the position of the person you should compare the others to. 

Note: Start counting the people in your collection from 1.

Output
  +	Print a single line of output in the format described above.

Constraints
  +	Input names, ages, and addresses will be valid. 
  +	Input number will always be а valid integer in the range [2…100]

Examples

| Input     | Output |
| --------- | -----|
| Peter 22 Varna <br> George 14 Sofia <br> END <br> 2 | No matches |
| Peter 22 Varna <br> George 22 Varna <br> George 22 Varna <br> END <br> 2 | 2 1 3 |

### Problem 6.  Equality Logic
Create a class Person holding a name and an age. A person with the same name and age should be considered the same. Override any methods needed to enforce this logic. Your class should work with both standards and hashed collections. Create a SortedSet and a HashSet of type Person. You will receive n – the number of input lines. On each of them, you will receive info about the people in the following format: "\<name> \<age>"

You should add the people to both sets. In the end, you should print the size of the sorted set and then the size of the HashSet.

Input
  +	On the first line of input, you will receive a number n. 
  +	On each of the next n lines, you will receive information about people in the described format. 

Output
  +	The output should consist of exactly two lines. 
  +	On the first one, you should print the size of the sorted set
  +	On the second - the size of the HashSet.

Constraints
  +	A person’s name will be a string that contains only alphanumerical characters with a length between [1…50] symbols.
  +	A person’s age will be a positive integer between [1…100].
  +	The number of people N will be a positive integer between [0…100].
  	
Examples

| Input     | Output |
| --------- | -----|
| 4 <br> Peter 20 <br> Petter 20 <br> George 15 <br> Peter 21 | 4 <br> 4 |
| 7 <br> John 17 <br> john 17 <br> Stoqn 25 <br> John 18 <br> John 17 <br> Sam 25 <br> Samm 25 | 5 <br> 5 |

### Problem 7.  Custom Comparator
Write a custom comparator that sorts all even numbers before all the odd ones in ascending order. Pass it to Array.Sort() function and print the result. Use functions.

Examples

| Input     | Output |
| --------- | -----|
| 1 2 3 4 5 6 | 2 4 6 1 3 5 |
| -3 2 | 2 -3 |

### Problem 8.  Custom Linked List
Extend your custom linked list, which is already generic, and implement the needed interfaces to make it foreachable.
