## PROBLEMS DESCRIPTION


### Problem 1.1	Http Server 

The Http Server is a simple system that stores executable HTTP requests. 

You are given a skeleton with a class HttpListener that implements the IHttpListener interface. 

This HttpServer works with HttpRequests entities. All HttpRequests entities are identified by a unique Id. 

NOTE: The HttpServer should store HTTP requests and executed requests also (as they can be rescheduled)

The HttpRequests entity contains the following properties:

  +	Id – string
  +	Method – string
  +	Expires – long (date in milliseconds after which the response is considered expired), could be null
  +	Host – string

Implement the following functionalities to make HttpListener fully operative:

  +	void AddRequest(HttpRequest request) – adds a pending request. Requests should be stored in order of addition.
  +	void AddPriorityRequest(HttpRequest request) – adds a pending request which should be executed on the next request execution. If the request is already scheduled - throw ArgumentException()
  +	bool Contains(string requestId) – returns whether a pending request exists with such id.
  +	int Size() – returns the total count of all pending requests.
  +	HttpRequest GetRequest(string requestId) – retrieves the pending request with the given id. If there is no such request - throw ArgumentException()
  +	void CancelRequest(string requestId) – completely removes the request from the HttpServer with the given id. If there is no such request - throw ArgumentException()
  +	HttpRequest Execute() – executes the first pending request, removes it from the server and archives it as an executed request and returns the Request as a result. If there is no such request - throw ArgumentException()
  +	HttpRequest RescheduleRequest(string requestId) – reschedules an executed request with the given id, adding it once again to the pool with pending requests and returns the request as a result. If there is no such executed request - throw ArgumentException()
  +	IEnumerable\<HttpRequest\> GetByHost(string host) – returns all pending requests, which are in the given host.
  +	IEnumerable\<HttpRequest\> GetAllExecutedRequests() – returns all unique executed requests.

NOTE: If all sorting criteria fail, you should order by order of input. This is for all methods with ordered output.


### Problem 1.2 Http Server – Performance

For this task, you will only be required to submit the code from the previous problem. If you are having a problem with this task you should perform detailed algorithmic complexity analysis and try to figure out weak spots inside your implementation.

For this problem, it is important that the operations are implemented correctly according to the specific problems: add, size, remove, get, etc… Also, make sure you are using the correct data structures.

### Problem 2.1	Bitcoin Wallet Manager

The Bitcoin Wallet Manager is a system designed to manage and track Bitcoin transactions. It provides a set of functionalities for handling transactions and keeping a record of users' transaction history.

You are given a skeleton class WalletManager that implements the IWalletManager interface. The Bitcoin Wallet Manager works with Transaction entities. Each Transaction is uniquely identified by a Hash.

The Transaction  entity contains the following properties:

  +	Hash - string
  +	From - string (sender's Bitcoin address)
  +	To - string (receiver's Bitcoin address)
  +	Nonce - int

Implement the following functionalities to make Bitcoin Wallet Manager fully operative:

  +	void AddTransaction(Transaction transaction) - This method adds a new Bitcoin transaction to the system. Transactions are stored in the order they are added.
  +	Transaction BroadcastTransaction(string txHash) - This method broadcasts a transaction, marking it as executed and removing it from the system. The method returns the executed transaction. If the provided txHash is not found in the system, it should throw an ArgumentException.
  +	Transaction CancelTransaction(string txHash) - This method cancels a pending transaction, removing it from the system. It returns the canceled transaction. If the provided txHash is not found in the system, it should throw an ArgumentException.
  +	bool Contains(string txHash) - This method checks if a pending transaction with the given txHash exists in the system and returns true if found, false otherwise.
  +	int GetEarliestNonceByUser(string user) - This method returns the earliest nonce value (an integer) for a user's pending transactions where the user is the from address.
  +	IEnumerable\<Transaction\> GetHistoryTransactionsByUser(string user) - This method returns a collection of executed transactions for a given user.
  +	IEnumerable\<Transaction\> GetPendingTransactionsByUser(string user) - This method returns a collection of pending transactions for a given user ordered by Nonce in ascending order.

NOTE: If all sorting criteria fail, you should order by order of input. This is for all methods with ordered output.

### Problem 2.2	Bitcoin Wallet Manager – Performance

For this task you will only be required to submit the code from the previous problem. If you are having a problem with this task you should perform detailed algorithmic complexity analysis and try to figure out weak spots inside your implementation.

For this problem it is important that other operations are implemented correctly according to the specific problems:  add, size, remove, get etc… Also, make sure you are using the correct data structures. 