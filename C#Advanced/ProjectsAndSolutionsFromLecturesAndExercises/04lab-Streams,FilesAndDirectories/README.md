## PROBLEMS DESCRIPTION - STREAMS, FILES AND DIRECTORIES (Lecture)


### Problem 1.	Odd Lines
Create a program that reads a text file and writes it's every odd line in another file. Line numbers starts from 0. 

Examples

| Input     | Output |
| --------- | -----|
| Two households, both alike in dignity, <br> In fair Verona, where we lay our scene, <br> From ancient grudge break to new mutiny, <br> Where civil blood makes civil hands unclean. <br> From forth the fatal loins of these two foes <br> A pair of star-cross'd lovers take their life; <br> Whose misadventured piteous overthrows <br> Do with their death bury their parents' strife. | In fair Verona, where we lay our scene, <br> Where civil blood makes civil hands unclean. <br> A pair of star-cross’d lovers take their life; <br> Do with their death bury their parents’ strife |

### Problem 2.	Line Numbers
Create a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file. 

Examples

| Input     | Output |
| --------- | -----|
| Two households, both alike in dignity, <br> In fair Verona, where we lay our scene, <br> From ancient grudge break to new mutiny, <br> Where civil blood makes civil hands unclean. <br> From forth the fatal loins of these two foes <br> A pair of star-cross'd lovers take their life; <br> Whose misadventured piteous overthrows <br> Do with their death bury their parents' strife. | 1.	Two households, both alike in dignity, <br> 2.	In fair Verona, where we lay our scene, <br> 3.	From ancient grudge break to new mutiny, <br> 4.	Where civil blood makes civil hands unclean. <br> 5.	From forth the fatal loins of these two foes <br> 6.	A pair of star-cross'd lovers take their life; <br> 7.	Whose misadventured piteous overthrows <br> 8.	Do with their death bury their parents' strife. |

### Problem 3.	Word Count
Create a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file text.txt. Matching should be case-insensitive.

The result should be written to another text file. Sort the words by frequency in descending order.

Examples

| words.txt | Input     | Output |
| ----- | --------- | -----|
| quick is fault | -I was quick to judge him, but it wasn't his fault. <br> -Is this some kind of joke?! Is it? <br> -Quick, hide here…It is safer. | is - 3 <br> quick - 2 <br> fault - 1 |

### Problem 4.	Merge Files
Create a program that reads the contents of two text files and merges them together into a third one.

Examples

| Input1 | Input2     | Output |
| ----- | --------- | -----|
| 1 <br> 3 <br> 5 | 2 <br> 4 <br> 6 | 1 <br> 2 <br> 3 <br> 4 <br> 5 <br> 6 |

### Problem 5.	Slice a File
Create a program that slice text file in 4 equal parts. 

Name them:
  +	Part-1.txt, Part-2.txt, Part-3. txt, Part-4.txt

### Problem 6.	Folder Size
You are given a folder named _"TestFolder"_. Get the size of all files in the folder, which are NOT directories. The result should be written to another text file in Megabytes.

Examples

| Output |
| -----|
| 5.16173839569092|
