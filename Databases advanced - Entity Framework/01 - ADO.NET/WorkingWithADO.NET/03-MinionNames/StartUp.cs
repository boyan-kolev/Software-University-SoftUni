using System;
using System.Data.SqlClient;

namespace _03_MinionNames
{
    public class StartUp
    {
        private static string conString = "Server = DESKTOP-PHQG6TO\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true;";
        private static SqlConnection connection = new SqlConnection(conString);
        public static void Main(string[] args)
        {
            connection.Open();
            using (connection)
            {
                string input = Console.ReadLine();
                string villianQuery = "SELECT Name FROM Villains WHERE Id = @Id";


                using (SqlCommand command = new SqlCommand(villianQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", input);
                    string villianName = (string)command.ExecuteScalar();

                    if (villianName == null)
                    {
                        Console.WriteLine($"No villain with ID {input} exists in the database.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Villain: {villianName}");
                    }


                }

                string minionQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";
                using (SqlCommand command = new SqlCommand(minionQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", input);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int counter = 1;
                        while (reader.Read())
                        {
                            Console.WriteLine($"{counter++}. {reader["Name"]} {reader["Age"]}");
                        }

                        if (reader.HasRows == false)
                        {
                            Console.WriteLine("no minions");
                        }
                    }
                }


            }
        }
    }
}
