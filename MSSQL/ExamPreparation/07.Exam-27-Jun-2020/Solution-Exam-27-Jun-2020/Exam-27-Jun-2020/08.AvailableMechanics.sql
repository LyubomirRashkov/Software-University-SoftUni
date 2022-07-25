   SELECT m.FirstName + ' ' + m.LastName AS Available
     FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
    WHERE j.JobId IS NULL OR NOT EXISTS (SELECT *
								FROM Jobs
							   WHERE MechanicId = m.MechanicId AND [Status] != 'Finished'
							GROUP BY MechanicId, [Status])
GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId


   SELECT m.FirstName + ' ' + m.LastName AS Available
     FROM Mechanics AS m
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
    WHERE j.JobId IS NULL OR (SELECT COUNT(*)
								FROM Jobs
							   WHERE MechanicId = m.MechanicId AND [Status] != 'Finished'
							GROUP BY MechanicId, [Status]) IS NULL
GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId



  SELECT FirstName + ' ' + LastName AS Available
    FROM Mechanics
   WHERE MechanicId NOT IN (SELECT MechanicId FROM Jobs WHERE [Status] = 'In Progress')
GROUP BY MechanicId, FirstName, LastName