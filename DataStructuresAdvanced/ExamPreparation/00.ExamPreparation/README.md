## PROBLEMS DESCRIPTION


### Problem 1.1	Microsystem

You have to implement a structure that keeps track of the Microsystem store for computers. Your structure will have to support the following functionalities:

  +	CreateComputer(computer) – you have to create a new computer and add it to the store. If there is already a computer with that number, throw ArgumentException
  +	Contains(int number) – checks if a computer with the provided number exists in the store. 
  +	Count() – returns the count of computers in the store
  +	GetComputer(number) – returns the computer with the given number. If there isn’t such throw ArgumentException.
  +	Remove(int number) – removes the computer with the provided number. If there isn’t such throw ArgumentException
  +	RemoveWithBrand(brand) – removes all computers with the given brand. If there aren’t any throw ArgumentException
  +	UpgradeRam(ram, number) – finds the computer with the given number and sets its ram to the given one (only if the given one is bigger). If there isn’t a computer with the provided number throw ArgumentException
  +	GetAllFromBrand(brand) – finds all computers with the provided brand. Order them by price descending. If there aren’t any return empty collection.
  +	GetAllWithScreenSize(screenSize) – finds all computers with screen size equal to the given. Order them by number descending. If there aren’t any return empty collection.
  +	GetAllWithColor(color) – finds all computers with the same color as the given. Order them by price descending. If there aren’t any return empty collection.
  +	GetInRangePrice(minPrice, maxPrice) – finds all computers with price between the given inclusive. Order them by price descending. If there aren’t any return empty collection.

Feel free to override Equals() and GetHashCode() if necessary.

Input / Output

You are given a Visual Studio C# project skeleton (unfinished project) holding the interface IMicrosystems, the classes Microsystem and Computer. Tests covering the Microsystems functionality and performance.

Your task is to finish this class to make the tests run correctly.

  + You are not allowed to change the tests.
  +	You are not allowed to change the interface.
  +	You can add to the Computer class, but don't remove anything.
  +	You can edit the Microsystems class if it implements the IMicrosystems interface.

### Problem 1.2	Microsystem - Performance

For this task, you will only be required to submit the code from the previous problem. If you are having a problem with this task you should perform detailed algorithmic complexity analysis and try to figure out weak spots inside your implementation.

For this problem, it is important that other operations are implemented correctly according to the specific problems:  add, size, remove, get, etc… Also, make sure you are using the correct data structures.

### Problem 2.1	Vani Planning

Your task is to implement a simple system for invoice processing.                                                                                       

You have a class Invoice which has the following properties:

  +	String SerialNumber – unique number for each invoice
  +	String CompanyName – the invoice company name
  +	Double Subtotal – the subtotal of the invoice
  +	Enum Department – the department to which the invoice belongs
  +	DateTime IssueDate – the date when the invoice was created
  +	DateTime DueDate – the deadline for the invoice

You need to support the following operations (and they should be fast):

  +	Create(Invoice)– Add the invoice to the agency archive. You will need to implement the Contains() method as well. If the invoice number already exists throw ArgumentException
  +	Contains(number) – checks if an invoice with the given number is present in the archive
  +	Count – returns the number of invoices in the archive
  +	PayInvoice(dueDate) – find all invoices whose due date is exactly the given one and set their subtotal to 0. If there aren’t any throw ArgumentException.
  +	ThrowInvoice(SerialNumber) – remove the invoice with the given number. If the invoice doesn’t exist throw ArgumentException
  +	ThrowPayed() – remove all invoices which were payed
  +	GetAllInvoiceInPeriod(start, end) – find all invoices which were created in the given period inclusive. Order them by date of creating ascending, then by due date as second parameter ascending. If there aren’t any return empty collection.
  +	SearchBySerialNumber (String SerialNumber) – return all invoices whose number contains the given one. Order them by their number descending. If there aren’t any throw ArgumentException
  +	ThrowInvoiceInPeriod(start, end)– remove all invoices which have due date between the given range exclusive. If there aren’t any throw ArgumentException.
  +	GetAllFromDepartment(department) – finds all invoices in the provided department. Order them by subtotal descending as first parameter, then by creating date ascending. If there aren’t any return empty collection.
  +	GetAllByCompany(company) – finds all invoices created by the given company. Order them by their number descending. If there aren’t any return empty collection.
  +	ExtendDeadline(dueDate, days) – find all invoices whose due date is equal to the given one and extend their due date by the days given. If there aren’t any throw ArgumentException.

Feel free to override Equals() and GetHashCode() if necessary.

Input / Output

You are given a Visual Studio C# project skeleton (unfinished project) holding the interface IAgency, the classes Agency and Invoice. Tests covering the Agency functionality and performance.

Your task is to finish this class to make the tests run correctly.

  +	You are not allowed to change the tests.
  +	You are not allowed to change the interface.
  +	You can add to the Invoice class, but don't remove anything.
  +	You can edit the Agency class if it implements the IAgency interface.

### Problem 2.2	Vani Planning - Performance

For this task, you will only be required to submit the code from the previous problem. If you are having a problem with this task you should perform detailed algorithmic complexity analysis and try to figure out weak spots inside your implementation.

For this problem, it is important that other operations are implemented correctly according to the specific problems:  add, size, remove, get, etc… Also, make sure you are using the correct data structures.