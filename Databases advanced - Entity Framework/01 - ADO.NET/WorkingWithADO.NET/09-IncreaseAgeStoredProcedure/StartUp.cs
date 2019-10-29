using System;
using System.Data.SqlClient;

namespace _09_IncreaseAgeStoredProcedure
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string conString = "Server = DESKTOP-PHQG6TO\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true;";
            int minionId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                string updateQuery = "EXEC usp_GetOlder @id";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", minionId);
                    command.ExecuteNonQuery();
                }

                string selectMinionQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(selectMinionQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", minionId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} - {reader[1]} years old");
                        }
                    }
                }
            }
        }
    }
}
