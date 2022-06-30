  SELECT p.FullName, COUNT(*) AS CountOfAircraft, SUM(fd.TicketPrice) AS TotalPayed
    FROM Passengers AS p
    JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
   WHERE p.FullName LIKE '_a%'
GROUP BY p.FullName
  HAVING COUNT(*) > 1
ORDER BY p.FullName