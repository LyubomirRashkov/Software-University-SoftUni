  SELECT cl.FirstName + ' ' + cl.LastName AS FullName, 
		 a.Country, 
		 a.ZIP, 
		 '$' + CONVERT(VARCHAR,MAX(cig.PriceForSingleCigar)) AS CigarPrice
    FROM Clients AS cl
    JOIN Addresses AS a ON cl.AddressId = a.Id
	JOIN ClientsCigars AS cc ON cl.Id = cc.ClientId
	JOIN Cigars AS cig ON cc.CigarId = cig.Id
   WHERE a.ZIP NOT LIKE '%[^0-9]%'
GROUP BY cl.FirstName, cl.LastName, a.Country, a.ZIP
ORDER BY FullName