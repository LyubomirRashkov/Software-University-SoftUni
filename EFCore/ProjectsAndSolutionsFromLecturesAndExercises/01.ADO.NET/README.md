## PROBLEMS DESCRIPTION - ADO.NET


### Problem 1. Initial Setup 

Write a program that connects to your localhost server. Create new database called MinionsDB where we will keep information about our minions and villains. 

For each minion we should keep information about its name, age and town. Each town has information about the country where it is located. Villains have name and evilness factor (super good, good, bad, evil, super evil). Each minion can serve several villains and each villain can have several minions serving him. Fill all tables with at least 5 records each.

In the end, you should have the following tables: 

  +	Countries
  +	Towns
  +	Minions
  +	EvilnessFactors
  +	Villains
  +	MinionsVillains

![изображение](https://user-images.githubusercontent.com/82647282/182947759-7a30db13-ccec-4936-b265-d67d45047836.png)

### Problem 2. Villain Names

Write a program that prints on the console all villains’ names and their number of minions of those who have more than 3 minions ordered descending by number of minions.

Example

| Output |
| --- |
| Jilly – 4 |

### Problem 3. Minion Names

Write a program that prints on the console all minion names and age for a given villain id, ordered by name alphabetically.

If there is no villain with the given ID, print "No villain with ID {VillainId} exists in the database.".

If the selected villain has no minions, print "(no minions)" on the second row.

Example

| Input | Output |
| --- | --- |
| 1 | Villain: Gru <br> 1. Becky 125 <br> 2. Bob 42 <br> 3. Kevin 1 |

| Input | Output |
| --- | --- |
| 3 | Villain: Jilly <br> 1. Becky 125 <br> 2. Bob 42 <br> 3. Cathleen 11 <br> 4. Simon 45 |

| Input | Output |
| --- | --- |
| 2 | Villain: Victor <br> 1. Bob 42 <br> 2. Simon 45 |

| Input | Output |
| --- | --- |
| 10 | No villain with ID 10 exists in the database. |

### Problem 4. Add Minion

Write a program that reads information about a minion and its villain and adds it to the database. In case the town of the minion is not in the database, insert it as well. In case the villain is not present in the database, add him too with a default evilness factor of "evil". Finally set the new minion to be a servant of the villain. Print appropriate messages after each operation.

Input

The input comes in two lines:

  +	On the first line, you will receive the minion information in the format "Minion: {Name} {Age} {TownName}"
  +	On the second – the villain information in the format "Villain: {Name}"

Output

After completing an operation, you must print one of the following messages:

  +	After adding a new town to the database: "Town {TownName} was added to the database."
  +	After adding a new villain to the database: "Villain {VillainName} was added to the database."
  +	Finally, after successfully adding the minion to the database and making it a servant of a villain: "Successfully added {MinionName} to be minion of {VillainName}."

*Bonus task: Make sure all operations are executed successfully. In case of an error do not change the database.

Example

| Input     | Output |
| --------- | ----- |
| Minion: Robert 14 Berlin <br> Villain: Gru | Successfully added Robert to be minion of Gru. |
| Minion: Cathleen 20 Liverpool <br> Villain: Gru | Successfully added Cathleen to be minion of Gru. |
| Minion: Mars 23 Sofia <br> Villain: Poppy | Villain Poppy was added to the database. <br> Successfully added Mars to be minion of Poppy. |
| Minion: Carry 20 Eindhoven <br> Villain: Jimmy | Town Eindhoven was added to the database. <br> Villain Jimmy was added to the database. <br> Successfully added Carry to be minion of Jimmy. |

### Problem 5. Change Town Names Casing

Write a program that changes all town names to uppercase for a given country. 

You will receive one line of input with the name of the country.

Print the number of towns that were changed in the format "{ChangedTownsCount} town names were affected.". On a second line, print the names that were changed, separated with a comma and a space.

If no towns were affected (the country does not exist in the database or has no cities connected to it), print "No town names were affected.".

Example

| Input     | Output |
| --------- | ----- |
| Bulgaria | 4 town names were affected. <br> [PLOVDIV, VARNA, BURGAS, SOFIA] |
| Germany | 2 town names were affected. <br> [BERLIN, FRANKFURT] |

### Problem 6. Remove Villain 

Write a program that receives the ID of a villain, deletes him from the database and releases his minions from serving to him. Print on two lines the name of the deleted villain in format "{Name} was deleted." and the number of minions released in format "{MinionCount} minions were released.". Make sure all operations go as planned, otherwise do not make any changes in the database.

If there is no villain in the database with the given ID, print "No such villain was found.".

Example

| Input     | Output |
| --------- | ----- |
| 1 | Gru was deleted. <br> 5 minions were released. |
| 3 | Jilly was deleted. <br> 4 minions were released. |
| 101 | No such villain was found. |

### Problem 7. Print All Minion Names

Write a program that prints all minion names from the minions table in the following order: first record, last record, first + 1, last - 1, first + 2, last - 2 … first + n, last - n. 

| 1 | 10 | 2 | 9 | 3 | 8 | 4 | 7 | 5 | 6 |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |

Example


| Original Order     | Output |
| --------- | ----- |
| Bob <br> Kevin <br> Bob <br> Simon <br> Cathleen <br> Carry <br> Becky <br> Mars <br> Misho <br> Zoe <br> Json <br> Robert <br> Cathleen <br> Mars <br> Carry | Bob <br> Carry <br> Kevin <br> Mars <br> Bob <br> Cathleen <br> Simon <br> Robert <br> Cathleen <br> Json <br> Carry <br> Zoe <br> Becky <br> Misho <br> Mars |

### Problem 8. Increase Minion Age

Read from the console minion IDs separated by space. Increment the age of those minions by 1 and make their names title case. Finally, print the name and the age of all minions in the database, each on a new row in format "{Name} {Age}".

Example

| Input     | Output |
| --------- | ----- |
| 2 1 4 | Bob 43 <br> Kevin 2 <br> Bob 32 <br> Simon 46 <br> Cathleen 11 <br> Carry 50 <br> Becky 125 <br> Mars 21 <br> Misho 5 <br> Zoe 125 <br> Json 21 <br> Robert 14 <br> Cathleen 20 <br> Mars 23 <br> Carry 20 |

| Input     | Output |
| --------- | ----- |
| 5 | Bob 43 <br> Kevin 2 <br> Bob 32 <br> Simon 46 <br> Cathleen 12 <br> Carry 50 <br> Becky 125 <br> Mars 21 <br> Misho 5 <br> Zoe 125 <br> Json 21 <br> Robert 14 <br> Cathleen 20 <br> Mars 23 <br> Carry 20 |

### Problem 9. Increase Age Stored Procedure 

Create stored procedure usp_GetOlder (directly in the database using Management Studio or any other similar tool) that receives MinionId and increases that minion’s age by 1. Write a program that uses that stored procedure to increase the age of a minion whose id will be given as input from the console. After that print the name and the age of that minion.

Example

| Input     | Output |
| --------- | ----- |
| 1 | Bob – 44 years old |
| 5 | Cathleen – 13 years old |
| 10 | Zoe – 126 years old |