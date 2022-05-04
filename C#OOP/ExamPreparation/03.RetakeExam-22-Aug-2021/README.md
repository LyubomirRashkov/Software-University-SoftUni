## PROBLEMS DESCRIPTION


#### Overview
Space Missions are very interesting and you have been sent to such one. Your mission is create a Space Station project, which navigates astronauts missions for collecting items from a foreign planet. The Space Station has Astronauts with different professional speacialties and their capability to survive in open space differs according to their essential needs, like the need for oxygen. Your task is to send them on missions and collect items from the different planets.

#### Setup
  +	Upload only the SpaceStation project in every problem except Unit Tests
  +	Do not modify the interfaces or their namespaces
  +	Use strong cohesion and loose coupling
  +	Use inheritance and the provided interfaces wherever possible. This includes constructors, method parameters and return types
  +	Do not violate your interface implementations by adding more public methods or properties in the concrete class than the interface has defined
  +	Make sure you have no public fields anywhere

### Problem 1.	Structure
You are given 5 interfaces, and you have to implement their functionality in the correct classes.

There are 4 types of entities in the application: Astronaut, Backpack, Mission, Planet. There should also have be a AstronautRepository, as well as PlanetRepository.
#### Astronaut
Astronaut is a base class or any type of astronaut and it should not be able to be instantiated.
##### Data
  +	Name – string 
    +	If the name is null or whitespace, throw an ArgumentNullException with message: "Astronaut name cannot be null or empty."
    +	All names are unique
  +	Oxygen –  double
    +	The oxygen of аn astronaut
    +	If the oxygen is below 0, throw an ArgumentException with message: "Cannot create Astronaut with negative oxygen!"
  +	CanBreath – calculated property, which returns bool
  +	Bag – IBag
    +	A property of type Backpack
##### Behavior
virtual void Breath()
  + The Breath() method decreases astronauts' oxygen. Keep in mind that some types of Astronaut can implement the method in a different way. 
    +	The method decreases the astronauts' oxygen by 10 units.
    +	Astronaut's oxygen should not drop below zero
##### Constructor
An Astronaut should take the following values upon initialization: 

string name, double oxygen
##### Child Classes
There are several concrete types of Astronaut:

#### Biologist
Has 70 initial units of oxygen.

Constructor should take the following values upon initialization:

string name
##### Behavior
void Breath()

The breath method decreases the biologists' oxygen by 5 units.

#### Geodesist
Has 50 initial units of ogyxen.

Constructor should take the following values upon initialization:

string name

#### Meteorologist
Has initial 90 units of oxygen.

Constructor should take the following values upon initialization:

string name

#### Backpack
The Backpack is class that holds collection of items. It should be able to be instantiated.
##### Data
  +	Items – a collection of strings
##### Constructor
The constructor should not take any values upon initialization.

#### Planet
The Planet is a class that holds information about the items that can be found on its surface. It should be able to be instantiated.
##### Data
  +	Name – string
    +	If the name is null or whitespace, throw an ArgumentNullException with message: "Invalid name!"
  +	Items – a collection of strings
##### Constructor
The constructor should take the following values upon initialization:

string name

#### Mission
The Mission class holds the main action, which is the Explore method. 
##### Behavior
void Explore(IPlanet planet, ICollection\<IAstronaut\> astronauts)

Here is how the Explore method works:
  +	The astronauts start going out in open space one by one. They can't go, if they don't have any oxygen left.
  +	An astronaut lands on a planet and starts collecting its items one by one. 
  +	He finds an item and he takes a breath.
  +	He adds the item to his backpack and respectively the item must be removed from the planet.
  +	Astronauts can't keep collecting items if their oxygen becomes 0.
  +	If it becomes 0, the next astronaut starts exploring.

#### AstronautRepository
The astronaut repository is a repository for the astronauts that are on the Space Station.
##### Data
  +	Models – a collection of astronauts (unmodifiable)
