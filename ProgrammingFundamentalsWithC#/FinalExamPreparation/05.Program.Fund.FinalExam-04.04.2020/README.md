## PROBLEMS DESCRIPTION


### Problem 1.	Activation Keys
The first line of the input will be your raw activation key. It will consist of letters and numbers only. 

After that, until the _"Generate"_ command is given, you will be receiving strings with instructions for different operations that need to be performed upon the raw activation key.

There are several types of instructions, split by ">>>":
  +	_"Contains>>>{substring}"_:
    +	If the raw activation key contains the given substring, prints: _"{raw activation key} contains {substring}"_.
    +	Otherwise, prints: _"Substring not found!"_
  +	_"Flip>>>Upper/Lower>>>{startIndex}>>>{endIndex}"_:
    +	Changes the substring between the given indices (the end index is exclusive) to upper or lower case and then prints the activation key.
    +	All given indexes will be valid.
  +	_"Slice>>>{startIndex}>>>{endIndex}"_:
    +	Deletes the characters between the start and end indices (the end index is exclusive) and prints the activation key.
    +	Both indices will be valid.

Input
  +	The first line of the input will be a string consisting of letters and numbers only. 
  +	After the first line, until the _"Generate"_ command is given, you will be receiving strings.

Output
  +	After the "Generate" command is received, print: _"Your activation key is: {activation key}"_

Examples

| Input     | Output |
| --------- | -----|
| abcdefghijklmnopqrstuvwxyz <br> Slice>>>2>>>6 <br> Flip>>>Upper>>>3>>>14 <br> Flip>>>Lower>>>5>>>7 <br> Contains>>>def <br> Contains>>>deF <br> Generate | abghijklmnopqrstuvwxyz <br> abgHIJKLMNOPQRstuvwxyz <br> abgHIjkLMNOPQRstuvwxyz <br> Substring not found! <br> Substring not found! <br> Your activation key is: abgHIjkLMNOPQRstuvwxyz |
| 134softsf5ftuni2020rockz42 <br> Slice>>>3>>>7 <br> Contains>>>-rock <br> Contains>>>-uni- <br> Contains>>>-rocks <br> Flip>>>Upper>>>2>>>8 <br> Flip>>>Lower>>>5>>>11 <br> Generate | 134sf5ftuni2020rockz42 <br> Substring not found! <br> Substring not found! <br> Substring not found! <br> 134SF5FTuni2020rockz42 <br> 134SF5ftuni2020rockz42 <br> Your activation key is: 134SF5ftuni2020rockz42 |

### Problem 2.	Emoji Detector
Your task is to write a program that extracts emojis from a text and find the threshold based on the input.

You have to get your cool threshold. It is obtained by multiplying all the digits found in the input.  The cool threshold could be a huge number, so be mindful.

An emoji is valid when:
  +	It is surrounded by 2 characters, either "::" or "\*\*"
  +	It is at least 3 characters long (without the surrounding symbols)
  +	It starts with a capital letter
  +	Continues with lowercase letters only

Examples of valid emojis: _::Joy::, \*\*Banana**, ::Wink::_

Examples of invalid emojis: _::Joy**, ::fox:Es:, \*\*Monk3ys**, :Snak::Es::_

You need to count all valid emojis in the text and calculate their coolness. The coolness of the emoji is determined by summing all the ASCII values of all letters in the emoji. 

Examples: _::Joy:: - 306, \*\*Banana** - 577, ::Wink:: - 409_

You need to print the result of the cool threshold and, after that to take all emojis out of the text, count them and print only the cool ones on the console.

Input
  +	On the single input, you will receive a piece of string. 

Output
  +	On the first line of the output, print the obtained Cool threshold in the format: _"Cool threshold: {coolThresholdSum}"_
  +	On the following line, print the count of all emojis found in the text in format:
  
_"{countOfAllEmojis} emojis found in the text. The cool ones are:_

_{cool emoji 1}_

_{cool emoji 2}_

_…_

_{cool emoji N}"_

Constraints
  + There will always be at least one digit in the text!

Examples

| Input     | Output |
| --------- | -----|
| In the Sofia Zoo there are 311 animals in total! ::Smiley:: This includes 3 \*\*Tigers**, 1 ::Elephant:, 12 \*\*Monk3ys**, a \*\*Gorilla::, 5 ::fox:Es: and 21 different types of :Snak::Es::. ::Mooning:: \*\*Shy** | Cool threshold: 540 <br> 4 emojis found in the text. The cool ones are: <br> ::Smiley:: <br> \*\*Tigers** <br> ::Mooning:: |
| 5, 4, 3, 2, 1, go! The 1-th consecutive banana-eating contest has begun! ::Joy:: \*\*Banana** ::Wink:: \*\*Vali** ::valid_emoji:: | Cool threshold: 120 <br> 4 emojis found in the text. The cool ones are: <br> ::Joy:: <br> \*\*Banana** <br> ::Wink:: <br> \*\*Vali** |
| It is a long established fact that 1 a reader will be distracted by 9 the readable content of a page when looking at its layout. The point of using ::LoremIpsum:: is that it has a more-or-less normal 3 distribution of 8 letters, as opposed to using 'Content here, content 99 here', making it look like readable \*\*English**. | Cool threshold: 17496 <br> 1 emojis found in the text. The cool ones are: |

