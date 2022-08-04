CREATE PROC usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
	DECLARE @ownerId INT = (SELECT OwnerId
							  FROM Animals
							 WHERE [Name] = @AnimalName);

	DECLARE @ownerName VARCHAR(50);

	IF(@ownerId IS NULL)
	BEGIN
		SET @ownerName = 'For adoption';
	END
	ELSE
	BEGIN
		SET @ownerName = (SELECT [Name]
							FROM Owners
						   WHERE Id = @ownerId);
	END

	SELECT @AnimalName AS [Name], @ownerName AS OwnersName