##### Behavior
  + void Add(IAstronaut astronaut)
    +	Adds an astronaut in the Space Station.
    +	Every astronaut is unique and it is guaranteed that there will not be an astronaut with the same name.
  + bool Remove(IAstronaut astronaut)
    +	Removes an astronaut from the collection. Returns true if the deletion was sucessful.
  + IAstronaut FindByName(string name)
    +	Returns an astronaut with that name, if he exists. If he doesn't, returns null.

#### PlanetRepository
The planet repository is a repository for planets that await to be explored.
##### Data
  +	Models – a collection of planets (unmodifiable)
##### Behavior
  + void Add(IPlanet planet)
    +	Adds a planet for exploration.
    +	Every planet is unique and it is guaranteed that there will not be a planet with the same name.
  + bool Remove(IPlanet planet)
    +	Removes a planet from the collection. Returns true if the deletion was sucessful.
  +IPlanet FindByName(string name)
    +	Returns a planet with that name. 
    +	It is guaranteed that the planet exists in the collection.

### Problem 2.	Business Logic 
#### The Controller Class
The business logic of the program should be concentrated around several commands. You are given interfaces, which you have to implement in the correct classes.

Note: The Controller class SHOULD NOT handle exceptions! The tests are designed to expect exceptions, not messages!

The first interface is IController. You must create a Controller class, which implements the interface and implements all of its methods. The constructor of Controller does not take any arguments. The given methods should have the following logic:
##### Commands
There are several commands, which control the business logic of the application. They are stated below.
##### AddAstronaut Command
Parameters
  +	type – string
  +	astronautName - string

Functionality

Creates an astronaut with the given name of the given type. If the astronaut is invalid, throw an InvalidOperationException with message: "Astronaut type doesn't exists!"

The method should return the following message: "Successfully added {astronautType}: {astronautName}!"
##### AddPlanet Command
Parameters
  +	planetName - string
  +	items – params[] string

Functionality

Creates a planet with the provided items and name. 

When the planet is created, keep it and return the following message: "Successfully added Planet: {planetName}!". 
##### RetireAstronaut Command
Parameters
  +	astronautName – string

Functionality

Retires the astronaut from the space station by removing it from its repository. If an astronaut with that name doesn't exist, throw InvalidOperationException with return the following message: "Astronaut {astronautName} doesn't exists!"
 
If an astronaut is successfully retired, remove it from the repository and return the following message: "Astronaut {astronautName} was retired!"
##### ExplorePlanet Command
Parameters
  +	planetName - string

Functionality

When the explore command is called, the action happens. You should start exploring the given planet, by sending the astronauts that are most suitable for the mission:
  +	You call each of the astronauts and pick only the ones that have oxygen above 60 units.
  +	You send the suitable astronauts on a mission to explore the planet.
  +	If you don't have any suitable astronauts, throw an InvalidOperationException with the following message: "You need at least one astronaut to explore the planet"
  +	After a mission, you must return the following message, with the name of the explored planet and the count of the astronauts that had given their lives for the mission: "Planet: {planetName} was explored! Exploration finished with {deadAstronauts} dead astronauts!"
##### Report Command
Functionality

Returns the information about the astronauts. If any of them doesn't have bag items, print "none" instead.

"{exploredPlanetsCount} planets were explored!

Astronauts info:

Name: {astronautName}

Oxygen: {astronautOxygen}

Bag items: {bagItem1, bagItem2, …, bagItemn} / none

…

Name: {astronautName}

Oxygen: {astronautOxygen}

Bag items: {bagItem1, bagItem2, …, bagItemn} / none"

Note: Use \r\n or Environment.NewLine for a new line.
##### Exit Command
Functionality

Ends the program.

#### Input / Output
You are provided with one interface, which will help you with the correct execution process of your program. The interface is IEngine and the class implementing this interface should read the input and when the program finishes, this class should print the output.
##### Input
Below, you can see the format in which each command will be given in the input:
  +	AddAstronaut {astronautType} {astronautName}
  +	AddPlanet {planetName} {item1} {item2}… {itemN}
  +	RetireAstronaut {astronautName}
  +	ExplorePlanet {planetName}
  +	Report
  +	Exit
