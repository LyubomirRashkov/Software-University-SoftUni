## PROBLEMS DESCRIPTION - GENERICS (Lecture)


### Problem 1.	Box
NOTE: You need a public StartUp class with the namespace BoxOfT.

Create a class Box<> that can store anything. It should have two public methods:
  +	void Add(element) – adds an element on the top of the list.
  +	element Remove() – removes the topmost element.
  +	int Count { get; }


### Problem 2.	Generic Array Creator
NOTE: You need a public StartUp class with the namespace GenericArrayCreator.

Create a class ArrayCreator with a method and a single overload to it:
  +	static T[] Create(int length, T item)

The method should return an array with the given length and every element should be set to the given default item.

### Problem 3.	Generic Scale
NOTE: You need a public StartUp class with the namespace GenericScale.

Create a class EqualityScale\<T> that holds two elements - left and right. The scale should receive the elements through its single constructor:
  +	EqualityScale(T left, T right)

The scale should have a single method: 
  +	bool AreEqual()

The greater of the two elements is the heavier. The method should return true if the elements are equal.
