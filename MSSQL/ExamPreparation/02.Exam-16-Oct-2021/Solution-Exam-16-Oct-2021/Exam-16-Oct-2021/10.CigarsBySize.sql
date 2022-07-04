  SELECT cl.LastName, 
		 AVG(s.[Length]) AS CigarLength, 
		 CEILING(AVG(s.RingRange)) AS CigarRingRange
    FROM Clients AS cl
    JOIN ClientsCigars AS cc ON cl.Id = cc.ClientId
    JOIN Cigars AS cig ON cc.CigarId = cig.Id
	JOIN Sizes AS s ON cig.SizeId = s.Id
GROUP BY cl.LastName
ORDER BY CigarLength DESC