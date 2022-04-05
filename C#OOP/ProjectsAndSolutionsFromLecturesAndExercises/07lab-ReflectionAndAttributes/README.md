## PROBLEMS DESCRIPTION - REFLECTION AND ATTRIBUTES (Lecture)


### Problem 1.	Stealer
NOTE: You need a public StartUp class with the namespace Stealer.

Add the Hacker class from the box below to your project.

| Hacker.cs |
| --------- |
| public class Hacker <br> { <br> &ensp; public string username = "securityGod82"; <br> &ensp; private string password = "mySuperSecretPassw0rd"; <br> &ensp; public string Password <br> &ensp; { <br> &ensp; &ensp; get => this.password; <br> &ensp; &ensp; set => this.password = value; <br> &ensp; } <br> &ensp; private int Id { get; set; } <br> &ensp; public double BankAccountBalance { get; private set; } <br> &ensp; public void DownloadAllBankAccountsInTheWorld() <br> &ensp; { <br> &ensp; } <br> } |

There is the one really nasty hacker, but not so wise though. He is trying to steal a big amount of money and transfer it to his own account. The police are after him but they need a professional… Correct - this is you!

You have the information that this hacker is keeping some of his info in private fields. Create a new class named Spy and add inside a method called - StealFieldInfo, which receives:
  +	string – the name of the class to investigate
  +	an array of string - names of the fields to investigate

After finding the fields, you must print on the console: _"Class under investigation: {nameOfTheClass}"_

On the next lines, print info about each field in the following format: _"{fieldName} = {fieldValue}"_

Use StringBuilder to concatenate the answer. Don’t change anything in Hacker class!

In your Main() method, you should be able to check your program with the current piece of code.

| Main() |
| --------- |
| Spy spy = new Spy(); <br> string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password"); <br> Console.WriteLine(result); |

Example

| Output |
| --------- |
| Class under investigation: Stealer.Hacker <br> username = securityGod82 <br> password = mySuperSecretPassw0rd |

### Problem 2.	High Quality Mistakes
NOTE: You need a public StartUp class with the namespace Stealer.

You are already an expert  on High-Quality Code, so you know what kind of access modifiers must be set to the members of a class. You should have noticed that our hacker is not familiar with these concepts.

Create a method inside your Spy class called - AnalyzeAccessModifiers(string className). Check all of the fields and methods access modifiers. Print on the console all of the mistakes in the format:
  +	Fields:	_"{fieldName} must be private!"_
  +	Getters: _"{methodName} have to be public!"_
  +	Setters: _"{methodName} have to be private!"_

Use StringBuilder to concatenate the answer. Don’t change anything in Hacker class!

In your Main() method you should be able to check your program with the current piece of code.

| Main() |
| --------- |
| Spy spy = new Spy(); <br> string result = spy.AnalyzeAccessModifiers("Hacker"); <br> Console.WriteLine(result); |

Example

NOTE: The order of your output may differ based on your solution logic.

| Output |
| --------- |
| username must be private! <br> get_Id have to be public! <br> set_Password have to be private! |

### Problem 3.	Mission Private Impossible
NOTE: You need a public StartUp class with the namespace Stealer.

It’s time to see what this hacker you are dealing with aims to do. Create a method inside your Spy class called - RevealPrivateMethods(string className). Print all private methods in the following format:

All Private Methods of Class: {className}

Base Class: {baseClassName}

On the next lines, print found method’s names each on a new line. 

Use StringBuilder to concatenate the answer. Don’t change anything in Hacker class! 

In your Main() method, you should be able to check your program with the current piece of code.

| Main() |
| --------- |
| Spy spy = new Spy(); <br> string result = spy.RevealPrivateMethods("Stealer.Hacker"); <br> Console.WriteLine(result); |

Example

NOTE: The order of your output may differ based on your solution logic.

| Output |
| --------- |
| All Private Methods of Class: Stealer.Hacker <br> Base Class: Object <br> get_Id <br> set_Id <br> set_BankAccountBalance <br> MemberwiseClone <br> Finalize |

### Problem 4.	Collector
NOTE: You need a public StartUp class with the namespace Stealer.

Use reflection to get all Hacker methods. Then prepare an algorithm that will recognize which methods are getters and setters.

Print to console each getter on a new line in the format: _"{name} will return {Return Type}"_

Then print all of the setters in the format: _"{name} will set field of {Parameter Type}"_

Use StringBuilder to concatenate the answer. Don’t change anything in Hacker class!

In your Main() method you should be able to check your program with the current piece of code.

| Main() |
| --------- |
| Spy spy = new Spy(); <br> string result = spy.CollectGettersAndSetters("Stealer.Hacker"); <br> Console.WriteLine(result); |

Example

| Output |
| --------- |
| get_Password will return System.String <br> get_Id will return System.Int32 <br> get_BankAccountBalance will return System.Double <br> set_Password will set field of System.String <br> set_Id will set field of System.Int32 <br> set_BankAccountBalance will set field of System.Double |

### Problem 5.	Create Attribute
NOTE: You need a public StartUp class with the namespace AuthorProblem.

Create attribute Author with a string element called name, that:
  +	Can be used over classes and methods
  +	Allow multiple attributes of the same type

Example

| StartUp.cs |
| --------- |
| [Author("Victor")] <br> class StartUp <br> { <br> &ensp; [Author("George")] <br> &ensp; static void Main(string[] args) <br> &ensp; { <br> &ensp; } <br> } |

### Problem 6.	Code Tracker
NOTE: You need a public StartUp class with the namespace AuthorProblem.

Create a class Tracker with the method void PrintMethodsByAuthor()

The method above should print on the console information about each method that is written by someone. You should print the information about the method and its creator in the following format: _"{methodName} is written by {authorName}"_. You should be able to call your method and see the output of it as in the example below.

Example

| StartUp.cs |
| --------- |
| [Author("Victor")] <br> class StartUp <br> { <br> &ensp; [Author("George")] <br> &ensp; static void Main(string[] args) <br> &ensp; { <br> &ensp; &ensp; var tracker = new Tracker(); <br> &ensp; &ensp; tracker.PrintMethodsByAuthor(); <br> &ensp; } <br> } |