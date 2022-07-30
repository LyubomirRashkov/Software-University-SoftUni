  SELECT t.Id, 
	     a.FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS [Full Name],
	     ac.[Name] AS [From], 
	     hc.[Name] AS [To],
	     CASE 
    	     WHEN CancelDate IS NULL THEN (CONVERT(VARCHAR, DATEDIFF(DAY, ArrivalDate, ReturnDate))
									       + ' days')
		     ELSE 'Canceled'
	     END AS Duration 
    FROM Trips AS t
    JOIN AccountsTrips AS [at] ON t.Id = [at].TripId
    JOIN Accounts AS a ON [at].AccountId = a.Id
    JOIN Cities AS ac ON a.CityId = ac.Id
    JOIN Rooms AS R ON t.RoomId = r.Id
    JOIN Hotels AS h ON r.HotelId = h.Id
    JOIN Cities AS hc ON h.CityId = hc.Id
ORDER BY [Full Name], t.Id