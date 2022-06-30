CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
BEGIN
	DECLARE @passengerId INT = (SELECT Id FROM Passengers WHERE Email = @email);

	DECLARE @numberOfFlightDestinations INT = (SELECT COUNT(*) 
												 FROM FlightDestinations 
												 WHERE PassengerId = @passengerId);

	RETURN @numberOfFlightDestinations;
END