using System;
using System.Data.SqlClient;

namespace _04_AddMinion
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string conString = "Server = DESKTOP-PHQG6TO\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true;";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string[] inputMinion = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string[] inputVillian = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

                string[] minionInfo = inputMinion[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string minionName = minionInfo[0];
                int age = int.Parse(minionInfo[1]);
                string town = minionInfo[2];

                string villian = inputVillian[1];


                string townNameQuery = "SELECT Name FROM Towns WHERE Name = @townName";
                using (SqlCommand selectCommand = new SqlCommand(townNameQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@townName", town);
                    string townName = (string)selectCommand.ExecuteScalar();

                    if (townName == null)
                    {
                        string createTownQuery = "INSERT INTO Towns (Name) VALUES (@townName)";
                        using (SqlCommand insertCommand = new SqlCommand(createTownQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@townName", town);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine($"Town {town} was added to the database.");
                        }
                    }
                }

                string villianNameQuery = "SELECT Name FROM Villains WHERE Name = @Name";
                using (SqlCommand selectCommand = new SqlCommand(villianNameQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@Name", villian);
                    string villianName = (string)selectCommand.ExecuteScalar();

                    if (villianName == null)
                    {
                        string createVillianQuery = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                        using (SqlCommand insertCommand = new SqlCommand(createVillianQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@villainName", villian);
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine($"Villain {villian} was added to the database.");
                        }
                    }
                }
                string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";
                int townId = -1;
                using (SqlCommand selectCommand = new SqlCommand(townIdQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@townName", town);
                    townId = (int)selectCommand.ExecuteScalar();
                }
                
                string createMinionQuery = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

                using (SqlCommand insertCommand = new SqlCommand(createMinionQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@name", minionName);
                    insertCommand.Parameters.AddWithValue("@age", age);
                    insertCommand.Parameters.AddWithValue("@townId", townId);

                    insertCommand.ExecuteNonQuery();
                }

                int villianId = -1;
                int minionId = -1;

                string selectVillianIdQuery = "SELECT Id FROM Villains WHERE Name = @Name";
                using (SqlCommand selectCommand = new SqlCommand(selectVillianIdQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@Name", villian);
                    villianId = (int)selectCommand.ExecuteScalar();
                }

                string selectMinionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";
                using (SqlCommand selectCommand = new SqlCommand(selectMinionIdQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@Name", minionName);
                    minionId = (int)selectCommand.ExecuteScalar();
                }


                try
                {
                    string insertMinonToVillianQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";
                    using (SqlCommand insertCommand = new SqlCommand(insertMinonToVillianQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@villainId", villianId);
                        insertCommand.Parameters.AddWithValue("@minionId", minionId);

                        insertCommand.ExecuteNonQuery();

                        Console.WriteLine($"Successfully added {minionName} to be minion of {villian}.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"The minion: {minionName} already set to be a servant of the villian: {villian}!");
                }
            }
        }
    }
}
