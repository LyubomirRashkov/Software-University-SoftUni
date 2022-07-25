SELECT m.FirstName + ' ' + m.LastName AS Mechanic, 
	   j.[Status], j.IssueDate
  FROM Jobs AS j
  JOIN Mechanics AS m ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId