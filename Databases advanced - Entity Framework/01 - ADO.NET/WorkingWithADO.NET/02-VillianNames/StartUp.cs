namespace _02_VillianNames
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = "Server = DESKTOP-PHQG6TO\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true;";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using (connection)
            {
                string cmdText = @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                        FROM Villains AS v
                                        JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                    GROUP BY v.Id, v.Name
                                      HAVING COUNT(mv.VillainId) > 3
                                    ORDER BY COUNT(mv.VillainId)";
                SqlCommand command = new SqlCommand(cmdText, connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " - " + reader[1]);
                }
            }
        }
    }
}
