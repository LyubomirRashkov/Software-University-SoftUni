## PROBLEMS DESCRIPTION - DESIGN PATTERNS (Exercise)


### Problem 1.	Prototype
Your task is to create a console application for building sandwiches implementing the Prototype Design Pattern.
#### Abstract Class
First, you have to create an abstract class to represent a sandwich and define a method by which the abstract Sandwich class can clone itself.

![изображение](https://user-images.githubusercontent.com/82647282/161313567-abe6c8bb-6032-445b-b328-e8bd86436283.png)

#### ConcretePrototype Participants
Now you need the ConcretePrototype participant class that can clone itself to create more Sandwich instances. Let’s say that a Sandwich consists of four parts: the meat, cheese, bread, and veggies.

![изображение](https://user-images.githubusercontent.com/82647282/161313643-19a70421-ec56-4794-8aa2-8ea5326cb000.png)

#### Sandwich Menu
Let’s create a class that will have the purpose to store the sandwiches we’ve made. It will be like a repository.

![изображение](https://user-images.githubusercontent.com/82647282/161313730-1967afaf-8d7a-4dc6-b241-571932ce420c.png)

#### Use What You’ve Done
Now is the time to test what you have done by trying to use it. In your Main() method you can do just that by instantiating the prototype and then cloning it, thereby populating your SandwichMenu.

![изображение](https://user-images.githubusercontent.com/82647282/161313816-9ce35b5e-f092-4fa3-b5bf-40eb0e8bcf9d.png)

![изображение](https://user-images.githubusercontent.com/82647282/161313832-514ca2ba-ee81-4109-bf06-b0da2f5ed83c.png)

### Problem 2.	Composite
Your task is to create a console application that calculates the total price of gifts that are being sold in a shop. The gift could be a single element (toy) or it can be a complex gift that consists of a box with two toys and another box with maybe one toy and the box with a single toy inside. We have a tree structure representing our complex gift so, implementing the Composite design pattern will be the right solution for us.
#### Component
First, you have to create an abstract class to represent the base gift. It should have two fields (name and price) and a method that calculates the total price. These fields and methods are going to be used as an interface between the Leaf and the Composite part of our pattern.

![изображение](https://user-images.githubusercontent.com/82647282/161313994-7a430f07-e494-4d05-9dc6-5c4229db7ed9.png)

#### Basic Operations
Create an interface IGiftOperations that will contain two operations - Add and Remove (a gift). You should create the interface because the Leaf class doesn’t need the operation methods.

![изображение](https://user-images.githubusercontent.com/82647282/161314078-8c25bf97-df01-46d1-92be-1fbef9c9ac39.png)

#### Composite Class
Now you have to create the composite class (CompositeGift). It should inherit the GiftBase class and implement the IGiftOperations interface. Therefore, the implementation is pretty forward. It will consist of many objects from the GiftBase class. The Add method will add a gift and the Remove - will remove one. The CalculateTotalPrice method will return the price of the CompositeGift.

![изображение](https://user-images.githubusercontent.com/82647282/161314205-ca744fba-df2d-424a-b7bd-c522ce3efff5.png)

#### Leaf Class
You should also create a Leaf class (SingleGift). It will not have sub-levels so it doesn’t require to add and delete operations. Therefore, it should only inherit the GiftBase class. It will be like a single gift, without component gifts.

![изображение](https://user-images.githubusercontent.com/82647282/161314283-bdb6952c-607f-4f5c-9677-cf780049e501.png)

#### Use What You’ve Done
Now is the time to test what you have done by trying to use it. In your Main() method you can do just that by instantiating the Leaf class (SingleGift) and the Composite class (CompositeGift) and using their methods.

![изображение](https://user-images.githubusercontent.com/82647282/161314394-91bbe0d8-4a98-418d-afa4-b62e053e506a.png)

![изображение](https://user-images.githubusercontent.com/82647282/161314417-1154afac-bf00-41ea-8703-e76c7f65c1ae.png)

### Problem 3.	Template Pattern
There are easily hundreds of types of bread currently being made in the world, but each kind involves specific steps to make them. Your task is to model a few different kinds of bread that all use this same pattern, which is a good fit for the Template Design Pattern.

#### Abstract Class
First, you have to create an abstract class (Bread) to represent all loaves of bread we can bake. It should have two abstract void methods MixIngredients(), Bake(), one virtual void method Slice(), and the template method - Make().

![изображение](https://user-images.githubusercontent.com/82647282/161314608-875bddde-46c9-4f14-bf67-7062969f9402.png)

#### Concrete Classes
Extend the application by adding several Concrete Classes for different types of Bread. Examples: TwelveGrain, Sourdough, WholeWheat.

![изображение](https://user-images.githubusercontent.com/82647282/161314699-eecdc5dc-549c-4c3b-be22-9d9a219478c0.png)

![изображение](https://user-images.githubusercontent.com/82647282/161314720-807428d4-08b9-4fea-86bc-51f311796cff.png)

![изображение](https://user-images.githubusercontent.com/82647282/161314744-3c2aaa0b-455c-4d0b-a18c-5d601dded2a9.png)

#### Use What You’ve Done
Now is the time to test what you have done by trying to use it. In your Main() method you can do just that by instantiating objects of the classes you’ve just made. It was that simple. This, this might be something you’ve been already using but you didn’t know it was a Design Pattern.

![изображение](https://user-images.githubusercontent.com/82647282/161314796-3a85661f-9f94-4786-9776-63a50c6ecdeb.png)

![изображение](https://user-images.githubusercontent.com/82647282/161314818-53309a1d-b5aa-4ae0-a354-97af5752f543.png)
