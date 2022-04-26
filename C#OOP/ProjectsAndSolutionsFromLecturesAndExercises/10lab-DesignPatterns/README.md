## PROBLEMS DESCRIPTION - DESIGN PATTERNS (Lecture)


### Problem 1.	Singleton
We are going to create a simple console application in which we are going to read all the data from a file (which consists of cities with their population) and then use that data. So, to start, let’s create a single interface:

![изображение](https://user-images.githubusercontent.com/82647282/161309471-6854342d-d5a9-4907-9dfb-b5aa08677ea8.png)

After that, we have to create a class to implement the ISingletonContainer interface. We are going to call it SingletonDataContainer.

![изображение](https://user-images.githubusercontent.com/82647282/161309595-a9a14b33-835d-4e0a-abe5-25ccc093c993.png)

So, we have a dictionary in which we store the capital names and their population from our file. As we can see, we are reading from a file in our constructor. And that is all good. Now we are ready to use this class in any consumer by simply instantiating it. But is this really what we need to do, to instantiate the class which reads from a file that never changes (in this particular project. The population of the cities is changing daily). Of course not, so using a Singleton pattern would be very useful here. Let’s implement it:

First, we will hide the constructor from the consumer classes by making it private. Then, we’ve created a single instance of our class and exposed it through the Instance property.

![изображение](https://user-images.githubusercontent.com/82647282/161309676-518baa69-5760-4975-8372-dcfaf31dcd38.png)

At this point, we can call the Instance property as many times as we want, but our object is going to be instantiated only once and shared for every other call. Check it for yourself:

![изображение](https://user-images.githubusercontent.com/82647282/161309710-3f9dcb6c-9d5b-40ce-9bd7-4ff0d42bf8c2.png)
 
The result in out console will be the following:

![изображение](https://user-images.githubusercontent.com/82647282/161309770-2d1c8409-f8b3-4ead-91b4-5aaf4a7ecc27.png)
 
We can see that we are calling our instance four times but it is initialized only once, which is exactly what we want.
Let’s check if our console program works:
 
![изображение](https://user-images.githubusercontent.com/82647282/161309809-02ee6c93-462f-4883-9b86-1c1ab98a2a2f.png)

The expected output should be something like this:

![изображение](https://user-images.githubusercontent.com/82647282/161309865-860ec411-688d-4ad9-8436-56266a73e611.png)

### Problem 2.	Facade
Now we will take a look at a Façade example implementation.

We will start off by creating a class to work with:

![изображение](https://user-images.githubusercontent.com/82647282/161310275-e5e113e4-9e2c-4231-aa5b-4164c4132e8d.png)

We have the info part and the address part of our object, so we are going to use two builders to create this whole object.

We need a façade, let’s create one:

![изображение](https://user-images.githubusercontent.com/82647282/161310349-2ca6939a-7437-4ae2-80b9-b9dfdc53c643.png)

We instantiate the Car object, which we want to build and expose it through the Build method.

What we need now is to create concrete builders. So, let’s start with the CarInfoBuilder which needs to inherit from the facade class:

![изображение](https://user-images.githubusercontent.com/82647282/161310411-408c03c2-3560-43ff-a383-fd7dd7ed35fa.png)

We receive, through the constructor, an object we want to build and use the fluent interface for building purpose.

Let’s do the same for the CarAddresBuilder class:

![изображение](https://user-images.githubusercontent.com/82647282/161310461-ee4d4405-9257-4a31-927b-7510d3f70366.png)

At this moment we have both builder classes, but we can’t start building our object yet because we haven’t exposed our builders inside the facade class. Well, let’s do that:

![изображение](https://user-images.githubusercontent.com/82647282/161310521-8138a7d3-4de8-4e35-a32f-864081aa6b94.png)

That’s it, we can start building our object:

![изображение](https://user-images.githubusercontent.com/82647282/161310575-1d62143a-9436-44ce-8c88-aa56f82a9658.png)

And the output should be:

![изображение](https://user-images.githubusercontent.com/82647282/161310626-505f8a58-e814-4de0-ae43-d9d2ae63258d.png)

### Problem 3.	Command Pattern
The Command design pattern consists of the Invoker class, Command class/interface, Concrete command classes, and the Receiver class.  Having that in mind, in our example, we are going to follow the same design structure.

So, what we are going to do is write a simple app in which we are going to modify the price of the product that will implement the Command design pattern.

That being said, let’s start with the Product receiver class, which should contain the base business logic in our app:

![изображение](https://user-images.githubusercontent.com/82647282/161311676-a0a2c64f-7aa4-421f-a3b5-663fb85d1b19.png)

Now the Client class can instantiate the Product class and execute the required actions. But the Command design pattern states that we shouldn’t use receiver classes directly. Instead, we should extract all the request details into a special class - Command. Let’s do that.

The first thing we are going to do is to add the ICommand interface:

![изображение](https://user-images.githubusercontent.com/82647282/161312374-c13a8dca-e238-4da5-b2a3-f095253ed05e.png)

Just to enumerate our price modification actions, we are going to add a simple PriceAction enumeration:

![изображение](https://user-images.githubusercontent.com/82647282/161312485-b17489aa-9bc2-47d8-9e80-dfa5594f7925.png)

Finally, let’s add the ProductCommand class:

![изображение](https://user-images.githubusercontent.com/82647282/161312533-ba12e4d7-cc4f-416b-89b0-d346e4cf3d48.png)

As we can see, the ProductCommand class has all the information about the request and based on that executes the required action.

To continue on, let’s add the ModifyPrice class, which will act as Invoker:

![изображение](https://user-images.githubusercontent.com/82647282/161312585-2215492a-52ca-4b7c-8854-882ab5a732f5.png)

This class can work with any command that implements the ICommand interface and store all the operations as well.

Now, we can start working with the client part:

![изображение](https://user-images.githubusercontent.com/82647282/161312639-050ea7c7-fee4-4962-a038-be0b6b9fbd8e.png)

The output should be like this:

![изображение](https://user-images.githubusercontent.com/82647282/161312688-bddbe124-e979-48ed-86b3-d9890b746a56.png)
