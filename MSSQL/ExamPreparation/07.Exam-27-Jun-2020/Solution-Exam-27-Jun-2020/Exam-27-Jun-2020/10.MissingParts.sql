   SELECT p.PartId, 
		  p.[Description], 
		  pn.Quantity AS [Required], 
		  p.StockQty AS [In Stock], 
		  IIF(o.Delivered = 'False', op.Quantity, 0) AS Ordered
     FROM Parts AS p 
LEFT JOIN PartsNeeded AS pn ON p.PartId = pn.PartId
LEFT JOIN Jobs AS j ON pn.JobId = J.JobId
LEFT JOIN OrderParts AS op ON p.PartId = op.PartId
LEFT JOIN Orders AS o ON j.JobId = o.JobId
    WHERE j.[Status] != 'Finished' AND p.StockQty < pn.Quantity AND o.Delivered IS NULL
 ORDER BY p.PartId