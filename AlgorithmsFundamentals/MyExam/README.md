## PROBLEMS DESCRIPTION


### Problem 1. Bitcoin Miners

You are a Bitcoin miner and you have a pool of n transactions waiting to be added to a block. You want to select x transactions to include in the next block, where x <= n. 

How many different ways can you select x transactions from the pool of n transactions?

Input

  +	The input consists of two lines.
  +	The first line is an integer - n - the number of all transactions in the pool.
  +	The second line is an integer - x - the number of transactions you can pick as a miner.

Output

  +	The output consists of one line - p - the number of ways can you select x transactions from the pool of n transactions

Constraints

  +	n will be an integer in the range [1… 20].
  +	x will be an integer in the range [1… 10].

Examples

| Input | Output |
| --- | --- |
| 10 <br> 3 | 120 |
| 20 <br> 5 | 15504 |

### Problem 2. Chainalysis

You are given a list of Bitcoin transactions, represented as tuples of three elements: (sender, receiver, amount), where sender and receiver are unique Bitcoin addresses, and the amount is a positive integer representing the amount of Bitcoin being transferred. 

Your task is to determine the number of groups of Bitcoin addresses that have participated in at least one transaction with each other.

In other words, given a transaction between two addresses, those addresses are considered to be in the same group. Two addresses that are indirectly connected through other addresses participating in the transactions are also considered to be in the same group.

For example, given the following list of transactions: [('A', 'B', 1), ('B', 'C', 2), ('C', 'D', 3), ('E', 'F', 1), ('F', 'G', 2), ('G', 'H', 3)]. We have 2 groups of Bitcoin addresses.

Input

  +	On the first line, you will receive an integer n - representing the number of transactions.
  +	On the next n lines, you will receive each transaction in the following format: "{from} {to} {amount}"

Output

  +	The output consists of one number - how many groups are found out of all transactions.

Constraints

  +	The input will always be in the format described in the Input section.
  +	Transactions will be unique.
  +	The number of transactions will be in the range [1… 100].
  +	The number of groups will be in the range [1… 100].

Examples

| Input | Output |
| --- | --- |
| 6 <br> A B 1 <br> B C 2 <br> C D 3 <br> E F 1 <br> F G 2 <br> G H 3 | 2 |
| 6 <br> A B 1 <br> B C 2 <br> C D 3 <br> E F 1 <br> F G 2 <br> H K 4 | 3 |

### Problem 3. Bitcoin Transactions

You are given two arrays of Bitcoin transactions, represented as arrays of transaction IDs.

Your task is to find the longest sequence of transaction IDs that appear in both arrays, in the same order but not necessarily contiguous.

For example, consider the following two arrays:

Array 1: ["tx1", "tx2", "tx3", "tx4", "tx5", "tx6", "tx7"]

Array 2: ["tx1", "tx3", "tx5", "tx7", "tx9"]

The longest sequence of transaction IDs that appears in both arrays, in the same order, is ["tx1", "tx3", "tx5", "tx7"], which has a length of 4.

Input

  +	The input consists of 2 lines - arrays of Bitcoin transactions.
  +	Both arrays will be in the following format: "{tx1} {tx2} … {txN}".

Output

  +	Print the best sequence as described in the problem description in the following format: "[{tx1} {tx2} … {txN}]".

Constraints

  +	The input will always be valid.
  +	The array lengths will be in the range [1… 1000].
  +	There might be more than one sequence matching condition described above.
    +	In such a case, you should pick the sequence that starts before others.

Examples

| Input | Output |
| --- | --- |
| tx1 tx2 tx3 tx4 tx5 tx6 tx7 <br> tx1 tx3 tx5 tx7 tx9 | [tx1 tx3 tx5 tx7] |
| tx1 tx2 tx3 tx4 tx5 <br> tx1 tx2 tx3 tx4 tx5 | [tx1 tx2 tx3 tx4 tx5] |