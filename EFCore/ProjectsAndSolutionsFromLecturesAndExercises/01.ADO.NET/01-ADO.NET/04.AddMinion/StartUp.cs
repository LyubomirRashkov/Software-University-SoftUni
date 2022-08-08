using Microsoft.Data.SqlClient;
using System;
using System.Text;

namespace _04.AddMinion
{
    public class StartUp
    {
        public static void Main()
        {
            string[] inputMinionInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string inputMinionName = inputMinionInfo[1];
            int inputMinionAge = int.Parse(inputMinionInfo[2]);
            string inputMinionTown = inputMinionInfo[3];

            string[] inputVillainInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string inputVillainName = inputVillainInfo[1];

            string sqlConnectionString = "Server = (local)\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true; Encrypt = false";

            using SqlConnection connection = new SqlConnection(sqlConnectionString);

            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();

            StringBuilder sb = new StringBuilder();

            string selectTownIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";

            using SqlCommand selectTownIdCommand = new SqlCommand(selectTownIdQuery, connection, transaction);

            selectTownIdCommand.Parameters.AddWithValue("@townName", inputMinionTown);

            int? townId = selectTownIdCommand.ExecuteScalar() as int?;

            if (townId == null)
            {
                string insertIntoTownsQuery = "INSERT INTO Towns (Name) VALUES (@townName)";

                using SqlCommand insertIntoTownsCommand = new SqlCommand(insertIntoTownsQuery, connection, transaction);

                insertIntoTownsCommand.Parameters.AddWithValue("@townName", inputMinionTown);

                insertIntoTownsCommand.ExecuteNonQuery();

                townId = selectTownIdCommand.ExecuteScalar() as int?;

                sb.AppendLine($"Town {inputMinionTown} was added to the database.");
            }

            string selectVillainIdQuery = "SELECT Id FROM Villains WHERE Name = @villainName";

            using SqlCommand selectVillainIdCommand = new SqlCommand(selectVillainIdQuery, connection, transaction);

            selectVillainIdCommand.Parameters.AddWithValue("@villainName", inputVillainName);

            int? villainId = selectVillainIdCommand.ExecuteScalar() as int?;

            if (villainId == null)
            {
                string inputIntoVillainsQuery = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES (@villainName, 4)";

                using SqlCommand inputIntoVillainsCommand = new SqlCommand(inputIntoVillainsQuery, connection, transaction);

                inputIntoVillainsCommand.Parameters.AddWithValue("@villainName", inputVillainName);

                inputIntoVillainsCommand.ExecuteNonQuery();

                villainId = selectVillainIdCommand.ExecuteScalar() as int?;

                sb.AppendLine($"Villain {inputVillainName} was added to the database.");
            }

            string selectMinionIdQuery = "SELECT Id FROM Minions WHERE Name = @minionName AND Age = @minionAge And TownId = @minionTownId";

            using SqlCommand selectMinionIdCommand = new SqlCommand(selectMinionIdQuery, connection, transaction);

            selectMinionIdCommand.Parameters.AddWithValue("@minionName", inputMinionName);
            selectMinionIdCommand.Parameters.AddWithValue("@minionAge", inputMinionAge);
            selectMinionIdCommand.Parameters.AddWithValue("@minionTownId", townId);

            int? minionId = selectMinionIdCommand.ExecuteScalar() as int?;

            if (minionId == null)
            {
                string insertIntoMinionsQuery = "INSERT INTO Minions (Name, Age, TownId) VALUES (@minionName, @minionAge, @minionTownId)";

                using SqlCommand insertIntoMinionsCommand = new SqlCommand(insertIntoMinionsQuery, connection, transaction);

                insertIntoMinionsCommand.Parameters.AddWithValue("@minionName", inputMinionName);
                insertIntoMinionsCommand.Parameters.AddWithValue("@minionAge", inputMinionAge);
                insertIntoMinionsCommand.Parameters.AddWithValue("@minionTownId", townId);

                insertIntoMinionsCommand.ExecuteNonQuery();

                minionId = selectMinionIdCommand.ExecuteScalar() as int?;
            }

            string insertIntoMinionsVillainsQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

            using SqlCommand insertIntoMinionsVillainsCommand = new SqlCommand(insertIntoMinionsVillainsQuery, connection, transaction);

            insertIntoMinionsVillainsCommand.Parameters.AddWithValue("@minionId", minionId);
            insertIntoMinionsVillainsCommand.Parameters.AddWithValue("@villainId", villainId);

            insertIntoMinionsVillainsCommand.ExecuteNonQuery();

            sb.AppendLine($"Successfully added {inputMinionName} to be minion of {inputVillainName}.");

            transaction.Commit();

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
