using System;
using System.Data.SqlClient;

namespace _06_RemoveVillian
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int villianId = int.Parse(Console.ReadLine());
            string villianName = string.Empty;

            string conString = "Server = DESKTOP-PHQG6TO\\SQLEXPRESS; Database = MinionsDB; Integrated Security = true;";


            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                string selectIdQuery = "SELECT Name FROM Villains WHERE Id = @villainId";
                using (SqlCommand command = new SqlCommand(selectIdQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villianId);
                    villianName = (string)command.ExecuteScalar();


                    if (villianName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }
                }

                int affectedRows = DeleteMinionVillianById(villianId, connection);
                deleteVillianById(villianId, connection);

                Console.WriteLine($"{villianName} was deleted.");
                Console.WriteLine($"{affectedRows} minions were released.");
            }

        }

        private static void deleteVillianById(int villianId, SqlConnection connection)
        {
            string deleteQuery = @"DELETE FROM Villains
                                   WHERE Id = @villainId";

            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villianId);
                command.ExecuteNonQuery();
            }
        }

        private static int DeleteMinionVillianById(int villianId, SqlConnection connection)
        {
            string deleteQuery = @"DELETE FROM MinionsVillains 
                                   WHERE VillainId = @villainId";

            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villianId);
                return command.ExecuteNonQuery();
            }
        }
    }
}
