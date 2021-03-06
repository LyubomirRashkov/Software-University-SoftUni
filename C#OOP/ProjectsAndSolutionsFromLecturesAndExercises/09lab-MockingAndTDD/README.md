## PROBLEMS DESCRIPTION - MOCKING AND TEST DRIVEN DEVELOPMENT (Lecture)


### Problem 1.	Mocking - Fake Axe and Dummy
Test if hero gains XP when a target dies. To do this, you need to: 
  +	Make Hero class testable (use Dependency Injection)
  +	Introduce Interfaces for Axe and Dummy
    +	Interface Weapon 
    +	Interface Target 

Create fake Weapon and fake Dummy for the test

### Problem 2.	Test Driven Development - Description
Peter has been struggling lately. He is a major shareholder at one of the largest product manufacturers in the world. As such he is always looking for new ways to improve his game and stay on the top. He has hired you to create a product tracking system for him. He has a lot of products in stock, so you have to make the system fast.
  +	Add(Product) 
    + Add the new manufactured Product in stock. 
  +	Contains(Product) 
    + Checks if a particular product is in stock. Keep in mind that only labels are unique.
  +	Count 
    + Returns the number of products currently in stock.
  +	Find(int)
    + Return the N-th product that was added to stock. The index is based on insertion order in the data structure. If such an index is not present, throw IndexOutOfRangeException.
  +	FindByLabel(string) 
    + Returns the product with a given label, throws ArgumentException if no such product is in stock.
  + FindAllInPriceRange(decimal, decimal)
    + Returns all products within the given price range (lower end and higher end are inclusive). Keep in mind that they should be returned in descending order. If there are no such products, return empty enumeration (collection).
  +	FindAllByPrice(decimal) 
    + Returns all products in stock with given price or empty collection if none were found.
  +	FindMostExpensiveProduct() 
    + Returns the most expensive product in stock.
  +	FindAllByQuantity(int) 
    + Returns all products in stock with the given remaining quantity. If there is no product with an identical quantity, return empty enumeration.
  +	GetEnumerator\<Product\>() 
    + Returns all products in stock.
  +	this[int index]
    + Indexer

  Duplicates of the product class are allowed. That means that the price and quantity of multiple objects might be the same (It is acceptable for the quantity to be 0). 
