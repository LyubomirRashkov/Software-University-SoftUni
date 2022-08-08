using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _07.PrintAllMinionNames
{
    public class StartUp
    {
        public static void Main()
        {
            string sqlConnectionString = "Server = (local)\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true; Encrypt = false";

            using SqlConnection connection = new SqlConnection(sqlConnectionString);

            connection.Open();

            string selectMinionNamesQuery = "SELECT Name FROM Minions";

            using SqlCommand selectMinionNamesCommand = new SqlCommand(selectMinionNamesQuery, connection);

            using SqlDataReader reader = selectMinionNamesCommand.ExecuteReader();

            List<string> minionNames = new List<string>();

            while (reader.Read())
            {
                minionNames.Add(reader["Name"] as string);
            }

            for (int i = 0; i < minionNames.Count / 2; i++)
            {
                Console.WriteLine($"{minionNames[i]}");

                Console.WriteLine($"{minionNames[minionNames.Count - 1 - i]}");
            }

            if (minionNames.Count % 2 != 0)
            {
                Console.WriteLine(minionNames[minionNames.Count / 2]);
            }
        }
    }
}
