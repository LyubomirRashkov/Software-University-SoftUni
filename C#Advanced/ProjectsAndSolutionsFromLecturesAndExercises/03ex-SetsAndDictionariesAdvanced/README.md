## PROBLEMS DESCRIPTION - SETS AND DICTIONARIES ADVANCED (Exercise)


### Problem 1.	Unique Usernames
Create a program that reads from the console a sequence of N usernames and keeps a collection only of the unique ones. On the first line you will be given an integer N. On the next N lines, you will receive one username per line. Print the collection on the console in order of insertion.

Examples

| Input     | Output |
| --------- | -----|
| 6 <br> John <br> John <br> John <br> Peter <br> John <br> Boy1234 | John <br> Peter <br> Boy1234 |
| 10 <br> Peter <br> Maria <br> Peter <br> George <br> Sam <br> Maria <br> Sara <br> Peter <br> Sam <br> George | Peter <br> Maria <br> George <br> Sam <br> Sara |

### Problem 2.	Sets of Elements
Create a program that prints a set of elements. On the first line you will receive two numbers - n and m, which represent the lengths of two separate sets. On the next n + m lines you will receive n numbers, which are the numbers in the first set, and m numbers, which are in the second set. Find all the unique elements that appear in both of them and print them in the order in which they appear in the first set - n.

For example:

Set with length n = 4: {1, 3, 5, 7}

Set with length m = 3: {3, 4, 5}

Set that contains all the elements that repeat in both sets -> {3, 5}

Examples

| Input     | Output |
| --------- | -----|
| 4 3 <br> 1 <br> 3 <br> 5 <br> 7 <br> 3 <br> 4 <br> 5 | 3 5 |
| 2 2 <br> 1 <br> 3 <br> 1 <br> 5 | 1 |

### Problem 3.	Periodic Table
Create a program that keeps all the unique chemical elements. On the first line you will be given a number n - the count of input lines that you are going to receive. On the next n lines, you will be receiving chemical compounds, separated by a single space. Your task is to print all the unique ones in ascending order.

Examples

| Input     | Output |
| --------- | -----|
| 4 <br> Ce O <br> Mo O Ce <br> Ee <br> Mo | Ce Ee Mo O |
| 3 <br> Ge Ch O Ne <br> Nb Mo Tc <br> O Ne | Ch Ge Mo Nb Ne O Tc |

### Problem 4.	Even Times
Create a program that prints a number from a collection, which appears an even number of times in it. On the first line, you will be given n – the count of integers you will receive. On the next n lines, you will be receiving the numbers. It is guaranteed that only one of them appears an even number of times. Your task is to find that number and print it in the end.

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> 2 <br> -1 <br> 2 | 2 |
| 5 <br> 1 <br> 2 <br> 3 <br> 1 <br> 5 | 1 |

### Problem 5.	Count Symbols
Create a program that reads some text from the console and counts the occurrences of each character in it. Print the results in alphabetical (lexicographical) order. 

Examples

| Input     | Output |
| --------- | -----|
| SoftUni rocks |  : 1 time/s <br> S: 1 time/s <br> U: 1 time/s <br> c: 1 time/s <br> f: 1 time/s <br> i: 1 time/s <br> k: 1 time/s <br> n: 1 time/s <br> o: 2 time/s <br> r: 1 time/s <br> s: 1 time/s <br> t: 1 time/s |
| Did you know Math.Round rounds to the nearest even integer? |  : 9 time/s <br> .: 1 time/s <br> ?: 1 time/s <br> D: 1 time/s <br> M: 1 time/s <br> R: 1 time/s <br> a: 2 time/s <br> d: 3 time/s <br> e: 7 time/s <br> g: 1 time/s <br> h: 2 time/s <br> i: 2 time/s <br> k: 1 time/s <br> n: 6 time/s <br> o: 5 time/s <br> r: 3 time/s <br> s: 2 time/s <br> t: 5 time/s <br> u: 3 time/s <br> v: 1 time/s <br> w: 1 time/s <br> y: 1 time/s |

### Problem 6.	Wardrobe
Create a program that helps you decide what clothes to wear from your wardrobe. You will receive the clothes, which are currently in your wardrobe, sorted by their color in the following format: _"{color} -> {item1},{item2},{item3}…"_

If you receive a certain color, which already exists in your wardrobe, just add the clothes to its records. You can also receive repeating items for a certain color and you have to keep their count.

In the end, you will receive a color and a piece of clothing, which you will look for in the wardrobe, separated by a space in the following format: _"{color} {clothing}"_

