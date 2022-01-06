## PROBLEMS DESCRIPTION


### Problem 1.	Secret Chat
On the first line of the input, you will receive the concealed message. After that, until the _"Reveal"_ command is given, you will receive strings with instructions for different operations that need to be performed upon the concealed message to interpret it and reveal its actual content. There are several types of instructions, split by ":|:"
  +	_"InsertSpace:|:{index}"_:
    +	Inserts a single space at the given index. The given index will always be valid.
  +	_"Reverse:|:{substring}"_:
    +	If the message contains the given substring, cut it out, reverse it and add it at the end of the message. 
    +	If not, print _"error"_.
    +	This operation should replace only the first occurrence of the given substring if there are two or more occurrences.
  +	_"ChangeAll:|:{substring}:|:{replacement}"_:
    +	Changes all occurrences of the given substring with the replacement text.
    
Input / Constraints
  +	On the first line, you will receive a string with a message.
  +	On the following lines, you will be receiving commands, split by ":|:".

Output
  +	After each set of instructions, print the resulting string. 
  +	After the _"Reveal"_ command is received, print this message: _"You have a new text message: {message}"_

Examples

| Input     | Output |
| --------- | -----|
| heVVodar!gniV <br> ChangeAll:\|:V:\|:l <br> Reverse:\|:!gnil <br> InsertSpace:\|:5 <br> Reveal | hellodar!gnil <br> hellodarling! <br> hello darling! <br> You have a new text message: hello darling! |
| Hiware?uiy <br> ChangeAll:\|:i:\|:o <br> Reverse:\|:?uoy <br> Reverse:\|:jd <br> InsertSpace:\|:3 <br> InsertSpace:\|:7 <br> Reveal | Howare?uoy <br> Howareyou? <br> error <br> How areyou? <br> How are you? <br> You have a new text message: How are you? |

### Problem 2.	Mirror words
On the first line of the input, you will be given a text string. To win the competition, you have to find all hidden word pairs, read them, and mark the ones that are mirror images of each other.

First of all, you have to extract the hidden word pairs. Hidden word pairs are:
  +	Surrounded by "@" or "#" (only one of the two) in the following pattern _#wordOne##wordTwo#_ or _@wordOne@@wordTwo@_
  +	At least 3 characters long each (without the surrounding symbols)
  +	Made up of letters only

