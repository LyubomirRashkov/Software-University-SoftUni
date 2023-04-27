## PROBLEMS DESCRIPTION - LINEAR DATA STRUCTURES (Exercise)


### Problem 1.	Faster Queue

You have the basic implementation of the IAbstractQueue\<T\> data structure from the lecture.

The task is simple - you have to modify the structure so now we can reduce the complexity when adding an element to a constant factor.

  +	Enqueue(T item) 
    +	Modify this operation so you can perform it in constant time, also modify anything required to achieve that. 

### Problem 2.	Circular Queue

Your task is to implement the ADS IAbstractQueue\<T\> inside the Queue\<T\> class provided.

You have to implement all the methods to solve the problem, however, you are free to add more methods with any access modifier you want.

  +	void Enqueue(T item) 
    +	Adds an element at the end of the queue and increases the size.
  +	T Dequeue()
    +	 Removes and returns the first element at the queue also decreases the size and performs a check if this method is called upon empty collection. 
    +	If so throw InvalidOperationException with the message of your choice.
  +	T Peek()
    +	Returns the element at the current front of the queue. If the collection is empty throw InvalidOperationException with the appropriate message.
  +	T[] ToArray() 
    +	Returns the queue as array of elements.
  +	int Count 
    +	Returns the number of elements inside the queue.

### Problem 3.	DoublyLinkedList

Your task is to take the implementation of the SinglyLinkedList\<T\> from the lecture and make it a doubly linked list. 

This means that you have to add two things:

  +	Add additional field Node\<T\> tail that will always point to the last element of the linked list.
  +	Add new property Node\<T\> Previous to the Node class this should point to the previous node.

Do the changes above the methods below should remain with unchanged erasure, use the tests provided to ensure that. 

  +	AddFirst(T item)
    +	Adds an element in front of the collection and increases the size.
  +	AddLast(T item)
    +	Adds an element after the last element of the collection and increases the size.
  +	T RemoveFirst()
    +	Removes and returns the first element of the collection if it is such if no then throw InvalidOperationException with the appropriate message.
  +	T RemoveLast()
    +	Removes and returns the last element of the collection if it is such if no then throw InvalidOperationException with the appropriate message.
  +	T GetFirst()
    +	Returns but does not remove the first element of the collection if it is such if no then throw InvalidOperationException with the appropriate message.
  +	T GetLast() 
    +	Returns but does not remove the last element of the collection if it is such if no then throw InvalidOperationException with the appropriate message.
  +	int Count
    +	Returns the number of elements inside the collection.

### Problem 4.	ReversedList

Implement a data structure ReversedList\<T\> that holds a sequence of elements of generic type T.

It should hold a sequence of items in reversed order. The structure should have some capacity that grows twice when it is filled, always starting at four. 

The reversed list should support the same operations that the List we have developed during the lecture implements but in a reversed order of adding elements.

### Problem 5.	Balanced Parentheses

Your task is to implement the method Solve() – which performs analysis of the parentheses filed and returns true or false whether the parentheses are balanced or not.

A sequence of parentheses is balanced if every open parenthesis can be paired uniquely with a closing parenthesis that occurs after the former.

You will be given three types of parentheses: (, {, and [.

{[()]} - This is a balanced parenthesis.

{[(]]}- This is not a balanced parenthesis.

### Problem 6.	Reverse Numbers with a Stack

Write a program that reads N integers from the console and reverses them using a stack. Use the Stack\<int\> class from .NET Framework.

Examples:

| Input | Output |
| --- | --- |
| 1 2 3 4 5 | 5 4 3 2 1 |
| 1 | 1 |
| (empty) | (empty) |
| 1 -2 | -2 1 |

### Problem 7.	Calculate Sequence with a Queue

We are given the following sequence of numbers:

  +	S1 = N
  +	S2 = S1 + 1
  +	S3 = 2 * S1 + 1
  +	S4 = S1 + 2
  +	S5 = S2 + 1
  +	S6 = 2 * S2 + 1
  +	S7 = S2 + 2
  +	…

Using the Queue\<T\> class, write a program to print its first 50 members for given N. 

Examples:

| Input | Output |
| --- | --- |
| 2 | 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, … |
| -1 | -1, 0, -1, 1, 1, 1, 2, … |
| 1000 | 1000, 1001, 2001, 1002, 1002, 2003, 1003, … |

### Problem 8.	Sequence N -> M

We are given numbers n and m, and the following operations:

  + n -> n + 1
  + n -> n + 2
  + n -> n * 2

Write a program that finds the shortest sequence of operations from the list above that starts from n and finishes in m. If several shortest sequences exist, find the first one of them. 

Examples:

| Input | Output |
| --- | --- |
| 3 10 | 3 -> 5 -> 10 |
| 5 -5 | (no solution) |
| 10 30 | 10 -> 11 -> 13 -> 15 -> 30 |
