## PROBLEMS DESCRIPTION - TREES REPRESENTATION AND TRAVERSAL (BFS AND DFS) (Exercise)


### Problem 1.	Implement Factory Class

Implement the factory class provided in the skeleton. It should return the root of the tree after it builds it.

Example: 

| Input | Output | Tree |
| --- | --- | --- |
| 7 19 <br> 7 21 <br> 7 14 <br> 19 1 <br> 19 12 <br> 19 31 <br> 14 23 <br> 14 6 | Root node: 7 | ![изображение](https://user-images.githubusercontent.com/82647282/235966612-ed81e8d6-61d9-4cea-8b21-4e8a100d4731.png) |

### Problem 2.	Tree As String

Implement the GetAsString method of the Tree class print it in the following format (each level indented +2 spaces).

Example:

| Tree | Output |
| --- | --- |
| ![изображение](https://user-images.githubusercontent.com/82647282/235967030-f6fa0004-3721-4f02-9b64-b821c1b24a17.png) | 7 <br> &ensp; 19 <br> &ensp; &ensp; 1 <br> &ensp; &ensp; 12 <br> &ensp; &ensp; 31 <br> &ensp; 21 <br> &ensp; 14 <br> &ensp; &ensp; 23 <br> &ensp; &ensp; 6 |

### Problem 3.	Get Leaf Keys

Implement the provided method. It should find all leaf nodes and return their keys.

Example:

| Tree | Output |
| --- | --- |
| ![изображение](https://user-images.githubusercontent.com/82647282/235967030-f6fa0004-3721-4f02-9b64-b821c1b24a17.png) | 1 12 31 21 23 6 |

### Problem 4.	Internal Nodes

Implement the provided method. It should find all internal nodes without the root and return their keys.

Example:

| Tree | Output |
| --- | --- |
| ![изображение](https://user-images.githubusercontent.com/82647282/235967030-f6fa0004-3721-4f02-9b64-b821c1b24a17.png) | 19 14 |

### Problem 5.	Deepest Node

Implement the provided method. It should find the deepest node (leftmost) in the tree and return it’s key.

Example:

| Tree | Output |
| --- | --- |
| ![изображение](https://user-images.githubusercontent.com/82647282/235967030-f6fa0004-3721-4f02-9b64-b821c1b24a17.png) | 1 |

### Problem 6.	Longest Path to Root

Implement the provided method. Find the longest path to the root of the tree (the leftmost if several paths have the same longest length).

Example:

| Tree | Output |
| --- | --- |
| ![изображение](https://user-images.githubusercontent.com/82647282/235967030-f6fa0004-3721-4f02-9b64-b821c1b24a17.png) | 7 19 1 |

### Problem 7.	All Paths With a Given Sum

Implement the method provided in the IntegerTree class. Find all paths (from leaf to root or vice-versa) in the tree with a given sum of their nodes (from the leftmost to the rightmost).

Example:

| Input | Tree | Output |
| --- | --- | --- |
| 27 | ![изображение](https://user-images.githubusercontent.com/82647282/235967030-f6fa0004-3721-4f02-9b64-b821c1b24a17.png) | 7 19 1 <br> 7 14 6 |

### Problem 8.	All Subtrees With a Given Sum

Implement the method provided in the IntegerTree class. Find all subtrees with the given sum of their nodes (from the leftmost to the rightmost).

Example:

| Input | Tree | Output |
| --- | --- | --- |
| 43 | ![изображение](https://user-images.githubusercontent.com/82647282/235967030-f6fa0004-3721-4f02-9b64-b821c1b24a17.png) | 14 <br> &ensp; 23 <br> &ensp; 6 |