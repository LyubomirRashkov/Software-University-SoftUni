CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(18,2)
BEGIN
	DECLARE @totalMoney MONEY = (SELECT SUM(p.Price * op.Quantity) 
	 FROM Jobs AS j
	 JOIN Orders AS o ON j.JobId = o.JobId
	 JOIN OrderParts AS op ON o.OrderId = op.OrderId
	 JOIN Parts AS p ON op.PartId = p.PartId
	WHERE j.JobId = @jobId);

	IF(@totalMoney IS NULL)
	BEGIN
		RETURN 0;
	END

	RETURN @totalMoney;
END