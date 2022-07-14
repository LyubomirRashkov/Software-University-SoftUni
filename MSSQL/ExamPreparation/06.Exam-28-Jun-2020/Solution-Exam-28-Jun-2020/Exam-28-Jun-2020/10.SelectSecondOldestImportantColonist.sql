SELECT *
  FROM (SELECT tc.JobDuringJourney AS JobDuringJourney, 
			   CONCAT(c.FirstName, ' ', c.LastName) AS FullName, 
			   DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate) AS JobRank
          FROM Colonists AS c
          JOIN TravelCards AS tc ON c.Id = tc.ColonistId) AS Temp
 WHERE JobRank = 2
