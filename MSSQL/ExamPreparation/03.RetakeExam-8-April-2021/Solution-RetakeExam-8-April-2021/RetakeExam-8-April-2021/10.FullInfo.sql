   SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee, 
		  ISNULL(d.[Name], 'None') AS Department, 
		  ISNULL(c.[Name],'None') AS Category,
		  ISNULL(r.[Description], 'None') AS [Description], 
		  ISNULL(FORMAT(r.OpenDate, 'dd.MM.yyyy'), 'None') AS OpenDate, 
		  ISNULL(s.[Label], 'None') AS [Status],
		  ISNULL(u.[Name], 'None') AS [User]
     FROM Reports AS r
LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
LEFT JOIN Categories AS c ON r.CategoryId = c.Id
LEFT JOIN [Status] AS s ON r.StatusId = s.Id
LEFT JOIN Users AS u ON r.UserId = u.Id
 ORDER BY e.FirstName DESC, 
		  e.LastName DESC, 
		  d.[Name], 
		  c.[Name], 
		  r.[Description], 
		  r.OpenDate, 
		  s.[Label], 
		  u.[Name]