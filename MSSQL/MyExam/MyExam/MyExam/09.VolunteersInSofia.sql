  SELECT v.[Name],
	     v.PhoneNumber,
	     REPLACE(REPLACE(v.[Address], 'Sofia , ', ''), 'Sofia, ', '') AS [Address]
    FROM Volunteers AS v
    JOIN VolunteersDepartments AS vd ON v.DepartmentId = vd.Id
   WHERE vd.DepartmentName = 'Education program assistant' 
	     AND v.[Address] LIKE '%Sofia%'
ORDER BY v.[Name]