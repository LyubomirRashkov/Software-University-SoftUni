   SELECT CountryName, DisributorName
     FROM (SELECT c.[Name] AS CountryName, 
	              d.[Name] AS DisributorName, 
	              DENSE_RANK() OVER (PARTITION BY c.[Name] ORDER BY COUNT(i.DistributorId) DESC) AS Ranked
             FROM Countries AS c
             JOIN Distributors AS d ON c.Id = d.CountryId
        LEFT JOIN Ingredients AS i ON d.Id = i.DistributorId
         GROUP BY c.[Name], d.[Name]) AS Temp
   WHERE Ranked = 1
ORDER BY CountryName, DisributorName