If the second word, spelled backward, is the same as the first word and vice versa (casing matters!), they are a match, and you have to store them somewhere. Examples of mirror words: _#Part##traP# @leveL@@Level@ #sAw##wAs#_
  +	If you don\`t find any valid pairs, print: _"No word pairs found!"_
  +	If you find valid pairs print their count: _"{valid pairs count} word pairs found!"_
  +	If there are no mirror words, print: _"No mirror words!"_
  +	If there are mirror words print:
  
 _"The mirror words are:_
  
 _{wordOne} <=> {wordtwo}, {wordOne} <=> {wordtwo}, … {wordOne} <=> {wordtwo}"_

Input / Constraints
  +	You will recieve a string.
  
Output
  +	Print the proper output messages in the proper cases as described in the problem description.
  +	If there are pairs of mirror words, print them in the end, each pair separated by ", ".
  +	Each pair of mirror word must be printed with " <=> " between the words.

Examples

| Input     | Output |
| --------- | -----|
| @mix#tix3dj#poOl##loOp#wl@@bong&song%4very$long@thong#Part##traP#<br>#@@leveL@@Level@##car#rac##tu@pack@@ckap@#rr#sAw##wAs#r#@w1r	| 5 word pairs found! <br> The mirror words are: <br> Part <=> traP, leveL <=> Level, sAw <=> wAs |
| #po0l##l0op# @bAc##cAB@ @LM@ML@ #xxxXxx##xxxXxx# @aba@@ababa@ | 2 word pairs found! <br> No mirror words! |
| #lol#lol# @#God@@doG@# #abC@@Cba# @Xyu@#uyX# | No word pairs found! <br> No mirror words! |

### Problem 3.	Need for Speed III
On the first line of the standard input, you will receive an integer n – the number of cars that you can obtain. On the next n lines, the cars themselves will follow with their mileage and fuel available, separated by "|" in the following format: _"{car}|{mileage}|{fuel}"_

Then, you will be receiving different commands, each on a new line, separated by " : ", until the _"Stop"_ command is given:
  +	_"Drive : {car} : {distance} : {fuel}"_:
    +	You need to drive the given distance, and you will need the given fuel to do that. If the car doesn't have enough fuel, print: _"Not enough fuel to make that ride"_
    +	If the car has the required fuel available in the tank, increase its mileage with the given distance, decrease its fuel with the given fuel, and print: _"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed."_
    +	You like driving new cars only, so if a car's mileage reaches 100 000 km, remove it from the collection(s) and print: _"Time to sell the {car}!"_
  +	_"Refuel : {car} : {fuel}"_:
    +	Refill the tank of your car. 
    +	Each tank can hold a maximum of 75 liters of fuel, so if the given amount of fuel is more than you can fit in the tank, take only what is required to fill it up. 
    +	Print a message in the following format: _"{car} refueled with {fuel} liters"_
  +	_"Revert : {car} : {kilometers}"_:
    +	Decrease the mileage of the given car with the given kilometers and print the kilometers you have decreased it with in the following format: _"{car} mileage decreased by {amount reverted} kilometers"_
    +	If the mileage becomes less than 10 000km after it is decreased, just set it to 10 000km and DO NOT print anything.
    
Upon receiving the _"Stop"_ command, you need to print all cars in your possession, sorted by their mileage in descending order, then by their name in ascending order, in the following format: _"{car} -> Mileage: {mileage} kms, Fuel in the tank: {fuel} lt."_

Input/Constraints
+	The mileage and fuel of the cars will be valid, 32-bit integers, and will never be negative.
+	The fuel and distance amounts in the commands will never be negative.
+	The car names in the commands will always be valid cars in your possession.

Output
+	All the output messages with the appropriate formats are described in the problem description.

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> Audi A6\|38000\|62 <br> Mercedes CLS\|11000\|35 <br> Volkswagen Passat CC\|45678\|5 <br> Drive : Audi A6 : 543 : 47 <br> Drive : Mercedes CLS : 94 : 11 <br> Drive : Volkswagen Passat CC : 69 : 8 <br> Refuel : Audi A6 : 50 <br> Revert : Mercedes CLS : 500 <br> Revert : Audi A6 : 30000 <br> Stop | Audi A6 driven for 543 kilometers. 47 liters of fuel consumed. <br> Mercedes CLS driven for 94 kilometers. 11 liters of fuel consumed. <br> Not enough fuel to make that ride <br> Audi A6 refueled with 50 liters <br> Mercedes CLS mileage decreased by 500 kilometers <br> Volkswagen Passat CC -> Mileage: 45678 kms, Fuel in the tank: 5 lt. <br> Mercedes CLS -> Mileage: 10594 kms, Fuel in the tank: 24 lt. <br> Audi A6 -> Mileage: 10000 kms, Fuel in the tank: 65 lt. |
| 4 <br> Lamborghini Veneno\|11111\|74 <br> Bugatti Veyron\|12345\|67 <br> Koenigsegg CCXR\|67890\|12 <br> Aston Martin Valkryie\|99900\|50 <br> Drive : Koenigsegg CCXR : 382 : 82 <br> Drive : Aston Martin Valkryie : 99 : 23 <br> Drive : Aston Martin Valkryie : 2 : 1 <br> Refuel : Lamborghini Veneno : 40 <br> Revert : Bugatti Veyron : 2000 <br> Stop | Not enough fuel to make that ride <br> Aston Martin Valkryie driven for 99 kilometers. 23 liters of fuel consumed. <br> Aston Martin Valkryie driven for 2 kilometers. 1 liters of fuel consumed. <br> Time to sell the Aston Martin Valkryie! <br> Lamborghini Veneno refueled with 1 liters <br> Bugatti Veyron mileage decreased by 2000 kilometers <br> Koenigsegg CCXR -> Mileage: 67890 kms, Fuel in the tank: 12 lt. <br> Lamborghini Veneno -> Mileage: 11111 kms, Fuel in the tank: 75 lt. <br> Bugatti Veyron -> Mileage: 10345 kms, Fuel in the tank: 67 lt. |
