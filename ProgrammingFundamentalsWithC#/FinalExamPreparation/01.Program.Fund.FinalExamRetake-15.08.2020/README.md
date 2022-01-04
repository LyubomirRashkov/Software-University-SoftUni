## PROBLEMS DESCRIPTION


### Problem 1.	The Imitation Game
On the first line of the input, you will receive the encrypted message. After that, until the _"Decode"_ command is given, you will be receiving strings with instructions for different operations that need to be performed upon the concealed message to interpret it and reveal its true content. There are several types of instructions, split by '|'
+	_"Move {number of letters}"_:
	+	Moves the first n letters to the back of the string
+	_"Insert {index} {value}"_:
	+	Inserts the given value before the given index in the string
+	_"ChangeAll {substring} {replacement}"_:
	+	Changes all occurrences of the given substring with the replacement text
	
Input / Constraints
+	On the first line, you will receive a string with a message.
+	On the following lines, you will be receiving commands, split by '|' .

Output
+	After the _"Decode"_ command is received, print this message: _"The decrypted message is: {message}"_

Examples

| Input     | Output |
| --------- | -----|
| zzHe <br> ChangeAll\|z\|l <br> Insert\|2\|o <br> Move\|3 <br> Decode | The decrypted message is: Hello |
| owyouh <br> Move\|2 <br> Move\|3 <br> Insert\|3\|are <br> Insert\|9\|? <br> Decode | The decrypted message is: howareyou? |

### Problem 2. Ad Astra
On the first line of the input, you will be given a text string. You must extract the information about the food and calculate the total calories. 

First, you must extract the food info. It will always follow the same pattern rules:
+	It will be surrounded by "|" or "#" (only one of the two) in the following pattern: _\#{item name}#{expiration date}#{calories}#_ or _|{item name}|{expiration date}|{calories}|_
+	The item name will contain only lowercase and uppercase letters and whitespace
+	The expiration date will always follow the pattern: _"{day}/{month}/{year}"_, where the day, month, and year will be exactly two digits long
+	The calories will be an integer between 0-10000

Calculate the total calories of all food items and then determine how many days you can last with the food you have. Keep in mind that you need 2000kcal a day.

Input / Constraints
+	You will receive a single string

Output
+	First, print the number of days you will be able to last with the food you have: _"You have food to last you for: {days} days!"_
+	The output for each food item should look like this: _"Item: {item name}, Best before: {expiration date}, Nutrition: {calories}"_

Examples

| Input     | Output |
| --------- | -----|
| #Bread#19/03/21#4000#\|Invalid\|03/03.20\|\|Apples\|08/10/20\|200\|\|Carrots\|06/08/20\|500\|\|Not right\|6.8.20\|5\| | You have food to last you for: 2 days! <br> Item: Bread, Best before: 19/03/21, Nutrition: 4000 <br> Item: Apples, Best before: 08/10/20, Nutrition: 200 <br> Item: Carrots, Best before: 06/08/20, Nutrition: 500 |
| $$#@@%^&#Fish#24/12/20#8500#\|#Incorrect#19.03.20#450\|$5*(@!#Ice Cream#03/10/21#9000#^#@aswe\|Milk\|05/09/20\|2000\| | You have food to last you for: 9 days! <br> Item: Fish, Best before: 24/12/20, Nutrition: 8500 <br> Item: Ice Cream, Best before: 03/10/21, Nutrition: 9000 <br> Item: Milk, Best before: 05/09/20, Nutrition: 2000 |
| Hello\|#Invalid food#19/03/20#450\|$5*(@ | You have food to last you for: 0 days! |

### Problem 3. The Pianist
On the first line of the standard input, you will receive an integer n – the number of pieces you will initially have. On the next n lines, the pieces themselves will follow with their composer and key, separated by "|" in the following format: _"{piece}|{composer}|{key}"_.

Then, you will be receiving different commands, each on a new line, separated by "|", until the _"Stop"_ command is given:
  +	_"Add|{piece}|{composer}|{key}"_:
    +	You need to add the given piece with the information about it to the other pieces and print: _"{piece} by {composer} in {key} added to the collection!"_
    +	If the piece is already in the collection, print: _"{piece} is already in the collection!"_
  +	_"Remove|{piece}"_:
    +	If the piece is in the collection, remove it and print: _"Successfully removed {piece}!"_
    +	Otherwise, print: _"Invalid operation! {piece} does not exist in the collection."_
  +	_"ChangeKey|{piece}|{new key}"_:
    +	If the piece is in the collection, change its key with the given one and print: _"Changed the key of {piece} to {new key}!"_
    +	Otherwise, print: _"Invalid operation! {piece} does not exist in the collection."_

Upon receiving the _"Stop"_ command, you need to print all pieces in your collection, sorted by their name and by the name of their composer in alphabetical order, in the following format: _"{Piece} -> Composer: {composer}, Key: {key}"_

Input/Constraints
+	You will receive a single integer at first – the initial number of pieces in the collection
+	For each piece, you will receive a single line of text with information about it.
+	Then you will receive multiple commands in the way described above until the command _"Stop"_.

Output
+	All the output messages with the appropriate formats are described in the problem description.

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> Fur Elise\|Beethoven\|A Minor <br> Moonlight Sonata\|Beethoven\|C# Minor <br> Clair de Lune\|Debussy\|C# Minor <br> Add\|Sonata No.2\|Chopin\|B Minor <br> Add\|Hungarian Rhapsody No.2\|Liszt\|C# Minor <br> Add\|Fur Elise\|Beethoven\|C# Minor <br> Remove\|Clair de Lune <br> ChangeKey\|Moonlight Sonata\|C# Major <br> Stop | Sonata No.2 by Chopin in B Minor added to the collection! <br> Hungarian Rhapsody No.2 by Liszt in C# Minor added to the collection! <br> Fur Elise is already in the collection! <br> Successfully removed Clair de Lune! <br> Changed the key of Moonlight Sonata to C# Major! <br> Fur Elise -> Composer: Beethoven, Key: A Minor <br> Hungarian Rhapsody No.2 -> Composer: Liszt, Key: C# Minor <br> Moonlight Sonata -> Composer: Beethoven, Key: C# Major <br> Sonata No.2 -> Composer: Chopin, Key: B Minor |
| 4 <br> Eine kleine Nachtmusik\|Mozart\|G Major <br> La Campanella\|Liszt\|G# Minor <br> The Marriage of Figaro\|Mozart\|G Major <br> Hungarian Dance No.5\|Brahms\|G Minor <br> Add\|Spring\|Vivaldi\|E Major <br> Remove\|The Marriage of Figaro <br> Remove\|Turkish March <br> ChangeKey\|Spring\|C Major <br> Add\|Nocturne\|Chopin\|C# Minor <br> Stop | Spring by Vivaldi in E Major added to the collection! <br> Successfully removed The Marriage of Figaro! <br> Invalid operation! Turkish March does not exist in the collection. <br> Changed the key of Spring to C Major! <br> Nocturne by Chopin in C# Minor added to the collection! <br> Eine kleine Nachtmusik -> Composer: Mozart, Key: G Major <br> Hungarian Dance No.5 -> Composer: Brahms, Key: G Minor <br> La Campanella -> Composer: Liszt, Key: G# Minor <br> Nocturne -> Composer: Chopin, Key: C# Minor <br> Spring -> Composer: Vivaldi, Key: C Major |
