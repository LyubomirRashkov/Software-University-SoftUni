CREATE PROC usp_ChangeJourneyPurpose(@journeyId INT, @newPurpose VARCHAR(11))
AS
	DECLARE @journeyIdVerified INT = (SELECT Id 
										FROM Journeys 
									   WHERE Id = @journeyId);

	IF(@journeyIdVerified IS NULL)
		THROW 50001, 'The journey does not exist!', 1;

	DECLARE @journeyPurpose VARCHAR(11) = (SELECT Purpose
											 FROM Journeys
											WHERE Id = @journeyIdVerified);

	IF(@journeyPurpose = @newPurpose)
		THROW 50002, 'You cannot change the purpose!', 1;

	UPDATE Journeys
	   SET Purpose = @newPurpose
	 WHERE Id = @journeyId;