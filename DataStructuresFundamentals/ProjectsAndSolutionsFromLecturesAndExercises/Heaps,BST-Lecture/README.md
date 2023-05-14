## PROBLEMS DESCRIPTION - HEAPS AND BST (Lecture)


### Problem 1.	 Binary Tree

Inside the given skeleton you should implement the AbstractBinaryTree\<T\> class with the following operations: 

  +	string AsIndentedPreOrder(int indent) – returns the tree as a string - each inner level is indented with the requested number of spaces as padding
  +	List\<IAbstractBinaryTree\<T\>\> PreOrder() – returns the tree in pre-order – first we add the visiting node then we continue with the left and right child
  +	List\<IAbstractBinaryTree\<T\>\> InOrder() – returns the tree in in-order – first we move left as much as we can then add the visiting node and then we continue the right child
  +	List\<IAbstractBinaryTree\<T\>\> PostOrder() – returns the tree in post-order – first we move left, then right and at the end as we have no path, we add the visiting node
  +	void ForEachInOrder(Action\<T\> action) – applies an Action on each node traversed in-order

### Problem 2.	Binary Search Tree (BST)

Inside the given skeleton you should implement the BinarySearchTree\<T\> class with the following operations: 

  +	void Insert(T item) – adds an element only if it does not already exist.
  +	bool Contains(T item) – returns a value indicating whether the passed-in element exists in the tree.
  +	IAbstractBinarySearchTree\<T\> Search(T item) – returns a BST with given element value if such exists. If not, returns null.
  +	EachInOrder(Action\<T\>) – applies an action to each element of the tree, traversing it in-order

### Problem 3.	MaxHeap

Inside the given skeleton you should implement the MaxHeap\<T\> class with the following operations: 

  +	int Size – returns the number of elements in the structure 
  +	void Add(T item) – adds an element
  +	T Peek() – returns the maximum element without removing it. If there are no elements, throw an InvalidOperationException.
  +	ExtractMax() – returns the biggest element and removes it. If there are no elements, throw an InvalidOperationException. 