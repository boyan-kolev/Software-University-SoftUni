using System;
using System.Data.SqlClient;
using System.Linq;

namespace _08_IncreaseMinionAge
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] minionIds = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string conString = "Server = DESKTOP-PHQG6TO\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true;";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string updateQuery = @"UPDATE Minions
                                        SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                      WHERE Id = @Id";

                for (int i = 0; i < minionIds.Length; i++)
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", minionIds[i]);
                        command.ExecuteNonQuery();
                    }
                }

                string selectMinionsSql = "SELECT Name, Age FROM Minions";

                using (SqlCommand command = new SqlCommand(selectMinionsSql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0] + " " + reader[1]);
                        }
                    }
                }
            }
        }
    }
}
