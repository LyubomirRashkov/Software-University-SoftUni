CREATE PROC usp_SwitchRoom(@tripId INT, @targetRoomId INT)
AS
	DECLARE @tripHotelId INT = (SELECT r.HotelId 
								  FROM Trips AS t
								  JOIN Rooms AS r ON t.RoomId = r.Id
								 WHERE t.Id = @tripId);

	DECLARE @targetRoomHotelId INT = (SELECT HotelId
	                                    FROM Rooms
									   WHERE Id = @targetRoomId);

	IF(@tripHotelId != @targetRoomHotelId)
		THROW 50001, 'Target room is in another hotel!', 1

	DECLARE @tripAccountsCount INT = (SELECT COUNT(*) 
										FROM Trips AS t
										JOIN AccountsTrips AS [at] ON t.Id = [at].TripId
									   WHERE t.Id = @tripId);

	DECLARE @targeTRoomBedsCount INT = (SELECT Beds 
									      FROM Rooms
								         WHERE Id = @targetRoomId);

	IF(@tripAccountsCount > @targeTRoomBedsCount)
		THROW 50002, 'Not enough beds in target room!', 1

	UPDATE Trips
	   SET RoomId = @targetRoomId
	 WHERE Id = @tripId;