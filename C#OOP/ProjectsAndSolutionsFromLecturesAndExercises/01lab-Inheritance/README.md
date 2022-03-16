## PROBLEMS DESCRIPTION - INHERITANCE (Lecture)


### Problem 1.	Single Inheritance
NOTE: You need a public StartUp class with the namespace Farm.

Create two classes named Animal and Dog:
  +	Animal with a single public method Eat() that prints: _"eating…"_
  +	Dog with a single public method Bark() that prints: _"barking…"_
  +	Dog should inherit from Animal

### Problem 2.	Multiple Inheritance
NOTE: You need a public StartUp class with the namespace Farm.

Create three classes named Animal, Dog and Puppy:
  +	Animal with a single public method Eat() that prints: _"eating…"_
  +	Dog with a single public method Bark() that prints: _"barking…"_
  +	Puppy with a single public method Weep() that prints: _"weeping…"_
  +	Dog should inherit from Animal
  +	Puppy should inherit from Dog

### Problem 3.	Hierarchical Inheritance
NOTE: You need a public StartUp class with the namespace Farm.

Create three classes named Animal, Dog and Cat: 
  +	Animal with a single public method Eat() that prints: _"eating…"_
  +	Dog with a single public method Bark() that prints: _"barking…"_
  +	Cat with a single public method Meow() that prints: _"meowing…"_
  +	Dog and Cat should inherit from Animal

### Problem 4.	Random List
NOTE: You need a public StartUp class with the namespace CustomRandomList.

Create a RandomList class that has all the functionality of List\<string\>. Add additional function that returns and removes a random element from the list.
  +	Public method: RandomString(): string

### Problem 5.	Stack of Strings
NOTE: You need a public StartUp class with the namespace CustomStack.

Create a class StackOfStrings that extends Stack, can store only strings, and has the following functionality:
  +	Public method: IsEmpty(): bool
  +	Public method: AddRange(): Stack<string>