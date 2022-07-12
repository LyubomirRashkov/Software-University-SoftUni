CREATE VIEW v_UserWithCountries AS
	 SELECT CONCAT(cus.FirstName, ' ', cus.LastName) AS CustomerName, 
	  	    cus.Age, 
		    cus.Gender, 
		    coun.[Name] AS CountryName
	   FROM Customers AS cus
       LEFT JOIN Countries AS coun ON cus.CountryId = coun.Id