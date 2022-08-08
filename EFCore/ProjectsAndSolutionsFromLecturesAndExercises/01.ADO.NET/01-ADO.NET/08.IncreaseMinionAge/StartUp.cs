using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace _08.IncreaseMinionAge
{
    public class StartUp
    {
        public static void Main()
        {
            string sqlConnectionString = "Server = (local)\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true; Encrypt = false";

            using SqlConnection connection = new SqlConnection(sqlConnectionString);

            connection.Open();

            int[] inputMinionIds = Console.ReadLine()
                                   .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();

            string updateMinionInfoQuery = @"UPDATE Minions
                                                SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                              WHERE Id = @Id";

            foreach (int minionId in inputMinionIds)
            {
                using SqlCommand updateMinionInfoCommand = new SqlCommand(updateMinionInfoQuery, connection);

                updateMinionInfoCommand.Parameters.AddWithValue("@Id", minionId);

                updateMinionInfoCommand.ExecuteNonQuery();
            }

            string selectMinionInfoQuery = "SELECT Name, Age FROM Minions";

            using SqlCommand selectMinionInfoCommand = new SqlCommand(selectMinionInfoQuery, connection);

            using SqlDataReader reader = selectMinionInfoCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} {reader["Age"]}");
            }
        }
    }
}
