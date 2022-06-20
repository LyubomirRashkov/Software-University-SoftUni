CREATE PROC usp_GetTownsStartingWith (@startingSubstring VARCHAR(50))
AS
	 SELECT [Name] AS Town
	   FROM Towns
	  WHERE [Name] LIKE @startingSubstring + '%'