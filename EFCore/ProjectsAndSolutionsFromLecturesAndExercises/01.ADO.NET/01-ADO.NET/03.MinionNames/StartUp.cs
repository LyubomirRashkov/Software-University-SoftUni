using Microsoft.Data.SqlClient;
using System;

namespace _03.MinionNames
{
    public class StartUp
    {
        public static void Main()
        {
            string sqlConnectionString = "Server = (local)\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true; Encrypt = false";

            using SqlConnection connection = new SqlConnection(sqlConnectionString);

            connection.Open();

            int inputId = int.Parse(Console.ReadLine());

            string selectVillainNameQuery = "SELECT Name FROM Villains WHERE Id = @Id";

            using SqlCommand selectVillainNameCommand = new SqlCommand(selectVillainNameQuery, connection);

            selectVillainNameCommand.Parameters.AddWithValue("@Id", inputId);

            string villainName = selectVillainNameCommand.ExecuteScalar() as string;

            if (villainName == null)
            {
                Console.WriteLine($"No villain with ID {inputId} exists in the database.");

                return;
            }

            Console.WriteLine($"Villain: {villainName}");

            string selectMinionNamesQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                                     m.Name AS MinionName, 
                                                     m.Age AS MinionAge
                                                FROM MinionsVillains AS mv
                                                JOIN Minions As m ON mv.MinionId = m.Id
                                               WHERE mv.VillainId = @Id
                                            ORDER BY m.Name";

            using SqlCommand selectMinionNamesCommand = new SqlCommand(selectMinionNamesQuery, connection);

            selectMinionNamesCommand.Parameters.AddWithValue("@Id", inputId);

            using SqlDataReader reader = selectMinionNamesCommand.ExecuteReader();

            if (!reader.HasRows)
            {
                Console.WriteLine("(no minions)");
            }

            while (reader.Read())
            {
                Console.WriteLine($"{reader["RowNum"]}. {reader["MinionName"]} {reader["MinionAge"]}");
            }
        }
    }
}
