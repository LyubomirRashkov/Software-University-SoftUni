  SELECT a.Id AS AircraftId,
		 a.Manufacturer, 
		 a.FlightHours, 
		 COUNT(*) AS FlightDestinationsCount, 
		 ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
    FROM Aircraft AS a
    JOIN FlightDestinations AS fd ON a.Id = fd.AircraftId
GROUP BY a.Id, a.Manufacturer, a.FlightHours
  HAVING COUNT(*) >=2
ORDER BY FlightDestinationsCount DESC, a.Id