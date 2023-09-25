## PROBLEMS DESCRIPTION - AVL TREES AND AA-TREES (Exercise)


### Problem 1.	AVL Tree Insertion 

You are given a skeleton that supports the following operations: 

  +	Node\<T\> Root - returns the root of the AVL tree 
  + bool Contains(T item) - checks if an element exists
  +	void EachInOrder(Action\<T\> action) - performs an action in order on each element 
  +	void Insert(T item) - inserts an item into the tree

Your task is to balance the tree after each insertion.

### Problem 2. Implement AVL Tree Deletion

Extend your AVL Tree to support:

  +	void DeleteMin() - deletes the minimum element (balances the tree if necessary) 
  +	void Delete(T item) - deletes the given element (balances the tree if necessary)