  SELECT u.Username, c.[Name] AS CategoryName
    FROM Reports AS r
    JOIN Users AS u ON r.UserId = u.Id
    JOIN Categories AS c ON r.CategoryId = c.Id
   WHERE (DATEPART(DAY, u.Birthdate) = DATEPART(DAY, r.OpenDate)) 
		 AND (DATEPART(MONTH, u.Birthdate) = DATEPART(MONTH, r.OpenDate))
ORDER BY u.Username, c.[Name]