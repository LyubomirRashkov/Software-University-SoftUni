CREATE FUNCTION udf_GetAvailableRoom(@hotelId INT, @date DATE, @people INT)
RETURNS NVARCHAR(MAX)
BEGIN
	DECLARE @result NVARCHAR(MAX);

	DECLARE @hotelBaseRate DECIMAL(18,2) = (SELECT BaseRate FROM Hotels WHERE Id = @hotelId);

	DECLARE @roomPrice DECIMAL(18,2) = (SELECT TOP (1) r.Price 
										  FROM Rooms AS r
										 WHERE (r.HotelId = @hotelId) 
											   AND (r.Beds >= @people)
											   AND NOT EXISTS (SELECT * 
															     FROM Trips AS t 
																WHERE (r.Id = t.RoomId)
																	  AND (@date BETWEEN t.ArrivalDate AND                                                 t.ReturnDate 
																	       AND t.CancelDate IS NULL))
									  ORDER BY r.Price DESC);

	IF(@roomPrice IS NULL)
	BEGIN
		SET @result = 'No rooms available';
	END

	ELSE
	BEGIN
		DECLARE @roomId INT = (SELECT TOP (1) r.Id 
								 FROM Rooms AS r
							    WHERE (r.HotelId = @hotelId) 
								      AND (r.Beds >= @people)
									  AND NOT EXISTS (SELECT * 
													    FROM Trips AS t 
													   WHERE (r.Id = t.RoomId)
														     AND (@date BETWEEN t.ArrivalDate AND t.ReturnDate
																  AND t.CancelDate IS NULL))
						     ORDER BY r.Price DESC);

		DECLARE @roomType NVARCHAR(20) = (SELECT TOP (1) r.[Type] 
										    FROM Rooms AS r
										   WHERE (r.HotelId = @hotelId) 
											     AND (r.Beds >= @people)
											     AND NOT EXISTS (SELECT * 
														   	       FROM Trips AS t 
																  WHERE (r.Id = t.RoomId)
																	    AND (@date BETWEEN t.ArrivalDate                                                    AND t.ReturnDate 
																	        AND t.CancelDate IS NULL))
									    ORDER BY r.Price DESC);

		DECLARE @beds INT = (SELECT TOP (1) r.Beds 
							   FROM Rooms AS r
							  WHERE (r.HotelId = @hotelId) 
									AND (Beds >= @people)
									AND NOT EXISTS (SELECT * 
													  FROM Trips AS t 
													 WHERE (r.Id = t.RoomId)
														   AND (@date BETWEEN t.ArrivalDate AND t.ReturnDate 
															    AND t.CancelDate IS NULL))
						   ORDER BY r.Price DESC);

		DECLARE @totalPrice DECIMAL(18,2) = (@hotelBaseRate + @roomPrice) * @people;

		SET @result = 'Room ' + CONVERT(VARCHAR,@roomId) + ': ' + @roomType + ' (' + CONVERT(VARCHAR, @beds) +' beds) - $' + CONVERT(VARCHAR, @totalPrice);
	END

	RETURN @result;
END