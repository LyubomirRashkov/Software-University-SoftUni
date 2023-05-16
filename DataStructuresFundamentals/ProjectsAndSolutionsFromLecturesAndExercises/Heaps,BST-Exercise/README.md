## PROBLEMS DESCRIPTION - HEAPS AND BST (Exercise)


### Problem 1.	BST Operations

You are given a skeleton, in which you have the following operations already implemented:

  +	void Insert(T) – Recursive implementation
  +	void EachInOrder(Action\<T\>) – In-Order traversal
  +	bool Contains(T) – Iterative implementation
  +	BST\<T\> Search(T) – Returns copy of the BST

You have to implement the rest of the operations:

  +	List\<T\> Range(T, T) – Returns collection with the elements found in the BST. Both borders are inclusive.
  +	DeleteMin() – Deletes the smallest element in the tree. 
  +	DeleteMax() – Deletes the max element in the tree.
  +	Delete(T) – Deletes a node with given value.
  +	Count() – Implement a method that returns the count of elements in the BST.
  +	Rank(T) – Implement a method that returns the count of elements smaller than a given value.
  +	Select(int) – Implement a method which accepts a number (n) and returns the first element which has exactly n elements smaller than it. Use the logic from Count() and Rank() to implement it.
  +	Ceiling(T) – Implement a method which finds (returns) the nearest larger value than given in the BST.
  +	Floor(T) – Implement a method which finds (returns) the nearest smaller value than given in the BST.

### Problem 2.	Lowest Common Ancestor

You are given the binary tree and two values V1 and V2. You need to return the lowest common ancestor (LCA) of V1 and V2 in the binary tree. Note that lowest here means in terms of level distance. The closer the node is to both values the lower we say it is. In other words, you can ignore the value you should only care for the distance.

### Problem 3.	Min Heap

Based on the implementation of the MaxHeap\<T\> and ADS Heap\<T\> from the lab implement a data structure that acts and operates the same way, however this time the heap property you want to preserve is the Min heap property.  

Remember you have to throw InvalidOperationException if you attempt to Peek() or ExtractMin() on an empty heap.

#### Implement Decrease Key

In the skeleton there is a PriorityQueue class that extends the MinHeap to support the DecreaseKey(T element) operation, that changes the priority of a given key. In a Min Binary Heap this should increase the priority of a given key, moving it higher in the tree structure.

### Problem 4.	Cookies

We want the sweetness of all his cookies to be greater than value K. To do this, we need to repeatedly mix two cookies with the least sweetness. We create a special combined cookie with sweetness calculated by (least sweet cookie) + (2 * 2nd least sweet cookie).

We repeat this procedure until all the cookies in the collection have a sweetness not less than K.

You are given the cookies. Return the number of operations required to give the cookies a sweetness not less than K. Return -1 if this isn't possible.

Implement the int Solve (int k, int[] cookies) method inside the provided CookiesProblem class.

Input

The first parameter is the K value and the second one is the array representing the cookies.

Output

The method should return a single integer -1 if there is no solution. Otherwise, return the number of operations required to complete the task.

Example

| Input | Output |
| --- | --- |
| 7 <br> 2 3 9 10 12 | 2 |

### Problem 5.	Top View

You are given the binary tree. Print the top view of the binary tree.

The top view means when you look at the tree from the top of the nodes, what you will see will be called the top view of the tree.

Example

![изображение](https://github.com/LyubomirRashkov/Software-University-SoftUni/assets/82647282/f0b65449-a17b-479b-8458-22d37d31fdae)

Given the above tree, the result should be 1, 2, 4, 3, 7, where the order of output does not matter.