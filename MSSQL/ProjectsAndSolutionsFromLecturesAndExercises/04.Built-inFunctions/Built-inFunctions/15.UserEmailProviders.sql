  SELECT [UserName] AS [Username], 
	     SUBSTRING([Email], 
				   CHARINDEX('@', [Email]) + 1, 
				   LEN([Email]) - CHARINDEX('@', [Email]) + 1) AS [Email Provider]
    FROM Users
ORDER BY [Email Provider], [Username]