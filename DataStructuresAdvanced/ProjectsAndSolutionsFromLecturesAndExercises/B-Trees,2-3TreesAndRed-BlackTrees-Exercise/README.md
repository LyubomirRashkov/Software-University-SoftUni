## PROBLEMS DESCRIPTION - B-TREES, 2-3-TREES AND RED-BLACK TREES (Exercise)


### Problem 1.	Red-Black Tree

You are given class RedBlackTree\<T\> your task is to implement all the methods with missing implementation:

  +	void Insert(T element) – adds new entry to the tree
  +	int Count() – returns the size of the tree
  +	RedBlackTree\<T\> Search(T element) - search for an element and return the entire subtree 
  +	void DeleteMin() – removes the min element by key in the tree. Throws InvalidOperationException if the tree is empty
  +	void DeleteMax() – removes the max element by key in the tree. Throws InvalidOperationException if the tree is empty
  +	void Delete(T element) – removes the specified element. Throws InvalidOperationException if the tree is empty
  +	void EachInOrder(Action\<T\> action) – iterates the tree and executes the action in-order
