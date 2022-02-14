## PROBLEMS DESCRIPTION


### Problem 1.	Food Finder
You will be given two sequences of characters, representing vowels and consonants. Your task is to start checking if the following words could be created:
  +	"pear"
  +	"flour"
  +	"pork"
  +	"olive"

Start by taking the first character of the vowels collection and the last character from the consonants collection. Then check if these letters are present in one or more of the given words. If these letters are present, you should store the information. Then process to the next couple of letters until there are no more consonant letters left. 

A letter (vowels or consonants) could participate in more than one word, for example:

The letter 'o' is present in  "flour", "pork", and "olive". 

The letter 'l' is present in "flour", and "olive".

Keep in mind that:
  +	A vowel letter is always returned to the collection, whether used or not.
  +	A consonant letter is always removed from the collection, whether used or not.

As a result, you should check how many of the given words were found and print:

_"Words found: {numberOfWordsFound}_

_{wordOne}_

_{wordTwo}_

_…"_

Input
  +	On the first line, you will receive characters representing the vowels, separated by a single space (" ").
  +	On the second line, you will receive characters representing the consonants, separated by a single space (" ").

Output
  +	As a result, print on the first line how many words have been found and on the next N lines, every word:

_"Words found: {numberOfWordsFound}_

_{wordOne}_

_{wordTwo}_

_…"_

Print words in the same order as in the problem's description.

Constraints
  +	All letters will be lowercase.
  +	All letters in the given words are unique.
  +	There will be no case where no word is matched.
  +	The letter 'y' will be always vowel.

Examples

| Input     | Output |
| --------- | -----|
| e a u o <br> p r l x f | Words found: 2 <br> pear <br> flour |
| a o y <br> b h p j r n k | Words found: 1 <br> pork |

### Problem 2.	Pawn Wars
A chessboard has 8 rows and 8 columns. Rows also called ranks, are marked from number 1 to 8, and columns are marked from A to H. We have a total of 64 squares, each square is represented by a combination of letters and a number (a1, b1, c1, etc.). In this problem colors of the board will be ignored.

We will play the game with two pawns white (w) and black (b), where they can:
  +	Only move forward:
    +	White (w) moves from the 1st rank to the 8th rank direction.
    +	Black (b) moves from 8th rank to the 1st rank direction.
  +	Can move only 1 square at a time.
  +	Can capture another pawn only diagonally.

When a pawn reaches the last rank, for white this is the 8th rank, and for black, this is the 1st rank, can be promoted to a queen.

Two pawns (w and b) will be placed on two random squares of the bord. The first move is always made by the white pawn (w), then black moves (b), then white (w) again, and so on. When a pawn marches forward, the previous position is marked by "-" (dash).

Some rules will be applied when moving paws:
  +	If the two pawns interact diagonally, the player, in turn, must capture the opponent’s pawn. When a pawn capture another pawn the game is over and _"Game over! {white/black} capture on {coordinates}."_ is printed to the console.
  +	If no capture is possible, the pawns keep on moving until one of them reaches the last rank. When one of the pawns reaches the last rank we print: _"Game over! {White/Black} pawn is promoted to a queen at {coordinates}."_

Constraints
  +	The input will be always valid.
  +	The matrix will always be 8x8.
  +	There will be no case where two pawns are placed on the same square.
  +	There will be no case where two pawns are placed on the same column.
  +	There will be no case where black/white will be placed on the last rank.

Examples

| Input     | Output |
| --------- | -----|
| ------b- <br> -------- <br> -------- <br> -------- <br> -------- <br> -w------ <br> -------- <br> -------- | Game over! White pawn is promoted to a queen at b8. |
| -------- <br> -------- <br> -------- <br> -------- <br> -------- <br> b------- <br> -w------ <br> -------- | Game over! White capture on a3. |

### Problem 3.	Stock Market
Your task is to create an investor with a portfolio of different stocks.

You’ve been given a C# class, called Stock with properties:
  +	CompanyName: string
  +	Director: string
  +	PricePerShare: decimal
  +	TotalNumberOfShares: int
  +	MarketCapitalization: decimal

The constructor of the Stock class should receive the CompanyName, Director, PricePerShare, and the TotalNumberOfShares. MarketCapitalization is a calculated property between PricePerShare and a TotalNumberOfShares. 

The class should also have the following methods:
  +	Override ToString() method in the format:

_"Company: {CompanyName}_

_Director: {Director}_

_Price per share: ${PricePerShare}_

_Market capitalization: ${MarketCapitalization}"_

The Investor class has a collection (portfolio) of type Stock with corresponding unique Company Name of a Stock. The name of the collection should be Portfolio. All the entities of the Portfolio collection have the same properties. The Investor has also some additional properties:
  +	FullName: string
  +	EmailAddress: string
  +	MoneyToInvest: decimal
  +	BrokerName: string

The constructor of the Investor class should receive the FullName, EmailAddress, MoneyToInvest, and BrokerName.

Implement the coming features:
  +	Getter Count - returns the count of the currently owned stocks.
  +	Method void BuyStock(Stock stock) – add a single stock of the given company if the stock’s market capitalization is bigger than $10000 and the investor has enough money. Then reduce the MoneyToInvest by the price of the stock. If a stock cannot be bought the method should not do anything.
  +	Method string SellStock(string companyName, decimal sellPrice) - sell a Stock from the portfolio with the given company name for the given price: 
    +	If the company does not exist return: _"{companyName} does not exist."_
    +	If the selling price is smaller than the price per share return: _"Cannot sell {companyName}."_
    +	Upon successful sell, you should remove the company from the portfolio, increase Money to Invest with the selling price, and return: _"{companyName} was sold."_
  +	Method Stock FindStock(string companyName) - returns a Stock with the given company name. If it doesn't exist, return null.
  +	Method Stock FindBiggestCompany() – returns the Stock with the biggest market capitalization. If there are no stocks in the portfolio, the method should return null. 
  +	Method string InvestorInformation() - returns information about the Investor and his portfolio in the following format:

_"The investor {fullName} with a broker {brokerName} has stocks:_ 

_{Stock1}_

_{Stock2}_

_… "_

Constraints
  +	Only a single stock of a company could be bought.
  +	The company name of each Stock in the portfolio will always be unique.
  +	The PricePerShare of a Stock and the MoneyToInvest of the Investor will always be positive numbers.
  +	There will not be a case where two Stock has the same CompanyName.
  +	You will always be given Stock added before receiving the method for its manipulation.
