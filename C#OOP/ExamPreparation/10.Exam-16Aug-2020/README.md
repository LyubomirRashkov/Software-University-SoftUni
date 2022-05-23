## PROBLEMS DESCRIPTION


#### Overview
In this exam, you need to build an online shop project, which has peripherals, components, and computers. The project will consist of model classes and a controller class, which manages the interaction between the peripherals, components, and computers.

#### Setup
  +	Upload only the OnlineShop project in every problem except Unit Tests
  +	Do not modify the interfaces or their namespaces
  +	Use strong cohesion and loose coupling
  +	Use inheritance and the provided interfaces wherever possible. This includes constructors, method parameters and return types
  +	Do not violate your interface implementations by adding more public methods or properties in the specific class than the interface has defined
  +	Make sure you have no public fields anywhere

### Problem 1.	Structure
You are given interfaces and you have to implement their functionality in the correct classes.

There are 4 types of entities in the application: Product, Component, Peripheral, Computer.

#### Product
The Product is a base class for components, peripherals and computers and it should not be able to be instantiated.
##### Data
  +	Id – int (cannot be less than or equal to 0. In that case, throw ArgumentException with message "Id can not be less or equal than 0.")
  +	Manufacturer – string (cannot be null or whitespace. In that case, throw ArgumentException with message "Manufacturer can not be empty.")
  +	Model – string (cannot be null or whitespace. In that case, throw ArgumentException with message "Model can not be empty.")
  +	Price – decimal (cannot be less than or equal to 0. In that case, throw ArgumentException with message "Price can not be less or equal than 0.")
  +	OverallPerformance – double (cannot be less than or equal to 0. In that case, throw ArgumentException with message "Overall Performance can not be less or equal than 0.")
##### Constructor
A product should take the following values upon initialization:

int id, string manufacturer, string model, decimal price, double overallPerformance
##### Override ToString() method:

"Overall Performance: {overall performance}. Price: {price} - {product type}: {manufacturer} {model} (Id: {id})"
##### Child Classes
There are several concrete types of products:
  +	Component
  +	Peripheral
  +	Computer

#### Component
The Component is a derived class from Product and a base class for any components and it should not be able to be instantiated.
##### Data
  +	Generation – int
##### Constructor
A product should take the following values upon initialization:

int id, string manufacturer, string model, decimal price, double overallPerformance, int generation
##### Override ToString() method:

"Overall Performance: {overall performance}. Price: {price} - {product type}: {manufacturer} {model} (Id: {id}) Generation: {generation}"
##### Child Classes
There are several specific types of components, where the overall performance has a different multiplier:
  +	CentralProcessingUnit - multiplier is 1.25
  +	Motherboard – multiplier is 1.25
  +	PowerSupply – multiplier is 1.05
  +	RandomAccessMemory – multiplier is 1.20
  +	SolidStateDrive – multiplier is 1.20
  +	VideoCard – multiplier is 1.15

Example: If we create the CentralProcessingUnit with overallPerformance – 50, from the constructor, and multiplier 1.25, the overallPerformance should be 62.50.

#### Peripheral
The Peripheral is a derived class from Product and a base class for any peripherals and it should not be able to be instantiated.
##### Data
  +	ConnectionType – string
##### Constructor
A product should take the following values upon initialization:

int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType
##### Override ToString() method:
"Overall Performance: {overall performance}. Price: {price} - {product type}: {manufacturer} {model} (Id: {id}) Connection Type: {connection type}"
##### Child Classes
There are several concrete types of peripherals:
  +	Headset
  +	Keyboard
  +	Monitor
  +	Mouse

#### Computer
The Computer is a derived class from Product and a base class for any computers and it should not be able to be instantiated.
##### Data
  +	Components – IReadOnlyCollection
  +	Peripherals – IReadOnlyCollection
  +	OverallPerformance – override the base functionality (if the components collection is empty, it should return only the computer overall performance, otherwise return the sum of the computer overall performance and the average overall performance from all components)
  +	Price – override the base functionality (The price is equal to the total sum of the computer price with the sum of all component prices and the sum of all peripheral prices)
##### Constructor
A product should take the following values upon initialization:

int id, string manufacturer, string model, decimal price, double overallPerformance
##### Override ToString() method:

"Overall Performance: {overall performance}. Price: {price} - {product type}: {manufacturer} {model} (Id: {id})"

" Components ({components count}):"

"  {component one}"

"  {component two}"

"  {component n}"

" Peripherals ({peripherals count}); Average Overall Performance ({average overall performance peripherals}):"

"  {peripheral one}"

"  {peripheral two}"

"  {peripheral n}"

Note: Be careful, some of the rows have one or two whitespaces at the beginning of the sentences!
##### Behavior
  + void AddComponent(IComponent component)

If the components collection contains a component with the same component type, throw an ArgumentException with the message "Component {component type} already exists in {computer type} with Id {id}."

Otherwise add the component in the components collection.

  + IComponent RemoveComponent(string componentType)

