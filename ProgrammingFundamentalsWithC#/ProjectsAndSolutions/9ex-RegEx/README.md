## PROBLEMS DESCRIPTION - REGULAR EXPRESSIONS (Exercise)


### Problem 1.	Furniture
Create a program to calculate the total cost of different types of furniture. You will be given some lines of input until you receive the line "Purchase". For the line to be valid it should be in the following format:

">>{furniture name}<<{price}!{quantity}"

The price can be floating point number or whole number. Store the names of the furniture and the total price. At the end print the each bought furniture on separate line in the format:

"Bought furniture:

{1st name}

{2nd name}

…"

And on the last line print the following: "Total money spend: {spend money}" formatted to the second decimal point.

Examples

| Input     | Output |
| --------- | -----|
| >>Sofa<<312.23!3 <br> >>TV<<300!5 <br> >Invalid<<!5 <br> Purchase | Bought furniture: <br> Sofa <br> TV <br> Total money spend: 2436.69 |
| >>Chair<<412.23!3 <br> >>Sofa<<500!5 <br> >>Recliner<<<<!5 <br> >>Bench<<230!10 <br> >>>>>>Rocking chair<<!5 <br> >>Bed<<700!5 <br> Purchase | Bought furniture: <br> Chair <br> Sofa <br> Bench <br> Bed <br> Total money spend: 9536.69 |

### Problem 2.	Race
Write a program that processes information about a race. On the first line you will be given list of participants separated by ", ". On the next few lines until you receive a line "end of race" you will be given some info which will be some alphanumeric characters. In between them you could have some extra characters which you should ignore. For example: "G!32e%o7r#32g$235@!2e". The letters are the name of the person and the sum of the digits is the distance he ran. So here we have George who ran 29 km. Store the information about the person only if the list of racers contains the name of the person. If you receive the same person more than once just add the distance to his old distance. At the end print the top 3 racers ordered by distance in descending in the format:

"1st place: {first racer}

2nd place: {second racer}

3rd place: {third racer}"

Examples

| Input     | Output |
| --------- | -----|
| George, Peter, Bill, Tom <br> G4e@55or%6g6!68e!!@ <br> R1@!3a$y4456@ <br> B5@i@#123ll <br> G@e54o$r6ge# <br> 7P%et^#e5346r <br> T$o553m&6 <br> end of race | 1st place: George <br> 2nd place: Peter <br> 3rd place: Tom |
| Ivan, Peter, James, Kyle <br> I4v@43an%66?77!!@ <br> G1@!3u$s445s6@ <br> B3@i@#245ll <br> I&v54a%66n@ <br> 7P%et^#e5346r <br> J$a553m&e6s <br> K2y3=l/^e23 <br> end of race | 1st place: Ivan <br> 2nd place: Peter <br> 3rd place: James |

### Problem 3.	SoftUni Bar Income
Let's take a break and visit the game bar at SoftUni. It is about time for the people behind the bar to go home and you are the person who has to draw the line and calculate the money from the products that were sold throughout the day. Until you receive a line with text "end of shift" you will be given lines of input. But before processing that line you have to do some validations first.

Each valid order should have a customer, product, count and a price:
+	Valid customer's name should be surrounded by '%' and must start with a capital letter, followed by lower-case letters
+	Valid product contains any word character and must be surrounded by '<' and '>' 
+	Valid count is an integer, surrounded by '|'
+	Valid price is any real number followed by '$'

The parts of a valid order should appear in the order given: customer, product, count and a price.

Between each part there can be other symbols, except ('|', '$', '%' and '.')


For each valid line print on the console: "{customerName}: {product} - {totalPrice}"

When you receive "end of shift" print the total amount of money for the day rounded to 2 decimal places in the following format: "Total income: {income}".

Input / Constraints
+	Strings that you have to process until you receive text "end of shift".

Output
+	Print all of the valid lines in the format "{customerName}: {product} - {totalPrice}"
+	After receiving "end of shift" print the total amount of money for the day rounded to 2 decimal places in the following format: "Total income: {income}"
+	Allowed working time / memory: 100ms / 16MB.

Examples

| Input     | Output |
| --------- | -----|
| %George%<Croissant>|2|10.3$ <br> %Peter%<Gum>|1|1.3$ <br> %Maria%<Cola>|1|2.4$ <br> end of shift | George: Croissant - 20.60 <br> Peter: Gum - 1.30 <br> Maria: Cola - 2.40 <br> Total income: 24.30 |
| %InvalidName%<Croissant>|2|10.3$ <br> %Peter%<Gum>1.3$ <br> %Maria%<Cola>|1|2.4 <br> %Valid%<Valid>valid|10|valid20$ <br> end of shift | Valid: Valid - 200.00 <br> Total income: 200.00 |

### Problem 4.	Star Enigma
The war is in its peak, but you, young Padawan, can turn the tides with your programming skills. You are tasked to create a program to decrypt the messages of The Order and prevent the death of hundreds of lives. 

You will receive several messages, which are encrypted using the legendary star enigma. You should decrypt the messages, following these rules:

To properly decrypt a message, you should count all the letters [s, t, a, r] – case insensitive and remove the count from the current ASCII value of each symbol of the encrypted message.

After decryption:

Each message should have a planet name, population, attack type ('A', as attack or 'D', as destruction) and soldier count.

The planet name starts after '@' and contains only letters from the Latin alphabet. 

