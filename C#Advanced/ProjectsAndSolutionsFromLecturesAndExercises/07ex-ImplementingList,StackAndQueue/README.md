## PROBLEMS DESCRIPTION - CREATE CUSTOM DATA STRUCTURES (Exercise)


Overview

In this workshop, we will create our own custom data structures – a custom list, a custom stack, and a custom queue. 

### Problem 1.	Implement the CustomList Class

The custom list will have similar functionality to C# lists that you've used before. Our custom list will work only with integers for now, but this will be fixed later in the course. It will have the following functionality: 
  +	void Add(int element) - Adds the given element to the end of the list
  +	int RemoveAt(int index) - Removes the element at the given index
  +	bool Contains(int element) - Checks if the list contains the given element. Returns True or False
  +	void Swap(int firstIndex, int secondIndex) - Swaps the elements at the given indexes

Details about the Structure:

First of all, we must make it clear how our structure should work under the provided public functionality.
  +	It should hold a sequence of items in an array. 
  +	The structure should have capacity that grows twice when it is filled, always starting at 2. 

The CustomList class should have the properties listed below:
  +	int[] items - An array that will hold all of our elements
  +	int Count – This property will return the count of items in the collection
  +	indexer – The Indexer will provide us with functionality to access the elements using integer indexes

The structure will have internal methods to make the managing of the internal collection easier.
  +	Resize – this method will be used to increase the internal collection's length twice
  +	Shrink – this method will help us to decrease the internal collection's length twice 
  +	Shift – this method will help us to rearrange the internal collection's elements after removing one.

Feel free to implement your functionality or to write the methods by yourself.

### Problem 2.	Implement the CustomStack Class

The custom stack will also have similar functionality to the C# stack and again, we will make it work only with integers. Later on, we will learn how to implement it in a way that will allow us to work with any type. It will have the following functionality:
  +	void Push(int element) – Adds the given element to the stack
  +	int Pop() – Removes the last added element
  +	int Peek() – Returns the last element in the stack without removing it
  +	void ForEach(Action\<int> action) – Goes through each of the elements in the stack

Details about the Structure:

The implementation of a custom stack is much easier, mostly because you can only execute actions over the last index of the collection, plus you can iterate through the collection. The first thing you can do is have a clear vision of how you want your structure to work under the provided public functionality. For example:
  +	It should hold a sequence of items in an array. 
  +	The structure should have a capacity that grows twice when it is filled, always starting at 4. 

The CustomStack class should have the properties listed below:
  +	int[] items - An array, which will hold all of our elements.
  +	int Count – This property will return the count of items in the collection.
  +	const int InitialCapacity – this constant's value will be the initial capacity of the internal array.

Feel free to implement your functionality or to write the methods by yourself.

### Problem 3.	Implement the CustomQueue Class

The custom queue will also have similar functionality to the C# queue and again, we will make it work only with integers. Later on, we will learn how to implement it in a way that will allow us to work with any type. It will have the following functionality:
  +	void Enqueue(int element) – Adds the given element to the queue
  +	int Dequeue() – Removes the first element
  +	int Peek() – Returns the first element in the queue without removing it
  +	void Clear() – Delete all elements in the queue
  +	void ForEach(Action\<int> action) – Goes through each of the elements in the queue

Details about the Structure:

When implementing a custom queue keep in mind that you can add elements at the end, and remove elements from the beginning of the queue, plus you can iterate through the collection. The first thing you can do is have a clear vision of how you want your structure to work under the provided public functionality. For example:
  +	It should hold a sequence of items in an array. 
  +	The structure should have a capacity that grows twice when it is filled, always starting at 4. 

The CustomQueue class should have the properties listed below:
  +	void Enqueue(int element) – Adds the given element to the queue
  +	int Dequeue() – Removes the first element
  +	int Peek() – Returns the first element in the queue without removing it
  +	void Clear() – Delete all elements in the queue
  +	void ForEach(Action\<int> action) – Goes through each of the elements in the queue

Feel free to implement your functionality or to write the methods by yourself.
