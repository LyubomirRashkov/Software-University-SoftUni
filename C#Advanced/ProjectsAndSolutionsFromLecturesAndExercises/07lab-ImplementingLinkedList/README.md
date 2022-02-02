## PROBLEM DESCRIPTION - CUSTOM DOUBLY LINKED LIST (Lecture)


Overview

In this workshop, we are going to create another custom data structure, which has similar functionalities as the C# doubly linked list. Оur custom doubly linked list will work only with integers. It will have the following functionalities: 
  +	void AddFirst(int element) – adds an element at the beginning of the collection
  +	void AddLast(int element) – adds an element at the end of the collection
  +	int RemoveFirst() – removes the element at the beginning of the collection
  +	int RemoveLast() – removes the element at the end of the collection 
  +	void ForEach() – goes through the collection and executes a given action
  +	int[] ToArray() – returns the collection as an array

Feel free to implement your own functionality or to write the methods by yourself. 

NOTE: You need a StartUp class with the namespace CustomDoublyLinkedList.

Details about the Structure

The doubly linked list is a structure that resembles a list, but has different functionalities. Each element in it "knows" about the previous one, if there is such, and the next one, again, if there is such. This is possible, because the doubly linked list has nodes and each node has two reference properties pointing to other nodes and a value property, which contains some kind of data. By definition, the doubly linked list has a head (list start) and a tail (list end). The typical operations over a doubly linked list are add / remove an element at both of the endings and traverse.
