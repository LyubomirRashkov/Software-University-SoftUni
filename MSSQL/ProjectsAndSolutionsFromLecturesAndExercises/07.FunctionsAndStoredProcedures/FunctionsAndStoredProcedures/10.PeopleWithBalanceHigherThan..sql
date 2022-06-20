CREATE PROC usp_GetHoldersWithBalanceHigherThan (@minTotalSum DECIMAL(15,2))
AS
	  SELECT FirstName AS [First Name], 
			 LastName AS [Last Name] 
	    FROM AccountHolders AS ah 
	    JOIN Accounts AS a ON ah.Id = a.AccountHolderId
	GROUP BY FirstName, LastName
	  HAVING SUM(Balance) > @minTotalSum
	ORDER BY FirstName, LastName