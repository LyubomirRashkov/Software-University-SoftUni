CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
BEGIN
	DECLARE @departmentId INT = (SELECT Id	
								   FROM VolunteersDepartments
								  WHERE DepartmentName = @VolunteersDepartment);

	RETURN (SELECT COUNT(*)
			  FROM Volunteers
			 WHERE DepartmentId = @departmentId);
END