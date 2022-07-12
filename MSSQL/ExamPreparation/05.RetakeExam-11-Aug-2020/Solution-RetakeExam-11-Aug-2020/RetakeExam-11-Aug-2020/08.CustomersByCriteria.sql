   SELECT cus.FirstName, cus.Age, cus.PhoneNumber
     FROM Customers AS cus
LEFT JOIN Countries AS coun ON cus.CountryId = coun.Id
    WHERE (cus.Age >= 21 AND cus.FirstName LIKE '%an%') 
		  OR (cus.PhoneNumber LIKE '%38' AND coun.[Name] != 'Greece')
 ORDER BY cus.FirstName, cus.Age DESC