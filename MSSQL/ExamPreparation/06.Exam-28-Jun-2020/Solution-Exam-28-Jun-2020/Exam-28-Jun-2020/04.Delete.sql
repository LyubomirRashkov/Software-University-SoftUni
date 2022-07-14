DELETE FROM TravelCards
 WHERE JourneyId IN (SELECT TOP (3) Id FROM Journeys)

DELETE FROM Journeys
 WHERE Id IN (SELECT TOP (3) Id FROM Journeys)