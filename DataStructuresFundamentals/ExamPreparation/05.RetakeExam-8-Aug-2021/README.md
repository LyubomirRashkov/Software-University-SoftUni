## PROBLEMS DESCRIPTION


### Problem 1	Olympics

You have to implement a structure that keeps track of the Olympic scores in Tokyo 2020. Your structure will have to support the following functionalities:

  +	AddCompetitor(competitorId, competitorName) – you have to register a new competitor. If there is already a competitor with that id, return ArgumentException
  +	AddCompetition(competitionId, competitionName, score) – you have to register a new competition. If there is already a competition with that id, return ArgumentException
  +	Compete(competitorId, competitionId) – search for the given competitor and the given competition and add the competitor with his score to the given competition. If there are no such competitor or competition throw ArgumentException
  +	Disqualify(competitionId, competitorId) – search for the competitor in the competition and remove him from the competition. Decrease the points of the competitor with the points of the current race. If there are no such competitor or competition throw ArgumentException
  +	GetByName(name) – return all competitors with the provided name ordered by their id’s. If there is no competitor with the given name return ArgumentException
  +	FindCompetitorsInRange(min, max) – find all competitors which have total score between the given start exclusive and end inclusive and order them by id.
  +	SearchWithNameLength(minLength, maxLength) – Returns a list of contestants that have name lengths between the 2 parameters inclusive and order them by id. If there aren’t any return empty collection.
  +	Contains(competitionId, Competitor) – Checks if a competitor is present in the competition.
  +	GetCompetition(id) – return the competition with the given id. If there is no such throw IllegalArgumentException
  +	CompetitorsCount() – return count of registered competitors
  +	CompetitionsCount() – return count of competitions

Feel free to override Equals() and GetHashCode() if necessary.

Input / Output

You are given a Visual Studio C# project skeleton (unfinished project) holding the interface IOlympics, the unfinished classes Competition, Competitor and Olympics. Tests covering the Olympics functionality and performance.

Your task is to finish this class to make the tests run correctly.
  
  +	You are not allowed to change the tests.
  +	You are not allowed to change the interface.
  +	You can add to the Olympics class, but don't remove anything.
  +	You can edit the Olympics class if it implements the IOlympics interface.

### Problem 2 Hearthstone

Your task is to implement a simple game with cards. You may have already known about the Hearthstone game and now you must implement your custom version of it.

You have a class Card which has the following properties:

  +	string Name – unique name for each card
  +	int Damage – the damage for the current card
  +	int Score – the score current card has
  +	int Health – the health of the current card (each card starts with 20 health)
  +	int Level – the level of the card

You need to support the following operations (and they should be fast):

  +	Draw(Card card)– Add a card to the deck of cards. You will need to implement the Contains() method as well. If the card name already exists throw ArgumentException
  +	Contains(name) – checks if a card with the given name is present in the deck
  +	Count – returns the number of cards in the deck
  +	Play(atackerCardName, atackedCardName) – find the attacker card and make damage to the attacked card. The attacker card can only attack other card if they both have the same level (otherwise throw ArgumentException). If the attacked card gets damage more than its current health it is no more available to play with, but it doesn’t get removed from the deck. If the attacker card kills the other card its score increases with the level of the attacked card. If the attacker tries to attack card with 0 or less health nothing happens. If any of the two provided cards does not exist throw ArgumentException
  +	Remove(name) – remove the card with the given name. If the card doesn’t exist return ArgumentException
  +	RemoveDeath() – remove all cards with health under or equal to 0
  +	GetBestInRange(int start, int end) – find all cards which have a score between the given two inclusive and ordered by their level descending. If you don’t find any return empty collection.
  +	ListCardsByPrefix(prefix) – return all cards starting with the specified prefix (sorted by the ASCII code of the reversed name in ascending order as a first criteria and by level in ascending order as a second criteria).
  +	SearchByLevel(int)– return all cards with the given level, order them by score descending
  +	Heal(int health) – finds the card with the smallest health and increases it with the given health. Cards with negative health can get heal too.
Feel free to override Equals() and GetHashCode() if necessary.

Input / Output

You are given a Visual Studio C# project skeleton (unfinished project) holding the interface IBoard, the unfinished classes Board and Card. Tests covering the Board functionality and performance.

Your task is to finish this class to make the tests run correctly.

  +	You are not allowed to change the tests.
  +	You are not allowed to change the interface.
  +	You can add to the Card class, but don't remove anything.
  +	You can edit the Board class if it implements the IBoard interface.