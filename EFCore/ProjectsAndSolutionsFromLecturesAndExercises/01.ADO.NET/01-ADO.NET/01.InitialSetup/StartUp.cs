using Microsoft.Data.SqlClient;

namespace _01.InitialSetup
{
    public class StartUp
    {
        public static void Main()
        {
            string sqlConnectionStringBase = "Server = (local)\\SQLEXPRESS; Database = master; Integrated Security = true; Encrypt = false";

            using SqlConnection connectionBase = new SqlConnection(sqlConnectionStringBase);

            connectionBase.Open();

            string createDBQuery = "CREATE DATABASE MinionsDB";

            using SqlCommand sqlCreateDBCommand = new SqlCommand(createDBQuery, connectionBase);

            sqlCreateDBCommand.ExecuteNonQuery();

            string sqlConnectionString = "Server = (local)\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true; Encrypt = false";

            using SqlConnection connection = new SqlConnection(sqlConnectionString);

            connection.Open();

            string[] createTableQueries = new string[]
            {
                "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))",
                "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))",
                "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))"
            };

            foreach (string query in createTableQueries)
            {
                using SqlCommand sqlCreateTableCommand = new SqlCommand(query, connection);

                sqlCreateTableCommand.ExecuteNonQuery();
            }

            string[] insertIntoQueries = new string[]
            {
                "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')",
                "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 4),('Frankfurt', 4),('Oslo', 5)",
                "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)",
                "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')",
                "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)",
                "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)"
            };

            foreach (string query in insertIntoQueries)
            {
                using SqlCommand sqlInsertIntoCommand = new SqlCommand(query, connection);

                sqlInsertIntoCommand.ExecuteNonQuery();
            }
        }
    }
}