### Problem 3.	P!rates
Until the _"Sail"_ command is given, you will be receiving:
  +	You and your crew have targeted cities, with their population and gold, separated by "||".
  +	If you receive a city that has already been received, you have to increase the population and gold with the given values.
  
After the _"Sail"_ command, you will start receiving lines of text representing events until the _"End"_ command is given.

Events will be in the following format:
  +	_"Plunder=>{town}=>{people}=>{gold}"_
    +	You have successfully attacked and plundered the town, killing the given number of people and stealing the respective amount of gold. 
    +	For every town you attack print this message: _"{town} plundered! {gold} gold stolen, {people} citizens killed."_
    +	If any of those two values (population or gold) reaches zero, the town is disbanded. You need to remove it from your collection of targeted cities and print the following message: _"{town} has been wiped off the map!"_
    +	There will be no case of receiving more people or gold than there is in the city.
  +	_"Prosper=>{town}=>{gold}"_
    +	There has been dramatic economic growth in the given city, increasing its treasury by the given amount of gold.
    +	The gold amount can be a negative number, so be careful. If a negative amount of gold is given, print: _"Gold added cannot be a negative number!"_ and ignore the command.
    +	If the given gold is a valid amount, increase the town's gold reserves by the respective amount and print the following message: _"{gold added} gold added to the city treasury. {town} now has {total gold} gold."_

Input
  +	On the first lines, until the _"Sail"_ command, you will be receiving strings representing the cities with their gold and population, separated by "||"
  +	On the following lines, until the _"End"_ command, you will be receiving strings representing the actions described above, separated by "=>"

Output
  +	After receiving the _"End"_ command, if there are any existing settlements on your list of targets, you need to print all of them, sorted by their gold in descending order, then by their name in ascending order, in the following format:
  
_"Ahoy, Captain! There are {count} wealthy settlements to go to:_

_{town1} -> Population: {people} citizens, Gold: {gold} kg_

_{town2} -> Population: {people} citizens, Gold: {gold} kg_

_…_

_{town…n} -> Population: {people} citizens, Gold: {gold} kg"_
  +	If there are no settlements left to plunder, print: _"Ahoy, Captain! All targets have been plundered and destroyed!"_

Constraints
  +	The initial population and gold of the settlements will be valid 32-bit integers, never negative, or exceed the respective limits.
  +	The town names in the events will always be valid towns that should be on your list.

Examples

| Input     | Output |
| --------- | -----|
| Tortuga\|\|345000\|\|1250 <br> Santo Domingo\|\|240000\|\|630 <br> Havana\|\|410000\|\|1100 <br> Sail <br> Plunder=>Tortuga=>75000=>380 <br> Prosper=>Santo Domingo=>180 <br> End | Tortuga plundered! 380 gold stolen, 75000 citizens killed. <br> 180 gold added to the city treasury. Santo Domingo now has 810 gold. <br> Ahoy, Captain! There are 3 wealthy settlements to go to: <br> Havana -> Population: 410000 citizens, Gold: 1100 kg <br> Tortuga -> Population: 270000 citizens, Gold: 870 kg <br> Santo Domingo -> Population: 240000 citizens, Gold: 810 kg |
| Nassau\|\|95000\|\|1000 <br> San Juan\|\|930000\|\|1250 <br> Campeche\|\|270000\|\|690 <br> Port Royal\|\|320000\|\|1000 <br> Port Royal\|\|100000\|\|2000 <br> Sail <br> Prosper=>Port Royal=>-200 <br> Plunder=>Nassau=>94000=>750 <br> Plunder=>Nassau=>1000=>150 <br> Plunder=>Campeche=>150000=>690 <br> End | Gold added cannot be a negative number! <br> Nassau plundered! 750 gold stolen, 94000 citizens killed. <br> Nassau plundered! 150 gold stolen, 1000 citizens killed. <br> Nassau has been wiped off the map! <br> Campeche plundered! 690 gold stolen, 150000 citizens killed. <br> Campeche has been wiped off the map! <br> Ahoy, Captain! There are 2 wealthy settlements to go to: <br> Port Royal -> Population: 420000 citizens, Gold: 3000 kg <br> San Juan -> Population: 930000 citizens, Gold: 1250 kg |