The planet population starts after ':' and is an Integer;

The attack type may be "A"(attack) or "D"(destruction) and must be surrounded by "!" (exclamation mark).

The soldier count starts after "->" and should be an Integer.

The order in the message should be: planet name -> planet population -> attack type -> soldier count. Each part can be separated from the others by any character except: '@', '-', '!', ':' and '>'.

Input / Constraints
+	The first line holds n – the number of messages– integer in range [1…100];
+	On the next n lines, you will be receiving encrypted messages.

Output

After decrypting all messages, you should print the decrypted information in the following format:

First print the attacked planets, then the destroyed planets.

"Attacked planets: {attackedPlanetsCount}"

"-> {planetName}"

"Destroyed planets: {destroyedPlanetsCount}"

"-> {planetName}"

The planets should be ordered by name alphabetically.

Examples

| Input     | Output |
| --------- | -----|
| 2 <br> STCDoghudd4=63333$D$0A53333 <br> EHfsytsnhf?8555&I&2C9555SR  | Attacked planets: 1 <br> -> Alderaa <br> Destroyed planets: 1 <br> -> Cantonica |
| 3 <br> tt(''DGsvywgerx>6444444444%H%1B9444 <br> GQhrr|A977777(H(TTTT <br> EHfsytsnhf?8555&I&2C9555SR | Attacked planets: 0 <br> Destroyed planets: 2 <br> -> Cantonica <br> -> Coruscant |

### Problem 5.	Nether Realms
Mighty battle is coming. In the stormy nether realms, demons are fighting against each other for supremacy in a duel from which only one will survive. 

Your job, however is not so exciting. You are assigned to sign in all the participants in the nether realm's mighty battle's demon book, which of course is sorted alphabetically. 

A demon's name contains his health and his damage. 

The sum of the asci codes of all characters (excluding numbers (0-9), arithmetic symbols ('+', '-', '*', '/') and delimiter dot ('.')) gives a demon's total health. 

The sum of all numbers in his name forms his base damage. Note that you should consider the plus '+' and minus '-' signs (e.g. +10 is 10 and -10 is -10). However, there are some symbols ('*' and '/') that can further alter the base damage by multiplying or dividing it by 2 (e.g. in the name "m15*/c-5.0", the base damage is 15 + (-5.0) = 10 and then you need to multiply it by 2 (e.g. 10 * 2 = 20) and then divide it by 2 (e.g. 20 / 2 = 10)). 

So, multiplication and division are applied only after all numbers are included in the calculation and in the order they appear in the name. 

You will get all demons on a single line, separated by commas and zero or more blank spaces. Sort them in alphabetical order and print their names along their health and damage. 

Input

The input will be read from the console. The input consists of a single line containing all demon names separated by commas and zero or more spaces in the format: "{demon name}, {demon name}, … {demon name}"

Output

Print all demons sorted by their name in ascending order, each on a separate line in the format:
+	"{demon name} - {health points} health, {damage points} damage"

Constraints
+	A demon's name will contain at least one character
+	A demon's name cannot contain blank spaces ' ' or commas ','
+	A floating point number will always have digits before and after its decimal separator
+	Number in a demon's name is considered everything that is a valid integer or floating point number (with dot '.' used as separator). For example, all these are valid numbers: '4', '+4', '-4', '3.5', '+3.5', '-3.5' 

Examples

| Input     | Output |
| --------- | -----|
| M3ph-0.5s-0.5t0.0\*\*   | M3ph-0.5s-0.5t0.0\*\* - 524 health, 8.00 damageBethany Taylor John <br> Smith |
| M3ph1st0\*\*, Azazel | Azazel - 615 health, 0.00 damage  <br> M3ph1st0\*\* - 524 health, 16.00 damage |
| Gos/ho | Gos/ho - 512 health, 0.00 damage |

### Problem 6.	Extract Emails
Write a program to extract all email addresses from a given text. The text comes at the only input line. Print the emails on the console, each at a separate line. Emails are considered to be in format <user>@<host>, where: 
+	<user> is a sequence of letters and digits, where '.', '-' and '_' can appear between them.
    +	Examples of valid users: "stephan", "mike03", "s.johnson", "st_steward", "softuni-bulgaria", "12345".
    +	Examples of invalid users: ''--123", ".....", "nakov_-", "_steve", ".info". 
+	<host> is a sequence of at least two words, separated by dots '.'. Each word is sequence of letters and can have hyphens '-' between the letters.
    +	Examples of hosts: "softuni.bg", "software-university.com", "intoprogramming.info", "mail.softuni.org". 
	+	Examples of invalid hosts: "helloworld", ".unknown.soft.", "invalid-host-", "invalid-". 
+	Examples of valid emails: info@softuni-bulgaria.org, kiki@hotmail.co.uk, no-reply@github.com, s.peterson@mail.uu.net, info-bg@software-university.software.academy. 
+	Examples of invalid emails: --123@gmail.com, …@mail.bg, .info@info.info, _steve@yahoo.cn, mike@helloworld, mike@.unknown.soft., s.johnson@invalid-.

Examples

| Input     | Output |
| --------- | -----|
| Please contact us at: support@github.com. | support@github.com |
| Just send email to s.miller@mit.edu and j.hopking@york.ac.uk for more information. | s.miller@mit.edu <br> j.hopking@york.ac.uk |
