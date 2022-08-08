using Microsoft.Data.SqlClient;
using System;

namespace _02.VillainNames
{
    public class StartUp
    {
        public static void Main()
        {
            string sqlConnectionString = "Server = (local)\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true; Encrypt = false";

            using SqlConnection connection = new SqlConnection(sqlConnectionString);

            connection.Open();

            string selectQuery = @"SELECT v.Name AS [VillainName], COUNT(mv.VillainId) AS MinionsCount  
                                     FROM Villains AS v 
                                     JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                 GROUP BY v.Id, v.Name 
                                   HAVING COUNT(mv.VillainId) > 3 
                                 ORDER BY COUNT(mv.VillainId)";

            using SqlCommand command = new SqlCommand(selectQuery, connection);

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["VillainName"]} - {reader["MinionsCount"]}");
            }
        }
    }
}
