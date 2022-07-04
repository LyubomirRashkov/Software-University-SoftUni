CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS 
	   SELECT c.CigarName, 
		     '$' + CONVERT(VARCHAR, c.PriceForSingleCigar) AS Price, 
		      t.TasteType, 
		      b.BrandName, 
		      CONVERT(VARCHAR, s.[Length]) + ' cm' AS CigarLength, 
		      CONVERT(VARCHAR, s.RingRange) + ' cm' AS CigarRingRange
	     FROM Cigars AS c
	     JOIN Tastes AS t ON c.TastId = t.Id
	     JOIN Brands AS b ON c.BrandId = b.Id
	     JOIN Sizes AS s ON c.SizeId = s.Id
	    WHERE t.TasteType = @taste
     ORDER BY s.[Length], s.RingRange DESC