## PROBLEMS DESCRIPTION - Exam 19 March 2022


### Problem 1.	Dora the Explorer

Dora wants to travel from one city to another as quickly as possible. However, she can’t resist exploring cities that she passes on her way to the destination. That’s why Dora needs you. 

Write a program that finds the fastest path from one city to another keeping in mind that at each step Dora spends X minutes exploring the city.

Input

  +	On the first, you will receive an integer – e – number of cities connections.
  +	On the next e lines, you will receive a connection in the following format: "{first city}, {second city}, {minutes}".
  +	On the next line, you will receive an integer – x – how many minutes Dora spends at each stop.
  +	On the next line, you will receive a start city.
  +	On the last line, you will receive an end city.

Output

  +	Print the total time of the fastest path including the time Dora spends exploring in the following format: "Total time: {totalTime}".
  +	Print all cities that form the fastest path, each on a new line.
  +	Order of the output doesn’t matter.

Constraints

  +	e will be in the range [1… 50].
  +	x will be in the range [1… 180].
  +	You can assume that there will be a path from the start city to the end city.
  +	You can assume that there will be only one fastest path at the end.

Examples

| Input | Output |
| --- | --- |
| 5 <br> 0, 6, 100 <br> 0, 8, 12 <br> 6, 4, 17 <br> 6, 5, 6 <br> 8, 5, 3 <br> 100 <br> 0 <br> 4 | Total time: 217 <br> 0 <br> 6 <br> 4 |
| 5 <br> 0, 6, 100 <br> 0, 8, 12 <br> 6, 4, 17 <br> 6, 5, 6 <br> 8, 5, 3 <br> 10 <br> 0 <br> 4 | Total time: 68 <br> 0 <br> 8 <br> 5 <br> 6 <br> 4 |

### Problem 2. Bitcoin Mining

Bitcoin users can control how quickly their transactions are processed by setting the fee rate. The higher the fee rate, the faster the transaction will be processed. Each block in the blockchain can only contain up to 1MB (1 000 000 bytes) of information. 

Since space is limited, a limited number of transactions can be included in each block. This means Bitcoin miners are incentivized to prioritize the transaction with the highest fees.

Write a program that based on the block capacity, you need to decide which transactions to put in it to maximize the fees of the pending transactions.

Input

  +	On the first line, you will receive an integer – n – number of the pending transactions.
  +	On the next n lines, you will receive a transaction in the following format: "{hash} {size} {fees} {from} {to}".
    +	Size will be in bytes.

Output

  +	Print the used size of the block in the following format: "Total Size: {totalSize}".
  +	Print the total fees of all transactions in the block in the following format: "Total Fees: {totalFees}".
  +	Print transaction hashses that will be included in the block.
    +	Order doesn’t matter.

Constraints

  +	n will be in the range [1… 25].
  +	size will be in the range [0… 1 000 000].
  +	fees will be in the range  [0… 1 000 000].

Examples

| Input | Output |
| --- | --- |
| 5 <br> 25d8dd2f 342000 23213 coinbase.btc atanasov.btc <br> 16d27e46 542000 523213 coinbase.btc shopov.btc <br> 6247072a 242000 13213 coinbase.btc ani.btc <br> fc951abc 600000 113213 procoinbase.btc atanasov.btc <br> 0a4a5f32 450000 153213 procoinbase.btc peter.btc | Total Size: 992000 <br> Total Fees: 676426 <br> 0a4a5f32 <br> 16d27e46 |
| 5 <br> 25d8dd2f 100000 2321 coinbase.btc atanasov.btc <br> 16d27e46 200000 52323 coinbase.btc shopov.btc <br> 6247072a 300000 1323 coinbase.btc ani.btc <br> fc951abc 150000 11323 procoinbase.btc atanasov.btc <br> 0a4a5f32 100000 15313 procoinbase.btc peter.btc | Total Size: 850000 <br> Total Fees: 82603 <br> 0a4a5f32 <br> fc951abc <br> 6247072a <br> 16d27e46 <br> 25d8dd2f |

### Problem 3. The Boring Company

The Boring Company hired you to write an algorithm that calculates the minimum budget required to connect all districts in Las Vegas to the existing tunnel system.

You are given the network of districts (some of them are connected to the tunnel system) along with the estimated connection costs between some districts.

A district can only be connected to the network via a direct connection with an already connected district.

Input

  +	On the first line, you will receive an integer – n – number of distrcits (numbered from 0 to n - 1).
  +	On the second line, you will receive an integer – e – number of connections between the districts.
  +	On the third line, you will receive an integer – p – number of already connected districts to the tunnel system.
  +	On the next e lines, you will receive a connection in the following format: "{first district} {second district} {estimated cost}".
  +	On the next p lines, you will receive already connected districts in the following format: "{first district} {second district}".

Output

  +	Print "Minimum budget: {minBudget}" on the console.

Constraints

  +	n will be in the range [1… 20].
  +	e will be in the range [1… 30].
  +	p will be in the range  [1… 10].
  +	estimated cost will always be in the range [1… 200].

Examples

| Input | Output |
| --- | --- |
| 4 <br> 5 <br> 2 <br> 0 1 9 <br> 0 3 4 <br> 3 1 6 <br> 3 2 11 <br> 1 2 5 <br> 0 3 <br> 3 2 | Minimum budget: 5 |
| 8 <br> 16 <br> 1 <br> 0 1 4 <br> 0 2 5 <br> 0 3 1 <br> 1 2 8 <br> 1 3 2 <br> 2 3 3 <br> 2 4 16 <br> 2 5 9 <br> 3 4 7 <br> 3 5 14 <br> 4 5 12 <br> 4 6 22 <br> 4 7 9 <br> 5 6 6 <br> 5 7 18 <br> 6 7 15 <br> 0 3 | Minimum budget: 36 |