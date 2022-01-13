## PROBLEMS DESCRIPTION - STACKS AND QUEUES (Exercise)


### Problem 1.	Basic Stack Operations
Play around with a stack. You will be given an integer N representing the number of elements to push into the stack, an integer S representing the number of elements to pop from the stack and finally an integer X, an element that you should look for in the stack. If it’s found, print _"true"_ on the console. If it isn't, print the smallest element currently present in the stack. If there are no elements in the sequence, print 0 on the console.

Input
  +	On the first line you will be given N, S and X, separated by a single space
  +	On the next line you will be given N number of integers

Output
  +	On a single line print either _"true"_ if X is present in the stack, otherwise print the smallest element in the stack. If the stack is empty, print 0

Examples

| Input     | Output |
| --------- | -----|
| 5 2 13 <br> 1 13 45 32 4 | true |
| 4 1 666 <br> 420 69 13 666 | 13 |

### Problem 2.	Basic Queue Operations
Play around with a queue. You will be given an integer N representing the number of elements to enqueue (add), an integer S representing the number of elements to dequeue (remove) from the queue and finally an integer X, an element that you should look for in the queue. If it is, print _"true"_ on the console. If it’s not print the smallest element currently present in the queue. If there are no elements in the sequence, print 0 on the console.

Examples

| Input     | Output |
| --------- | -----|
| 5 2 32 <br> 1 13 45 32 4 | true  |
| 4 1 666 <br> 666 69 13 420 | 13 |
| 3 3 90 <br> 90 0 90 | 0 |

### Problem 3.	Maximum and Minimum Element
You have an empty sequence, and you will be given N queries. Each query is one of these three types:

1 x – Push the element x into the stack.

2 – Delete the element present at the top of the stack.

3 – Print the maximum element in the stack.

4 – Print the minimum element in the stack.

After you go through all of the queries, print the stack in the following format: _"{n}, {n1}, {n2} …, {nn}"_

Input
  +	The first line of input contains an integer, N
  +	The next N lines each contain an above-mentioned query. (It is guaranteed that each query is valid)

Output
  +	For each type 3 or 4 query, print the maximum/minimum element in the stack on a new line

Constraints
  +	1 ≤ N ≤ 105
  +	1 ≤ x ≤ 109
  +	1 ≤ type ≤ 4
  +	If there are no elements in the stack, don’t print anything on commands 3 and 4

Examples

| Input     | Output |
| --------- | -----|
| 9 <br> 1 97 <br> 2 <br> 1 20 <br> 2 <br> 1 26 <br> 1 20 <br> 3 <br> 1 91 <br> 4 | 26 <br> 20 <br> 91, 20, 26 |
| 10 <br> 2 <br> 1 47 <br> 1 66 <br> 1 32 <br> 4 <br> 3 <br> 1 25 <br> 1 16 <br> 1 8 <br> 4 | 32 <br> 66 <br> 8 <br> 8, 16, 25, 32, 66, 47 |

### Problem 4.	Fast Food
You have a fast food restaurant and most of the food that you're offering is previously prepared. You need to know if you will have enough food to serve lunch to all of your customers. Write a program that checks the orders’ quantity. You also want to know the client with the biggest order for the day, because you want to give him a discount the next time he comes. 

First, you will be given the quantity of the food that you have for the day (an integer number).  Next, you will be given a sequence of integers, each representing the quantity of an order. Keep the orders in a queue. Find the biggest order and print it. You will begin servicing your clients from the first one that came. Before each order, check if you have enough food left to complete it. If you have, remove the order from the queue and reduce the amount of food you have. If you succeeded in servicing all of your clients, print: _"Orders complete"._  If not, print: _"Orders left: {order1} {order2} .... {orderN}"_.

Input
  +	On the first line you will be given the quantity of your food - an integer in the range [0, 1000]
  +	On the second line you will receive a sequence of integers, representing each order, separated by a single space

Output
  +	Print the quantity of biggest order
  +	Print _"Orders complete"_ if the orders are complete
  +	If there are orders left, print them in the format given above

Constraints
  +	The input will always be valid
  	
Examples

| Input     | Output |
| --------- | -----|
| 348 <br> 20 54 30 16 7 9 | 54 <br> Orders complete |
| 499 <br> 57 45 62 70 33 90 88 76 | 90 <br> Orders left: 76 |

