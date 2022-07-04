ALTER TABLE Clients
ALTER COLUMN AddressID INT NULL

UPDATE Clients
   SET AddressId = NULL
 WHERE Id IN (SELECT Id 
				FROM Addresses 
				WHERE Country LIKE 'c%')

DELETE FROM Addresses
 WHERE Country LIKE 'c%'