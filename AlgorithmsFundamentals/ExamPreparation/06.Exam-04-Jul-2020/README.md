## PROBLEMS DESCRIPTION - Exam 04 July 2020


### Problem 1.	Two Minutes to Midnight

You are on an adventure and you have found yourself stuck in front of great challenge. There is a door blocking your path it will unlock after you have guessed the correct number which is the answer to the following riddle:

In how many ways can you select the loot inside the treasure room, given that you have N items and you can only pick K of those?

So you need to develop a program which produces a single number as an output.

You receive two numbers first one represents the number of items, and the second one represents the number of those that you can get.

Input

  +	The input will come from the console on two lines each line will represent a single number

Output

  +	The output is always a single number.

Constraints

  +	All input lines will be valid the first number will always be not less than the second.
  +	The input will be in the range [1…1000]

Examples

| Input | Output |
| --- | --- |
| 5 <br> 3 | 10 |
| 48 <br> 17 | 4244421484512 |

### Problem 2. Time

This time you are master of the time itself.

Do you know what a persistent timeline is? Well even if you don't you are about to understand. You need to rebuild the timeline of the universe. Which universe? This one, maybe if you are lucky enough. 

You will be given two sequences of integers representing two timeline versions. You need to extract from both sequences the single correct timeline that can be retrieved by finding the longest sub sequence of equal integers from both timelines and also find its length.

Input

  +	The first line integers representing the first timeline separated by spaces.
  +	The second line integers representing the second timeline separated by spaces

Output

  +	On the first line print the correct timeline, if there are more than one optimal timeline print the rightmost
  +	On the second line print the length of that timeline

Constraints

  +	All numbers will be valid integers
  +	The length of the timelines will be between [1…5000]

Examples

| Input | Output |
| --- | --- |
| 13 42 69 73 42 84 26 <br> 13 54 73 42 8 15 29 | 13 73 42 <br> 3 |
| 5 69 78 5 3 5 5 5 <br> 1 2 3 5 5 5 5 5 | 5 5 5 5 5 <br> 5 |

### Problem 3. The Story Telling

The greatest storyteller of all times needs your help. He has his stories, however they got all mixed up his storytelling needs to be in the correct order and you need to fix that order. You will be given the stories in the following format on a single line until command "End" is received: {preStory} -> {postStory1} {postStory2} {postStoryn-1}

You have to read the stories data and then print the stories in the correct order according to the description above. Keep in mind that the structure above represents relation in which any story can be preStory or postStory in different input lines.

The input will come from the console:

  +	On a single line the input in the above format until "End" command is received.

Output

  +	On a single line print the stories in the correct order separated by spaces
  +	The output priority if there are more than one stories without pre story should be in the order of the input

Constraints

  +	All stories will be valid and also can contain any ASCII symbol except space
  +	The input will always end with "End" line

Examples

| Input | Output |
| --- | --- |
| Mort -> Time Space <br> Time -> Future Robot <br> Space -> Metro <br> Future -> Space Metro <br> Robot -> Future <br> Metro -> <br> End | Mort Time Robot Future Space Metro |
| By -> The <br> Story -> The Told <br> Told -> Narrator <br> The -> Narrator Ever Greatest <br> Narrator -> <br> Some -> Told Ever <br> Greatest -> <br> Ever -> <br> End | Some Story Told By The Greatest Ever Narrator |