### Problem 5.	Fashion Boutique
You own a fashion boutique and you receive a delivery once a month in a huge box, which is full of clothes. You have to arrange them in your store, so you take the box and start from the last piece of clothing on the top of the pile to the first one at the bottom. Use a stack for the purpose. Each piece of clothing has its value (an integer). You have to sum their values, while you take them out of the box. You will be given an integer representing the capacity of a rack. While the sum of the clothes is less than the capacity, keep summing them. If the sum becomes equal to the capacity you have to take a new rack for the next clothes, if there are any left in the box. If it becomes greater than the capacity, don't add the piece of clothing to the current rack and take a new one. In the end, print how many racks you have used to hang all of the clothes.

Input
  +	On the first line you will be given a sequence of integers, representing the clothes in the box, separated by a single space
  +	On the second line, you will be given an integer, representing the capacity of a rack

Output
  +	Print the number of racks, needed to hang all of the clothes from the box

Constraints
  +	The values of the clothes will be integers in the range [0,20]
  +	There will never be more than 50 clothes in a box
  +	The capacity will be an integer in the range [0,20]
  +	None of the integers from the box will be greater than the value of the capacity

Examples

| Input     | Output |
| --------- | -----|
| 5 4 8 6 3 8 7 7 9 <br> 16 | 5 |
| 1 7 8 2 5 4 7 8 9 6 3 2 5 4 6 <br> 20 | 5 |

### Problem 6.	Songs Queue
Write a program that keeps track of a songs queue. The first song that is put in the queue, should be the first that gets played. A song cannot be added if it is currently in the queue.

You will be given a sequence of songs, separated by a comma and a single space. After that you will be given commands until there are no songs enqueued. When there are no more songs in the queue print _"No more songs!"_ and stop the program.

The possible commands are:
  +	_"Play"_ - plays a song (removes it from the queue)
  +	_"Add {song}"_ - adds the song to the queue if it isn’t contained already, otherwise print _"{song} is already contained!"_
  +	_"Show"_ - prints all songs in the queue separated by a comma and a white space (start from the first song in the queue to the last)

Input
  +	On the first line, you will be given a sequence of strings, separated by a comma and a white space
  +	On the next lines you will be given commands until there are no songs in the queue

Output
  +	While receiving the commands, print the proper messages described above
  +	After the command _"Show"_, print the songs from the first to the last

Constraints
  +	The input will always be valid and in the formats described above
  +	There might be commands even after there are no songs in the queue (ignore them)
  +	There will never be duplicate songs in the initial queue
  
Examples

| Input     | Output |
| --------- | -----|
| All Over Again, Watch Me <br> Play <br> Add Watch Me <br> Add Love Me Harder <br> Add Promises <br> Show <br> Play <br> Play <br> Play <br> Play | Watch Me is already contained! <br> Watch Me, Love Me Harder, Promises <br> No more songs! |

### Problem 7.	Truck Tour
Suppose there is a circle. There are N petrol pumps on that circle. Petrol pumps are numbered 0 to (N−1) (both inclusive). You have two pieces of information corresponding to each of the petrol pump: (1) the amount of petrol that particular petrol pump will give, and (2) the distance from that petrol pump to the next petrol pump.

Initially, you have a tank of infinite capacity carrying no petrol. You can start the tour at any of the petrol pumps. Calculate the first point from where the truck will be able to complete the circle. Consider that the truck will stop at each of the petrol pumps. The truck will move one kilometer for each liter of the petrol.

Input
  +	The first line will contain the value of N
  +	The next N lines will contain a pair of integers each, i.e. the amount of petrol that petrol pump will give and the distance between that petrol pump and the next petrol pump

Output
  +	An integer which will be the smallest index of the petrol pump from which we can start the tour

Constraints
  +	1 ≤ N ≤ 1000001
  +	1 ≤ Amount of petrol, Distance ≤ 1000000000

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> 1 5 <br> 10 3 <br> 3 4 | 1 |

