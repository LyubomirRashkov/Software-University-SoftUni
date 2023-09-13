## PROBLEMS DESCRIPTION - Exam 26 August 2023


### Problem 1.	TimberMax Dilemma

You are the manager of a lumber company, and you have a collection of long wooden logs that need to be cut into smaller pieces for sale. Each log has a certain length, and you want to maximize the total revenue generated from selling the log pieces. The prices for log pieces are not uniform and vary based on their length.

Write an algorithm to determine the maximum possible revenue that can be obtained by cutting up the logs and selling the pieces. Your algorithm should take into account the varying prices for log pieces and ensure that the pieces are cut in a way that maximizes the total revenue.

Input

  +	On the first line, you will receive a sequence of integers representing the prices for each length of log. The sequence will be in the following format: "{priceLen1} {priceLen2} ... {priceLenN}". 
    +	Each price will always refer to a length equal to its position in the sequence. The first price will be for a length of 1, etc.
    +	The prices will be positive integers.
  +	On the second line, you will receive an integer k, the length of each log you have for cutting.
    +	k will always be a positive integer.

Output

  +	The output consists of a single line containing an integer, which represents the maximum possible revenue that can be obtained by cutting up a single log.

Examples

| Input | Output |
| --- | --- |
| 1 5 8 9 10 <br> 5 | 13 |
| 1 5 8 9 10 17 17 20 24 30 <br> 10 | 30 |

### Problem 2. Data Streaming

A company has a network of computers that are connected by a series of cables. Each cable has a certain capacity, which is the maximum amount of data that can be transferred through it in a given amount of time. 

However, some computers in the network have been corrupted and are blacklisted, meaning they cannot be used to stream or receive streamed data because the data could be leaked. 

The company wants to find the maximum amount of data that can be transferred from a source computer to a destination computer, taking into account the blacklist.

Input and Constraints

  +	On the first line, you will receive an integer n, representing the number of computers in the network.
    +	The computers will be labeled from 0 to n - 1.
  +	On the second line, you will receive an integer c, representing the number of connections between the computers.
  +	The next c lines describe the connections between the computers. Each line contains three space-separated integers: from, to, and capacity. It indicates that there is a cable connecting {computer from} to {computer to} with a maximum capacity of capacity.
  +	Connections between computers are one-way and two computers cannot be connected by more than one cable.
  +	The next line contains a comma-separated list of integers representing the corrupt computers in the network.
    +	The corrupt computers will never be either the source or the destination computers.
    +	There will be always at least one corrupted computer.
  +	The next line contains an integer source, representing the source computer.
  +	The last line contains an integer destination, representing the destination computer.

Output

  +	The output consists of a single line containing an integer, which represents the maximum amount of data that can be transferred.

Examples

| Input | Output |
| --- | --- |
| 6 <br> 9 <br> 0 1 10 <br> 0 2 10 <br> 1 2 2 <br> 2 4 9 <br> 1 4 8 <br> 1 3 4 <br> 4 3 6 <br> 4 5 10 <br> 3 5 10 <br> 2,4 <br> 0 <br> 5 | 4 |
| 4 <br> 5 <br> 0 1 1000 <br> 0 2 1000 <br> 1 2 1 <br> 1 3 1000 <br> 2 3 1000 <br> 1 <br> 0 <br> 3 | 1000 |

### Problem 3. Bitcoin Groups

You are provided with a dataset that represents the Bitcoin network. 

Transactions within this network occur between different wallets, and each transaction is unidirectional, meaning that funds are transferred from one wallet to another. 

Your objective is to develop an algorithm that can identify interconnected groups of wallets and determine the most active group based on the count of wallets it contains. An interconnected group of wallets denotes a collection of wallets wherein there exists a path of transactions connecting any two wallets within the group.

Furthermore, you are required to provide a list of all direct transactions made within the identified group.

Input

  +	On the first line, you will receive an integer - w - number of wallets.
    +	Wallets will be labeled from 0 to w - 1.
  +	On the next line, you will receive an integer - t - number of transactions.
  +	On the next t lines, you will receive all transactions in the following format: "{sender} {receiver}".

Output

  +	Print all transactions in the most active group in the following format: "{sender} -> {receiver}".
  +	The order of the transactions does not matter.

Constraints

  +	There will always be only one group that can be considered "the most active group". 

Examples

| Input | Output |
| --- | --- |
| 14 <br> 20 <br> 0 1 <br> 0 11 <br> 0 13 <br> 1 6 <br> 2 0 <br> 3 4 <br> 4 3 <br> 4 6 <br> 5 13 <br> 6 0 <br> 6 11 <br> 7 12 <br> 8 6 <br> 8 11 <br> 9 0 <br> 10 4 <br> 10 6 <br> 12 7 <br> 13 2 <br> 13 9 | 0 -> 1 <br> 0 -> 13 <br> 9 -> 0 <br> 6 -> 0 <br> 1 -> 6 <br> 2 -> 0 <br> 13 -> 9 <br> 13 -> 2 |
| 3 <br> 4 <br> 0 2 <br> 1 2 <br> 2 0 <br> 2 1 | 0 -> 2 <br> 2 -> 0 <br> 2 -> 1 <br> 1 -> 2 |