Your task is to print all the items and their count for each color in the following format: 

_"{color} clothes:_

_* {item1} - {count}_

_* {item2} - {count}_

_* {item3} - {count}_

_…_

_* {itemN} - {count}"_

If you find the item you are looking for, you need to print _"(found!)"_ next to it: _"* {itemN} - {count} (found!)"_

Input
  +	On the first line, you will receive n - the number of lines of clothes, which you will receive.
  + On the next n lines, you will receive the clothes in the format described above.

Output
  +	Print the clothes from your wardrobe in the format described above

Examples

| Input     | Output |
| --------- | -----|
| 4 <br> Blue -> dress,jeans,hat <br> Gold -> dress,t-shirt,boxers <br> White -> briefs,tanktop <br> Blue -> gloves <br> Blue dress | Blue clothes: <br> * dress - 1 (found!) <br> * jeans - 1 <br> * hat - 1 <br> * gloves - 1 <br> Gold clothes: <br> * dress - 1 <br> * t-shirt - 1 <br> * boxers - 1 <br> White clothes: <br> * briefs - 1 <br> * tanktop - 1 |
| 4 <br> Red -> hat <br> Red -> dress,t-shirt,boxers <br> White -> briefs,tanktop <br> Blue -> gloves <br> White tanktop | Red clothes: <br> * hat - 1 <br> * dress - 1 <br> * t-shirt - 1 <br> * boxers - 1 <br> White clothes: <br> * briefs - 1 <br> * tanktop - 1 (found!) <br> Blue clothes: <br> * gloves - 1 |

### Problem 7.	The V-Logger
Create a program that keeps information about vloggers and their followers. The input will come as a sequence of strings, where each string will represent a valid command. The commands will be presented in the following format:
  +	_"{vloggername}" joined The V-Logger_ – keep the vlogger in your records.
    +	Vloggernames consist of only one word.
    +	If the given vloggername already exists, ignore that command.
  +	_"{vloggername} followed {vloggername}"_ – The first vlogger followed the second vlogger.
    +	If any of the given vlogernames does not exist in you collection, ignore that command.
    +	Vlogger cannot follow himself
    +	Vlogger cannot follow someone he is already a follower of
  +	_"Statistics"_ - Upon receiving this command, you have to print a statistic about the vloggers.

Each vlogger has an unique vloggername. Vloggers can follow other vloggers and a vlogger can follow as many other vloggers as he wants, but he cannot follow himself or follow someone he is already a follower of. You need to print the total count of vloggers in your collection. Then you have to print the most famous vlogger – the one with the most followers, with his followers. If more than one vloggers have the same number of followers, print the one following less people and his followers should be printed in lexicographical order (in case the vlogger has no followers, print just the first line, which is described below). Lastly, print the rest vloggers, ordered by the count of followers in descending order, then by the number of vloggers he follows in ascending order. The whole output must be in the following format:

_"The V-Logger has a total of {registered vloggers} vloggers in its logs._

_1. {mostFamousVlogger} : {followers} followers, {followings} following_

_*  {follower1}_

_*  {follower2} …_

_{No}. {vlogger} : {followers} followers, {followings} following_

_{No}. {vlogger} : {followers} followers, {followings} following…"_

Input
  +	The input will come in the format described above.

Output
  +	On the first line, print the total count of vloggers in the format described above.
  +	On the second line, print the most famous vlogger in the format described above.
  +	On the next lines, print all of the rest vloggers in the format described above.

Constraints
  +	There will be no invalid input.
  +	There will be no situation where two vloggers have equal count of followers and equal count of followings
  +	Allowed time/memory: 100ms/16MB.

Examples

| Input     | Output |
| --------- | -----|
| EmilConrad joined The V-Logger <br> VenomTheDoctor joined The V-Logger <br> Saffrona joined The V-Logger <br> Saffrona followed EmilConrad <br> Saffrona followed VenomTheDoctor <br> EmilConrad followed VenomTheDoctor <br> VenomTheDoctor followed VenomTheDoctor <br> Saffrona followed EmilConrad <br> Statistics | The V-Logger has a total of 3 vloggers in its logs. <br> 1. VenomTheDoctor : 2 followers, 0 following <br> *  EmilConrad <br> *  Saffrona <br> 2. EmilConrad : 1 followers, 1 following <br> 3. Saffrona : 0 followers, 2 following |
| JennaMarbles joined The V-Logger <br> JennaMarbles followed Zoella <br> AmazingPhil joined The V-Logger <br> JennaMarbles followed AmazingPhil <br> Zoella joined The V-Logger <br> JennaMarbles followed Zoella <br> Zoella followed AmazingPhil <br> Christy followed Zoella <br> Zoella followed Christy <br> JacksGap joined The V-Logger <br> JacksGap followed JennaMarbles <br> PewDiePie joined The V-Logger <br> Zoella joined The V-Logger <br> Statistics | The V-Logger has a total of 5 vloggers in its logs. <br> 1. AmazingPhil : 2 followers, 0 following <br> *  JennaMarbles <br> *  Zoella <br> 2. Zoella : 1 followers, 1 following <br> 3. JennaMarbles : 1 followers, 2 following <br> 4. PewDiePie : 0 followers, 0 following <br> 5. JacksGap : 0 followers, 1 following |

