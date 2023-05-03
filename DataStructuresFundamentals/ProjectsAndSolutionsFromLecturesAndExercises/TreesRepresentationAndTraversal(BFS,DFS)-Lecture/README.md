## PROBLEMS DESCRIPTION - TREES REPRESENTATION AND TRAVERSAL (BFS AND DFS) (Lecture)


### Problem 1.	 Create Tree

Implement the Tree class's constructor to set the correct key and to be able to build a full tree by accepting all the children for each node and set their parent. 

### Problem 2.	BFS Traversal

Implement the Tree class's OrderBFS() method which should traverse the elements in order of each level sequentially.

### Problem 3.	DFS Traversal

Implement the Tree class's OrderDFS() method which should traverse the elements in terms of descendant before sibling order of each level sequentially. Try to implement it using recursion.

### Problem 4.	Add Child 

Find the Tree node with a specified key and add a child tree to its children. 

You must traverse all the Nodes and find the one with the same key. After that simply attach the child Tree. If the searched node doesn't exist throw an ArgumentNullException.

### Problem 5.	Remove Node

Find a Tree node with a specified key and remove it from the tree. 

If we remove a leaf, we only affect that specific node. If we remove an internal node, we remove the entire subtree that have that node as parent. Simply put, removing a node also removes any descendants of that node. If the searched node doesn't exist throw an ArgumentNullException. If we try to remove the root node, we should throw ArgumentException.

Example:

| Initial Tree | Operation | Result Tree |
| --- | --- | --- |
| ![изображение](https://user-images.githubusercontent.com/82647282/235964463-0036860f-7e0f-467b-b88e-0358a907ff36.png) | Remove(19) | ![изображение](https://user-images.githubusercontent.com/82647282/235964563-dbead45e-6bb8-4e3b-a86e-bc6b45ebe43e.png) |

### Problem 6.	Swap Nodes

This time you must find the Tree nodes with the specified keys and swap them. Swap the two nodes alongside their descendants. If one of the searched nodes doesn't exist throw an ArgumentNullException. Keep in mind that swapping should also arrange the references inside the nodes in a proper way. When swapping a node with it’s own child, remove the node and its descendants and leave only the child that is swapped. If you need to swap the root, throw ArgumentException.

Example:

| Initial Tree | Operation | Result Tree |
| --- | --- | --- |
| ![изображение](https://user-images.githubusercontent.com/82647282/235964903-41ee567b-2f4b-44f1-a789-3cae308d8de7.png) | Swap(19, 14) | ![изображение](https://user-images.githubusercontent.com/82647282/235964982-b44f05ea-71d0-499b-85ec-36a6ab599382.png) |
| ![изображение](https://user-images.githubusercontent.com/82647282/235965040-108642e3-7a1d-488a-9f98-e2ab8e9a537c.png) | Swap(19, 31) | ![изображение](https://user-images.githubusercontent.com/82647282/235965111-ed4c9ebc-7f90-45ee-b2bd-e9366877d9a2.png) |