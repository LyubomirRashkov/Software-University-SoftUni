CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	 DECLARE @counter SMALLINT = 1;

	 WHILE(@counter <= LEN(@word))
	 BEGIN
		  IF(CHARINDEX(SUBSTRING(@word, @counter, 1), @setOfLetters) = 0)
		  BEGIN
			   RETURN 0
		  END

		  SET @counter += 1;
	 END

	 RETURN 1
END