### Problem 8.	Ranking
Create a program that ranks candidate-interns, depending on the points from the interview tasks and their exam results in SoftUni. You will receive some lines of input in the format _"{contest}:{password for contest}"_ until you receive _"end of contests"_. Save that data because you will need it later. After that you will receive other type of inputs in format _"{contest}=>{password}=>{username}=>{points}"_ until you receive _"end of submissions"_. Here is what you need to do:
  +	Check if the contest is valid (if you received it in the first type of input)
  +	Check if the password is correct for the given contest
  +	Save the user with the contest they take part in (a user can take part in many contests) and the points the user has in the given contest. If you receive the same contest and the same user, update the points only if the new ones are more than the older ones.

At the end you have to print the info for the user with the most points in the format: _"Best candidate is {user} with total {total points} points."_. After that print all students ordered by their names. For each user, print each contest with the points in descending order in the following format:

_"{user1 name}_

_\#  {contest1} -> {points}_

_\#  {contest2} -> {points}_

_{user2 name}_

_…_"

Input
  +	You will be receiving strings in formats described above, until the appropriate commands, also described above, are given.

Output
  +	On the first line print the best user in the format described above. 
  +	On the next lines print all students ordered as mentioned above in format.

Constraints
  +	There will be no case with two equal contests.
  +	The strings may contain any ASCII character except from (:, =, >).
  +	The numbers will be in range [0 - 10000].
  +	The second input is always valid.
  +	There will be no case with 2 or more users with same total points.

Examples

| Input     | Output |
| --------- | -----|
| Part One Interview:success <br> Js Fundamentals:JSFundPass <br> C# Fundamentals:fundPass <br> Algorithms:fun <br> end of contests <br> C# Fundamentals=>fundPass=>Tanya=>350 <br> Algorithms=>fun=>Tanya=>380 <br> Part One Interview=>success=>Nikola=>120 <br> Java Basics Exam=>JSFundPass=>Parker=>400 <br> Part One Interview=>success=>Tanya=>220 <br> OOP Advanced=>password123=>BaiIvan=>231 <br> C# Fundamentals=>fundPass=>Tanya=>250 <br> C# Fundamentals=>fundPass=>Nikola=>200 <br> Js Fundamentals=>JSFundPass=>Tanya=>400 <br> end of submissions | Best candidate is Tanya with total 1350 points. <br> Ranking: <br> Nikola <br> #  C# Fundamentals -> 200 <br> #  Part One Interview -> 120 <br> Tanya <br> #  Js Fundamentals -> 400 <br> #  Algorithms -> 380 <br> #  C# Fundamentals -> 350 <br> #  Part One Interview -> 220 |
| Java Advanced:funpass <br> Part Two Interview:success <br> Math Concept:asdasd <br> Java Web Basics:forrF <br> end of contests <br> Math Concept=>ispass=>Monika=>290 <br> Java Advanced=>funpass=>Simon=>400 <br> Part Two Interview=>success=>Drago=>120 <br> Java Advanced=>funpass=>Petyr=>90 <br> Java Web Basics=>forrF=>Simon=>280 <br> Part Two Interview=>success=>Petyr=>0 <br> Math Concept=>asdasd=>Drago=>250 <br> Part Two Interview=>success=>Simon=>200 <br> end of submissions | Best candidate is Simon with total 880 points. <br> Ranking: <br> Drago <br> #  Math Concept -> 250 <br> #  Part Two Interview -> 120 <br> Petyr <br> #  Java Advanced -> 90 <br> #  Part Two Interview -> 0 <br> Simon <br> #  Java Advanced -> 400 <br> #  Java Web Basics -> 280 <br> #  Part Two Interview -> 200 |