If the components collection is empty or does not have a component of that type, throw an ArgumentException with the message "Component {component type} does not exist in {computer type} with Id {id}."

Otherwise remove the component of that type and return it.

  + void AddPeripheral(IPeripheral peripheral)

If the peripherals collection contains a peripheral with the same peripheral type, throw an ArgumentException with the message "Peripheral {peripheral type} already exists in {computer type} with Id {id}."

Otherwise add the peripheral in peripherals collection.

  + IPeripheral RemovePeripheral(string peripheralType)

If the peripherals collection is empty or does not have a peripheral of that type, throw an ArgumentException with the message "Peripheral {peripheral type} does not exist in {computer type} with Id {id}."

Otherwise remove the peripheral of that type and return it.
##### Child Classes
There are several specific types of computers, where the overall performance has a different value:
  +	DesktopComputer – overall performance is 15
  +	Laptop – overall performance is 10

Child classes should not receive an overall performance as a parameter from the constructor.

### Problem 2.	Business Logic 

#### The Controller Class
The business logic of the program should be concentrated around several commands. You are given interfaces, which you have to implement in the correct classes.

Note: The Controller class SHOULD NOT handle exceptions! The tests are designed to expect exceptions, not messages!

The first interface is the IController. You must create a Controller class, which implements the interface and implements all of its methods. The constructor, of the Controller, does not take any arguments. The given methods should have the logic, described for each in the Commands section.
##### Commands
There are several commands, which control the business logic of the application. They are stated below. 

NOTE: For each command, except for "AddComputer" and "BuyBest", you must check if a computer, with that id, exists in the computers collection. If it doesn't, throw an ArgumentException with the message "Computer with this id does not exist.".
##### AddComputer Command
Parameters
  +	computerType – string
  +	id – int
  +	manufacturer – string
  +	model – string
  +	price – decimal

Functionality

Creates a computer with the correct type and adds it to the collection of computers.

If a computer, with the same id, already exists in the computers collection, throw an ArgumentException with the message "Computer with this id already exists."

If the computer type is invalid, throw an ArgumentException with the message "Computer type is invalid."

If it's successful, returns "Computer with id {id} added successfully.".
##### AddComponent Command
Parameters
  +	computerId – int
  +	id – int
  +	componentType – string
  +	manufacturer – string
  +	model – string
  +	price – decimal
  +	overallPerformance – double
  +	generation – int

Functionality

Creates a component with the correct type and adds it to the computer with that id, then adds it to the collection of components in the controller.

If a component, with the same id, already exists in the components collection, throws an ArgumentException with the message "Component with this id already exists."

If the component type is invalid, throws an ArgumentException with the message "Component type is invalid."

If it's successful, returns "Component {component type} with id {component id} added successfully in computer with id {computer id}.".
##### RemoveComponent Command
Parameters
  +	componentType – string
  +	computerId – int

Functionality

Removes a component, with the given type from the computer with that id, then removes component from the collection of components.

If it's successful, it returns "Successfully removed {component type} with id {component id}.".
##### AddPeripheral Command
Parameters
  +	computerId – int
  +	id – int
  +	peripheralType – string
  +	manufacturer – string
  +	model – string
  +	price – decimal
  +	overallPerformance – double
  +	connectionType – string

Functionality

Creates a peripheral, with the correct type, and adds it to the computer with that id, then adds it to the collection of peripherals in the controller.

If a peripheral, with the same id, already exists in the peripherals collection, it throws an ArgumentException with the message "Peripheral with this id already exists."

If the peripheral type is invalid, throws an ArgumentException with the message "Peripheral type is invalid."

If it's successful, it returns "Peripheral {peripheral type} with id {peripheral id} added successfully in computer with id {computer id}.".
##### RemovePeripheral Command
Parameters
  +	peripheralType – string
  +	computerId – int

Functionality

Removes a peripheral, with the given type from the computer with that id, then removes the peripheral from the collection of peripherals.

If it's successful, it returns "Successfully removed {peripheral type} with id { peripheral id}.".
##### BuyComputer Command
Parameters
  +	id – int

Functionality

Removes a computer, with the given id, from the collection of computers.

If it's successful, it returns ToString method on the removed computer.
##### BuyBest Command
Parameters
  +	budget – decimal

Functionality

Removes the computer with the highest overall performance and with a price, less or equal to the budget, from the collection of computers.

If there are not any computers in the collection or the budget is insufficient for any computer, throws an ArgumentException with the message " Can't buy a computer with a budget of ${budget}."

If it's successful, it returns ToString method on the removed computer.
##### GetComputerData Command
Parameters
  +	id – int

Functionality

If it's successful, it returns ToString method on the computer with the given id.
##### Close Command
Functionality

Ends the program.

