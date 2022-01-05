## PROBLEMS DESCRIPTION


### Problem 1.	World Tour
On the first line, you will be given a string containing all of your stops. Until you receive the command _"Travel"_, you will be given some commands to manipulate that initial string. The commands can be:
  +	_"Add Stop:{index}:{string}"_:
    +	Insert the given string at that index only if the index is valid
  + _"Remove Stop:{start_index}:{end_index}"_:
    +	Remove the elements of the string from the starting index to the end index (inclusive) if both indices are valid
  +	_"Switch:{old_string}:{new_string}"_:
    +	If the old string is in the initial string, replace it with the new one (all occurrences)
  
**_Note: After each command, print the current state of the string_**

After the _"Travel"_ command, print the following: _"Ready for world tour! Planned stops: {string}"_

Input / Constraints
  +	An index is valid if it is between the first and the last element index (inclusive) in the sequence.
 	
Output
  +	Print the proper output messages in the proper cases as described in the problem description

Examples

| Input     | Output |
| --------- | -----|
| Hawai::Cyprys-Greece <br> Add Stop:7:Rome <br> Remove Stop:11:16 <br> Switch:Hawai:Bulgaria <br> Travel | Hawai::RomeCyprys-Greece <br> Hawai::Rome-Greece <br> Bulgaria::Rome-Greece <br> Ready for world tour! Planned stops: Bulgaria::Rome-Greece |

### Problem 2.	Destination Mapper
You will be given a string representing some places on the map. You have to filter only the valid ones. A valid location is:
  +	Surrounded by "=" or "/" on both sides (the first and the last symbols must match)
  +	After the first "=" or "/" there should be only letters (the first must be upper-case, other letters could be upper or lower-case)
  +	The letters must be at least 3

Example: In the string _"=Hawai=/Cyprus/=Invalid/invalid==i5valid=/I5valid/=i="_ only the first two locations are valid.

After you have matched all the valid locations, you have to calculate travel points. They are calculated by summing the lengths of all the valid destinations that you have found on the map. 

In the end, on the first line, print: _"Destinations: {destinations joined by ', '}"_. 

On the second line, print _"Travel Points: {travel_points}"_.

Input / Constraints
  +	You will receive a string representing the locations on the map

Output
+	Print the messages described above

Examples

| Input     | Output |
| --------- | -----|
| =Hawai=/Cyprus/=Invalid/invalid==i5valid=/I5valid/=i= | Destinations: Hawai, Cyprus <br> Travel Points: 11 |
| ThisIs some InvalidInput | Destinations: <br> Travel Points: 0 |

### Problem 3.	Plant Discovery
On the first line, you will receive a number n. On the next n lines, you will be given some information about the plants that you have discovered in the format: _"{plant}<->{rarity}"_. Store that information because you will need it later. If you receive a plant more than once, update its rarity.

After that, until you receive the command _"Exhibition"_, you will be given some of these commands:
  +	_"Rate: {plant} - {rating}"_ – add the given rating to the plant (store all ratings)
  +	_"Update: {plant} - {new_rarity}"_ – update the rarity of the plant with the new one
  +	_"Reset: {plant}"_ – remove all the ratings of the given plant
  
**_Note: If any given plant name is invalid, print "error"_**

After the command _"Exhibition"_, print the information that you have about the plants in the following format:

_"Plants for the exhibition:_

_- {plant_name1}; Rarity: {rarity}; Rating: {average_rating}_

_- {plant_name2}; Rarity: {rarity}; Rating: {average_rating}_

_…_

_- {plant_nameN}; Rarity: {rarity}; Rating: {average_rating}"_

The plants should be sorted by rarity in descending order. If two or more plants have the same rarity value sort them by average rating in descending order. The average rating should be formatted to the second decimal place.

Input / Constraints
  +	You will receive the input as described above

Output
  +	Print the information about all plants as described above

Examples

| Input     | Output |
| --------- | -----|
| 3 <br> Arnoldii<->4 <br> Woodii<->7 <br> Welwitschia<->2 <br> Rate: Woodii - 10 <br> Rate: Welwitschia - 7 <br> Rate: Arnoldii - 3 <br> Rate: Woodii - 5 <br> Update: Woodii - 5 <br> Reset: Arnoldii <br> Exhibition | Plants for the exhibition: <br> - Woodii; Rarity: 5; Rating: 7.50 <br> - Arnoldii; Rarity: 4; Rating: 0.00 <br> - Welwitschia; Rarity: 2; Rating: 7.00 |
| 2 <br> Candelabra<->10 <br> Oahu<->10 <br> Rate: Oahu - 7 <br> Rate: Candelabra - 6 <br> Exhibition | Plants for the exhibition: <br> - Oahu; Rarity: 10; Rating: 7.00 <br> - Candelabra; Rarity: 10; Rating: 6.00 |
