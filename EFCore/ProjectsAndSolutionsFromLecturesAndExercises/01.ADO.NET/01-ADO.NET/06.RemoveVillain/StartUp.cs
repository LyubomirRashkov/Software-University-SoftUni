using Microsoft.Data.SqlClient;
using System;

namespace _06.RemoveVillain
{
    public class StartUp
    {
        public static void Main()
        {
            string sqlConnectionString = "Server = (local)\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true; Encrypt = false";

            using SqlConnection connection = new SqlConnection(sqlConnectionString);

            connection.Open();

            int inputVillainId = int.Parse(Console.ReadLine());

            using SqlTransaction transaction = connection.BeginTransaction();

            string selectVillainNameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";

            using SqlCommand selectVillainNameCommand = new SqlCommand(selectVillainNameQuery, connection, transaction);

            selectVillainNameCommand.Parameters.AddWithValue("@villainId", inputVillainId);

            string villainName = selectVillainNameCommand.ExecuteScalar() as string;

            if (villainName == null)
            {
                Console.WriteLine("No such villain was found.");

                transaction.Rollback();

                return;
            }

            string deleteFromMinionsVillainsQuery = @"DELETE FROM MinionsVillains 
                                                       WHERE VillainId = @villainId";

            using SqlCommand deleteFromMinionsVillainsCommand = new SqlCommand(deleteFromMinionsVillainsQuery, connection, transaction);

            deleteFromMinionsVillainsCommand.Parameters.AddWithValue("@villainId", inputVillainId);

            int affectedRows = deleteFromMinionsVillainsCommand.ExecuteNonQuery();

            string deleteVillainQuery = @"DELETE FROM Villains
                                           WHERE Id = @villainId";

            using SqlCommand deleteVillainCommand = new SqlCommand(deleteVillainQuery, connection, transaction);

            deleteVillainCommand.Parameters.AddWithValue("@villainId", inputVillainId);

            deleteVillainCommand.ExecuteNonQuery();

            Console.WriteLine($"{villainName} was deleted.");

            Console.WriteLine($"{affectedRows} minions were released.");

            transaction.Commit();
        }
    }
}