##### Output
Print the output from each command when issued. If an exception is thrown during any of the commands' execution, print the exception message.
##### Examples

| Input     |
| --------- |
| AddAstronaut Biologist Oliver <br> AddAstronaut Geodesist Jake <br> AddAstronaut Meteorologist James <br> AddAstronaut Biologist Michael <br> AddAstronaut Meteorologist David <br> AddAstronaut Meteorologist Thomas <br> AddAstronaut Engineer Alexander <br> AddPlanet Mercury <br> AddPlanet Mars Carbon <br> RetireAstronaut David <br> ExplorePlanet Mars <br> Report <br> Exit |

| Output     |
| --------- |
| Successfully added Biologist: Oliver! <br> Successfully added Geodesist: Jake! <br> Successfully added Meteorologist: James! <br> Successfully added Biologist: Michael! <br> Successfully added Meteorologist: David! <br> Successfully added Meteorologist: Thomas! <br> Astronaut type doesn't exists! <br> Successfully added Planet: Mercury! <br> Successfully added Planet: Mars! <br> Astronaut David was retired! <br> Planet: Mars was explored! Exploration finished with 0 dead astronauts! <br> 1 planets were explored! <br> Astronauts info: <br> Name: Oliver <br> Oxygen: 65 <br> Bag items: Carbon <br> Name: Jake <br> Oxygen: 50 <br> Bag items: none <br> Name: James <br> Oxygen: 90 <br> Bag items: none <br> Name: Michael <br> Oxygen: 70 <br> Bag items: none <br> Name: Thomas <br> Oxygen: 90 <br> Bag items: none |


| Input     |
| --------- |
| AddAstronaut Geodesist Jake <br> AddPlanet Mars Carbon <br> ExplorePlanet Mars <br> Report <br> AddAstronaut Biologist Jack <br> AddAstronaut Meteorologist Liam <br> AddAstronaut Biologist Michael <br> AddAstronaut Meteorologist David <br> AddAstronaut Meteorologist Thomas <br> AddPlanet Jupiter Titanium Quartz Aluminium Azurnium Cobalt Copper Iron Lead Lithium Plutonium Mercury Nickel Magnesium Diamond Gold Carbon <br> RetireAstronaut David <br> RetireAstronaut William <br> ExplorePlanet Jupiter <br> Report <br> Exit |

| Output     |
| --------- |
| Successfully added Geodesist: Jake! <br> Successfully added Planet: Mars! <br> You need at least one astronaut to explore the planet! <br> 0 planets were explored! <br> Astronauts info: <br> Name: Jake <br> Oxygen: 50 <br> Bag items: none <br> Successfully added Biologist: Jack! <br> Successfully added Meteorologist: Liam! <br> Successfully added Biologist: Michael! <br> Successfully added Meteorologist: David! <br> Successfully added Meteorologist: Thomas! <br> Successfully added Planet: Jupiter! <br> Astronaut David was retired! <br> Astronaut William doesn't exists! <br> Planet: Jupiter was explored! Exploration finished with 1 dead astronauts! <br> 1 planets were explored! <br> Astronauts info: <br> Name: Jake <br> Oxygen: 50 <br> Bag items: none <br> Name: Jack <br> Oxygen: 0 <br> Bag items: Titanium, Quartz, Aluminium, Azurnium, Cobalt, Copper, Iron, Lead, Lithium, Plutonium, Mercury, Nickel, Magnesium, Diamond <br> Name: Liam <br> Oxygen: 70 <br> Bag items: Gold, Carbon <br> Name: Michael <br> Oxygen: 70 <br> Bag items: none <br> Name: Thomas <br> Oxygen: 90 <br> Bag items: none |

### Problem 3.	Unit Tests 
You will receive a skeleton with Hero and HeroRepository classes inside. The class will have some methods, fields and one constructor, which are working properly. You are NOT ALLOWED to change any class. Cover the whole class with unit tests to make sure that the class is working as intended.

You are provided with a unit test project in the project skeleton.

Do NOT use Mocking in your unit tests!
