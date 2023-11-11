## PROBLEMS DESCRIPTION


### Problem 1.1	Public Transport Management System

You are given a skeleton with a class PublicTransportRepository that implements the IPublicTransportRepository interface. 

The system works with Passenger and Bus entities. All entities are identified by a unique Id. 

The Passenger entity contains the following properties:

  + Id – string
  +	Name – string

The Bus entity contains the following properties:

  +	Id – string
  +	Number – string 
  +	Capacity – Integer

Implement the following functionalities to make the Public Transport Management System fully operative:
 
  +	void RegisterPassenger(Passenger passenger) - adds a passenger to the system.
  + void AddBus(Bus bus) - adds a bus to the system.
  +	bool Contains(Passenger passenger) - returns whether the passenger is in the system.
  +	bool Contains(Bus bus) - returns whether the bus is in the system.
  +	IEnumerable\<Bus\> GetBuses() - returns a collection of all buses in the system.
  +	void BoardBus(Passenger passenger, Bus bus) - the given passenger boards the given bus. If either the passenger or bus is not in the system - throw ArgumentException().
  +	void LeaveBus(Passenger passenger, Bus bus) - the given passenger leaves the given bus. If either the passenger or bus is not in the system or the passenger is not on the bus - throw ArgumentException().
  +	IEnumerable\<Passenger\> GetPassengersOnBus(Bus bus) - returns a collection of all passengers currently on the given bus.
  +	IEnumerable\<Bus\> GetBusesOrderedByOccupancy() - returns all buses ordered by the number of passengers currently on board in ascending order.
  +	IEnumerable\<Bus\> GetBusesWithCapacity(int capacity) - returns a collection of all buses with a capacity greater than or equal to the given capacity.

NOTE: If all sorting criteria fail, you should order by order of input. This is for all methods with ordered output.

### Problem 1.2	Public Transport Management System - Performance

For this task, you will only be required to submit the code from the previous problem. If you are having a problem with this task you should perform detailed algorithmic complexity analysis and try to figure out weak spots inside your implementation.

For this problem, it is important that other operations are implemented correctly according to the specific problems:  add, size, remove, get, etc… Also, make sure you are using the correct data structures.

### Problem 2.1	Bitcoin Wallet Manager

You are tasked with implementing the data management of a Bitcoin wallet management system. The software should work with Bitcoin transactions, wallets and users as entities. All entities are identified by a unique Id. The entities are defined as follows:

The Transaction entity contains the following properties:

  +	Id – string
  +	SenderWalletId – string (unique Id of the sender's wallet)
  +	ReceiverWalletId – string (unique Id of the receiver's wallet)
  +	Amount – long (amount of Sats involved in the transaction)
  + Timestamp – DateTime

The Wallet entity contains the following properties:

  +	Id – string
  +	UserId – string (unique Id of the user owning the wallet)
  +	Balance – long(total balance of Sats in the wallet)
  +	Transactions – List of Bitcoin Transaction Ids (Ids of transactions associated with this wallet)

The User entity contains the following properties:

  +	Id – string
  +	Name – string
  +	Email – string

Implement the following functionalities to make the Bitcoin wallet management system fully operative:

  +	void CreateUser(User user) – adds a new user to the system.
  +	void CreateWallet(Wallet wallet) – creates a new wallet for a user and adds it to the system.
  +	bool ContainsUser(User user) – returns whether the user is registered in the system.
  +	bool ContainsWallet(Wallet wallet) – returns whether the wallet is present in the system.
  +	IEnumerable\<Wallet\> GetWalletsByUser(string userId) – returns all wallets owned by the given user.
  +	void PerformTransaction(Transaction transaction) – performs a Bitcoin transaction between two wallets, updating their balances accordingly. If neither the sender's nor receiver's wallet is not present in the system or if the sender's wallet balance is insufficient, throw ArgumentException().
  +	IEnumerable\<Transaction\> GetTransactionsByUser(string userId) – returns all Bitcoin transactions associated with the given user (either as a sender or receiver).
  +	IEnumerable\<Wallet\> GetWalletsSortedByBalanceDescending() – returns all wallets ordered by their balances in descending order.
  +	IEnumerable\<User\> GetUsersSortedByBalanceDescending() – returns all users ordered by their balances in descending order.
  +	IEnumerable\<User\> GetUsersByTransactionCount() – returns all users ordered by the total count of transactions they've been involved in (as a sender or receiver) in descending order. If there aren’t any users – return an empty collection.

Please implement the above functionalities in a class named "BitcoinWalletManager" that implements the "IBitcoinWalletManager" interface. The "IBitcoinWalletManager" interface should contain the method signatures for the above functionalities.

NOTE: If all sorting criteria fail, you should order by order of input. This is for all methods with ordered output.

### Problem 2.1	Bitcoin Wallet Manager - Performance

For this task, you will only be required to submit the code from the previous problem. If you are having a problem with this task, you should perform a detailed algorithmic complexity analysis and try to figure out weak spots inside your implementation.

For this problem, it is important that other operations are implemented correctly according to the specific problems:  add, size, remove, get, etc… Also, make sure you are using the correct data structures.