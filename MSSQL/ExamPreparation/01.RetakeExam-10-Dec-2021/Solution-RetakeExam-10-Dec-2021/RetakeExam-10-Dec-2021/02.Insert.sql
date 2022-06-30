INSERT INTO Passengers (FullName, Email)
	(SELECT FirstName + ' ' + LastName AS FullName, FirstName + LastName + '@gmail.com' AS Email 
	  FROM Pilots
     WHERE Id BETWEEN 5 AND 15)