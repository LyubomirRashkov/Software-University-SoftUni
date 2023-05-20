## PROBLEMS DESCRIPTION


### Problem 1.1	Delivery System

You’ve been tasked with implementing a program for managing a delivery system. The software should work with deliverers, which deliver packages.

You are given a skeleton with a class DeliveriesManager that implements the IDeliveriesManager interface. 

This Delivery System works with Deliverers and Packages as entities. All entities are identified by a unique Id. 

The Deliverer entity contains the following properties:

  +	Id – string
  +	Name – string

The Package entity contains the following properties:

  +	Id – string
  +	Receiver – string 
  +	Address – string
  +	Phone – string
  +	Weight – double

Implement the following functionalities to make the Delivery System software fully operative:

  +	void AddDeliverer(Deliverer deliverer) – adds an deliverer to the Delivery System software.
  +	void AddPackage(Package package) – adds a package to the Delivery System software.
  +	bool Contains(Deliverer deliverer) – returns whether the deliverer is contained inside the Delivery System software.
  +	bool Contains(Package package) – returns whether the package is contained inside the Delivery System software.
  +	IEnumerable\<Deliverer\> GetDeliverers() – returns a collection of all deliverers.
  +	IEnumerable\<Package\> GetPackages() – returns a collection of all packages.
  +	void AssignPackage(Deliverer deliverer, Package package) – assigns the given package to the given deliverer. If the deliverer or the package do not exist in the Delivery System - throw ArgumentException()
  +	IEnumerable\<Package\> GetUnassignedPackages() – returns a collection of all packages, which have not been assigned to any deliverer. 
  +	IEnumerable\<Package\> GetPackagesOrderedByWeightThenByReceiver () – returns all of the packages ordered by weight in descending order, then by receiver in alphabetical (ascending) order. If there aren’t any packages – return an empty collection. 
  +	IEnumerable\<Deliverer\> GetDeliverersOrderedByCountOfPackagesThenByName() – returns all of the deliverers ordered by count of packages in descending order, then by name in alphabetical (ascending) order. If there aren’t any deliverers – return an empty collection.

NOTE: If all sorting criteria fails, you should order by order of input. This is for all methods with ordered output.
### Problem 1.2	Delivery System – Performance

For this task you will only be required to submit the code from the previous problem. If you are having a problem with this task you should perform detailed algorithmic complexity analysis and try to figure out weak spots inside your implementation.

For this problem it is important that other operations are implemented correctly according to the specific problems: add, size, remove, get etc… Also, make sure you are using the correct data structures.

### Problem 2.1	Airlines

You’ve been tasked with implementing a program for managing an airline tracking system. The software should work with airlines and flights.

You are given a skeleton with a class AirlinesManager that implements the IAirlinesManager interface. 

This Airlines System works with Airlines and Flights as entities. All entities are identified by a unique Id. 

The Airline entity contains the following properties:

  +	Id – string
  +	Name – string
  +	Rating - double

The Flight entity contains the following properties:

  +	Id – string
  +	Number – string 
  +	Origin – string
  +	Destination – string
  +	IsCompleted – boolean 

Implement the following functionalities to make the Airlines System software fully operative:

  +	void AddAirline(Airline airline) – adds an airline to the Airlines System software.
  +	void AddFlight(Airline airline, Flight flight) – adds a flight to the given airline in the Airlines System software. If the airline does not exist - throw ArgumentException()
  +	bool Contains(Airline airline) – returns whether the airline is contained inside the Airlines System software.
  +	bool Contains(Flight flight) – returns whether the flight is contained inside the Airlines System software.
  +	void DeleteAirline(Airline airline) – removes the given airline from the Airlines System software and every Flight associated with it. If the airline does not exist - throw ArgumentException()
  +	IEnumerable\<Flight\> GetAllFlights() – returns a collection of all flights.
  +	Flight PerformFlight(Airline airline, Flight flight) – performs the given flight – setting its IsCompleted property to true, and returning it as a result. If the airline or the flight do not exist in the Airline System - throw ArgumentException()
  +	IEnumerable\<Flight\> GetCompletedFlights() – returns a collection of all completed flights.
  +	IEnumerable\<Flight\> GetFlightsOrderedByCompletionThenByNumber() – returns all of the flights ordered by number in asceding (alphabetical) order – flights that are not completed (IsCompleted is false) should be returned first. If there aren’t any flights – return an empty collection. 
  +	IEnumerable\<Airline\> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName() – returns all of the airlines ordered by rating in descending order, then by count of flights in descending order, then by name in ascending (alphabetical) order. If there aren’t any airlines – return an empty collection. 
  +	IEnumerable\<Airline\> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination) – returns all of the airlines which contain atleast 1 flight, which is not completed (IsCompleted is false) and has origin equal to the given one and destination equal to the given one. If there aren’t any eligible results – return an empty collection. 

### Problem 2.2 Airlines – Performance

For this task you will only be required to submit the code from the previous problem. If you are having a problem with this task you should perform detailed algorithmic complexity analysis and try to figure out weak spots inside your implementation.

For this problem it is important that other operations are implemented correctly according to the specific problems: add, size, remove, get etc… Also, make sure you are using the correct data structures.