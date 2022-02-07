## PROBLEMS DESCRIPTION - GENERICS (Exercise)


### Problem 1.	Generic Box of String
Create a generic class Box that can be initialized with any type and store the value. Override the ToString() method and print the type and stored value.

Input
  +	On the first line, you will get n - the number of strings to read from the console.
  +	On the next n lines, you will get the actual strings.
    +	For each of them, create a box and call its ToString() method to print its data on the console.

Output
  +	The output should be in the given format: _"{class full name: value}"_

Examples

| Input     | Output |
| --------- | -----|
| 2 <br> life in a box <br> box in a life | System.String: life in a box <br> System.String: box in a life |
| 3 <br> Peter <br> Simon <br> Griffin | System.String: Peter <br> System.String: Simon <br> System.String: Griffin |

### Problem 2.	Generic Box of Integer
Use the description of the previous problem but now, test your generic box with Integers.

Examples

| Input     | Output |
| --------- | -----|
| 1 <br> 1001 | System.Int32: 1001 |
| 3 <br> 7 <br> 123 <br> 42 | System.Int32: 7 <br> System.Int32: 123 <br> System.Int32: 42 |

### Problem 3.	Generic Swap Method Strings
Create a generic method that receives a list, containing any type of data and swaps the elements at two given indexes.

Input
  +	On the first line, you will read n number of boxes of type string and add them to the list.
  +	On the next line, however, you will receive a swap command consisting of two indexes.

Output
  +	Use the method you've created to swap the elements that correspond to the given indexes and print each element in the list.

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> Peter <br> George <br> Swap me with Peter <br> 0 2 | System.String: Swap me with Peter <br> System.String: George <br> System.String: Peter |
| 2 <br> SoftUni <br> Hello <br> 0 1 | System.String: Hello <br> System.String: SoftUni |

### Problem 4.	Generic Swap Method Integers
Use the description of the previous problem, but now, test your list of generic boxes with integers.

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> 7 <br> 123 <br> 42 <br> 0 2 | System.Int32: 42 <br> System.Int32: 123 <br> System.Int32: 7 |
| 3 <br> 1 <br> 2 <br> 3 <br> 0 1 | System.Int32: 2 <br> System.Int32: 1 <br> System.Int32: 3 |

### Problem 5.	Generic Count Method Strings
Create a method that receives as an argument a list of any type, that can be compared and an element of the given type. The method should return the count of elements that are greater than the value of the given element. Modify your Box class to support comparison by value of the stored data.

Input
  +	 On the first line, you will receive n - the number of elements to add to the list.
  +	 On the next n lines, you will receive the actual elements.
  +	 On the last line, you will get the value of the element for comparison.

Output
  +	Print the count of elements that are larger than the value of the given element.

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> aa <br> aaa <br> bb <br> aa | 2 |
| 1 <br> aaa <br> aa | 1 |

### Problem 6.	Generic Count Method Doubles
Use the description of the previous problem, but now, test your list of generic boxes with doubles.

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> 7.13 <br> 123.22 <br> 42.78 <br> 7.55 | 2 |
| 3 <br> 1.1 <br> 2.3 <br> 3.2 <br> 1.5 | 2 |

### Problem 7.	Tuple
A Tuple is a class in C#, in which you can store a few objects. First, we are going to focus on the Tuple's type, which contains two objects. The first one is "item1" and the second one is "item2". It is kind of like a KeyValuePair, except – it simply has items, which are neither key nor value. Your task is to create a class "Tuple", which holds two objects. The first one, will be "item1" and the second one – "item2". The tricky part here is to make the class hold generics. This means, that when you create a new object of class – "Tuple", there should be a way to explicitly specify both items' type separately.

Input

The input consists of three lines:

  + The first one is holding a person's name and an address. They are separated by space(s). Your task is to collect them in the tuple and print them on the console. Format of the input: _{first name} {last name} {address}_
  +	The second line holds a name of a person and the amount of beer (int) he can drink. Format: _{name} {liters of beer}_
  +	The last line will hold an integer and a double. Format: _{integer} {double}_

Output
  +	Print the tuples’ items in format: _{item1} -> {item2}_

Constraints
  +	Use the good practices we have learned. Create the class and make it have getters and setters for its class variables. The input will be valid, no need to check it explicitly!

Examples

| Input     | Output |
| --------- | -----|
| Adam Smith California <br> Mark 2 <br> 23 21.23212321 | Adam Smith -> California <br> Mark -> 2 <br> 23	-> 21.23212321 |
| William Donovan York <br> Richard 2999999 <br> 10 10 | William Donovan -> York <br> Richard -> 2999999 <br> 10 -> 10 |

### Problem 8.	Threeuple
Create a Class Threeuple. Its name is telling us, that it will hold no longer, just a pair of objects. The task is simple, our Threeuple should hold three objects. Make it have getters and setters. You can even extend the previous class

Input

The input consists of three lines:
  +	The first one is holding a name, an address and a town. Format of the input: _{first name} {last name} {address} {town}_
  +	The second line is holding a name, beer liters, and a boolean variable with value - drunk or not. Format: _{name} {liters of beer} {drunk or not}_
  +	The last line will hold a name, a bank balance (double) and a bank name. Format: _{name} {account balance} {bank name}_

Output
  +	Print the Threeuples' objects in format: _"{firstElement} -> {secondElement} -> {thirdElement}"_

Examples

| Input     | Output |
| --------- | -----|
| Adam Smith Wallstreet New York <br> Mark 18 drunk <br> Karren 0.10 USBank | Adam Smith -> Wallstreet -> New York <br> Mark -> 18 -> True <br> Karren -> 0.1 -> USBank |
| Anatoly Andreevich Kutuzova Kaliningrad <br> Marley 9 not <br> Grant 2 NGB | Anatoly Andreevich -> Kutuzova -> Kaliningrad <br> Marley -> 9 -> False <br> Grant -> 2 -> NGB |

### Problem 9.	Custom Linked List
Now you have the needed knowledge to extend the custom linked list you have created during the previous workshop and your task is to make it generic. Upload your solution without the bin and obj folders in Judge.
