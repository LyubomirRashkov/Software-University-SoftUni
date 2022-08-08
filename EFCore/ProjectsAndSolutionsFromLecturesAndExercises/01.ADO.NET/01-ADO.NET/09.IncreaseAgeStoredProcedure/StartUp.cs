using Microsoft.Data.SqlClient;
using System;

namespace _09.IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        public static void Main()
        {
            string sqlConnectionString = "Server = (local)\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true; Encrypt = false";

            using SqlConnection connection = new SqlConnection(sqlConnectionString);

            connection.Open();

            int inputMinionId = int.Parse(Console.ReadLine());

            string executeStoredProcedureQuery = "EXEC usp_GetOlder @id";

            using SqlCommand executeStoredProcedureCommand = new SqlCommand(executeStoredProcedureQuery, connection);

            executeStoredProcedureCommand.Parameters.AddWithValue("@id", inputMinionId);

            executeStoredProcedureCommand.ExecuteNonQuery();

            string selectMinionInfoQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";

            using SqlCommand selectMinionInfoCommand = new SqlCommand(selectMinionInfoQuery, connection);

            selectMinionInfoCommand.Parameters.AddWithValue("@Id", inputMinionId);

            using SqlDataReader reader = selectMinionInfoCommand.ExecuteReader();

            reader.Read();

            Console.WriteLine($"{reader["Name"]} – {reader["Age"]} years old");
        }
    }
}
