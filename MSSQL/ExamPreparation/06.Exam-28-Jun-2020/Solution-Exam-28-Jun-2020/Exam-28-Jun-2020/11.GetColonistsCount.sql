CREATE FUNCTION dbo.udf_GetColonistsCount(@planetName VARCHAR (30))
RETURNS INT 
BEGIN
	DECLARE @colonistsCount INT = (SELECT COUNT(c.Id)
	                                 FROM Planets AS p
	                                 JOIN Spaceports AS s ON p.Id = s.PlanetId
	                                 JOIN Journeys AS j ON s.Id = j.DestinationSpaceportId
	                                 JOIN TravelCards AS tc ON j.Id = tc.JourneyId
	                                 JOIN Colonists AS c ON tc.ColonistId = c.Id
	                                WHERE p.[Name] = @planetName);

	RETURN @colonistsCount;
END