CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	DECLARE @employeeDepartmentId INT = (SELECT DepartmentId 
										   FROM Employees 
										   WHERE Id = @EmployeeId);

	DECLARE @reportDepartmentId INT = (SELECT c.DepartmentId 
										 FROM Reports AS r 
										 JOIN Categories AS c ON r.CategoryId = c.Id
										 WHERE r.Id = @ReportId);

	IF(@employeeDepartmentId != @reportDepartmentId)
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1

	UPDATE Reports
	   SET EmployeeId = @EmployeeId
	 WHERE Id = @ReportId