CREATE FUNCTION udf_HoursToComplete(@startDate DATETIME, @endDate DATETIME)
RETURNS INT
BEGIN
	IF(@startDate IS NULL OR @endDate IS NULL)
	BEGIN 
		RETURN 0;
	END

	RETURN DATEDIFF(HOUR, @startDate, @endDate);
END