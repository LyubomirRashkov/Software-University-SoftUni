SELECT DISTINCT Temp.DepartmentID, Temp.Salary AS ThirdHighestSalary
  FROM (SELECT DepartmentID, 
               Salary, 
			   DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Ranked]
          FROM Employees) AS Temp
 WHERE Ranked = 3