CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
BEGIN
	DECLARE @numberOfCigars INT = (SELECT COUNT(*)
								     FROM Clients AS c
									 JOIN ClientsCigars AS cc ON c.Id = cc.ClientId
									WHERE FirstName = @name);

	RETURN @numberOfCigars;
END