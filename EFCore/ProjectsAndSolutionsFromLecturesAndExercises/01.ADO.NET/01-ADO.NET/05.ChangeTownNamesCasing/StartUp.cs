using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace _05.ChangeTownNamesCasing
{
    public class StartUp
    {
        public static void Main()
        {
            string sqlConnectionString = "Server = (local)\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true; Encrypt = false";

            using SqlConnection connection = new SqlConnection(sqlConnectionString);

            connection.Open();

            string inputCountryName = Console.ReadLine();

            string updateTownNamesQuery = @"UPDATE Towns
                                               SET Name = UPPER(Name)
                                             WHERE CountryCode = (SELECT c.Id 
                                                                    FROM Countries AS c 
                                                                   WHERE c.Name = @countryName)";

            using SqlCommand updateTownNamesCommand = new SqlCommand(updateTownNamesQuery, connection);

            updateTownNamesCommand.Parameters.AddWithValue("@countryName", inputCountryName);

            int? affectedRows = updateTownNamesCommand.ExecuteNonQuery() as int?;

            if (affectedRows == 0)
            {
                Console.WriteLine("No town names were affected.");

                return;
            }

            string selectTownNamesQuery = @" SELECT t.Name AS TownName
                                               FROM Towns as t
                                               JOIN Countries AS c ON c.Id = t.CountryCode
                                              WHERE c.Name = @countryName";

            using SqlCommand selectTownNamesCommand = new SqlCommand(selectTownNamesQuery, connection);

            selectTownNamesCommand.Parameters.AddWithValue("@countryName", inputCountryName);

            using SqlDataReader reader = selectTownNamesCommand.ExecuteReader();

            List<string> townNames = new List<string>();

            while (reader.Read())
            {
                townNames.Add(reader["TownName"] as string);
            }

            Console.WriteLine($"{affectedRows} town names were affected.");

            Console.WriteLine($"[{String.Join(", ", townNames)}]");
        }
    }
}