### Problem 8.	Balanced Parentheses
Given a sequence consisting of parentheses, determine whether the expression is balanced. A sequence of parentheses is balanced if every open parenthesis can be paired uniquely with a closed parenthesis that occurs after the former. Also, the interval between them must be balanced. You will be given three types of parentheses: (, {, and [.

{[()]} - This is a balanced parenthesis.

{[(])} - This is not a balanced parenthesis.

Input
  +	Each input consists of a single line, the sequence of parentheses.

Output 
  +	For each test case, print on a new line _"YES"_ if the parentheses are balanced. Otherwise, print _"NO"_. Do not print the quotes.

Constraints
+	1 ≤ lens ≤ 1000, where lens is the length of the sequence.
+	Each character of the sequence will be one of {, }, (, ), [, ].

Examples

| Input     | Output |
| --------- | -----|
| {[()]} | YES |
| {[(])} | NO |
| {{[[(())]]}} | YES |

### Problem 9.	Simple Text Editor
You are given an empty text. Your task is to implement 4 commands related to manipulating the text
  +	1 someString - appends someString to the end of the text
  +	2 count - erases the last count elements from the text
  + 3 index - returns the element at position index from the text
  +	4 - undoes the last not undone command of type 1 / 2 and returns the text to the state before that operation

Input
  +	The first line contains n, the number of operations.
  +	Each of the following n lines contains the name of the operation followed by the command argument, if any, separated by space in the following format _"CommandName Argument"_.

Output
  +	For each operation of type 3 print a single line with the returned character of that operation.

Constraints
  +	1 ≤ N ≤ 105
  +	The length of the text will not exceed 1000000
  +	All input characters are English letters.
  +	It is guaranteed that the sequence of input operation is possible to perform.

Examples

| Input     | Output |
| --------- | -----|
| 8 <br> 1 abc <br> 3 3 <br> 2 3 <br> 1 xy <br> 3 2 <br> 4 <br> 4 <br> 3 1 | c <br> y <br> a |
| 9 <br> 1 <br> HelloThere <br> 3 7 <br> 2 2 <br> 3 5 <br> 4 <br> 3 7 <br> 4 <br> 1 <br> TestPassed <br> 3 5 | h <br> o <br> h <br> P |

### Problem 10.	Crossroads
Our favorite super-spy action hero Sam is back from his mission in the previous exam, and he has finally found some time to go on a holiday. He is taking his wife somewhere nice and they’re going to have a really good time, but first, they have to get there. Even on his holiday trip, Sam is still going to run into some problems and the first one is, of course, getting to the airport. Right now, he is stuck in a traffic jam at a very active crossroads where a lot of accidents happen.

Your job is to keep track of traffic at the crossroads and report whether a crash happened or everyone passed the crossroads safely and our hero is one step closer to a much desired vacation.

The road Sam is on has a single lane where cars queue up until the light goes green. When it does, they start passing one by one during the green light and the free window before the intersecting road’s light goes green. During one second only one part of a car (a single character) passes the crossroads. If a car is still in the crossroads when the free window ends, it will get hit at the first character that is still in the crossroads.

Input
  +	On the first line, you will receive the duration of the green light in seconds – an integer in the range [1-100]
  +	On the second line, you will receive the duration of the free window in seconds – an integer in the range [0-100]
  +	On the following lines, until you receive the _"END"_ command, you will receive one of two things:
    + A car – a string containing any ASCII character, or
    +	The command _"green"_ which indicates the start of a green light cycle
    
A green light cycle goes as follows:
  +	During the green light cars will enter and exit the crossroads one by one
  +	During the free window cars will only exit the crossroads

Output
  +	If a crash happens, end the program and print:

_"A crash happened!"_

_"{car} was hit at {characterHit}."_
  +	If everything goes smoothly and you receive an _"END"_ command, print:

_"Everyone is safe."_

_"{totalCarsPassed} total cars passed the crossroads."_

Constraints
  +	The input will be within the constaints specified above and will always be valid. There is no need to check it explicitly.

Examples

| Input     | Output |
| --------- | -----|
| 10 <br> 5 <br> Mercedes <br> green <br> Mercedes <br> BMW <br> Skoda <br> green <br> END | Everyone is safe. <br> 3 total cars passed the crossroads. |
| 9 <br> 3 <br> Mercedes <br> Hummer <br> green <br> Hummer <br> Mercedes <br> green <br> END | A crash happened! <br> Hummer was hit at e. |

### Problem 11.	Key Revolver
Our favorite super-spy action hero Sam is back from his mission in another exam, and this time he has an even more difficult task. He needs to unlock a safe. The problem is that the safe is locked by several locks in a row, which all have varying sizes.

Our hero posesses a special weapon though, called the Key Revolver, with special bullets. Each bullet can unlock a lock with a size equal to or larger than the size of the bullet. The bullet goes into the keyhole, then explodes, completely destroying it. Sam doesn’t know the size of the locks, so he needs to just shoot at all of them, until the safe runs out of locks.

What’s behind the safe, you ask? Well, intelligence! It is told that Sam’s sworn enemy – Nikoladze, keeps his top secret Georgian Chacha Brandy recipe inside. It’s valued differently across different times of the year, so Sam’s boss will tell him what it’s worth over the radio. One last thing, every bullet Sam fires will also cost him money, which will be deducted from his pay from the price of the intelligence.

Good luck, operative.

Input
  +	On the first line of input, you will receive the price of each bullet – an integer in the range [0-100]
  +	On the second line, you will receive the size of the gun barrel – an integer in the range [1-5000]
  +	On the third line, you will receive the bullets – a space-separated integer sequence with [1-100] integers
  +	On the fourth line, you will receive the locks – a space-separated integer sequence with [1-100] integers
  +	On the fifth line, you will receive the value of the intelligence – an integer in the range [1-100000]

After Sam receives all of his information and gear (input), he starts to shoot the locks front-to-back, while going through the bullets back-to-front.

If the bullet has a smaller or equal size to the current lock, print _"Bang!"_, then remove the lock. If not, print _"Ping!"_, leaving the lock intact. The bullet is removed in both cases.

If Sam runs out of bullets in his barrel, print _"Reloading!"_ on the console, then continue shooting. If there aren’t any bullets left, don’t print it.

The program ends when Sam either runs out of bullets, or the safe runs out of locks.

Output
  +	 If Sam runs out of bullets before the safe runs out of locks, print:
  
_"Couldn't get through. Locks left: {locksLeft}"_
  +	If Sam manages to open the safe, print:

_"{bulletsLeft} bullets left. Earned ${moneyEarned}"_

Make sure to account for the price of the bullets when calculating the money earned.

Constraints
  +	The input will be within the constaints specified above and will always be valid. There is no need to check it explicitly.
  +	There will never be a case where Sam breaks the lock and ends up with а negative balance.

Examples

| Input     | Output |
| --------- | -----|
| 50 <br> 2 <br> 11 10 5 11 10 20 <br> 15 13 16 <br> 1500 | Ping! <br> Bang! <br> Reloading! <br> Bang! <br> Bang! <br> Reloading! <br> 2 bullets left. Earned $1300 |
| 20 <br> 6 <br> 14 13 12 11 10 5 <br> 13 3 11 10 <br> 800 | Bang! <br> Ping! <br> Ping! <br> Ping! <br> Ping! <br> Ping! <br> Couldn't get through. Locks left: 3 |
| 33 <br> 1 <br> 12 11 10 <br> 10 20 30 <br> 100 | Bang! <br> Reloading! <br> Bang! <br> Reloading! <br> Bang! <br> 0 bullets left. Earned $1 |

### Problem 12.	Cups and Bottles
You will be given a sequence of integers – each indicating a cup's capacity. After that you will be given another sequence of integers – a bottle with water in it. Your job is to try to fill up all of the cups.

Filling is done by picking exactly one bottle at a time. You must start picking from the last received bottle and start filling from the first entered cup. If the current bottle has N water, you give the first entered cup N water and reduce its integer value by N.

When a cup's integer value reaches 0 or less, it gets removed. It is possible that the current cup's value is greater than the current bottle's value. In that case you pick bottles until you reduce the cup's integer value to 0 or less. If a bottle's value is greater or equal to the cup's current value, you fill up the cup and the remaining water becomes wasted. You should keep track of the wasted litters of water and print it at the end of the program. 

If you have managed to fill up all of the cups, print the remaining water bottles, from the last entered – to the first, otherwise you must print the remaining cups, by order of entrance – from the first entered – to the last. 

Input
  +	On the first line of input you will receive the integers, representing the cups' capacity, separated by a single space. 
  +	On the second line of input you will receive the integers, representing the filled bottles, separated by a single space.

Output
  +	On the first line of output you must print the remaining bottles, or the remaining cups, depending on the case you are in. Just keep the orders of printing exactly as specified. 
    +	_"Bottles: {remainingBottles}"_ or _"Cups: {remainingCups}"_
  +	On the second line print the wasted litters of water in the following format: _"Wasted litters of water: {wastedLittersOfWater}"_.

Constraints
  +	All of the given numbers will be valid integers in the range [1, 500].
  +	It is safe to assume that there will be NO case in which the water is exactly as much as the cups' values, so that at the end there are no cups and no water in the bottles.
  +	Allowed time/memory: 100ms/16MB.

Examples

| Input     | Output |
| --------- | -----|
| 4 2 10 5 <br> 3 15 15 11 6 | Bottles: 3 <br> Wasted litters of water: 26 |
| 1 5 28 1 4 <br> 3 18 1 9 30 4 5 | Cups: 4 <br> Wasted litters of water: 35 |
| 10 20 30 40 50 <br> 20 11 | Cups: 30 40 50 <br> Wasted litters of water: 1 |