#### Input / Output
You are provided with two interfaces, which will help you with the correct execution process of your program. The interface IEngine and the class, implementing this interface, should read the input and when the program finishes, this class should print the output. ICommandInterpreter and CommandInterpreter are responsible for executing a specific command. Call the appropriate method from the controller, and return the result to the engine class.
##### Input
Below, you can see the format in which each command will be given in the input:
  +	AddComputer {computer type} {id} {manufacturer} {model} {price}
  +	AddComponent {computer id} {component id} {component type} {manufacturer} {model} {price} {overall performance} {generation}
  +	RemoveComponent {component type} {computer id}
  +	AddPeripheral {computer id} {peripheral id} { peripheral type} {manufacturer} {model} {price} {overall performance} {connection type}
  +	RemovePeripheral {peripheral type} {computer id}
  +	BuyComputer {id}
  +	BuyBestComputer {budget}
  +	GetComputerData {id}
  +	Close
##### Output
Print the output, from each command, when issued. If an exception is thrown, during any of the commands' execution, print the exception message.
##### Example

| Input     |
| --------- |
| AddComputer Laptop 4 Asus ROG 700 <br> AddComponent 4 3 CentralProcessingUnit Intel Xeon 1600 82 9 <br> AddComponent 4 6 Motherboard Asus ROG 1250 70 8 <br> AddComponent 4 7 PowerSupply Fortron FSP 700 70 2 <br> AddComponent 4 10 RandomAccessMemory Kingston HyperX 900 80 4 <br> AddComponent 4 13 SolidStateDrive Samsung Evo 800 85 7 <br> AddComponent 4 17 VideoCard Nvidia GeForce 2000 97 9 <br> AddPeripheral 4 3 Headset Razer Thresher 300 70 AUX <br> GetComputerData 4 <br> RemovePeripheral Headset 4 <br> BuyComputer 4 <br> Close |

| Output     |
| --------- |
| Computer with id 4 added successfully. <br> Component CentralProcessingUnit with id 3 added successfully in computer with id 4. <br> Component Motherboard with id 6 added successfully in computer with id 4. <br> Component PowerSupply with id 7 added successfully in computer with id 4. <br> Component RandomAccessMemory with id 10 added successfully in computer with id 4. <br> Component SolidStateDrive with id 13 added successfully in computer with id 4. <br> Component VideoCard with id 17 added successfully in computer with id 4. <br> Peripheral Headset with id 3 added successfully in computer with id 4. <br> Overall Performance: 105.51. Price: 8250.00 - Laptop: Asus ROG (Id: 4) <br> &ensp; Components (6): <br> &ensp; &ensp; Overall Performance: 102.50. Price: 1600.00 - CentralProcessingUnit: Intel Xeon (Id: 3) Generation: 9 <br> &ensp; &ensp; Overall Performance: 87.50. Price: 1250.00 - Motherboard: Asus ROG (Id: 6) Generation: 8 <br> &ensp; &ensp; Overall Performance: 73.50. Price: 700.00 - PowerSupply: Fortron FSP (Id: 7) Generation: 2 <br> &ensp; &ensp; Overall Performance: 96.00. Price: 900.00 - RandomAccessMemory: Kingston HyperX (Id: 10) Generation: 4 <br> &ensp; &ensp;  Overall Performance: 102.00. Price: 800.00 - SolidStateDrive: Samsung Evo (Id: 13) Generation: 7 <br> &ensp; &ensp; Overall Performance: 111.55. Price: 2000.00 - VideoCard: Nvidia GeForce (Id: 17) Generation: 9 <br> &ensp; Peripherals (1); Average Overall Performance (70.00): <br> &ensp; &ensp; Overall Performance: 70.00. Price: 300.00 - Headset: Razer Thresher (Id: 3) Connection Type: AUX <br> Successfully removed Headset with id 3. <br> Overall Performance: 105.51. Price: 7950.00 - Laptop: Asus ROG (Id: 4) <br> &ensp; Components (6): <br> &ensp; &ensp; Overall Performance: 102.50. Price: 1600.00 - CentralProcessingUnit: Intel Xeon (Id: 3) Generation: 9 <br> &ensp; &ensp; Overall Performance: 87.50. Price: 1250.00 - Motherboard: Asus ROG (Id: 6) Generation: 8 <br> &ensp; &ensp; Overall Performance: 73.50. Price: 700.00 - PowerSupply: Fortron FSP (Id: 7) Generation: 2 <br> &ensp; &ensp; Overall Performance: 96.00. Price: 900.00 - RandomAccessMemory: Kingston HyperX (Id: 10) Generation: 4 <br> &ensp; &ensp; Overall Performance: 102.00. Price: 800.00 - SolidStateDrive: Samsung Evo (Id: 13) Generation: 7 <br> &ensp; &ensp; Overall Performance: 111.55. Price: 2000.00 - VideoCard: Nvidia GeForce (Id: 17) Generation: 9 <br> &ensp; Peripherals (0); Average Overall Performance (0.00): |

### Problem 3.	Unit Testing 
You will receive a skeleton with one class inside. The class will have some methods, properties, fields and constructors. Cover the whole class with unit test to make sure that the class is working as intended.
